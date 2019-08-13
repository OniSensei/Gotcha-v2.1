Imports System.Net
Imports Discord
Imports Discord.WebSocket
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Nini.Config
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Text
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Firefox
Imports OpenQA.Selenium.Support.UI

Module Gotcha
    ' Our lists, all pokemon, legendary, mythic, ultra beast, alolan forms, and event pokemon
    Public pkmn() As String = {"Detective Pikachu", "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Alolan Rattata", "Raticate", "Alolan Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Alolan Raichu", "Sandshrew", "Alolan Sandshrew", "Sandslash", "Alolan Sandslash", "Nidoran", "Nidorina", "Nidoqueen", "Nidoran_m", "Nidorino", "Nidoking", "Clefairy", "Clefable", "Vulpix", "Alolan Vulpix", "Ninetales", "Alolan Ninetales", "Jigglypuff", "Wigglytuff", "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth", "Diglett", "Alolan Diglett", "Dugtrio", "Alolan Dugtrio", "Meowth", "Alolan Meowth", "Persian", "Alolan Persian", "Psyduck", "Golduck", "Mankey", "Primeape", "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Alolan Geodude", "Graveler", "Alolan Graveler", "Golem", "Alolan Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro", "Magnemite", "Magneton", "Farfetchd", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Alolan Grimer", "Muk", "Alolan Muk", "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno", "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Alolan Exeggutor", "Cubone", "Marowak", "Alolan Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu", "Starmie", "Mr. Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew", "Chikorita", "Bayleef", "Meganium", "Cyndaquil", "Quilava", "Typhlosion", "Totodile", "Croconaw", "Feraligatr", "Sentret", "Furret", "Hoothoot", "Noctowl", "Ledyba", "Ledian", "Spinarak", "Ariados", "Crobat", "Chinchou", "Lanturn", "Pichu", "Cleffa", "Igglybuff", "Togepi", "Togetic", "Natu", "Xatu", "Mareep", "Flaaffy", "Ampharos", "Bellossom", "Marill", "Azumarill", "Sudowoodo", "Politoed", "Hoppip", "Skiploom", "Jumpluff", "Aipom", "Sunkern", "Sunflora", "Yanma", "Wooper", "Quagsire", "Espeon", "Umbreon", "Murkrow", "Slowking", "Misdreavus", "Unown", "Wobbuffet", "Girafarig", "Pineco", "Forretress", "Dunsparce", "Gligar", "Steelix", "Snubbull", "Granbull", "Qwilfish", "Scizor", "Shuckle", "Heracross", "Sneasel", "Teddiursa", "Ursaring", "Slugma", "Magcargo", "Swinub", "Piloswine", "Corsola", "Remoraid", "Octillery", "Delibird", "Mantine", "Skarmory", "Houndour", "Houndoom", "Kingdra", "Phanpy", "Donphan", "Porygon2", "Stantler", "Smeargle", "Tyrogue", "Hitmontop", "Smoochum", "Elekid", "Magby", "Miltank", "Blissey", "Raikou", "Entei", "Suicune", "Larvitar", "Pupitar", "Tyranitar", "Lugia", "Ho-Oh", "Celebi", "Treecko", "Grovyle", "Sceptile", "Torchic", "Combusken", "Blaziken", "Mudkip", "Marshtomp", "Swampert", "Poochyena", "Mightyena", "Zigzagoon", "Linoone", "Wurmple", "Silcoon", "Beautifly", "Cascoon", "Dustox", "Lotad", "Lombre", "Ludicolo", "Seedot", "Nuzleaf", "Shiftry", "Taillow", "Swellow", "Wingull", "Pelipper", "Ralts", "Kirlia", "Gardevoir", "Surskit", "Masquerain", "Shroomish", "Breloom", "Slakoth", "Vigoroth", "Slaking", "Nincada", "Ninjask", "Shedinja", "Whismur", "Loudred", "Exploud", "Makuhita", "Hariyama", "Azurill", "Nosepass", "Skitty", "Delcatty", "Sableye", "Mawile", "Aron", "Lairon", "Aggron", "Meditite", "Medicham", "Electrike", "Manectric", "Plusle", "Minun", "Volbeat", "Illumise", "Roselia", "Gulpin", "Swalot", "Carvanha", "Sharpedo", "Wailmer", "Wailord", "Numel", "Camerupt", "Torkoal", "Spoink", "Grumpig", "Spinda", "Trapinch", "Vibrava", "Flygon", "Cacnea", "Cacturne", "Swablu", "Altaria", "Zangoose", "Seviper", "Lunatone", "Solrock", "Barboach", "Whiscash", "Corphish", "Crawdaunt", "Baltoy", "Claydol", "Lileep", "Cradily", "Anorith", "Armaldo", "Feebas", "Milotic", "Castform", "Kecleon", "Shuppet", "Banette", "Duskull", "Dusclops", "Tropius", "Chimecho", "Absol", "Wynaut", "Snorunt", "Glalie", "Spheal", "Sealeo", "Walrein", "Clamperl", "Huntail", "Gorebyss", "Relicanth", "Luvdisc", "Bagon", "Shelgon", "Salamence", "Beldum", "Metang", "Metagross", "Regirock", "Regice", "Registeel", "Latias", "Latios", "Kyogre", "Groudon", "Rayquaza", "Jirachi", "Deoxys", "Turtwig", "Grotle", "Torterra", "Chimchar", "Monferno", "Infernape", "Piplup", "Prinplup", "Empoleon", "Starly", "Staravia", "Staraptor", "Bidoof", "Bibarel", "Kricketot", "Kricketune", "Shinx", "Luxio", "Luxray", "Budew", "Roserade", "Cranidos", "Rampardos", "Shieldon", "Bastiodon", "Burmy", "Wormadam", "Mothim", "Combee", "Vespiquen", "Pachirisu", "Buizel", "Floatzel", "Cherubi", "Cherrim", "Shellos", "Gastrodon", "Ambipom", "Drifloon", "Drifblim", "Buneary", "Lopunny", "Mismagius", "Honchkrow", "Glameow", "Purugly", "Chingling", "Stunky", "Skuntank", "Bronzor", "Bronzong", "Bonsly", "Mime Jr.", "Happiny", "Chatot", "Spiritomb", "Gible", "Gabite", "Garchomp", "Munchlax", "Riolu", "Lucario", "Hippopotas", "Hippowdon", "Skorupi", "Drapion", "Croagunk", "Toxicroak", "Carnivine", "Finneon", "Lumineon", "Mantyke", "Snover", "Abomasnow", "Weavile", "Magnezone", "Lickilicky", "Rhyperior", "Tangrowth", "Electivire", "Magmortar", "Togekiss", "Yanmega", "Leafeon", "Glaceon", "Gliscor", "Mamoswine", "Porygon-Z", "Gallade", "Probopass", "Dusknoir", "Froslass", "Rotom", "Uxie", "Mesprit", "Azelf", "Dialga", "Palkia", "Heatran", "Regigigas", "Giratina", "Cresselia", "Phione", "Manaphy", "Darkrai", "Shaymin", "Arceus", "Victini", "Snivy", "Servine", "Serperior", "Tepig", "Pignite", "Emboar", "Oshawott", "Dewott", "Samurott", "Patrat", "Watchog", "Lillipup", "Herdier", "Stoutland", "Purrloin", "Liepard", "Pansage", "Simisage", "Pansear", "Simisear", "Panpour", "Simipour", "Munna", "Musharna", "Pidove", "Tranquill", "Unfezant", "Blitzle", "Zebstrika", "Roggenrola", "Boldore", "Gigalith", "Woobat", "Swoobat", "Drilbur", "Excadrill", "Audino", "Timburr", "Gurdurr", "Conkeldurr", "Tympole", "Palpitoad", "Seismitoad", "Throh", "Sawk", "Sewaddle", "Swadloon", "Leavanny", "Venipede", "Whirlipede", "Scolipede", "Cottonee", "Whimsicott", "Petilil", "Lilligant", "Basculin", "Sandile", "Krokorok", "Krookodile", "Darumaka", "Darmanitan", "Maractus", "Dwebble", "Crustle", "Scraggy", "Scrafty", "Sigilyph", "Yamask", "Cofagrigus", "Tirtouga", "Carracosta", "Archen", "Archeops", "Trubbish", "Garbodor", "Zorua", "Zoroark", "Minccino", "Cinccino", "Gothita", "Gothorita", "Gothitelle", "Solosis", "Duosion", "Reuniclus", "Ducklett", "Swanna", "Vanillite", "Vanillish", "Vanilluxe", "Deerling", "Sawsbuck", "Emolga", "Karrablast", "Escavalier", "Foongus", "Amoonguss", "Frillish", "Jellicent", "Alomomola", "Joltik", "Galvantula", "Ferroseed", "Ferrothorn", "Klink", "Klang", "Klinklang", "Tynamo", "Eelektrik", "Eelektross", "Elgyem", "Beheeyem", "Litwick", "Lampent", "Chandelure", "Axew", "Fraxure", "Haxorus", "Cubchoo", "Beartic", "Cryogonal", "Shelmet", "Accelgor", "Stunfisk", "Mienfoo", "Mienshao", "Druddigon", "Golett", "Golurk", "Pawniard", "Bisharp", "Bouffalant", "Rufflet", "Braviary", "Vullaby", "Mandibuzz", "Heatmor", "Durant", "Deino", "Zweilous", "Hydreigon", "Larvesta", "Volcarona", "Cobalion", "Terrakion", "Virizion", "Tornadus", "Thundurus", "Reshiram", "Zekrom", "Landorus", "Kyurem", "Keldeo", "Meloetta", "Genesect", "Chespin", "Quilladin", "Chesnaught", "Fennekin", "Braixen", "Delphox", "Froakie", "Frogadier", "Greninja", "Bunnelby", "Diggersby", "Fletchling", "Fletchinder", "Talonflame", "Scatterbug", "Spewpa", "Vivillon", "Litleo", "Pyroar", "Flabebe", "Floette", "Florges", "Skiddo", "Gogoat", "Pancham", "Pangoro", "Furfrou", "Espurr", "Meowstic", "Honedge", "Doublade", "Aegislash", "Spritzee", "Aromatisse", "Swirlix", "Slurpuff", "Inkay", "Malamar", "Binacle", "Barbaracle", "Skrelp", "Dragalge", "Clauncher", "Clawitzer", "Helioptile", "Heliolisk", "Tyrunt", "Tyrantrum", "Amaura", "Aurorus", "Sylveon", "Hawlucha", "Dedenne", "Carbink", "Goomy", "Sliggoo", "Goodra", "Klefki", "Phantump", "Trevenant", "Pumpkaboo", "Gourgeist", "Bergmite", "Avalugg", "Noibat", "Noivern", "Xerneas", "Yveltal", "Zygarde", "Diancie", "Hoopa", "Volcanion", "Rowlet", "Dartrix", "Decidueye", "Litten", "Torracat", "Incineroar", "Popplio", "Brionne", "Primarina", "Pikipek", "Trumbeak", "Toucannon", "Yungoos", "Gumshoos", "Grubbin", "Charjabug", "Vikavolt", "Crabrawler", "Crabominable", "Oricorio", "Cutiefly", "Ribombee", "Rockruff", "Lycanroc", "Wishiwashi", "Mareanie", "Toxapex", "Mudbray", "Mudsdale", "Dewpider", "Araquanid", "Fomantis", "Lurantis", "Morelull", "Shiinotic", "Salandit", "Salazzle", "Stufful", "Bewear", "Bounsweet", "Steenee", "Tsareena", "Comfey", "Oranguru", "Passimian", "Wimpod", "Golisopod", "Sandygast", "Palossand", "Pyukumuku", "Type: Null", "Silvally", "Minior", "Komala", "Turtonator", "Togedemaru", "Mimikyu", "Bruxish", "Drampa", "Dhelmise", "Jangmo-o", "Hakamo-o", "Kommo-o", "Tapu Koko", "Tapu Lele", "Tapu Bulu", "Tapu Fini", "Cosmog", "Cosmoem", "Solgaleo", "Lunala", "Nihilego", "Buzzwole", "Pheromosa", "Xurkitree", "Celesteela", "Kartana", "Guzzlord", "Necrozma", "Magearna", "Marshadow", "Poipole", "Naganadel", "Stakataka", "Blacephalon", "Zeraora", "Meltan", "Melmetal"}
    Public mythics() As String = {"Arceus", "Darkrai", "Deoxys", "Celebi", "Shaymin", "Mew", "Jerachi", "Hoopa", "Victini", "Phione", "Magearna", "Volcanion", "Diancie", "Genesect", "Keldeo", "Meloetta", "Manaphy", "Magearna", "Marshadow", "Zeraora", "Meltan", "Melmetal"}
    Public alolans() As String = {"Alolan Rattata", "Alolan Raticate", " Alolan Raichu", "Alolan Sandshrew", "Alolan Sandslash", "Alolan Vulpix", " Alolan Ninetales", "Alolan Diglett", "Alolan Dugtrio", "Alolan Meowth", "Alolan Persian", "Alolan Geodude", "Alolan Graveler", "Alolan Golem", "Alolan Grimer", "Alolan Muk", "Alolan Exeggutor", "Alolan Marowak"}
    Public ultrabeasts() As String = {"Nihilego", "Buzzwole", "Pheromosa", "Xurkitree", "Celesteela", "Kartana", "Guzzlord", "Poipole", "Naganadel", "Stakataka", "Blacephalon"}
    Public legends() As String = {"Articuno", "Zapdos", "Moltres", "Mewtwo", "Raikou", "Entei", "Suicune", "Ho-Oh", "Lugia", "Regirock", "Regice", "Registeel", "Regigigas", "Latios", "Latias", "Kyogre", "Groudon", "Rayquaza", "Dialga", "Palkia", "Heatran", "Giratina", "Cresselia", "Uxie", "Azelf", "Mesprit", "Zygarde", "Cobalion", "Terrakion", "Virizion", "Tornadus", "Thundurus", "Reshiram", "Zekrom", "Landorus", "Kyurem", "Xerneas", "Yveltal", "Zygarde", "Type: Null", "Silvally", "Cosmog", "Cosmoem", "Solgaleo", "Lunala", "Necrozma", "Tapu Lele", "Tapu Bulu", "Tapu Fini", "Tapu Koko"}
    Public pkmnEvents() As String = {"Detective Pikachu"}
    Public recentCatches() As String = {""}
    Public lstRecentCatches As List(Of String) = New List(Of String)(recentCatches)

    ' Bot variables
    Public botRunning As Boolean = True
    Public MainTimer As New Timers.Timer
    Public keyTimer As New Timers.Timer
    Public funcTimer As New Timers.Timer
    Public level As Integer = 0
    Public evo As Integer = 0
    Public catchCount As Integer = 0
    Public seenCount As Integer = 0
    Public shinyCount As Integer = 0
    Public lPKMN As Integer = 0
    Public mPKMN As Integer = 0
    Public ubPKMN As Integer = 0
    Public ePKMN As Integer = 0
    Public cPKMN As Integer = 0
    Public aPKMN As Integer = 0
    Public topcount As Integer = 0
    Public onlinecount As Integer = 0
    Public rPokemon As String
    Public topPokemon As String
    Public onlinestatus As Boolean
    Public encounter As Boolean
    Public xpOn As Boolean
    Dim voting As Boolean = False
    Dim StopWatch As New Stopwatch
    Dim swEncounter As New Stopwatch
    Dim encounterStart As Date
    Dim encounterStop As Date
    Dim catchTimes As New List(Of Integer)

    ' Load settings.ini
    Public iniSettings As New IniConfigSource(Application.StartupPath & "/config/settings.ini")
    Public token As String = iniSettings.Configs("Basic").Get("BotToken")
    Public channel As String = iniSettings.Configs("Basic").Get("Channel")
    Public clientype As String = iniSettings.Configs("Basic").Get("Client")
    Public pokePrefix As String = iniSettings.Configs("Basic").Get("Prefix")
    Public botHotkey As String = iniSettings.Configs("Basic").Get("BotHotkey")

    ' Load voter.ini
    Public iniVoter As New IniConfigSource(Application.StartupPath & "/config/voter.ini")
    Public autoVote As Boolean = iniVoter.Configs("Voter").Get("AutoVoter")
    Public lastVote As Date = iniVoter.Configs("Voter").Get("LastVote")
    Public voteClient As String = iniVoter.Configs("Voter").Get("Client")

    Public email As String = iniVoter.Configs("Discord").Get("Email")
    Public password As String = iniVoter.Configs("Discord").Get("Password")
    Public lastTime As Date

    ' Load updater.ini
    Public iniUpdater As New IniConfigSource(Application.StartupPath & "/config/updater.ini")
    Public autoUpdate As Boolean = iniUpdater.Configs("Updater").Get("AutoUpdate")
    Public version As String = iniUpdater.Configs("Updater").Get("Version")

    ' Load spam.ini
    Public iniSpammer As New IniConfigSource(Application.StartupPath & "/config/spam.ini")
    Public spamInterval As Integer = iniSpammer.Configs("Spammer").Get("SpamInterval")
    Public autoSpam As Boolean = iniSpammer.Configs("Spammer").Get("AutoSpam")

    ' Load levels.ini
    Dim iniLeveler As New IniConfigSource(Application.StartupPath & "/config/levels.ini")
    Dim levelGrind As Boolean = iniLeveler.Configs("Leveler").Get("AutoLevel")
    Dim levelAutoXP As Boolean = iniLeveler.Configs("Leveler").Get("AutoBuyXpBoost")
    Dim lastbuy As Date = iniLeveler.Configs("Leveler").Get("LastBoost")
    Dim levelQueue As String = iniLeveler.Configs("Leveler").Get("LevelQueue")
    Dim levelStats As Boolean = iniLeveler.Configs("Stats").Get("Visible")
    Dim levelTotal As Boolean = iniLeveler.Configs("Stats").Get("Totals")
    Dim levelQueueList As String() = levelQueue.Split(New Char() {","c})
    Dim lstLevelQueue As List(Of String) = New List(Of String)(levelQueueList)

    ' Load catch.ini
    Public iniCatcher As New IniConfigSource(Application.StartupPath & "/config/catch.ini")
    Public autoBal As Boolean = iniCatcher.Configs("Catcher").Get("AutoBal")
    Public catchDelay As Integer = iniCatcher.Configs("Catcher").Get("CatchDelay")
    Public pokeWhite As String = iniCatcher.Configs("Catcher").Get("PokeWhitelist")
    Public catchVisible As Boolean = iniCatcher.Configs("Stats").Get("Visible")
    Public catchTotals As Boolean = iniCatcher.Configs("Stats").Get("Totals")
    Public catchMostC As Boolean = iniCatcher.Configs("Stats").Get("MostCaught")
    Public catchMoney As Boolean = iniCatcher.Configs("Stats").Get("Money")
    Public whitelist As String() = pokeWhite.Split(New Char() {","c})
    Public whitecount As Integer = whitelist.Count

    ' Load notifications.ini
    Public iniNotifications As New IniConfigSource(Application.StartupPath & "/config/notifications.ini")
    Public legendToggle As Boolean = iniNotifications.Configs("Notifications").Get("Legendary")
    Public mythicToggle As Boolean = iniNotifications.Configs("Notifications").Get("Mythical")
    Public ultraToggle As Boolean = iniNotifications.Configs("Notifications").Get("UltraBeast")
    Public eventToggle As Boolean = iniNotifications.Configs("Notifications").Get("EventPkmn")
    Public shinyToggle As Boolean = iniNotifications.Configs("Notifications").Get("Shiny")
    Public alolanToggle As Boolean = iniNotifications.Configs("Notifications").Get("Alolan")
    Public customToggle As Boolean = iniNotifications.Configs("Notifications").Get("CustomPkmn")
    Public customPoke As String = iniNotifications.Configs("Notifications").Get("CustomPoke")
    Public cPokeList As String() = customPoke.Split(New Char() {","c})

    ' Load counts.ini
    Public iniCounts As New IniConfigSource(Application.StartupPath & "/config/counts.ini")
    Public seenPk As Integer = iniCounts.Configs("Catches").Get("Seen")
    Public catchPk As Integer = iniCounts.Configs("Catches").Get("Caught")
    Public legendPK As Integer = iniCounts.Configs("Catches").Get("Legendary")
    Public mythicPK As Integer = iniCounts.Configs("Catches").Get("Mythical")
    Public ubPK As Integer = iniCounts.Configs("Catches").Get("UltraBeast")
    Public eventPK As Integer = iniCounts.Configs("Catches").Get("Event")
    Public customePK As Integer = iniCounts.Configs("Catches").Get("Custom")
    Public shinyPK As Integer = iniCounts.Configs("Catches").Get("Shiny")
    Public alolanPK As Integer = iniCounts.Configs("Catches").Get("Alolan")
    Public popular As String = iniCounts.Configs("MostCaught").Get("Popular")
    Public popularCount As Integer = iniCounts.Configs("MostCaught").Get("PopularCount")
    Public levelPK As Integer = iniCounts.Configs("Levels").Get("Level")
    Public evoPK As Integer = iniCounts.Configs("Levels").Get("Evolution")
    Public creditCount As Integer = iniCounts.Configs("Money").Get("Credits")

    ' Set logfile
    Public logFile As String = Application.StartupPath & "/logs/" & DateTime.Now.ToString("ddMMyyHHmmss") & "_log.txt"

    ' Main sub
    Sub Main(args As String())
        handler = New ConsoleEventDelegate(AddressOf ConsoleEventCallback)
        SetConsoleCtrlHandler(handler, True)

        ' Start main as an async sub
        MainAsync.GetAwaiter.GetResult()
    End Sub

    ' Set discord client variable
    Public _client As DiscordSocketClient = New DiscordSocketClient

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
        AddHandler funcTimer.Elapsed, AddressOf tick3
    End Sub

    ' Async main function as referenced above
    ' Set the STA Thread
    <STAThread()>
    Public Async Function MainAsync() As Task
        Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
        Colorize("║                                            Loading Gotcha Bot v" & version & "                                              ║")
        Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
        ' Set thread
        Threading.Thread.CurrentThread.SetApartmentState(Threading.ApartmentState.STA)

        ' Check for update
        Dim verURL As String = "https://raw.githubusercontent.com/OniSensei/Gotcha-v2.1/master/version.txt"
        Dim client As WebClient = New WebClient
        Dim reader As StreamReader = New StreamReader(client.OpenRead(verURL))
        Dim iVersion As String = reader.ReadToEnd

        If autoUpdate = True Then
            If iVersion.Contains(version) = False Then ' Update
                Process.Start("Gotcha Updater.exe")
                End
            End If
        End If

        reader.Close()

        ' Wait for login using our token
        If token = "" Then
            Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
            Colorize("║                                                      Enter Token                                                    ║")
            Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
            iniSettings.Configs("Basic").Set("BotToken", Console.ReadLine())
            token = iniSettings.Configs("Basic").Get("BotToken")
            Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
            Colorize("║                                                     Token Updated                                                   ║")
            Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
            Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
            Colorize("║                                                     Enter Channel                                                   ║")
            Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")

            iniSettings.Configs("Basic").Set("Channel", Console.ReadLine())
            channel = iniSettings.Configs("Basic").Get("Channel")
            Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
            Colorize("║                                                    Channel Updated                                                  ║")
            Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
            iniSettings.Save()
        End If

        Try
            Await _client.LoginAsync(TokenType.Bot, token)
        Catch ex As Exception
            Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
            Colorize("║                                                     Invalid Token                                                   ║")
            Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
        End Try

        ' Update user count
        Try
            Dim userurl As String = "https://gotchabot.000webhostapp.com/v2/online/add.php"
            Dim uClient As WebClient = New WebClient
            Dim uReader As StreamReader = New StreamReader(uClient.OpenRead(userurl))
            Dim usr As String = uReader.ReadToEnd

            onlinecount = usr
            uReader.Close()
        Catch ex As Exception
        End Try

        ' Wait for the client to start
        Await _client.StartAsync
        Await Task.Delay(-1)
    End Function

    ' Log discord.net messages
    Private Async Function LogAsync(ByVal log As LogMessage) As Task(Of Task)
        ' Once loginasync and startasync finish we get the log message of "Ready" once we get that, we load everything else
        If log.ToString.Contains("Ready") Then
            ' This is mostly just visual crap cause we loaded the settings up above
            Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
            Colorize("║                                              Loading *.ini Config Files                                             ║")
            Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
            Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
            If Num(botHotkey) <= 9 Then
                Colorize("║                                   Bot Started | Press " & botHotkey & " to pause OR Esc to Close                                   ║")
            Else
                Colorize("║                                   Bot Started | Press " & botHotkey & " to pause OR Esc to Close                                  ║")
            End If
            Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")

            StopWatch.Start()

            ' Check vote
            If creditCount = 0 Then
                FindDiscordWindow(channel, clientype) ' Find discord window
                If GetCaptionOfActiveWindow() = "#" & channel & " - " & clientype Then
                    SendKeys.SendWait(pokePrefix & "bal") ' Send the command to see ballance and set credit count
                    SendKeys.SendWait("{Enter}")
                End If
            End If

            MainTimer.Interval = spamInterval

            ' Set most caught
            topcount = popularCount
                topPokemon = popular

                ' This timer is to detect F12 for pausing and resuming
                keyTimer.Interval = "500"
                keyTimer.Start()

                funcTimer.Interval = "1000"
                funcTimer.Start()
            ElseIf log.ToString.Contains("gateway") Or log.ToString.Contains("unhandled") Then
                ' dont log, people dont need to see it
            Else
                Colorize("[LOAD]      " & log.ToString) ' update console
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
                ' encounter timer
                Dim elapsedEncounter As TimeSpan = swEncounter.Elapsed
                catchTimes.Add(elapsedEncounter.TotalMilliseconds)

                Dim legendsent As Boolean = False
                If legendToggle = True Then ' if we want legendary notifications then continue
                    For Each value As String In legends ' Split the legendary list from above
                        If message.Content.Contains(value) Then ' if the pokemon is in the legendary list then continue
                            Await UserExtensions.SendMessageAsync(message.MentionedUsers.FirstOrDefault, message.Content.ToString) ' pm user its legendary

                            legendsent = True

                            ' Update stats
                            lPKMN += 1
                            legendPK += 1
                            iniCounts.Configs("Catches").Set("Legendary", legendPK)

                            iniCounts.Save()

                            Colorize("[INFO]      Legendary notification sent...") ' update console
                        End If
                    Next
                End If

                ' Repeat above with mythics, ultrabeasts, and event pokemon
                If mythicToggle = True Then
                    For Each value As String In mythics
                        If legendsent = False Then
                            If message.Content.Contains(value) Then
                                Await UserExtensions.SendMessageAsync(message.MentionedUsers.FirstOrDefault, message.Content.ToString)

                                ' Update stats
                                mPKMN += 1
                                mythicPK += 1
                                iniCounts.Configs("Catches").Set("Mythical", mythicPK)

                                iniCounts.Save()

                                Colorize("[INFO]      Mythical notification sent...")
                            End If
                        End If

                    Next
                End If

                If ultraToggle = True Then
                    For Each value As String In ultrabeasts
                        If message.Content.Contains(value) Then
                            Await UserExtensions.SendMessageAsync(message.MentionedUsers.FirstOrDefault, message.Content.ToString)

                            ' Update stats
                            ubPKMN += 1
                            ubPK += 1
                            iniCounts.Configs("Catches").Set("UltraBeast", ubPK)

                            iniCounts.Save()

                            Colorize("[INFO]      Ultra Beast notification sent...")
                        End If
                    Next
                End If

                If eventToggle = True Then
                    For Each value As String In pkmnEvents
                        If message.Content.Contains(value) Then
                            Await UserExtensions.SendMessageAsync(message.MentionedUsers.FirstOrDefault, message.Content.ToString)

                            ' Update stats
                            ePKMN += 1
                            eventPK += 1
                            iniCounts.Configs("Catches").Set("Event", eventPK)

                            iniCounts.Save()

                            Colorize("[INFO]      Event Pokemon notification sent...")
                        End If
                    Next
                End If

                If alolanToggle = True Then
                    For Each value As String In alolans
                        If message.Content.Contains(value) Then
                            Await UserExtensions.SendMessageAsync(message.MentionedUsers.FirstOrDefault, message.Content.ToString)

                            ' Update stats
                            aPKMN += 1
                            alolanPK += 1
                            iniCounts.Configs("Catches").Set("Alolan", alolanPK)

                            iniCounts.Save()

                            Colorize("[INFO]      Alolan Pokemon notification sent...")
                        End If
                    Next
                End If

                If customToggle = True Then
                    For Each value As String In cPokeList
                        If message.Content.Contains(value) Then
                            Await UserExtensions.SendMessageAsync(message.MentionedUsers.FirstOrDefault, message.Content.ToString)

                            ' Update stats
                            cPKMN += 1
                            customePK += 1
                            iniCounts.Configs("Catches").Set("Custom", customePK)

                            iniCounts.Save()

                            Colorize("[INFO]      Custom Pokemon notification sent...")
                        End If
                    Next
                End If

                ' End notifications

                ' Average times
                Dim tSize As Integer = catchTimes.Count
                Dim avgCatch As Double
                For i = 1 To tSize
                    avgCatch = catchTimes.Average
                Next

                ' Pokemon caught, update console & the catch count & recent catches
                Colorize("[CATCH]     Time to Identify: " & String.Format("{0} SEC {1} MS", Math.Round(elapsedEncounter.Seconds, 0, MidpointRounding.AwayFromZero), Math.Round(elapsedEncounter.Milliseconds, 0, MidpointRounding.AwayFromZero)) & " | Average Time to Identify: " & Math.Round(avgCatch, 2, MidpointRounding.AwayFromZero) & " MS")
                Colorize("[CATCH]     " & message.Content.ToString)

                swEncounter.Stop()
                swEncounter.Reset()

                catchCount += 1

                ' Add recent catch to list
                lstRecentCatches.Add(rPokemon)

                ' Update stats
                catchPk += 1
                iniCounts.Configs("Catches").Set("Caught", catchPk)

                iniCounts.Save()

                ' Count the most frequently caught pokemon
                Dim pkmncount As Integer = lstRecentCatches.Where(Function(value) value = rPokemon).Count

                ' Math for catch percentage
                Dim ratio As Double = Math.Round(catchCount / seenCount * 100)
                Dim ratio2 As Double = Math.Round(catchPk / seenPk * 100)

                If pkmncount >= topcount Then
                    topcount = pkmncount ' set new top count
                    topPokemon = rPokemon ' set new top pokemon

                    iniCounts.Configs("MostCaught").Set("Popular", topPokemon)
                    iniCounts.Configs("MostCaught").Set("PopularCount", topcount)
                    iniCounts.Save()

                    ' Update console with stats
                    If catchVisible = True Then
                        If catchTotals = True Then
                            Colorize("[STAT]      Seen: " & seenCount & " [" & seenPk & "] | Caught: " & catchCount & " [" & catchPk & "] | Catch Rate: " & ratio & "% [" & ratio2 & "%]")
                            Colorize("[STAT]      Legendary: " & lPKMN & " [" & legendPK & "] | Mythic: " & mPKMN & " [" & mythicPK & "] | Ultra Beast: " & ubPKMN& & " [" & ubPK & "] | Shiny: " & shinyCount & " [" & shinyPK & "] | Alolan: " & aPKMN & " [" & alolanPK & "]")
                        Else
                            Colorize("[STAT]      Seen: " & seenCount & " | Caught: " & catchCount & " | Catch Rate: " & ratio & "%")
                            Colorize("[STAT]      Legendary: " & lPKMN & " | Mythic: " & mPKMN & " | Ultra Beast: " & ubPKMN& & " | Shiny: " & shinyCount & " | Alolan: " & aPKMN)
                        End If
                    End If
                    If catchMostC = True Then
                        Colorize("[STAT]      [ NEW ] Most caught pokemon: " & topcount & " - " & topPokemon & " [ NEW ]")
                    End If
                Else
                    ' Update console with stats
                    If catchVisible = True Then
                        If catchTotals = True Then
                            Colorize("[STAT]      Seen: " & seenCount & " [" & seenPk & "] | Caught: " & catchCount & " [" & catchPk & "] | Catch Rate: " & ratio & "% [" & ratio2 & "%]")
                            Colorize("[STAT]      Legendary: " & lPKMN & " [" & legendPK & "] | Mythic: " & mPKMN & " [" & mythicPK & "] | Ultra Beast: " & ubPKMN& & " [" & ubPK & "] | Shiny: " & shinyCount & " [" & shinyPK & "] | Alolan: " & aPKMN & " [" & alolanPK & "]")
                        Else
                            Colorize("[STAT]      Seen: " & seenCount & " | Caught: " & catchCount & " | Catch Rate: " & ratio & "%")
                            Colorize("[STAT]      Legendary: " & lPKMN & " | Mythic: " & mPKMN & " | Ultra Beast: " & ubPKMN& & " | Shiny: " & shinyCount & " | Alolan: " & aPKMN)
                        End If
                    End If
                    If catchMostC = True Then
                        Colorize("[STAT]      Most caught pokemon: " & topcount & " - " & topPokemon)
                    End If
                End If

                ' Checks if the message also contains pokedex reward tags like added to pokedex, or 10th, or 100th pokemon caught
                ' Also only auto balance command if the toggle is on in settings
                If message.Content.Contains("Added to Pokédex") And autoBal = True Then
                    MainTimer.Stop()

                    Threading.Thread.Sleep(spamInterval) ' otherwise it can tell us we are sending commands to fast
                    FindDiscordWindow(channel, clientype) ' Find discord window
                    If GetCaptionOfActiveWindow() = "#" & channel & " - " & clientype Then
                        SendKeys.SendWait(pokePrefix & "pokedex claim all") ' Send the command to collect balance
                        SendKeys.SendWait("{Enter}")
                    End If

                    ' Update console
                    Colorize("[INFO]      New Pokédex reward available. Claiming the balance.")

                    creditCount += 50
                    iniCounts.Configs("Money").Set("Credits", creditCount)
                    iniCounts.Save()
                ElseIf message.Content.Contains("10th") And autoBal = True Then
                    MainTimer.Stop()

                    Threading.Thread.Sleep(spamInterval) ' otherwise it can tell us we are sending commands to fast
                    FindDiscordWindow(channel, clientype) ' Find discord window
                    If GetCaptionOfActiveWindow() = "#" & channel & " - " & clientype Then
                        SendKeys.SendWait(pokePrefix & "pokedex claim all") ' Send the command to collect balance
                        SendKeys.SendWait("{Enter}")
                    End If

                    ' Update console
                    Colorize("[INFO]      New Pokédex reward available. Claiming the balance.")

                    creditCount += 500
                    iniCounts.Configs("Money").Set("Credits", creditCount)
                    iniCounts.Save()
                ElseIf message.Content.Contains("100th") And autoBal = True Then
                    MainTimer.Stop()

                    Threading.Thread.Sleep(spamInterval) ' otherwise it can tell us we are sending commands to fast
                    FindDiscordWindow(channel, clientype) ' Find discord window
                    If GetCaptionOfActiveWindow() = "#" & channel & " - " & clientype Then
                        SendKeys.SendWait(pokePrefix & "pokedex claim all") ' Send the command to collect balance
                        SendKeys.SendWait("{Enter}")
                    End If

                    ' Update console
                    Colorize("[INFO]      New Pokédex reward available. Claiming the balance.")

                    creditCount += 500
                    iniCounts.Configs("Money").Set("Credits", creditCount)
                    iniCounts.Save()
                ElseIf message.Content.Contains("Shiny") Then
                    If shinyToggle = True Then ' if we want shiny notifications then continue
                        Colorize("[INFO]      Shiny notification sent...") ' update console
                        shinyCount += 1
                        shinyPK += 1
                        iniCounts.Configs("Catches").Set("Shiny", shinyPK)
                        iniCounts.Save()
                        Await UserExtensions.SendMessageAsync(message.MentionedUsers.FirstOrDefault, message.Content.ToString) ' pm user its shiny
                    End If
                End If
            End If

            ' Balance
            If message.Embeds(0).Description.Contains("You currently have") Then
                Try
                    MainTimer.Stop()

                    iniCounts.Configs("Money").Set("Credits", Num(message.Embeds(0).Description))
                    creditCount = Num(message.Embeds(0).Description)

                    iniCounts.Save()

                    Colorize("[INFO]      Credit balance updated, current credit count is: " & Num(message.Embeds(0).Description))
                Catch ex As Exception
                    Console.WriteLine(ex.tostring)
                End Try

            End If

            ' Wrong pokemon
            If message.Content.Contains("wrong") Then
                ' Update console
                Colorize("[ERROR]     " & message.Content.ToString)
            End If

            ' Encounter
            If message.Embeds.Count <> 0 And message.Embeds(0).Title.Contains("appeared!") Then
                ' Encounter timer
                swEncounter.Start()

                ' Stop the timer
                MainTimer.Stop()

                ' Update variable
                encounter = True

                ' Update console and seen count
                Colorize("[ENCOUNTER] A wild Pokémon has appeared!")
                seenCount += 1
                seenPk += 1
                iniCounts.Configs("Catches").Set("Seen", seenPk)

                iniCounts.Save()

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
                                    pokemonName = fi.Name
                                    pokemonName = pokemonName.Remove(pokemonName.Length - 4) ' clean up the ".txt" from end of file name
                                    If pokemonName = "TypeNull" Then pokemonName = "Type: Null" ' cleanup
                                    If pokeWhite.Contains(pokemonName) Then ' if pokemon is on the whitelist
                                        If pokemonName = "Nidoran_m" Then pokemonName = "Nidoran" ' cleanup

                                        ' set recent pokemon name
                                        rPokemon = pokemonName

                                        ' Catch delay
                                        Threading.Thread.Sleep(catchDelay)
                                        FindDiscordWindow(channel, clientype) ' find discord
                                        If GetCaptionOfActiveWindow() = "#" & channel & " - " & clientype Then
                                            SendKeys.SendWait(pokePrefix & "catch " & pokemonName.ToLower) ' Actual catch
                                            SendKeys.SendWait("{Enter}")
                                        End If
                                        encounter = False ' end encounter
                                        If autoSpam = True AndAlso MainTimer.Enabled = False AndAlso botRunning = True Then
                                            MainTimer.Start()
                                        End If
                                    Else
                                        ' Skip encounter and restart
                                        encounter = False
                                        If autoSpam = True AndAlso MainTimer.Enabled = False AndAlso botRunning = True Then
                                            MainTimer.Start()
                                        End If
                                        Colorize("[ENCOUNTER] Pokémon not whitelisted. Skipping...")
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
                Try
                    Dim fieldvalue As String = ""
                    Dim fieldname As String = ""
                    Dim desc As String = message.Embeds(0).Description.ToString
                    If message.Embeds(0).Fields.Count <> 0 Then
                        fieldvalue = message.Embeds(0).Fields(0).Value.ToString
                        fieldname = message.Embeds(0).Fields(0).Name.ToString
                    End If
                    levelFound(desc, fieldvalue, fieldname)
                Catch ex As Exception
                    Console.WriteLine()
                End Try
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
                        iniSettings.Save()

                        Colorize("[INFO]      Settings updated | Channel = " & param3) ' Update console
                    ElseIf param2 = "[token]" Then ' Token settings
                        param3 = param3.Substring(1)
                        param3 = param3.Substring(0, param3.Length - 1)
                        iniSettings.Configs("Basic").Set("BotToken", param3)
                        iniSettings.Save()

                        Colorize("[INFO]      Settings updated | BotToken = " & param3)
                    ElseIf param2 = "[client]" Then ' Token settings
                        param3 = param3.Substring(1)
                        param3 = param3.Substring(0, param3.Length - 1)
                        iniSettings.Configs("Basic").Set("Client", param3)
                        iniSettings.Save()

                        Colorize("[INFO]      Settings updated | Client = " & param3)
                    ElseIf param2 = "[prefix]" Then ' Prefix settings
                        param3 = param3.Substring(1)
                        param3 = param3.Substring(0, param3.Length - 1)
                        iniSettings.Configs("Basic").Set("Prefix", param3)
                        iniSettings.Save()

                        Colorize("[INFO]      Settings updated | Prefix = " & param3)
                    ElseIf param2 = "[hotkey]" Then ' Prefix settings
                        param3 = param3.Substring(1)
                        param3 = param3.Substring(0, param3.Length - 1)
                        iniSettings.Configs("Basic").Set("BotHotkey", """" & param3 & """")
                        iniSettings.Save()

                        Colorize("[INFO]      Settings updated | Hotkey = " & param3)
                    ElseIf param2 = "[autoupdate]" Then ' Auto update settings
                        If param3 = "[on]" Then
                            MainTimer.Interval = spamInterval
                            iniUpdater.Configs("Updater").Set("AutoUpdate", "True")
                            iniUpdater.Save()

                            Colorize("[INFO]      Settings updated | AutoUpdate = True")
                        ElseIf param3 = "[off]" Then
                            iniUpdater.Configs("Updater").Set("AutoUpdate", "False")
                            iniUpdater.Save()

                            Colorize("[INFO]      Settings updated | AutoUpdate = Flase")
                        End If
                    ElseIf param2 = "[autovote]" Then ' Auto update settings
                        If param3 = "[on]" Then
                            MainTimer.Interval = spamInterval
                            iniVoter.Configs("Voter").Set("AutoVoter", "True")
                            iniVoter.Save()

                            Colorize("[INFO]      Settings updated | AutoVoter = True")
                        ElseIf param3 = "[off]" Then
                            iniVoter.Configs("Voter").Set("AutoVoter", "False")
                            iniVoter.Save()

                            Colorize("[INFO]      Settings updated | AutoVoter = Flase")
                        End If
                    ElseIf param2 = "[spamdelay]" Then ' Spam delay settings
                        param3 = param3.Substring(1)
                        param3 = param3.Substring(0, param3.Length - 1)
                        MainTimer.Interval = param3
                        spamInterval = param3
                        iniSpammer.Configs("Spammer").Set("SpamInterval", param3)
                        iniSpammer.Save()

                        Colorize("[INFO]      Settings updated | SpamInterval = " & param3)
                    ElseIf param2 = "[autospam]" Then ' Auto spam settings
                        If param3 = "[on]" Then
                            MainTimer.Interval = spamInterval
                            iniSpammer.Configs("Spammer").Set("AutoSpam", "True")
                            iniSpammer.Save()

                            Colorize("[INFO]      Settings updated | AutoSpam = True")
                        ElseIf param3 = "[off]" Then
                            iniSpammer.Configs("Spammer").Set("AutoSpam", "False")
                            iniSpammer.Save()

                            Colorize("[INFO]      Settings updated | AutoSpam = Flase")
                        End If
                    ElseIf param2 = "[autolevel]" Then ' Auto level settings
                        If param3 = "[on]" Then
                            MainTimer.Interval = spamInterval
                            iniLeveler.Configs("Leveler").Set("AutoLevel", "True")
                            iniLeveler.Save()

                            Colorize("[INFO]      Settings updated | AutoLevel = True")
                        ElseIf param3 = "[off]" Then
                            iniLeveler.Configs("Leveler").Set("AutoLevel", "False")
                            iniLeveler.Save()

                            Colorize("[INFO]      Settings updated | AutoLevel = Flase")
                        End If
                    ElseIf param2 = "[autobal]" Then ' Auto ballance settings
                        If param3 = "[on]" Then
                            iniCatcher.Configs("Catcher").Set("AutoBal", "True")
                            iniCatcher.Save()

                            Colorize("[INFO]      Settings updated | AutoBal = True")
                        ElseIf param3 = "[off]" Then
                            iniCatcher.Configs("Catcher").Set("AutoBal", "False")
                            iniCatcher.Save()

                            Colorize("[INFO]      Settings updated | AutoBal = Flase")
                        End If
                    ElseIf param2 = "[catchdelay]" Then ' Catch delay settings
                        param3 = param3.Substring(1)
                        param3 = param3.Substring(0, param3.Length - 1)
                        catchDelay = param3
                        iniCatcher.Configs("Catcher").Set("CatchDelay", param3)
                        iniCatcher.Save()

                        Colorize("[INFO]      Settings updated | CatchDelay = " & param3)
                    ElseIf param2 = "[legend]" Then ' Legendary notifications
                        If param3 = "[on]" Then
                            iniNotifications.Configs("Notifications").Set("Legendary", "True")
                            iniNotifications.Save()

                            Colorize("[INFO]      Settings updated | Legendary = True")
                        ElseIf param3 = "[off]" Then
                            iniNotifications.Configs("Notifications").Set("Legendary", "False")
                            iniNotifications.Save()

                            Colorize("[INFO]      Settings updated | Legendary = Flase")
                        End If
                    ElseIf param2 = "[mythic]" Then ' Mythic notifications
                        If param3 = "[on]" Then
                            iniNotifications.Configs("Notifications").Set("Mythical", "True")
                            iniNotifications.Save()

                            Colorize("[INFO]      Settings updated | Mythical = True")
                        ElseIf param3 = "[off]" Then
                            iniNotifications.Configs("Notifications").Set("Mythical", "False")
                            iniNotifications.Save()

                            Colorize("[INFO]      Settings updated | Mythical = Flase")
                        End If
                    ElseIf param2 = "[ultrabeast]" Then ' Ultra Beast notifications
                        If param3 = "[on]" Then
                            iniNotifications.Configs("Notifications").Set("UltraBeast", "True")
                            iniNotifications.Save()

                            Colorize("[INFO]      Settings updated | UltraBeast = True")
                        ElseIf param3 = "[off]" Then
                            iniNotifications.Configs("Notifications").Set("UltraBeast", "False")
                            iniNotifications.Save()

                            Colorize("[INFO]      Settings updated | UltraBeast = Flase")
                        End If
                    ElseIf param2 = "[event]" Then ' Event notifications
                        If param3 = "[on]" Then
                            iniNotifications.Configs("Notifications").Set("EeventPokemon", "True")
                            iniNotifications.Save()

                            Colorize("[INFO]      Settings updated | EventPokemon = True")
                        ElseIf param3 = "[off]" Then
                            iniNotifications.Configs("Notifications").Set("EventPokemon", "False")
                            iniNotifications.Save()

                            Colorize("[INFO]      Settings updated | EventPokemon = Flase")
                        End If
                    ElseIf param2 = "[shiny]" Then ' Shiny notifications
                        If param3 = "[on]" Then
                            iniNotifications.Configs("Notifications").Set("Shiny", "True")
                            iniNotifications.Save()

                            Colorize("[INFO]      Settings updated | Shiny = True")
                        ElseIf param3 = "[off]" Then
                            iniNotifications.Configs("Notifications").Set("Shiny", "False")
                            iniNotifications.Save()

                            Colorize("[INFO]      Settings updated | Shiny = Flase")
                        End If
                    ElseIf param2 = "[custom]" Then ' Shiny notifications
                        If param3 = "[on]" Then
                            iniNotifications.Configs("Notifications").Set("CustomPkmn", "True")
                            iniNotifications.Save()

                            Colorize("[INFO]      Settings updated | CustomPkmn = True")
                        ElseIf param3 = "[off]" Then
                            iniNotifications.Configs("Notifications").Set("CustomPkmn", "False")
                            iniNotifications.Save()

                            Colorize("[INFO]      Settings updated | CustomPkmn = Flase")
                        End If
                    ElseIf param2 = "[reload]" Then ' Reload settings
                        token = iniSettings.Configs("Basic").Get("BotToken")
                        channel = iniSettings.Configs("Basic").Get("Channel")
                        pokePrefix = iniSettings.Configs("Basic").Get("Prefix")
                        botHotkey = iniSettings.Configs("Basic").Get("BotHotkey")
                        version = iniUpdater.Configs("Updater").Get("Version")
                        autoUpdate = iniUpdater.Configs("Updater").Get("AutoUpdate")
                        spamInterval = iniSpammer.Configs("Spammer").Get("SpamInterval")
                        autoSpam = iniSpammer.Configs("Spammer").Get("AutoSpam")
                        autoVote = iniVoter.Configs("Voter").Get("AutoVote")
                        levelGrind = iniLeveler.Configs("Leveler").Get("AutoLevel")
                        autoBal = iniCatcher.Configs("Catcher").Get("AutoBal")
                        catchDelay = iniCatcher.Configs("Catcher").Get("CatchDelay")
                        legendToggle = iniNotifications.Configs("Notifications").Get("Legendary")
                        mythicToggle = iniNotifications.Configs("Notifications").Get("Mythical")
                        ultraToggle = iniNotifications.Configs("Notifications").Get("UltraBeast")
                        eventToggle = iniNotifications.Configs("Notifications").Get("EventPkmn")
                        shinyToggle = iniNotifications.Configs("Notifications").Get("Shiny")
                        customToggle = iniNotifications.Configs("Notifications").Get("Custom")

                        MainTimer.Interval = spamInterval
                        If autoSpam = True AndAlso botRunning = True Then
                            MainTimer.Start()
                        End If
                        Colorize("[INFO]      Settings Reloaded...")
                    End If
                ElseIf param1 = "[online]" Then ' online check
                    Colorize("[INFO]      " & onlinecount & " Users Online")
                ElseIf param1 = "[cmd]" Or param1 = "[cmds]" Or param1 = "[help]" Or param1 = "[commands]" Or param1 = "[?]" Or param1 = "[command]" Or param1 = "[help]" Then
                    ' Send pm with command list
                    Dim builder As New EmbedBuilder
                    builder.WithTitle("Gotcha Bot v2.1 Commands")
                    builder.WithFooter(message.Timestamp.ToString)
                    builder.WithColor(45, 45, 45)
                    builder.WithDescription("Prefix: +g | ex. +g[param1][param2][param3] | ex. +g[settings][autoupdate][off] turns off auto updates.")
                    builder.AddField("+g[settings][channel][channelname]", "This command changes the channel name in the settings.ini file. Replace channelname with your channel name.", False)
                    builder.AddField("+g[settings][token][yourtoken]", "This command changes the token in the settings.ini file. Replace yourtoken with your channel name. The bot will need to be rebooted after this command.", False)
                    builder.AddField("+g[settings][client][Discord]", "This command changes the client in the settings.ini file. Replace Discord with your client | Desktop: Discord | Chrome: Google Chrome | Firefox: Mozilla Firefox.", False)
                    builder.AddField("+g[settings][prefix][p!]", "This command changes the token in the settings.ini file. Replace p! with your pokecord prefix.", False)
                    builder.AddField("+g[settings][hotkey][F1-F12]", "This command changes the bot pause/resume hotkey in the settings.ini file. Replace F1-F12 with your hotkey preference.", False)
                    builder.AddField("+g[settings][spamdelay][1500]", "This command changes the spam delay in the spammer.ini file. [1500ms the default, is the suggested ammount]", False)
                    builder.AddField("+g[settings][autospam][on/off]", "This command changes the auto spammer to true or false in the spam.ini file.", False)
                    builder.AddField("+g[settings][autoupdate][on/off]", "This command changes the auto updater to true or false in the updater.ini file.", False)
                    builder.AddField("+g[settings][autolevel][on/off]", "This command changes the auto leveler to true or false in the leveler.ini file.", False)
                    builder.AddField("+g[settings][autobal][on/off]", "This command changes the auto pokedex claiming to true or false in the catcher.ini file.", False)
                    builder.AddField("+g[settings][catchdelay][750]", "This command changes the catch delay in the catcher.ini file. [750ms the default, is the suggested ammount]", False)
                    builder.AddField("+g[settings][legend][on/off]", "This command changes the legendary notifications to true or false in the notifications.ini file.", False)
                    builder.AddField("+g[settings][mythic][on/off]", "This command changes the mythic notifications to true or false in the notifications.ini file.", False)
                    builder.AddField("+g[settings][ultrabeast][on/off]", "This command changes the ultra beast notifications to true or false in the notifications.ini file.", False)
                    builder.AddField("+g[settings][event][on/off]", "This command changes the event notifications to true or false in the notifications.ini file.", False)
                    builder.AddField("+g[settings][shiny][on/off]", "This command changes the shiny notifications to true or false in the notifications.ini file.", False)
                    builder.AddField("+g[settings][custom][on/off]", "This command changes the custom notifications to true or false in the notifications.ini file.", False)
                    builder.AddField("+g[settings][reload]", "This command reloads the config .ini files. This is required after any settings changes in order to take effect.", False)
                    builder.AddField("Github", "https://github.com/OniSensei/Gotcha-v2.1", False)
                    builder.AddField("Discord", "DefaulT#2648 - Message me for invite to private discord server.", False)

                    Await message.Author.SendMessageAsync("", False, builder.Build())
                End If
            End If

            If message.Content = pokePrefix & "daily" And autoVote = True Then
                If voteClient = "Google Chrome" Then
                    Try
                        Dim options As New ChromeOptions
                        options.AddArgument("--window-size=1280,720")
                        options.AddArgument("--disable-gpu")
                        options.AddArgument("ignore-certificate-errors")
                        options.Proxy = Nothing

                        Dim service As ChromeDriverService = ChromeDriverService.CreateDefaultService
                        service.HideCommandPromptWindow = True

                        Dim driver As New ChromeDriver(service, options)
                        Dim js As IJavaScriptExecutor = CType(driver, IJavaScriptExecutor)
                        Dim wait As WebDriverWait = New WebDriverWait(driver, New TimeSpan(0, 5, 0))

                        driver.Navigate.GoToUrl("https://discordbots.org/")
                        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href*='login']")))

                        driver.FindElement(By.CssSelector("a[href*='login']")).Click()

                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@aria-label='Email']")))
                        driver.FindElement(By.XPath("//input[@aria-label='Email']")).SendKeys(email)
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@aria-label='Password']")))
                        driver.FindElement(By.XPath("//input[@aria-label='Password']")).SendKeys(password)

                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@type='submit']")))
                        driver.FindElement(By.XPath("//button[@type='submit']")).Submit()

                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[normalize-space(.)='Authorize']")))
                        driver.FindElement(By.XPath("//div[normalize-space(.)='Authorize']")).Click()

                        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href*='logout']")))
                        driver.Navigate.GoToUrl("https://discordbots.org/bot/365975655608745985")

                        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href*='/bot/365975655608745985/vote']")))
                        driver.FindElement(By.CssSelector("a[href*='/bot/365975655608745985/vote']")).Click()

                        Threading.Thread.Sleep(10000)
                        js.ExecuteScript("upvote('365975655608745985', this)")

                        Threading.Thread.Sleep(10000)

                        driver.Quit()
                        driver.Dispose()

                        Colorize("[INFO]      Daily vote completed " & Date.Now)


                        MainTimer.Stop()
                        FindDiscordWindow(channel, clientype) ' Find discord window
                        If GetCaptionOfActiveWindow() = "#" & channel & " - " & clientype Then
                            SendKeys.SendWait(pokePrefix & "daily claim") ' Send the command to see ballance and set credit count
                            SendKeys.SendWait("{Enter}")
                        End If

                        iniVoter.Configs("Voter").Set("LastVote", Date.Now)
                        iniVoter.Save()

                        lastVote = Date.Now

                        If autoSpam = True AndAlso botRunning = True Then
                            MainTimer.Start()
                        End If

                        funcTimer.Start()

                        voting = False
                    Catch ex As Exception
                        Console.WriteLine(ex.ToString)
                    End Try
                ElseIf voteClient = "Mozilla Firefox" Then
                    Try
                        Dim options As New FirefoxOptions
                        options.AddArgument("--window-size=1280,720")

                        Dim service As FirefoxDriverService = FirefoxDriverService.CreateDefaultService
                        service.HideCommandPromptWindow = True

                        Dim driver As New FirefoxDriver(service, options)
                        Dim js As IJavaScriptExecutor = CType(driver, IJavaScriptExecutor)
                        Dim wait As WebDriverWait = New WebDriverWait(driver, New TimeSpan(0, 5, 0))

                        driver.Navigate.GoToUrl("https://discordbots.org/")
                        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href*='login']")))

                        driver.FindElement(By.CssSelector("a[href*='login']")).Click()

                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@aria-label='Email']")))
                        driver.FindElement(By.XPath("//input[@aria-label='Email']")).SendKeys(email)
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@aria-label='Password']")))
                        driver.FindElement(By.XPath("//input[@aria-label='Password']")).SendKeys(password)

                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@type='submit']")))
                        driver.FindElement(By.XPath("//button[@type='submit']")).Submit()

                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[normalize-space(.)='Authorize']")))
                        driver.FindElement(By.XPath("//div[normalize-space(.)='Authorize']")).Click()

                        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href*='logout']")))
                        driver.Navigate.GoToUrl("https://discordbots.org/bot/365975655608745985")

                        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href*='/bot/365975655608745985/vote']")))
                        driver.FindElement(By.CssSelector("a[href*='/bot/365975655608745985/vote']")).Click()

                        Threading.Thread.Sleep(10000)
                        js.ExecuteScript("upvote('365975655608745985', this)")

                        Threading.Thread.Sleep(10000)

                        driver.Quit()
                        driver.Dispose()

                        Colorize("[INFO]      Daily vote completed " & Date.Now)


                        MainTimer.Stop()
                        FindDiscordWindow(channel, clientype) ' Find discord window
                        If GetCaptionOfActiveWindow() = "#" & channel & " - " & clientype Then
                            SendKeys.SendWait(pokePrefix & "daily claim") ' Send the command to see ballance and set credit count
                            SendKeys.SendWait("{Enter}")
                        End If

                        iniVoter.Configs("Voter").Set("LastVote", Date.Now)
                        iniVoter.Save()

                        lastVote = Date.Now

                        If autoSpam = True AndAlso botRunning = True Then
                            MainTimer.Start()
                        End If

                        funcTimer.Start()

                        voting = False
                    Catch ex As Exception
                        Console.WriteLine(ex.ToString)
                    End Try
                End If
            End If
        End If
    End Function

    ' Extract numbers from string
    Private Function Num(ByVal value As String) As Integer
        Dim returnVal As String = String.Empty
        Dim collection As MatchCollection = Regex.Matches(value, "\d+")
        For Each m As Match In collection
            returnVal += m.ToString()
        Next
        Return Convert.ToInt32(returnVal)
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

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Function GetForegroundWindow() As IntPtr
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Function GetWindowText(hWnd As IntPtr, text As StringBuilder, count As Integer) As Integer
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Function GetWindowTextLength(hWnd As IntPtr) As Integer
    End Function

    Private Function GetCaptionOfActiveWindow() As String
        Dim strTitle As String = String.Empty
        Dim handle As IntPtr = GetForegroundWindow()
        ' Obtain the length of the text   
        Dim intLength As Integer = GetWindowTextLength(handle) + 1
        Dim stringBuilder As New StringBuilder(intLength)
        If GetWindowText(handle, stringBuilder, intLength) > 0 Then
            strTitle = stringBuilder.ToString()
        End If
        Return strTitle
    End Function

    Public Sub FindDiscordWindow(ByVal channel As String, ByVal clType As String)
        Dim nWnd As IntPtr
        Dim ceroIntPtr As New IntPtr(0)
        Dim Wnd_name As String

        Wnd_name = "#" & channel & " - " & clType
        nWnd = FindWindow(Nothing, Wnd_name)

        SetForegroundWindow(nWnd)
    End Sub

    ' Function to check pokecord status
    Public Sub checkPokecord()
        If _client.GetUser("365975655608745985").Status = UserStatus.Online Then
            onlinestatus = True ' Set status
            If MainTimer.Enabled = False AndAlso autoSpam = True AndAlso encounter = False AndAlso botRunning = True AndAlso voting = False Then ' Restart spammer if it was previously off
                MainTimer.Start()
            End If
        Else
            onlinestatus = False ' Set status
            If MainTimer.Enabled = True Then ' Turn off spammer if its still on
                MainTimer.Stop()
                Colorize("[ERROR]     " & DateTime.Now & " Pokécord Offline...")
                encounter = False
            End If
        End If
    End Sub

    ' Spam chat
    Public Sub SpamChats()
        ' Find discord
        FindDiscordWindow(channel, clientype)

        ' Make active window check
        If GetCaptionOfActiveWindow() = "#" & channel & " - " & clientype Then
            ' Check for spamchat file
            If File.Exists(Application.StartupPath & "/config/spamchat.txt") Then
                Dim ioFile As New StreamReader(Application.StartupPath & "/config/spamchat.txt")
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
                Colorize("[ERROR]     Cannot locate /config/spamchat.txt...") ' error
                MainTimer.Stop()
            End If
        End If
    End Sub

    ' Spam chat timer
    Private Sub tick(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)
        ' Spam chat function above
        SpamChats()
    End Sub

    ' F12 Pause timer
    Private Sub tick2(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)
        If botHotkey = "F1" Then
            ' Checks keystate and acts
            If GetAsyncKeyState(VK_F1) Then
                If botRunning = True Then
                    MainTimer.Stop() ' pause
                    botRunning = False ' update toggle
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Paused | Press " & botHotkey & " to resume OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                Else
                    If autoSpam = True Then
                        MainTimer.Start()
                    End If
                    botRunning = True
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Resumed | Press " & botHotkey & " to pause OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                End If
            End If
        ElseIf botHotkey = "F2" Then
            ' Checks keystate and acts
            If GetAsyncKeyState(VK_F2) Then
                If botRunning = True Then
                    MainTimer.Stop() ' pause
                    botRunning = False ' update toggle
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Paused | Press " & botHotkey & " to resume OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                Else
                    If autoSpam = True Then
                        MainTimer.Start()
                    End If
                    botRunning = True
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Resumed | Press " & botHotkey & " to pause OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                End If
            End If
        ElseIf botHotkey = "F3" Then
            ' Checks keystate and acts
            If GetAsyncKeyState(VK_F3) Then
                If botRunning = True Then
                    MainTimer.Stop() ' pause
                    botRunning = False ' update toggle
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Paused | Press " & botHotkey & " to resume OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                Else
                    If autoSpam = True Then
                        MainTimer.Start()
                    End If
                    botRunning = True
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Resumed | Press " & botHotkey & " to pause OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                End If
            End If
        ElseIf botHotkey = "F4" Then
            ' Checks keystate and acts
            If GetAsyncKeyState(VK_F4) Then
                If botRunning = True Then
                    MainTimer.Stop() ' pause
                    botRunning = False ' update toggle
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Paused | Press " & botHotkey & " to resume OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                Else
                    If autoSpam = True Then
                        MainTimer.Start()
                    End If
                    botRunning = True
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Resumed | Press " & botHotkey & " to pause OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                End If
            End If
        ElseIf botHotkey = "F5" Then
            ' Checks keystate and acts
            If GetAsyncKeyState(VK_F5) Then
                If botRunning = True Then
                    MainTimer.Stop() ' pause
                    botRunning = False ' update toggle
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Paused | Press " & botHotkey & " to resume OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                Else
                    If autoSpam = True Then
                        MainTimer.Start()
                    End If
                    botRunning = True
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Resumed | Press " & botHotkey & " to pause OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                End If
            End If
        ElseIf botHotkey = "F6" Then
            ' Checks keystate and acts
            If GetAsyncKeyState(VK_F6) Then
                If botRunning = True Then
                    MainTimer.Stop() ' pause
                    botRunning = False ' update toggle
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Paused | Press " & botHotkey & " to resume OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                Else
                    If autoSpam = True Then
                        MainTimer.Start()
                    End If
                    botRunning = True
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Resumed | Press " & botHotkey & " to pause OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                End If
            End If
        ElseIf botHotkey = "F7" Then
            ' Checks keystate and acts
            If GetAsyncKeyState(VK_F7) Then
                If botRunning = True Then
                    MainTimer.Stop() ' pause
                    botRunning = False ' update toggle
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Paused | Press " & botHotkey & " to resume OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                Else
                    If autoSpam = True Then
                        MainTimer.Start()
                    End If
                    botRunning = True
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Resumed | Press " & botHotkey & " to pause OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                End If
            End If
        ElseIf botHotkey = "F8" Then
            ' Checks keystate and acts
            If GetAsyncKeyState(VK_F8) Then
                If botRunning = True Then
                    MainTimer.Stop() ' pause
                    botRunning = False ' update toggle
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Paused | Press " & botHotkey & " to resume OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                Else
                    If autoSpam = True Then
                        MainTimer.Start()
                    End If
                    botRunning = True
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Resumed | Press " & botHotkey & " to pause OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                End If
            End If
        ElseIf botHotkey = "F9" Then
            ' Checks keystate and acts
            If GetAsyncKeyState(VK_F9) Then
                If botRunning = True Then
                    MainTimer.Stop() ' pause
                    botRunning = False ' update toggle
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Paused | Press " & botHotkey & " to resume OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                Else
                    If autoSpam = True Then
                        MainTimer.Start()
                    End If
                    botRunning = True
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Resumed | Press " & botHotkey & " to pause OR Esc to Close                                 ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                End If
            End If
        ElseIf botHotkey = "F10" Then
            ' Checks keystate and acts
            If GetAsyncKeyState(VK_F10) Then
                If botRunning = True Then
                    MainTimer.Stop() ' pause
                    botRunning = False ' update toggle
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Paused | Press " & botHotkey & " to resume OR Esc to Close                                  ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                Else
                    If autoSpam = True Then
                        MainTimer.Start()
                    End If
                    botRunning = True
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Resumed | Press " & botHotkey & " to pause OR Esc to Close                                  ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                End If
            End If
        ElseIf botHotkey = "F11" Then
            ' Checks keystate and acts
            If GetAsyncKeyState(VK_F11) Then
                If botRunning = True Then
                    MainTimer.Stop() ' pause
                    botRunning = False ' update toggle
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Paused | Press " & botHotkey & " to resume OR Esc to Close                                  ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")

                Else
                    If autoSpam = True Then
                        MainTimer.Start()
                    End If
                    botRunning = True
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Resumed | Press " & botHotkey & " to pause OR Esc to Close                                  ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                End If
            End If
        ElseIf botHotkey = "F12" Then
            ' Checks keystate and acts
            If GetAsyncKeyState(VK_F12) Then
                If botRunning = True Then
                    MainTimer.Stop() ' pause
                    botRunning = False ' update toggle
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Paused | Press " & botHotkey & " to resume OR Esc to Close                                  ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                Else
                    If autoSpam = True Then
                        MainTimer.Start()
                    End If
                    botRunning = True
                    Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
                    Colorize("║                                   Bot Resumed | Press " & botHotkey & " to pause OR Esc to Close                                  ║")
                    Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")
                End If
            End If
        End If

        If GetAsyncKeyState(Windows.Forms.Keys.Escape) Then
            Colorize("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗")
            Colorize("║                                   Bot Closing | Prepairing final tasks and saving                                   ║")
            Colorize("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝")

            ' Update user count
            Try
                Dim verURL As String = "https://gotchabot.000webhostapp.com/v2/online/remove.php"
                Dim client As WebClient = New WebClient
                Dim reader As StreamReader = New StreamReader(client.OpenRead(verURL))
                Dim iVersion As String = reader.ReadToEnd
                reader.Close()

                _client.Dispose()
            Catch ex As Exception
            End Try

            End
        End If
    End Sub

    ' function checker
    Private Sub tick3(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)
        ' Check daily vote
        If autoVote = True Then
            If (Date.Now - lastVote).TotalHours > 12 AndAlso (Date.Now - lastVote).TotalMinutes > 5 Then
                voting = True
                funcTimer.Stop()
                MainTimer.Stop()

                FindDiscordWindow(channel, clientype) ' Find discord window
                SendKeys.SendWait(pokePrefix & "daily")
                SendKeys.SendWait("{Enter}")
            End If
        End If

        Dim elapsed As TimeSpan = StopWatch.Elapsed
        Console.Title = "Bot Runtime: " & String.Format("{0}DAY {1}HR {2}MIN {3}SEC", elapsed.Days, elapsed.Hours, elapsed.Minutes, elapsed.Seconds)

        If voting = False Then
            If xpOn = False And (Date.Now - lastbuy).TotalHours < 2 AndAlso (Date.Now - lastbuy).TotalMinutes < 5 Then
                xpOn = True
            End If

            ' Auto xp purchase
            If levelAutoXP = True AndAlso creditCount > 70 AndAlso xpOn = False Then
                lastbuy = Date.Now
                iniLeveler.Configs("Leveler").Set("LastBoost", lastbuy)
                iniLeveler.Save()

                If autoSpam = True Then
                    MainTimer.Stop()
                End If

                FindDiscordWindow(channel, clientype) ' Find discord window
                SendKeys.SendWait(pokePrefix & "buy 3")
                SendKeys.SendWait("{Enter}")

                xpOn = True

                creditCount -= 70
                iniCounts.Configs("Money").Set("Credits", creditCount)
                iniCounts.Save()

                iniLeveler.Configs("Leveler").Set("LastBoost", Date.Now)
                iniLeveler.Save()

                Threading.Thread.Sleep("2000")
                If autoSpam = True AndAlso botRunning = True Then
                    MainTimer.Start()
                End If
            End If

            ' Timed toggle
            If xpOn = True AndAlso (Date.Now - lastbuy).TotalHours > 2 AndAlso (Date.Now - lastbuy).TotalMinutes > 5 Then
                xpOn = False
            End If
        End If

        ' Check for pokecord online status
        checkPokecord()
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
                Console.ForegroundColor = ConsoleColor.DarkCyan
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
            Case msg.Contains("STAT")
                Console.ForegroundColor = ConsoleColor.DarkGray
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
    Public Function GetAsyncKeyState(ByVal vKey As Windows.Forms.Keys) As Short
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

    Private Function ConsoleEventCallback(ByVal eventType As Integer) As Boolean
        Select Case eventType
            Case 0
                ' Update user count
                Try
                    Dim verURL As String = "https://gotchabot.000webhostapp.com/v2/online/remove.php"
                    Dim client As WebClient = New WebClient
                    Dim reader As StreamReader = New StreamReader(client.OpenRead(verURL))
                    Dim iVersion As String = reader.ReadToEnd
                    reader.Close()

                    Colorize("[INFO]      Bot Closing | Prepairing final tasks and saving")

                    _client.Dispose()
                Catch ex As Exception
                End Try
            Case 1
                ' Update user count
                Try
                    Dim verURL As String = "https://gotchabot.000webhostapp.com/v2/online/remove.php"
                    Dim client As WebClient = New WebClient
                    Dim reader As StreamReader = New StreamReader(client.OpenRead(verURL))
                    Dim iVersion As String = reader.ReadToEnd
                    reader.Close()

                    Colorize("[INFO]      Bot Closing | Prepairing final tasks and saving")

                    _client.Dispose()
                Catch ex As Exception
                End Try
            Case 2
                ' Update user count
                Try
                    Dim verURL As String = "https://gotchabot.000webhostapp.com/v2/online/remove.php"
                    Dim client As WebClient = New WebClient
                    Dim reader As StreamReader = New StreamReader(client.OpenRead(verURL))
                    Dim iVersion As String = reader.ReadToEnd
                    reader.Close()

                    Colorize("[INFO]      Bot Closing | Prepairing final tasks and saving")

                    _client.Dispose()
                Catch ex As Exception
                End Try
            Case 5
                ' Update user count
                Try
                    Dim verURL As String = "https://gotchabot.000webhostapp.com/v2/online/remove.php"
                    Dim client As WebClient = New WebClient
                    Dim reader As StreamReader = New StreamReader(client.OpenRead(verURL))
                    Dim iVersion As String = reader.ReadToEnd
                    reader.Close()

                    Colorize("[INFO]      Bot Closing | Prepairing final tasks and saving")

                    _client.Dispose()
                Catch ex As Exception
                End Try
            Case 6
                ' Update user count
                Try
                    Dim verURL As String = "https://gotchabot.000webhostapp.com/v2/online/remove.php"
                    Dim client As WebClient = New WebClient
                    Dim reader As StreamReader = New StreamReader(client.OpenRead(verURL))
                    Dim iVersion As String = reader.ReadToEnd
                    reader.Close()

                    Colorize("[INFO]      Bot Closing | Prepairing final tasks and saving")

                    _client.Dispose()
                Catch ex As Exception
                End Try
        End Select
        Return False
    End Function

    Dim handler As ConsoleEventDelegate
    Private Delegate Function ConsoleEventDelegate(ByVal eventType As Integer) As Boolean
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Function SetConsoleCtrlHandler(ByVal callback As ConsoleEventDelegate, ByVal add As Boolean) As Boolean
    End Function
End Module
