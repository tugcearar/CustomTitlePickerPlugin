using System.ComponentModel;
using System;
using Xamarin.Forms;

namespace Plugin.CustomTitlePicker.Shared
{
    /// <summary>
    /// 
    /// </summary>
    //[DesignTimeVisible(true)]
    public class TitlePicker : Picker
    {
        public string DoneButtonText
        {
            get
            {
                return (string)GetValue(DoneButtonTextProperty);
            }
            set
            {
                SetValue(DoneButtonTextProperty, value);
            }
        }

        public static readonly BindableProperty DoneButtonTextProperty = BindableProperty.Create(
                                                          propertyName: "DoneButtonTextProperty",
                                                          returnType: typeof(string),
                                                          declaringType: typeof(TitlePicker),
                                                          defaultValue: string.Empty);

        public string CancelButtonText
        {
            get
            {
                return (string)GetValue(CancelButtonTextProperty);
            }
            set
            {
                SetValue(CancelButtonTextProperty, value);
            }
        }

        public static readonly BindableProperty CancelButtonTextProperty = BindableProperty.Create(
                                                          propertyName: "CancelButtonTextProperty",
                                                          returnType: typeof(string),
                                                          declaringType: typeof(TitlePicker),
                                                          defaultValue: string.Empty);
    }
}