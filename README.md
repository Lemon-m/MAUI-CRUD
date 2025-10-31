# MAUI CRUD

Simple app made in .NET MAUI for creating, reading, updating and deleting products in a .csv file.

## Requirements

- Visual Studio 2022/2023 with .NET MAUI workload installed
- Android SDK
- Physical device or Android emulator

## How to run

1. Clone the repo:
```bash
git clone https://github.com/Lemon-m/MAUI-CRUD.git
```

2. Open the project in Visual Studio.
3. Choose **Debug** or **Release**.
4. Connect your physical device or start your emulator.
5. Press **Start** (F5).

## Building the APK

1. Right click `MAUI CRUD` in the solution explorer and choose 'Properties'.
2. Click the Android tab on the left 
3. Under Manifest, set Android Package Format to `apk`.
4. Build the project → you'll find the .apk file in `bin\Release\net9.0-android`.

## Warning

-  `bin/` and `obj/` folders and other temporary files are ignored by `.gitignore`.
