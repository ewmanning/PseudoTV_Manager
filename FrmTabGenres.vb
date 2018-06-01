Public Class FrmTabGenres
    
    Private _mSortingColumn2 As ColumnHeader

    Private Sub FrmTabGenres_Load(sender As Object, e As EventArgs) Handles Me.Load
        GenresList.Columns.Add("Genre", 100, HorizontalAlignment.Left)
        GenresList.Columns.Add("# Shows", 60, HorizontalAlignment.Center)
        GenresList.Columns.Add("# Movies", 60, HorizontalAlignment.Center)
        GenresList.Columns.Add("# Total", 80, HorizontalAlignment.Center)
        GenresList.Columns.Add("Genre ID", 0, HorizontalAlignment.Left)

        RefreshGenres()
    End Sub

    '==== EVENTS ====================================================================

    Private Sub GenresList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GenresList.SelectedIndexChanged
        GenresListSubList.Items.Clear()
        GenresListSubListMovies.Items.Clear()

        If GenresList.SelectedIndices.Count > 0 Then
            Dim selectArray(0)
            selectArray(0) = 1


            'Now, gather a list of all the show IDs that match the genreID
            Dim returnArray() As String = DbReadRecord($"SELECT * FROM genre_link WHERE media_type = 'tvshow' AND genre_id ='{GenresList.Items(GenresList.SelectedIndices(0)).SubItems(4).Text}'", selectArray)

            'Now loop through each one individually.

            If returnArray Is Nothing Then
            Else
                For x = 0 To returnArray.Count - 1
                    selectArray(0) = 1

                    Dim returnArray2() As String = DbReadRecord($"SELECT * FROM tvshow WHERE idShow='{returnArray(x)}'", selectArray)

                    'Now add that name to the list.
                    GenresListSubList.Items.Add(returnArray2(0))
                Next
            End If

            'MOVIES REPEAT THIS PROCESS.

            Dim returnArrayMovies() As String = DbReadRecord($"SELECT * FROM genre_link WHERE media_type = 'movie' AND genre_id ='{GenresList.Items(GenresList.SelectedIndices(0)).SubItems(4).Text}'", selectArray)

            'Now loop through each one individually 
            If returnArrayMovies Is Nothing Then
            Else
                For x = 0 To returnArrayMovies.Count - 1
                    selectArray(0) = 2

                    Dim returnArray2() As String = DbReadRecord($"SELECT * FROM movie WHERE idMovie='{returnArrayMovies(x)}'", selectArray)

                    'Now add that name to the list.
                    GenresListSubListMovies.Items.Add(returnArray2(0))
                Next
            End If
        End If

    End Sub

    Private Sub GenresList_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles GenresList.ColumnClick
        ' Get the new sorting column. 
        Dim newSortingColumn As ColumnHeader = GenresList.Columns(e.Column)
        ' Figure out the new sorting order. 
        Dim sortOrder As SortOrder
        If _mSortingColumn2 Is Nothing Then
            ' New column. Sort ascending. 
            sortOrder = SortOrder.Ascending
        Else ' See if this is the same column. 
            If newSortingColumn.Equals(_mSortingColumn2) Then
                ' Same column. Switch the sort order. 
                If _mSortingColumn2.Text.StartsWith("> ") Then
                    sortOrder = SortOrder.Descending
                Else
                    sortOrder = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending. 
                sortOrder = SortOrder.Ascending
            End If
            ' Remove the old sort indicator. 
            _mSortingColumn2.Text = _mSortingColumn2.Text.Substring(2)
        End If
        ' Display the new sort order. 
        _mSortingColumn2 = newSortingColumn
        If sortOrder = SortOrder.Ascending Then
            _mSortingColumn2.Text = $"> {_mSortingColumn2.Text}"
        Else
            _mSortingColumn2.Text = $"< {_mSortingColumn2.Text}"
        End If
        ' Create a comparer. 
        GenresList.ListViewItemSorter = New clsListviewSorter(e.Column, sortOrder)
        ' Sort. 
        GenresList.Sort()
    End Sub

    '==== SUBS ====================================================================

    Public Sub RefreshGenres()
        GenresList.Items.Clear()
        Dim selectArrayMain(1)
        selectArrayMain(0) = 0
        selectArrayMain(1) = 1

        'Shoot it over to the ReadRecord sub
        Dim returnArrayMain() As String = DbReadRecord("SELECT * FROM genre", selectArrayMain)

        'Loop through and read the name


        For x = 0 To UBound(returnArrayMain)
            'Sort them into an array
            Dim splitItem() As String = Split(returnArrayMain(x), "~")
            'Position 0 = genre ID
            'Position 1 = genre name

            'Push array into ListViewItem

            Dim selectArray(0)
            selectArray(0) = 1

            'Now, grab a list of all the shows that match the GenreID
            Dim returnArray() As String = DbReadRecord($"SELECT * FROM genre_link WHERE media_type = 'tvshow' AND genre_id ='{splitItem(0)}'", selectArray)

            'This will grab the number of movies.
            Dim returnArray2() As String = DbReadRecord($"SELECT * FROM genre_link WHERE media_type = 'movie' AND genre_id ='{splitItem(0)}'", selectArray)

            Dim showNum
            Dim movieNum

            'This is the total number of shows that match this genre.
            'Also, verify the returning array is something, not null before proceeding.
            If returnArray Is Nothing Then
                showNum = 0
            Else
                showNum = returnArray.Count
            End If

            If returnArray2 Is Nothing Then
                movieNum = 0
            Else
                movieNum = returnArray2.Count
            End If

            Dim str(4) As String
            'Genre Name
            '# of shows in genre
            '# of movies in genre
            'Total of both /\
            'Genre ID

            str(0) = splitItem(1)
            str(1) = showNum
            str(2) = movieNum
            str(3) = showNum + movieNum
            str(4) = splitItem(0)

            Dim itm As ListViewItem
            itm = New ListViewItem(str)
            'Add to list
            GenresList.Items.Add(itm)
        Next

        GenresList.Sort()
    End Sub

End Class