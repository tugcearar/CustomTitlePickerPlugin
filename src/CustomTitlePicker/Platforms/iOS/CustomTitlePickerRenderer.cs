using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;
using Plugin.CustomTitlePicker.Shared;
using CustomTitlePicker.Platforms.iOS;

[assembly: ExportRenderer(typeof(TitlePicker), typeof(CustomTitlePickerRenderer))]
namespace Plugin.CustomTitlePicker.Platforms.iOS
{
    /// <summary>
    /// ImageCircle Implementation
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CustomTitlePickerRenderer : PickerRenderer
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public async static void Init()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            var temp = DateTime.Now;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null) return;
            var customPicker = e.NewElement as TitlePicker;
            if (Control == null)
            {
                SetNativeControl(new UITextField
                {
                    RightViewMode = UITextFieldViewMode.Always,
                    ClearButtonMode = UITextFieldViewMode.WhileEditing,
                });
                SetUIButton(customPicker.DoneButtonText);
            }
            else
            {
                SetUIButton(customPicker.DoneButtonText);
            }
        }

        public void SetUIButton(string doneButtonText)
        {
            UIToolbar toolbar = new UIToolbar();
            toolbar.BarStyle = UIBarStyle.Default;
            toolbar.Translucent = true;
            toolbar.SizeToFit();
            UIBarButtonItem doneButton = new UIBarButtonItem(String.IsNullOrEmpty(doneButtonText) ? "Accept" : doneButtonText, UIBarButtonItemStyle.Done, (s, ev) =>
            {
                Control.ResignFirstResponder();
            });
            UIBarButtonItem flexible = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
            toolbar.SetItems(new UIBarButtonItem[] { doneButton, flexible }, true);
            Control.InputAccessoryView = toolbar;
        }
    }
}