Public Class FrmTabNetworksStudios

    
    'For sorting columns in listviews
    Private _mSortingColumn As ColumnHeader


    Private Sub FrmTabNetworksStudios_Load(sender As Object, e As EventArgs) Handles Me.Load
        NetworkList.Columns.Add("Network", 140, HorizontalAlignment.Left)
        NetworkList.Columns.Add("# Shows", 60, HorizontalAlignment.Left)

        MovieNetworkList.Columns.Add("Studio", 170, HorizontalAlignment.Left)
        MovieNetworkList.Columns.Add("# Movies", 60, HorizontalAlignment.Left)

        RefreshNetworkList()
        RefreshNetworkListMovies()
    End Sub

    '===== EVENTS ===============================================================================

    Private Sub NetworkList_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles NetworkList.ColumnClick
        ' Get the new sorting column. 
        Dim newSortingColumn As ColumnHeader = NetworkList.Columns(e.Column)
        ' Figure out the new sorting order. 
        Dim sortOrder As SortOrder
        If _mSortingColumn Is Nothing Then
            ' New column. Sort ascending. 
            sortOrder = SortOrder.Ascending
        Else ' See if this is the same column. 
            If newSortingColumn.Equals(_mSortingColumn) Then
                ' Same column. Switch the sort order. 
                If _mSortingColumn.Text.StartsWith("> ") Then
                    sortOrder = SortOrder.Descending
                Else
                    sortOrder = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending. 
                sortOrder = SortOrder.Ascending
            End If
            ' Remove the old sort indicator. 
            _mSortingColumn.Text = _mSortingColumn.Text.Substring(2)
        End If
        ' Display the new sort order. 
        _mSortingColumn = newSortingColumn
        If sortOrder = SortOrder.Ascending Then
            _mSortingColumn.Text = $"> {_mSortingColumn.Text}"
        Else
            _mSortingColumn.Text = $"< {_mSortingColumn.Text}"
        End If
        ' Create a comparer. 
        NetworkList.ListViewItemSorter = New clsListviewSorter(e.Column, sortOrder)
        ' Sort. 
        NetworkList.Sort()
    End Sub

    Private Sub NetworkList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NetworkList.SelectedIndexChanged

        NetworkListSubList.Items.Clear()

        If NetworkList.SelectedIndices.Count > 0 Then

            Dim selectArray(0)
            selectArray(0) = 1

            Dim returnArray() As String = DbReadRecord($"SELECT * FROM tvshow WHERE c14='{NetworkList.Items(NetworkList.SelectedIndices(0)).SubItems(0).Text}'", selectArray)

            For x = 0 To returnArray.Count - 1
                NetworkListSubList.Items.Add(returnArray(x))
            Next

        End If
    End Sub

    Private Sub MovieNetworkList_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles MovieNetworkList.ColumnClick
        ' Get the new sorting column. 
        Dim newSortingColumn As ColumnHeader = MovieNetworkList.Columns(e.Column)
        ' Figure out the new sorting order. 
        Dim sortOrder As SortOrder
        If _mSortingColumn Is Nothing Then
            ' New column. Sort ascending. 
            sortOrder = SortOrder.Ascending
        Else ' See if this is the same column. 
            If newSortingColumn.Equals(_mSortingColumn) Then
                ' Same column. Switch the sort order. 
                If _mSortingColumn.Text.StartsWith("> ") Then
                    sortOrder = SortOrder.Descending
                Else
                    sortOrder = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending. 
                sortOrder = SortOrder.Ascending
            End If
            ' Remove the old sort indicator. 
            _mSortingColumn.Text = _mSortingColumn.Text.Substring(2)
        End If
        ' Display the new sort order. 
        _mSortingColumn = newSortingColumn
        If sortOrder = SortOrder.Ascending Then
            _mSortingColumn.Text = $"> {_mSortingColumn.Text}"
        Else
            _mSortingColumn.Text = $"< {_mSortingColumn.Text}"
        End If
        ' Create a comparer. 
        MovieNetworkList.ListViewItemSorter = New clsListviewSorter(e.Column, sortOrder)
        ' Sort. 
        MovieNetworkList.Sort()
    End Sub

    Private Sub MovieNetworkList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles MovieNetworkList.SelectedIndexChanged
        MovieNetworkListSubList.Items.Clear()

        If MovieNetworkList.SelectedIndices.Count > 0 Then

            Dim selectArray(0)
            selectArray(0) = 2

            Dim returnArray() As String = DbReadRecord($"SELECT * FROM movie WHERE c18='{MovieNetworkList.Items(MovieNetworkList.SelectedIndices(0)).SubItems(0).Text}'", selectArray)

            For x = 0 To returnArray.Count - 1
                MovieNetworkListSubList.Items.Add(returnArray(x))
            Next

        End If
    End Sub



    '===== SUBS ================================================================================

    Public Sub RefreshNetworkListMovies()
        MovieNetworkList.Items.Clear()

        Dim selectArray(1)
        selectArray(0) = 2
        selectArray(1) = 20

        Dim returnArray() As String = DbReadRecord("SELECT * FROM movie ORDER BY c18 ASC", selectArray)


        'Loop through each returned Movie
        For x = 0 To returnArray.Count - 1


            Dim returnArraySplit() As String

            Dim showNetwork As String

            returnArraySplit = Split(returnArray(x), "~")

            showNetwork = returnArraySplit(1)

            Dim networkListed As Boolean = False

            For y = 0 To MovieNetworkList.Items.Count - 1

                If MovieNetworkList.Items(y).SubItems(0).Text = showNetwork Then
                    networkListed = True
                    MovieNetworkList.Items(y).SubItems(1).Text = MovieNetworkList.Items(y).SubItems(1).Text + 1
                End If

            Next

            If networkListed = False Then
                Dim itm As ListViewItem
                Dim str(2) As String

                str(0) = showNetwork
                str(1) = 1

                itm = New ListViewItem(str)

                'Add the item to the TV show list.
                MovieNetworkList.Items.Add(itm)


            End If

        Next

    End Sub

    Public Sub RefreshNetworkList()
        NetworkList.Items.Clear()

        Dim selectArray(1)
        selectArray(0) = 1
        selectArray(1) = 15

        Dim returnArray() As String = DbReadRecord("SELECT * FROM tvshow ORDER BY c14 ASC", selectArray)


        'Loop through each returned TV show.
        For x = 0 To returnArray.Count - 1


            Dim returnArraySplit() As String

            Dim showNetwork As String

            returnArraySplit = Split(returnArray(x), "~")

            showNetwork = returnArraySplit(1)

            Dim networkListed As Boolean = False

            For y = 0 To NetworkList.Items.Count - 1

                If NetworkList.Items(y).SubItems(0).Text = showNetwork Then
                    networkListed = True
                    NetworkList.Items(y).SubItems(1).Text = NetworkList.Items(y).SubItems(1).Text + 1
                End If

            Next

            If networkListed = False Then
                Dim itm As ListViewItem
                Dim str(2) As String

                str(0) = showNetwork
                str(1) = 1

                itm = New ListViewItem(str)

                'Add the item to the TV show list.
                NetworkList.Items.Add(itm)


            End If

        Next

    End Sub


End Class