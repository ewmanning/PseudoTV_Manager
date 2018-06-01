<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTabTvShows
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
        Me.BtnNetworkBrowse = New System.Windows.Forms.Button()
        Me.cboTvShowNetwork = New System.Windows.Forms.ComboBox()
        Me.btnRemoveTvShowGenre = New System.Windows.Forms.Button()
        Me.btnAddTvShowGenre = New System.Windows.Forms.Button()
        Me.TvShowGenresList = New System.Windows.Forms.ListBox()
        Me.TvShowPictureBox = New System.Windows.Forms.PictureBox()
        Me.TVShowLabel = New System.Windows.Forms.Label()
        Me.SaveTVShow = New System.Windows.Forms.Button()
        Me.txtShowLocation = New System.Windows.Forms.TextBox()
        Me.txtShowName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TVShowList = New System.Windows.Forms.ListView()
        CType(Me.TvShowPictureBox,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'BtnNetworkBrowse
        '
        Me.BtnNetworkBrowse.Location = New System.Drawing.Point(666, 51)
        Me.BtnNetworkBrowse.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNetworkBrowse.Name = "BtnNetworkBrowse"
        Me.BtnNetworkBrowse.Size = New System.Drawing.Size(41, 33)
        Me.BtnNetworkBrowse.TabIndex = 34
        Me.BtnNetworkBrowse.Text = "..."
        Me.BtnNetworkBrowse.UseVisualStyleBackColor = true
        '
        'cboTvShowNetwork
        '
        Me.cboTvShowNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTvShowNetwork.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cboTvShowNetwork.FormattingEnabled = true
        Me.cboTvShowNetwork.Location = New System.Drawing.Point(303, 51)
        Me.cboTvShowNetwork.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTvShowNetwork.Name = "cboTvShowNetwork"
        Me.cboTvShowNetwork.Size = New System.Drawing.Size(355, 33)
        Me.cboTvShowNetwork.TabIndex = 33
        '
        'btnRemoveTvShowGenre
        '
        Me.btnRemoveTvShowGenre.Location = New System.Drawing.Point(582, 157)
        Me.btnRemoveTvShowGenre.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemoveTvShowGenre.Name = "btnRemoveTvShowGenre"
        Me.btnRemoveTvShowGenre.Size = New System.Drawing.Size(76, 25)
        Me.btnRemoveTvShowGenre.TabIndex = 32
        Me.btnRemoveTvShowGenre.Text = "Remove"
        Me.btnRemoveTvShowGenre.UseVisualStyleBackColor = true
        '
        'btnAddTvShowGenre
        '
        Me.btnAddTvShowGenre.Location = New System.Drawing.Point(498, 158)
        Me.btnAddTvShowGenre.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddTvShowGenre.Name = "btnAddTvShowGenre"
        Me.btnAddTvShowGenre.Size = New System.Drawing.Size(76, 25)
        Me.btnAddTvShowGenre.TabIndex = 31
        Me.btnAddTvShowGenre.Text = "Add"
        Me.btnAddTvShowGenre.UseVisualStyleBackColor = true
        '
        'TvShowGenresList
        '
        Me.TvShowGenresList.FormattingEnabled = true
        Me.TvShowGenresList.ItemHeight = 16
        Me.TvShowGenresList.Location = New System.Drawing.Point(303, 186)
        Me.TvShowGenresList.Margin = New System.Windows.Forms.Padding(4)
        Me.TvShowGenresList.Name = "TvShowGenresList"
        Me.TvShowGenresList.Size = New System.Drawing.Size(355, 244)
        Me.TvShowGenresList.TabIndex = 30
        '
        'TvShowPictureBox
        '
        Me.TvShowPictureBox.Location = New System.Drawing.Point(715, 51)
        Me.TvShowPictureBox.Margin = New System.Windows.Forms.Padding(4)
        Me.TvShowPictureBox.Name = "TvShowPictureBox"
        Me.TvShowPictureBox.Size = New System.Drawing.Size(400, 500)
        Me.TvShowPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TvShowPictureBox.TabIndex = 29
        Me.TvShowPictureBox.TabStop = false
        '
        'TVShowLabel
        '
        Me.TVShowLabel.AutoSize = true
        Me.TVShowLabel.Location = New System.Drawing.Point(712, 13)
        Me.TVShowLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TVShowLabel.Name = "TVShowLabel"
        Me.TVShowLabel.Size = New System.Drawing.Size(51, 17)
        Me.TVShowLabel.TabIndex = 28
        Me.TVShowLabel.Text = "Label5"
        Me.TVShowLabel.Visible = false
        '
        'SaveTVShow
        '
        Me.SaveTVShow.Location = New System.Drawing.Point(303, 438)
        Me.SaveTVShow.Margin = New System.Windows.Forms.Padding(4)
        Me.SaveTVShow.Name = "SaveTVShow"
        Me.SaveTVShow.Size = New System.Drawing.Size(107, 37)
        Me.SaveTVShow.TabIndex = 27
        Me.SaveTVShow.Text = "Save"
        Me.SaveTVShow.UseVisualStyleBackColor = true
        '
        'txtShowLocation
        '
        Me.txtShowLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtShowLocation.Location = New System.Drawing.Point(303, 92)
        Me.txtShowLocation.Margin = New System.Windows.Forms.Padding(4)
        Me.txtShowLocation.Name = "txtShowLocation"
        Me.txtShowLocation.Size = New System.Drawing.Size(355, 24)
        Me.txtShowLocation.TabIndex = 26
        '
        'txtShowName
        '
        Me.txtShowName.Enabled = false
        Me.txtShowName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtShowName.Location = New System.Drawing.Point(305, 13)
        Me.txtShowName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtShowName.Name = "txtShowName"
        Me.txtShowName.Size = New System.Drawing.Size(353, 30)
        Me.txtShowName.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(305, 146)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 36)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Genres"
        '
        'TVShowList
        '
        Me.TVShowList.FullRowSelect = true
        Me.TVShowList.HideSelection = false
        Me.TVShowList.Location = New System.Drawing.Point(13, 13)
        Me.TVShowList.Margin = New System.Windows.Forms.Padding(4)
        Me.TVShowList.MultiSelect = false
        Me.TVShowList.Name = "TVShowList"
        Me.TVShowList.Size = New System.Drawing.Size(284, 750)
        Me.TVShowList.TabIndex = 19
        Me.TVShowList.UseCompatibleStateImageBehavior = false
        Me.TVShowList.View = System.Windows.Forms.View.Details
        '
        'FrmTabTvShows
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(1219, 845)
        Me.Controls.Add(Me.BtnNetworkBrowse)
        Me.Controls.Add(Me.cboTvShowNetwork)
        Me.Controls.Add(Me.btnRemoveTvShowGenre)
        Me.Controls.Add(Me.btnAddTvShowGenre)
        Me.Controls.Add(Me.TvShowGenresList)
        Me.Controls.Add(Me.TvShowPictureBox)
        Me.Controls.Add(Me.TVShowLabel)
        Me.Controls.Add(Me.SaveTVShow)
        Me.Controls.Add(Me.txtShowLocation)
        Me.Controls.Add(Me.txtShowName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TVShowList)
        Me.Name = "FrmTabTvShows"
        Me.Text = "FrmTabTvShows"
        CType(Me.TvShowPictureBox,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents BtnNetworkBrowse As Button
    Friend WithEvents cboTvShowNetwork As ComboBox
    Friend WithEvents btnRemoveTvShowGenre As Button
    Friend WithEvents btnAddTvShowGenre As Button
    Friend WithEvents TvShowGenresList As ListBox
    Friend WithEvents TvShowPictureBox As PictureBox
    Friend WithEvents TVShowLabel As Label
    Friend WithEvents SaveTVShow As Button
    Friend WithEvents txtShowLocation As TextBox
    Friend WithEvents txtShowName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TVShowList As ListView
End Class
