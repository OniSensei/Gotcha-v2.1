Imports System.Net
Imports Discord
Imports Discord.WebSocket
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Module Gotcha
    Dim pkmn() As String = {"Detective Pikachu", "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Alolan Rattata", "Raticate", "Alolan Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Alolan Raichu", "Sandshrew", "Alolan Sandshrew", "Sandslash", "Alolan Sandslash", "Nidoran", "Nidorina", "Nidoqueen", "Nidoran_m", "Nidorino", "Nidoking", "Clefairy", "Clefable", "Vulpix", "Alolan Vulpix", "Ninetales", "Alolan Ninetales", "Jigglypuff", "Wigglytuff", "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth", "Diglett", "Alolan Diglett", "Dugtrio", "Alolan Dugtrio", "Meowth", "Alolan Meowth", "Persian", "Alolan Persian", "Psyduck", "Golduck", "Mankey", "Primeape", "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Alolan Geodude", "Graveler", "Alolan Graveler", "Golem", "Alolan Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro", "Magnemite", "Magneton", "Farfetchd", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Alolan Grimer", "Muk", "Alolan Muk", "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno", "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Alolan Exeggutor", "Cubone", "Marowak", "Alolan Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu", "Starmie", "Mr. Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew", "Chikorita", "Bayleef", "Meganium", "Cyndaquil", "Quilava", "Typhlosion", "Totodile", "Croconaw", "Feraligatr", "Sentret", "Furret", "Hoothoot", "Noctowl", "Ledyba", "Ledian", "Spinarak", "Ariados", "Crobat", "Chinchou", "Lanturn", "Pichu", "Cleffa", "Igglybuff", "Togepi", "Togetic", "Natu", "Xatu", "Mareep", "Flaaffy", "Ampharos", "Bellossom", "Marill", "Azumarill", "Sudowoodo", "Politoed", "Hoppip", "Skiploom", "Jumpluff", "Aipom", "Sunkern", "Sunflora", "Yanma", "Wooper", "Quagsire", "Espeon", "Umbreon", "Murkrow", "Slowking", "Misdreavus", "Unown", "Wobbuffet", "Girafarig", "Pineco", "Forretress", "Dunsparce", "Gligar", "Steelix", "Snubbull", "Granbull", "Qwilfish", "Scizor", "Shuckle", "Heracross", "Sneasel", "Teddiursa", "Ursaring", "Slugma", "Magcargo", "Swinub", "Piloswine", "Corsola", "Remoraid", "Octillery", "Delibird", "Mantine", "Skarmory", "Houndour", "Houndoom", "Kingdra", "Phanpy", "Donphan", "Porygon2", "Stantler", "Smeargle", "Tyrogue", "Hitmontop", "Smoochum", "Elekid", "Magby", "Miltank", "Blissey", "Raikou", "Entei", "Suicune", "Larvitar", "Pupitar", "Tyranitar", "Lugia", "Ho-Oh", "Celebi", "Treecko", "Grovyle", "Sceptile", "Torchic", "Combusken", "Blaziken", "Mudkip", "Marshtomp", "Swampert", "Poochyena", "Mightyena", "Zigzagoon", "Linoone", "Wurmple", "Silcoon", "Beautifly", "Cascoon", "Dustox", "Lotad", "Lombre", "Ludicolo", "Seedot", "Nuzleaf", "Shiftry", "Taillow", "Swellow", "Wingull", "Pelipper", "Ralts", "Kirlia", "Gardevoir", "Surskit", "Masquerain", "Shroomish", "Breloom", "Slakoth", "Vigoroth", "Slaking", "Nincada", "Ninjask", "Shedinja", "Whismur", "Loudred", "Exploud", "Makuhita", "Hariyama", "Azurill", "Nosepass", "Skitty", "Delcatty", "Sableye", "Mawile", "Aron", "Lairon", "Aggron", "Meditite", "Medicham", "Electrike", "Manectric", "Plusle", "Minun", "Volbeat", "Illumise", "Roselia", "Gulpin", "Swalot", "Carvanha", "Sharpedo", "Wailmer", "Wailord", "Numel", "Camerupt", "Torkoal", "Spoink", "Grumpig", "Spinda", "Trapinch", "Vibrava", "Flygon", "Cacnea", "Cacturne", "Swablu", "Altaria", "Zangoose", "Seviper", "Lunatone", "Solrock", "Barboach", "Whiscash", "Corphish", "Crawdaunt", "Baltoy", "Claydol", "Lileep", "Cradily", "Anorith", "Armaldo", "Feebas", "Milotic", "Castform", "Kecleon", "Shuppet", "Banette", "Duskull", "Dusclops", "Tropius", "Chimecho", "Absol", "Wynaut", "Snorunt", "Glalie", "Spheal", "Sealeo", "Walrein", "Clamperl", "Huntail", "Gorebyss", "Relicanth", "Luvdisc", "Bagon", "Shelgon", "Salamence", "Beldum", "Metang", "Metagross", "Regirock", "Regice", "Registeel", "Latias", "Latios", "Kyogre", "Groudon", "Rayquaza", "Jirachi", "Deoxys", "Turtwig", "Grotle", "Torterra", "Chimchar", "Monferno", "Infernape", "Piplup", "Prinplup", "Empoleon", "Starly", "Staravia", "Staraptor", "Bidoof", "Bibarel", "Kricketot", "Kricketune", "Shinx", "Luxio", "Luxray", "Budew", "Roserade", "Cranidos", "Rampardos", "Shieldon", "Bastiodon", "Burmy", "Wormadam", "Mothim", "Combee", "Vespiquen", "Pachirisu", "Buizel", "Floatzel", "Cherubi", "Cherrim", "Shellos", "Gastrodon", "Ambipom", "Drifloon", "Drifblim", "Buneary", "Lopunny", "Mismagius", "Honchkrow", "Glameow", "Purugly", "Chingling", "Stunky", "Skuntank", "Bronzor", "Bronzong", "Bonsly", "Mime Jr.", "Happiny", "Chatot", "Spiritomb", "Gible", "Gabite", "Garchomp", "Munchlax", "Riolu", "Lucario", "Hippopotas", "Hippowdon", "Skorupi", "Drapion", "Croagunk", "Toxicroak", "Carnivine", "Finneon", "Lumineon", "Mantyke", "Snover", "Abomasnow", "Weavile", "Magnezone", "Lickilicky", "Rhyperior", "Tangrowth", "Electivire", "Magmortar", "Togekiss", "Yanmega", "Leafeon", "Glaceon", "Gliscor", "Mamoswine", "Porygon-Z", "Gallade", "Probopass", "Dusknoir", "Froslass", "Rotom", "Uxie", "Mesprit", "Azelf", "Dialga", "Palkia", "Heatran", "Regigigas", "Giratina", "Cresselia", "Phione", "Manaphy", "Darkrai", "Shaymin", "Arceus", "Victini", "Snivy", "Servine", "Serperior", "Tepig", "Pignite", "Emboar", "Oshawott", "Dewott", "Samurott", "Patrat", "Watchog", "Lillipup", "Herdier", "Stoutland", "Purrloin", "Liepard", "Pansage", "Simisage", "Pansear", "Simisear", "Panpour", "Simipour", "Munna", "Musharna", "Pidove", "Tranquill", "Unfezant", "Blitzle", "Zebstrika", "Roggenrola", "Boldore", "Gigalith", "Woobat", "Swoobat", "Drilbur", "Excadrill", "Audino", "Timburr", "Gurdurr", "Conkeldurr", "Tympole", "Palpitoad", "Seismitoad", "Throh", "Sawk", "Sewaddle", "Swadloon", "Leavanny", "Venipede", "Whirlipede", "Scolipede", "Cottonee", "Whimsicott", "Petilil", "Lilligant", "Basculin", "Sandile", "Krokorok", "Krookodile", "Darumaka", "Darmanitan", "Maractus", "Dwebble", "Crustle", "Scraggy", "Scrafty", "Sigilyph", "Yamask", "Cofagrigus", "Tirtouga", "Carracosta", "Archen", "Archeops", "Trubbish", "Garbodor", "Zorua", "Zoroark", "Minccino", "Cinccino", "Gothita", "Gothorita", "Gothitelle", "Solosis", "Duosion", "Reuniclus", "Ducklett", "Swanna", "Vanillite", "Vanillish", "Vanilluxe", "Deerling", "Sawsbuck", "Emolga", "Karrablast", "Escavalier", "Foongus", "Amoonguss", "Frillish", "Jellicent", "Alomomola", "Joltik", "Galvantula", "Ferroseed", "Ferrothorn", "Klink", "Klang", "Klinklang", "Tynamo", "Eelektrik", "Eelektross", "Elgyem", "Beheeyem", "Litwick", "Lampent", "Chandelure", "Axew", "Fraxure", "Haxorus", "Cubchoo", "Beartic", "Cryogonal", "Shelmet", "Accelgor", "Stunfisk", "Mienfoo", "Mienshao", "Druddigon", "Golett", "Golurk", "Pawniard", "Bisharp", "Bouffalant", "Rufflet", "Braviary", "Vullaby", "Mandibuzz", "Heatmor", "Durant", "Deino", "Zweilous", "Hydreigon", "Larvesta", "Volcarona", "Cobalion", "Terrakion", "Virizion", "Tornadus", "Thundurus", "Reshiram", "Zekrom", "Landorus", "Kyurem", "Keldeo", "Meloetta", "Genesect", "Chespin", "Quilladin", "Chesnaught", "Fennekin", "Braixen", "Delphox", "Froakie", "Frogadier", "Greninja", "Bunnelby", "Diggersby", "Fletchling", "Fletchinder", "Talonflame", "Scatterbug", "Spewpa", "Vivillon", "Litleo", "Pyroar", "Flabebe", "Floette", "Florges", "Skiddo", "Gogoat", "Pancham", "Pangoro", "Furfrou", "Espurr", "Meowstic", "Honedge", "Doublade", "Aegislash", "Spritzee", "Aromatisse", "Swirlix", "Slurpuff", "Inkay", "Malamar", "Binacle", "Barbaracle", "Skrelp", "Dragalge", "Clauncher", "Clawitzer", "Helioptile", "Heliolisk", "Tyrunt", "Tyrantrum", "Amaura", "Aurorus", "Sylveon", "Hawlucha", "Dedenne", "Carbink", "Goomy", "Sliggoo", "Goodra", "Klefki", "Phantump", "Trevenant", "Pumpkaboo", "Gourgeist", "Bergmite", "Avalugg", "Noibat", "Noivern", "Xerneas", "Yveltal", "Zygarde", "Diancie", "Hoopa", "Volcanion", "Rowlet", "Dartrix", "Decidueye", "Litten", "Torracat", "Incineroar", "Popplio", "Brionne", "Primarina", "Pikipek", "Trumbeak", "Toucannon", "Yungoos", "Gumshoos", "Grubbin", "Charjabug", "Vikavolt", "Crabrawler", "Crabominable", "Oricorio", "Cutiefly", "Ribombee", "Rockruff", "Lycanroc", "Wishiwashi", "Mareanie", "Toxapex", "Mudbray", "Mudsdale", "Dewpider", "Araquanid", "Fomantis", "Lurantis", "Morelull", "Shiinotic", "Salandit", "Salazzle", "Stufful", "Bewear", "Bounsweet", "Steenee", "Tsareena", "Comfey", "Oranguru", "Passimian", "Wimpod", "Golisopod", "Sandygast", "Palossand", "Pyukumuku", "Type: Null", "Silvally", "Minior", "Komala", "Turtonator", "Togedemaru", "Mimikyu", "Bruxish", "Drampa", "Dhelmise", "Jangmo-o", "Hakamo-o", "Kommo-o", "Tapu Koko", "Tapu Lele", "Tapu Bulu", "Tapu Fini", "Cosmog", "Cosmoem", "Solgaleo", "Lunala", "Nihilego", "Buzzwole", "Pheromosa", "Xurkitree", "Celesteela", "Kartana", "Guzzlord", "Necrozma", "Magearna", "Marshadow", "Poipole", "Naganadel", "Stakataka", "Blacephalon", "Zeraora", "Meltan", "Melmetal"}
    Dim mythics() As String = {"Arceus", "Darkrai", "Deoxys", "Celebi", "Shaymin", "Mew", "Jerachi", "Hoopa", "Victini", "Phione", "Magearna", "Volcanion", "Diancie", "Genesect", "Keldeo", "Meloetta", "Manaphy", "Magearna", "Marshadow", "Zeraora", "Meltan", "Melmetal"}
    Dim alolans() As String = {"Alolan Rattata", "Alolan Raticate", " Alolan Raichu", "Alolan Sandshrew", "Alolan Sandslash", "Alolan Vulpix", " Alolan Ninetales", "Alolan Diglett", "Alolan Dugtrio", "Alolan Meowth", "Alolan Persian", "Alolan Geodude", "Alolan Graveler", "Alolan Golem", "Alolan Grimer", "Alolan Muk", "Alolan Exeggutor", "Alolan Marowak"}
    Dim ultrabeasts() As String = {"Nihilego", "Buzzwole", "Pheromosa", "Xurkitree", "Celesteela", "Kartana", "Guzzlord", "Poipole", "Naganadel", "Stakataka", "Blacephalon"}
    Dim legends() As String = {"Articuno", "Zapdos", "Moltres", "Mewtwo", "Raikou", "Entei", "Suicune", "Ho-Oh", "Lugia", "Regirock", "Regice", "Registeel", "Regigigas", "Latios", "Latias", "Kyogre", "Groudon", "Rayquaza", "Dialga", "Palkia", "Heatran", "Giratina", "Cresselia", "Uxie", "Azelf", "Cobalion", "Terrakion", "Virizion", "Tornadus", "Thundrus", "Reshiram", "Zekrom", "Landorus", "Kyurem", "Xeneas", "Yveltal", "Zygarde", "Type: Null", "Silvally", "Cosmog", "Cosmoem", "Solgaleo", "Lunala", "Necrozma"}
    Dim events() As String = {"Detective Pikachu"}
    Dim MainTimer As New System.Timers.Timer
    Dim token As String
    Dim channel As String
    Dim level As Integer = 0
    Dim evo As Integer = 0
    Dim catchCount As Integer = 0
    Dim seenCount As Integer = 0
    Dim lPKMN As Integer = 0
    Dim mPKMN As Integer = 0
    Dim ubPKMN As Integer = 0

    Sub Main(args As String())
        MainAsync.GetAwaiter.GetResult()
    End Sub

    Dim _client As DiscordSocketClient = New DiscordSocketClient

    Sub New()
        token = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "/token.txt")
        channel = My.Computer.FileSystem.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "/channel.txt")

        AddHandler _client.Log, AddressOf LogAsync
        AddHandler _client.Ready, AddressOf ReadAsync
        AddHandler _client.MessageReceived, AddressOf MessageReceivedAsync
        AddHandler MainTimer.Elapsed, AddressOf tick
    End Sub

    <STAThread()>
    Public Async Function MainAsync() As Task
        Threading.Thread.CurrentThread.SetApartmentState(Threading.ApartmentState.STA)
        Await _client.LoginAsync(TokenType.Bot, token)
        Await _client.StartAsync
        Await Task.Delay(-1)
    End Function

    Private Function LogAsync(ByVal log As LogMessage) As Task
        If log.ToString.Contains("Ready") Then
            Colorize("Ready")
            Colorize(" ____ ____ ____ ____ ____ ____ _________ ____ ____ ____ ____")
            Colorize("||G |||o |||t |||c |||h |||a |||       |||v |||2 |||. |||1 ||")
            Colorize("||__|||__|||__|||__|||__|||__|||_______|||__|||__|||__|||__||")
            Colorize("|/__\|/__\|/__\|/__\|/__\|/__\|/_______\|/__\|/__\|/__\|/__\|")

            MainTimer.Interval = 1500
            MainTimer.Start()
        ElseIf log.ToString.Contains("unhandled") Then
            ' dont log
        ElseIf log.Message IsNot Nothing Then
            Colorize(log.Message)
        End If
        Return Task.CompletedTask
    End Function

    Private Function ReadAsync() As Task
        Return Task.CompletedTask
    End Function

    Private Async Function MessageReceivedAsync(ByVal message As SocketMessage) As Task
        If message.Author.ToString.Contains("Pokécord") Then

            If message.Content.Contains("You caught a") Then
                Colorize("[CATCH]     " & message.Content.ToString)

                catchCount += 1

                Dim ratio As Double = Math.Round(catchCount / seenCount * 100)

                Colorize("[INFO]      Stats: Seen: " & seenCount & " | Caught: " & catchCount & " | Catch Rate: " & ratio & "% | Levels Gained: " & level & " | Evolutions Gained: " & evo)
                Colorize("[INFO]      Legendary:   " & lPKMN & " | Mythic: " & mPKMN & " | Ultra Beast: " & ubPKMN)

                If message.Content.Contains("Added to Pokédex") Then
                    FindDiscordWindow(channel)
                    SendKeys.SendWait("p!pokedex claim all")
                    SendKeys.SendWait("{Enter}")

                    Colorize("[INFO]      New pokemon added to pokedex. Claiming the balance.")
                End If

                MainTimer.Start()

            End If

            If message.Embeds(0).Title.Contains("appeared!") Then
                MainTimer.Stop()

                Colorize("[ENCOUNTER] A pokemon appeared!")
                seenCount += 1

                Dim url As String = message.Embeds(0).Image.ToString
                Dim tClient As WebClient = New WebClient
                Dim timage As Bitmap = Bitmap.FromStream(New IO.MemoryStream(tClient.DownloadData(url)))

                Dim pokemon As String = ConvertImageToBase64(timage)

                Try
                    For i = 0 To (pkmn.Count - 1)
                        Dim pkmnName As String = pkmn(i).ToString
                        If pkmnName = "Type: Null" Then
                            pkmnName = "TypeNull"
                        End If

                        Dim di As New DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory & "\poke\")
                        Dim pokemonName As String
                        For Each fi As FileInfo In di.GetFiles()
                            If File.ReadAllText(fi.FullName).Contains(pokemon) Then
                                Try
                                    ' Find discord and send catch
                                    FindDiscordWindow(channel)
                                    pokemonName = fi.Name
                                    pokemonName = pokemonName.Remove(pokemonName.Length - 4)
                                    If pokemonName = "Nidoran_m" Then pokemonName = "Nidoran"
                                    If legends.Contains(pokemonName) Then lPKMN += 1
                                    If mythics.Contains(pokemonName) Then mPKMN += 1
                                    If ultrabeasts.Contains(pokemonName) Then ubPKMN += 1
                                    SendKeys.SendWait("p!catch " & pokemonName)
                                    SendKeys.SendWait("{Enter}")
                                    Exit For
                                Catch ex As Exception
                                    ' Catch exception
                                    Console.WriteLine(ex.ToString)
                                End Try
                            End If
                        Next
                        Exit For
                    Next
                Catch ex As Exception
                    Console.WriteLine(ex.ToString)
                End Try
            ElseIf message.Content = "This is the wrong pokémon!" Then
                Colorize("[ERROR]     Wrong Pokemon...")
            ElseIf message.Embeds(0).Description.Contains("is now level") Then
                Colorize("[LEVEL]     " & message.Embeds(0).Description)
                level += 1
            End If

            If message.Embeds(0).Fields.Count <> 0 Then
                Colorize("[EVOLVE]    " & message.Embeds(0).Fields(0).Name.ToString)
                Colorize("[EVOLVE]    " & message.Embeds(0).Fields(0).Value.ToString)
                evo += 1
            End If
        End If

    End Function

    ''Convert the Image from Input to Base64 Encoded String
    Public Function ConvertImageToBase64(ImageInput As Drawing.Image) As String
        Using ms As New MemoryStream()
            ImageInput.Save(ms, ImageInput.RawFormat)
            Dim imageBytes As Byte() = ms.ToArray
            Dim base64String As String = Convert.ToBase64String(imageBytes)

            Return base64String
        End Using
    End Function

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

    Public Sub SpamChats()
        FindDiscordWindow(channel)

        If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\spamchat.txt") Then
            Dim ioFile As New StreamReader(System.AppDomain.CurrentDomain.BaseDirectory & "\spamchat.txt")
            Dim lines As New List(Of String)
            Dim rnd As New Random()
            Dim line As Integer

            While ioFile.Peek <> -1
                lines.Add(ioFile.ReadLine())
            End While

            line = GetRandom(0, lines.Count - 1)

            Windows.Forms.SendKeys.SendWait(lines(line).Trim())
            Windows.Forms.SendKeys.SendWait("{Enter}")
        Else
            Colorize("[ERROR]     Cannot locate spamchat.txt...")
        End If
    End Sub

    Private Sub tick(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        SpamChats()
    End Sub

    Public Sub Colorize(ByVal msg As String)
        Select Case True
            Case msg.Contains("ERROR")
                Console.ForegroundColor = ConsoleColor.DarkRed
                Console.WriteLine(msg)
                Console.ResetColor()
            Case msg.Contains("INFO")
                Console.ForegroundColor = ConsoleColor.DarkGray
                Console.WriteLine(msg)
                Console.ResetColor()
            Case msg.Contains("ENCOUNTER")
                Console.ForegroundColor = ConsoleColor.DarkMagenta
                Console.WriteLine(msg)
                Console.ResetColor()
            Case msg.Contains("LEVEL")
                Console.ForegroundColor = ConsoleColor.DarkYellow
                Console.WriteLine(msg)
                Console.ResetColor()
            Case msg.Contains("EVOLVE")
                Console.ForegroundColor = ConsoleColor.DarkCyan
                Console.WriteLine(msg)
                Console.ResetColor()
            Case msg.Contains("CATCH")
                Console.ForegroundColor = ConsoleColor.DarkGreen
                Console.WriteLine(msg)
                Console.ResetColor()
            Case Else
                Console.ForegroundColor = ConsoleColor.DarkGray
                Console.WriteLine(msg)
                Console.ResetColor()
        End Select
    End Sub

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
End Module
