<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWebPageList
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lstWebPages = New System.Windows.Forms.ListBox()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.txtNewHtmlFileName = New System.Windows.Forms.TextBox()
        Me.txtNewHtmlFileTitle = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnOpenInMain = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(393, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(48, 22)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lstWebPages
        '
        Me.lstWebPages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstWebPages.FormattingEnabled = True
        Me.lstWebPages.Location = New System.Drawing.Point(12, 92)
        Me.lstWebPages.Name = "lstWebPages"
        Me.lstWebPages.Size = New System.Drawing.Size(429, 238)
        Me.lstWebPages.TabIndex = 9
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(12, 12)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(48, 22)
        Me.btnOpen.TabIndex = 10
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(66, 12)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(48, 22)
        Me.btnEdit.TabIndex = 11
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(12, 40)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(48, 22)
        Me.btnNew.TabIndex = 12
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'txtNewHtmlFileName
        '
        Me.txtNewHtmlFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewHtmlFileName.Location = New System.Drawing.Point(66, 41)
        Me.txtNewHtmlFileName.Name = "txtNewHtmlFileName"
        Me.txtNewHtmlFileName.Size = New System.Drawing.Size(375, 20)
        Me.txtNewHtmlFileName.TabIndex = 13
        '
        'txtNewHtmlFileTitle
        '
        Me.txtNewHtmlFileTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewHtmlFileTitle.Location = New System.Drawing.Point(66, 67)
        Me.txtNewHtmlFileTitle.Name = "txtNewHtmlFileTitle"
        Me.txtNewHtmlFileTitle.Size = New System.Drawing.Size(375, 20)
        Me.txtNewHtmlFileTitle.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Title:"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(120, 13)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(48, 22)
        Me.btnDelete.TabIndex = 16
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnOpenInMain
        '
        Me.btnOpenInMain.Location = New System.Drawing.Point(174, 13)
        Me.btnOpenInMain.Name = "btnOpenInMain"
        Me.btnOpenInMain.Size = New System.Drawing.Size(109, 22)
        Me.btnOpenInMain.TabIndex = 36
        Me.btnOpenInMain.Text = "Open in Main Form"
        Me.btnOpenInMain.UseVisualStyleBackColor = True
        '
        'btnHome
        '
        Me.btnHome.Location = New System.Drawing.Point(289, 13)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(48, 22)
        Me.btnHome.TabIndex = 37
        Me.btnHome.Text = "Home"
        Me.ToolTip1.SetToolTip(Me.btnHome, "Open the Start Page on the Main form")
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'frmWebPageList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 346)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnOpenInMain)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNewHtmlFileTitle)
        Me.Controls.Add(Me.txtNewHtmlFileName)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.lstWebPages)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmWebPageList"
        Me.Text = "Workflow Web Pages"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents lstWebPages As ListBox
    Friend WithEvents btnOpen As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents txtNewHtmlFileName As TextBox
    Friend WithEvents txtNewHtmlFileTitle As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnOpenInMain As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
