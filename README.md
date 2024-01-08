<!--
  logo
  <img src="https://cdn.discordapp.com/attachments/888136140564095007/1091974996965982279/Ek9VjzB.png?raw=true" height=144>
-->
<!--
  banner with no text
  <img src="https://user-images.githubusercontent.com/120770627/230755565-04f6b0f3-9de7-4d8f-96a3-c7add6872857.png?raw=true">
-->
<!-- banner with text -->
<img src="https://user-images.githubusercontent.com/120770627/230755569-33b4feac-b65c-40af-890f-728149635ea6.png?raw=true">

<br>
<p align="center">
  <a href="https://learn.microsoft.com/en-us/dotnet/csharp">
    <img src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white">
  </a>
  <a href="https://unity.com">
    <img src="https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white">
  </a>
  <a href="https://windows.com">
    <img src="https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white">
  </a>
</p>
<p align="center"><i>"Mission: Monkey" is the first game created by Lemon Studios</i></p>
<hr>

## 🚀 Recommended PC Specs to play:
1. Windows 10 or 11, MacOS 10.11 or higher, or Linux with any Desktop environment installed
2. A decent CPU
3. A GPU that supports DirectX12 (For Windows) or Vulkan (For Linux)

## ⚙️ Requirements to Develop
1. Windows or Linux (MacOS might be possible but good luck pal)
2. [Unity 2023.2.3](https://unity.com/releases/editor/archive#download-archive-2023)
3. [Blender 4.0+](https://www.blender.org/download/)
4. A C++ compiler (See compiler instructions below)
5. ~5-10GB of storage to clone the source code and download all the packages required for the project

### C++ Compiler
Windows 10/11: Use [Visual Studio 2022](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community). Install the "Desktop Development With C++" and "Game Development With Unity" modules, and add at least one Windows 10/11 SDK

MacOS: Install the [XCode C++ Compiler](https://www.cs.rhodes.edu/~kirlinp/courses/cs2/s17/installing-clion/xcode.html)

Linux: A C++ Compiler should be installed by default, you can check this by running ```cpp --version``` or ```c++ --version```. If you do not have a C++ compiler installed, Google: "Install C++ Compiler [Distribution Name]"

After meeting the above requirements, clone the repoository with git (or use GitHub Desktop):
```sh
git clone https://github.com/Lemons-Studios/Mission-Monkey.git
```
Add the project to the Unity Hub, and you are good to launch the game!

## 🏗️ Build From Source
To build from source, you must have all of the software mentioned in **Requirements to Develop** installed, as well as the ~5-10GB of storage required to have the project on your computer
Follow the exact same steps provided on how to open the project in **Requirements to Develop**. Once you have the project open, navigate to the ["build settings" tab](https://cdn.discordapp.com/attachments/888136140564095007/1174972604847771739/image.png?ex=65698982&is=65571482&hm=216d691f61f592c5fe6c86d884b92a40366e25f26158b118bdf07426ac5f4c96&), and select your build options from there.

> **Note**
> 
> If you are attempting to build for MacOS on a non-Mac, you must [turn off IL2CPP](https://youtu.be/E71ta7EwD8I) in the project settings befoire being able to build for Macs.

#### ©2023 Lemon Studios
