## Custom Picker Control Plugin for Xamarin.Forms

 A custom picker plugin where you can change the Cancel/Done text of the control as you wish.
 
#### Setup
* Available on NuGet: [![NuGet](https://img.shields.io/nuget/v/Xamarin.Forms.CustomTitlePickerPlugin.svg?label=NuGet)](https://www.nuget.org/packages/Xamarin.Forms.CustomTitlePickerPlugin/)
*  [https://www.nuget.org/packages/Xamarin.Forms.CustomTitlePickerPlugin/](https://www.nuget.org/packages/Xamarin.Forms.CustomTitlePickerPlugin/)
* Build status: [![Build Status](https://dev.azure.com/stugcearar/CustomTitlePickerPlugin/_apis/build/status/CustomTitlePickerPlugin-CI?branchName=master)](https://dev.azure.com/stugcearar/CustomTitlePickerPlugin/_build/latest?definitionId=2&branchName=master)
* Install into your PCL project and Client projects.


**Platform Support**

|Platform|Version|
| -------------------  | :------------------: |
|Xamarin.iOS|iOS 7+|
|Xamarin.Android|API 14+|

#### Usage

**XAML:**

First add the xmlns namespace:
```xml
xmlns:customTitlePicker="clr-namespace:Plugin.CustomTitlePicker.Shared;assembly=Plugin.CustomTitlePicker"
```

Then add the xaml:

```xml
 <customTitlePicker:TitlePicker DoneButtonText="My Done Text"
                                CancelButtonText="My Cancel Text">
</customTitlePicker:TitlePicker>
```

**Bindable Properties**

You are able to set the ```DoneButtonText``` to a text to display a Done button text and also ```CancelButtonText``` to a text to display a Cancel button text for your picker.

These are supported in iOS and Android.

#### License
Licensed under MIT, see license file


### Want To Support This Project?
All I have ever asked is to be active by submitting bugs, features, and sending those pull requests down!
