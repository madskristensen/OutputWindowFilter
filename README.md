[marketplace]: https://marketplace.visualstudio.com/items?itemName=MadsKristensen.OutputWindowFilter
[vsixgallery]: https://www.vsixgallery.com/extension/OutputWindowFilter.daaf649c-5187-405c-bff8-e0dd79f30573/
[repo]: https://github.com/madskristensen/OutputWindowFilter

# Output Window Filter for Visual Studio

[![Build](https://github.com/madskristensen/OutputWindowFilter/actions/workflows/build.yaml/badge.svg)](https://github.com/madskristensen/OutputWindowFilter/actions/workflows/build.yaml)

Download this extension from the [Visual Studio Marketplace][marketplace]
or get the [CI build][vsixgallery].

--------------------------------------

Adds a filter textbox to the Output Window that lets you filter the output based on text matches and regular expressions.

![screenshot](art/screenshot.gif)

## Features

- **Real-time filtering** - Filter output as you type
- **Regular expression support** - Use regex patterns for advanced filtering
- **Match highlighting** - Matching text is highlighted for easy identification
- **Filter history** - Previously used filters are saved in a dropdown for quick access
- **Works with all output panes** - Build, Debug, Test, and any other output

## How to Use

1. Open the **Output Window** (`View → Output` or `Ctrl+Alt+O`)
2. Type your filter text in the **Filter** textbox in the Output Window toolbar
3. Press **Enter** to apply the filter
4. Only lines containing matches will be visible; matching text is highlighted
5. Clear the filter text to show all output again

### Filter Examples

| Filter | Description |
|--------|-------------|
| `error` | Shows lines containing "error" (case-insensitive) |
| `warning\|error` | Shows lines containing "warning" OR "error" |
| `^Build` | Shows lines starting with "Build" |
| `failed$` | Shows lines ending with "failed" |
| `CS\d{4}` | Shows lines with C# compiler codes (e.g., CS0246) |

## Customization

You can customize the highlight color in **Tools → Options → Environment → Fonts and Colors**. Search for **"Output Filter - Match Highlight"** to change the background and foreground colors.

## How can I help?

If you enjoy using the extension, please give it a ★★★★★ rating on the [Visual Studio Marketplace][marketplace].

Should you encounter bugs or if you have feature requests, head on over to the [GitHub repo][repo] to open an issue if one doesn't already exist.

Pull requests are also very welcome, since I can't always get around to fixing all bugs myself. This is a personal passion project, so my time is limited.

Another way to help out is to [sponsor me on GitHub](https://github.com/sponsors/madskristensen).
