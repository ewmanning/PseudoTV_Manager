﻿'Import the SQLite DLL file.
'C:\SQLite\THERE!

Imports System
Imports System.IO

Public Class Form1

    'C:\Users\Nate\AppData\Roaming\XBMC\userdata\addon_data\script.pseudotv\Settings2.xml

    'Add Movie support

    'Public VideoDatabaseLocation = "C:\Users\Nate\AppData\Roaming\XBMC\userdata\Database\MyVideos60.db"
    'Public PseudoTvSettingsLocation = "C:\Users\Nate\AppData\Roaming\XBMC\userdata\addon_data\script.pseudotv\settings2.xml"


    Public DatabaseType As Integer = 0
    Public MySQLConnectionString As String = ""
    'Public VideoDatabaseLocation As String = ""
    Public PseudoTvSettingsLocation As String = ""

    '===================================================================================================================
    
    Private WithEvents _frmTabNetworksStudios As New FrmTabNetworksStudios
    Private WithEvents _frmTabGenres As New FrmTabGenres
    Private WithEvents _frmTabTvShows As New FrmTabTvShows
    Private WithEvents _frmTabMovies As New FrmTabMovies

    'For sorting columns in listviews
    Private m_SortingColumn As ColumnHeader

    Private Sub _frmTabTvShows_TvShowSaved(ByVal tvShowId As String, ByVal tvShowName As String) Handles _frmTabTvShows.TvShowSaved
        Status.Text = $"Updated {tvShowName} Successfully"
    End Sub

    Private Sub _frmTabMovies_MovieSaved(movieId As String, movieName As String) Handles _frmTabMovies.MovieSaved
        Status.Text = $"Updated {movieName} Successfully"

        FrmTabNetworksStudios.RefreshNetworkListMovies()
    End Sub

    '===================================================================================================================
    
    Public Sub RefreshTVGuide()
        'Clear the TV name and the List items
        TVGuideShowName.Text = ""
        TVGuideList.Items.Clear()

        Dim FullFile As String

        Dim TotalChannels As Integer = 0

        'This will hold an array of our channel #s
        Dim ChannelArray() As String = Nothing
        Dim ChannelNum As Integer

        Dim FILE_LOCATION As String = PseudoTvSettingsLocation

        If System.IO.File.Exists(PseudoTvSettingsLocation) = True Then
            'Load everything into the FullFile string
            FullFile = ReadFile(PseudoTvSettingsLocation)

            Dim objReader As New System.IO.StreamReader(FILE_LOCATION)

            'Loop through each line individually, then add the channel # to an array
            Do While objReader.Peek() <> -1

                Dim SingleLine = objReader.ReadLine()

                If InStr(SingleLine, "_type" & Chr(34) & " value=") Then
                    Dim Part1 = Split(SingleLine, "_type")(0)
                    Dim Part2 = Split(Part1, "_")(1)


                    ReDim Preserve ChannelArray(ChannelNum)
                    ChannelNum = ChannelNum + 1
                    ChannelArray(UBound(ChannelArray)) = Part2

                End If

            Loop

            objReader.Close()

            For x = 0 To UBound(ChannelArray)

                Dim ChannelInfo() As String

                Dim ChannelRules As String = ""
                Dim ChannelRulesAdvanced As String = ""
                Dim ChannelRulesCount As String = ""
                Dim ChannelType As String = ""
                Dim ChannelTypeDetail As String = ""
                Dim ChannelTime As String = ""


                'Grab everything that says setting id = Channel #
                ChannelInfo = Split(FullFile, "<setting id=" & Chr(34) & "Channel_" & ChannelArray(x) & "_", , CompareMethod.Text)


                'Now loop through everything it returned.
                For y = 1 To ChannelInfo.Count - 1
                    Dim RuleType As String
                    Dim RuleValue As String

                    RuleType = Split(ChannelInfo(y), Chr(34))(0)

                    RuleValue = Split(ChannelInfo(y), "value=" & Chr(34))(1)
                    RuleValue = Split(RuleValue, Chr(34))(0)

                    If RuleType = "changed" Then

                    ElseIf RuleType = "rulecount" Then
                        ChannelRulesCount = RuleValue
                    ElseIf RuleType = "time" Then
                        ChannelTime = RuleValue
                    ElseIf RuleType = "type" Then
                        'Update the Channel type to the value of that.
                        ChannelType = RuleValue
                    ElseIf RuleType = "1" Then
                        'Gets more information on what type the channel is, playlist location/genre/etc.
                        ChannelTypeDetail = RuleValue
                    ElseIf InStr(RuleType, "rule", CompareMethod.Text) Then
                        'Okay, It's rule information.

                        'Get the rule number.
                        Dim RuleNumber As String
                        RuleNumber = Split(RuleType, "rule_")(1)
                        RuleNumber = Split(RuleNumber, "_")(0)




                        If InStr(RuleType, "opt", CompareMethod.Text) Then
                            'Okay, it's an actual option tied to another rule.

                            Dim OptNumber = Split(RuleType, "_opt_")(1)
                            RuleNumber = Split(RuleType, "_opt_")(0)
                            RuleNumber = Split(RuleNumber, "rule_")(1)

                            'MsgBox("Opt : " & RuleNumber & " | " & OptNumber & " | " & RuleValue)
                            'ChannelRulesAdvanced = ChannelRulesAdvanced & "~" & RuleNumber & "|" & OptNumber & "|" & RuleValue
                            'MsgBox(RuleNumber & " | " & OptNumber & " | " & RuleValue)

                            'Add this to the previous rule, remove the ending 
                            'Then add this rule as Rule#:RuleValue
                            ChannelRules = ChannelRules & "|" & OptNumber & "^" & RuleValue
                        Else
                            ChannelRules = ChannelRules & "~" & RuleNumber & "|" & RuleValue
                        End If
                    Else

                    End If

                    'End result for a basic option:  ~RuleNumber|RuleValue 
                    'End result for an advanced option:  ~RuleNumber|RuleValue|Rule1^Rule1Value|Rule2^Rule2Value



                Next

                Dim str(6) As String


                str(0) = ChannelArray(x)  'Channel #.
                str(1) = ChannelType
                str(2) = ChannelTypeDetail
                str(3) = ChannelTime
                str(4) = ChannelRules
                str(5) = ChannelRulesCount

                Dim itm As ListViewItem
                itm = New ListViewItem(str)
                'Add to list
                TVGuideList.Items.Add(itm)


            Next

        End If

        'Sort List
        TVGuideList.ListViewItemSorter = New clsListviewSorter(0, SortOrder.Ascending)
        ' Sort. 
        TVGuideList.Sort()
    End Sub

    

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TVGuideList.Columns.Add("Channel", 200, HorizontalAlignment.Left)
        TVGuideList.Columns.Add("Type", 0, HorizontalAlignment.Left)
        TVGuideList.Columns.Add("TypeDetail", 0, HorizontalAlignment.Left)
        TVGuideList.Columns.Add("Time", 0, HorizontalAlignment.Left)
        TVGuideList.Columns.Add("Rules", 0, HorizontalAlignment.Left)
        TVGuideList.Columns.Add("RuleCount", 0, HorizontalAlignment.Left)

        InterleavedList.Columns.Add("Chan", 50, HorizontalAlignment.Left)
        InterleavedList.Columns.Add("Min", 45, HorizontalAlignment.Left)
        InterleavedList.Columns.Add("Max", 45, HorizontalAlignment.Left)
        InterleavedList.Columns.Add("Epi", 45, HorizontalAlignment.Left)

        SchedulingList.Columns.Add("Chan", 53, HorizontalAlignment.Left)
        SchedulingList.Columns.Add("Days", 45, HorizontalAlignment.Left)
        SchedulingList.Columns.Add("Time", 45, HorizontalAlignment.Left)
        SchedulingList.Columns.Add("Epi", 45, HorizontalAlignment.Left)

        TVGuideSubMenu.Columns.Add("Shows / Movies", 300, HorizontalAlignment.Left)

        'Settings.txt location
        Dim SettingsFile As String = Application.StartupPath() & "\" & "Settings.txt"

        'See if there's already a text file in place, if so load it.
        If System.IO.File.Exists(SettingsFile) = True Then
            Dim FileLocations = ReadFile(SettingsFile)

            'Make sure there's the | symbol there so we can split it
            If InStr(FileLocations, " | ") Then
                FileLocations = Split(FileLocations, " | ")

                'Now count the split and make sure it has the proper amount.
                If UBound(FileLocations) = 2 Then

                    If FileLocations(0) = "0" Then
                        'This is for a standard SQLite Entry.
                        DatabaseType = 0
                        VideoDatabaseLocation = FileLocations(1)
                        PseudoTvSettingsLocation = FileLocations(2)
                    Else
                        DatabaseType = 1
                        MySQLConnectionString = FileLocations(1)
                        PseudoTvSettingsLocation = FileLocations(2)
                    End If
                End If


                RefreshALL()
                RefreshTVGuide()

            End If

        Else
            System.IO.File.Create(SettingsFile)
            MsgBox("Unable to locate the location of XBMC video library and PseudoTV's setting location.  Please enter them and save the changes.")
        End If

        'Tabs
        AddTab(_frmTabNetworksStudios, "NetworksStudios", "Networks / Studios")
        AddTab(_frmTabGenres, "Genres", "Genres")
        AddTab(_frmTabTvShows, "TvShows", "TV Shows")
        AddTab(_frmTabMovies, "Movies", "Movies")

    End Sub
    
    Private Sub AddTab(form As Form, tabName As String, tabText As String) 
        form.TopLevel = False
        form.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        form.Dock = DockStyle.Fill

        Dim tab As New TabPage
        tab.Name = tabName
        tab.Text = $"{tabText}"
        tab.Controls.Add(form)
        tab.AutoSize = True
        TabControl1.TabPages.Add(tab)
        form.Show()
    End Sub


    Public Sub RefreshAllGenres()
        Dim SavedText = Option2.Text
        Option2.Items.Clear()
        'Set an array with the columns you want returned
        Dim SelectArray(0)
        SelectArray(0) = 1

        'Shoot it over to the ReadRecord sub, 
        Dim ReturnArray() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM genre", SelectArray)

        'Now, read the output of the array.

        'Loop through each of the Array items.
        For x = 0 To ReturnArray.Count - 1
            Option2.Items.Add(ReturnArray(x))
        Next
        Option2.Sorted = True
        Option2.Text = SavedText
    End Sub

    Public Sub RefreshAllStudios()
        Dim SavedText = Option2.Text

        'Clear all
        Option2.Items.Clear()
        FrmTvStudios.ListBox1.Items.Clear()

        'TODO - Use Event
        'cboTvShowNetwork.Items.Clear()

        'TODO - Use Event
        'txtMovieNetwork.Items.Clear()
        FrmMovieNetworks.ListBox1.Items.Clear()

        'Set an array with the columns you want returned
        Dim SelectArray(0)
        SelectArray(0) = 1

        'Shoot it over to the ReadRecord sub, 
        Dim ReturnArray() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM studio", SelectArray)

        'Now, read the output of the array.

        'Loop through each of the Array items.
        For x = 0 To ReturnArray.Count - 1
            Option2.Items.Add(ReturnArray(x))
            FrmTvStudios.ListBox1.Items.Add(ReturnArray(x))
            
            'TODO - Use Event
            'cboTvShowNetwork.Items.Add(ReturnArray(x))

            'TODO - Use Event
            'txtMovieNetwork.Items.Add(ReturnArray(x))
            FrmMovieNetworks.ListBox1.Items.Add(ReturnArray(x))
        Next

        'Sort them all.
        Option2.Sorted = True
        FrmTvStudios.ListBox1.Sorted = True
        FrmMovieNetworks.ListBox1.Sorted = True
        
        'TODO - Use Event
        'cboTvShowNetwork.Sorted = True
        
        'TODO - Use Event
        'txtMovieNetwork.Sorted = True

        Option2.Text = SavedText

    End Sub

    

    



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        RefreshALL()
    End Sub

    Public Sub RefreshALL()
        If VideoDatabaseLocation <> "" Or MySQLConnectionString <> "" And PseudoTvSettingsLocation <> "" Then
            'TODO - Use Event
            'RefreshMovieList()

            'TODO - Use Event
            'RefreshTVShows()

            RefreshAllStudios()
            
            'TODO - Do not access directly. Use an event
            FrmTabNetworksStudios.RefreshNetworkList()
            FrmTabNetworksStudios.RefreshNetworkListMovies()

            'TODO - Do not access directly. Use an event
            FrmTabGenres.RefreshGenres()

            'TODO - Reset as part of event raised above
