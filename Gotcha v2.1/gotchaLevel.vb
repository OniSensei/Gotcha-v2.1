Imports System.Windows.Forms
Imports Nini.Config

Module gotchaLevel
    ' Load levels.ini
    Dim iniLeveler As New IniConfigSource(Application.StartupPath & "/config/levels.ini")
    Dim levelGrind As Boolean = iniLeveler.Configs("Leveler").Get("AutoLevel")
    Dim levelQueue As String = iniLeveler.Configs("Leveler").Get("LevelQueue")
    Dim levelCap As Integer = iniLeveler.Configs("Leveler").Get("LevelCap")
    Dim levelStats As Boolean = iniLeveler.Configs("Stats").Get("Visible")
    Dim levelTotal As Boolean = iniLeveler.Configs("Stats").Get("Totals")
    Dim levelQueueList As String() = levelQueue.Split(New Char() {","c})
    Dim lstLevelQueue As List(Of String) = New List(Of String)(levelQueueList)

    Public Sub levelFound(ByVal msgDescription As String, ByVal embedValue As String, ByVal embedName As String)
        Try
            ' Update console and level count
            Colorize("[LEVEL]     " & msgDescription)
            level += 1
            levelPK += 1

            iniCounts.Configs("Levels").Set("Level", levelPK)

            iniCounts.Save()

            ' Pokemon is max level
            If msgDescription.Contains(levelCap) Then
                ' Pokemon is max level, lets switch it
                If levelGrind = True Then
                    botRunning = False
                    MainTimer.Stop()
                    If levelQueue = "" Then
                        FindDiscordWindow(channel, clientype) ' find discord
                        Threading.Thread.Sleep(spamInterval) ' Delay
                        SendKeys.SendWait(pokePrefix & "select latest") ' Switch pokemon to latest caught
                        SendKeys.SendWait("{Enter}") ' Send command
                    Else
                        ' que
                        FindDiscordWindow(channel, clientype) ' find discord
                        Threading.Thread.Sleep(spamInterval) ' Delay
                        SendKeys.SendWait(pokePrefix & "select " & lstLevelQueue(0).ToString) ' Switch pokemon to next in queue
                        SendKeys.SendWait("{Enter}") ' Send command

                        ' Remove from queue
                        lstLevelQueue.RemoveAt(0)

                        ' Update settings.ini
                        Dim newQueue As String = String.Join(",", lstLevelQueue)
                        iniLeveler.Configs("Leveler").Set("LevelQueue", newQueue)
                        iniLeveler.Save()

                        ' Add any additions from the ini
                        levelQueue = iniLeveler.Configs("Leveler").Get("LevelQueue")
                        levelQueueList = levelQueue.Split(New Char() {","c})
                        lstLevelQueue = New List(Of String)(levelQueueList)
                    End If
                    botRunning = True
                    MainTimer.Start()
                    Colorize("[LEVEL]     Your Pokémon has reached max level. Switching selected Pokémon...")
                End If
            End If

            If levelStats = True Then
                If levelTotal = True Then
                    If xpOn = True Then
                        Colorize("[STAT]      Levels Gained: " & level & " [" & levelPK & "] | Evolutions Gained: " & evo & " [" & evoPK & "] | [XP Boost ON]")
                    Else
                        Colorize("[STAT]      Levels Gained: " & level & " [" & levelPK & "] | Evolutions Gained: " & evo & " [" & evoPK & "] | [XP Boost OFF]")
                    End If
                Else
                    If xpOn = True Then
                        Colorize("[STAT]      Levels Gained: " & level & " | Evolutions Gained: " & evo & " | [XP Boost ON]")
                    Else
                        Colorize("[STAT]      Levels Gained: " & level & " | Evolutions Gained: " & evo & " | [XP Boost OFF]")
                    End If
                End If
            End If

            ' Evolution
            If embedValue.Contains("evolved") Then
                If autoSpam = True Then
                    MainTimer.Stop() ' stop spammer
                End If
                ' Update console and evo count
                Colorize("[EVOLVE]    " & embedName)
                Colorize("[EVOLVE]    " & embedValue)
                evo += 1
                evoPK += 1

                iniCounts.Configs("Levels").Set("Evolution", evoPK)

                iniCounts.Save()

                If levelStats = True Then
                    If levelTotal = True Then
                        Colorize("[STAT]      Levels Gained: " & level & " [" & levelPK & "] | Evolutions Gained: " & evo & " [" & evoPK & "]")
                    Else
                        Colorize("[STAT]      Levels Gained: " & level & " | Evolutions Gained: " & evo)
                    End If
                End If
                If autoSpam = True Then
                    MainTimer.Start() ' stop spammer
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
End Module
