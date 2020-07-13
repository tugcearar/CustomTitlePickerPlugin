using Android.Runtime;
using System;
using Android.Content;
using Android.App;
using Android.Widget;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.CustomTitlePicker.Shared;
using Plugin.CustomTitlePicker.Platforms.Droid;

[assembly: ExportRenderer(typeof(TitlePicker), typeof(CustomTitlePickerRenderer))]
namespace Plugin.CustomTitlePicker.Platforms.Droid
{
    /// <summary>
    /// CustomTitlePicker Implementation
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CustomTitlePickerRenderer : PickerRenderer
    {
#pragma warning disable CS0618 // Type or member is obsolete
        public CustomTitlePickerRenderer() : base()
#pragma warning restore CS0618 // Type or member is obsolete
        {
        }

        AlertDialog _dialog;
        IElementController ElementController => Element as IElementController;
        TitlePicker customPicker;
        public CustomTitlePickerRenderer(Context context) : base(context)
        {
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public async static void Init()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null || e.OldElement != null)
                return;

            customPicker = e.NewElement as TitlePicker;
            Control.Click += Control_Click;
        }

        private void Control_Click(object sender, EventArgs e)
        {
            Picker model = Element;
            if (_dialog != null)
                return;
            var picker = new NumberPicker(Context);
            if (model.Items != null && model.Items.Any())
            {
                picker.MaxValue = model.Items.Count - 1;
                picker.MinValue = 0;
                picker.SetDisplayedValues(model.Items.ToArray());
                picker.WrapSelectorWheel = false;
                picker.DescendantFocusability = Android.Views.DescendantFocusability.BlockDescendants;
                picker.Value = model.SelectedIndex;
            }

            var layout = new LinearLayout(Context) { Orientation = Orientation.Vertical };
            layout.AddView(picker);

            ElementController.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, true);

            var builder = new AlertDialog.Builder(Context);
            builder.SetView(layout);
            builder.SetTitle(model.Title ?? "");
            builder.SetNegativeButton(customPicker.CancelButtonText ?? "Cancel", (s, a) =>
            {
                ElementController.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, false);
                _dialog = null;
            });
            builder.SetPositiveButton(customPicker.DoneButtonText ?? "Accept", (s, a) =>
            {
                ElementController.SetValueFromRenderer(Picker.SelectedIndexProperty, picker.Value);
                // It is possible for the Content of the Page to be changed on SelectedIndexChanged.
                // In this case, the Element & Control will no longer exist.
                if (Element != null)
                {
                    if (model.Items.Count > 0 && Element.SelectedIndex >= 0)
                        Control.Text = model.Items[Element.SelectedIndex];
                    ElementController.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, false);
                }
                _dialog = null;
            });

            _dialog = builder.Create();
            _dialog.DismissEvent += (dSender, dArgs) =>
            {
                ElementController?.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, false);
                _dialog?.Dispose();
                _dialog = null;
            };
            _dialog.Show();
        }
    }
}