Public Module ModGlobal
    Public VideoDatabaseLocation As String = ""
    
    'This looks up the Genre based on the name and returns the proper Genre ID
    Public Function LookUpGenre(ByVal genreName As String)

        Dim genreId As String = Nothing

        Dim selectArray(0)
        selectArray(0) = 0

        'Shoot it over to the ReadRecord sub
        Dim returnArray() As String = DbReadRecord(VideoDatabaseLocation, $"SELECT * FROM genre where name ='{GenreName}'", selectArray)

        'The ID # is all we need.
        'Just make sure it's not a null reference.
        If returnArray Is Nothing Then
            MsgBox("nothing!")
        Else
            genreId = returnArray(0)
        End If

        Return genreId
    End Function
    
    Public Function ConvertGenres(ByVal genrelist As ListBox)
        'Converts the existing ListTVGenre's contents to the proper format.

        Dim tvGenresString As String = ""
        For x = 0 To Genrelist.Items.Count - 1
            If x = 0 Then
                tvGenresString = Genrelist.Items(x).ToString
            Else
                tvGenresString = $"{tvGenresString} / {Genrelist.Items(x).ToString}"
            End If
        Next

        Return tvGenresString
    End Function

    Public Function LookUpNetwork(ByVal network As String)
        'This looks up the Network name and returns the proper Network ID

        Dim networkId As String = Nothing

        Dim selectArray(0)
        selectArray(0) = 0

        'Shoot it over to the ReadRecord sub
        Dim returnArray() As String = DbReadRecord(VideoDatabaseLocation, $"SELECT * FROM studio where name='{Network}'", selectArray)

        'The ID # is all we need. Just make sure it's not a null reference.
        If returnArray IsNot Nothing Then
            networkId = returnArray(0)
        End If

        Return networkId

    End Function

End Module