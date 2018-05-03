<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTvGenres
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
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.GenreList = New System.Windows.Forms.ListView()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.BtnAdd.Location = New System.Drawing.Point(35, 276)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(142, 28)
        Me.BtnAdd.TabIndex = 1
        Me.BtnAdd.Text = "Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'GenreList
        '
        Me.GenreList.Location = New System.Drawing.Point(4, 12)
        Me.GenreList.Name = "GenreList"
        Me.GenreList.Size = New System.Drawing.Size(208, 229)
        Me.GenreList.TabIndex = 2
        Me.GenreList.UseCompatibleStateImageBehavior = False
        Me.GenreList.View = System.Windows.Forms.View.Details
        '
        'Button2
        '
        Me.BtnNew.Location = New System.Drawing.Point(12, 247)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(51, 20)
        Me.BtnNew.TabIndex = 3
        Me.BtnNew.Text = "New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.BtnDelete.Location = New System.Drawing.Point(153, 247)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(51, 20)
        Me.BtnDelete.TabIndex = 4
        Me.BtnDelete.Text = "Del"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(216, 307)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.GenreList)
        Me.Controls.Add(Me.BtnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form2"
        Me.Text = "Add TV Genre(s)"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GenreList As System.Windows.Forms.ListView
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
End Class
