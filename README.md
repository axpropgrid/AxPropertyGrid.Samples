# AxPropertyGrid.Samples

A comprehensive sample application demonstrating all features of [AxPropertyGrid.WPF](https://axpropertygrid.com) — a modern WPF property grid control for .NET 8.

## Overview

This sample project showcases three configuration modes and covers every major feature of the AxPropertyGrid library, including type-specific editors, layout organization, localization, custom editors, and theming.

![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![WPF](https://img.shields.io/badge/WPF-Application-5C2D91?logo=windows)
![Windows](https://img.shields.io/badge/Platform-Windows_10%2B-0078D6?logo=windows)

## Run the Sample

```bash
cd AxPropertyGrid.Samples
dotnet run
```

> Requires .NET 8.0 SDK and Windows 10 (Build 19041+).

## Three Configuration Modes

The application provides a combo box to switch between three demo objects, each demonstrating a different configuration approach:

### 1. SampleObject — Attribute-Based Configuration

All settings are defined via attributes on the model class. No `AxGridSetting` is needed — just assign the object to `SelectedObject`.

```csharp
pg.SelectedObject = new SampleObject();
```

This is the simplest approach and covers:

- **All property types**: `bool`, `string`, all numeric types (`int`, `uint`, `long`, `ulong`, `short`, `ushort`, `byte`, `sbyte`, `float`, `double`, `decimal`), `DateTime`, `DateOnly`, `TimeOnly`, `Color`, `Size`, `Point`, enums, and custom types.
- **Editor styles**: Toggle switches, radio groups (horizontal/vertical), multi-line text, date/time pickers, numeric spinners with prefix/suffix.
- **Layout attributes**: `[AxAutoUniformWidthLineUp]` for grouping properties on the same line, `[AxNextTo]` for adjacent placement.
- **Nested properties**: `[AxInnerProperty]` to flatten a 3-level object hierarchy into dot-notation paths.
- **Custom editors**: Via `IAxContainCustomEditors` interface.
- **Localization**: Display names resolved from `.resx` resource files using the convention `"Properties.Resources.ResourceKey"`.

Example:

```csharp
[AxProperty("Port", "Connection", helpText: "Server port number")]
[AxIntegerEdit(1, 65535, 1)]
public int Port { get; set; } = 5432;

[AxProperty("Use SSL", "Security", EditorStyle = ValueEditorStyle.Bool_ToggleSwitch)]
public bool UseSsl { get; set; } = true;

[AxAutoUniformWidthLineUp("size", 1)]
public double Width { get; set; } = 100;

[AxAutoUniformWidthLineUp("size", 2)]
public double Height { get; set; } = 200;
```

### 2. ServerConnectionSettings — GridSetting Fluent API

All configuration is done programmatically using `AxGridSetting`, with **no attributes** on the model class. Ideal for dynamic or runtime configuration.

```csharp
pg.GridSetting = ServerConnectionSettings.BuildSettings();
pg.SelectedObject = new ServerConnectionSettings();
```

The `AxGridSetting` fluent API provides:

```csharp
var settings = new AxGridSetting(typeof(ServerConnectionSettings));

// Ignore properties
settings.AddIgnoredProperty("InternalToken");

// Create groups with ordering
settings.CreateGroup("Connection", "Connection", order: 1);
settings.CreateGroup("Security", "Security", order: 2);

// Configure properties
settings.SetPropertyGeneralInformation("Port", "Port", group: "Connection");
settings.SetNumericTypePropertyValueStepRange<int>("Port", 1, 65535, 1);
settings.SetPropertyEditorStyle("Protocol", ValueEditorStyle.Enum_RadioGroup_Horizontal);

// Enum display text
settings.SetEnumValueDisplayText<ProtocolType>(ProtocolType.Tcp, "TCP/IP");
settings.SetEnumValueDisplayText<ProtocolType>(ProtocolType.Udp, "UDP");

// Layout
settings.SetPropertyInUniformWidthLine("ConnectionTimeout", "PerfLine1", 0);
settings.SetPropertyNextToAnotherProperty("MaxBytesPerSecond", "DataRate");
```

### 3. ApplicationSettings — Explicit Properties Mode

The class is marked with `[AxExplicitProperties]`, so **only** properties decorated with `[AxProperty]` are displayed. All others are automatically hidden — no `[AxPropertyIgnore]` needed.

```csharp
[AxExplicitProperties]
public class ApplicationSettings
{
    // These are hidden automatically (no [AxProperty])
    public int InternalId { get; set; }
    public string SettingsVersion { get; set; }
    public bool IsDirty { get; set; }

    // Only these are shown
    [AxProperty("Window Title", "General", helpText: "The main window caption")]
    public string WindowTitle { get; set; } = "My Application";

    [AxProperty("Font Size", "Appearance")]
    [AxIntegerEdit(8, 72, 1, "", "pt")]
    public int FontSize { get; set; } = 14;
}
```

## Features Demonstrated

### Type-Specific Editors

| Type | Editors Available |
|------|-------------------|
| `bool` | Checkbox, Toggle Switch |
| `string` | Single-line, Multi-line, Multi-line with AcceptReturn |
| `int`, `double`, `float`, `decimal`, etc. | Numeric spinner with min/max/step/prefix/suffix |
| `DateTime` | Date picker, Date & Time picker, Time-only picker |
| `DateOnly` / `TimeOnly` | Native type support |
| `Color` | Color picker |
| `Size` | Width/Height with field labels and range |
| `Point` | X/Y with configurable precision |
| `enum` | ComboBox, Horizontal Radio Group, Vertical Radio Group |
| Custom types | Via `IAxContainCustomEditors` or `AxGridSetting` |

### Layout Organization

- **Property Lining Up** — Group multiple properties on one uniform-width line via `[AxAutoUniformWidthLineUp("groupName", lineNumber)]` or `SetPropertyInUniformWidthLine()`.
- **Next-To Placement** — Place a property adjacent to another via `[AxNextTo("PropertyName")]` or `SetPropertyNextToAnotherProperty()`.
- **Property Groups** — Organize properties into collapsible groups with `[AxProperty("displayName", "groupName")]` or `CreateGroup()`.

### Nested Properties

Expose properties from nested objects using `[AxInnerProperty]` with dot-notation paths:

```csharp
[AxInnerProperty("Property2", "innerProp1")]
[AxInnerProperty("InnerProperty.InnerDoubleProperty", "innerProp2", EditorStyle = ValueEditorStyle.Numeric_Double)]
[AxInnerProperty("InnerProperty.InnerType2.InnerStringProperty", "innerProp3")]
public AxLibType InnerProperty { get; set; } = new AxLibType();
```

### Localization

The sample includes resource files for 6 languages:

- English (`Resources.resx`)
- Chinese (`Resources.zh.resx`)
- Korean (`Resources.ko.resx`)
- Russian (`Resources.ru.resx`)
- German (`Resources.de.resx`)
- Spanish (`Resources.es.resx`)

Localized display names use the resource key convention:

```csharp
[AxProperty("Properties.Resources.LocaledBoolPropName", "Properties.Resources.LocaledPropGroupName",
             helpText: "Properties.Resources.LocaledBoolPropHelp")]
public bool LocaledBool { get; set; }
```

Enum values can also be localized:

```csharp
public enum EnumType
{
    Value1,
    [AxEnumValueDisplayText("Properties.Resources.LocaledEnumValueText")]
    Value2,
    Value3
}
```

Switch languages at runtime via the language selector in the sample app.

### Theming

Click any color swatch in the sample to apply a theme at runtime using `ThemeManager.ApplyTheme()`. The theme system performs an HSL-based color shift across all control resources.

```csharp
AxControls.ThemeManager.ApplyTheme(Colors.SkyBlue);
```

### Custom Value Editors

The `SampleObject` class implements `IAxContainCustomEditors` to provide a custom editor for the `LibTypeProperty`:

```csharp
public bool IsCustomEditorAvailable(string propertyName) => propertyName == nameof(LibTypeProperty);

public FrameworkElement CreateValueEditor(string propertyName, object propertyValue, object propertyOwner)
{
    if (propertyName == nameof(LibTypeProperty))
        return new AxLibObjEditor();
    return null;
}
```

### Read-Only Properties

Properties with `private set` are automatically detected and displayed as read-only in the grid.

## Project Structure

```
AxPropertyGrid.Samples/
├── AxPropertyGrid.Samples.csproj
├── App.xaml / App.xaml.cs          # Language initialization from settings.json
├── MainWindow.xaml / .xaml.cs      # PropertyGrid host with theme/language selectors
├── Models/
│   ├── SampleObject.cs             # Attribute-based demo (IAxContainCustomEditors)
│   ├── AxLibType.cs                # Nested type for custom editor & inner property demos
│   ├── ExplicitPropertiesExample.cs # [AxExplicitProperties] demo
│   └── GridSettingExample.cs       # AxGridSetting fluent API demo
└── Properties/
    ├── Resources.resx              # Default resources
    ├── Resources.zh.resx           # Chinese
    ├── Resources.ko.resx           # Korean
    ├── Resources.ru.resx           # Russian
    ├── Resources.de.resx           # German
    └── Resources.es.resx           # Spanish
```

## More Information

- **Product page**: [axpropertygrid.com](https://axpropertygrid.com)
- **Documentation**: [axpropertygrid.com/docs](https://axpropertygrid.com/docs)
- **NuGet**: `Install-Package AxPropertyGrid.WPF`
