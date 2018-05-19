Public Class FrmTabMovies
    Public Event MovieSaved(ByVal mediaId As String, ByVal mediaName As String)
    Private Event MovieSelected(ByVal mediaId As String, ByVal mediaName As String)

    '======== EVENTS ============================================================
    Private Sub FrmTabMovies_Load(sender As Object, e As EventArgs) Handles Me.Load
        MovieList.Columns.Add("Movie", 300, HorizontalAlignment.Left)
        MovieList.Columns.Add("ID", 0, HorizontalAlignment.Left)

        RefreshMovieList()
        ClearMovieDetail()
    End Sub
    
    Private Sub BtnAddGenre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddGenre.Click 
        RemoveHandler FrmMovieGenres.MovieGenresAdded, AddressOf _frmMovieGenres_MovieGenresAdded
        AddHandler FrmMovieGenres.MovieGenresAdded, AddressOf _frmMovieGenres_MovieGenresAdded

        FrmMovieGenres.Visible = True
        FrmMovieGenres.Focus()
    End Sub

    Private Sub BtnRemoveGenre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemoveGenre.Click 
        If MovieGenresList.SelectedIndex < 0 Then Return

        Dim genreId = LookUpGenre(MovieGenresList.Items(MovieGenresList.SelectedIndex).ToString)
        MovieGenresList.Items.RemoveAt(MovieGenresList.SelectedIndex)
    End Sub
    
    Private Sub MovieList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovieList.SelectedIndexChanged 
        ClearMovieDetail()

        Dim listView As ListView = DirectCast(sender, ListView)

        If listView.SelectedItems.Count <= 0 Then Return

        Dim movieId = listView.SelectedItems.Item(0).SubItems(1).Text
        Dim movieName = listView.SelectedItems.Item(0).SubItems(0).Text

        Dim selectArray(2)
        selectArray(0) = 16
        selectArray(1) = 24
        selectArray(2) = 20

        'Shoot it over to the ReadRecord sub, 
        'TODO - Enhancement: Return a proper custom type (Movie) - or could just reference Movie type from list rather than call DB again
        Dim returnArray() As String = DbReadRecord($"SELECT * FROM movie WHERE idMovie='{movieId}'", selectArray)
            
        'We only have 1 response, since it searches by ID. So, just break it into parts. 
        Dim returnArraySplit() As String = Split(returnArray(0), "~")

        Dim movieGenres As String = returnArraySplit(0)

        MovieLabel.Text = movieName
        MovieLocation.Text = returnArraySplit(1)

        If returnArraySplit(2) = "" Then
            cboMovieNetwork.SelectedIndex = -1
        Else
            cboMovieNetwork.Text = returnArraySplit(2)
        End If


        'TODO - Enahncement: Use list from cutom Movie type to define genres for movie
        'Loop through each Movie Genre, if there more than one.
        MovieGenresList.Items.Clear()
        If InStr(movieGenres, " / ") > 0 Then
            Dim movieGenresSplit() As String = Split(movieGenres, " / ")

            For x = 0 To UBound(movieGenresSplit)
                MovieGenresList.Items.Add(movieGenresSplit(x))
            Next
        ElseIf movieGenres <> "" Then
            MovieGenresList.Items.Add(movieGenres)
        End If

        If MovieLocation.TextLength >= 6 Then
            If MovieLocation.Text.Substring(0, 6) = "smb://" Then
                MovieLocation.Text = $"//{MovieLocation.Text.Substring(6)}"
            End If
        End If

        Dim movieLocationFolder = System.IO.Path.GetDirectoryName(MovieLocation.Text)
        
        If System.IO.File.Exists(movieLocationFolder & "\folder.jpg") Then
            MoviePicture.ImageLocation = $"{movieLocationFolder}\folder.jpg"
        Else
            MoviePicture.ImageLocation = Nothing
        End If

        BtnAddGenre.Enabled = True
        RaiseEvent MovieSelected(movieId, movieName)
    End Sub
    
    Private Sub BtnSaveMovie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveMovie.Click 
        If MovieList.SelectedItems.Count <= 0 Then Return

        Dim selectedMovie = MovieList.SelectedItems(0)
        Dim selectedMovieId As String = selectedMovie.SubItems(1).Text

        UpdateMovieNetwork(selectedMovieId)
        UpdateMovie(selectedMovieId)
        UpdateMovieGenres(selectedMovieId)
        
        RefreshMovieList()
        MovieList.Items(MovieList.FindItemWithText(selectedMovie.SubItems(0).Text).Index).Selected = True

        ' Fix any issues with shows and 's.
        Dim movieName As String = Replace(MovieLabel.Text, "'", "''")
        RaiseEvent MovieSaved(selectedMovieId, movieName)
    End Sub

    'TODO - Look at this and Refactor
    Private Sub BtnTempLocationBrowse_Click(sender As Object, e As EventArgs) Handles BtnTempLocationBrowse.Click
        If MovieList.SelectedItems.Count <= 0 Then Return

        Form1.RefreshAllStudios()
        Form8.Visible = True
        Form8.Focus()
    End Sub
    
    Private Sub MovieGenresList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MovieGenresList.SelectedIndexChanged
        If DirectCast(sender, ListBox).SelectedItem = "" Then
            BtnRemoveGenre.Enabled = False
        Else 
            BtnRemoveGenre.Enabled = True
        End If
    End Sub
    
    Private Sub FrmTabMovies_MovieSelected(mediaId As String, mediaName As String) Handles Me.MovieSelected
        cboMovieNetwork.Enabled = True
        MovieLocation.Enabled = True
        BtnAddGenre.Enabled = True
        BtnSaveMovie.Enabled = True
        BtnTempLocationBrowse.Enabled = True
    End Sub

    Private Sub _frmMovieGenres_MovieGenresAdded(ByVal genres As ListView.SelectedListViewItemCollection) 
        For Each element As ListViewItem In genres 
            AddGenreToMovie(element.SubItems(0).Text)
        Next 
    End Sub
    
    '======== SUBS ============================================================

    Private Sub AddGenreToMovie(ByVal genre As String) 
        Dim isInList As Boolean = False

        For Each element In MovieGenresList.Items
            If StrComp(element.ToString, genre) = 0 Then
                isInList = True
                Exit For
            End If
        Next

        If Not isInList Then
            MovieGenresList.Items.Add(genre)
        End If
    End Sub

    Private Sub ClearMovieDetail()
        MovieLabel.Text = ""
        cboMovieNetwork.SelectedValue = Nothing
        cboMovieNetwork.Enabled = False
        MovieLocation.Text = ""
        MovieLocation.Enabled = False
        MovieGenresList.Items.Clear()
        MoviePicture.ImageLocation = Nothing
        BtnAddGenre.Enabled = False
        BtnRemoveGenre.Enabled = False
        BtnSaveMovie.Enabled = False
        BtnTempLocationBrowse.Enabled = False
    End Sub

    Private Sub UpdateMovieNetwork(ByVal movieId As String) 
        'Grab the Network ID based on the name
        Dim networkId = LookUpNetwork(cboMovieNetwork.Text)

        DbExecute("DELETE FROM studio_link WHERE media_type = 'movie' AND media_id = '" & movieId & "'")
        DbExecute("INSERT INTO studio_link (studio_id, media_id, media_type) VALUES ('" & networkId & "', '" & movieId & "', 'movie')")
    End Sub

    Private Sub UpdateMovie(ByVal movieId As String) 
        'Convert show genres into the format ex:  genre1 / genre2 / etc.
        Dim movieGenres = ConvertGenres(MovieGenresList)
        Dim query = $"UPDATE movie SET c14 = '{movieGenres}', c18 ='{cboMovieNetwork.Text}' WHERE idMovie = '{movieId}'"
        DbExecute(query)
    End Sub

    Private Sub UpdateMovieGenres(ByVal movieId As String) 
        'Remove all genres from movie
        DbExecute($"DELETE FROM genre_link WHERE media_id = '{movieId}'")

        'add each one.  one by one.
        For genre = 0 To MovieGenresList.Items.Count - 1
            Dim genreId = LookUpGenre(MovieGenresList.Items(genre).ToString)
            DbExecute($"INSERT INTO genre_link (genre_id, media_id, media_type) VALUES ('{genreId}', '{movieId}', 'movie')")
        Next
    End Sub

    Private Sub RefreshMovieList()
        MovieList.Items.Clear()

        'Set an array with the columns you want returned
        Dim selectArray(1)
        selectArray(0) = 2
        selectArray(1) = 0

        'Shoot it over to the ReadRecord sub, 
        'TODO - Enhancement: Return a proper custom type (List of Movies)
        Dim returnArray() As String = DbReadRecord("SELECT * FROM movie ORDER BY c00", selectArray)

        'Now, read the output of the array.
        'Loop through each of the Array items.
        For x = 0 To returnArray.Count - 1
            'Split them by ~'s.  This is how we seperate the rows in the single-element.
            Dim str() As String = Split(returnArray(x), "~")

            'Now take that split string and make it an item.
            Dim itm = New ListViewItem(str)

            'Add the item to the TV show list.
            MovieList.Items.Add(itm)
        Next
    End Sub
End Class