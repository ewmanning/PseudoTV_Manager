<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TVGuideSubMenu = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DontShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TVGuideShowName = New System.Windows.Forms.Label()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.NotShows = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SchedulingList = New System.Windows.Forms.ListView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.InterleavedList = New System.Windows.Forms.ListView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ResetDays = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ChannelName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ChkPlayInOrder = New System.Windows.Forms.CheckBox()
        Me.ChkPause = New System.Windows.Forms.CheckBox()
        Me.ChkWatched = New System.Windows.Forms.CheckBox()
        Me.ChkUnwatched = New System.Windows.Forms.CheckBox()
        Me.ChkIceLibrary = New System.Windows.Forms.CheckBox()
        Me.ChkResume = New System.Windows.Forms.CheckBox()
        Me.ChkRealTime = New System.Windows.Forms.CheckBox()
        Me.ChkRandom = New System.Windows.Forms.CheckBox()
        Me.chkDontPlayChannel = New System.Windows.Forms.CheckBox()
        Me.ChkLogo = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Option2 = New System.Windows.Forms.ComboBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PlayListLocation = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PlayListType = New System.Windows.Forms.ComboBox()
        Me.TVGuideList = New System.Windows.Forms.ListView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AaaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1.SuspendLayout
        Me.TabPage4.SuspendLayout
        Me.ContextMenuStrip1.SuspendLayout
        Me.StatusStrip1.SuspendLayout
        Me.MenuStrip1.SuspendLayout
        Me.SuspendLayout
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(0, 33)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1401, 953)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Gray
        Me.TabPage4.Controls.Add(Me.TVGuideSubMenu)
        Me.TabPage4.Controls.Add(Me.TVGuideShowName)
        Me.TabPage4.Controls.Add(Me.Button13)
        Me.TabPage4.Controls.Add(Me.Button14)
        Me.TabPage4.Controls.Add(Me.Button11)
        Me.TabPage4.Controls.Add(Me.Button12)
        Me.TabPage4.Controls.Add(Me.Button9)
        Me.TabPage4.Controls.Add(Me.Button10)
        Me.TabPage4.Controls.Add(Me.Button8)
        Me.TabPage4.Controls.Add(Me.Button7)
        Me.TabPage4.Controls.Add(Me.Button2)
        Me.TabPage4.Controls.Add(Me.NotShows)
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Controls.Add(Me.SchedulingList)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.InterleavedList)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.ResetDays)
        Me.TabPage4.Controls.Add(Me.Label10)
        Me.TabPage4.Controls.Add(Me.ChannelName)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.ChkPlayInOrder)
        Me.TabPage4.Controls.Add(Me.ChkPause)
        Me.TabPage4.Controls.Add(Me.ChkWatched)
        Me.TabPage4.Controls.Add(Me.ChkUnwatched)
        Me.TabPage4.Controls.Add(Me.ChkIceLibrary)
        Me.TabPage4.Controls.Add(Me.ChkResume)
        Me.TabPage4.Controls.Add(Me.ChkRealTime)
        Me.TabPage4.Controls.Add(Me.ChkRandom)
        Me.TabPage4.Controls.Add(Me.chkDontPlayChannel)
        Me.TabPage4.Controls.Add(Me.ChkLogo)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Controls.Add(Me.Option2)
        Me.TabPage4.Controls.Add(Me.Button5)
        Me.TabPage4.Controls.Add(Me.PlayListLocation)
        Me.TabPage4.Controls.Add(Me.Label6)
        Me.TabPage4.Controls.Add(Me.Label5)
        Me.TabPage4.Controls.Add(Me.PlayListType)
        Me.TabPage4.Controls.Add(Me.TVGuideList)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1393, 924)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "TV Guide"
        '
        'TVGuideSubMenu
        '
        Me.TVGuideSubMenu.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TVGuideSubMenu.Location = New System.Drawing.Point(199, 263)
        Me.TVGuideSubMenu.Margin = New System.Windows.Forms.Padding(4)
        Me.TVGuideSubMenu.Name = "TVGuideSubMenu"
        Me.TVGuideSubMenu.Size = New System.Drawing.Size(239, 372)
        Me.TVGuideSubMenu.TabIndex = 42
        Me.TVGuideSubMenu.UseCompatibleStateImageBehavior = false
        Me.TVGuideSubMenu.View = System.Windows.Forms.View.Details
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DontShowToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(155, 28)
        '
        'DontShowToolStripMenuItem
        '
        Me.DontShowToolStripMenuItem.Name = "DontShowToolStripMenuItem"
        Me.DontShowToolStripMenuItem.Size = New System.Drawing.Size(154, 24)
        Me.DontShowToolStripMenuItem.Text = "Don't Show"
        '
        'TVGuideShowName
        '
        Me.TVGuideShowName.AutoSize = true
        Me.TVGuideShowName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TVGuideShowName.Location = New System.Drawing.Point(208, 16)
        Me.TVGuideShowName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TVGuideShowName.Name = "TVGuideShowName"
        Me.TVGuideShowName.Size = New System.Drawing.Size(0, 29)
        Me.TVGuideShowName.TabIndex = 41
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(61, 762)
        Me.Button13.Margin = New System.Windows.Forms.Padding(4)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(49, 28)
        Me.Button13.TabIndex = 40
        Me.Button13.Text = "Del"
        Me.Button13.UseVisualStyleBackColor = true
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(4, 762)
        Me.Button14.Margin = New System.Windows.Forms.Padding(4)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(49, 28)
        Me.Button14.TabIndex = 39
        Me.Button14.Text = "Add"
        Me.Button14.UseVisualStyleBackColor = true
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(1032, 726)
        Me.Button11.Margin = New System.Windows.Forms.Padding(4)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(49, 28)
        Me.Button11.TabIndex = 38
        Me.Button11.Text = "Del"
        Me.Button11.UseVisualStyleBackColor = true
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(975, 726)
        Me.Button12.Margin = New System.Windows.Forms.Padding(4)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(49, 28)
        Me.Button12.TabIndex = 37
        Me.Button12.Text = "Add"
        Me.Button12.UseVisualStyleBackColor = true
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(763, 726)
        Me.Button9.Margin = New System.Windows.Forms.Padding(4)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(49, 28)
        Me.Button9.TabIndex = 36
        Me.Button9.Text = "Del"
        Me.Button9.UseVisualStyleBackColor = true
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(705, 726)
        Me.Button10.Margin = New System.Windows.Forms.Padding(4)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(49, 28)
        Me.Button10.TabIndex = 35
        Me.Button10.Text = "Add"
        Me.Button10.UseVisualStyleBackColor = true
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(508, 726)
        Me.Button8.Margin = New System.Windows.Forms.Padding(4)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(49, 28)
        Me.Button8.TabIndex = 34
        Me.Button8.Text = "Del"
        Me.Button8.UseVisualStyleBackColor = true
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(451, 726)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(49, 28)
        Me.Button7.TabIndex = 33
        Me.Button7.Text = "Add"
        Me.Button7.UseVisualStyleBackColor = true
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(236, 656)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(117, 41)
        Me.Button2.TabIndex = 32
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'NotShows
        '
        Me.NotShows.FormattingEnabled = true
        Me.NotShows.ItemHeight = 16
        Me.NotShows.Location = New System.Drawing.Point(975, 394)
        Me.NotShows.Margin = New System.Windows.Forms.Padding(4)
        Me.NotShows.Name = "NotShows"
        Me.NotShows.Size = New System.Drawing.Size(213, 324)
        Me.NotShows.TabIndex = 31
        '
        'Label12
        '
        Me.Label12.AutoSize = true
        Me.Label12.Location = New System.Drawing.Point(971, 374)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(176, 17)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Don't Include these shows:"
        '
        'SchedulingList
        '
        Me.SchedulingList.FullRowSelect = true
        Me.SchedulingList.Location = New System.Drawing.Point(705, 394)
        Me.SchedulingList.Margin = New System.Windows.Forms.Padding(4)
        Me.SchedulingList.Name = "SchedulingList"
        Me.SchedulingList.Size = New System.Drawing.Size(257, 324)
        Me.SchedulingList.TabIndex = 29
        Me.SchedulingList.UseCompatibleStateImageBehavior = false
        Me.SchedulingList.View = System.Windows.Forms.View.Details
        '
        'Label11
        '
        Me.Label11.AutoSize = true
        Me.Label11.Location = New System.Drawing.Point(737, 374)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 17)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Channel Scheduling"
        '
        'InterleavedList
        '
        Me.InterleavedList.FullRowSelect = true
        Me.InterleavedList.Location = New System.Drawing.Point(451, 393)
        Me.InterleavedList.Margin = New System.Windows.Forms.Padding(4)
        Me.InterleavedList.Name = "InterleavedList"
        Me.InterleavedList.Size = New System.Drawing.Size(249, 325)
        Me.InterleavedList.TabIndex = 27
        Me.InterleavedList.UseCompatibleStateImageBehavior = false
        Me.InterleavedList.View = System.Windows.Forms.View.Details
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Location = New System.Drawing.Point(447, 378)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 17)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Interleaved Channels"
        '
        'ResetDays
        '
        Me.ResetDays.Location = New System.Drawing.Point(595, 289)
        Me.ResetDays.Margin = New System.Windows.Forms.Padding(4)
        Me.ResetDays.Name = "ResetDays"
        Me.ResetDays.Size = New System.Drawing.Size(55, 22)
        Me.ResetDays.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Location = New System.Drawing.Point(449, 293)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(138, 17)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Reset Every X Days:"
        '
        'ChannelName
        '
        Me.ChannelName.Location = New System.Drawing.Point(325, 80)
        Me.ChannelName.Margin = New System.Windows.Forms.Padding(4)
        Me.ChannelName.Name = "ChannelName"
        Me.ChannelName.Size = New System.Drawing.Size(263, 22)
        Me.ChannelName.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label9.Location = New System.Drawing.Point(207, 74)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 29)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Name"
        '
        'ChkPlayInOrder
        '
        Me.ChkPlayInOrder.AutoSize = true
        Me.ChkPlayInOrder.Location = New System.Drawing.Point(808, 263)
        Me.ChkPlayInOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkPlayInOrder.Name = "ChkPlayInOrder"
        Me.ChkPlayInOrder.Size = New System.Drawing.Size(153, 21)
        Me.ChkPlayInOrder.TabIndex = 21
        Me.ChkPlayInOrder.Text = "Play shows in order"
        Me.ChkPlayInOrder.UseVisualStyleBackColor = true
        '
        'ChkPause
        '
        Me.ChkPause.AutoSize = true
        Me.ChkPause.Location = New System.Drawing.Point(808, 292)
        Me.ChkPause.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkPause.Name = "ChkPause"
        Me.ChkPause.Size = New System.Drawing.Size(190, 21)
        Me.ChkPause.TabIndex = 20
        Me.ChkPause.Text = "Pause when not watching"
        Me.ChkPause.UseVisualStyleBackColor = true
        '
        'ChkWatched
        '
        Me.ChkWatched.AutoSize = true
        Me.ChkWatched.Location = New System.Drawing.Point(973, 175)
        Me.ChkWatched.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkWatched.Name = "ChkWatched"
        Me.ChkWatched.Size = New System.Drawing.Size(145, 21)
        Me.ChkWatched.TabIndex = 19
        Me.ChkWatched.Text = "Only play watched"
        Me.ChkWatched.UseVisualStyleBackColor = true
        '
        'ChkUnwatched
        '
        Me.ChkUnwatched.AutoSize = true
        Me.ChkUnwatched.Location = New System.Drawing.Point(808, 175)
        Me.ChkUnwatched.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkUnwatched.Name = "ChkUnwatched"
        Me.ChkUnwatched.Size = New System.Drawing.Size(161, 21)
        Me.ChkUnwatched.TabIndex = 18
        Me.ChkUnwatched.Text = "Only play unwatched"
        Me.ChkUnwatched.UseVisualStyleBackColor = true
        '
        'ChkIceLibrary
        '
        Me.ChkIceLibrary.AutoSize = true
        Me.ChkIceLibrary.Location = New System.Drawing.Point(808, 235)
        Me.ChkIceLibrary.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkIceLibrary.Name = "ChkIceLibrary"
        Me.ChkIceLibrary.Size = New System.Drawing.Size(156, 21)
        Me.ChkIceLibrary.TabIndex = 17
        Me.ChkIceLibrary.Text = "IceLibrary Streams?"
        Me.ChkIceLibrary.UseVisualStyleBackColor = true
        '
        'ChkResume
        '
        Me.ChkResume.AutoSize = true
        Me.ChkResume.Location = New System.Drawing.Point(808, 112)
        Me.ChkResume.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkResume.Name = "ChkResume"
        Me.ChkResume.Size = New System.Drawing.Size(156, 21)
        Me.ChkResume.TabIndex = 16
        Me.ChkResume.Text = "Force resume mode"
        Me.ChkResume.UseVisualStyleBackColor = true
        '
        'ChkRealTime
        '
        Me.ChkRealTime.AutoSize = true
        Me.ChkRealTime.Location = New System.Drawing.Point(975, 84)
        Me.ChkRealTime.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkRealTime.Name = "ChkRealTime"
        Me.ChkRealTime.Size = New System.Drawing.Size(164, 21)
        Me.ChkRealTime.TabIndex = 15
        Me.ChkRealTime.Text = "Force real-time mode"
        Me.ChkRealTime.UseVisualStyleBackColor = true
        '
        'ChkRandom
        '
        Me.ChkRandom.AutoSize = true
        Me.ChkRandom.Location = New System.Drawing.Point(808, 84)
        Me.ChkRandom.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkRandom.Name = "ChkRandom"
        Me.ChkRandom.Size = New System.Drawing.Size(157, 21)
        Me.ChkRandom.TabIndex = 14
        Me.ChkRandom.Text = "Force random mode"
        Me.ChkRandom.UseVisualStyleBackColor = true
        '
        'chkDontPlayChannel
        '
        Me.chkDontPlayChannel.AutoSize = true
        Me.chkDontPlayChannel.Location = New System.Drawing.Point(973, 27)
        Me.chkDontPlayChannel.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDontPlayChannel.Name = "chkDontPlayChannel"
        Me.chkDontPlayChannel.Size = New System.Drawing.Size(173, 21)
        Me.chkDontPlayChannel.TabIndex = 13
        Me.chkDontPlayChannel.Text = "Don't play this channel"
        Me.chkDontPlayChannel.UseVisualStyleBackColor = true
        '
        'ChkLogo
        '
        Me.ChkLogo.AutoSize = true
        Me.ChkLogo.Location = New System.Drawing.Point(808, 27)
        Me.ChkLogo.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkLogo.Name = "ChkLogo"
        Me.ChkLogo.Size = New System.Drawing.Size(107, 21)
        Me.ChkLogo.TabIndex = 12
        Me.ChkLogo.Text = "Display logo"
        Me.ChkLogo.UseVisualStyleBackColor = true
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label8.Location = New System.Drawing.Point(191, 50)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 29)
        Me.Label8.TabIndex = 10
        '
        'Option2
        '
        Me.Option2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Option2.FormattingEnabled = true
        Me.Option2.Location = New System.Drawing.Point(325, 154)
        Me.Option2.Margin = New System.Windows.Forms.Padding(4)
        Me.Option2.Name = "Option2"
        Me.Option2.Size = New System.Drawing.Size(263, 24)
        Me.Option2.TabIndex = 9
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(596, 210)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(43, 25)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "..."
        Me.Button5.UseVisualStyleBackColor = true
        Me.Button5.Visible = false
        '
        'PlayListLocation
        '
        Me.PlayListLocation.Location = New System.Drawing.Point(325, 206)
        Me.PlayListLocation.Margin = New System.Windows.Forms.Padding(4)
        Me.PlayListLocation.Name = "PlayListLocation"
        Me.PlayListLocation.Size = New System.Drawing.Size(263, 22)
        Me.PlayListLocation.TabIndex = 5
        Me.PlayListLocation.Visible = false
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label6.Location = New System.Drawing.Point(205, 206)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 29)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Location:"
        Me.Label6.Visible = false
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label5.Location = New System.Drawing.Point(205, 121)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 29)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Type:"
        '
        'PlayListType
        '
        Me.PlayListType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PlayListType.FormattingEnabled = true
        Me.PlayListType.Items.AddRange(New Object() {"Playlist", "TV Network", "Movie Studio", "TV Genre", "Movie Genre", "Mixed Genre (Tv & Movie)", "TV Show", "Directory"})
        Me.PlayListType.Location = New System.Drawing.Point(325, 121)
        Me.PlayListType.Margin = New System.Windows.Forms.Padding(4)
        Me.PlayListType.Name = "PlayListType"
        Me.PlayListType.Size = New System.Drawing.Size(263, 24)
        Me.PlayListType.TabIndex = 2
        '
        'TVGuideList
        '
        Me.TVGuideList.FullRowSelect = true
        Me.TVGuideList.HideSelection = false
        Me.TVGuideList.Location = New System.Drawing.Point(4, 4)
        Me.TVGuideList.Margin = New System.Windows.Forms.Padding(4)
        Me.TVGuideList.Name = "TVGuideList"
        Me.TVGuideList.Size = New System.Drawing.Size(185, 750)
        Me.TVGuideList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.TVGuideList.TabIndex = 1
        Me.TVGuideList.UseCompatibleStateImageBehavior = false
        Me.TVGuideList.View = System.Windows.Forms.View.Details
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 863)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1257, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Status
        '
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(0, 17)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1257, 28)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AaaToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'AaaToolStripMenuItem
        '
        Me.AaaToolStripMenuItem.Name = "AaaToolStripMenuItem"
        Me.AaaToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.AaaToolStripMenuItem.Text = "Settings"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1257, 885)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "PseudoTV Manager"
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage4.ResumeLayout(false)
        Me.TabPage4.PerformLayout
        Me.ContextMenuStrip1.ResumeLayout(false)
        Me.StatusStrip1.ResumeLayout(false)
        Me.StatusStrip1.PerformLayout
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AaaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TVGuideList As System.Windows.Forms.ListView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PlayListType As System.Windows.Forms.ComboBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents PlayListLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Option2 As System.Windows.Forms.ComboBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ChannelName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChkPlayInOrder As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPause As System.Windows.Forms.CheckBox
    Friend WithEvents ChkWatched As System.Windows.Forms.CheckBox
    Friend WithEvents ChkUnwatched As System.Windows.Forms.CheckBox
    Friend WithEvents ChkIceLibrary As System.Windows.Forms.CheckBox
    Friend WithEvents ChkResume As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRealTime As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRandom As System.Windows.Forms.CheckBox
    Friend WithEvents chkDontPlayChannel As System.Windows.Forms.CheckBox
    Friend WithEvents ChkLogo As System.Windows.Forms.CheckBox
    Friend WithEvents ResetDays As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents InterleavedList As System.Windows.Forms.ListView
    Friend WithEvents NotShows As System.Windows.Forms.ListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SchedulingList As System.Windows.Forms.ListView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TVGuideShowName As System.Windows.Forms.Label
    Friend WithEvents TVGuideSubMenu As System.Windows.Forms.ListView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DontShowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
