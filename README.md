# Gotcha-v2.1
### Auto spammer / catcher for discord bot pokecord
### This will take over your keyboard. This is not meant to be used in a discord server with mutiple people, use at your own risk.

## Preview
![preview](https://imgur.com/nogZlZY.png)

## Discord
> [Join the Discord](https://discord.gg/6ByeEMy)

## Video guide
> [Youtube](https://www.youtube.com/watch?v=Hc1msF5jaEY)

## Downloads
> [Discord Client](https://discordapp.com/)

> [Gotcha v2.1.0.4](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.3) - Hotfix - Latest Release

> [Gotcha v2.1.0.3](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.3) - Older - Stable

> [Gotcha v2.1.0.2](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.2) - Older - Stable

> [Gotcha v2.1.0.1](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.1) - Older - Stable

> [Gotcha v2.1.0.0](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.0) - Original Commit - Stable

## Discord Commands
```
+g <- Prefix

Settings Commands: (you must include the "[]" brackets.)

+g[settings][channel][channelname] <- replace channelname with your channel name.
	- This command changes the channel name in the settings.ini file.
	
+g[settings][token][yourtoken] <- replace yourtoken with your token.
	- This command changes the token in the settings.ini file.

+g[settings][spamdelay][1500] <- replace 1500 with your delay in ms.
	- This command changes the spam delay in the settings.ini file. (1500ms the default, is the suggested ammount)

+g[settings][autospam][on/off] < - replace on/off with either on or off.
	- This command changes the auto spammer to true or false in the settings.ini file.

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
	
+g[settings][reload]
	- This command reloads the settings.ini file. This is required after any settings changes in order to take effect. Even after it is suggested to reboot the bot.
	
```

## Setup

- [Click Here](https://discordapp.com/developers/applications/) to create a bot and invite it to your server as follows
   - Click the 'New Application' button
         
   ![New Application](https://i.imgur.com/2OQwdyk.png)
         
   - Enter a name for this bot and click create
         
   ![Name Bot](https://imgur.com/wdj544W.png)
         
   - Click the 'Bot' tab under settings on the right toolbar
         
   ![Bot Tab](https://imgur.com/1UCYlma.png)
         
   - Click the 'Add Bot' button
         
   ![Add Bot](https://imgur.com/8AlIHjo.png)
         
   - Click 'Yes do it' in the pop-up
       
   ![Yes do it](https://imgur.com/HWg5AZ8.png)
        
   - Click 'Copy' button located under the token
         
   ![Copy Token](https://imgur.com/ImHZxNG.png)
         
   - Paste the token into settings.ini | It should look something like this:
   
   ![Token Settings](https://imgur.com/KOP60Zg.png)
   
   - Replace 'general2' under 'Channel' with your discord channel name
   
   - These settings tell the bot who it is and where 
   ```
   [Basic]
   Channel = "general" 
   BotToken = "NTk3MjY3MjU5MjUzMTk0Nzkz.XTaFGw.NARvf5ktmSG93ujfdsfUdwD-kRwoTY"
   ```
   
   - These settings control the auto spammer
   ```
   [Spam]
   SpamInterval = "1500"     ; In ms | 1000ms = 1 sec | Default is 1500
   AutoSpam = "True"         ; True or False
   ```
   
   - These settings control the auto catcher
   ```
   [Catch]
   AutoBal = "True"          ; True or False | This sends p!pokedex claim all after a new pokemon is added to pokedex
   CatchDelay = "750"        ; In ms | 1000ms = 1 sec | Default is 750
   PokeWhiteList = "Bulbasaur"
   ```      
     - The pokemon catcher only catches pokemon on the Whitelist, they must be correct spelling and capital first letter. The default settings have every pokemon.
      
   - These settings control the notifications
   ```
   [Notifications]
   Legendary = True         ; True or False
   Mythical = True          ; True or False
   UltraBeast = True        ; True or False
   EventPkmn = True         ; True or False
   ```
      
   - Save settings.ini
   
   - Go back to the Discord Developer Portal and select 'OAuth2' tab under settings on the right toolbar
         
   ![OAuth2](https://imgur.com/z24sHdA.png)
        
   - Select 'Bot' checkbox from the scopes list and copy the link
         
   ![Bot OAuth2](https://imgur.com/yhEg5iw.png)
         
   - Paste the copied link into a new tab / new window
                                
   - Select the server you want to invite the bot to and click 'Authorize'
     
   ![Authorize Bot](https://imgur.com/rFa3MHP.png)
   
- Add / Remove / Edit any spam chats
  - This bot spams the chat automatically to incourage spawns
    - Located in the Gotcha v2.1 root folder there is spamchat.txt
      - Add a line to add a spam chat.
      - Modify a line to change a spam chat.
      - Remove a line to remove a spam chat

- Extract the Gotcha v2.1 Folder from the Gotcha v2.1.zip file

- Before starting the bot please ensure the following:
   - Discord client is running
   - Your discord client is in your server with the bot added
   - You are chatting in the channel you set in channel.txt

- Start the bot by double clicking Gotcha v2.1.exe

- Stop the bot by closing gotcha.exe

## Recent Changes
```
- Added pokecord prefix settings to settings.ini
- Added version to settings.ini for auto updates in the future
```