'            TxtShowName.Text = ""
'            txtShowLocation.Text = ""
'            TvShowPictureBox.ImageLocation = ""
        End If
    End Sub

    

    

    



    Public Sub RefreshTVGuideSublist(ByVal ListType As String, ByVal ListValue As String)
        TVGuideSubMenu.Items.Clear()

        Dim TVChannelTypeValue = ListValue

        If ListType = 0 Then
            'Playlist

            'Add Info for PlayList editing/loading.

        ElseIf ListType = 1 Then
            'This is a TV Network.

            'Make sure there's a value in this box.
            If TVChannelTypeValue <> "" Then
                Dim ChannelPreview(0)
                ChannelPreview(0) = 1

                Dim ReturnArray() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM tvshow WHERE c14='" & TVChannelTypeValue & "'", ChannelPreview)

                'Make sure the Array is not null.
                If ReturnArray Is Nothing Then
                Else
                    For x = 0 To ReturnArray.Count - 1
                        'Add each item it returns to the list.
                        TVGuideSubMenu.Items.Add(ReturnArray(x))
                    Next
                End If
            End If

        ElseIf ListType = 2 Then
            'Movie Studio

            'Make sure there's a value in this box.
            If TVChannelTypeValue <> "" Then
                Dim SelectArray(0)
                SelectArray(0) = 2


                'Now, gather a list of all the show IDs that match the genreID
                Dim ReturnArray() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM movie WHERE c18='" & TVChannelTypeValue & "'", SelectArray)

                'Now loop through each one individually.
                If ReturnArray Is Nothing Then
                Else
                    For x = 0 To ReturnArray.Count - 1
                        'Now add that name to the list.
                        TVGuideSubMenu.Items.Add(ReturnArray(x))
                    Next
                End If
            End If

        ElseIf ListType = 3 Then
            'TV Genre

            'Make sure there's a value in this box.
            If TVChannelTypeValue <> "" Then
                Dim SelectArray(0)
                SelectArray(0) = 1


                'Now, gather a list of all the show IDs that match the genreID
                Dim ReturnArray() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM genre_link WHERE media_type = 'tvshow' AND genre_id ='" & LookUpGenre(TVChannelTypeValue) & "'", SelectArray)

                'Now loop through each one individually.
                For x = 0 To ReturnArray.Count - 1
                    Dim ShowNameArray(0)
                    ShowNameArray(0) = 1

                    Dim ReturnArray2() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM tvshow WHERE idShow='" & ReturnArray(x) & "'", ShowNameArray)

                    'Now add that name to the list.
                    TVGuideSubMenu.Items.Add(ReturnArray2(0))
                Next
            End If

        ElseIf ListType = 4 Then
            'Movie Genre

            Dim SelectArrayMovies(0)
            SelectArrayMovies(0) = 1

            Dim ReturnArrayMovies() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM genre_link WHERE media_type = 'movie' AND genre_id ='" & LookUpGenre(TVChannelTypeValue) & "'", SelectArrayMovies)


            'Now loop through each one individually.
            If ReturnArrayMovies Is Nothing Then
            Else
                For x = 0 To UBound(ReturnArrayMovies)

                    Dim ShowArray(0)
                    ShowArray(0) = 2

                    Dim ReturnArray2() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM movie WHERE idMovie='" & ReturnArrayMovies(x) & "'", ShowArray)

                    'Now add that name to the list.
                    TVGuideSubMenu.Items.Add(ReturnArray2(0))
                Next
            End If
        ElseIf ListType = 5 Then
            'Mixed Genre

            'Make sure there's a value in this box.
            If TVChannelTypeValue <> "" Then
                Dim SelectArray(0)
                SelectArray(0) = 1


                'Now, gather a list of all the show IDs that match the genreID

                Dim ReturnArray() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM genre_link WHERE media_type = 'tvshow' AND genre_id ='" & LookUpGenre(TVChannelTypeValue) & "'", SelectArray)


                'Now loop through each one individually.
                If ReturnArray Is Nothing Then
                Else
                    For x = 0 To UBound(ReturnArray)
                        Dim ShowArray(0)
                        ShowArray(0) = 1

                        Dim ReturnArray2() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM tvshow WHERE idShow='" & ReturnArray(x) & "'", ShowArray)

                        'Now add that name to the list.
                        TVGuideSubMenu.Items.Add(ReturnArray2(0))
                    Next
                End If
                '------------------------------------
                'Repeat this step for the Movies now.

                Dim SelectArrayMovies(0)
                SelectArrayMovies(0) = 1

                Dim ReturnArrayMovies() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM genre_link WHERE media_type = 'movie' AND genre_id ='" & LookUpGenre(TVChannelTypeValue) & "'", SelectArrayMovies)


                'Now loop through each one individually.
                'Verify it's not NULL.
                If ReturnArrayMovies Is Nothing Then
                Else
                    For x = 0 To UBound(ReturnArrayMovies)
                        Dim ShowArray(0)
                        ShowArray(0) = 2

                        Dim ReturnArray2() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM movie WHERE idMovie='" & ReturnArrayMovies(x) & "'", ShowArray)

                        'Now add that name to the list.
                        TVGuideSubMenu.Items.Add(ReturnArray2(0))
                    Next
                End If


            End If

        ElseIf ListType = 6 Then
            'TV Show
        ElseIf ListType = 7 Then
            'Directory

        End If

        'Now loop through all the shows listed to NOT show, compare them to the list of shows and make any of them have a red background if they match.
        For x = 0 To NotShows.Items.Count - 1
            Dim NotShow = NotShows.Items(x).ToString

            For y = 0 To TVGuideSubMenu.Items.Count - 1
                If StrComp(NotShow, TVGuideSubMenu.Items(y).SubItems(0).Text, CompareMethod.Text) = 0 Then
                    TVGuideSubMenu.Items(y).BackColor = Color.Red
                End If
            Next

        Next
        TVGuideSubMenu.Sort()
    End Sub

    Private Sub TVGuideList_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles TVGuideList.ColumnClick
        ' Get the new sorting column. 
        Dim new_sorting_column As ColumnHeader = TVGuideList.Columns(e.Column)
        ' Figure out the new sorting order. 
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending. 
            sort_order = SortOrder.Ascending
        Else ' See if this is the same column. 
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order. 
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending. 
                sort_order = SortOrder.Ascending
            End If
            ' Remove the old sort indicator. 
            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If
        ' Display the new sort order. 
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If
        ' Create a comparer. 
        TVGuideList.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort. 
        TVGuideList.Sort()
    End Sub


    Private Sub TVGuideList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TVGuideList.SelectedIndexChanged
        If TVGuideList.SelectedIndices.Count > 0 Then



            'Reset the checked options.
            ChkLogo.Checked = False
            chkDontPlayChannel.Checked = False
            ChkRandom.Checked = False
            ChkRealTime.Checked = False
            ChkResume.Checked = False
            ChkIceLibrary.Checked = False
            ChkUnwatched.Checked = False
            ChkWatched.Checked = False
            ChkPause.Checked = False
            ChkPlayInOrder.Checked = False
            ResetDays.Clear()
            ChannelName.Clear()

            'Clear other form items.
            TVGuideSubMenu.Items.Clear()
            Dim PlayListNumber = TVGuideList.Items(TVGuideList.SelectedIndices(0)).SubItems(1).Text
            Option2.Items.Clear()
            InterleavedList.Items.Clear()
            SchedulingList.Items.Clear()
            NotShows.Items.Clear()

            'Display the Channel Number.
            TVGuideShowName.Text = "Channel " & TVGuideList.SelectedItems(0).SubItems(0).Text

            If PlayListNumber <> 9999 Then

                PlayListType.SelectedIndex = PlayListNumber

                Dim NoOption As Boolean = False

                Dim TVChannelTypeValue = TVGuideList.Items(TVGuideList.SelectedIndices(0)).SubItems(2).Text

                If PlayListNumber = 0 Then
                    'Playlist
                    NoOption = True

                    'Add Info for PlayList editing/loading.

                ElseIf PlayListNumber = 1 Then
                    'This is a TV Network.

                    'TODO - Do not access directly. Use events.
                    For x = 0 To FrmTabNetworksStudios.NetworkList.Items.Count - 1
                        Option2.Items.Add(FrmTabNetworksStudios.NetworkList.Items(x).SubItems(0).Text)
                    Next

                    'Make sure there's a value in this box.
                    If TVChannelTypeValue <> "" Then
                        RefreshTVGuideSublist(PlayListNumber, TVChannelTypeValue)
                    End If

                ElseIf PlayListNumber = 2 Then
                    'Movie Studio
                    RefreshAllStudios()

                ElseIf PlayListNumber = 3 Then
                    'TODO - Do not access directly. Use an event
                    'TV Genre
                    For x = 0 To FrmTabGenres.GenresList.Items.Count - 1
                        Option2.Items.Add(FrmTabGenres.GenresList.Items(x).SubItems(0).Text)
                    Next

                ElseIf PlayListNumber = 4 Then
                    'Movie Genre
                    RefreshAllGenres()

                ElseIf PlayListNumber = 5 Then
                    'Mixed Genre
                    RefreshAllGenres()

                    'TODO Need access to TVShowList?
                ElseIf PlayListNumber = 6 Then
                    'TODO - Do not access directly. Use an event
                    'TV Show
                    For x = 0 To FrmTabTvShows.TVShowList.Items.Count - 1
                        Option2.Items.Add(FrmTabTvShows.TVShowList.Items(x).SubItems(0).Text)
                    Next
                ElseIf PlayListNumber = 7 Then
                    'Directory
                    NoOption = True

                End If

                'Now, we loop through the advanced rules to populate those properly.

                'break this array into all the rules for this channel.
                Dim AllRules = Split(TVGuideList.Items(TVGuideList.SelectedIndices(0)).SubItems(4).Text, "~")

                'Loop through all of them.
                'But, only the ones it "says" it has.

                Dim RuleCount As Integer


                If TVGuideList.Items(TVGuideList.SelectedIndices(0)).SubItems(5).Text <> "" Then
                    RuleCount = TVGuideList.Items(TVGuideList.SelectedIndices(0)).SubItems(5).Text
                End If


                For y = 1 To RuleCount
                    'For y = 1 To UBound(AllRules)
                    Dim RuleSettings() = Split(AllRules(y), "|")

                    'Rule #1, #2, etc.
                    Dim RuleNum = RuleSettings(0)
                    'Value, most of the time this is the only thing we need.
                    Dim RuleValue = RuleSettings(1)


                    If RuleValue = 5 Then
                        chkDontPlayChannel.Checked = True
                    ElseIf RuleValue = 10 Then
                        ChkRandom.Checked = True
                    ElseIf RuleValue = 7 Then
                        ChkRealTime.Checked = True
                    ElseIf RuleValue = 9 Then
                        ChkResume.Checked = True
                    ElseIf RuleValue = 11 Then
                        ChkUnwatched.Checked = True
                    ElseIf RuleValue = 4 Then
                        ChkWatched.Checked = True
                    ElseIf RuleValue = 8 Then
                        ChkPause.Checked = True
                    ElseIf RuleValue = 12 Then
                        ChkPlayInOrder.Checked = True
                    Else

                        'Okay, so it's not something requiring a single option.

                        'Now loop through all the sub-options of each rule.
                        Dim SubOptions(4) As String

                        For z = 2 To UBound(RuleSettings)
                            Dim OptionNum = Split(RuleSettings(z), "^")(0)
                            Dim OptionValue = Split(RuleSettings(z), "^")(1)


                            If RuleValue = 13 Then
                                'MsgBox(RuleValue)
                                ResetDays.Text = OptionValue
                                Exit For
                            ElseIf RuleValue = 1 Then
                                ChannelName.Text = OptionValue
                                Exit For
                            ElseIf RuleValue = 15 And OptionValue = "Yes" Then
                                ChkLogo.Checked = True
                                Exit For
                            ElseIf RuleValue = 14 And OptionValue = "Yes" Then
                                ChkIceLibrary.Checked = True
                                Exit For
                            ElseIf RuleValue = 2 Then
                                NotShows.Items.Add(OptionValue)
                                Exit For
                            ElseIf RuleValue = 6 Then
                                'Add this option to a sub-item array to add later to the
                                'Object at the end
                                SubOptions(OptionNum - 1) = OptionValue

                                If OptionNum = 4 Then
                                    'last option.
                                    'create + insert object
                                    Dim itm As ListViewItem
                                    itm = New ListViewItem(SubOptions)
                                    'Add to list
                                    InterleavedList.Items.Add(itm)
                                    'Remove it from the loop.  We only need 4 options here.
                                    Exit For
                                Else

                                End If
                            ElseIf RuleValue = 3 Then
                                'Add this option to a sub-item array to add later to the
                                'Object at the end
                                SubOptions(OptionNum - 1) = OptionValue
                                If OptionNum = 4 Then
                                    'last option.
                                    'create + insert object
                                    Dim itm As ListViewItem
                                    itm = New ListViewItem(SubOptions)
                                    'Add to list

                                    SchedulingList.Items.Add(itm)
                                    Exit For
                                Else

                                End If
                            End If

                        Next
                    End If
                Next


                RefreshTVGuideSublist(PlayListNumber, TVChannelTypeValue)

                If NoOption = True Then
                    PlayListLocation.Text = TVGuideList.Items(TVGuideList.SelectedIndices(0)).SubItems(2).Text
                Else
                    Option2.Text = TVGuideList.Items(TVGuideList.SelectedIndices(0)).SubItems(2).Text
                End If
                TVGuideSubMenu.Sort()

            End If
        End If
    End Sub


    Private Sub Option2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Option2.SelectedIndexChanged
        If PlayListType.SelectedIndex >= 0 And Option2.Text <> "" Then
            RefreshTVGuideSublist(PlayListType.SelectedIndex, Option2.Text)
        End If
    End Sub

    Private Sub PlayListType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayListType.SelectedIndexChanged
        'Clear the Sub-menu
        TVGuideSubMenu.Items.Clear()
        PlayListLocation.Text = ""

        If PlayListType.SelectedIndex = 0 Or PlayListType.SelectedIndex = 7 Then
            Button5.Visible = True
            Label6.Visible = True
            PlayListLocation.Visible = True
            Option2.Visible = False
        Else
            Button5.Visible = False
            Label6.Visible = False
            PlayListLocation.Visible = False
            Option2.Visible = True
        End If

        Option2.Items.Clear()
        Option2.Text = ""

        If PlayListType.SelectedIndex = 0 Then
            For x = 0 To FrmTabNetworksStudios.NetworkList.Items.Count - 1
                Option2.Items.Add(FrmTabNetworksStudios.NetworkList.Items(x).SubItems(0).Text)
            Next
        ElseIf PlayListType.SelectedIndex = 1 Then
            For x = 0 To FrmTabNetworksStudios.NetworkList.Items.Count - 1
                Option2.Items.Add(FrmTabNetworksStudios.NetworkList.Items(x).SubItems(0).Text)
            Next
        ElseIf PlayListType.SelectedIndex = 2 Then
            RefreshAllStudios()
        ElseIf PlayListType.SelectedIndex = 3 Then
            'TODO -Do not access directly. Use an event
            For x = 0 To FrmTabGenres.GenresList.Items.Count - 1
                Option2.Items.Add(FrmTabGenres.GenresList.Items(x).SubItems(0).Text)
            Next
        ElseIf PlayListType.SelectedIndex = 4 Then
            RefreshAllGenres()
        ElseIf PlayListType.SelectedIndex = 5 Then
            RefreshAllGenres()
            'TODO Need access to TVShowList?
