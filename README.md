# AutoMouseClicker

AutoMouseClicker is a small Windows desktop app for repeating left or right mouse clicks at a fixed or randomized interval.

## Download and Run

Download **AutoMouseClicker.exe** from the [latest rolling release](https://github.com/EdenBeavis/AutoMouseClicker/releases/tag/rolling). It is a self-contained Windows x64 executable: no installer or separate .NET runtime is needed. Save it somewhere convenient and open it to run the app.

Windows may display a security warning for an unsigned or unrecognized application. Only run the executable if you downloaded it from this repository's Releases page and trust its source.

## How to Use

- Choose left or right click and select a fixed or random delay. Set the base interval and, for random delays, the variance in milliseconds.
- The global start/stop hotkey defaults to **F6**. To change it, select the hotkey field and press a key or key combination. The app shows whether the shortcut could be registered.
- Start clicking with the hotkey. Clicks are sent at the current mouse pointer position.
- Choose whether the hotkey stops clicking or whether clicking stops after a specified number of clicks.
- Select **Hide to tray** to hide the window. Double-click the tray icon to show it again; use its menu to show the app or exit.

Settings are saved in `%LOCALAPPDATA%\AutoMouseClicker\settings.json` and restored the next time the app starts.

## Build and Run from Source

You need Windows and the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).

```powershell
dotnet restore AutoMouseClicker.sln
dotnet build AutoMouseClicker.sln --configuration Release
dotnet run --project AutoMouseClicker/AutoMouseClicker.csproj
```

## Contributing

Fork the repository, create a branch for your change, and open a pull request targeting `main`. Please build the solution before submitting; pull requests are also checked by GitHub Actions.

Every push to `main` updates the [rolling release](https://github.com/EdenBeavis/AutoMouseClicker/releases/tag/rolling). It always contains the latest main build rather than keeping a separate release for every commit.

## Versioned Releases

The root `VERSION` file controls stable releases. Pushing normal changes to `main` updates the rolling release; when `VERSION` is higher than the latest versioned release, GitHub Actions creates a fixed release with the self-contained executable, a SHA-256 checksum, and a WinGet manifest. Leave `VERSION` unchanged for ordinary updates. For a new release, change it to the next `MAJOR.MINOR.PATCH` version (for example, `1.0.1`) in the release-ready change and push or merge that change to `main`; no manual Git tag is needed.

See [WinGet release preparation](packaging/winget/README.md) for the package submission steps.