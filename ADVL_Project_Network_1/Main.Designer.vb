<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAppInfo = New System.Windows.Forms.Button()
        Me.btnProject = New System.Windows.Forms.Button()
        Me.btnMessages = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage15 = New System.Windows.Forms.TabPage()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.trvProjTree = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1_OpenProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.btnShowChildProjectInfo = New System.Windows.Forms.Button()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1_EditWorkflowTabPage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1_ShowStartPageInWorkflowTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtDirName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.txtFindNodeProjID = New System.Windows.Forms.TextBox()
        Me.btnFindNode = New System.Windows.Forms.Button()
        Me.txtNodeIndex = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnOpenPath = New System.Windows.Forms.Button()
        Me.txtPTProjCreationDate = New System.Windows.Forms.TextBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.txtPTProjParentProjectPath = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.txtPTProjRelativePath = New System.Windows.Forms.TextBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.txtPTProjParentProjectID = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.txtPTProjParentProjectName = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtPTProjAppName = New System.Windows.Forms.TextBox()
        Me.txtPTProjID = New System.Windows.Forms.TextBox()
        Me.txtPTProjPath = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtPTProjType = New System.Windows.Forms.TextBox()
        Me.txtPTProjName = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.btnMovePTNodeDown = New System.Windows.Forms.Button()
        Me.btnMovePTNodeUp = New System.Windows.Forms.Button()
        Me.chkConnect1 = New System.Windows.Forms.CheckBox()
        Me.btnStartProject = New System.Windows.Forms.Button()
        Me.btnDeleteProjNode = New System.Windows.Forms.Button()
        Me.txtPTProjDescription = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtPTProjNodeKey = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.txtNewChildParentID = New System.Windows.Forms.TextBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.txtNewChildParentText = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.txtNewChildParentName = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txtAuthorDescription = New System.Windows.Forms.TextBox()
        Me.txtAuthorContact = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtAuthorName = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.txtProjectDirectoryRelativePath = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.btnCreateDirectoryProject = New System.Windows.Forms.Button()
        Me.txtProjectDirectoryName = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.txtProjectArchiveRelativePath = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.btnCreateArchiveProject = New System.Windows.Forms.Button()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.txtProjectArchiveName = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.TabPage11 = New System.Windows.Forms.TabPage()
        Me.txtHPDataLocn = New System.Windows.Forms.TabControl()
        Me.TabPage12 = New System.Windows.Forms.TabPage()
        Me.txtHybridProjectRelativePath = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.btnCreateHybridProject = New System.Windows.Forms.Button()
        Me.txtHPDirectoryName = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.TabPage14 = New System.Windows.Forms.TabPage()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.cmbHPSettingsType = New System.Windows.Forms.ComboBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.txtHPSettingsName = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.TabPage13 = New System.Windows.Forms.TabPage()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.cmbHPDataType = New System.Windows.Forms.ComboBox()
        Me.txtHPDataName = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.TabPage16 = New System.Windows.Forms.TabPage()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.cmbHPSystemType = New System.Windows.Forms.ComboBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.txtHPSystemName = New System.Windows.Forms.TextBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.cmbNewChildProjectApplication = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cmbNewChildProjectType = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtNewChildProjectDescription = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtNewChildProjectName = New System.Windows.Forms.TextBox()
        Me.pbOpenAppDirIcon = New System.Windows.Forms.PictureBox()
        Me.pbAppDirIcon = New System.Windows.Forms.PictureBox()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.trvAppTree = New System.Windows.Forms.TreeView()
        Me.btnGetAppInfo = New System.Windows.Forms.Button()
        Me.txtAppName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtNodeText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAddApplication = New System.Windows.Forms.Button()
        Me.btnMoveDown = New System.Windows.Forms.Button()
        Me.btnMoveUp = New System.Windows.Forms.Button()
        Me.chkConnect2 = New System.Windows.Forms.CheckBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.txtRelativePath = New System.Windows.Forms.TextBox()
        Me.btnAddToProjTree = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtProjID = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtParentProjectID = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtApplicationName = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtParentProjectName = New System.Windows.Forms.TextBox()
        Me.txtProjPath = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtProjType = New System.Windows.Forms.TextBox()
        Me.txtProjName = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtAppDirectory = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtExePath2 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtItemType = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnDeleteNode = New System.Windows.Forms.Button()
        Me.pbOpenIcon = New System.Windows.Forms.PictureBox()
        Me.pbIcon = New System.Windows.Forms.PictureBox()
        Me.txtOpenIconNo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtIconNo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtItemDescription = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtNodeKey = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkConnect = New System.Windows.Forms.CheckBox()
        Me.btnOpenProject = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtProjectPath = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtProNetName = New System.Windows.Forms.TextBox()
        Me.btnOpenAppDir = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnOpenSystem = New System.Windows.Forms.Button()
        Me.btnOpenData = New System.Windows.Forms.Button()
        Me.btnOpenSettings = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtParentProject = New System.Windows.Forms.TextBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.btnParameters = New System.Windows.Forms.Button()
        Me.btnCheckComNet = New System.Windows.Forms.Button()
        Me.btnSetUpComNetClient = New System.Windows.Forms.Button()
        Me.btnGetComNetAppInfo = New System.Windows.Forms.Button()
        Me.btnGetAppList = New System.Windows.Forms.Button()
        Me.btnGetConnectionList = New System.Windows.Forms.Button()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.txtSystemLocationType = New System.Windows.Forms.TextBox()
        Me.txtSystemPath = New System.Windows.Forms.TextBox()
        Me.txtCurrentDuration = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTotalDuration = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtLastUsed = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCreationDate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDataPath = New System.Windows.Forms.TextBox()
        Me.txtDataLocationType = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSettingsPath = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSettingsLocationType = New System.Windows.Forms.TextBox()
        Me.txtProjectType = New System.Windows.Forms.TextBox()
        Me.txtProjectDescription = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProjectName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.AppTreeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ProjectIconImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ProjTreeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtOpenProjectName = New System.Windows.Forms.TextBox()
        Me.btnOnline = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.btnWebPages = New System.Windows.Forms.Button()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.btnAndorville = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage15.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        Me.TabPage10.SuspendLayout()
        Me.TabPage11.SuspendLayout()
        Me.txtHPDataLocn.SuspendLayout()
        Me.TabPage12.SuspendLayout()
        Me.TabPage14.SuspendLayout()
        Me.TabPage13.SuspendLayout()
        Me.TabPage16.SuspendLayout()
        CType(Me.pbOpenAppDirIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAppDirIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbOpenIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(1033, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAppInfo
        '
        Me.btnAppInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAppInfo.Location = New System.Drawing.Point(792, 12)
        Me.btnAppInfo.Name = "btnAppInfo"
        Me.btnAppInfo.Size = New System.Drawing.Size(95, 22)
        Me.btnAppInfo.TabIndex = 46
        Me.btnAppInfo.Text = "Application Info"
        Me.ToolTip1.SetToolTip(Me.btnAppInfo, "Show information about the Application Network application.")
        Me.btnAppInfo.UseVisualStyleBackColor = True
        '
        'btnProject
        '
        Me.btnProject.Location = New System.Drawing.Point(6, 6)
        Me.btnProject.Name = "btnProject"
        Me.btnProject.Size = New System.Drawing.Size(72, 22)
        Me.btnProject.TabIndex = 48
        Me.btnProject.Text = "Project List"
        Me.ToolTip1.SetToolTip(Me.btnProject, "Select or create a project.")
        Me.btnProject.UseVisualStyleBackColor = True
        '
        'btnMessages
        '
        Me.btnMessages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMessages.Location = New System.Drawing.Point(893, 12)
        Me.btnMessages.Name = "btnMessages"
        Me.btnMessages.Size = New System.Drawing.Size(72, 22)
        Me.btnMessages.TabIndex = 49
        Me.btnMessages.Text = "Messages"
        Me.btnMessages.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage15)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1085, 708)
        Me.TabControl1.TabIndex = 50
        '
        'TabPage15
        '
        Me.TabPage15.Controls.Add(Me.WebBrowser1)
        Me.TabPage15.Location = New System.Drawing.Point(4, 22)
        Me.TabPage15.Name = "TabPage15"
        Me.TabPage15.Size = New System.Drawing.Size(1077, 585)
        Me.TabPage15.TabIndex = 7
        Me.TabPage15.Text = "Workflow"
        Me.TabPage15.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(3, 3)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1071, 579)
        Me.WebBrowser1.TabIndex = 67
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.SplitContainer2)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(1077, 682)
        Me.TabPage5.TabIndex = 6
        Me.TabPage5.Text = "Project Tree"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.trvProjTree)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TabControl2)
        Me.SplitContainer2.Size = New System.Drawing.Size(1077, 682)
        Me.SplitContainer2.SplitterDistance = 354
        Me.SplitContainer2.TabIndex = 0
        '
        'trvProjTree
        '
        Me.trvProjTree.AllowDrop = True
        Me.trvProjTree.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvProjTree.ContextMenuStrip = Me.ContextMenuStrip1
        Me.trvProjTree.ItemHeight = 36
        Me.trvProjTree.Location = New System.Drawing.Point(3, 3)
        Me.trvProjTree.Name = "trvProjTree"
        Me.trvProjTree.Size = New System.Drawing.Size(348, 676)
        Me.trvProjTree.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1_OpenProject})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(144, 26)
        '
        'ToolStripMenuItem1_OpenProject
        '
        Me.ToolStripMenuItem1_OpenProject.Name = "ToolStripMenuItem1_OpenProject"
        Me.ToolStripMenuItem1_OpenProject.Size = New System.Drawing.Size(143, 22)
        Me.ToolStripMenuItem1_OpenProject.Text = "Open Project"
        '
        'TabControl2
        '
        Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.TabPage7)
        Me.TabControl2.Controls.Add(Me.TabPage8)
        Me.TabControl2.Location = New System.Drawing.Point(3, 3)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(713, 676)
        Me.TabControl2.TabIndex = 53
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.btnShowChildProjectInfo)
        Me.TabPage7.Controls.Add(Me.txtDirName)
        Me.TabPage7.Controls.Add(Me.Label5)
        Me.TabPage7.Controls.Add(Me.Label78)
        Me.TabPage7.Controls.Add(Me.txtFindNodeProjID)
        Me.TabPage7.Controls.Add(Me.btnFindNode)
        Me.TabPage7.Controls.Add(Me.txtNodeIndex)
        Me.TabPage7.Controls.Add(Me.Label53)
        Me.TabPage7.Controls.Add(Me.GroupBox3)
        Me.TabPage7.Controls.Add(Me.btnMovePTNodeDown)
        Me.TabPage7.Controls.Add(Me.btnMovePTNodeUp)
        Me.TabPage7.Controls.Add(Me.chkConnect1)
        Me.TabPage7.Controls.Add(Me.btnStartProject)
        Me.TabPage7.Controls.Add(Me.btnDeleteProjNode)
        Me.TabPage7.Controls.Add(Me.txtPTProjDescription)
        Me.TabPage7.Controls.Add(Me.Label33)
        Me.TabPage7.Controls.Add(Me.txtPTProjNodeKey)
        Me.TabPage7.Controls.Add(Me.Label34)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(705, 553)
        Me.TabPage7.TabIndex = 0
        Me.TabPage7.Text = "Project Information"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'btnShowChildProjectInfo
        '
        Me.btnShowChildProjectInfo.ContextMenuStrip = Me.ContextMenuStrip2
        Me.btnShowChildProjectInfo.Location = New System.Drawing.Point(9, 505)
        Me.btnShowChildProjectInfo.Name = "btnShowChildProjectInfo"
        Me.btnShowChildProjectInfo.Size = New System.Drawing.Size(129, 22)
        Me.btnShowChildProjectInfo.TabIndex = 298
        Me.btnShowChildProjectInfo.Text = "Show Child Project Info"
        Me.btnShowChildProjectInfo.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1_EditWorkflowTabPage, Me.ToolStripMenuItem1_ShowStartPageInWorkflowTab})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(248, 48)
        '
        'ToolStripMenuItem1_EditWorkflowTabPage
        '
        Me.ToolStripMenuItem1_EditWorkflowTabPage.Name = "ToolStripMenuItem1_EditWorkflowTabPage"
        Me.ToolStripMenuItem1_EditWorkflowTabPage.Size = New System.Drawing.Size(247, 22)
        Me.ToolStripMenuItem1_EditWorkflowTabPage.Text = "Edit Workflow Tab Page"
        '
        'ToolStripMenuItem1_ShowStartPageInWorkflowTab
        '
        Me.ToolStripMenuItem1_ShowStartPageInWorkflowTab.Name = "ToolStripMenuItem1_ShowStartPageInWorkflowTab"
        Me.ToolStripMenuItem1_ShowStartPageInWorkflowTab.Size = New System.Drawing.Size(247, 22)
        Me.ToolStripMenuItem1_ShowStartPageInWorkflowTab.Text = "Show Start Page In Workflow Tab"
        '
        'txtDirName
        '
        Me.txtDirName.Location = New System.Drawing.Point(114, 477)
        Me.txtDirName.Name = "txtDirName"
        Me.txtDirName.Size = New System.Drawing.Size(346, 20)
        Me.txtDirName.TabIndex = 297
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 480)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 296
        Me.Label5.Text = "Directory Name:"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(6, 324)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(57, 13)
        Me.Label78.TabIndex = 295
        Me.Label78.Text = "Project ID:"
        '
        'txtFindNodeProjID
        '
        Me.txtFindNodeProjID.Location = New System.Drawing.Point(3, 340)
        Me.txtFindNodeProjID.Name = "txtFindNodeProjID"
        Me.txtFindNodeProjID.Size = New System.Drawing.Size(82, 20)
        Me.txtFindNodeProjID.TabIndex = 294
        '
        'btnFindNode
        '
        Me.btnFindNode.Location = New System.Drawing.Point(3, 299)
        Me.btnFindNode.Name = "btnFindNode"
        Me.btnFindNode.Size = New System.Drawing.Size(82, 22)
        Me.btnFindNode.TabIndex = 293
        Me.btnFindNode.Text = "Find Node"
        Me.ToolTip1.SetToolTip(Me.btnFindNode, "Start the application selected in the Applications list.")
        Me.btnFindNode.UseVisualStyleBackColor = True
        '
        'txtNodeIndex
        '
        Me.txtNodeIndex.Location = New System.Drawing.Point(6, 249)
        Me.txtNodeIndex.Name = "txtNodeIndex"
        Me.txtNodeIndex.Size = New System.Drawing.Size(76, 20)
        Me.txtNodeIndex.TabIndex = 292
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(6, 233)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(64, 13)
        Me.Label53.TabIndex = 291
        Me.Label53.Text = "Node index:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnOpenPath)
        Me.GroupBox3.Controls.Add(Me.txtPTProjCreationDate)
        Me.GroupBox3.Controls.Add(Me.Label77)
        Me.GroupBox3.Controls.Add(Me.txtPTProjParentProjectPath)
        Me.GroupBox3.Controls.Add(Me.Label76)
        Me.GroupBox3.Controls.Add(Me.txtPTProjRelativePath)
        Me.GroupBox3.Controls.Add(Me.Label62)
        Me.GroupBox3.Controls.Add(Me.txtPTProjParentProjectID)
        Me.GroupBox3.Controls.Add(Me.Label61)
        Me.GroupBox3.Controls.Add(Me.txtPTProjParentProjectName)
        Me.GroupBox3.Controls.Add(Me.Label60)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.Label35)
        Me.GroupBox3.Controls.Add(Me.txtPTProjAppName)
        Me.GroupBox3.Controls.Add(Me.txtPTProjID)
        Me.GroupBox3.Controls.Add(Me.txtPTProjPath)
        Me.GroupBox3.Controls.Add(Me.Label39)
        Me.GroupBox3.Controls.Add(Me.Label40)
        Me.GroupBox3.Controls.Add(Me.txtPTProjType)
        Me.GroupBox3.Controls.Add(Me.txtPTProjName)
        Me.GroupBox3.Controls.Add(Me.Label41)
        Me.GroupBox3.Location = New System.Drawing.Point(88, 83)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(611, 377)
        Me.GroupBox3.TabIndex = 290
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Project:"
        '
        'btnOpenPath
        '
        Me.btnOpenPath.Location = New System.Drawing.Point(6, 88)
        Me.btnOpenPath.Name = "btnOpenPath"
        Me.btnOpenPath.Size = New System.Drawing.Size(48, 22)
        Me.btnOpenPath.TabIndex = 303
        Me.btnOpenPath.Text = "Open"
        Me.btnOpenPath.UseVisualStyleBackColor = True
        '
        'txtPTProjCreationDate
        '
        Me.txtPTProjCreationDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPTProjCreationDate.Location = New System.Drawing.Point(117, 169)
        Me.txtPTProjCreationDate.Name = "txtPTProjCreationDate"
        Me.txtPTProjCreationDate.Size = New System.Drawing.Size(488, 20)
        Me.txtPTProjCreationDate.TabIndex = 298
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(6, 172)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(73, 13)
        Me.Label77.TabIndex = 297
        Me.Label77.Text = "Creation date:"
        '
        'txtPTProjParentProjectPath
        '
        Me.txtPTProjParentProjectPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPTProjParentProjectPath.Location = New System.Drawing.Point(117, 274)
        Me.txtPTProjParentProjectPath.Multiline = True
        Me.txtPTProjParentProjectPath.Name = "txtPTProjParentProjectPath"
        Me.txtPTProjParentProjectPath.Size = New System.Drawing.Size(488, 88)
        Me.txtPTProjParentProjectPath.TabIndex = 296
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(7, 277)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(100, 13)
        Me.Label76.TabIndex = 295
        Me.Label76.Text = "Parent project path:"
        '
        'txtPTProjRelativePath
        '
        Me.txtPTProjRelativePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPTProjRelativePath.Location = New System.Drawing.Point(117, 143)
        Me.txtPTProjRelativePath.Name = "txtPTProjRelativePath"
        Me.txtPTProjRelativePath.Size = New System.Drawing.Size(488, 20)
        Me.txtPTProjRelativePath.TabIndex = 294
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(6, 146)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(73, 13)
        Me.Label62.TabIndex = 293
        Me.Label62.Text = "Relative path:"
        '
        'txtPTProjParentProjectID
        '
        Me.txtPTProjParentProjectID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPTProjParentProjectID.Location = New System.Drawing.Point(117, 248)
        Me.txtPTProjParentProjectID.Name = "txtPTProjParentProjectID"
        Me.txtPTProjParentProjectID.Size = New System.Drawing.Size(488, 20)
        Me.txtPTProjParentProjectID.TabIndex = 292
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(6, 251)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(90, 13)
        Me.Label61.TabIndex = 291
        Me.Label61.Text = "Parent project ID:"
        '
        'txtPTProjParentProjectName
        '
        Me.txtPTProjParentProjectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPTProjParentProjectName.Location = New System.Drawing.Point(117, 222)
        Me.txtPTProjParentProjectName.Name = "txtPTProjParentProjectName"
        Me.txtPTProjParentProjectName.Size = New System.Drawing.Size(488, 20)
        Me.txtPTProjParentProjectName.TabIndex = 290
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(6, 225)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(105, 13)
        Me.Label60.TabIndex = 289
        Me.Label60.Text = "Parent project name:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(6, 198)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(91, 13)
        Me.Label32.TabIndex = 286
        Me.Label32.Text = "Application name:"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(156, 44)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(21, 13)
        Me.Label35.TabIndex = 288
        Me.Label35.Text = "ID:"
        '
        'txtPTProjAppName
        '
        Me.txtPTProjAppName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPTProjAppName.Location = New System.Drawing.Point(117, 195)
        Me.txtPTProjAppName.Name = "txtPTProjAppName"
        Me.txtPTProjAppName.Size = New System.Drawing.Size(488, 20)
        Me.txtPTProjAppName.TabIndex = 285
        '
        'txtPTProjID
        '
        Me.txtPTProjID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPTProjID.Location = New System.Drawing.Point(183, 41)
        Me.txtPTProjID.Name = "txtPTProjID"
        Me.txtPTProjID.Size = New System.Drawing.Size(422, 20)
        Me.txtPTProjID.TabIndex = 287
        '
        'txtPTProjPath
        '
        Me.txtPTProjPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPTProjPath.Location = New System.Drawing.Point(60, 67)
        Me.txtPTProjPath.Multiline = True
        Me.txtPTProjPath.Name = "txtPTProjPath"
        Me.txtPTProjPath.Size = New System.Drawing.Size(545, 70)
        Me.txtPTProjPath.TabIndex = 276
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(6, 70)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(32, 13)
        Me.Label39.TabIndex = 275
        Me.Label39.Text = "Path:"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(6, 44)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(34, 13)
        Me.Label40.TabIndex = 274
        Me.Label40.Text = "Type:"
        '
        'txtPTProjType
        '
        Me.txtPTProjType.Location = New System.Drawing.Point(50, 41)
        Me.txtPTProjType.Name = "txtPTProjType"
        Me.txtPTProjType.Size = New System.Drawing.Size(100, 20)
        Me.txtPTProjType.TabIndex = 273
        '
        'txtPTProjName
        '
        Me.txtPTProjName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPTProjName.Location = New System.Drawing.Point(50, 15)
        Me.txtPTProjName.Name = "txtPTProjName"
        Me.txtPTProjName.Size = New System.Drawing.Size(555, 20)
        Me.txtPTProjName.TabIndex = 272
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(6, 18)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(38, 13)
        Me.Label41.TabIndex = 271
        Me.Label41.Text = "Name:"
        '
        'btnMovePTNodeDown
        '
        Me.btnMovePTNodeDown.Location = New System.Drawing.Point(9, 199)
        Me.btnMovePTNodeDown.Name = "btnMovePTNodeDown"
        Me.btnMovePTNodeDown.Size = New System.Drawing.Size(73, 22)
        Me.btnMovePTNodeDown.TabIndex = 289
        Me.btnMovePTNodeDown.Text = "Move Down"
        Me.btnMovePTNodeDown.UseVisualStyleBackColor = True
        '
        'btnMovePTNodeUp
        '
        Me.btnMovePTNodeUp.Location = New System.Drawing.Point(9, 171)
        Me.btnMovePTNodeUp.Name = "btnMovePTNodeUp"
        Me.btnMovePTNodeUp.Size = New System.Drawing.Size(73, 22)
        Me.btnMovePTNodeUp.TabIndex = 288
        Me.btnMovePTNodeUp.Text = "Move Up"
        Me.btnMovePTNodeUp.UseVisualStyleBackColor = True
        '
        'chkConnect1
        '
        Me.chkConnect1.AutoSize = True
        Me.chkConnect1.Location = New System.Drawing.Point(9, 120)
        Me.chkConnect1.Name = "chkConnect1"
        Me.chkConnect1.Size = New System.Drawing.Size(66, 17)
        Me.chkConnect1.TabIndex = 287
        Me.chkConnect1.Text = "Connect"
        Me.ToolTip1.SetToolTip(Me.chkConnect1, "Connect to the AppNet when the application starts")
        Me.chkConnect1.UseVisualStyleBackColor = True
        '
        'btnStartProject
        '
        Me.btnStartProject.Location = New System.Drawing.Point(9, 92)
        Me.btnStartProject.Name = "btnStartProject"
        Me.btnStartProject.Size = New System.Drawing.Size(73, 22)
        Me.btnStartProject.TabIndex = 286
        Me.btnStartProject.Text = "Start"
        Me.ToolTip1.SetToolTip(Me.btnStartProject, "Start the application selected in the Applications list.")
        Me.btnStartProject.UseVisualStyleBackColor = True
        '
        'btnDeleteProjNode
        '
        Me.btnDeleteProjNode.Location = New System.Drawing.Point(9, 143)
        Me.btnDeleteProjNode.Name = "btnDeleteProjNode"
        Me.btnDeleteProjNode.Size = New System.Drawing.Size(73, 22)
        Me.btnDeleteProjNode.TabIndex = 285
        Me.btnDeleteProjNode.Text = "Delete"
        Me.btnDeleteProjNode.UseVisualStyleBackColor = True
        '
        'txtPTProjDescription
        '
        Me.txtPTProjDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPTProjDescription.Location = New System.Drawing.Point(88, 32)
        Me.txtPTProjDescription.Multiline = True
        Me.txtPTProjDescription.Name = "txtPTProjDescription"
        Me.txtPTProjDescription.Size = New System.Drawing.Size(611, 45)
        Me.txtPTProjDescription.TabIndex = 284
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(6, 35)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(63, 13)
        Me.Label33.TabIndex = 283
        Me.Label33.Text = "Description:"
        '
        'txtPTProjNodeKey
        '
        Me.txtPTProjNodeKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPTProjNodeKey.Location = New System.Drawing.Point(88, 6)
        Me.txtPTProjNodeKey.Name = "txtPTProjNodeKey"
        Me.txtPTProjNodeKey.Size = New System.Drawing.Size(611, 20)
        Me.txtPTProjNodeKey.TabIndex = 282
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(6, 9)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(56, 13)
        Me.Label34.TabIndex = 281
        Me.Label34.Text = "Node key:"
        Me.ToolTip1.SetToolTip(Me.Label34, "The is also the document file name")
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.txtNewChildParentID)
        Me.TabPage8.Controls.Add(Me.Label65)
        Me.TabPage8.Controls.Add(Me.txtNewChildParentText)
        Me.TabPage8.Controls.Add(Me.Label64)
        Me.TabPage8.Controls.Add(Me.txtNewChildParentName)
        Me.TabPage8.Controls.Add(Me.Label59)
        Me.TabPage8.Controls.Add(Me.GroupBox4)
        Me.TabPage8.Controls.Add(Me.TabControl3)
        Me.TabPage8.Controls.Add(Me.Label44)
        Me.TabPage8.Controls.Add(Me.Label43)
        Me.TabPage8.Controls.Add(Me.cmbNewChildProjectApplication)
        Me.TabPage8.Controls.Add(Me.Label42)
        Me.TabPage8.Controls.Add(Me.cmbNewChildProjectType)
        Me.TabPage8.Controls.Add(Me.Label38)
        Me.TabPage8.Controls.Add(Me.Label37)
        Me.TabPage8.Controls.Add(Me.txtNewChildProjectDescription)
        Me.TabPage8.Controls.Add(Me.Label36)
        Me.TabPage8.Controls.Add(Me.txtNewChildProjectName)
        Me.TabPage8.Controls.Add(Me.pbOpenAppDirIcon)
        Me.TabPage8.Controls.Add(Me.pbAppDirIcon)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(705, 650)
        Me.TabPage8.TabIndex = 1
        Me.TabPage8.Text = "Create Child Project"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'txtNewChildParentID
        '
        Me.txtNewChildParentID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewChildParentID.Location = New System.Drawing.Point(117, 348)
        Me.txtNewChildParentID.Name = "txtNewChildParentID"
        Me.txtNewChildParentID.ReadOnly = True
        Me.txtNewChildParentID.Size = New System.Drawing.Size(582, 20)
        Me.txtNewChildParentID.TabIndex = 304
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(6, 351)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(90, 13)
        Me.Label65.TabIndex = 303
        Me.Label65.Text = "Parent project ID:"
        '
        'txtNewChildParentText
        '
        Me.txtNewChildParentText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewChildParentText.Location = New System.Drawing.Point(117, 322)
        Me.txtNewChildParentText.Name = "txtNewChildParentText"
        Me.txtNewChildParentText.ReadOnly = True
        Me.txtNewChildParentText.Size = New System.Drawing.Size(582, 20)
        Me.txtNewChildParentText.TabIndex = 302
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(6, 325)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(96, 13)
        Me.Label64.TabIndex = 301
        Me.Label64.Text = "Parent project text:"
        '
        'txtNewChildParentName
        '
        Me.txtNewChildParentName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewChildParentName.Location = New System.Drawing.Point(117, 296)
        Me.txtNewChildParentName.Name = "txtNewChildParentName"
        Me.txtNewChildParentName.ReadOnly = True
        Me.txtNewChildParentName.Size = New System.Drawing.Size(582, 20)
        Me.txtNewChildParentName.TabIndex = 300
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(6, 299)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(105, 13)
        Me.Label59.TabIndex = 299
        Me.Label59.Text = "Parent project name:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label45)
        Me.GroupBox4.Controls.Add(Me.txtAuthorDescription)
        Me.GroupBox4.Controls.Add(Me.txtAuthorContact)
        Me.GroupBox4.Controls.Add(Me.Label46)
        Me.GroupBox4.Controls.Add(Me.txtAuthorName)
        Me.GroupBox4.Controls.Add(Me.Label48)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 160)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(693, 130)
        Me.GroupBox4.TabIndex = 298
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Author:"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(6, 48)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(63, 13)
        Me.Label45.TabIndex = 36
        Me.Label45.Text = "Description:"
        '
        'txtAuthorDescription
        '
        Me.txtAuthorDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAuthorDescription.Location = New System.Drawing.Point(84, 45)
        Me.txtAuthorDescription.Multiline = True
        Me.txtAuthorDescription.Name = "txtAuthorDescription"
        Me.txtAuthorDescription.Size = New System.Drawing.Size(603, 50)
        Me.txtAuthorDescription.TabIndex = 33
        '
        'txtAuthorContact
        '
        Me.txtAuthorContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAuthorContact.Location = New System.Drawing.Point(84, 101)
        Me.txtAuthorContact.Name = "txtAuthorContact"
        Me.txtAuthorContact.Size = New System.Drawing.Size(603, 20)
        Me.txtAuthorContact.TabIndex = 32
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(6, 104)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(47, 13)
        Me.Label46.TabIndex = 31
        Me.Label46.Text = "Contact:"
        '
        'txtAuthorName
        '
        Me.txtAuthorName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAuthorName.Location = New System.Drawing.Point(84, 19)
        Me.txtAuthorName.Name = "txtAuthorName"
        Me.txtAuthorName.Size = New System.Drawing.Size(603, 20)
        Me.txtAuthorName.TabIndex = 30
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(6, 22)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(38, 13)
        Me.Label48.TabIndex = 29
        Me.Label48.Text = "Name:"
        '
        'TabControl3
        '
        Me.TabControl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl3.Controls.Add(Me.TabPage9)
        Me.TabControl3.Controls.Add(Me.TabPage10)
        Me.TabControl3.Controls.Add(Me.TabPage11)
        Me.TabControl3.Location = New System.Drawing.Point(6, 383)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(690, 261)
        Me.TabControl3.TabIndex = 297
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.txtProjectDirectoryRelativePath)
        Me.TabPage9.Controls.Add(Me.Label66)
        Me.TabPage9.Controls.Add(Me.btnCreateDirectoryProject)
        Me.TabPage9.Controls.Add(Me.txtProjectDirectoryName)
        Me.TabPage9.Controls.Add(Me.Label47)
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage9.Size = New System.Drawing.Size(682, 138)
        Me.TabPage9.TabIndex = 0
        Me.TabPage9.Text = "Directory Project"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'txtProjectDirectoryRelativePath
        '
        Me.txtProjectDirectoryRelativePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectDirectoryRelativePath.Location = New System.Drawing.Point(127, 32)
        Me.txtProjectDirectoryRelativePath.Name = "txtProjectDirectoryRelativePath"
        Me.txtProjectDirectoryRelativePath.ReadOnly = True
        Me.txtProjectDirectoryRelativePath.Size = New System.Drawing.Size(549, 20)
        Me.txtProjectDirectoryRelativePath.TabIndex = 296
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(6, 35)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(73, 13)
        Me.Label66.TabIndex = 295
        Me.Label66.Text = "Relative path:"
        '
        'btnCreateDirectoryProject
        '
        Me.btnCreateDirectoryProject.Location = New System.Drawing.Point(6, 56)
        Me.btnCreateDirectoryProject.Name = "btnCreateDirectoryProject"
        Me.btnCreateDirectoryProject.Size = New System.Drawing.Size(73, 22)
        Me.btnCreateDirectoryProject.TabIndex = 294
        Me.btnCreateDirectoryProject.Text = "Create"
        Me.ToolTip1.SetToolTip(Me.btnCreateDirectoryProject, "Create the child project.")
        Me.btnCreateDirectoryProject.UseVisualStyleBackColor = True
        '
        'txtProjectDirectoryName
        '
        Me.txtProjectDirectoryName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectDirectoryName.Location = New System.Drawing.Point(127, 6)
        Me.txtProjectDirectoryName.Name = "txtProjectDirectoryName"
        Me.txtProjectDirectoryName.Size = New System.Drawing.Size(549, 20)
        Me.txtProjectDirectoryName.TabIndex = 30
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(6, 9)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(115, 13)
        Me.Label47.TabIndex = 29
        Me.Label47.Text = "Project directory name:"
        '
        'TabPage10
        '
        Me.TabPage10.Controls.Add(Me.txtProjectArchiveRelativePath)
        Me.TabPage10.Controls.Add(Me.Label67)
        Me.TabPage10.Controls.Add(Me.btnCreateArchiveProject)
        Me.TabPage10.Controls.Add(Me.Label49)
        Me.TabPage10.Controls.Add(Me.txtProjectArchiveName)
        Me.TabPage10.Controls.Add(Me.Label50)
        Me.TabPage10.Location = New System.Drawing.Point(4, 22)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage10.Size = New System.Drawing.Size(682, 138)
        Me.TabPage10.TabIndex = 1
        Me.TabPage10.Text = "Archive Project"
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'txtProjectArchiveRelativePath
        '
        Me.txtProjectArchiveRelativePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectArchiveRelativePath.Location = New System.Drawing.Point(122, 32)
        Me.txtProjectArchiveRelativePath.Name = "txtProjectArchiveRelativePath"
        Me.txtProjectArchiveRelativePath.ReadOnly = True
        Me.txtProjectArchiveRelativePath.Size = New System.Drawing.Size(562, 20)
        Me.txtProjectArchiveRelativePath.TabIndex = 298
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(6, 35)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(73, 13)
        Me.Label67.TabIndex = 297
        Me.Label67.Text = "Relative path:"
        '
        'btnCreateArchiveProject
        '
        Me.btnCreateArchiveProject.Location = New System.Drawing.Point(6, 56)
        Me.btnCreateArchiveProject.Name = "btnCreateArchiveProject"
        Me.btnCreateArchiveProject.Size = New System.Drawing.Size(73, 22)
        Me.btnCreateArchiveProject.TabIndex = 295
        Me.btnCreateArchiveProject.Text = "Create"
        Me.ToolTip1.SetToolTip(Me.btnCreateArchiveProject, "Create the child project.")
        Me.btnCreateArchiveProject.UseVisualStyleBackColor = True
        '
        'Label49
        '
        Me.Label49.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(620, 9)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(64, 13)
        Me.Label49.TabIndex = 40
        Me.Label49.Text = ".AdvlProject"
        '
        'txtProjectArchiveName
        '
        Me.txtProjectArchiveName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectArchiveName.Location = New System.Drawing.Point(122, 6)
        Me.txtProjectArchiveName.Name = "txtProjectArchiveName"
        Me.txtProjectArchiveName.Size = New System.Drawing.Size(492, 20)
        Me.txtProjectArchiveName.TabIndex = 39
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(6, 9)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(110, 13)
        Me.Label50.TabIndex = 38
        Me.Label50.Text = "Project archive name:"
        '
        'TabPage11
        '
        Me.TabPage11.Controls.Add(Me.txtHPDataLocn)
        Me.TabPage11.Location = New System.Drawing.Point(4, 22)
        Me.TabPage11.Name = "TabPage11"
        Me.TabPage11.Size = New System.Drawing.Size(682, 235)
        Me.TabPage11.TabIndex = 2
        Me.TabPage11.Text = "Hybrid Project"
        Me.TabPage11.UseVisualStyleBackColor = True
        '
        'txtHPDataLocn
        '
        Me.txtHPDataLocn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHPDataLocn.Controls.Add(Me.TabPage12)
        Me.txtHPDataLocn.Controls.Add(Me.TabPage14)
        Me.txtHPDataLocn.Controls.Add(Me.TabPage13)
        Me.txtHPDataLocn.Controls.Add(Me.TabPage16)
        Me.txtHPDataLocn.Location = New System.Drawing.Point(3, 3)
        Me.txtHPDataLocn.Name = "txtHPDataLocn"
        Me.txtHPDataLocn.SelectedIndex = 0
        Me.txtHPDataLocn.Size = New System.Drawing.Size(684, 229)
        Me.txtHPDataLocn.TabIndex = 0
        '
        'TabPage12
        '
        Me.TabPage12.Controls.Add(Me.txtHybridProjectRelativePath)
        Me.TabPage12.Controls.Add(Me.Label68)
        Me.TabPage12.Controls.Add(Me.btnCreateHybridProject)
        Me.TabPage12.Controls.Add(Me.txtHPDirectoryName)
        Me.TabPage12.Controls.Add(Me.Label52)
        Me.TabPage12.Location = New System.Drawing.Point(4, 22)
        Me.TabPage12.Name = "TabPage12"
        Me.TabPage12.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage12.Size = New System.Drawing.Size(676, 203)
        Me.TabPage12.TabIndex = 0
        Me.TabPage12.Text = "Project Directory"
        Me.TabPage12.UseVisualStyleBackColor = True
        '
        'txtHybridProjectRelativePath
        '
        Me.txtHybridProjectRelativePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHybridProjectRelativePath.Location = New System.Drawing.Point(124, 32)
        Me.txtHybridProjectRelativePath.Name = "txtHybridProjectRelativePath"
        Me.txtHybridProjectRelativePath.ReadOnly = True
        Me.txtHybridProjectRelativePath.Size = New System.Drawing.Size(546, 20)
        Me.txtHybridProjectRelativePath.TabIndex = 298
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(3, 35)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(73, 13)
        Me.Label68.TabIndex = 297
        Me.Label68.Text = "Relative path:"
        '
        'btnCreateHybridProject
        '
        Me.btnCreateHybridProject.Location = New System.Drawing.Point(6, 56)
        Me.btnCreateHybridProject.Name = "btnCreateHybridProject"
        Me.btnCreateHybridProject.Size = New System.Drawing.Size(73, 22)
        Me.btnCreateHybridProject.TabIndex = 295
        Me.btnCreateHybridProject.Text = "Create"
        Me.ToolTip1.SetToolTip(Me.btnCreateHybridProject, "Create the child project.")
        Me.btnCreateHybridProject.UseVisualStyleBackColor = True
        '
        'txtHPDirectoryName
        '
        Me.txtHPDirectoryName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHPDirectoryName.Location = New System.Drawing.Point(124, 6)
        Me.txtHPDirectoryName.Name = "txtHPDirectoryName"
        Me.txtHPDirectoryName.Size = New System.Drawing.Size(546, 20)
        Me.txtHPDirectoryName.TabIndex = 39
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(3, 9)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(115, 13)
        Me.Label52.TabIndex = 38
        Me.Label52.Text = "Project directory name:"
        '
        'TabPage14
        '
        Me.TabPage14.Controls.Add(Me.Label74)
        Me.TabPage14.Controls.Add(Me.cmbHPSettingsType)
        Me.TabPage14.Controls.Add(Me.Label70)
        Me.TabPage14.Controls.Add(Me.txtHPSettingsName)
        Me.TabPage14.Controls.Add(Me.Label69)
        Me.TabPage14.Location = New System.Drawing.Point(4, 22)
        Me.TabPage14.Name = "TabPage14"
        Me.TabPage14.Size = New System.Drawing.Size(676, 203)
        Me.TabPage14.TabIndex = 2
        Me.TabPage14.Text = "Settings"
        Me.TabPage14.UseVisualStyleBackColor = True
        '
        'Label74
        '
        Me.Label74.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(650, 9)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(23, 13)
        Me.Label74.TabIndex = 290
        Me.Label74.Text = ".zip"
        '
        'cmbHPSettingsType
        '
        Me.cmbHPSettingsType.FormattingEnabled = True
        Me.cmbHPSettingsType.Location = New System.Drawing.Point(124, 32)
        Me.cmbHPSettingsType.Name = "cmbHPSettingsType"
        Me.cmbHPSettingsType.Size = New System.Drawing.Size(135, 21)
        Me.cmbHPSettingsType.TabIndex = 289
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(5, 35)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(111, 13)
        Me.Label70.TabIndex = 288
        Me.Label70.Text = "Settings location type:"
        '
        'txtHPSettingsName
        '
        Me.txtHPSettingsName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHPSettingsName.Location = New System.Drawing.Point(124, 6)
        Me.txtHPSettingsName.Name = "txtHPSettingsName"
        Me.txtHPSettingsName.Size = New System.Drawing.Size(520, 20)
        Me.txtHPSettingsName.TabIndex = 44
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(5, 9)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(117, 13)
        Me.Label69.TabIndex = 43
        Me.Label69.Text = "Settings location name:"
        '
        'TabPage13
        '
        Me.TabPage13.Controls.Add(Me.Label73)
        Me.TabPage13.Controls.Add(Me.cmbHPDataType)
        Me.TabPage13.Controls.Add(Me.txtHPDataName)
        Me.TabPage13.Controls.Add(Me.Label57)
        Me.TabPage13.Controls.Add(Me.Label58)
        Me.TabPage13.Location = New System.Drawing.Point(4, 22)
        Me.TabPage13.Name = "TabPage13"
        Me.TabPage13.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage13.Size = New System.Drawing.Size(676, 203)
        Me.TabPage13.TabIndex = 1
        Me.TabPage13.Text = "Data"
        Me.TabPage13.UseVisualStyleBackColor = True
        '
        'Label73
        '
        Me.Label73.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(650, 9)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(23, 13)
        Me.Label73.TabIndex = 288
        Me.Label73.Text = ".zip"
        '
        'cmbHPDataType
        '
        Me.cmbHPDataType.FormattingEnabled = True
        Me.cmbHPDataType.Location = New System.Drawing.Point(124, 32)
        Me.cmbHPDataType.Name = "cmbHPDataType"
        Me.cmbHPDataType.Size = New System.Drawing.Size(135, 21)
        Me.cmbHPDataType.TabIndex = 287
        '
        'txtHPDataName
        '
        Me.txtHPDataName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHPDataName.Location = New System.Drawing.Point(124, 6)
        Me.txtHPDataName.Name = "txtHPDataName"
        Me.txtHPDataName.Size = New System.Drawing.Size(520, 20)
        Me.txtHPDataName.TabIndex = 42
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(6, 35)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(96, 13)
        Me.Label57.TabIndex = 41
        Me.Label57.Text = "Data location type:"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(6, 9)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(102, 13)
        Me.Label58.TabIndex = 40
        Me.Label58.Text = "Data location name:"
        '
        'TabPage16
        '
        Me.TabPage16.Controls.Add(Me.Label75)
        Me.TabPage16.Controls.Add(Me.cmbHPSystemType)
        Me.TabPage16.Controls.Add(Me.Label71)
        Me.TabPage16.Controls.Add(Me.txtHPSystemName)
        Me.TabPage16.Controls.Add(Me.Label72)
        Me.TabPage16.Location = New System.Drawing.Point(4, 22)
        Me.TabPage16.Name = "TabPage16"
        Me.TabPage16.Size = New System.Drawing.Size(676, 203)
        Me.TabPage16.TabIndex = 3
        Me.TabPage16.Text = "System"
        Me.TabPage16.UseVisualStyleBackColor = True
        '
        'Label75
        '
        Me.Label75.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(650, 9)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(23, 13)
        Me.Label75.TabIndex = 294
        Me.Label75.Text = ".zip"
        '
        'cmbHPSystemType
        '
        Me.cmbHPSystemType.FormattingEnabled = True
        Me.cmbHPSystemType.Location = New System.Drawing.Point(124, 32)
        Me.cmbHPSystemType.Name = "cmbHPSystemType"
        Me.cmbHPSystemType.Size = New System.Drawing.Size(135, 21)
        Me.cmbHPSystemType.TabIndex = 293
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(5, 35)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(107, 13)
        Me.Label71.TabIndex = 292
        Me.Label71.Text = "System location type:"
        '
        'txtHPSystemName
        '
        Me.txtHPSystemName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHPSystemName.Location = New System.Drawing.Point(124, 6)
        Me.txtHPSystemName.Name = "txtHPSystemName"
        Me.txtHPSystemName.Size = New System.Drawing.Size(520, 20)
        Me.txtHPSystemName.TabIndex = 291
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(5, 9)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(113, 13)
        Me.Label72.TabIndex = 290
        Me.Label72.Text = "System location name:"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(342, 120)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(94, 13)
        Me.Label44.TabIndex = 292
        Me.Label44.Text = "Open project icon:"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(200, 120)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(66, 13)
        Me.Label43.TabIndex = 291
        Me.Label43.Text = "Project icon:"
        '
        'cmbNewChildProjectApplication
        '
        Me.cmbNewChildProjectApplication.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbNewChildProjectApplication.FormattingEnabled = True
        Me.cmbNewChildProjectApplication.Location = New System.Drawing.Point(75, 93)
        Me.cmbNewChildProjectApplication.Name = "cmbNewChildProjectApplication"
        Me.cmbNewChildProjectApplication.Size = New System.Drawing.Size(624, 21)
        Me.cmbNewChildProjectApplication.TabIndex = 288
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(6, 96)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(62, 13)
        Me.Label42.TabIndex = 287
        Me.Label42.Text = "Application:"
        '
        'cmbNewChildProjectType
        '
        Me.cmbNewChildProjectType.FormattingEnabled = True
        Me.cmbNewChildProjectType.Location = New System.Drawing.Point(75, 120)
        Me.cmbNewChildProjectType.Name = "cmbNewChildProjectType"
        Me.cmbNewChildProjectType.Size = New System.Drawing.Size(101, 21)
        Me.cmbNewChildProjectType.TabIndex = 286
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(6, 123)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(34, 13)
        Me.Label38.TabIndex = 285
        Me.Label38.Text = "Type:"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 35)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(63, 13)
        Me.Label37.TabIndex = 284
        Me.Label37.Text = "Description:"
        '
        'txtNewChildProjectDescription
        '
        Me.txtNewChildProjectDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewChildProjectDescription.Location = New System.Drawing.Point(75, 32)
        Me.txtNewChildProjectDescription.Multiline = True
        Me.txtNewChildProjectDescription.Name = "txtNewChildProjectDescription"
        Me.txtNewChildProjectDescription.Size = New System.Drawing.Size(624, 55)
        Me.txtNewChildProjectDescription.TabIndex = 283
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(6, 9)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(38, 13)
        Me.Label36.TabIndex = 282
        Me.Label36.Text = "Name:"
        '
        'txtNewChildProjectName
        '
        Me.txtNewChildProjectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewChildProjectName.Location = New System.Drawing.Point(75, 6)
        Me.txtNewChildProjectName.Name = "txtNewChildProjectName"
        Me.txtNewChildProjectName.Size = New System.Drawing.Size(624, 20)
        Me.txtNewChildProjectName.TabIndex = 281
        '
        'pbOpenAppDirIcon
        '
        Me.pbOpenAppDirIcon.Location = New System.Drawing.Point(442, 120)
        Me.pbOpenAppDirIcon.Name = "pbOpenAppDirIcon"
        Me.pbOpenAppDirIcon.Size = New System.Drawing.Size(64, 34)
        Me.pbOpenAppDirIcon.TabIndex = 290
        Me.pbOpenAppDirIcon.TabStop = False
        '
        'pbAppDirIcon
        '
        Me.pbAppDirIcon.Location = New System.Drawing.Point(272, 120)
        Me.pbAppDirIcon.Name = "pbAppDirIcon"
        Me.pbAppDirIcon.Size = New System.Drawing.Size(64, 34)
        Me.pbAppDirIcon.TabIndex = 289
        Me.pbAppDirIcon.TabStop = False
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.SplitContainer1)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(1077, 585)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Application Tree"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.trvAppTree)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnGetAppInfo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtAppName)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnUpdate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtNodeText)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnAddApplication)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnMoveDown)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnMoveUp)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkConnect2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnStart)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtItemType)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnDeleteNode)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pbOpenIcon)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pbIcon)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtOpenIconNo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtIconNo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtItemDescription)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label27)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtNodeKey)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label22)
        Me.SplitContainer1.Size = New System.Drawing.Size(1071, 579)
        Me.SplitContainer1.SplitterDistance = 479
        Me.SplitContainer1.TabIndex = 1
        '
        'trvAppTree
        '
        Me.trvAppTree.AllowDrop = True
        Me.trvAppTree.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvAppTree.ItemHeight = 36
        Me.trvAppTree.Location = New System.Drawing.Point(3, 3)
        Me.trvAppTree.Name = "trvAppTree"
        Me.trvAppTree.Size = New System.Drawing.Size(473, 573)
        Me.trvAppTree.TabIndex = 0
        '
        'btnGetAppInfo
        '
        Me.btnGetAppInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetAppInfo.Location = New System.Drawing.Point(515, 551)
        Me.btnGetAppInfo.Name = "btnGetAppInfo"
        Me.btnGetAppInfo.Size = New System.Drawing.Size(60, 22)
        Me.btnGetAppInfo.TabIndex = 296
        Me.btnGetAppInfo.Text = "Get Info"
        Me.btnGetAppInfo.UseVisualStyleBackColor = True
        '
        'txtAppName
        '
        Me.txtAppName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAppName.Location = New System.Drawing.Point(125, 553)
        Me.txtAppName.Name = "txtAppName"
        Me.txtAppName.Size = New System.Drawing.Size(383, 20)
        Me.txtAppName.TabIndex = 295
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 556)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 294
        Me.Label2.Text = "Application name:"
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Location = New System.Drawing.Point(521, 262)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(60, 22)
        Me.btnUpdate.TabIndex = 293
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtNodeText
        '
        Me.txtNodeText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNodeText.Location = New System.Drawing.Point(225, 263)
        Me.txtNodeText.Name = "txtNodeText"
        Me.txtNodeText.Size = New System.Drawing.Size(290, 20)
        Me.txtNodeText.TabIndex = 292
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(163, 266)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 291
        Me.Label1.Text = "Node text:"
        '
        'btnAddApplication
        '
        Me.btnAddApplication.Location = New System.Drawing.Point(7, 262)
        Me.btnAddApplication.Name = "btnAddApplication"
        Me.btnAddApplication.Size = New System.Drawing.Size(145, 22)
        Me.btnAddApplication.TabIndex = 290
        Me.btnAddApplication.Text = "Add or Update Application"
        Me.btnAddApplication.UseVisualStyleBackColor = True
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Location = New System.Drawing.Point(7, 215)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(73, 22)
        Me.btnMoveDown.TabIndex = 274
        Me.btnMoveDown.Text = "Move Down"
        Me.btnMoveDown.UseVisualStyleBackColor = True
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Location = New System.Drawing.Point(7, 187)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(73, 22)
        Me.btnMoveUp.TabIndex = 273
        Me.btnMoveUp.Text = "Move Up"
        Me.btnMoveUp.UseVisualStyleBackColor = True
        '
        'chkConnect2
        '
        Me.chkConnect2.AutoSize = True
        Me.chkConnect2.Location = New System.Drawing.Point(7, 136)
        Me.chkConnect2.Name = "chkConnect2"
        Me.chkConnect2.Size = New System.Drawing.Size(66, 17)
        Me.chkConnect2.TabIndex = 272
        Me.chkConnect2.Text = "Connect"
        Me.ToolTip1.SetToolTip(Me.chkConnect2, "Connect to the AppNet when the application starts")
        Me.chkConnect2.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(7, 108)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(73, 22)
        Me.btnStart.TabIndex = 271
        Me.btnStart.Text = "Start"
        Me.ToolTip1.SetToolTip(Me.btnStart, "Start the application selected in the Applications list.")
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label63)
        Me.GroupBox2.Controls.Add(Me.txtRelativePath)
        Me.GroupBox2.Controls.Add(Me.btnAddToProjTree)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.txtProjID)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.txtParentProjectID)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.txtApplicationName)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtParentProjectName)
        Me.GroupBox2.Controls.Add(Me.txtProjPath)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtProjType)
        Me.GroupBox2.Controls.Add(Me.txtProjName)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 293)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(574, 254)
        Me.GroupBox2.TabIndex = 270
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Project:"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(7, 226)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(73, 13)
        Me.Label63.TabIndex = 291
        Me.Label63.Text = "Relative path:"
        '
        'txtRelativePath
        '
        Me.txtRelativePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRelativePath.Location = New System.Drawing.Point(118, 223)
        Me.txtRelativePath.Name = "txtRelativePath"
        Me.txtRelativePath.Size = New System.Drawing.Size(450, 20)
        Me.txtRelativePath.TabIndex = 290
        '
        'btnAddToProjTree
        '
        Me.btnAddToProjTree.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddToProjTree.Location = New System.Drawing.Point(461, 195)
        Me.btnAddToProjTree.Name = "btnAddToProjTree"
        Me.btnAddToProjTree.Size = New System.Drawing.Size(107, 22)
        Me.btnAddToProjTree.TabIndex = 289
        Me.btnAddToProjTree.Text = "Add to Project Tree"
        Me.btnAddToProjTree.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(156, 44)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(21, 13)
        Me.Label23.TabIndex = 288
        Me.Label23.Text = "ID:"
        '
        'txtProjID
        '
        Me.txtProjID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjID.Location = New System.Drawing.Point(183, 41)
        Me.txtProjID.Name = "txtProjID"
        Me.txtProjID.Size = New System.Drawing.Size(385, 20)
        Me.txtProjID.TabIndex = 287
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(7, 198)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(90, 13)
        Me.Label21.TabIndex = 286
        Me.Label21.Text = "Parent project ID:"
        '
        'txtParentProjectID
        '
        Me.txtParentProjectID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtParentProjectID.Location = New System.Drawing.Point(118, 195)
        Me.txtParentProjectID.Name = "txtParentProjectID"
        Me.txtParentProjectID.Size = New System.Drawing.Size(337, 20)
        Me.txtParentProjectID.TabIndex = 285
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 146)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(91, 13)
        Me.Label24.TabIndex = 284
        Me.Label24.Text = "Application name:"
        '
        'txtApplicationName
        '
        Me.txtApplicationName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApplicationName.Location = New System.Drawing.Point(118, 143)
        Me.txtApplicationName.Name = "txtApplicationName"
        Me.txtApplicationName.Size = New System.Drawing.Size(450, 20)
        Me.txtApplicationName.TabIndex = 283
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 172)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(105, 13)
        Me.Label20.TabIndex = 278
        Me.Label20.Text = "Parent project name:"
        '
        'txtParentProjectName
        '
        Me.txtParentProjectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtParentProjectName.Location = New System.Drawing.Point(118, 169)
        Me.txtParentProjectName.Name = "txtParentProjectName"
        Me.txtParentProjectName.Size = New System.Drawing.Size(450, 20)
        Me.txtParentProjectName.TabIndex = 277
        '
        'txtProjPath
        '
        Me.txtProjPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjPath.Location = New System.Drawing.Point(50, 67)
        Me.txtProjPath.Multiline = True
        Me.txtProjPath.Name = "txtProjPath"
        Me.txtProjPath.Size = New System.Drawing.Size(518, 70)
        Me.txtProjPath.TabIndex = 276
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 70)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(32, 13)
        Me.Label19.TabIndex = 275
        Me.Label19.Text = "Path:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(34, 13)
        Me.Label18.TabIndex = 274
        Me.Label18.Text = "Type:"
        '
        'txtProjType
        '
        Me.txtProjType.Location = New System.Drawing.Point(50, 41)
        Me.txtProjType.Name = "txtProjType"
        Me.txtProjType.Size = New System.Drawing.Size(100, 20)
        Me.txtProjType.TabIndex = 273
        '
        'txtProjName
        '
        Me.txtProjName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjName.Location = New System.Drawing.Point(50, 15)
        Me.txtProjName.Name = "txtProjName"
        Me.txtProjName.Size = New System.Drawing.Size(518, 20)
        Me.txtProjName.TabIndex = 272
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 271
        Me.Label17.Text = "Name:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.txtAppDirectory)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtExePath2)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(86, 122)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(495, 134)
        Me.GroupBox1.TabIndex = 269
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Application:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(23, 32)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(31, 13)
        Me.Label25.TabIndex = 272
        Me.Label25.Text = "path:"
        '
        'txtAppDirectory
        '
        Me.txtAppDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAppDirectory.Location = New System.Drawing.Point(72, 74)
        Me.txtAppDirectory.Multiline = True
        Me.txtAppDirectory.Name = "txtAppDirectory"
        Me.txtAppDirectory.Size = New System.Drawing.Size(417, 52)
        Me.txtAppDirectory.TabIndex = 271
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 77)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 270
        Me.Label16.Text = "Directory:"
        '
        'txtExePath2
        '
        Me.txtExePath2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExePath2.Location = New System.Drawing.Point(71, 16)
        Me.txtExePath2.Multiline = True
        Me.txtExePath2.Name = "txtExePath2"
        Me.txtExePath2.Size = New System.Drawing.Size(417, 52)
        Me.txtExePath2.TabIndex = 269
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 268
        Me.Label15.Text = "Executable"
        '
        'txtItemType
        '
        Me.txtItemType.Location = New System.Drawing.Point(72, 82)
        Me.txtItemType.Name = "txtItemType"
        Me.txtItemType.Size = New System.Drawing.Size(100, 20)
        Me.txtItemType.TabIndex = 268
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 85)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 13)
        Me.Label14.TabIndex = 267
        Me.Label14.Text = "Type:"
        '
        'btnDeleteNode
        '
        Me.btnDeleteNode.Location = New System.Drawing.Point(7, 159)
        Me.btnDeleteNode.Name = "btnDeleteNode"
        Me.btnDeleteNode.Size = New System.Drawing.Size(73, 22)
        Me.btnDeleteNode.TabIndex = 266
        Me.btnDeleteNode.Text = "Delete"
        Me.btnDeleteNode.UseVisualStyleBackColor = True
        '
        'pbOpenIcon
        '
        Me.pbOpenIcon.Location = New System.Drawing.Point(476, 82)
        Me.pbOpenIcon.Name = "pbOpenIcon"
        Me.pbOpenIcon.Size = New System.Drawing.Size(32, 34)
        Me.pbOpenIcon.TabIndex = 265
        Me.pbOpenIcon.TabStop = False
        '
        'pbIcon
        '
        Me.pbIcon.Location = New System.Drawing.Point(301, 82)
        Me.pbIcon.Name = "pbIcon"
        Me.pbIcon.Size = New System.Drawing.Size(32, 34)
        Me.pbIcon.TabIndex = 264
        Me.pbIcon.TabStop = False
        '
        'txtOpenIconNo
        '
        Me.txtOpenIconNo.Location = New System.Drawing.Point(422, 82)
        Me.txtOpenIconNo.Name = "txtOpenIconNo"
        Me.txtOpenIconNo.Size = New System.Drawing.Size(48, 20)
        Me.txtOpenIconNo.TabIndex = 263
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(339, 85)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 13)
        Me.Label13.TabIndex = 262
        Me.Label13.Text = "Open Icon No:"
        '
        'txtIconNo
        '
        Me.txtIconNo.Location = New System.Drawing.Point(247, 82)
        Me.txtIconNo.Name = "txtIconNo"
        Me.txtIconNo.Size = New System.Drawing.Size(48, 20)
        Me.txtIconNo.TabIndex = 261
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(193, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 260
        Me.Label12.Text = "Icon No:"
        '
        'txtItemDescription
        '
        Me.txtItemDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItemDescription.Location = New System.Drawing.Point(72, 31)
        Me.txtItemDescription.Multiline = True
        Me.txtItemDescription.Name = "txtItemDescription"
        Me.txtItemDescription.Size = New System.Drawing.Size(507, 45)
        Me.txtItemDescription.TabIndex = 259
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(10, 34)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(63, 13)
        Me.Label27.TabIndex = 258
        Me.Label27.Text = "Description:"
        '
        'txtNodeKey
        '
        Me.txtNodeKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNodeKey.Location = New System.Drawing.Point(72, 5)
        Me.txtNodeKey.Name = "txtNodeKey"
        Me.txtNodeKey.Size = New System.Drawing.Size(507, 20)
        Me.txtNodeKey.TabIndex = 257
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(10, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 13)
        Me.Label22.TabIndex = 256
        Me.Label22.Text = "Node key:"
        Me.ToolTip1.SetToolTip(Me.Label22, "The is also the document file name")
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkConnect)
        Me.TabPage1.Controls.Add(Me.btnOpenProject)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.txtProjectPath)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.txtProNetName)
        Me.TabPage1.Controls.Add(Me.btnOpenAppDir)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.btnOpenSystem)
        Me.TabPage1.Controls.Add(Me.btnOpenData)
        Me.TabPage1.Controls.Add(Me.btnOpenSettings)
        Me.TabPage1.Controls.Add(Me.btnAdd)
        Me.TabPage1.Controls.Add(Me.txtParentProject)
        Me.TabPage1.Controls.Add(Me.Label81)
        Me.TabPage1.Controls.Add(Me.btnParameters)
        Me.TabPage1.Controls.Add(Me.btnCheckComNet)
        Me.TabPage1.Controls.Add(Me.btnSetUpComNetClient)
        Me.TabPage1.Controls.Add(Me.btnGetComNetAppInfo)
        Me.TabPage1.Controls.Add(Me.btnGetAppList)
        Me.TabPage1.Controls.Add(Me.btnGetConnectionList)
        Me.TabPage1.Controls.Add(Me.Label79)
        Me.TabPage1.Controls.Add(Me.txtSystemLocationType)
        Me.TabPage1.Controls.Add(Me.txtSystemPath)
        Me.TabPage1.Controls.Add(Me.txtCurrentDuration)
        Me.TabPage1.Controls.Add(Me.Label29)
        Me.TabPage1.Controls.Add(Me.txtTotalDuration)
        Me.TabPage1.Controls.Add(Me.Label30)
        Me.TabPage1.Controls.Add(Me.Label31)
        Me.TabPage1.Controls.Add(Me.txtLastUsed)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.btnProject)
        Me.TabPage1.Controls.Add(Me.txtCreationDate)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtDataPath)
        Me.TabPage1.Controls.Add(Me.txtDataLocationType)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtSettingsPath)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtSettingsLocationType)
        Me.TabPage1.Controls.Add(Me.txtProjectType)
        Me.TabPage1.Controls.Add(Me.txtProjectDescription)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtProjectName)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1077, 585)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Project Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkConnect
        '
        Me.chkConnect.AutoSize = True
        Me.chkConnect.Location = New System.Drawing.Point(411, 136)
        Me.chkConnect.Name = "chkConnect"
        Me.chkConnect.Size = New System.Drawing.Size(112, 17)
        Me.chkConnect.TabIndex = 306
        Me.chkConnect.Text = "Connect On Open"
        Me.chkConnect.UseVisualStyleBackColor = True
        '
        'btnOpenProject
        '
        Me.btnOpenProject.Location = New System.Drawing.Point(84, 180)
        Me.btnOpenProject.Name = "btnOpenProject"
        Me.btnOpenProject.Size = New System.Drawing.Size(48, 22)
        Me.btnOpenProject.TabIndex = 304
        Me.btnOpenProject.Text = "Open"
        Me.btnOpenProject.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 164)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(67, 13)
        Me.Label28.TabIndex = 303
        Me.Label28.Text = "Project path:"
        '
        'txtProjectPath
        '
        Me.txtProjectPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectPath.Location = New System.Drawing.Point(138, 161)
        Me.txtProjectPath.Multiline = True
        Me.txtProjectPath.Name = "txtProjectPath"
        Me.txtProjectPath.Size = New System.Drawing.Size(933, 46)
        Me.txtProjectPath.TabIndex = 302
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(166, 35)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(84, 13)
        Me.Label26.TabIndex = 301
        Me.Label26.Text = "Project network:"
        '
        'txtProNetName
        '
        Me.txtProNetName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProNetName.Location = New System.Drawing.Point(275, 32)
        Me.txtProNetName.Name = "txtProNetName"
        Me.txtProNetName.Size = New System.Drawing.Size(796, 20)
        Me.txtProNetName.TabIndex = 300
        '
        'btnOpenAppDir
        '
        Me.btnOpenAppDir.Location = New System.Drawing.Point(6, 369)
        Me.btnOpenAppDir.Name = "btnOpenAppDir"
        Me.btnOpenAppDir.Size = New System.Drawing.Size(150, 22)
        Me.btnOpenAppDir.TabIndex = 298
        Me.btnOpenAppDir.Text = "Open Application Directory"
        Me.btnOpenAppDir.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(562, 374)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 297
        Me.Label8.Text = "d:h:m:s"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(374, 374)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 296
        Me.Label6.Text = "d:h:m:s"
        '
        'btnOpenSystem
        '
        Me.btnOpenSystem.Location = New System.Drawing.Point(84, 334)
        Me.btnOpenSystem.Name = "btnOpenSystem"
        Me.btnOpenSystem.Size = New System.Drawing.Size(48, 22)
        Me.btnOpenSystem.TabIndex = 295
        Me.btnOpenSystem.Text = "Open"
        Me.btnOpenSystem.UseVisualStyleBackColor = True
        '
        'btnOpenData
        '
        Me.btnOpenData.Location = New System.Drawing.Point(84, 284)
        Me.btnOpenData.Name = "btnOpenData"
        Me.btnOpenData.Size = New System.Drawing.Size(48, 22)
        Me.btnOpenData.TabIndex = 294
        Me.btnOpenData.Text = "Open"
        Me.btnOpenData.UseVisualStyleBackColor = True
        '
        'btnOpenSettings
        '
        Me.btnOpenSettings.Location = New System.Drawing.Point(84, 232)
        Me.btnOpenSettings.Name = "btnOpenSettings"
        Me.btnOpenSettings.Size = New System.Drawing.Size(48, 22)
        Me.btnOpenSettings.TabIndex = 293
        Me.btnOpenSettings.Text = "Open"
        Me.btnOpenSettings.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(6, 34)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(150, 22)
        Me.btnAdd.TabIndex = 289
        Me.btnAdd.Text = "Add to Message Service"
        Me.ToolTip1.SetToolTip(Me.btnAdd, "Add the selected project to the Message Service list")
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtParentProject
        '
        Me.txtParentProject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtParentProject.Location = New System.Drawing.Point(275, 6)
        Me.txtParentProject.Name = "txtParentProject"
        Me.txtParentProject.Size = New System.Drawing.Size(796, 20)
        Me.txtParentProject.TabIndex = 287
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(166, 11)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(76, 13)
        Me.Label81.TabIndex = 286
        Me.Label81.Text = "Parent project:"
        '
        'btnParameters
        '
        Me.btnParameters.Location = New System.Drawing.Point(84, 6)
        Me.btnParameters.Name = "btnParameters"
        Me.btnParameters.Size = New System.Drawing.Size(72, 22)
        Me.btnParameters.TabIndex = 285
        Me.btnParameters.Text = "Parameters"
        Me.btnParameters.UseVisualStyleBackColor = True
        '
        'btnCheckComNet
        '
        Me.btnCheckComNet.Location = New System.Drawing.Point(544, 397)
        Me.btnCheckComNet.Name = "btnCheckComNet"
        Me.btnCheckComNet.Size = New System.Drawing.Size(110, 34)
        Me.btnCheckComNet.TabIndex = 88
        Me.btnCheckComNet.Text = "Check ComNet Service"
        Me.btnCheckComNet.UseVisualStyleBackColor = True
        '
        'btnSetUpComNetClient
        '
        Me.btnSetUpComNetClient.Location = New System.Drawing.Point(428, 397)
        Me.btnSetUpComNetClient.Name = "btnSetUpComNetClient"
        Me.btnSetUpComNetClient.Size = New System.Drawing.Size(110, 34)
        Me.btnSetUpComNetClient.TabIndex = 87
        Me.btnSetUpComNetClient.Text = "Set Up ComNet Client"
        Me.btnSetUpComNetClient.UseVisualStyleBackColor = True
        '
        'btnGetComNetAppInfo
        '
        Me.btnGetComNetAppInfo.Location = New System.Drawing.Point(312, 397)
        Me.btnGetComNetAppInfo.Name = "btnGetComNetAppInfo"
        Me.btnGetComNetAppInfo.Size = New System.Drawing.Size(110, 34)
        Me.btnGetComNetAppInfo.TabIndex = 86
        Me.btnGetComNetAppInfo.Text = "Get Message Service App Info"
        Me.btnGetComNetAppInfo.UseVisualStyleBackColor = True
        '
        'btnGetAppList
        '
        Me.btnGetAppList.Location = New System.Drawing.Point(159, 397)
        Me.btnGetAppList.Name = "btnGetAppList"
        Me.btnGetAppList.Size = New System.Drawing.Size(147, 34)
        Me.btnGetAppList.TabIndex = 85
        Me.btnGetAppList.Text = "Get Application List"
        Me.btnGetAppList.UseVisualStyleBackColor = True
        '
        'btnGetConnectionList
        '
        Me.btnGetConnectionList.Location = New System.Drawing.Point(6, 397)
        Me.btnGetConnectionList.Name = "btnGetConnectionList"
        Me.btnGetConnectionList.Size = New System.Drawing.Size(147, 34)
        Me.btnGetConnectionList.TabIndex = 84
        Me.btnGetConnectionList.Text = "Get Connection List"
        Me.btnGetConnectionList.UseVisualStyleBackColor = True
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(6, 320)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(68, 13)
        Me.Label79.TabIndex = 82
        Me.Label79.Text = "System path:"
        '
        'txtSystemLocationType
        '
        Me.txtSystemLocationType.Location = New System.Drawing.Point(6, 336)
        Me.txtSystemLocationType.Name = "txtSystemLocationType"
        Me.txtSystemLocationType.Size = New System.Drawing.Size(72, 20)
        Me.txtSystemLocationType.TabIndex = 81
        '
        'txtSystemPath
        '
        Me.txtSystemPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSystemPath.Location = New System.Drawing.Point(138, 317)
        Me.txtSystemPath.Multiline = True
        Me.txtSystemPath.Name = "txtSystemPath"
        Me.txtSystemPath.Size = New System.Drawing.Size(933, 46)
        Me.txtSystemPath.TabIndex = 80
        '
        'txtCurrentDuration
        '
        Me.txtCurrentDuration.Location = New System.Drawing.Point(471, 369)
        Me.txtCurrentDuration.Name = "txtCurrentDuration"
        Me.txtCurrentDuration.Size = New System.Drawing.Size(85, 20)
        Me.txtCurrentDuration.TabIndex = 78
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(421, 374)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(44, 13)
        Me.Label29.TabIndex = 76
        Me.Label29.Text = "Current:"
        '
        'txtTotalDuration
        '
        Me.txtTotalDuration.Location = New System.Drawing.Point(283, 369)
        Me.txtTotalDuration.Name = "txtTotalDuration"
        Me.txtTotalDuration.Size = New System.Drawing.Size(85, 20)
        Me.txtTotalDuration.TabIndex = 75
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(243, 374)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(34, 13)
        Me.Label30.TabIndex = 74
        Me.Label30.Text = "Total:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(162, 374)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(75, 13)
        Me.Label31.TabIndex = 73
        Me.Label31.Text = "Project usage:"
        '
        'txtLastUsed
        '
        Me.txtLastUsed.Location = New System.Drawing.Point(275, 134)
        Me.txtLastUsed.Name = "txtLastUsed"
        Me.txtLastUsed.Size = New System.Drawing.Size(120, 20)
        Me.txtLastUsed.TabIndex = 35
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(213, 137)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Last used:"
        '
        'txtCreationDate
        '
        Me.txtCreationDate.Location = New System.Drawing.Point(85, 134)
        Me.txtCreationDate.Name = "txtCreationDate"
        Me.txtCreationDate.Size = New System.Drawing.Size(120, 20)
        Me.txtCreationDate.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 138)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Creation date:"
        '
        'txtDataPath
        '
        Me.txtDataPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDataPath.Location = New System.Drawing.Point(138, 265)
        Me.txtDataPath.Multiline = True
        Me.txtDataPath.Name = "txtDataPath"
        Me.txtDataPath.Size = New System.Drawing.Size(933, 46)
        Me.txtDataPath.TabIndex = 31
        '
        'txtDataLocationType
        '
        Me.txtDataLocationType.Location = New System.Drawing.Point(6, 284)
        Me.txtDataLocationType.Name = "txtDataLocationType"
        Me.txtDataLocationType.Size = New System.Drawing.Size(72, 20)
        Me.txtDataLocationType.TabIndex = 30
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 268)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Data path:"
        '
        'txtSettingsPath
        '
        Me.txtSettingsPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSettingsPath.Location = New System.Drawing.Point(138, 213)
        Me.txtSettingsPath.Multiline = True
        Me.txtSettingsPath.Name = "txtSettingsPath"
        Me.txtSettingsPath.Size = New System.Drawing.Size(933, 46)
        Me.txtSettingsPath.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Settings path:"
        '
        'txtSettingsLocationType
        '
        Me.txtSettingsLocationType.Location = New System.Drawing.Point(6, 232)
        Me.txtSettingsLocationType.Name = "txtSettingsLocationType"
        Me.txtSettingsLocationType.Size = New System.Drawing.Size(72, 20)
        Me.txtSettingsLocationType.TabIndex = 25
        '
        'txtProjectType
        '
        Me.txtProjectType.Location = New System.Drawing.Point(6, 180)
        Me.txtProjectType.Name = "txtProjectType"
        Me.txtProjectType.Size = New System.Drawing.Size(72, 20)
        Me.txtProjectType.TabIndex = 23
        '
        'txtProjectDescription
        '
        Me.txtProjectDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectDescription.Location = New System.Drawing.Point(85, 88)
        Me.txtProjectDescription.Multiline = True
        Me.txtProjectDescription.Name = "txtProjectDescription"
        Me.txtProjectDescription.Size = New System.Drawing.Size(986, 40)
        Me.txtProjectDescription.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Description:"
        '
        'txtProjectName
        '
        Me.txtProjectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectName.Location = New System.Drawing.Point(85, 62)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(986, 20)
        Me.txtProjectName.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Project name:"
        '
        'AppTreeImageList
        '
        Me.AppTreeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.AppTreeImageList.ImageSize = New System.Drawing.Size(32, 32)
        Me.AppTreeImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'ProjectIconImageList
        '
        Me.ProjectIconImageList.ImageStream = CType(resources.GetObject("ProjectIconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ProjectIconImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ProjectIconImageList.Images.SetKeyName(0, "DefaultProject.jpg")
        Me.ProjectIconImageList.Images.SetKeyName(1, "OpenDefaultProject.jpg")
        Me.ProjectIconImageList.Images.SetKeyName(2, "DirectoryProject.jpg")
        Me.ProjectIconImageList.Images.SetKeyName(3, "OpenDirectoryProject.jpg")
        Me.ProjectIconImageList.Images.SetKeyName(4, "ArchiveProject.jpg")
        Me.ProjectIconImageList.Images.SetKeyName(5, "OpenArchiveProject.jpg")
        Me.ProjectIconImageList.Images.SetKeyName(6, "HybridProject.jpg")
        Me.ProjectIconImageList.Images.SetKeyName(7, "OpenHybridProject.jpg")
        '
        'ProjTreeImageList
        '
        Me.ProjTreeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.ProjTreeImageList.ImageSize = New System.Drawing.Size(64, 32)
        Me.ProjTreeImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(129, 17)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(74, 13)
        Me.Label51.TabIndex = 268
        Me.Label51.Text = "Project Name:"
        '
        'txtOpenProjectName
        '
        Me.txtOpenProjectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOpenProjectName.Location = New System.Drawing.Point(209, 13)
        Me.txtOpenProjectName.Name = "txtOpenProjectName"
        Me.txtOpenProjectName.ReadOnly = True
        Me.txtOpenProjectName.Size = New System.Drawing.Size(503, 20)
        Me.txtOpenProjectName.TabIndex = 274
        '
        'btnOnline
        '
        Me.btnOnline.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOnline.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOnline.ForeColor = System.Drawing.Color.Red
        Me.btnOnline.Location = New System.Drawing.Point(971, 12)
        Me.btnOnline.Name = "btnOnline"
        Me.btnOnline.Size = New System.Drawing.Size(56, 22)
        Me.btnOnline.TabIndex = 276
        Me.btnOnline.Text = "Offline"
        Me.btnOnline.UseVisualStyleBackColor = True
        '
        'btnWebPages
        '
        Me.btnWebPages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWebPages.ContextMenuStrip = Me.ContextMenuStrip2
        Me.btnWebPages.Location = New System.Drawing.Point(718, 12)
        Me.btnWebPages.Name = "btnWebPages"
        Me.btnWebPages.Size = New System.Drawing.Size(68, 22)
        Me.btnWebPages.TabIndex = 277
        Me.btnWebPages.Text = "Workflows"
        Me.btnWebPages.UseVisualStyleBackColor = True
        '
        'Timer3
        '
        '
        'btnAndorville
        '
        Me.btnAndorville.BackgroundImage = Global.ADVL_Project_Network_1.My.Resources.Resources.Andorville_16May16_TM_Crop_Grey
        Me.btnAndorville.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAndorville.Font = New System.Drawing.Font("Harlow Solid Italic", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAndorville.Location = New System.Drawing.Point(5, 5)
        Me.btnAndorville.Name = "btnAndorville"
        Me.btnAndorville.Size = New System.Drawing.Size(118, 29)
        Me.btnAndorville.TabIndex = 51
        Me.btnAndorville.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1109, 760)
        Me.Controls.Add(Me.btnWebPages)
        Me.Controls.Add(Me.btnOnline)
        Me.Controls.Add(Me.txtOpenProjectName)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.btnAndorville)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnMessages)
        Me.Controls.Add(Me.btnAppInfo)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "Project Network"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage15.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage9.PerformLayout()
        Me.TabPage10.ResumeLayout(False)
        Me.TabPage10.PerformLayout()
        Me.TabPage11.ResumeLayout(False)
        Me.txtHPDataLocn.ResumeLayout(False)
        Me.TabPage12.ResumeLayout(False)
        Me.TabPage12.PerformLayout()
        Me.TabPage14.ResumeLayout(False)
        Me.TabPage14.PerformLayout()
        Me.TabPage13.ResumeLayout(False)
        Me.TabPage13.PerformLayout()
        Me.TabPage16.ResumeLayout(False)
        Me.TabPage16.PerformLayout()
        CType(Me.pbOpenAppDirIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAppDirIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbOpenIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnAppInfo As System.Windows.Forms.Button
    Friend WithEvents btnProject As System.Windows.Forms.Button
    Friend WithEvents btnMessages As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtLastUsed As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCreationDate As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDataPath As System.Windows.Forms.TextBox
    Friend WithEvents txtDataLocationType As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSettingsPath As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSettingsLocationType As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectType As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents btnAndorville As Button
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents trvAppTree As TreeView
    Friend WithEvents AppTreeImageList As ImageList
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents txtItemDescription As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents txtNodeKey As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtOpenIconNo As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtIconNo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents pbOpenIcon As PictureBox
    Friend WithEvents pbIcon As PictureBox
    Friend WithEvents btnDeleteNode As Button
    Friend WithEvents txtItemType As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtApplicationName As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtParentProjectName As TextBox
    Friend WithEvents txtProjPath As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtProjType As TextBox
    Friend WithEvents txtProjName As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtAppDirectory As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtExePath2 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents chkConnect2 As CheckBox
    Friend WithEvents btnStart As Button
    Friend WithEvents txtCurrentDuration As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtTotalDuration As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtParentProjectID As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtProjID As TextBox
    Friend WithEvents ProjectIconImageList As ImageList
    Friend WithEvents btnMoveDown As Button
    Friend WithEvents btnMoveUp As Button
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents trvProjTree As TreeView
    Friend WithEvents ProjTreeImageList As ImageList
    Friend WithEvents btnAddToProjTree As Button
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents txtPTProjAppName As TextBox
    Friend WithEvents txtPTProjID As TextBox
    Friend WithEvents txtPTProjPath As TextBox
    Friend WithEvents Label39 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents txtPTProjType As TextBox
    Friend WithEvents txtPTProjName As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents btnMovePTNodeDown As Button
    Friend WithEvents btnMovePTNodeUp As Button
    Friend WithEvents chkConnect1 As CheckBox
    Friend WithEvents btnStartProject As Button
    Friend WithEvents btnDeleteProjNode As Button
    Friend WithEvents txtPTProjDescription As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents txtPTProjNodeKey As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents Label44 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents pbOpenAppDirIcon As PictureBox
    Friend WithEvents pbAppDirIcon As PictureBox
    Friend WithEvents cmbNewChildProjectApplication As ComboBox
    Friend WithEvents Label42 As Label
    Friend WithEvents cmbNewChildProjectType As ComboBox
    Friend WithEvents Label38 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents txtNewChildProjectDescription As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents txtNewChildProjectName As TextBox
    Friend WithEvents TabControl3 As TabControl
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents txtProjectDirectoryName As TextBox
    Friend WithEvents Label47 As Label
    Friend WithEvents TabPage10 As TabPage
    Friend WithEvents Label49 As Label
    Friend WithEvents txtProjectArchiveName As TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents TabPage11 As TabPage
    Friend WithEvents txtHPDataLocn As TabControl
    Friend WithEvents TabPage12 As TabPage
    Friend WithEvents txtHPDirectoryName As TextBox
    Friend WithEvents Label52 As Label
    Friend WithEvents TabPage13 As TabPage
    Friend WithEvents txtHPDataName As TextBox
    Friend WithEvents Label57 As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents TabPage14 As TabPage
    Friend WithEvents btnCreateDirectoryProject As Button
    Friend WithEvents btnCreateArchiveProject As Button
    Friend WithEvents btnCreateHybridProject As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label45 As Label
    Friend WithEvents txtAuthorDescription As TextBox
    Friend WithEvents txtAuthorContact As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents txtAuthorName As TextBox
    Friend WithEvents Label48 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents txtOpenProjectName As TextBox
    Friend WithEvents TabPage15 As TabPage
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents txtNodeIndex As TextBox
    Friend WithEvents Label53 As Label
    Friend WithEvents txtPTProjRelativePath As TextBox
    Friend WithEvents Label62 As Label
    Friend WithEvents txtPTProjParentProjectID As TextBox
    Friend WithEvents Label61 As Label
    Friend WithEvents txtPTProjParentProjectName As TextBox
    Friend WithEvents Label60 As Label
    Friend WithEvents Label63 As Label
    Friend WithEvents txtRelativePath As TextBox
    Friend WithEvents txtNewChildParentID As TextBox
    Friend WithEvents Label65 As Label
    Friend WithEvents txtNewChildParentText As TextBox
    Friend WithEvents Label64 As Label
    Friend WithEvents txtNewChildParentName As TextBox
    Friend WithEvents Label59 As Label
    Friend WithEvents txtProjectDirectoryRelativePath As TextBox
    Friend WithEvents Label66 As Label
    Friend WithEvents txtProjectArchiveRelativePath As TextBox
    Friend WithEvents Label67 As Label
    Friend WithEvents txtHybridProjectRelativePath As TextBox
    Friend WithEvents Label68 As Label
    Friend WithEvents cmbHPSettingsType As ComboBox
    Friend WithEvents Label70 As Label
    Friend WithEvents txtHPSettingsName As TextBox
    Friend WithEvents Label69 As Label
    Friend WithEvents cmbHPDataType As ComboBox
    Friend WithEvents TabPage16 As TabPage
    Friend WithEvents cmbHPSystemType As ComboBox
    Friend WithEvents Label71 As Label
    Friend WithEvents txtHPSystemName As TextBox
    Friend WithEvents Label72 As Label
    Friend WithEvents Label74 As Label
    Friend WithEvents Label73 As Label
    Friend WithEvents Label75 As Label
    Friend WithEvents txtPTProjParentProjectPath As TextBox
    Friend WithEvents Label76 As Label
    Friend WithEvents txtPTProjCreationDate As TextBox
    Friend WithEvents Label77 As Label
    Friend WithEvents Label78 As Label
    Friend WithEvents txtFindNodeProjID As TextBox
    Friend WithEvents btnFindNode As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1_OpenProject As ToolStripMenuItem
    Friend WithEvents Label79 As Label
    Friend WithEvents txtSystemLocationType As TextBox
    Friend WithEvents txtSystemPath As TextBox
    Friend WithEvents btnOnline As Button
    Friend WithEvents btnGetConnectionList As Button
    Friend WithEvents Timer2 As Timer
    Friend WithEvents btnGetAppList As Button
    Friend WithEvents btnGetComNetAppInfo As Button
    Friend WithEvents btnSetUpComNetClient As Button
    Friend WithEvents btnCheckComNet As Button
    Friend WithEvents btnAddApplication As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtNodeText As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnWebPages As Button
    Friend WithEvents btnGetAppInfo As Button
    Friend WithEvents txtAppName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnParameters As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtParentProject As TextBox
    Friend WithEvents Label81 As Label
    Friend WithEvents Timer3 As Timer
    Friend WithEvents btnOpenAppDir As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnOpenSystem As Button
    Friend WithEvents btnOpenData As Button
    Friend WithEvents btnOpenSettings As Button
    Friend WithEvents btnOpenProject As Button
    Friend WithEvents Label28 As Label
    Friend WithEvents txtProjectPath As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtProNetName As TextBox
    Friend WithEvents chkConnect As CheckBox
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1_EditWorkflowTabPage As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1_ShowStartPageInWorkflowTab As ToolStripMenuItem
    Friend WithEvents txtDirName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnShowChildProjectInfo As Button
    Friend WithEvents btnOpenPath As Button
End Class
