# What is Search Everything
This is a simple C# application to search for directories, files and the contents of files. It offers a CLI and a Windows-only GUI application, both offering the same functionality.

Borne out of a frustration at Window's built-in search functionality, it may be better than that, but there are tons of better applications out there. I would generally recommend you use those instead.

# Getting Started
SearchEverything comes with Windows binaries, which only depend on the .NET 6 [runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) being present. Alternatively, the repository can be cloned and built locally, provided the .NET SDK is installed.

## CLI
Simply run the CLI providing a path to match, followed by the content to match and optionally the starting folder to search from. An empty string for the initial parameters is considered a 'match everything' symbol.
```
# Searches for <canvas> elements in all html files in the current directory and all subdirectories
SearchEverything.CLI.exe .html <canvas> .
# Searches for all .json files on the C:\ drive, and any subdirectories
SearchEverything.CLI.exe .json "" C:\
```

Aside from the first argument, the others are optional, but there is no way to provide them in an alternate order. That means that if you want to search through file contents, you'll have to provide a search path as well.

## GUI
Start the GUI application, and provide the required arguments through the interface. Search results will be displayed in a table-like format.

![afbeelding](https://github.com/NinovanderMark/SearchEverything/assets/6692167/ff3141f3-d641-4765-bc2e-2125298127f9)

# Alternate platforms
The GUI application is a Windows Forms application, which can only target Windows. The CLI should be able to run on any platform where .NET 6 will run. To compile it for one of these platforms, run `dotnet build` with the `--os` parameter, indicating the target OS to build for.

For more information, see the Microsoft documentation on `dotnet build`:

https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-build
