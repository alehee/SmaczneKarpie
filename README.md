# Smaczne Karpie
![It's a front pic!](https://github.com/alehee/SmaczneKarpie/blob/master/github_resources/github_front.png?raw=true)

## Description
Smaczne Karpie is a small fishing + rune making bot for Tibia. Based on Tibia hotkeys and emulating mouse moves. Easily run bot while taking a nap and receive some runes and fishing level of course!

The most important - **don't use this on official servers and main characters**, I created this as a 'fun to make' project and some sort of challenge to myself

## Used technology
Technology I used for this project:
* C#
* C# WPF

And some NuGets (big shout-out to creators!)
* Arphox.MouseManipulator
* Codeer.Friendly.Windows.Grasp
* SharpDX
* InputHelper

## Installation
There's two ways: you can download the master branch with code, check how it's working and compile whole application in *Visual Studio 2019*, or simply download it from link below and run it from *smaczneKarpie.exe*

  ### Requirements
  * Windows 7 or higher
  * Tibia 12 client
  
  ### Download
  Download [here](https://drive.google.com/file/d/1n9e2EJZbb8pOiHzRJZZvbsOgL2oPjpkU/view?usp=sharing) latest version, uzip and **run** the **smaczneKarpie.exe** file.
  
## How to use
It requires a few preparation steps

First of all, let me present you program front panel
<p align="center">
  <img src="https://github.com/alehee/SmaczneKarpie/blob/master/github_resources/github_panel.png">
</p>

* ![Simple color](https://dummyimage.com/10x10/d3a9de/d3a9de) application coords information, useful function for next step
* ![Simple color](https://dummyimage.com/10x10/ff0000/ff0000) hotkeys row, select your hotkey for every of this actions
* ![Simple color](https://dummyimage.com/10x10/00ff00/00ff00) fishing area position
* ![Simple color](https://dummyimage.com/10x10/1c7eff/1c7eff) eating and rune making timer, delays each of this actions
* ![Simple color](https://dummyimage.com/10x10/5f1d9c/5f1d9c) start/stop button (if the bot is running **holding ALT** also works to turn it off!)
* ![Simple color](https://dummyimage.com/10x10/fff700/fff700) program log area, useful things will be written there!

### First use
First of all you need to **prepare your client to the program**.
* Run Tibia 12 and set hotkeys to **fishing rod**, **fishes** in your eq (or any other food you want to eat) and **rune making spell** you want to do
* Go to some desolate place next to the water so you will be able to use fishing rod
* Run *smaczneKarpie.exe* from unziped or compiled folder and make sure the Tibia client is on screen behind so you can drag Smaczne Karpie window on opened Tibia client

Now we will setup bot's options. The options will be saved always after **clicking the *Start fishing* button!**
1. ![Simple color](https://dummyimage.com/10x10/ff0000/ff0000) Enter the hotkeys for **Fishing**, **Eating** and **Rune making**
2. ![Simple color](https://dummyimage.com/10x10/1c7eff/1c7eff) Enter how many seconds you want to delay each action
3. ![Simple color](https://dummyimage.com/10x10/00ff00/00ff00) Now we will be setting up the fishing coords
     - Drag left upper corner of the *Smaczne Karpie* window to left upper corner of your fishing pond in Tibia so the little fish icon on window bar will be on first water square from top-left Tibia window
     - Check the ![Simple color](https://dummyimage.com/10x10/d3a9de/d3a9de) **Screen coords** on bot's window, there's your first coords for client in order: **xPosition:yPosition**
     - Now you've got the pale red coords so enter it to the textboxes in ![Simple color](https://dummyimage.com/10x10/00ff00/00ff00) **Fishing screen area**
     - Do the same for right bottom corner of fishing pond - the left upper corner of the *Smaczne Karpie* window should be on the last water square (bottom-right Tibia window)
     - Enter the coords to pale green X and Y textboxes
4. **Caution!** Fishing loop is very short so the mouse will be moving constantly, **remember** to stop the bot with **holding ALT** for few seconds! It's easier to do so!

Well done! You can now start fishing and make some runes! Go to **Every use** section and catch some fishes!

### Every use
If you started the bot for even a one second the options should be saves from your latest run, but if you want to change fishing spot you need to do **step 3** from **First use** section!

But if you want to run it in the same place all you need to do is
* Run *smaczneKarpie.exe* from unziped or compiled folder
* Make sure you are logged in Tibia on character you want to use
* Make sure you have some *blank runes*, *fishing rod* and *few worms* and you are on the same spot
* Click the *Start fishing* button and focus on Tibia window so it will be the only opened window on your screen
* Grab some tea, good book and wait for brand new runes (and fishes)

**Remember that you can stop the bot always by holding ALT button!**
  
Send me some excess fishes!

## Thank you!
Thank you for peeking at my project!

If you're interested check out my other stuff [here](https://github.com/alehee)
