# NonStop
**NonStop** allows one to deactivate/hide the possibility of shutting down (or sleeping) a **Windows** system.   

## Screenshot
![NonStop](https://user-images.githubusercontent.com/37046652/226178897-9b22a6fc-3996-4813-8ea0-d90bf7140c8a.png)

## Building
1. Get the source (Cloning/Downloading)
2. Open the **NonStop.sln** with Visual Studio for example
3. Build the project
4. There should now be a **NonStop.exe** which you can run

## Notes
The program was tested on **Windows 10 x64**.   

## How does it work?
**NonStop** alters registry values in the background so that shutting down/sleeping is not possible anymore on the given machine.   
(Look at **src/NonStopTool.cs** to see the mentioned registry keys)

## Limitations
The program cannot currently stop a user from shutting down a system via **PowerShell**/**CMD** which is not easily possible.

## Hacking
Ideas and suggestions are welcome in general.   
If you like to submit a patch make sure to format your code accordingly.
