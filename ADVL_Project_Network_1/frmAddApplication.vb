Public Class frmAddApplication
    'Form used to add an application the the Application Tree on the Main form.
    'The new application is selected from a list imported from the Message Service.


#Region " Variable Declarations - All the variables used in this form and this application." '=================================================================================================

    ' Public AppInfo As New Dictionary(Of String, clsAppInfo) 'Dictionary of information about each application shown in the AppTreeView. The Name is the key.

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Properties - All the properties used in this form and this application" '============================================================================================================

#End Region 'Properties -----------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Process XML files - Read and write XML files." '=====================================================================================================================================

    Private Sub SaveFormSettings()
        'Save the form settings in an XML document.
        Dim settingsData = <?xml version="1.0" encoding="utf-8"?>
                           <!---->
                           <FormSettings>
                               <Left><%= Me.Left %></Left>
                               <Top><%= Me.Top %></Top>
                               <Width><%= Me.Width %></Width>
                               <Height><%= Me.Height %></Height>
                               <!---->
                               <ApplictionNameWidth><%= dgvApplications.Columns(0).Width %></ApplictionNameWidth>
                               <ApplicationDescriptionWidth><%= dgvApplications.Columns(1).Width %></ApplicationDescriptionWidth>
                               <ApplicationDirectoryWidth><%= dgvApplications.Columns(2).Width %></ApplicationDirectoryWidth>
                               <ApplicationExePathWidth><%= dgvApplications.Columns(3).Width %></ApplicationExePathWidth>
                           </FormSettings>

        'Add code to include other settings to save after the comment line <!---->

        Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Main.Project.SaveXmlSettings(SettingsFileName, settingsData)
    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"

        If Main.Project.SettingsFileExists(SettingsFileName) Then
            Dim Settings As System.Xml.Linq.XDocument
            Main.Project.ReadXmlSettings(SettingsFileName, Settings)

            If IsNothing(Settings) Then 'There is no Settings XML data.
                Exit Sub
            End If

            'Restore form position and size:
            If Settings.<FormSettings>.<Left>.Value <> Nothing Then Me.Left = Settings.<FormSettings>.<Left>.Value
            If Settings.<FormSettings>.<Top>.Value <> Nothing Then Me.Top = Settings.<FormSettings>.<Top>.Value
            If Settings.<FormSettings>.<Height>.Value <> Nothing Then Me.Height = Settings.<FormSettings>.<Height>.Value
            If Settings.<FormSettings>.<Width>.Value <> Nothing Then Me.Width = Settings.<FormSettings>.<Width>.Value

            'Add code to read other saved setting here:
            If Settings.<FormSettings>.<ApplictionNameWidth>.Value <> Nothing Then dgvApplications.Columns(0).Width = Settings.<FormSettings>.<ApplictionNameWidth>.Value
            If Settings.<FormSettings>.<ApplicationDescriptionWidth>.Value <> Nothing Then dgvApplications.Columns(1).Width = Settings.<FormSettings>.<ApplicationDescriptionWidth>.Value
            If Settings.<FormSettings>.<ApplicationDirectoryWidth>.Value <> Nothing Then dgvApplications.Columns(2).Width = Settings.<FormSettings>.<ApplicationDirectoryWidth>.Value
            If Settings.<FormSettings>.<ApplicationExePathWidth>.Value <> Nothing Then dgvApplications.Columns(3).Width = Settings.<FormSettings>.<ApplicationExePathWidth>.Value
            CheckFormPos()
        End If
    End Sub

    Private Sub CheckFormPos()
        'Chech that the form can be seen on a screen.

        Dim MinWidthVisible As Integer = 48 'Minimum number of X pixels visible. The form will be moved if this many form pixels are not visible.
        Dim MinHeightVisible As Integer = 48 'Minimum number of Y pixels visible. The form will be moved if this many form pixels are not visible.

        Dim FormRect As New Rectangle(Me.Left, Me.Top, Me.Width, Me.Height)
        Dim WARect As Rectangle = Screen.GetWorkingArea(FormRect) 'The Working Area rectangle - the usable area of the screen containing the form.

        ''Check if the top of the form is less than zero:
        'If Me.Top < 0 Then Me.Top = 0

        'Check if the top of the form is above the top of the Working Area:
        If Me.Top < WARect.Top Then
            Me.Top = WARect.Top
        End If

        'Check if the top of the form is too close to the bottom of the Working Area:
        If (Me.Top + MinHeightVisible) > (WARect.Top + WARect.Height) Then
            Me.Top = WARect.Top + WARect.Height - MinHeightVisible
        End If

        'Check if the left edge of the form is too close to the right edge of the Working Area:
        If (Me.Left + MinWidthVisible) > (WARect.Left + WARect.Width) Then
            Me.Left = WARect.Left + WARect.Width - MinWidthVisible
        End If

        'Check if the right edge of the form is too close to the left edge of the Working Area:
        If (Me.Left + Me.Width - MinWidthVisible) < WARect.Left Then
            Me.Left = WARect.Left - Me.Width + MinWidthVisible
        End If

    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message) 'Save the form settings before the form is minimised:
        If m.Msg = &H112 Then 'SysCommand
            If m.WParam.ToInt32 = &HF020 Then 'Form is being minimised
                SaveFormSettings()
            End If
        End If
        MyBase.WndProc(m)
    End Sub

