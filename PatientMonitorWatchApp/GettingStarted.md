﻿*Recommended Markdown viewer: [Markdown Editor VS Extension](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor)*

# Getting started
The generated project is intended as a starting point, and can be modified and extended as you want. If you are new to Tizen .NET, start with [Get Started with .NET Applications](https://docs.tizen.org/application/dotnet/get-started/overview).

There are a few concepts to understand before start working on this generated code:
* [Xamarin.Forms](https://docs.microsoft.com/xamarin/get-started/what-is-xamarin-forms)
* [Xamarin.Forms Shell](https://docs.microsoft.com/xamarin/xamarin-forms/app-fundamentals/shell/)
* [CircularUI](https://github.com/Samsung/Tizen.CircularUI)

## Project structure
The generated project includes the following files in the top-level directory:
* **Main.cs**: Manages life-cycle of Tizen application and loads Xamarin.Forms Application.
* **App.xaml and App.xaml.cs**: Extends Xamarin.Forms Application which sets the root page of the application.
* **AppShell.xaml and AppShell.xaml.cs**: Extends Xamarin.Froms Shell which provides a common navigation user experience.
* **tizen-manifest.xml**: Includes information such as Application ID and privilege used when install and launch an application. 
* **template.manifest**: Includes information such as template version used by Tizen Template Studio.

In addition, files for selected templates are shown in the following directories:
* **Views**: Contains the files of selected pages which users actually see on device.
* **Services**: Contains the files of selected features. It helps to use watch device API or service more easily.
* **Resources**: Contains AppResource.resx which stores strings shown on device.
* **ViewModels**: Contains the view model classes for MVVM design pattern.
* **Models**: Contains the model classes which encapsulate the data.
* **Mvvm**: Contains the base classes for MVVM design pattern.
* **Extensions**: Contains the extensions of existing classes and markup extensions for XAML.
* **Converters**: Contains data converters used when convert data during binding.
* **res**: Contains resource files such as image and sound used by this application only.
* **shared**: Contains data files to be shared with other applications. An icon file is included in `shared/res`.

Among the above directories, `res` and `shared` are predefined directories in Tizen. **Do not change the name of these directories**. For more details about directory hierarchy in Tizen application, see [File System Directory Hierarchy](https://docs.tizen.org/application/native/tutorials/details/io-overview).

## Extend the generated project
Before starting the development, check out **Task List** on **Task List Window** first. Tizen Template Studio provides templates for general purpose, so you need to modify and extend the generated code to meet your requirements.

### Add additional template
Even after creating a project, you can add templates while developing the project. Tizen Template Studio provides a context menu which merges additional template into the generated project.

Select **Project** on **Solution Explorer** and right-click, then you can find **Tizen Template Studio** context menu. Using this context menu, you can select a template you want to add. For more details, see [Tizen Template Studio](https://github.com/Samsung/TizenTemplateStudio).

**Do not remove or edit `template.manifest`** because available templates vary with project configuration and Tizen Template Studio gets that information from `template.manifest`. 

---
You can learn more about generating a project at [Tizen Template Studio](https://github.com/Samsung/TizenTemplateStudio).

# Generation summary
The following changes have been incorporated into your project:

## Pages

### Grid Layout - Workout
The grid layout organizes its children into rows and columns.
#### New files:
* Views/WorkoutPage.xaml
* Views/WorkoutPage.xaml.cs
* ViewModels/WorkoutViewModel.cs
* res/WorkoutSample.png
#### Modified files:
* Resources/AppResources.resx
* Resources/AppResources.Designer.cs

### Information Popup - RandomHealthInfo
An InformationPopup provides single text and progress relevant to the user's current situation.
#### New files:
* Views/RandomHealthInfoPage.xaml
* Views/RandomHealthInfoPage.xaml.cs
* ViewModels/RandomHealthInfoViewModel.cs
#### Modified files:
* Resources/AppResources.resx
* Resources/AppResources.Designer.cs

### Center Layout - HeartbeatMonitor
A center layout places the main piece of content in the middle of the screen.
#### New files:
* Views/HeartbeatMonitorPage.xaml
* Views/HeartbeatMonitorPage.xaml.cs
* ViewModels/HeartbeatMonitorViewModel.cs
* res/HeartbeatMonitorSample.png
#### Modified files:
* Resources/AppResources.resx
* Resources/AppResources.Designer.cs

## Features

### Sleep Monitor
Track the sleep data.
#### New files:
* Services/SleepMonitorService.cs
#### Modified files:
* tizen-manifest.xml
* Main.cs
* App.xaml.cs
#### Dependent features:
* Privacy Permission

### Pedometer
Record the number of steps taken.
#### New files:
* Services/PedometerService.cs
#### Modified files:
* tizen-manifest.xml
* Main.cs
* App.xaml.cs
#### Dependent features:
* Privacy Permission

### Heart Rate Monitor
Measure heart rate.
#### New files:
* Services/HeartRateMonitorService.cs
#### Modified files:
* tizen-manifest.xml
* Main.cs
* App.xaml.cs
#### Dependent features:
* Privacy Permission

### Samsung Accessory Protocol
Exchange data with a paired phone using Samsung Accessory Protocol.
#### New files:
* Services/SamsungAccessoryProtocolService.cs
* res/xml/accessoryservices.xml
#### Modified files:
* tizen-manifest.xml

### Network Access
Access the internet on a watch.
#### New files:
* Services/NetworkAccessService.cs
* Services/NetworkAccessService.Sample.cs
#### Modified files:
* tizen-manifest.xml

### Location
Obtain the geographical information.
#### New files:
* Services/LocationService.cs
#### Modified files:
* Resources/AppResources.resx
* Resources/AppResources.Designer.cs
* App.xaml.cs
* tizen-manifest.xml
#### Dependent features:
* Privacy Permission

### Privacy Permission
Ask the user to grant the privacy permissions at runtime.
#### New files:
* Services/PrivacyPermissionService.cs
* Services/PrivacyPermissionService.Samples.cs
* Services/PrivacyPrivilege.cs

### Localization
Localize an application.
#### New files:
* Converters/LocalizedResourceConverter.cs
* Extensions/LocalizingExtension.cs
* Extensions/StringExtensions.cs
* Services/LocalizationService.cs
* Views/LocalizationService.SamplePage.xaml
* Views/LocalizationService.SamplePage.xaml.cs
