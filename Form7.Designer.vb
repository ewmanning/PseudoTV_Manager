<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.lstGenres = New System.Windows.Forms.ListView()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'BtnDelete
        '
        Me.BtnDelete.Location = New System.Drawing.Point(204, 304)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(68, 25)
        Me.BtnDelete.TabIndex = 8
        Me.BtnDelete.Text = "Del"
        Me.BtnDelete.UseVisualStyleBackColor = true
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(16, 304)
        Me.BtnNew.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(68, 25)
        Me.BtnNew.TabIndex = 7
        Me.BtnNew.Text = "New"
        Me.BtnNew.UseVisualStyleBackColor = true
        '
        'GenreList
        '
        Me.lstGenres.Location = New System.Drawing.Point(5, 15)
        Me.lstGenres.Margin = New System.Windows.Forms.Padding(4)
        Me.lstGenres.Name = "lstGenres"
        Me.lstGenres.Size = New System.Drawing.Size(276, 281)
        Me.lstGenres.TabIndex = 6
        Me.lstGenres.UseCompatibleStateImageBehavior = false
        Me.lstGenres.View = System.Windows.Forms.View.Details
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(48, 336)
        Me.BtnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(189, 34)
        Me.BtnAdd.TabIndex = 5
        Me.BtnAdd.Text = "Add"
        Me.BtnAdd.UseVisualStyleBackColor = true
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 378)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.lstGenres)
        Me.Controls.Add(Me.BtnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form7"
        Me.Text = "Add Movie Genres"
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents lstGenres As System.Windows.Forms.ListView
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
End Class
