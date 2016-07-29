<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAppInfo = New System.Windows.Forms.Button()
        Me.btnProject = New System.Windows.Forms.Button()
        Me.btnMessages = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtLastUsed = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCreationDate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDataLocationPath = New System.Windows.Forms.TextBox()
        Me.txtDataLocationType = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSettingsLocationPath = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSettingsLocationType = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtProjectType = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProjectDescription = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProjectName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvConnections = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.rbProjectApplications = New System.Windows.Forms.RadioButton()
        Me.rbAllApplications = New System.Windows.Forms.RadioButton()
        Me.chkConnect = New System.Windows.Forms.CheckBox()
        Me.txtExePath = New System.Windows.Forms.TextBox()
        Me.txtDirectory = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRemoveApp = New System.Windows.Forms.Button()
        Me.dgvApplications = New System.Windows.Forms.DataGridView()
        Me.btnStartApp = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.btnOpenProject = New System.Windows.Forms.Button()
        Me.dgvProjects = New System.Windows.Forms.DataGridView()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.btnRunProcess = New System.Windows.Forms.Button()
        Me.dgvProcesses = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAndorville = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvConnections, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvApplications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvProjects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvProcesses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(797, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 22)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAppInfo
        '
        Me.btnAppInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAppInfo.Location = New System.Drawing.Point(618, 12)
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
        Me.btnProject.Size = New System.Drawing.Size(69, 22)
        Me.btnProject.TabIndex = 48
        Me.btnProject.Text = "Project"
        Me.ToolTip1.SetToolTip(Me.btnProject, "Select or create a project.")
        Me.btnProject.UseVisualStyleBackColor = True
        '
        'btnMessages
        '
        Me.btnMessages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMessages.Location = New System.Drawing.Point(719, 12)
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
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(12, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(849, 384)
        Me.TabControl1.TabIndex = 50
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtLastUsed)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.btnProject)
        Me.TabPage1.Controls.Add(Me.txtCreationDate)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtDataLocationPath)
        Me.TabPage1.Controls.Add(Me.txtDataLocationType)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtSettingsLocationPath)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtSettingsLocationType)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtProjectType)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtProjectDescription)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtProjectName)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(841, 358)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Project Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtLastUsed
        '
        Me.txtLastUsed.Location = New System.Drawing.Point(457, 109)
        Me.txtLastUsed.Name = "txtLastUsed"
        Me.txtLastUsed.Size = New System.Drawing.Size(143, 20)
        Me.txtLastUsed.TabIndex = 35
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(374, 112)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Date last used:"
        '
        'txtCreationDate
        '
        Me.txtCreationDate.Location = New System.Drawing.Point(217, 108)
        Me.txtCreationDate.Name = "txtCreationDate"
        Me.txtCreationDate.Size = New System.Drawing.Size(150, 20)
        Me.txtCreationDate.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(138, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Creation date:"
        '
        'txtDataLocationPath
        '
        Me.txtDataLocationPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDataLocationPath.Location = New System.Drawing.Point(215, 186)
        Me.txtDataLocationPath.Multiline = True
        Me.txtDataLocationPath.Name = "txtDataLocationPath"
        Me.txtDataLocationPath.Size = New System.Drawing.Size(620, 46)
        Me.txtDataLocationPath.TabIndex = 31
        '
        'txtDataLocationType
        '
        Me.txtDataLocationType.Location = New System.Drawing.Point(124, 186)
        Me.txtDataLocationType.Name = "txtDataLocationType"
        Me.txtDataLocationType.Size = New System.Drawing.Size(85, 20)
        Me.txtDataLocationType.TabIndex = 30
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(112, 215)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Data location path:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 189)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Data location type:"
        '
        'txtSettingsLocationPath
        '
        Me.txtSettingsLocationPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSettingsLocationPath.Location = New System.Drawing.Point(215, 134)
        Me.txtSettingsLocationPath.Multiline = True
        Me.txtSettingsLocationPath.Name = "txtSettingsLocationPath"
        Me.txtSettingsLocationPath.Size = New System.Drawing.Size(620, 46)
        Me.txtSettingsLocationPath.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(97, 162)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Settings location path:"
        '
        'txtSettingsLocationType
        '
        Me.txtSettingsLocationType.Location = New System.Drawing.Point(123, 134)
        Me.txtSettingsLocationType.Name = "txtSettingsLocationType"
        Me.txtSettingsLocationType.Size = New System.Drawing.Size(86, 20)
        Me.txtSettingsLocationType.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Settings location type:"
        '
        'txtProjectType
        '
        Me.txtProjectType.Location = New System.Drawing.Point(46, 109)
        Me.txtProjectType.Name = "txtProjectType"
        Me.txtProjectType.Size = New System.Drawing.Size(86, 20)
        Me.txtProjectType.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Type:"
        '
        'txtProjectDescription
        '
        Me.txtProjectDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectDescription.Location = New System.Drawing.Point(123, 62)
        Me.txtProjectDescription.Multiline = True
        Me.txtProjectDescription.Name = "txtProjectDescription"
        Me.txtProjectDescription.Size = New System.Drawing.Size(712, 40)
        Me.txtProjectDescription.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Description:"
        '
        'txtProjectName
        '
        Me.txtProjectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProjectName.Location = New System.Drawing.Point(123, 36)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(712, 20)
        Me.txtProjectName.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Name:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvConnections)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(841, 358)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Connections"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvConnections
        '
        Me.dgvConnections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConnections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConnections.Location = New System.Drawing.Point(6, 6)
        Me.dgvConnections.Name = "dgvConnections"
        Me.dgvConnections.Size = New System.Drawing.Size(829, 346)
        Me.dgvConnections.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.rbProjectApplications)
        Me.TabPage3.Controls.Add(Me.rbAllApplications)
        Me.TabPage3.Controls.Add(Me.chkConnect)
        Me.TabPage3.Controls.Add(Me.txtExePath)
        Me.TabPage3.Controls.Add(Me.txtDirectory)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.btnRemoveApp)
        Me.TabPage3.Controls.Add(Me.dgvApplications)
        Me.TabPage3.Controls.Add(Me.btnStartApp)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(841, 358)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Applications"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'rbProjectApplications
        '
        Me.rbProjectApplications.AutoSize = True
        Me.rbProjectApplications.Location = New System.Drawing.Point(446, 7)
        Me.rbProjectApplications.Name = "rbProjectApplications"
        Me.rbProjectApplications.Size = New System.Drawing.Size(168, 17)
        Me.rbProjectApplications.TabIndex = 59
        Me.rbProjectApplications.TabStop = True
        Me.rbProjectApplications.Text = "Show project applications only"
        Me.rbProjectApplications.UseVisualStyleBackColor = True
        '
        'rbAllApplications
        '
        Me.rbAllApplications.AutoSize = True
        Me.rbAllApplications.Location = New System.Drawing.Point(316, 6)
        Me.rbAllApplications.Name = "rbAllApplications"
        Me.rbAllApplications.Size = New System.Drawing.Size(124, 17)
        Me.rbAllApplications.TabIndex = 58
        Me.rbAllApplications.TabStop = True
        Me.rbAllApplications.Text = "Show all applications"
        Me.rbAllApplications.UseVisualStyleBackColor = True
        '
        'chkConnect
        '
        Me.chkConnect.AutoSize = True
        Me.chkConnect.Location = New System.Drawing.Point(79, 7)
        Me.chkConnect.Name = "chkConnect"
        Me.chkConnect.Size = New System.Drawing.Size(119, 17)
        Me.chkConnect.TabIndex = 57
        Me.chkConnect.Text = "Connect to network"
        Me.chkConnect.UseVisualStyleBackColor = True
        '
        'txtExePath
        '
        Me.txtExePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExePath.Location = New System.Drawing.Point(96, 73)
        Me.txtExePath.Multiline = True
        Me.txtExePath.Name = "txtExePath"
        Me.txtExePath.Size = New System.Drawing.Size(734, 53)
        Me.txtExePath.TabIndex = 56
        '
        'txtDirectory
        '
        Me.txtDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDirectory.Location = New System.Drawing.Point(96, 31)
        Me.txtDirectory.Multiline = True
        Me.txtDirectory.Name = "txtDirectory"
        Me.txtDirectory.Size = New System.Drawing.Size(734, 36)
        Me.txtDirectory.TabIndex = 55
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Executable path:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Directory:"
        '
        'btnRemoveApp
        '
        Me.btnRemoveApp.Location = New System.Drawing.Point(204, 3)
        Me.btnRemoveApp.Name = "btnRemoveApp"
        Me.btnRemoveApp.Size = New System.Drawing.Size(85, 22)
        Me.btnRemoveApp.TabIndex = 52
        Me.btnRemoveApp.Text = "Remove App"
        Me.ToolTip1.SetToolTip(Me.btnRemoveApp, "Remove the application entry selected in the Applications list.")
        Me.btnRemoveApp.UseVisualStyleBackColor = True
        '
        'dgvApplications
        '
        Me.dgvApplications.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvApplications.Location = New System.Drawing.Point(3, 132)
        Me.dgvApplications.Name = "dgvApplications"
        Me.dgvApplications.Size = New System.Drawing.Size(835, 223)
        Me.dgvApplications.TabIndex = 1
        '
        'btnStartApp
        '
        Me.btnStartApp.Location = New System.Drawing.Point(3, 3)
        Me.btnStartApp.Name = "btnStartApp"
        Me.btnStartApp.Size = New System.Drawing.Size(70, 22)
        Me.btnStartApp.TabIndex = 51
        Me.btnStartApp.Text = "Start App"
        Me.ToolTip1.SetToolTip(Me.btnStartApp, "Start the application selected in the Applications list.")
        Me.btnStartApp.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btnOpenProject)
        Me.TabPage4.Controls.Add(Me.dgvProjects)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(841, 358)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Projects"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'btnOpenProject
        '
        Me.btnOpenProject.Location = New System.Drawing.Point(3, 3)
        Me.btnOpenProject.Name = "btnOpenProject"
        Me.btnOpenProject.Size = New System.Drawing.Size(104, 22)
        Me.btnOpenProject.TabIndex = 52
        Me.btnOpenProject.Text = "Open Project"
        Me.ToolTip1.SetToolTip(Me.btnOpenProject, "Start the application selected in the Applications list.")
        Me.btnOpenProject.UseVisualStyleBackColor = True
        '
        'dgvProjects
        '
        Me.dgvProjects.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProjects.Location = New System.Drawing.Point(6, 31)
        Me.dgvProjects.Name = "dgvProjects"
        Me.dgvProjects.Size = New System.Drawing.Size(829, 321)
        Me.dgvProjects.TabIndex = 2
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.btnRunProcess)
        Me.TabPage5.Controls.Add(Me.dgvProcesses)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(841, 358)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Processes"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'btnRunProcess
        '
        Me.btnRunProcess.Location = New System.Drawing.Point(3, 3)
        Me.btnRunProcess.Name = "btnRunProcess"
        Me.btnRunProcess.Size = New System.Drawing.Size(104, 22)
        Me.btnRunProcess.TabIndex = 53
        Me.btnRunProcess.Text = "Run Process"
        Me.ToolTip1.SetToolTip(Me.btnRunProcess, "Start the application selected in the Applications list.")
        Me.btnRunProcess.UseVisualStyleBackColor = True
        '
        'dgvProcesses
        '
        Me.dgvProcesses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProcesses.Location = New System.Drawing.Point(6, 31)
        Me.dgvProcesses.Name = "dgvProcesses"
        Me.dgvProcesses.Size = New System.Drawing.Size(829, 321)
        Me.dgvProcesses.TabIndex = 3
        '
        'Timer1
        '
        '
        'btnAndorville
        '
        Me.btnAndorville.BackgroundImage = Global.ADVL_ApplicationNetwork.My.Resources.Resources.Andorville_16May16_TM_Crop_Grey
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
        Me.ClientSize = New System.Drawing.Size(873, 436)
        Me.Controls.Add(Me.btnAndorville)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnMessages)
        Me.Controls.Add(Me.btnAppInfo)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "Application Network"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvConnections, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgvApplications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvProjects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgvProcesses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents txtDataLocationPath As System.Windows.Forms.TextBox
    Friend WithEvents txtDataLocationType As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSettingsLocationPath As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSettingsLocationType As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtProjectType As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtProjectDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvConnections As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvApplications As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnStartApp As Button
    Friend WithEvents btnRemoveApp As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents btnAndorville As Button
    Friend WithEvents txtExePath As TextBox
    Friend WithEvents txtDirectory As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chkConnect As CheckBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents dgvProjects As DataGridView
    Friend WithEvents btnOpenProject As Button
    Friend WithEvents rbProjectApplications As RadioButton
    Friend WithEvents rbAllApplications As RadioButton
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents btnRunProcess As Button
    Friend WithEvents dgvProcesses As DataGridView
End Class
