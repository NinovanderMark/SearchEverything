# What is Search Everything
This is a simple C# application to search for directories, files and the contents of files. It offers a CLI and a Windows-only GUI application, both offering the same functionality.

Borne out of a frustration at Window's built-in search functionality, it may be better than that, but there are tons of better applications out there. I would generally recommend you use those instead.

# Getting Started
Searching with SearchEverything a user can search for a match on the path of a file or directory, or for a match on the contents of the file. 

Optionally this search can be made recursively, to include files/directories in subdirectories of the point.

Below subheaders describe how to provide these arguments for the different frontends.


SearchEverything comes with Windows binaries, which only depend on the .NET 6 [runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) being present. Alternatively, the repository can be cloned and built locally, provided the .NET SDK is installed.

## CLI
Simply run the CLI providing a path to match, followed by the content to match, optionally the starting folder to search from and whether to search recursively. An empty string for the initial parameters is considered a 'match everything' symbol.
```
# Searches for <canvas> elements in all html files in the current directory and all subdirectories
SearchEverything.CLI.exe .html <canvas> . true
# Searches for all .json files on the C:\ drive
SearchEverything.CLI.exe .json "" C:\
```

## GUI
Start the GUI application, and provide the required arguments through the interface. Search results will be displayed in a table-like format.

![afbeelding](https://github.com/NinovanderMark/SearchEverything/assets/6692167/55b48f34-eb7d-44a0-9190-06c8335b871d)

# Alternate platforms
The GUI application is a Windows Forms application, which can only target Windows. The CLI should be able to run on any platform where .NET 6 will run. To compile it for one of these platforms, run `dotnet build` with the `--os` parameter, indicating the target OS to build for.

For more information, see the Microsoft documentation on `dotnet build`:

https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-build
