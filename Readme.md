Set this program up to be ran via the "External Tools" menu in Visual Studio and pass in $(SolutionDir) as arguments. You can also configure a keyboard shortcut to execute the program (CTRL + ALT + F5 for instance).

The program searches the directory structure for DLLs which end in "Tests.dll" under the the "bin" directory. You can set the path to NUnit in the NUnitLauncherConfig.xml.
