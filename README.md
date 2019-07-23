# Gotcha-v2.1
### Auto spammer / catcher for discord bot pokecord
### This will take over your keyboard. This is not meant to be used in a discord server with mutiple people, use at your own risk.

## Preview
![preview](https://imgur.com/GbgBXgJ.png)

## Discord
> [Join the Discord](https://discord.gg/6ByeEMy)

## Downloads
> [Discord Client](https://discordapp.com/)

> [Gotcha v2.1.0.1](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.1) - Latest Release

> [Gotcha v2.1.0.0](https://github.com/OniSensei/Gotcha-v2.1/releases/tag/2.1.0.0) - Original Commit - Stable


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
   
   ![Token Settings](https://imgur.com/uSlyF5P.png)
   
   - Replace 'general2' under 'Channel' with your discord channel name
   
   - These settings tell the bot who it is and where 
   ```
   [Basic]
   Channel = "general" 
   BotToken = "NTk3MjY3MjU5MjUzMTk0Nzkz.XTaFGw.NARvf5ktmSG93ujfUdwD-kRwoTY"
   ```
   
   - These settings control the auto spammer
   ```
   [Spam]
   SpamInterval = "1500"     ; In ms | 1000ms = 1 sec
   AutoSpam = "True"         ; True or False
   ```
   
   - These settings control the auto catcher
   ```
   [Catch]
   AutoBal = "True"          ; True or False | This sends p!pokedex claim all after a new pokemon is added to pokedex
   PokeWhiteList = "Bulbasaur"
   ```
     - The pokemon catcher only catches pokemon on the Whitelist, they must be correct spelling and capital first letter. The default settings have every pokemon.
      
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

