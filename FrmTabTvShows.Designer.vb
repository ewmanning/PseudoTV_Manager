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
        Me.Button19 = New System.Windows.Forms.Button()
        Me.BtnNetworkBrowse = New System.Windows.Forms.Button()
        Me.txtShowNetwork = New System.Windows.Forms.ComboBox()
        Me.btnDeleteTvShowGenre = New System.Windows.Forms.Button()
        Me.btnAddTvShowGenre = New System.Windows.Forms.Button()
        Me.ListTVGenres = New System.Windows.Forms.ListBox()
        Me.TVShowPictureBox = New System.Windows.Forms.PictureBox()
        Me.TVShowLabel = New System.Windows.Forms.Label()
        Me.SaveTVShow = New System.Windows.Forms.Button()
        Me.txtShowLocation = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtShowName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TVShowList = New System.Windows.Forms.ListView()
        CType(Me.TVShowPictureBox,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(521, 165)
        Me.Button19.Margin = New System.Windows.Forms.Padding(4)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(77, 33)
        Me.Button19.TabIndex = 35
        Me.Button19.Text = "Button19"
        Me.Button19.UseVisualStyleBackColor = true
        '
        'BtnNetworkBrowse
        '
        Me.BtnNetworkBrowse.Location = New System.Drawing.Point(877, 64)
        Me.BtnNetworkBrowse.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNetworkBrowse.Name = "BtnNetworkBrowse"
        Me.BtnNetworkBrowse.Size = New System.Drawing.Size(41, 36)
        Me.BtnNetworkBrowse.TabIndex = 34
        Me.BtnNetworkBrowse.Text = "..."
        Me.BtnNetworkBrowse.UseVisualStyleBackColor = true
        '
        'txtShowNetwork
        '
        Me.txtShowNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtShowNetwork.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtShowNetwork.FormattingEnabled = true
        Me.txtShowNetwork.Location = New System.Drawing.Point(518, 64)
        Me.txtShowNetwork.Margin = New System.Windows.Forms.Padding(4)
        Me.txtShowNetwork.Name = "txtShowNetwork"
        Me.txtShowNetwork.Size = New System.Drawing.Size(349, 33)
        Me.txtShowNetwork.TabIndex = 33
        '
        'btnDeleteTvShowGenre
        '
        Me.btnDeleteTvShowGenre.Location = New System.Drawing.Point(608, 253)
        Me.btnDeleteTvShowGenre.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeleteTvShowGenre.Name = "btnDeleteTvShowGenre"
        Me.btnDeleteTvShowGenre.Size = New System.Drawing.Size(49, 26)
        Me.btnDeleteTvShowGenre.TabIndex = 32
        Me.btnDeleteTvShowGenre.Text = "Del"
        Me.btnDeleteTvShowGenre.UseVisualStyleBackColor = true
        '
        'btnAddTvShowGenre
        '
        Me.btnAddTvShowGenre.Location = New System.Drawing.Point(550, 253)
        Me.btnAddTvShowGenre.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddTvShowGenre.Name = "btnAddTvShowGenre"
        Me.btnAddTvShowGenre.Size = New System.Drawing.Size(49, 26)
        Me.btnAddTvShowGenre.TabIndex = 31
        Me.btnAddTvShowGenre.Text = "Add"
        Me.btnAddTvShowGenre.UseVisualStyleBackColor = true
        '
        'ListTVGenres
        '
        Me.ListTVGenres.FormattingEnabled = true
        Me.ListTVGenres.ItemHeight = 16
        Me.ListTVGenres.Location = New System.Drawing.Point(306, 282)
        Me.ListTVGenres.Margin = New System.Windows.Forms.Padding(4)
        Me.ListTVGenres.Name = "ListTVGenres"
        Me.ListTVGenres.Size = New System.Drawing.Size(352, 244)
        Me.ListTVGenres.TabIndex = 30
        '
        'TVShowPictureBox
        '
        Me.TVShowPictureBox.Location = New System.Drawing.Point(777, 253)
        Me.TVShowPictureBox.Margin = New System.Windows.Forms.Padding(4)
        Me.TVShowPictureBox.Name = "TVShowPictureBox"
        Me.TVShowPictureBox.Size = New System.Drawing.Size(403, 510)
        Me.TVShowPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TVShowPictureBox.TabIndex = 29
        Me.TVShowPictureBox.TabStop = false
        '
        'TVShowLabel
        '
        Me.TVShowLabel.AutoSize = true
        Me.TVShowLabel.Location = New System.Drawing.Point(921, 36)
        Me.TVShowLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TVShowLabel.Name = "TVShowLabel"
        Me.TVShowLabel.Size = New System.Drawing.Size(51, 17)
        Me.TVShowLabel.TabIndex = 28
        Me.TVShowLabel.Text = "Label5"
        Me.TVShowLabel.Visible = false
        '
        'SaveTVShow
        '
        Me.SaveTVShow.Location = New System.Drawing.Point(762, 151)
        Me.SaveTVShow.Margin = New System.Windows.Forms.Padding(4)
        Me.SaveTVShow.Name = "SaveTVShow"
        Me.SaveTVShow.Size = New System.Drawing.Size(107, 37)
        Me.SaveTVShow.TabIndex = 27
        Me.SaveTVShow.Text = "Save"
        Me.SaveTVShow.UseVisualStyleBackColor = true
        '
        'txtShowLocation
        '
        Me.txtShowLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtShowLocation.Location = New System.Drawing.Point(518, 111)
        Me.txtShowLocation.Margin = New System.Windows.Forms.Padding(4)
        Me.txtShowLocation.Name = "txtShowLocation"
        Me.txtShowLocation.Size = New System.Drawing.Size(503, 26)
        Me.txtShowLocation.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.Location = New System.Drawing.Point(306, 106)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 36)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Location"
        '
        'TxtShowName
        '
        Me.TxtShowName.Enabled = false
        Me.TxtShowName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TxtShowName.Location = New System.Drawing.Point(518, 20)
        Me.TxtShowName.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtShowName.Name = "TxtShowName"
        Me.TxtShowName.Size = New System.Drawing.Size(347, 30)
        Me.TxtShowName.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(306, 64)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 36)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Network"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(308, 243)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 36)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Genres"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.Location = New System.Drawing.Point(306, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 36)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Show Name"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 771)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 25)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = true
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
        Me.Controls.Add(Me.Button19)
        Me.Controls.Add(Me.BtnNetworkBrowse)
        Me.Controls.Add(Me.txtShowNetwork)
        Me.Controls.Add(Me.btnDeleteTvShowGenre)
        Me.Controls.Add(Me.btnAddTvShowGenre)
        Me.Controls.Add(Me.ListTVGenres)
        Me.Controls.Add(Me.TVShowPictureBox)
        Me.Controls.Add(Me.TVShowLabel)
        Me.Controls.Add(Me.SaveTVShow)
        Me.Controls.Add(Me.txtShowLocation)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtShowName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TVShowList)
        Me.Name = "FrmTabTvShows"
        Me.Text = "FrmTabTvShows"
        CType(Me.TVShowPictureBox,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents Button19 As Button
    Friend WithEvents BtnNetworkBrowse As Button
    Friend WithEvents txtShowNetwork As ComboBox
    Friend WithEvents btnDeleteTvShowGenre As Button
    Friend WithEvents btnAddTvShowGenre As Button
    Friend WithEvents ListTVGenres As ListBox
    Friend WithEvents TVShowPictureBox As PictureBox
    Friend WithEvents TVShowLabel As Label
    Friend WithEvents SaveTVShow As Button
    Friend WithEvents txtShowLocation As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtShowName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TVShowList As ListView
End Class
