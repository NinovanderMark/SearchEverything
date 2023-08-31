# What is Search Everything
This is a simple C# application to search for directories, files and the contents of files. It offers a CLI and a Windows-only GUI application, both offering the same functionality.

Borne out of a frustration at Window's built-in search functionality, it may be better than that, but there are tons of better applications out there. I would generally recommend you use those instead.

# Getting Started
## CLI
Simply run the CLI providing the search string, the path to search in, and a boolean indicating whether to search through files' contents, as command-line arguments, in that order.
`SearchEverything.CLI.exe foo.json . false`
`SearchEverything.CLI.exe <html> C:\Websites true`

Aside from the first argument, the others are optional, but there is no way to provide them in an alternate order. That means that if you want to search through file contents, you'll have to provide a search path as well.

## GUI
Start the GUI application, and provide the required arguments through the interface. Search results will be displayed in a table-like format.

![afbeelding](https://github.com/NinovanderMark/SearchEverything/assets/6692167/97cc387c-ba6e-4db9-b2e2-90811f1a1d97)

# Alternate platforms
The GUI application is a Windows Forms application, which can only target Windows. The CLI should be able to run on any platform where .NET 6 will run. To compile it for one of these platforms, run `dotnet build` with the `--os` parameter, indicating the target OS to build for.

For more information, see the Microsoft documentation on `dotnet build`:

https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-build
