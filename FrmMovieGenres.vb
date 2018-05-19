Public Class FrmMovieGenres
    Public Event MovieGenresAdded(ByVal genres As ListView.SelectedListViewItemCollection)

    Private Sub FrmMovieGenres_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        lstGenres.Items.Clear()
        lstGenres.Columns.Add("Genre", 200, HorizontalAlignment.Left)
        lstGenres.Columns.Add("ID", 0, HorizontalAlignment.Left)


        'Set an array with the columns you want returned
        Dim selectArray(1)
        selectArray(0) = 1
        selectArray(1) = 0

        'Shoot it over to the ReadRecord sub, 
        Dim returnArray() As String = DbReadRecord(VideoDatabaseLocation, "SELECT * FROM genre", selectArray)

        'Now, read the output of the array.
        'Loop through each of the Array items.
        For x = 0 To returnArray.Count - 1

            'Split them by ~'s.  This is how we seperate the rows in the single-element.
            Dim str() As String = Split(returnArray(x), "~")

            'Now take that split string and make it an item.
            Dim itm As ListViewItem
            itm = New ListViewItem(str)

            'Add the item to the TV genre list.
            lstGenres.Items.Add(itm)

        Next

        lstGenres.ListViewItemSorter = New clsListviewSorter(0, SortOrder.Ascending)
        lstGenres.Sort()
    End Sub
    
    Private Sub BtnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAdd.Click
        If lstGenres.SelectedIndices.Count <= 0 Then Return

        RaiseEvent MovieGenresAdded(lstGenres.SelectedItems)
    End Sub

    Private Sub BtnNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNew.Click
        Dim newGenre = InputBox("New Genre Name", "New Genre Name")

        If newGenre <> "" Then
            Dim alreadyUsed As Boolean = False

            For x = 0 To lstGenres.Items.Count - 1
                If StrComp(lstGenres.Items(x).Text, newGenre, CompareMethod.Text) = 0 Then
                    alreadyUsed = True
                End If
            Next

            If alreadyUsed = False Then
                DbExecute($"INSERT INTO genre (name) VALUES ('{newGenre}')")
            Else
                MsgBox($"You already have a genre labeled : {newGenre}")
            End If
        End If

        FrmMovieGenres_Load(Nothing, Nothing)
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnDelete.Click
        If lstGenres.SelectedItems.Count > 0 Then
            DeleteMovieGenre()
            RemoveGenreFromMovie()
            
            FrmMovieGenres_Load(Nothing, Nothing)
        End If
    End Sub

    Private Sub DeleteMovieGenre() 
        'These are the columns we need back.  Just the ID
        Dim selectArray(0)
        selectArray(0) = 0

        'Grab the GenreID and store it in GenreID
        Dim sqlStatement = $"SELECT * FROM genre WHERE name = '{lstGenres.SelectedItems(0).Text}'"
        Dim returnArray() As String = DbReadRecord(VideoDatabaseLocation, sqlStatement, selectArray)
        Dim genreId = returnArray(0)

        'Remove it from the Genre_link table for movies only
        DbExecute($"DELETE FROM genre_link WHERE genre_id = '{genreId}' AND media_type = 'movie'")

        'Remove it from the Genres table
        DbExecute($"DELETE FROM genre WHERE genre_id = '{genreId}'")
    End Sub

    Private Sub RemoveGenreFromMovie()
        'Now grab the MOVIE table & remove the genre there.
        Dim selectArray(1)
        selectArray(0) = 0
        selectArray(1) = 9

        Dim statement = $"SELECT * FROM movie WHERE c14 LIKE '%{lstGenres.SelectedItems(0).Text}%'"
        Dim returnArray() As String = DbReadRecord(VideoDatabaseLocation, statement, selectArray)

        'Make sure there's not a null return for the genre items.
        If returnArray Is Nothing Then
        Else
            For index = 0 To returnArray.Count - 1
                If returnArray(index) = "" Then
                    Continue For
                End If

                'Loop through all the returned shows
                Dim allGenres = Split(Split(returnArray(index), "~")(1), " / ")
                Dim mediaId = Split(returnArray(index), "~")(0)
                Dim newGenres() As String = Nothing
                Dim newGenresNum As Integer = 0

                'Loop through all genres
                For y = 0 To UBound(allGenres)
                    'Don't add the genre if it matches
                    If StrComp(allGenres(y), lstGenres.SelectedItems(0).Text, CompareMethod.Text) <> 0 Then
                        ReDim Preserve newGenres(newGenresNum)
                        newGenres(newGenresNum) = allGenres(y)
                        newGenresNum = newGenresNum + 1
                    End If
                Next

                'Now, add all of the genres back into the properly formatted: genre1 / genre2 / etc.
                Dim properFormedGenres As String = ""

                For y = 0 To UBound(newGenres)
                    If y = 0 Then
                        properFormedGenres = newGenres(y)
                    Else
                        properFormedGenres = properFormedGenres & " / " & newGenres(y)
                    End If
                Next

                'Now update the actual Database.
                Dim sqlQuery = $"UPDATE movie SET c14 = '{properFormedGenres}' WHERE idMovie = '{mediaId}'"
                DbExecute(sqlQuery)

                'Should use an event rather than calling the form directly
                Form1.RefreshALL()
            Next
        End If

        MsgBox($"The genre {lstGenres.SelectedItems(0).Text} has also been removed from all movies")
    End Sub

End Class