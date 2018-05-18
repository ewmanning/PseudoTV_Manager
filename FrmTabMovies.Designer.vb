<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTabMovies
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
        Me.MovieLabel = New System.Windows.Forms.Label()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.MovieIDLabel = New System.Windows.Forms.Label()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.txtMovieNetwork = New System.Windows.Forms.ComboBox()
        Me.MovieLocation = New System.Windows.Forms.TextBox()
        Me.BtnDeleteGenre = New System.Windows.Forms.Button()
        Me.BtnAddGenre = New System.Windows.Forms.Button()
        Me.MovieGenresList = New System.Windows.Forms.ListBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.MovieList = New System.Windows.Forms.ListView()
        Me.MoviePicture = New System.Windows.Forms.PictureBox()
        CType(Me.MoviePicture,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'MovieLabel
        '
        Me.MovieLabel.AutoSize = true
        Me.MovieLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.MovieLabel.Location = New System.Drawing.Point(309, 26)
        Me.MovieLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.MovieLabel.Name = "MovieLabel"
        Me.MovieLabel.Size = New System.Drawing.Size(83, 31)
        Me.MovieLabel.TabIndex = 49
        Me.MovieLabel.Text = "Temp"
        '
        'Button18
        '
        Me.Button18.Location = New System.Drawing.Point(667, 57)
        Me.Button18.Margin = New System.Windows.Forms.Padding(4)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(41, 36)
        Me.Button18.TabIndex = 48
        Me.Button18.Text = "..."
        Me.Button18.UseVisualStyleBackColor = true
        '
        'MovieIDLabel
        '
        Me.MovieIDLabel.AutoSize = true
        Me.MovieIDLabel.Location = New System.Drawing.Point(741, 17)
        Me.MovieIDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.MovieIDLabel.Name = "MovieIDLabel"
        Me.MovieIDLabel.Size = New System.Drawing.Size(59, 17)
        Me.MovieIDLabel.TabIndex = 47
        Me.MovieIDLabel.Text = "Label16"
        Me.MovieIDLabel.Visible = false
        '
        'Button17
        '
        Me.Button17.Location = New System.Drawing.Point(311, 473)
        Me.Button17.Margin = New System.Windows.Forms.Padding(4)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(105, 38)
        Me.Button17.TabIndex = 46
        Me.Button17.Text = "Save"
        Me.Button17.UseVisualStyleBackColor = true
        '
        'txtMovieNetwork
        '
        Me.txtMovieNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtMovieNetwork.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtMovieNetwork.FormattingEnabled = true
        Me.txtMovieNetwork.Location = New System.Drawing.Point(308, 57)
        Me.txtMovieNetwork.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMovieNetwork.Name = "txtMovieNetwork"
        Me.txtMovieNetwork.Size = New System.Drawing.Size(349, 33)
        Me.txtMovieNetwork.TabIndex = 45
        '
        'MovieLocation
        '
        Me.MovieLocation.Location = New System.Drawing.Point(308, 116)
        Me.MovieLocation.Margin = New System.Windows.Forms.Padding(4)
        Me.MovieLocation.Name = "MovieLocation"
        Me.MovieLocation.Size = New System.Drawing.Size(352, 22)
        Me.MovieLocation.TabIndex = 44
        '
        'BtnDeleteGenre
        '
        Me.BtnDeleteGenre.Location = New System.Drawing.Point(612, 179)
        Me.BtnDeleteGenre.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDeleteGenre.Name = "BtnDeleteGenre"
        Me.BtnDeleteGenre.Size = New System.Drawing.Size(49, 26)
        Me.BtnDeleteGenre.TabIndex = 43
        Me.BtnDeleteGenre.Text = "Del"
        Me.BtnDeleteGenre.UseVisualStyleBackColor = true
        '
        'BtnAddGenre
        '
        Me.BtnAddGenre.Location = New System.Drawing.Point(555, 179)
        Me.BtnAddGenre.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAddGenre.Name = "BtnAddGenre"
        Me.BtnAddGenre.Size = New System.Drawing.Size(49, 26)
        Me.BtnAddGenre.TabIndex = 42
        Me.BtnAddGenre.Text = "Add"
        Me.BtnAddGenre.UseVisualStyleBackColor = true
        '
        'MovieGenresList
        '
        Me.MovieGenresList.FormattingEnabled = true
        Me.MovieGenresList.ItemHeight = 16
        Me.MovieGenresList.Location = New System.Drawing.Point(311, 208)
        Me.MovieGenresList.Margin = New System.Windows.Forms.Padding(4)
        Me.MovieGenresList.Name = "MovieGenresList"
        Me.MovieGenresList.Size = New System.Drawing.Size(352, 244)
        Me.MovieGenresList.TabIndex = 41
        '
        'Label13
        '
        Me.Label13.AutoSize = true
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label13.Location = New System.Drawing.Point(316, 173)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 36)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Genres"
        '
        'MovieList
        '
        Me.MovieList.FullRowSelect = true
        Me.MovieList.HideSelection = false
        Me.MovieList.Location = New System.Drawing.Point(13, 13)
        Me.MovieList.Margin = New System.Windows.Forms.Padding(4)
        Me.MovieList.MultiSelect = false
        Me.MovieList.Name = "MovieList"
        Me.MovieList.Size = New System.Drawing.Size(284, 757)
        Me.MovieList.TabIndex = 39
        Me.MovieList.UseCompatibleStateImageBehavior = false
        Me.MovieList.View = System.Windows.Forms.View.Details
        '
        'MoviePicture
        '
        Me.MoviePicture.Location = New System.Drawing.Point(740, 82)
        Me.MoviePicture.Margin = New System.Windows.Forms.Padding(4)
        Me.MoviePicture.Name = "MoviePicture"
        Me.MoviePicture.Size = New System.Drawing.Size(403, 510)
        Me.MoviePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MoviePicture.TabIndex = 38
        Me.MoviePicture.TabStop = false
        '
        'FrmTabMovies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(1200, 800)
        Me.Controls.Add(Me.MovieLabel)
        Me.Controls.Add(Me.Button18)
        Me.Controls.Add(Me.MovieIDLabel)
        Me.Controls.Add(Me.Button17)
        Me.Controls.Add(Me.txtMovieNetwork)
        Me.Controls.Add(Me.MovieLocation)
        Me.Controls.Add(Me.BtnDeleteGenre)
        Me.Controls.Add(Me.BtnAddGenre)
        Me.Controls.Add(Me.MovieGenresList)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.MovieList)
        Me.Controls.Add(Me.MoviePicture)
        Me.Name = "FrmTabMovies"
        Me.Text = "FrmTabMovies"
        CType(Me.MoviePicture,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents MovieLabel As Label
    Friend WithEvents Button18 As Button
    Friend WithEvents MovieIDLabel As Label
    Friend WithEvents Button17 As Button
    Friend WithEvents txtMovieNetwork As ComboBox
    Friend WithEvents MovieLocation As TextBox
    Friend WithEvents BtnDeleteGenre As Button
    Friend WithEvents BtnAddGenre As Button
    Friend WithEvents MovieGenresList As ListBox
    Friend WithEvents Label13 As Label
    Friend WithEvents MovieList As ListView
    Friend WithEvents MoviePicture As PictureBox
End Class
