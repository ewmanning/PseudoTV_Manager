Public Class FrmTabTvShows
    Public Event TvShowSaved(ByVal mediaId As String, ByVal mediaName As String)
    Private Event TvShowSelected(ByVal mediaId As String, ByVal mediaName As String)

    '======== EVENTS ============================================================

    Private Sub FrmTabTvShows_Load(sender As Object, e As EventArgs) Handles Me.Load
        TVShowList.Columns.Add("Show", 100, HorizontalAlignment.Left)
        TVShowList.Columns.Add("Network", 100, HorizontalAlignment.Left)
        TVShowList.Columns.Add("ID", 0, HorizontalAlignment.Left)

        RefreshTvShowList()
        RefreshStudioList()
        ClearTvShowDetail()
    End Sub

    Private Sub BtnAddGenre_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddTvShowGenre.Click 
        RemoveHandler FrmTvGenres.TvShowGenresAdded, AddressOf _frmTvShowGenres_TvShowGenresAdded
        AddHandler FrmTvGenres.TvShowGenresAdded, AddressOf _frmTvShowGenres_TvShowGenresAdded
        
        FrmTvGenres.Visible = True
        FrmTvGenres.Focus()
    End Sub

    Private Sub BtnRemoveGenre_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemoveTvShowGenre.Click 
        If TvShowGenresList.SelectedIndex < 0 Then Return

        TvShowGenresList.Items.RemoveAt(TvShowGenresList.SelectedIndex)
    End Sub

    Private Sub TVShowList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TVShowList.SelectedIndexChanged
        ClearTvShowDetail()

        Dim listView As ListView = DirectCast(sender, ListView)
        If listView.SelectedItems.Count <= 0 Then Return
        
        Dim tvShowId = listView.SelectedItems.Item(0).SubItems(2).Text
        Dim tvShowName = listView.SelectedItems.Item(0).SubItems(0).Text

        Dim selectArray(3)
        selectArray(0) = 0  ' tv show name
        selectArray(1) = 1  ' tv show genres
        selectArray(2) = 2  ' tv show networks
        selectArray(3) = 3  ' tv show location
        
        'Shoot it over to the ReadRecord sub, 
        Dim returnArray() As String = DbReadRecord($"select c00, c08, c14, strPath from tvshow_view where idShow = {tvShowId}", selectArray)

        'We only have 1 response, since it searches by ID. So, just break it into parts. 
        Dim returnArraySplit() As String = Split(returnArray(0), "~")

        If returnArraySplit(2) = "" Then
            cboTvShowNetwork.SelectedIndex = -1
        Else
            cboTvShowNetwork.SelectedIndex = cboTvShowNetwork.FindString(returnArraySplit(2))
        End If

        TxtShowName.Text = returnArraySplit(0)
        txtShowLocation.Text = returnArraySplit(3)

        'Loop through each TV Genre, if there more than one.
        Dim tvGenres As String = returnArraySplit(1)
        TvShowGenresList.Items.Clear()
        If InStr(tvGenres, " / ") > 0 Then
            Dim tvGenresSplit() As String = Split(tvGenres, " / ")

            For x = 0 To UBound(tvGenresSplit)
                TvShowGenresList.Items.Add(tvGenresSplit(x))
            Next
        ElseIf tvGenres <> "" Then
            TvShowGenresList.Items.Add(tvGenres)
        End If
        
        If txtShowLocation.TextLength >= 6 Then
            If txtShowLocation.Text.Substring(0, 6) = "smb://" Then
                txtShowLocation.Text = $"//{txtShowLocation.Text.Substring(6)}"
            End If
        End If

        Dim tvShowLocationFolder = System.IO.Path.GetDirectoryName(txtShowLocation.Text)

        If System.IO.File.Exists(tvShowLocationFolder & "\poster.jpg") Then
            TvShowPictureBox.ImageLocation = $"{txtShowLocation.Text}\poster.jpg"
        ElseIf System.IO.File.Exists(tvShowLocationFolder & "\folder.jpg") Then
            TvShowPictureBox.ImageLocation = $"{txtShowLocation.Text}\folder.jpg"
        Else
            TvShowPictureBox.ImageLocation = Nothing
        End If

        BtnAddTvShowGenre.Enabled = True
        RaiseEvent TvShowSelected(tvShowId, tvShowName)
    End Sub

    Private Sub SaveTVShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveTVShow.Click 
        If TVShowList.SelectedItems.Count <= 0 Then Return

        Dim selectedTvShow = TVShowList.SelectedItems(0)
        Dim selectedTvShowId As String = selectedTvShow.SubItems(2).Text

        ' Fix any issues with shows and 's.
        Dim selectedTvShowName As String = Replace(selectedTvShow.Text, "'", "''")
        
        UpdateTvShowStudio(selectedTvShowId)
        UpdateTvShow(selectedTvShowId, selectedTvShowName)
        UpdateTvShowGenres(selectedTvShowId)

        RefreshTvShowList()
        TVShowList.Items(TVShowList.FindItemWithText(selectedTvShow.SubItems(0).Text).Index).Selected = True

        RaiseEvent TvShowSaved(selectedTvShowId, selectedTvShowName)
    End Sub

    Private Sub BtnNetworkBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNetworkBrowse.Click 
        If TVShowList.SelectedItems.Count <= 0 Then Return

        FrmTvStudios.Visible = True
        FrmTvStudios.Focus()
    End Sub

    Private Sub TvShowGenresList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TvShowGenresList.SelectedIndexChanged
        If DirectCast(sender, ListBox).SelectedItem = "" Then
            BtnRemoveTvShowGenre.Enabled = False
        Else 
            BtnRemoveTvShowGenre.Enabled = True
        End If
    End Sub
    
    Private Sub FrmTabTvShows_TvShowSelected(mediaId As String, mediaName As String) Handles Me.TvShowSelected
        cboTvShowNetwork.Enabled = True
        btnAddTvShowGenre.Enabled = True
        SaveTVShow.Enabled = True
        BtnNetworkBrowse.Enabled = True
    End Sub

    Private Sub _frmTvShowGenres_TvShowGenresAdded(ByVal genres As ListView.SelectedListViewItemCollection) 
        For Each element As ListViewItem In genres 
            AddGenreToTvShow(element.SubItems(0).Text)
        Next 
    End Sub

    '======== SUBS ============================================================

    Private Sub AddGenreToTvShow(ByVal genre As String) 
        Dim isInList As Boolean = False

        For Each element In TvShowGenresList.Items
            If StrComp(element.ToString, genre) = 0 Then
                isInList = True
                Exit For
            End If
        Next

        If Not isInList Then
            TvShowGenresList.Items.Add(genre)
        End If
    End Sub

    Private Sub ClearTvShowDetail()
        TxtShowName.Text = ""
        cboTvShowNetwork.SelectedValue = Nothing
        cboTvShowNetwork.Enabled = False
        txtShowLocation.Text = ""
        txtShowLocation.Enabled = False
        TvShowGenresList.Items.Clear()
        TvShowPictureBox.ImageLocation = Nothing
        btnAddTvShowGenre.Enabled = False
        btnRemoveTvShowGenre.Enabled = False
        BtnNetworkBrowse.Enabled = False
        SaveTVShow.Enabled = False
    End Sub

    Private Sub UpdateTvShowStudio(ByVal tvShowId As String)
        'Grab the Network ID based on the name
        Dim networkId = LookUpNetwork(cboTvShowNetwork.Text)

        DbExecute($"DELETE FROM studio_link WHERE media_type='tvshow' AND media_id = '{tvShowId}'")
        DbExecute($"INSERT INTO studio_link (studio_id, media_id, media_type) VALUES ('{networkId}', '{tvShowId}', 'tvshow')")
    End Sub

    Private Sub UpdateTvShow(ByVal tvShowId As String, ByVal tvShowName As String)
        'Convert show genres into the format ex:  genre1 / genre2 / etc.
        Dim showGenres = ConvertGenres(TvShowGenresList)

        DbExecute($"UPDATE tvshow SET c00 = '{tvShowName}', c08 = '{showGenres}', c14 ='{cboTvShowNetwork.Text}' WHERE idShow = '{tvShowId}'")
    End Sub

    Private Sub UpdateTvShowGenres(ByVal tvShowId As String)
        'Remove all genres from tv show
        DbExecute($"DELETE FROM genre_link WHERE media_id = '{tvShowId}'")

        'add each one.  one by one.
        For x = 0 To TvShowGenresList.Items.Count - 1
            Dim genreId = LookUpGenre(TvShowGenresList.Items(x).ToString)
            DbExecute($"INSERT INTO genre_link (genre_id, media_id, media_type) VALUES ('{genreId}', '{tvShowId}', 'tvshow')")
        Next
    End Sub
    
    Private Sub RefreshTvShowList()
        TVShowList.Items.Clear()

        'Set an array with the columns you want returned
        Dim selectArray(2)
        selectArray(0) = 1
        selectArray(1) = 15
        selectArray(2) = 0

        'Shoot it over to the ReadRecord sub, 
        Dim returnArray() As String = DbReadRecord("SELECT * FROM tvshow ORDER BY c00", selectArray)

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

    Private Sub RefreshStudioList()
        cboTvShowNetwork.Items.Clear()

        Dim selectArray(0)
        selectArray(0) = 1 'name

        Dim returnArray() As String = DbReadRecord("SELECT * FROM studio ORDER BY name", selectArray)

        'Now, read the output of the array.
        'Loop through each of the Array items.
        For index = 0 To returnArray.Count - 1
            'Add the item to the combo.
            cboTvShowNetwork.Items.Add(returnArray(index))
        Next

    End Sub
End Class