<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTabNetworksStudios
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
        Me.Label15 = New System.Windows.Forms.Label()
        Me.MovieNetworkListSubList = New System.Windows.Forms.ListBox()
        Me.MovieNetworkList = New System.Windows.Forms.ListView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.NetworkListSubList = New System.Windows.Forms.ListBox()
        Me.NetworkList = New System.Windows.Forms.ListView()
        Me.SuspendLayout
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Silver
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label15.Location = New System.Drawing.Point(625, 9)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(347, 25)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Movie Studios"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MovieNetworkListSubList
        '
        Me.MovieNetworkListSubList.FormattingEnabled = true
        Me.MovieNetworkListSubList.ItemHeight = 16
        Me.MovieNetworkListSubList.Location = New System.Drawing.Point(980, 38)
        Me.MovieNetworkListSubList.Margin = New System.Windows.Forms.Padding(4)
        Me.MovieNetworkListSubList.Name = "MovieNetworkListSubList"
        Me.MovieNetworkListSubList.Size = New System.Drawing.Size(263, 388)
        Me.MovieNetworkListSubList.TabIndex = 11
        '
        'MovieNetworkList
        '
        Me.MovieNetworkList.FullRowSelect = true
        Me.MovieNetworkList.HideSelection = false
        Me.MovieNetworkList.Location = New System.Drawing.Point(625, 38)
        Me.MovieNetworkList.Margin = New System.Windows.Forms.Padding(4)
        Me.MovieNetworkList.Name = "MovieNetworkList"
        Me.MovieNetworkList.Size = New System.Drawing.Size(347, 731)
        Me.MovieNetworkList.TabIndex = 10
        Me.MovieNetworkList.UseCompatibleStateImageBehavior = false
        Me.MovieNetworkList.View = System.Windows.Forms.View.Details
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Silver
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 9)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(333, 25)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "TV Networks"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NetworkListSubList
        '
        Me.NetworkListSubList.FormattingEnabled = true
        Me.NetworkListSubList.ItemHeight = 16
        Me.NetworkListSubList.Location = New System.Drawing.Point(354, 38)
        Me.NetworkListSubList.Margin = New System.Windows.Forms.Padding(4)
        Me.NetworkListSubList.Name = "NetworkListSubList"
        Me.NetworkListSubList.Size = New System.Drawing.Size(263, 388)
        Me.NetworkListSubList.TabIndex = 8
        '
        'NetworkList
        '
        Me.NetworkList.FullRowSelect = true
        Me.NetworkList.HideSelection = false
        Me.NetworkList.Location = New System.Drawing.Point(13, 38)
        Me.NetworkList.Margin = New System.Windows.Forms.Padding(4)
        Me.NetworkList.Name = "NetworkList"
        Me.NetworkList.Size = New System.Drawing.Size(333, 731)
        Me.NetworkList.TabIndex = 7
        Me.NetworkList.UseCompatibleStateImageBehavior = false
        Me.NetworkList.View = System.Windows.Forms.View.Details
        '
        'FrmTabNetworksStudios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(1376, 829)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.MovieNetworkListSubList)
        Me.Controls.Add(Me.MovieNetworkList)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.NetworkListSubList)
        Me.Controls.Add(Me.NetworkList)
        Me.Name = "FrmTabNetworksStudios"
        Me.Text = "FrmTabNetworksStudios"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents Label15 As Label
    Friend WithEvents MovieNetworkListSubList As ListBox
    Friend WithEvents MovieNetworkList As ListView
    Friend WithEvents Label14 As Label
    Friend WithEvents NetworkListSubList As ListBox
    Friend WithEvents NetworkList As ListView
End Class
