# Visual Scratch

A Windows desktop application that provides a modern, integrated development environment for creating and editing Scratch projects (.sb3 files) using the powerful TurboWarp editor.

## Features

- **TurboWarp Integration**: Edit Scratch projects using the enhanced TurboWarp editor embedded directly in the application
- **Project Management**: Create, open, and organize Scratch projects with ease
- **Modern UI**: Built with Krypton UI components for a polished, professional look
- **Dockable Windows**: Flexible workspace with dockable panels and tabbed documents
- **.sb3 Support**: Full support for Scratch 3.0 project files

## Installation

### For End Users

1. Download the latest release from the [Releases](https://github.com/turbotoad12/Visual-Scratch/releases) page
2. Locate the `setup.msi` file in the release assets
3. Run `setup.msi` and follow the installation wizard
4. Once installed, launch Visual Scratch from your Start Menu

**Note**: There are no releases available yet. Once releases are published, you'll be able to download and install Visual Scratch using the steps above.

## System Requirements

- **Operating System**: Windows 7 or later
- **.NET Framework**: 4.8 or higher
- **WebView2 Runtime**: Required for the TurboWarp editor (installer will prompt to install if not present)

## Building from Source

### Prerequisites

- Visual Studio 2022 or later
- .NET Framework 4.8 SDK
- Windows Installer Projects Extension (optional, for building the installer)

### Build Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/turbotoad12/Visual-Scratch.git
   cd Visual-Scratch
   ```

2. Open the solution:
   - Open `Visual Scratch.slnx` in Visual Studio

3. Restore NuGet packages:
   - Visual Studio should automatically restore packages
   - Or manually restore: `Tools > NuGet Package Manager > Restore NuGet Packages`

4. Build the solution:
   - Press `F6` or select `Build > Build Solution`
   - The output will be in `Visual Scratch/bin/Debug` or `Visual Scratch/bin/Release`

### Dependencies

The project uses the following NuGet packages:
- **Krypton Suite** (v100.25.11.328): UI components for ribbons, docking, navigation, toolkit, and workspace
- **Microsoft.Web.WebView2** (v1.0.3650.58): For embedding the TurboWarp editor
- **System.Text.Json** (v10.0.1): JSON serialization for project files

## Usage

1. **Create a New Project**: 
   - Click the "New Project" button on the ribbon
   - Enter project details (name, author, description)
   - Choose a location to save your project

2. **Open an Existing Project**:
   - Click the "Open Project" button on the ribbon
   - Navigate to your Visual Scratch project file

3. **Edit in TurboWarp**:
   - Projects automatically open in the integrated TurboWarp editor
   - Use all TurboWarp features to create your Scratch project

## License

This project is licensed under the GNU General Public License v3.0 - see the [LICENSE](LICENSE) file for details.

Copyright © 2025 TurboToad12

## Acknowledgements

- [Scratch](https://scratch.mit.edu/) - The visual programming language this editor supports
- [TurboWarp](https://turbowarp.org/) - The enhanced Scratch editor used within this application
- [Krypton Toolkit](https://github.com/Krypton-Suite/Standard-Toolkit) - UI components
- [WebView2](https://developer.microsoft.com/en-us/microsoft-edge/webview2/) - Microsoft Edge WebView2 control

## Contributing

Contributions are welcome! Submit issues or pull requests to help improve the project.

## Support

If you encounter any issues or have questions, please [open an issue](https://github.com/turbotoad12/Visual-Scratch/issues) on GitHub.