'        ElseIf PlayListType.SelectedIndex = 6 Then
'            For x = 0 To TVShowList.Items.Count - 1
'                Option2.Items.Add(TVShowList.Items(x).SubItems(0).Text)
'            Next
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click


        If PlayListType.Text = "Directory" Then
            FolderBrowserDialog1.ShowDialog()
            PlayListLocation.Text = FolderBrowserDialog1.SelectedPath
        ElseIf PlayListType.Text = "Playlist" Then
            OpenFileDialog1.ShowDialog()

            Dim Filename = OpenFileDialog1.FileName
            Dim FilenameSplit = Split(Filename, "\")

            PlayListLocation.Text = "special://profile/playlists/video/" & FilenameSplit(UBound(FilenameSplit))


        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Loop through config file.
        'Grab all comments MINUS the ones for selected #
        'Append this & our new content to the file.

        If TVGuideList.SelectedItems.Count > 0 Then

            Dim FILE_NAME As String = PseudoTvSettingsLocation
            Dim TextFile As String = ""

            Dim ChannelNum = TVGuideList.Items(TVGuideList.SelectedIndices(0)).SubItems(0).Text


            'Loop through config file.
            'Grab all comments MINUS the ones for selected #
            If System.IO.File.Exists(FILE_NAME) = True Then

                Dim objReader As New System.IO.StreamReader(FILE_NAME)

                Do While objReader.Peek() <> -1

                    Dim SingleLine = objReader.ReadLine()

                    If InStr(SingleLine, "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_") Or InStr(SingleLine, "</settings", CompareMethod.Text) Then
                    Else
                        TextFile = TextFile & SingleLine & vbNewLine
                    End If

                Loop

                objReader.Close()
            Else

                MsgBox("File Does Not Exist")

            End If

            'Now, append info for this channel we're editing.

            Dim AppendInfo As String = ""
            Dim rulecount = 0

            'Show the Logo is checked.
            '<setting id="Channel_1_rule_1_id" value="15" />
            If ChkLogo.Checked = True Then
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "15" & Chr(34) & " />"
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_opt_1" & Chr(34) & " value=" & Chr(34) & "Yes" & Chr(34) & " />"
            End If

            'Don't show this channel is checked
            '<setting id="Channel_1_rule_1_id" value="5" />
            If chkDontPlayChannel.Checked = True Then
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "5" & Chr(34) & " />"
            End If

            'Play Random Mode
            '<setting id="Channel_1_rule_1_id" value="10" />
            If ChkRandom.Checked = True Then
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "10" & Chr(34) & " />"
            End If

            'Play Real-Time Mode
            '<setting id="Channel_1_rule_1_id" value="7" />
            If ChkRealTime.Checked = True Then
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "7" & Chr(34) & " />"
            End If

            'Play Resume Mode
            '<setting id="Channel_1_rule_1_id" value="9" />
            If ChkResume.Checked = True Then
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "9" & Chr(34) & " />"
            End If

            'Play Only Unwatched Films
            '<setting id="Channel_1_rule_1_id" value="11" />
            If ChkUnwatched.Checked = True Then
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "11" & Chr(34) & " />"
            End If

            'Only play Watched
            '<setting id="Channel_1_rule_1_id" value="4" />
            If ChkWatched.Checked = True Then
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "4" & Chr(34) & " />"
            End If

            'IceLibrary Support?
            '<setting id="Channel_1_rule_1_id" value="14" />
            If ChkIceLibrary.Checked = True Then
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "14" & Chr(34) & " />"
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_opt_1" & Chr(34) & " value=" & Chr(34) & "Yes" & Chr(34) & " />"
            End If

            'Pause when not watching
            '<setting id="Channel_1_rule_1_id" value="8" />
            If ChkPause.Checked = True Then
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "8" & Chr(34) & " />"
            End If

            'Play shows in order
            '<setting id="Channel_1_rule_1_id" value="12" />
            If ChkPlayInOrder.Checked = True Then
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "12" & Chr(34) & " />"
            End If

            'Theres a # in the reset day amount
            '<setting id="Channel_1_rule_1_id" value="13" />
            '<setting id="Channel_1_rule_1_opt_1" value=ResetDays />

            If IsNumeric(ResetDays.Text) Then
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "13" & Chr(34) & " />"
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_opt_1" & Chr(34) & " value=" & Chr(34) & ResetDays.Text & Chr(34) & " />"
            End If

            'Theres a channel name
            '<setting id="Channel_1_rule_1_id" value="1" />
            '<setting id="Channel_1_rule_1_opt_1" value=ChannelName />
            If ChannelName.Text <> "" Then
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "1" & Chr(34) & " />"
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_opt_1" & Chr(34) & " value=" & Chr(34) & ChannelName.Text & Chr(34) & " />"
            End If

            'Loop through shows not to play
            '<setting id="Channel_1_rule_1_id" value="2" />
            '<setting id="Channel_1_rule_1_opt_1" value=ShowName />
            For x = 0 To NotShows.Items.Count - 1
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "2" & Chr(34) & " />"
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_opt_1" & Chr(34) & " value=" & Chr(34) & NotShows.Items(x) & Chr(34) & " />"
            Next

            'Interleaved loop
            For x = 0 To InterleavedList.Items.Count - 1
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "6" & Chr(34) & " />"
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_opt_1" & Chr(34) & " value=" & Chr(34) & InterleavedList.Items(x).SubItems(0).Text & Chr(34) & " />"
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_opt_2" & Chr(34) & " value=" & Chr(34) & InterleavedList.Items(x).SubItems(1).Text & Chr(34) & " />"
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_opt_3" & Chr(34) & " value=" & Chr(34) & InterleavedList.Items(x).SubItems(2).Text & Chr(34) & " />"
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_opt_4" & Chr(34) & " value=" & Chr(34) & InterleavedList.Items(x).SubItems(3).Text & Chr(34) & " />"
            Next

            For x = 0 To SchedulingList.Items.Count - 1
                rulecount = rulecount + 1
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_id" & Chr(34) & " value=" & Chr(34) & "3" & Chr(34) & " />"
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_opt_1" & Chr(34) & " value=" & Chr(34) & SchedulingList.Items(x).SubItems(0).Text & Chr(34) & " />"
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_opt_2" & Chr(34) & " value=" & Chr(34) & SchedulingList.Items(x).SubItems(1).Text & Chr(34) & " />"
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_opt_3" & Chr(34) & " value=" & Chr(34) & SchedulingList.Items(x).SubItems(2).Text & Chr(34) & " />"
                AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rule_" & rulecount & "_opt_4" & Chr(34) & " value=" & Chr(34) & SchedulingList.Items(x).SubItems(3).Text & Chr(34) & " />"
            Next



            'Update it has been changed to flag it?
            '<setting id="Channel_1_changed" value="True" />
            AppendInfo = AppendInfo & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_changed" & Chr(34) & " value=" & Chr(34) & "True" & Chr(34) & " />"

            'Add type of channel to the top.
            Dim TopAppend
            TopAppend = vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_type" & Chr(34) & " value=" & Chr(34) & PlayListType.SelectedIndex & Chr(34) & " />"

            If PlayListType.SelectedIndex = 0 Or PlayListType.SelectedIndex = 7 Then
                TopAppend = TopAppend & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_1" & Chr(34) & " value=" & Chr(34) & PlayListLocation.Text & Chr(34) & " />"
            Else
                TopAppend = TopAppend & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_1" & Chr(34) & " value=" & Chr(34) & Option2.Text & Chr(34) & " />"
            End If

            'Also append the Rulecount to the top, just underneath the channel type & 2nd value
            TopAppend = TopAppend & vbCrLf & vbTab & "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_rulecount" & Chr(34) & " value=" & Chr(34) & rulecount & Chr(34) & " />"

            AppendInfo = TopAppend & AppendInfo

            'Combine the original text, plus the edited channel at the bottom, followed by ending the settings.
            TextFile = TextFile & AppendInfo & vbCrLf & "</settings>"

            SaveFile(PseudoTvSettingsLocation, TextFile)

            'RefreshALL()
            Dim returnindex = TVGuideList.SelectedIndices(0)
            RefreshTVGuide()
            TVGuideList.Items(returnindex).Selected = True
        End If
    End Sub

    

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If InterleavedList.SelectedItems.Count > 0 Then
            InterleavedList.Items(InterleavedList.SelectedIndices(0)).Remove()
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If SchedulingList.SelectedItems.Count > 0 Then
            SchedulingList.Items(SchedulingList.SelectedIndices(0)).Remove()
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Form4.Visible = True
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim Response = InputBox("Enter TV Show's Name", "TV Show Name")

        If Response <> "" Then
            NotShows.Items.Add(Response)
        End If

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If NotShows.SelectedItems.Count > 0 Then
            NotShows.Items.RemoveAt(NotShows.SelectedIndex)
        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim NewItem(5) As String

        NewItem(0) = InputBox("Enter Channel Number", "Enter Channel Number")
        NewItem(1) = 1
        NewItem(2) = Nothing
        NewItem(3) = Nothing
        NewItem(4) = Nothing
        NewItem(5) = Nothing

        Dim itm As ListViewItem
        itm = New ListViewItem(NewItem)

        Dim InList As Boolean = False

        If IsNumeric(NewItem(0)) Then
            If NewItem(0) > 0 And NewItem(0) <= 999 Then
                For x = 0 To TVGuideList.Items.Count - 1
                    If TVGuideList.Items(x).SubItems(0).Text = NewItem(0) Then
                        MsgBox("You already have a channel " & NewItem(0))
                        InList = True
                        Exit For
                    End If
                Next
            Else
                MsgBox("Sorry, the channel has to be 1 - 999)")
                InList = True
            End If
        End If

        If InList = False And IsNumeric(NewItem(0)) Then
            TVGuideList.Items.Add(itm)

            'Now make that the selected item.
            For x = 0 To TVGuideList.Items.Count - 1
                If TVGuideList.Items(x).SubItems(0).Text = NewItem(0) Then

                    TVGuideList.Items(x).Selected = True
                ElseIf TVGuideList.Items(x).Selected = True Then
                    TVGuideList.Items(x).Selected = False
                End If
            Next
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click

        If TVGuideList.Items.Count <> 1 Then

            'Loop through config file.
            'Grab all comments MINUS the ones for selected #
            'Append this & our new content to the file.

            Dim FILE_NAME As String = PseudoTvSettingsLocation
            Dim TextFile As String = ""

            Dim ChannelNum = TVGuideList.Items(TVGuideList.SelectedIndices(0)).SubItems(0).Text


            'Loop through config file.
            'Grab all comments MINUS the ones for selected #
            If System.IO.File.Exists(FILE_NAME) = True Then

                Dim objReader As New System.IO.StreamReader(FILE_NAME)

                Do While objReader.Peek() <> -1

                    Dim SingleLine = objReader.ReadLine()

                    If InStr(SingleLine, "<setting id=" & Chr(34) & "Channel_" & ChannelNum & "_") Or InStr(SingleLine, "</settings", CompareMethod.Text) Then
                    Else
                        TextFile = TextFile & SingleLine & vbNewLine
                    End If

                Loop

                objReader.Close()
            Else

                MsgBox("File Does Not Exist")

            End If

            SaveFile(PseudoTvSettingsLocation, TextFile)

            RefreshTVGuide()

            TVGuideList.SelectedItems.Clear()

            'Clear everything on the form.

            'Reset the checked options.
            ChkLogo.Checked = False
            chkDontPlayChannel.Checked = False
            ChkRandom.Checked = False
            ChkRealTime.Checked = False
            ChkResume.Checked = False
            ChkIceLibrary.Checked = False
            ChkUnwatched.Checked = False
            ChkWatched.Checked = False
            ChkPause.Checked = False
            ChkPlayInOrder.Checked = False
            ResetDays.Clear()
            ChannelName.Clear()

            'Clear other form items.
            TVGuideSubMenu.Items.Clear()
            Option2.Items.Clear()
            InterleavedList.Items.Clear()
            SchedulingList.Items.Clear()
            NotShows.Items.Clear()

        Else
            MsgBox("You must have at least one channel")
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Form5.Visible = True
    End Sub

    Private Sub AaaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AaaToolStripMenuItem.Click
        Form6.Visible = True
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub DontShowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DontShowToolStripMenuItem.Click
        If TVGuideSubMenu.SelectedItems.Count > 0 Then
            NotShows.Items.Add(TVGuideSubMenu.Items(TVGuideSubMenu.SelectedIndices(0)).SubItems(0).Text)
            TVGuideSubMenu.Items(TVGuideSubMenu.SelectedIndices(0)).BackColor = Color.Red
        End If
    End Sub

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    
    
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        LookUpGenre("aaccc")
    End Sub


End Class
