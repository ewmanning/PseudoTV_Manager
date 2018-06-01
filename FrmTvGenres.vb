Public Class FrmTvGenres
    Public Event TvShowGenresAdded(ByVal genres As ListView.SelectedListViewItemCollection)

    '======== EVENTS ============================================================

    Private Sub FrmTvGenres_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GenreList.Items.Clear()
        GenreList.Columns.Add("Genre", 200, HorizontalAlignment.Left)
        GenreList.Columns.Add("ID", 0, HorizontalAlignment.Left)

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
            GenreList.Items.Add(itm)
        Next

        GenreList.ListViewItemSorter = New clsListviewSorter(0, SortOrder.Ascending)
        GenreList.Sort()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If GenreList.SelectedIndices.Count <= 0 Then Return

        RaiseEvent TvShowGenresAdded(GenreList.SelectedItems)
    End Sub
    
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Dim newGenre = InputBox("New Genre Name", "New Genre Name")
        If newGenre.Trim() = "" Then Return
        
        Dim alreadyUsed As Boolean = False
        For x = 0 To GenreList.Items.Count - 1
            If StrComp(GenreList.Items(x).Text, newGenre, CompareMethod.Text) = 0 Then
                alreadyUsed = True
            End If
        Next

        If alreadyUsed = False Then
            DbExecute($"INSERT INTO genre (name) VALUES ('{newGenre}')")
        End If
        
        FrmTvGenres_Load(Nothing, Nothing)
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If GenreList.SelectedItems.Count <= 0 Then Return

        DeleteTvShowGenre()
        RemoveGenreFromTvShow()
            
        FrmTvGenres_Load(Nothing, Nothing)
    End Sub

    '======== SUBS ============================================================

    Private Sub DeleteTvShowGenre() 
        'These are the columns we need back.  Just the ID
        Dim selectArray(0)
        selectArray(0) = 0

        'Grab the GenreID and store it in GenreID
        Dim returnArray() As String = DbReadRecord(VideoDatabaseLocation, $"SELECT * FROM genre WHERE name = '{GenreList.SelectedItems(0).Text}'", selectArray)
        Dim genreId = returnArray(0)

        'Remove it from the Genre_link table for tv shows only
        DbExecute($"DELETE FROM genre_link WHERE genre_id = '{genreId}' AND media_type = 'tvshow'")

        'TODO - Merge Movie & TvShow Genres as there is only 1 set for both
        'Remove it from the Genres table
        DbExecute($"DELETE FROM genre WHERE genre_id = '{genreId}'")
    End Sub

    Private Sub RemoveGenreFromTvShow()
        'Now grab the TV table & remove the genre there. 

        Dim selectArray(1)
        selectArray(0) = 0
        selectArray(1) = 9

        Dim statement = $"SELECT * FROM tvshow WHERE c08 LIKE '%{GenreList.SelectedItems(0).Text}%'"
        Dim returnArray() As String = DbReadRecord(statement, selectArray)

        'Make sure there's not a null return for the genre items.
        If returnArray Is Nothing Then
        Else
            For index = 0 To returnArray.Count - 1
                If returnArray(index) = "" Then
                    Continue For
                End If

                'Loop through all the returned shows
                Dim allGenres = Split(Split(returnArray(index), "~")(1), " / ")
                Dim tvShowId = Split(returnArray(index), "~")(0)
                Dim newGenres() As String = Nothing
                Dim newGenresNum As Integer = 0

                'Loop through all genres
                For y = 0 To UBound(allGenres)
                    'Don't add the genre if it matches
                    If StrComp(allGenres(y), GenreList.SelectedItems(0).Text, CompareMethod.Text) <> 0 Then
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
                DbExecute($"UPDATE tvshow SET c08 = '{properFormedGenres}' WHERE idShow = '{tvShowId}'")

                'Should use an event rather than calling the form directly
                Form1.RefreshALL()
            Next
        End If

        'TODO - Enhancement: Make this an Event so this can become a status bar update rather than msgbox
        MsgBox($"The genre {GenreList.SelectedItems(0).Text} has also been removed from all tv shows")
    End Sub

End Class