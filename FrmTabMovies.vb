Public Class FrmTabMovies
    
    Private Sub FrmTabMovies_Load(sender As Object, e As EventArgs) Handles Me.Load
        MovieList.Columns.Add("Movie", 300, HorizontalAlignment.Left)
        MovieList.Columns.Add("ID", 0, HorizontalAlignment.Left)

        RefreshMovieList()
    End Sub


    Private Sub RefreshMovieList()
        MovieList.Items.Clear()

        'Set an array with the columns you want returned
        Dim selectArray(1)
        selectArray(0) = 2
        selectArray(1) = 0

        'Shoot it over to the ReadRecord sub, 
        Dim returnArray() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM movie ORDER BY c00", selectArray)

        'Now, read the output of the array.
        'Loop through each of the Array items.
        For x = 0 To returnArray.Count - 1
            'Split them by ~'s.  This is how we seperate the rows in the single-element.
            Dim str() As String = Split(returnArray(x), "~")

            'Now take that split string and make it an item.
            Dim itm As ListViewItem
            itm = New ListViewItem(str)

            'Add the item to the TV show list.
            MovieList.Items.Add(itm)
        Next
    End Sub

    Private Sub MovieList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovieList.SelectedIndexChanged 
        If MovieList.SelectedItems.Count > 0 Then
            Dim listItem As ListViewItem
            listItem = MovieList.SelectedItems.Item(0)

            Dim movieId = listItem.SubItems(1).Text
            Dim movieName = listItem.SubItems(0).Text

            Dim selectArray(2)
            selectArray(0) = 16
            selectArray(1) = 24
            selectArray(2) = 20

            'Shoot it over to the ReadRecord sub, 
            Dim returnArray() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM movie WHERE idMovie='" & movieId & "'", selectArray)
            
            'We only have 1 response, since it searches by ID. So, just break it into parts. 
            Dim returnArraySplit() As String = Split(returnArray(0), "~")

            Dim movieGenres As String = returnArraySplit(0)

            MovieLabel.Text = movieName
            MovieLocation.Text = returnArraySplit(1)

            If returnArraySplit(2) = "" Then
                txtMovieNetwork.SelectedIndex = -1
            Else
                txtMovieNetwork.Text = returnArraySplit(2)
            End If


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

            If System.IO.File.Exists(MovieLocation.Text & "folder.jpg") Then
                MoviePicture.ImageLocation = $"{MovieLocation.Text}folder.jpg"
            Else
                MoviePicture.ImageLocation = Nothing
            End If
        End If
    End Sub

    Private Sub BtnDeleteGenre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteGenre.Click 
        If MovieGenresList.SelectedIndex >= 0 Then
            'Grab the 3rd column from the TVShowList, which is the TVShowID
            Dim genreId = LookUpGenre(MovieGenresList.Items(MovieGenresList.SelectedIndex).ToString)

            'Now, remove the link in the database.
            'DbExecute("DELETE FROM genre_link WHERE media_type = 'tvshow' AND genre_id = '" & GenreID & "' AND media_id ='" & TVShowList.Items(TVShowList.SelectedIndices(0)).SubItems(2).Text & "'")
            
            MovieGenresList.Items.RemoveAt(MovieGenresList.SelectedIndex)
            ' SaveTVShow_Click(Nothing, Nothing)
            Form1.RefreshGenres()
        End If
    End Sub

    'This looks up the Genre based on the name and returns the proper Genre ID
    Private Function LookUpGenre(ByVal genreName As String)
        Dim selectArray(0)
        selectArray(0) = 0

        'Shoot it over to the ReadRecord sub
        Dim returnArray() As String = DbReadRecord(VideoDatabaseLocation, $"SELECT * FROM genre where name ='{GenreName}'", selectArray)

        'The ID # is all we need. Just make sure it's not a null reference.
        Dim genreId As String = Nothing
        If returnArray Is Nothing Then
            MsgBox("nothing!")
        Else
            genreId = returnArray(0)
        End If

        Return genreId
    End Function

    'Movie Tab, Save Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click 
        If MovieList.SelectedItems.Count > 0 Then
            ' Fix any issues with shows and 's.
            Dim movieName As String = MovieLabel.Text

            'Convert show genres into the format ex:  genre1 / genre2 / etc.
            Dim movieGenres = ConvertGenres(MovieGenresList)
            movieName = Replace(movieName, "'", "''")

            'Grab the Network ID based on the name
            Dim networkId = LookUpNetwork(txtMovieNetwork.Text)
            Dim movieId As String = MovieList.SelectedItems(0).SubItems(1).Text


            DbExecute("DELETE FROM studio_link WHERE media_type = 'movie' AND movie_id = '" & movieId & "'")
            DbExecute("INSERT INTO studio_link (studio_id, media_id, media_type) VALUES ('" & networkId & "', '" & movieId & "', 'movie')")


            Dim query = "UPDATE movie SET c14 = '" & movieGenres & "', c18 ='" & txtMovieNetwork.Text &
                        "' WHERE idMovie = '" & movieId & "'"
            DbExecute(query)
            Form1.Status.Text = $"Updated {MovieLabel.Text} Successfully"

            'Remove all genres from tv show
            DbExecute("DELETE FROM genre_link WHERE genre_id = '" & movieId & "'")

            'add each one.  one by one.
            For x = 0 To MovieGenresList.Items.Count - 1
                Dim genreId = LookUpGenre(MovieGenresList.Items(x).ToString)
                DbExecute("INSERT INTO genre_link (genre_id, media_id, media_type) VALUES ('" & genreId & "', '" & movieId & "', 'movie')")
            Next

            'Save our spot on the list.
            Dim SavedName = txtMovieNetwork.Text

            'Refresh Things
            Form1.RefreshNetworkListMovies()
            Form1.RefreshGenres()



            Dim returnindex = MovieList.SelectedIndices(0)
            RefreshMovieList()
            MovieList.Items(returnindex).Selected = True



        End If
    End Sub


    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        If MovieList.SelectedItems.Count > 0 Then
            Form1.RefreshAllStudios()
            Form8.Visible = True
            Form8.Focus()
        End If
    End Sub

