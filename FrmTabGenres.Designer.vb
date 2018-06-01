<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTabGenres
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GenresListSubListMovies = New System.Windows.Forms.ListBox()
        Me.GenresListSubList = New System.Windows.Forms.ListBox()
        Me.GenresList = New System.Windows.Forms.ListView()
        Me.SuspendLayout
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Silver
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label17.Location = New System.Drawing.Point(729, 13)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(255, 25)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Movies"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Silver
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label16.Location = New System.Drawing.Point(466, 13)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(255, 25)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "TV Shows"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GenresListSubListMovies
        '
        Me.GenresListSubListMovies.FormattingEnabled = true
        Me.GenresListSubListMovies.ItemHeight = 16
        Me.GenresListSubListMovies.Location = New System.Drawing.Point(729, 42)
        Me.GenresListSubListMovies.Margin = New System.Windows.Forms.Padding(4)
        Me.GenresListSubListMovies.Name = "GenresListSubListMovies"
        Me.GenresListSubListMovies.Size = New System.Drawing.Size(255, 740)
        Me.GenresListSubListMovies.TabIndex = 9
        '
        'GenresListSubList
        '
        Me.GenresListSubList.FormattingEnabled = true
        Me.GenresListSubList.ItemHeight = 16
        Me.GenresListSubList.Location = New System.Drawing.Point(466, 42)
        Me.GenresListSubList.Margin = New System.Windows.Forms.Padding(4)
        Me.GenresListSubList.Name = "GenresListSubList"
        Me.GenresListSubList.Size = New System.Drawing.Size(255, 740)
        Me.GenresListSubList.TabIndex = 8
        '
        'GenresList
        '
        Me.GenresList.FullRowSelect = true
        Me.GenresList.HideSelection = false
        Me.GenresList.Location = New System.Drawing.Point(13, 13)
        Me.GenresList.Margin = New System.Windows.Forms.Padding(4)
        Me.GenresList.Name = "GenresList"
        Me.GenresList.Size = New System.Drawing.Size(405, 771)
        Me.GenresList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.GenresList.TabIndex = 7
        Me.GenresList.UseCompatibleStateImageBehavior = false
        Me.GenresList.View = System.Windows.Forms.View.Details
        '
        'FrmTabGenres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(1119, 876)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GenresListSubListMovies)
        Me.Controls.Add(Me.GenresListSubList)
        Me.Controls.Add(Me.GenresList)
        Me.Name = "FrmTabGenres"
        Me.Text = "FrmTabGenres"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents GenresListSubListMovies As ListBox
    Friend WithEvents GenresListSubList As ListBox
    Friend WithEvents GenresList As ListView
End Class
