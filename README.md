# Autostarter
Allows an executable to be automatically started upon Windows boot.

## Usage
Enabling/disabling autostart is as simple as:<br />
```
var autostarter = new Autostarter(Application.ExecutablePath); // or any other path
autostarter.Enable();
autostarter.Disable();
```

## Installation

### NuGet
Can be installed using NuGet simply by running: <br />
`PM> Install-Package Autostarter` (Using GUI-based installers: search for '[Autostarter](https://www.nuget.org/packages/Autostarter/)')

### DLL-file
While NuGet is the preferred installation method, you can also add the DLL-file as a reference in Visual Studio.
You can find the latest DLL-file under [releases](https://github.com/danielsunnerberg/Autostarter/releases).