'    'Copied from Form1. 
'    'Should be called instead of RefreshAllStudios
'    Public Sub RefreshMovieStudios()
'        Dim SavedText = Option2.Text
'
'        'Clear all
'        Option2.Items.Clear()
'        Form3.ListBox1.Items.Clear()
'        txtShowNetwork.Items.Clear()
'        txtMovieNetwork.Items.Clear()
'        Form8.ListBox1.Items.Clear()
'
'        'Set an array with the columns you want returned
'        Dim SelectArray(0)
'        SelectArray(0) = 1
'
'        'Shoot it over to the ReadRecord sub, 
'        Dim ReturnArray() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM studio", SelectArray)
'
'        'Now, read the output of the array.
'
'        'Loop through each of the Array items.
'        For x = 0 To ReturnArray.Count - 1
'            Option2.Items.Add(ReturnArray(x))
'            Form3.ListBox1.Items.Add(ReturnArray(x))
'            txtShowNetwork.Items.Add(ReturnArray(x))
'            txtMovieNetwork.Items.Add(ReturnArray(x))
'            Form8.ListBox1.Items.Add(ReturnArray(x))
'        Next
'
'        'Sort them all.
'        Option2.Sorted = True
'        Form3.ListBox1.Sorted = True
'        Form8.ListBox1.Sorted = True
'        txtShowNetwork.Sorted = True
'        txtMovieNetwork.Sorted = True
'        Option2.Text = SavedText
'
'    End Sub

    Private Sub BtnAddGenre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddGenre.Click 
        FrmMovieGenres.Visible = True
        FrmMovieGenres.Focus()
    End Sub
End Class