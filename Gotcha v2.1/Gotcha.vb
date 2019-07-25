Imports System.Net
Imports Discord
Imports Discord.WebSocket
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Nini.Config
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Module Gotcha
    ' Our lists, all pokemon, legendary, mythic, ultra beast, alolan forms, and event pokemon
    Dim pkmn() As String = {"Detective Pikachu", "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Alolan Rattata", "Raticate", "Alolan Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Alolan Raichu", "Sandshrew", "Alolan Sandshrew", "Sandslash", "Alolan Sandslash", "Nidoran", "Nidorina", "Nidoqueen", "Nidoran_m", "Nidorino", "Nidoking", "Clefairy", "Clefable", "Vulpix", "Alolan Vulpix", "Ninetales", "Alolan Ninetales", "Jigglypuff", "Wigglytuff", "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth", "Diglett", "Alolan Diglett", "Dugtrio", "Alolan Dugtrio", "Meowth", "Alolan Meowth", "Persian", "Alolan Persian", "Psyduck", "Golduck", "Mankey", "Primeape", "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Alolan Geodude", "Graveler", "Alolan Graveler", "Golem", "Alolan Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro", "Magnemite", "Magneton", "Farfetchd", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Alolan Grimer", "Muk", "Alolan Muk", "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno", "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Alolan Exeggutor", "Cubone", "Marowak", "Alolan Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu", "Starmie", "Mr. Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew", "Chikorita", "Bayleef", "Meganium", "Cyndaquil", "Quilava", "Typhlosion", "Totodile", "Croconaw", "Feraligatr", "Sentret", "Furret", "Hoothoot", "Noctowl", "Ledyba", "Ledian", "Spinarak", "Ariados", "Crobat", "Chinchou", "Lanturn", "Pichu", "Cleffa", "Igglybuff", "Togepi", "Togetic", "Natu", "Xatu", "Mareep", "Flaaffy", "Ampharos", "Bellossom", "Marill", "Azumarill", "Sudowoodo", "Politoed", "Hoppip", "Skiploom", "Jumpluff", "Aipom", "Sunkern", "Sunflora", "Yanma", "Wooper", "Quagsire", "Espeon", "Umbreon", "Murkrow", "Slowking", "Misdreavus", "Unown", "Wobbuffet", "Girafarig", "Pineco", "Forretress", "Dunsparce", "Gligar", "Steelix", "Snubbull", "Granbull", "Qwilfish", "Scizor", "Shuckle", "Heracross", "Sneasel", "Teddiursa", "Ursaring", "Slugma", "Magcargo", "Swinub", "Piloswine", "Corsola", "Remoraid", "Octillery", "Delibird", "Mantine", "Skarmory", "Houndour", "Houndoom", "Kingdra", "Phanpy", "Donphan", "Porygon2", "Stantler", "Smeargle", "Tyrogue", "Hitmontop", "Smoochum", "Elekid", "Magby", "Miltank", "Blissey", "Raikou", "Entei", "Suicune", "Larvitar", "Pupitar", "Tyranitar", "Lugia", "Ho-Oh", "Celebi", "Treecko", "Grovyle", "Sceptile", "Torchic", "Combusken", "Blaziken", "Mudkip", "Marshtomp", "Swampert", "Poochyena", "Mightyena", "Zigzagoon", "Linoone", "Wurmple", "Silcoon", "Beautifly", "Cascoon", "Dustox", "Lotad", "Lombre", "Ludicolo", "Seedot", "Nuzleaf", "Shiftry", "Taillow", "Swellow", "Wingull", "Pelipper", "Ralts", "Kirlia", "Gardevoir", "Surskit", "Masquerain", "Shroomish", "Breloom", "Slakoth", "Vigoroth", "Slaking", "Nincada", "Ninjask", "Shedinja", "Whismur", "Loudred", "Exploud", "Makuhita", "Hariyama", "Azurill", "Nosepass", "Skitty", "Delcatty", "Sableye", "Mawile", "Aron", "Lairon", "Aggron", "Meditite", "Medicham", "Electrike", "Manectric", "Plusle", "Minun", "Volbeat", "Illumise", "Roselia", "Gulpin", "Swalot", "Carvanha", "Sharpedo", "Wailmer", "Wailord", "Numel", "Camerupt", "Torkoal", "Spoink", "Grumpig", "Spinda", "Trapinch", "Vibrava", "Flygon", "Cacnea", "Cacturne", "Swablu", "Altaria", "Zangoose", "Seviper", "Lunatone", "Solrock", "Barboach", "Whiscash", "Corphish", "Crawdaunt", "Baltoy", "Claydol", "Lileep", "Cradily", "Anorith", "Armaldo", "Feebas", "Milotic", "Castform", "Kecleon", "Shuppet", "Banette", "Duskull", "Dusclops", "Tropius", "Chimecho", "Absol", "Wynaut", "Snorunt", "Glalie", "Spheal", "Sealeo", "Walrein", "Clamperl", "Huntail", "Gorebyss", "Relicanth", "Luvdisc", "Bagon", "Shelgon", "Salamence", "Beldum", "Metang", "Metagross", "Regirock", "Regice", "Registeel", "Latias", "Latios", "Kyogre", "Groudon", "Rayquaza", "Jirachi", "Deoxys", "Turtwig", "Grotle", "Torterra", "Chimchar", "Monferno", "Infernape", "Piplup", "Prinplup", "Empoleon", "Starly", "Staravia", "Staraptor", "Bidoof", "Bibarel", "Kricketot", "Kricketune", "Shinx", "Luxio", "Luxray", "Budew", "Roserade", "Cranidos", "Rampardos", "Shieldon", "Bastiodon", "Burmy", "Wormadam", "Mothim", "Combee", "Vespiquen", "Pachirisu", "Buizel", "Floatzel", "Cherubi", "Cherrim", "Shellos", "Gastrodon", "Ambipom", "Drifloon", "Drifblim", "Buneary", "Lopunny", "Mismagius", "Honchkrow", "Glameow", "Purugly", "Chingling", "Stunky", "Skuntank", "Bronzor", "Bronzong", "Bonsly", "Mime Jr.", "Happiny", "Chatot", "Spiritomb", "Gible", "Gabite", "Garchomp", "Munchlax", "Riolu", "Lucario", "Hippopotas", "Hippowdon", "Skorupi", "Drapion", "Croagunk", "Toxicroak", "Carnivine", "Finneon", "Lumineon", "Mantyke", "Snover", "Abomasnow", "Weavile", "Magnezone", "Lickilicky", "Rhyperior", "Tangrowth", "Electivire", "Magmortar", "Togekiss", "Yanmega", "Leafeon", "Glaceon", "Gliscor", "Mamoswine", "Porygon-Z", "Gallade", "Probopass", "Dusknoir", "Froslass", "Rotom", "Uxie", "Mesprit", "Azelf", "Dialga", "Palkia", "Heatran", "Regigigas", "Giratina", "Cresselia", "Phione", "Manaphy", "Darkrai", "Shaymin", "Arceus", "Victini", "Snivy", "Servine", "Serperior", "Tepig", "Pignite", "Emboar", "Oshawott", "Dewott", "Samurott", "Patrat", "Watchog", "Lillipup", "Herdier", "Stoutland", "Purrloin", "Liepard", "Pansage", "Simisage", "Pansear", "Simisear", "Panpour", "Simipour", "Munna", "Musharna", "Pidove", "Tranquill", "Unfezant", "Blitzle", "Zebstrika", "Roggenrola", "Boldore", "Gigalith", "Woobat", "Swoobat", "Drilbur", "Excadrill", "Audino", "Timburr", "Gurdurr", "Conkeldurr", "Tympole", "Palpitoad", "Seismitoad", "Throh", "Sawk", "Sewaddle", "Swadloon", "Leavanny", "Venipede", "Whirlipede", "Scolipede", "Cottonee", "Whimsicott", "Petilil", "Lilligant", "Basculin", "Sandile", "Krokorok", "Krookodile", "Darumaka", "Darmanitan", "Maractus", "Dwebble", "Crustle", "Scraggy", "Scrafty", "Sigilyph", "Yamask", "Cofagrigus", "Tirtouga", "Carracosta", "Archen", "Archeops", "Trubbish", "Garbodor", "Zorua", "Zoroark", "Minccino", "Cinccino", "Gothita", "Gothorita", "Gothitelle", "Solosis", "Duosion", "Reuniclus", "Ducklett", "Swanna", "Vanillite", "Vanillish", "Vanilluxe", "Deerling", "Sawsbuck", "Emolga", "Karrablast", "Escavalier", "Foongus", "Amoonguss", "Frillish", "Jellicent", "Alomomola", "Joltik", "Galvantula", "Ferroseed", "Ferrothorn", "Klink", "Klang", "Klinklang", "Tynamo", "Eelektrik", "Eelektross", "Elgyem", "Beheeyem", "Litwick", "Lampent", "Chandelure", "Axew", "Fraxure", "Haxorus", "Cubchoo", "Beartic", "Cryogonal", "Shelmet", "Accelgor", "Stunfisk", "Mienfoo", "Mienshao", "Druddigon", "Golett", "Golurk", "Pawniard", "Bisharp", "Bouffalant", "Rufflet", "Braviary", "Vullaby", "Mandibuzz", "Heatmor", "Durant", "Deino", "Zweilous", "Hydreigon", "Larvesta", "Volcarona", "Cobalion", "Terrakion", "Virizion", "Tornadus", "Thundurus", "Reshiram", "Zekrom", "Landorus", "Kyurem", "Keldeo", "Meloetta", "Genesect", "Chespin", "Quilladin", "Chesnaught", "Fennekin", "Braixen", "Delphox", "Froakie", "Frogadier", "Greninja", "Bunnelby", "Diggersby", "Fletchling", "Fletchinder", "Talonflame", "Scatterbug", "Spewpa", "Vivillon", "Litleo", "Pyroar", "Flabebe", "Floette", "Florges", "Skiddo", "Gogoat", "Pancham", "Pangoro", "Furfrou", "Espurr", "Meowstic", "Honedge", "Doublade", "Aegislash", "Spritzee", "Aromatisse", "Swirlix", "Slurpuff", "Inkay", "Malamar", "Binacle", "Barbaracle", "Skrelp", "Dragalge", "Clauncher", "Clawitzer", "Helioptile", "Heliolisk", "Tyrunt", "Tyrantrum", "Amaura", "Aurorus", "Sylveon", "Hawlucha", "Dedenne", "Carbink", "Goomy", "Sliggoo", "Goodra", "Klefki", "Phantump", "Trevenant", "Pumpkaboo", "Gourgeist", "Bergmite", "Avalugg", "Noibat", "Noivern", "Xerneas", "Yveltal", "Zygarde", "Diancie", "Hoopa", "Volcanion", "Rowlet", "Dartrix", "Decidueye", "Litten", "Torracat", "Incineroar", "Popplio", "Brionne", "Primarina", "Pikipek", "Trumbeak", "Toucannon", "Yungoos", "Gumshoos", "Grubbin", "Charjabug", "Vikavolt", "Crabrawler", "Crabominable", "Oricorio", "Cutiefly", "Ribombee", "Rockruff", "Lycanroc", "Wishiwashi", "Mareanie", "Toxapex", "Mudbray", "Mudsdale", "Dewpider", "Araquanid", "Fomantis", "Lurantis", "Morelull", "Shiinotic", "Salandit", "Salazzle", "Stufful", "Bewear", "Bounsweet", "Steenee", "Tsareena", "Comfey", "Oranguru", "Passimian", "Wimpod", "Golisopod", "Sandygast", "Palossand", "Pyukumuku", "Type: Null", "Silvally", "Minior", "Komala", "Turtonator", "Togedemaru", "Mimikyu", "Bruxish", "Drampa", "Dhelmise", "Jangmo-o", "Hakamo-o", "Kommo-o", "Tapu Koko", "Tapu Lele", "Tapu Bulu", "Tapu Fini", "Cosmog", "Cosmoem", "Solgaleo", "Lunala", "Nihilego", "Buzzwole", "Pheromosa", "Xurkitree", "Celesteela", "Kartana", "Guzzlord", "Necrozma", "Magearna", "Marshadow", "Poipole", "Naganadel", "Stakataka", "Blacephalon", "Zeraora", "Meltan", "Melmetal"}
    Dim mythics() As String = {"Arceus", "Darkrai", "Deoxys", "Celebi", "Shaymin", "Mew", "Jerachi", "Hoopa", "Victini", "Phione", "Magearna", "Volcanion", "Diancie", "Genesect", "Keldeo", "Meloetta", "Manaphy", "Magearna", "Marshadow", "Zeraora", "Meltan", "Melmetal"}
    Dim alolans() As String = {"Alolan Rattata", "Alolan Raticate", " Alolan Raichu", "Alolan Sandshrew", "Alolan Sandslash", "Alolan Vulpix", " Alolan Ninetales", "Alolan Diglett", "Alolan Dugtrio", "Alolan Meowth", "Alolan Persian", "Alolan Geodude", "Alolan Graveler", "Alolan Golem", "Alolan Grimer", "Alolan Muk", "Alolan Exeggutor", "Alolan Marowak"}
    Dim ultrabeasts() As String = {"Nihilego", "Buzzwole", "Pheromosa", "Xurkitree", "Celesteela", "Kartana", "Guzzlord", "Poipole", "Naganadel", "Stakataka", "Blacephalon"}
    Dim legends() As String = {"Articuno", "Zapdos", "Moltres", "Mewtwo", "Raikou", "Entei", "Suicune", "Ho-Oh", "Lugia", "Regirock", "Regice", "Registeel", "Regigigas", "Latios", "Latias", "Kyogre", "Groudon", "Rayquaza", "Dialga", "Palkia", "Heatran", "Giratina", "Cresselia", "Uxie", "Azelf", "Cobalion", "Terrakion", "Virizion", "Tornadus", "Thundrus", "Reshiram", "Zekrom", "Landorus", "Kyurem", "Xeneas", "Yveltal", "Zygarde", "Type: Null", "Silvally", "Cosmog", "Cosmoem", "Solgaleo", "Lunala", "Necrozma"}
    Dim pkmnEvents() As String = {"Detective Pikachu"}
    Dim recentCatches() As String = {""}
    Dim lstRecentCatches As List(Of String) = New List(Of String)(recentCatches)

    ' Bot variables
    Dim botRunning As Boolean = True
    Dim MainTimer As New Timers.Timer
    Dim keyTimer As New Timers.Timer
    Dim level As Integer = 0
    Dim evo As Integer = 0
    Dim catchCount As Integer = 0
    Dim seenCount As Integer = 0
    Dim lPKMN As Integer = 0
    Dim mPKMN As Integer = 0
    Dim ubPKMN As Integer = 0
    Dim ePKMN As Integer = 0
    Dim topcount As Integer = 0
    Dim rPokemon As String = ""
    Dim topPokemon As String = ""

    ' Load settings.ini
    Dim iniSettings As New IniConfigSource("settings.ini")
    Dim token As String = iniSettings.Configs("Basic").Get("BotToken")
    Dim channel As String = iniSettings.Configs("Basic").Get("Channel")
    Dim spamInterval As Integer = iniSettings.Configs("Spam").Get("SpamInterval")
    Dim autoSpam As Boolean = iniSettings.Configs("Spam").Get("AutoSpam")
    Dim autoBal As Boolean = iniSettings.Configs("Catch").Get("AutoBal")
    Dim catchDelay As Integer = iniSettings.Configs("Catch").Get("CatchDelay")
    Dim pokeWhite As String = iniSettings.Configs("Catch").Get("PokeWhitelist")
    Dim legendToggle As Boolean = iniSettings.Configs("Notifications").Get("Legendary")
    Dim mythicToggle As Boolean = iniSettings.Configs("Notifications").Get("Mythical")
    Dim ultraToggle As Boolean = iniSettings.Configs("Notifications").Get("UltraBeast")
    Dim eventToggle As Boolean = iniSettings.Configs("Notifications").Get("EventPkmn")
    Dim whitelist As String() = pokeWhite.Split(New Char() {","c})
    Dim whitecount As Integer = whitelist.Count

    ' Set logfile
    Dim logFile As String = Application.StartupPath & "/logs/" & DateTime.Now.ToString("ddMMyyHHmmss") & "_log.txt"

    ' Main sub
    Sub Main(args As String())
        ' Start main as an async sub
        MainAsync.GetAwaiter.GetResult()
    End Sub

    ' Set discord client variable
    Dim _client As DiscordSocketClient = New DiscordSocketClient

    ' New sub
    Sub New()
        ' Set console encoding for names with symbols like nidoran♂️ and nidoran♀️
        Console.OutputEncoding = System.Text.Encoding.UTF8
        ' Set our log, ready, timer, and message received functions
        AddHandler _client.Log, AddressOf LogAsync
        AddHandler _client.Ready, AddressOf ReadAsync
        AddHandler _client.MessageReceived, AddressOf MessageReceivedAsync
        AddHandler MainTimer.Elapsed, AddressOf tick
        AddHandler keyTimer.Elapsed, AddressOf tick2
    End Sub

    ' Async main function as referenced above
    ' Set the STA Thread
    <STAThread()>
    Public Async Function MainAsync() As Task
        ' Gotcha ASCII Art.... dont judge...
        Colorize(" ____ ____ ____ ____ ____ ____ _________ ____ ____ ____ ____") ' Colorize is a function below that is used to change the color of the font in the console
        Colorize("||G |||o |||t |||c |||h |||a |||       |||v |||2 |||. |||1 ||")
        Colorize("||__|||__|||__|||__|||__|||__|||_______|||__|||__|||__|||__||")
        Colorize("|/__\|/__\|/__\|/__\|/__\|/__\|/_______\|/__\|/__\|/__\|/__\|")
        Colorize("")
        Colorize("____________________________________________________________")
        Colorize("              [ Loading Gotcha v2.1.0.2 ]                   ")
        ' Set thread
        Threading.Thread.CurrentThread.SetApartmentState(Threading.ApartmentState.STA)
        ' Wait for login using our token
        Await _client.LoginAsync(TokenType.Bot, token)
        ' Wait for the client to start
        Await _client.StartAsync
        Await Task.Delay(-1)
    End Function

    ' Log discord.net messages
    Private Function LogAsync(ByVal log As LogMessage) As Task
        ' Once loginasync and startasync finish we get the log message of "Ready" once we get that, we load everything else
        If log.ToString.Contains("Ready") Then
            ' This is mostly just visual crap cause we loaded the settings up above
            Colorize("____________________________________________________________")
            Colorize("                    [ SETTINGS.INI ]                        ")
            Colorize("[LOAD]      Channel: " & channel)
            Colorize("[LOAD]      Token: " & token)
            If autoBal = True Then
                Colorize("[LOAD]      AutoBal:                             Enabled")
            Else
                Colorize("[LOAD]      AutoBal:                            Disabled")
            End If
            If autoSpam = True Then
                Colorize("[LOAD]      AutoSpam:                            Enabled")

                ' We do actually start the auto spammer tho, but thats becuase we had to wait for this
                MainTimer.Interval = spamInterval
                MainTimer.Start()
            Else
                Colorize("[LOAD]      AutoSpam:                           Disabled")
            End If
            Colorize("[LOAD]      Catch Delay: " & catchDelay)
            Colorize("[LOAD]      Spam Interval: " & spamInterval)
            Colorize("[LOAD]      " & whitecount & " Pokémon in Whitelist...")
            If legendToggle = True Then
                Colorize("[LOAD]      Legendary Notifications:             Enabled")
            Else
                Colorize("[LOAD]      Legendary Notifications:            Disabled")
            End If
            If mythicToggle = True Then
                Colorize("[LOAD]      Mythic Notifications:                Enabled")
            Else
                Colorize("[LOAD]      Mythic Notifications:               Disabled")
            End If
            If ultraToggle = True Then
                Colorize("[LOAD]      UltraBeast Notifications:            Enabled")
            Else
                Colorize("[LOAD]      UltraBeast Notifications:           Disabled")
            End If
            If eventToggle = True Then
                Colorize("[LOAD]      Event PKMN Notifications:            Enabled")
            Else
                Colorize("[LOAD]      Event PKMN Notifications:           Disabled")
            End If
            Colorize("____________________________________________________________")
            Colorize("                                                            ")
            Colorize("[LOAD]      Bot Started | Press F12 to pause...")

            ' This timer is to detect F12 for pausing and resuming
            keyTimer.Interval = "750"
            keyTimer.Start()
        ElseIf log.ToString.Contains("gateway") Or log.ToString.Contains("unhandled") Then
            ' dont log, people dont need to see it
        ElseIf log.Message IsNot Nothing Then
            ' Default output for log messages
            Colorize("[INFO]      " & log.Message)
        End If
        Return Task.CompletedTask
    End Function

    ' Async reader
    Private Function ReadAsync() As Task
        Return Task.CompletedTask
    End Function

    ' Async message revieved function
    Private Async Function MessageReceivedAsync(ByVal message As SocketMessage) As Task
        If message.Author.ToString.Contains("Pokécord") Then ' Only runs if the author of the message is pokecord
            If message.Content.Contains("You caught a") Then ' This string means we caught a pokemon
                If legendToggle = True Then ' if we want legendary notifications then continue
                    For Each value As String In legends ' Split the legendary list from above
                        If message.Content.Contains(value) Then ' if the pokemon is in the legendary list then continue
                            Await UserExtensions.SendMessageAsync(message.MentionedUsers.FirstOrDefault, message.Content.ToString) ' pm user its legendary
                            Colorize("[INFO]      Legendary notification sent...") ' update console
                        End If
                    Next
                End If

                ' Repeat above with mythics, ultrabeasts, and event pokemon
                If mythicToggle = True Then
                    For Each value As String In mythics
                        If message.Content.Contains(value) Then
                            Await UserExtensions.SendMessageAsync(message.MentionedUsers.FirstOrDefault, message.Content.ToString)
                            Colorize("[INFO]      Mythical notification sent...")
                        End If
                    Next
                End If

                If ultraToggle = True Then
                    For Each value As String In ultrabeasts
                        If message.Content.Contains(value) Then
                            Await UserExtensions.SendMessageAsync(message.MentionedUsers.FirstOrDefault, message.Content.ToString)
                            Colorize("[INFO]      Ultra Beast notification sent...")
                        End If
                    Next
                End If
                If eventToggle = True Then
                    For Each value As String In pkmnEvents
                        If message.Content.Contains(value) Then
                            Await UserExtensions.SendMessageAsync(message.MentionedUsers.FirstOrDefault, message.Content.ToString)
                            Colorize("[INFO]      Event Pokemon notification sent...")
                        End If
                    Next
                End If
                ' End notifications

                ' Pokemon caught, update console & the catch count & recent catches
                Colorize("[CATCH]     " & message.Content.ToString)

                catchCount += 1

                ' Add recent catch to list
                lstRecentCatches.Add(rPokemon)


                ' Count the most frequently caught pokemon
                Dim pkmncount As Integer = lstRecentCatches.Where(Function(value) value = rPokemon).Count

                If pkmncount >= topcount Then
                    topcount = pkmncount ' set new top count
                    topPokemon = rPokemon ' set new top pokemon

                    ' Math for catch percentage
                    Dim ratio As Double = Math.Round(catchCount / seenCount * 100)

                    ' Update console with stats
                    Colorize("[INFO]      Stats: Seen: " & seenCount & " | Caught: " & catchCount & " | Catch Rate: " & ratio & "% | Levels Gained: " & level & " | Evolutions Gained: " & evo)
                    Colorize("[INFO]      Legendary:   " & lPKMN & " | Mythic: " & mPKMN & " | Ultra Beast: " & ubPKMN)
                    Colorize("[INFO]      [ NEW ] Most caught pokemon: " & topcount & " - " & topPokemon & " [ NEW ]")
                Else
                    ' Math for catch percentage
                    Dim ratio As Double = Math.Round(catchCount / seenCount * 100)

                    ' Update console with stats
                    Colorize("[INFO]      Stats: Seen: " & seenCount & " | Caught: " & catchCount & " | Catch Rate: " & ratio & "% | Levels Gained: " & level & " | Evolutions Gained: " & evo)
                    Colorize("[INFO]      Legendary:   " & lPKMN & " | Mythic: " & mPKMN & " | Ultra Beast: " & ubPKMN)
                    Colorize("[INFO]      Most caught pokemon: " & topcount & " - " & topPokemon)
                End If

                ' Checks if the message also contains pokedex reward tags like added to pokedex, or 10th, or 100th pokemon caught
                ' Also only auto balance command if the toggle is on in settings
                If message.Content.Contains("Added to Pokédex") And autoBal = True Then
                    Threading.Thread.Sleep(catchDelay) ' otherwise it can tell us we are sending commands to fast
                    FindDiscordWindow(channel) ' Find discord window
                    SendKeys.SendWait("p!pokedex claim all") ' Send the command to collect balance
                    SendKeys.SendWait("{Enter}")

                    ' Update console
                    Colorize("[INFO]      New Pokédex reward available. Claiming the balance.")
                ElseIf message.Content.Contains("10th") And autoBal = True Then
                    Threading.Thread.Sleep(catchDelay) ' otherwise it can tell us we are sending commands to fast
                    FindDiscordWindow(channel) ' Find discord window
                    SendKeys.SendWait("p!pokedex claim all") ' Send the command to collect balance
                    SendKeys.SendWait("{Enter}")

                    ' Update console
                    Colorize("[INFO]      New Pokédex reward available. Claiming the balance.")
                ElseIf message.Content.Contains("100th") And autoBal = True Then
                    Threading.Thread.Sleep(catchDelay) ' otherwise it can tell us we are sending commands to fast
                    FindDiscordWindow(channel) ' Find discord window
                    SendKeys.SendWait("p!pokedex claim all") ' Send the command to collect balance
                    SendKeys.SendWait("{Enter}")

                    ' Update console
                    Colorize("[INFO]      New Pokédex reward available. Claiming the balance.")
                End If

                ' Continue to spam if autospammer is set to true
                If autoSpam = True Then
                    MainTimer.Start()
                End If

            End If

            ' Wrong pokemon
            If message.Content.Contains("wrong") Then
                ' Update console
                Colorize("[ERROR]     " & message.Content.ToString)
            End If

            ' Encounter
            If message.Embeds(0).Title.Contains("appeared!") Then
                ' Stop the timer
                MainTimer.Stop()

                ' Update console and seen count
                Colorize("[ENCOUNTER] A wild Pokémon has appeared!")
                seenCount += 1

                ' Download the image into memory for conversion to base64
                Dim url As String = message.Embeds(0).Image.ToString ' URL of image from pokemon spawn on discord
                Dim tClient As WebClient = New WebClient
                Dim timage As Bitmap = Bitmap.FromStream(New IO.MemoryStream(tClient.DownloadData(url)))

                Dim pokemon As String = ConvertImageToBase64(timage) ' Uses convertimagetobase64 function below with the image as reference

                ' Search for pokemons base64 string
                Try
                    For i = 0 To (pkmn.Count - 1) ' loop
                        Dim di As New DirectoryInfo(Application.StartupPath & "\poke\") ' set the directory of the pokemon base64 files
                        Dim pokemonName As String
                        For Each fi As FileInfo In di.GetFiles() ' get the file name of each file i n the directory
                            If File.ReadAllText(fi.FullName).Contains(pokemon) Then ' if the file contains the base64 string then
                                Try
                                    FindDiscordWindow(channel) ' find discord
                                    pokemonName = fi.Name
                                    pokemonName = pokemonName.Remove(pokemonName.Length - 4) ' clean up the ".txt" from end of file name
                                    If pokeWhite.Contains(pokemonName) Then ' if pokemon is on the whitelist
                                        If pokemonName = "Nidoran_m" Then pokemonName = "Nidoran" ' cleanup
                                        If pokemonName = "TypeNull" Then pokemonName = "Type: Null" ' cleanup
                                        ' If the pokemon matches the list then update the count
                                        If legends.Contains(pokemonName) Then lPKMN += 1
                                        If mythics.Contains(pokemonName) Then mPKMN += 1
                                        If ultrabeasts.Contains(pokemonName) Then ubPKMN += 1
                                        If pkmnEvents.Contains(pokemonName) Then ePKMN += 1
                                        ' set recent pokemon name
                                        rPokemon = pokemonName
                                        ' Catch delay
                                        Threading.Thread.Sleep(catchDelay)
                                        SendKeys.SendWait("p!catch " & pokemonName.ToLower) ' Actual catch
                                        SendKeys.SendWait("{Enter}")
                                    End If
                                    Exit For
                                Catch ex As Exception
                                    Console.WriteLine(ex.ToString) ' error
                                End Try
                            End If
                        Next
                        Exit For
                    Next
                Catch ex As Exception
                    Console.WriteLine(ex.ToString) 'error
                End Try
                ' Level up
            ElseIf message.Embeds(0).Description.Contains("is now level") Then
                ' Update console and level count
                Colorize("[LEVEL]     " & message.Embeds(0).Description)
                level += 1
            End If

            ' Evolution
            If message.Embeds(0).Fields.Count <> 0 Then
                ' Update console and evo count
                Colorize("[EVOLVE]    " & message.Embeds(0).Fields(0).Name.ToString)
                Colorize("[EVOLVE]    " & message.Embeds(0).Fields(0).Value.ToString)
                evo += 1
            End If

        Else
            ' Discord Commands
            If message.Content.Contains("+g") Then ' prefix
                Dim input As String = message.Content.ToString
                Dim regx As New Regex("\[(.*?)\]") ' we use [] for paramaters so we use regex to find the characters in the brackets
                Dim matches As MatchCollection = regx.Matches(input)
                Dim count As Integer = matches.Count
                ' paramaters of command
                Dim param1 As String = ""
                Dim param2 As String = ""
                Dim param3 As String = ""

                ' How many paramaters are we using
                If count = 1 Then
                    param1 = matches(0).Value
                ElseIf count = 2 Then
                    param1 = matches(0).Value
                    param2 = matches(1).Value
                ElseIf count = 3 Then
                    param1 = matches(0).Value
                    param2 = matches(1).Value
                    param3 = matches(2).Value
                End If

                ' Param check
                If param1 = "[settings]" Then ' editing settings so command looks like this so far +g[settings]
                    If param2 = "[channel]" Then ' editing channel so command looks like +g[settings][channel][######]
                        param3 = param3.Substring(1)
                        param3 = param3.Substring(0, param3.Length - 1)
                        iniSettings.Configs("Basic").Set("Channel", param3) ' Update the channel
                        Colorize("[INFO]      Settings updated | Channel = " & param3) ' Update console
                    ElseIf param2 = "[token]" Then ' Token settings
                        param3 = param3.Substring(1)
                        param3 = param3.Substring(0, param3.Length - 1)
                        iniSettings.Configs("Basic").Set("BotToken", param3)
                        Colorize("[INFO]      Settings updated | BotToken = " & param3)
                    ElseIf param2 = "[spamdelay]" Then ' Spam delay settings
                        param3 = param3.Substring(1)
                        param3 = param3.Substring(0, param3.Length - 1)
                        MainTimer.Interval = param3
                        spamInterval = param3
                        iniSettings.Configs("Spam").Set("SpamInterval", param3)
                        Colorize("[INFO]      Settings updated | SpamInterval = " & param3)
                    ElseIf param2 = "[autospam]" Then ' Auto spam settings
                        If param3 = "[on]" Then
                            MainTimer.Interval = spamInterval
                            iniSettings.Configs("Spam").Set("AutoSpam", "True")
                            Colorize("[INFO]      Settings updated | AutoSpam = True")
                        ElseIf param3 = "[off]" Then
                            iniSettings.Configs("Spam").Set("AutoSpam", "False")
                            Colorize("[INFO]      Settings updated | AutoSpam = Flase")
                        End If
                    ElseIf param2 = "[autobal]" Then ' Auto ballance settings
                        If param3 = "[on]" Then
                            iniSettings.Configs("Catch").Set("AutoBal", "True")
                            Colorize("[INFO]      Settings updated | AutoBal = True")
                        ElseIf param3 = "[off]" Then
                            iniSettings.Configs("Catch").Set("AutoBal", "False")
                            Colorize("[INFO]      Settings updated | AutoBal = Flase")
                        End If
                    ElseIf param2 = "[catchdelay]" Then ' Catch delay settings
                        param3 = param3.Substring(1)
                        param3 = param3.Substring(0, param3.Length - 1)
                        catchDelay = param3
                        iniSettings.Configs("Chat").Set("CatchDelay", param3)
                        Colorize("[INFO]      Settings updated | CatchDelay = " & param3)
                    ElseIf param2 = "[legend]" Then ' Legendary notifications
                        If param3 = "[on]" Then
                            iniSettings.Configs("Notifications").Set("Legendary", "True")
                            Colorize("[INFO]      Settings updated | Legendary = True")
                        ElseIf param3 = "[off]" Then
                            iniSettings.Configs("Notifications").Set("Legendary", "False")
                            Colorize("[INFO]      Settings updated | Legendary = Flase")
                        End If
                    ElseIf param2 = "[mythic]" Then ' Mythic notifications
                        If param3 = "[on]" Then
                            iniSettings.Configs("Notifications").Set("Mythical", "True")
                            Colorize("[INFO]      Settings updated | Mythical = True")
                        ElseIf param3 = "[off]" Then
                            iniSettings.Configs("Notifications").Set("Mythical", "False")
                            Colorize("[INFO]      Settings updated | Mythical = Flase")
                        End If
                    ElseIf param2 = "[ultrabeast]" Then ' Ultra Beast notifications
                        If param3 = "[on]" Then
                            iniSettings.Configs("Notifications").Set("UltraBeast", "True")
                            Colorize("[INFO]      Settings updated | UltraBeast = True")
                        ElseIf param3 = "[off]" Then
                            iniSettings.Configs("Notifications").Set("UltraBeast", "False")
                            Colorize("[INFO]      Settings updated | UltraBeast = Flase")
                        End If
                    ElseIf param2 = "[event]" Then ' Event notifications
                        If param3 = "[on]" Then
                            iniSettings.Configs("Notifications").Set("EeventPokemon", "True")
                            Colorize("[INFO]      Settings updated | EventPokemon = True")
                        ElseIf param3 = "[off]" Then
                            iniSettings.Configs("Notifications").Set("EventPokemon", "False")
                            Colorize("[INFO]      Settings updated | EventPokemon = Flase")
                        End If
                    ElseIf param2 = "[reload]" Then ' Reload settings
                        token = iniSettings.Configs("Basic").Get("BotToken")
                        channel = iniSettings.Configs("Basic").Get("Channel")
                        spamInterval = iniSettings.Configs("Spam").Get("SpamInterval")
                        autoSpam = iniSettings.Configs("Spam").Get("AutoSpam")
                        autoBal = iniSettings.Configs("Catch").Get("AutoBal")
                        catchDelay = iniSettings.Configs("Catch").Get("CatchDelay")
                        pokeWhite = iniSettings.Configs("Catch").Get("PokeWhitelist")
                        legendToggle = iniSettings.Configs("Notifications").Get("Legendary")
                        mythicToggle = iniSettings.Configs("Notifications").Get("Mythical")
                        ultraToggle = iniSettings.Configs("Notifications").Get("UltraBeast")
                        eventToggle = iniSettings.Configs("Notifications").Get("EventPkmn")
                        Colorize("[INFO]      Settings Reloaded...")
                    End If
                    iniSettings.Save() ' Save settings.ini
                End If
            End If
        End If
    End Function

    ' Convert image to base64
    Public Function ConvertImageToBase64(ImageInput As Drawing.Image) As String
        Using ms As New MemoryStream()
            ImageInput.Save(ms, ImageInput.RawFormat)
            Dim imageBytes As Byte() = ms.ToArray
            Dim base64String As String = Convert.ToBase64String(imageBytes)

            Return base64String
        End Using
    End Function

    ' Find discord functions
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (
    ByVal lpClassName As String,
    ByVal lpWindowName As String) As IntPtr

    Private Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As IntPtr) As Long

    Public Sub FindDiscordWindow(ByVal channel As String)
        Dim nWnd As IntPtr
        Dim ceroIntPtr As New IntPtr(0)
        Dim Wnd_name As String

        Wnd_name = "#" & channel & " - Discord"
        nWnd = FindWindow(Nothing, Wnd_name)

        SetForegroundWindow(nWnd)
    End Sub

    ' Spam chat
    Public Sub SpamChats()
        ' Find discord
        FindDiscordWindow(channel)

        ' Check for spamchat file
        If File.Exists("spamchat.txt") Then
            Dim ioFile As New StreamReader("spamchat.txt")
            Dim lines As New List(Of String)
            Dim rnd As New Random()
            Dim line As Integer

            While ioFile.Peek <> -1
                lines.Add(ioFile.ReadLine())
            End While

            ' Get random line and spam
            line = GetRandom(0, lines.Count - 1)

            ' Spam
            SendKeys.SendWait(lines(line).Trim())
            SendKeys.SendWait("{Enter}")
        Else
            Colorize("[ERROR]     Cannot locate spamchat.txt...") ' error
        End If
    End Sub

    ' Spam chat timer
    Private Sub tick(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)
        ' Spam chat function above
        SpamChats()
    End Sub

    ' F12 Pause timer
    Private Sub tick2(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)
        ' Checks keystate and acts
        If GetAsyncKeyState(VK_F12) Then
            If botRunning = True Then
                MainTimer.Stop() ' pause
                botRunning = False ' update toggle
                Colorize("[INFO]      Bot Paused  | Press F12 to resume...") ' update console
            Else
                MainTimer.Start() ' resume
                botRunning = True ' update toggle
                Colorize("[INFO]      Bot Resumed | Press F12 to pause...") ' update console
            End If
        End If
    End Sub

    ' Colorize function for console font color
    Public Sub Colorize(ByVal msg As String)
        ' Checks the message for particular string and changes the color, then updates the log
        Select Case True
            Case msg.Contains("ERROR") ' error message
                Console.ForegroundColor = ConsoleColor.DarkRed ' errors are red
                Console.WriteLine(msg) ' update console
                Console.ResetColor() ' reset the color
                Using sw As StreamWriter = File.AppendText(logFile) ' write to log
                    sw.WriteLine(DateTime.Now & "  |  " & msg)
                End Using
            Case msg.Contains("INFO") ' repeat
                Console.ForegroundColor = ConsoleColor.White
                Console.WriteLine(msg)
                Using sw As StreamWriter = File.AppendText(logFile)
                    sw.WriteLine(DateTime.Now & "  |  " & msg)
                End Using
                Console.ResetColor()
            Case msg.Contains("ENCOUNTER")
                Console.ForegroundColor = ConsoleColor.DarkYellow
                Console.WriteLine(msg)
                Console.ResetColor()
                Using sw As StreamWriter = File.AppendText(logFile)
                    sw.WriteLine(DateTime.Now & "  |  " & msg)
                End Using
            Case msg.Contains("LEVEL")
                Console.ForegroundColor = ConsoleColor.Blue
                Console.WriteLine(msg)
                Console.ResetColor()
                Using sw As StreamWriter = File.AppendText(logFile)
                    sw.WriteLine(DateTime.Now & "  |  " & msg)
                End Using
            Case msg.Contains("EVOLVE")
                Console.ForegroundColor = ConsoleColor.DarkCyan
                Console.WriteLine(msg)
                Console.ResetColor()
                Using sw As StreamWriter = File.AppendText(logFile)
                    sw.WriteLine(DateTime.Now & "  |  " & msg)
                End Using
            Case msg.Contains("CATCH")
                Console.ForegroundColor = ConsoleColor.DarkGreen
                Console.WriteLine(msg)
                Console.ResetColor()
                Using sw As StreamWriter = File.AppendText(logFile)
                    sw.WriteLine(DateTime.Now & "  |  " & msg)
                End Using
            Case msg.Contains("LOAD")
                Console.ForegroundColor = ConsoleColor.White
                Console.WriteLine(msg)
                Console.ResetColor()
                Using sw As StreamWriter = File.AppendText(logFile)
                    sw.WriteLine(DateTime.Now & "  |  " & msg)
                End Using
            Case Else
                Console.ForegroundColor = ConsoleColor.DarkYellow
                Console.WriteLine(msg)
                Console.ResetColor()
        End Select
    End Sub

    ' Get a random number since the built in rand function is trash and moves linear
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    ' Get key state for F12 - includes all keys for future hotkey support
    <DllImport("user32.dll")>
    Public Function GetAsyncKeyState(ByVal vKey As Keys) As Short
    End Function
    Private Const VK_0 = &H30
    Private Const VK_1 = &H31
    Private Const VK_2 = &H32
    Private Const VK_3 = &H33
    Private Const VK_4 = &H34
    Private Const VK_5 = &H35
    Private Const VK_6 = &H36
    Private Const VK_7 = &H37
    Private Const VK_8 = &H38
    Private Const VK_9 = &H39
    Private Const VK_A = &H41
    Private Const VK_B = &H42
    Private Const VK_C = &H43
    Private Const VK_D = &H44
    Private Const VK_E = &H45
    Private Const VK_F = &H46
    Private Const VK_G = &H47
    Private Const VK_H = &H48
    Private Const VK_I = &H49
    Private Const VK_J = &H4A
    Private Const VK_K = &H4B
    Private Const VK_L = &H4C
    Private Const VK_M = &H4D
    Private Const VK_N = &H4E
    Private Const VK_O = &H4F
    Private Const VK_P = &H50
    Private Const VK_Q = &H51
    Private Const VK_R = &H52
    Private Const VK_S = &H53
    Private Const VK_T = &H54
    Private Const VK_U = &H55
    Private Const VK_V = &H56
    Private Const VK_W = &H57
    Private Const VK_X = &H58
    Private Const VK_Y = &H59
    Private Const VK_Z = &H5A
    Private Const VK_ADD = &H6B
    Private Const VK_ATTN = &HF6
    Private Const VK_BACK = &H8
    Private Const VK_CANCEL = &H3
    Private Const VK_CAPITAL = &H14
    Private Const VK_CLEAR = &HC
    Private Const VK_CONTROL = &H11
    Private Const VK_CRSEL = &HF7
    Private Const VK_DECIMAL = &H6E
    Private Const VK_DELETE = &H2E
    Private Const VK_DIVIDE = &H6F
    Private Const VK_DOWN = &H28
    Private Const VK_END = &H23
    Private Const VK_EREOF = &HF9
    Private Const VK_ESCAPE = &H1B
    Private Const VK_EXECUTE = &H2B
    Private Const VK_EXSEL = &HF8
    Private Const VK_F1 = &H70
    Private Const VK_F10 = &H79
    Private Const VK_F11 = &H7A
    Private Const VK_F12 = &H7B
    Private Const VK_F13 = &H7C
    Private Const VK_F14 = &H7D
    Private Const VK_F15 = &H7E
    Private Const VK_F16 = &H7F
    Private Const VK_F17 = &H80
    Private Const VK_F18 = &H81
    Private Const VK_F19 = &H82
    Private Const VK_F2 = &H71
    Private Const VK_F20 = &H83
    Private Const VK_F21 = &H84
    Private Const VK_F22 = &H85
    Private Const VK_F23 = &H86
    Private Const VK_F24 = &H87
    Private Const VK_F3 = &H72
    Private Const VK_F4 = &H73
    Private Const VK_F5 = &H74
    Private Const VK_F6 = &H75
    Private Const VK_F7 = &H76
    Private Const VK_F8 = &H77
    Private Const VK_F9 = &H78
    Private Const VK_HELP = &H2F
    Private Const VK_HOME = &H24
    Private Const VK_INSERT = &H2D
    Private Const VK_LBUTTON = &H1
    Private Const VK_LCONTROL = &HA2
    Private Const VK_LEFT = &H25
    Private Const VK_LMENU = &HA4
    Private Const VK_LSHIFT = &HA0
    Private Const VK_MBUTTON = &H4
    Private Const VK_MENU = &H12
    Private Const VK_MULTIPLY = &H6A
    Private Const VK_NEXT = &H22
    Private Const VK_NONAME = &HFC
    Private Const VK_NUMLOCK = &H90
    Private Const VK_NUMPAD0 = &H60
    Private Const VK_NUMPAD1 = &H61
    Private Const VK_NUMPAD2 = &H62
    Private Const VK_NUMPAD3 = &H63
    Private Const VK_NUMPAD4 = &H64
    Private Const VK_NUMPAD5 = &H65
    Private Const VK_NUMPAD6 = &H66
    Private Const VK_NUMPAD7 = &H67
    Private Const VK_NUMPAD8 = &H68
    Private Const VK_NUMPAD9 = &H69
    Private Const VK_OEM_CLEAR = &HFE
    Private Const VK_PA1 = &HFD
    Private Const VK_PAUSE = &H13
    Private Const VK_PLAY = &HFA
    Private Const VK_PRINT = &H2A
    Private Const VK_PRIOR = &H21
    Private Const VK_PROCESSKEY = &HE5
    Private Const VK_RBUTTON = &H2
    Private Const VK_RCONTROL = &HA3
    Private Const VK_RETURN = &HD
    Private Const VK_RIGHT = &H27
    Private Const VK_RMENU = &HA5
    Private Const VK_RSHIFT = &HA1
    Private Const VK_SCROLL = &H91
    Private Const VK_SELECT = &H29
    Private Const VK_SEPARATOR = &H6C
    Private Const VK_SHIFT = &H10
    Private Const VK_SNAPSHOT = &H2C
    Private Const VK_SPACE = &H20
    Private Const VK_SUBTRACT = &H6D
    Private Const VK_TAB = &H9
    Private Const VK_UP = &H26
    Private Const VK_ZOOM = &HFB
End Module