#End Region 'Process XML Files ----------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Display Methods - Code used to display this form." '============================================================================================================================

    'Private Sub frmTemplate_Load(sender As Object, e As EventArgs) Handles Me.Load
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load


        'Set up dgvApplications:
        'Columns in the DataGridView are: Application Name, Description
        dgvApplications.ColumnCount = 4
        dgvApplications.Columns(0).HeaderText = "Name"
        dgvApplications.Columns(0).Width = 200
        dgvApplications.Columns(1).HeaderText = "Description"
        dgvApplications.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvApplications.Columns(1).Width = 200
        dgvApplications.Columns(2).HeaderText = "Directory"
        dgvApplications.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvApplications.Columns(2).Width = 200
        dgvApplications.Columns(3).HeaderText = "Executable Path"
        dgvApplications.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvApplications.Columns(3).Width = 200

        dgvApplications.Rows.Clear()

        dgvApplications.AutoResizeRows()
        dgvApplications.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells

        dgvApplications.AllowUserToAddRows = False

        RestoreFormSettings()   'Restore the form settings

        GetAppList()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Form
        Me.Close() 'Close the form
    End Sub

    'Private Sub frmTemplate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If WindowState = FormWindowState.Normal Then
            SaveFormSettings()
        Else
            'Dont save settings if the form is minimised.
        End If
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Open and Close Forms - Code used to open and close other forms." '===================================================================================================================

#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Methods - The main actions performed by this form." '===========================================================================================================================


    Private Sub GetAppList()
        'Retrieve the list of application from ComNet.

        If IsNothing(Main.client) Then
            Main.Message.AddWarning("No client connection available!" & vbCrLf)
        Else
            Main.client.GetApplicationListAsync() 'Request a list of applications from ComNet.
        End If

    End Sub

    Private Sub btnUpdateList_Click(sender As Object, e As EventArgs) Handles btnUpdateList.Click
        'Update the list of applications
        UpdateList
    End Sub

    Public Sub UpdateList()

        GetAppList()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Add the selected application to the Application Tree on the Main form.

        If dgvApplications.SelectedRows.Count = 0 Then

        ElseIf dgvApplications.SelectedRows.Count = 1 Then
            Dim SelRow As Integer = dgvApplications.SelectedRows(0).Index
            If Main.AppInfo.ContainsKey(dgvApplications.Rows(SelRow).Cells(0).Value) Then
                Main.Message.AddWarning("The application is already in the list: " & dgvApplications.Rows(SelRow).Cells(0).Value & vbCrLf)
            Else
                Dim NewAppName As String = dgvApplications.Rows(SelRow).Cells(0).Value
                Main.Message.Add("Adding the application to the list: " & NewAppName & vbCrLf)
                Main.AppInfo.Add(NewAppName, New clsAppInfo)
                Main.AppInfo(NewAppName).Description = dgvApplications.Rows(SelRow).Cells(1).Value
                Main.AppInfo(NewAppName).Directory = dgvApplications.Rows(SelRow).Cells(2).Value
                Main.AppInfo(NewAppName).ExecutablePath = dgvApplications.Rows(SelRow).Cells(3).Value
                Main.AddAppNodeToAppTree(NewAppName)
            End If
        Else

        End If

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'Update the directory and executable file path of the selected application.

        If dgvApplications.SelectedRows.Count = 0 Then

        ElseIf dgvApplications.SelectedRows.Count = 1 Then
            Dim SelRow As Integer = dgvApplications.SelectedRows(0).Index
            If Main.AppInfo.ContainsKey(dgvApplications.Rows(SelRow).Cells(0).Value) Then
                Dim AppName As String = dgvApplications.Rows(SelRow).Cells(0).Value
                Main.Message.Add("Updating the application information: " & AppName & vbCrLf)
                'Update the application information:
                Main.AppInfo(AppName).Description = dgvApplications.Rows(SelRow).Cells(1).Value
                Main.AppInfo(AppName).Directory = dgvApplications.Rows(SelRow).Cells(2).Value
                Main.AppInfo(AppName).ExecutablePath = dgvApplications.Rows(SelRow).Cells(3).Value
            Else
                Main.Message.AddWarning("The application is not in the list: " & dgvApplications.Rows(SelRow).Cells(0).Value & vbCrLf)
            End If
        Else

        End If

    End Sub

#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

End Class