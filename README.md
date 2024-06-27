# Developer-Console v1.7.0

A mod for The Long Dark that makes Hinterland's developer console accessible in-game.

## Instructions

- Press F1 to open or close the developer console
- Use `help` to get a list of all commands
- Use `search X` to get a list of all commands that include `X`
- Press the TAB key to auto-complete a command
- Auto-completion also works on the arguments of certain commands, such as "gear_add"

## Dependencies

- ModSettings

## Changelog

1.7.0
- ModSettings integration
- Button for opening console can be customized
- Slider for console font size
- Method addition: Modders can disable the "add" command for items

Example:
"DeveloperConsole.GearList.RemoveFromConsole("GEAR_BearHide", true);"

First argument: itemname (works with or without gear_ prefix), upper/lower case does not matter
Second argument: If true the adding fails silently, if its set to false a notification will appear in the console and log
