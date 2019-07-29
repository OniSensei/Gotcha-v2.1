# Gotcha-v2.1

## Support
> Discord: DefaulT#2648

### Auto spammer / catcher for discord bot pokecord
### This will take over your keyboard. This is not meant to be used in a discord server with mutiple people, use at your own risk.

## Preview
![preview](https://imgur.com/TwepYvy.png)

## Video guide
> [Youtube](https://www.youtube.com/watch?v=Fk16LdoEyRY)

## Downloads

> [Discord Client](https://discordapp.com/)

> [Gotcha v2.1.0.7](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.7) - Latest Release 

> [Gotcha v2.1.0.6](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.6) - Older

> [Gotcha v2.1.0.5](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.5) - Older - New auto update feature. This can be turned off in settings.ini

> [Gotcha v2.1.0.4](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.4) - Hotfix - Older - Stable

> [Gotcha v2.1.0.3](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.3) - Older - Stable

> [Gotcha v2.1.0.2](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.2) - Older - Stable

> [Gotcha v2.1.0.1](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.1) - Older - Stable

> [Gotcha v2.1.0.0](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.0) - Original Commit - Stable

## Discord Commands
```
Commands:
+g <- Prefix

Settings Commands: (you must include the "[]" brackets.)

+g[settings][channel][channelname] <- replace channelname with your channel name.
	- This command changes the channel name in the settings.ini file.
	
+g[settings][token][yourtoken] <- replace yourtoken with your token.
	- This command changes the token in the settings.ini file.
	
+g[settings][prefix][p!] <- replace p! with your pokecord prefix.
	- This command changes the token in the settings.ini file.

+g[settings][spamdelay][1500] <- replace 1500 with your delay in ms.
	- This command changes the spam delay in the settings.ini file. (1500ms the default, is the suggested ammount)

+g[settings][autoupdate][on/off] < - replace on/off with either on or off.
	- This command changes the auto updater to true or false in the settings.ini file.
	
+g[settings][autospam][on/off] < - replace on/off with either on or off.
	- This command changes the auto spammer to true or false in the settings.ini file.

+g[settings][autolevel][on/off] < - replace on/off with either on or off.
	- This command changes the auto leveler to true or false in the settings.ini file.
	
+g[settings][autobal][on/off] <- replace on/off with either on or off.
	- This command changes the auto ballance to true or false in the settings.ini file.
	
+g[settings][catchdelay][750] <- replace 750 with your delay in ms.
	- This command changes the catch delay in the settings.ini file (750ms the default, is the suggested ammount)

+g[settings][legend][on/off] <- replace on/off with either on or off.
	- This command changes the legendary notifications to true or false in the settings.ini file.
	
+g[settings][mythic][on/off] <- replace on/off with either on or off.
	- This command changes the mythical notifications to true or false in the settings.ini file.
	
+g[settings][ultrabeast][on/off] <- replace on/off with either on or off.
	- This command changes the Ultra Beast notifications to true or false in the settings.ini file.
	
+g[settings][event][on/off] <- replace on/off with either on or off.
	- This command changes the event pokemon notifications to true or false in the settings.ini file.
	
+g[settings][shiny][on/off] <- replace on/off with either on or off.
	- This command changes the shiny pokemon notifications to true or false in the settings.ini file.
		
+g[settings][custom][on/off] <- replace on/off with either on or off.
	- This command changes the custom pokemon notifications to true or false in the settings.ini file.
		
+g[settings][reload]
	- This command reloads the settings.ini file. This is required after any settings changes in order to take effect. Even after it is suggested to reboot the bot.
	
```

## Setup

- [Click Here](https://discordapp.com/developers/applications/) to create a bot and invite it to your server as follows
   - Click the 'New Application' button
         
   ![New Application](https://i.imgur.com/2OQwdyk.png)
         
   - Enter a name for this bot and click create
         
   ![Name Bot](https://imgur.com/wdj544W.png)
         
   - Click the 'Bot' tab under settings on the left toolbar
         
   ![Bot Tab](https://imgur.com/1UCYlma.png)
         
   - Click the 'Add Bot' button
         
   ![Add Bot](https://imgur.com/8AlIHjo.png)
         
   - Click 'Yes do it' in the pop-up
       
   ![Yes do it](https://imgur.com/HWg5AZ8.png)
     
   - Select 'OAuth2' tab under settings on the left toolbar
         
   ![OAuth2](https://imgur.com/z24sHdA.png)
        
   - Select 'Bot' checkbox from the scopes list and copy the link
         
   ![Bot OAuth2](https://imgur.com/yhEg5iw.png)
         
   - Paste the copied link into a new tab / new window
                                
   - Select the server you want to invite the bot to and click 'Authorize'
     
   ![Authorize Bot](https://imgur.com/rFa3MHP.png)
   
   - Go back to the developer portal at  and select the Bot tab again.
   
   ![Bot Tab](https://imgur.com/1UCYlma.png)
   
   - Click 'Copy' button located under the token
         
   ![Copy Token](https://imgur.com/ImHZxNG.png)
        
   - Make sure your discord desktop client is running *(this does not work with discord on webclients like chrome etc)*
   
   - Download the latest version of the bot
      - > https://github.com/OniSensei/Gotcha-v2.1/releases
    
    ![Downloading](https://imgur.com/KRCFL1n.png)
    
   - Extract the zip to the desktop or my documents, somewhere you can find it easily.
   
   ![Extracted](https://imgur.com/wARredw.png)
   
   - Open the folder Gotcha v2.1 that was extracted from the zip and start Gotcha v2.1.exe
     - If you do not want the auto updater to run you need to go to /config/settings.ini and change AutoUpdate to False
     - If you want to change any settings beforehand please check /config/settings.ini and change them
     - If you want to change any settings during the bot running, use the commands located in this readme
     - If you want to pause the bot press F12
   
   ![Application](https://imgur.com/xrF5K8H.png)
   
   - If there is an update the auto updated will automatically start. If not then the bot will ask you for your token.
     - This is the token we coppied in the step above, paste it using CTRL + V and press enter
     
     - The updater should now be asking you for the channel name
       - This is the name of the channel you will be spamming and catching pokemon in, on discord, do not include the #
     
     - Once complete the bot should start.
     
   - If there is no update the bot should start.
   
## /config/settings.ini explaned
```
[Basic]
// The channel name - this is used to find the discord window to spam messages and catch pokemon
Channel = general

// The bot token used to log into the bot we invite - used to read pokecord messages - dont share this token!
BotToken = 

// The pokecord prefix for your server 
Prefix = p!

// The current bot version you are using - used to update bot
Version = 2.1.0.6

// Auto updater toggle - if False then the bot will not auto update
AutoUpdate = True
```

```
[Spam]
// This is how offten the bot will try to send a spam message in ms [1000ms = 1sec]
SpamInterval = 1500

// This is the Auto Spammer toggle - if False then the bot will not spam
AutoSpam = True

// This is the Auto Level toggle - if False then the bot will not switch pokemon when they reach level 100
AutoLevel = True
```

```
[Catch]
// This is the Auto Ballance toggle - if False then the bot will not collect pokedex rewards automatically
AutoBal = True

// This is the catch delay - it is used so we dont catch the pokemon super quick and makes it look more life like
CatchDelay = 750

// These are the pokemon you want to catch - Spelling must be correct, and CaSeSeNsItIvE by default the list has 829 pokemon which includes all pokemon catchable at the moment im writing this.
PokeWhitelist = Detective Pikachu, Bulbasaur, Ivysaur, Venusaur
```

```
[Notifications]
// Notifications will pm the user if set to True when the user catches the corresponding pokemon.
Legendary = True
Mythical = True
UltraBeast = True
EventPkmn = True
Shiny = True

// These are pokemon not listed above that you still want notifications for.
CustomPkmn = False
CustomPoke = Dragonite, Tyranitar, Salamance, Metagross, Garchomp, Hydreigon, Goodra, Kommo-o
```

## Recent Changes
```
 -Added shiny catch count to stats
 -Added user count to backend
 -Added online count command
      +g[online]
 -Added custom pokemon notifications
 -Update spammer | conditional channel
 -Updated bot commands
      -Added +g[settings][prefix][p!]
      -Added +g[settings][autoupdate][on/off]
      -Added +g[settings][autolevel][on/off]
      -Added +g[settings][shiny][on/off]
      -Added +g[settings][custom][on/off]
```
