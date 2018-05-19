Public Class FrmTabTvShows
    Public Event TvShowGenresAdded(ByVal genres As ListView.SelectedListViewItemCollection)
    Public Event TvShowGenresRemoved(ByVal genres As ListView.SelectedListViewItemCollection)

    Public Event TvShowSaved(ByVal tvShowId As String, ByVal tvShowName As String)

    '''''' EVENTS

    Private Sub FrmTabTvShows_Load(sender As Object, e As EventArgs) Handles Me.Load
        TVShowList.Columns.Add("Show", 100, HorizontalAlignment.Left)
        TVShowList.Columns.Add("Network", 100, HorizontalAlignment.Left)
        TVShowList.Columns.Add("ID", 0, HorizontalAlignment.Left)
    End Sub

    Private Sub BtnAddTvShowGenre_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddTvShowGenre.Click 
        If TVShowList.SelectedIndices.Count <= 0 Then Return

        FrmTvGenres.Visible = True
        FrmTvGenres.Focus()
    End Sub

    Private Sub BtnDeleteTvShowGenre_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteTvShowGenre.Click 
        If ListTVGenres.SelectedIndex < 0 Then Return

        'Grab the 3rd column from the TVShowList, which is the TVShowID
        Dim genreId = LookUpGenre(ListTVGenres.Items(ListTVGenres.SelectedIndex).ToString)

        'Remove from the GUI list
        ListTVGenres.Items.RemoveAt(ListTVGenres.SelectedIndex)

        'Save the TvShow with the new genres
        SaveTVShow_Click(Nothing, Nothing)

        RaiseEvent TvShowGenresRemoved(Nothing)
    End Sub

    Private Sub BtnNetworkBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNetworkBrowse.Click 
        If TVShowList.SelectedItems.Count <= 0 Then Return

        'TODO - Should be done in actual form3 not here
        'RefreshAllStudios()

        Form3.Visible = True
        Form3.Focus()
    End Sub

    Private Sub SaveTVShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveTVShow.Click 
        If TVShowList.SelectedItems.Count <= 0 Then Return

        DbExecute($"DELETE FROM studio_link WHERE media_type='tvshow' AND studio_id = '{TVShowLabel.Text}'")

        'Grab the Network ID based on the name
        Dim networkId = LookUpNetwork(txtShowNetwork.Text)
        DbExecute($"INSERT INTO studio_link (studio_id, media_id, media_type) VALUES ('{networkId}', '{TVShowLabel.Text}', 'tvshow')")
        
        ' Fix any issues with shows and 's.
        Dim tvShowName As String = Replace(TxtShowName.Text, "'", "''")

        'Convert show genres into the format ex:  genre1 / genre2 / etc.
        Dim showGenres = ConvertGenres(ListTVGenres)

        DbExecute($"UPDATE tvshow SET c00 = '{tvShowName}', c08 = '{showGenres}', c14 ='{txtShowNetwork.Text}' WHERE idShow = '{TVShowLabel.Text}'")
        
        'Remove all genres from tv show
        DbExecute($"DELETE FROM genre_link WHERE media_id = '{TVShowLabel.Text}'")

        'add each one.  one by one.
        For x = 0 To ListTVGenres.Items.Count - 1
            Dim genreId = LookUpGenre(ListTVGenres.Items(x).ToString)
            DbExecute($"INSERT INTO genre_link (genre_id, media_id, media_type) VALUES ('{genreId}', '{TVShowLabel.Text}', 'tvshow')")
        Next

        'Now update the tv show table
        Dim savedName = txtShowNetwork.Text

        'Refresh Things

        'TODO - Use Event
        'RefreshNetworkList()
        'TODO - Use Event
        'RefreshGenres()

        'Reset the text
        txtShowNetwork.Text = SavedName

        Dim returnindex = TVShowList.SelectedIndices(0)

        'TODO - Use Event
        'RefreshALL()

        TVShowList.Items(returnindex).Selected = True

        RaiseEvent TvShowSaved(TVShowLabel.Text, TxtShowName.Text)
    End Sub


    Private Sub TVShowList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        If TVShowList.SelectedItems.Count > 0 Then

            Dim listItem As ListViewItem
            listItem = TVShowList.SelectedItems.Item(0)

            Dim tvShowId = listItem.SubItems(2).Text
            TVShowLabel.Text = tvShowId

            Dim selectArray(3)
            selectArray(0) = 1
            selectArray(1) = 9
            selectArray(2) = 15
            selectArray(3) = 17

            'Shoot it over to the ReadRecord sub, 
            Dim returnArray() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM tvshow WHERE idShow='" & tvShowId & "'", selectArray)

            Dim returnArraySplit() As String

            'We only have 1 response, since it searches by ID. So, just break it into parts. 
            returnArraySplit = Split(returnArray(0), "~")

            TxtShowName.Text = returnArraySplit(0)

            Dim tvGenres As String = returnArraySplit(1)
            If returnArraySplit(2) = "" Then
                txtShowNetwork.SelectedIndex = -1
            Else
                txtShowNetwork.Text = returnArraySplit(2)
            End If

            txtShowLocation.Text = returnArraySplit(3)

            'Loop through each TV Genre, if there more than one.
            ListTVGenres.Items.Clear()
            If InStr(tvGenres, " / ") > 0 Then
                Dim tvGenresSplit() As String = Split(tvGenres, " / ")

                For x = 0 To UBound(tvGenresSplit)
                    ListTVGenres.Items.Add(tvGenresSplit(x))
                Next
            ElseIf tvGenres <> "" Then
                ListTVGenres.Items.Add(tvGenres)
            End If


            If txtShowLocation.TextLength >= 6 Then
                If txtShowLocation.Text.Substring(0, 6) = "smb://" Then
                    txtShowLocation.Text = "//" & txtShowLocation.Text.Substring(6)
                End If
            End If

            If IO.File.Exists(txtShowLocation.Text & "poster.jpg") Then
                TVShowPictureBox.ImageLocation = txtShowLocation.Text & "poster.jpg"
            ElseIf IO.File.Exists(txtShowLocation.Text & "folder.jpg") Then
                TVShowPictureBox.ImageLocation = txtShowLocation.Text & "folder.jpg"
            Else
                TVShowPictureBox.ImageLocation = Nothing
            End If
        End If
    End Sub

    '''''' SUBS
    
    Public Sub RefreshTvShows()
        TVShowList.Items.Clear()

        'Set an array with the columns you want returned
        Dim selectArray(2)
        selectArray(0) = 1
        selectArray(1) = 15
        selectArray(2) = 0

        'Shoot it over to the ReadRecord sub, 
        Dim returnArray() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM tvshow ORDER BY c00", selectArray)

        'Now, read the output of the array.
        'Loop through each of the Array items.
        For x = 0 To returnArray.Count - 1

            'Split them by ~'s.  This is how we seperate the rows in the single-element.
            Dim str() As String = Split(returnArray(x), "~")

            'Now take that split string and make it an item.
            Dim itm As ListViewItem
            itm = New ListViewItem(str)

            'Add the item to the TV show list.
            TVShowList.Items.Add(itm)
        Next
    End Sub

End Class