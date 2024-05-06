# FuseGames
Small Games Developed for the FUSE program. Organized into directories containing the projects themselves.

# List of Games

1. [**Hyperspeed**](https://sdasd30.github.io/FuseHyperspeed/)
2. [**FuseDDR**](https://sdasd30.github.io/FuseDDR/)

# Compilation Guide
To compile the game, you will need Unity Editor version 2022.3.16f1. You can aquire this Unity version through the project managment application [Unity Hub](https://unity.com/unity-hub).
You will need to aquire a license to use this, which will mean you likely need to create a new account. A free personal license will do.

Once Unity Hub is open, you can open the project through the "Add" button. Select one of the subfolders of this Directory (e.g, FUSEInfiniteRace, FuseDDR) to add it to Unity Hub. It should appear in the list of projects below. 

When you select the game, it will ask you to install the associated Unity Version, Unity Editor version 2022.3.16f1. To install a different Unity version, go to the Installs sidebar on the left side of Unity Hub, and pick the desired version. While updating the game to a newer Unity version should not cause any issues, I recommend keeping the version the same, unless a version specific bug appears. 

When installing the Unity editor, make sure you **select WebGL Build Support**.

Either way, once your Unity editor is open, it should bring you to the Main Scene.

In the top left of the Unity Editor, under the File, go to Build Settings. From there, select "WebGL" as the platform. Most of the build options should be set already, but if there is a specific issue, check the right side to change settings such as texture compression or code compression. Additional settings can also be found in the Player Settings... button in the bottom left corner.

Once the desired settings are selected, click Build, and it will bring up a window of your filesystem. This is to select where you want the build files to go. Select any appropriate location for your files, and Unity should automatically start building. The build can take upwards of 10 minutes.

When complete, another file explorer should appear with the results of the build.
