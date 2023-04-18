# 🍷 Mission: Monkey Install Tutorial for Linux
If you are reading this, then you want to go install this stupid game on your Linux device. Let's get going with that!

## 📕 Chapters:
- [Base Requirements](https://github.com/funny-unity-game/Mission-Monkey/blob/main/WINE.md#-base-requirements)

- [Installing Packages](https://github.com/funny-unity-game/Mission-Monkey/blob/main/WINE.md#-base-requirements)
  - [Ubuntu-Based](https://github.com/funny-unity-game/Mission-Monkey/blob/main/WINE.md#-installing-packages)
  - [Fedora-Based](https://github.com/funny-unity-game/Mission-Monkey/blob/main/WINE.md#ubuntu-based-distros)
  - [Arch-Based](https://github.com/funny-unity-game/Mission-Monkey/blob/main/WINE.md#fedora-based-distros)
  - [OpenSuse-Based](https://github.com/funny-unity-game/Mission-Monkey/blob/main/WINE.md#fedora-based-distros)
  - [Gentoo](https://github.com/funny-unity-game/Mission-Monkey/blob/main/WINE.md#gentoo)
 
## 🧱 Base requirements
To even run this game, you will need only three things, which are:
- An X86_64/amd64 CPU (Unless your computer is from 2003, it has this)
- A graphics card that supports both DX11 and Vulkan if the computer was on Windows
- An internet connection

## 📦 Installing Packages:

There are many Linux-Based Distros on the planet, but I will only list a few. If your distro is not listed here, open an issue and I (Shob3r) Will add it here when I get around to it

If you dont know what distro your distro is based off of, just Google:"What distro is (distro) based off of?"

> **Note**
> 
> The following instructions require the use of the Linux terminal and you will need to know the superuser password

### Ubuntu-Based Distros:
> **Note**
> 
> These Instructions assume you are using the **LATEST** version of Ubuntu (22.10 as of writing)
 
1. Enable the 32 Bit architecture (Wine needs it to install itself): ```sudo dpkg --add-architecture i386```
2. Install Wine: ```sudo apt-get install --install-recommends winehq-development```
3. Install DXVK ```sudo add-apt-repository ppa:kisak/kisak-mesa && sudo apt-get update && sudo apt-get install dxvk```
4. Download and unzip the game. You should already know this if you are on Linux, but if you are 100% new, just search around
5. Create a new .bash file in the game files. You can name it whatever you want
6. Open the file in a text editor of your choice, and paste in the following line of code: ```WINEARCH=win64 WINEPREFIX=~/.wine64 DXVK_HUD=1 wine "./Mission Monkey.exe"```
7. Save the file, make the file executable by right clicking on it, clicking on properties, and setting it as an executable file
8. Run the script, and you are off!


### Fedora-Based Distros:

### Arch-Based Distros

### OpenSuse-Based Distros

### Gentoo
