'----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
'
'Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598

'Licensed under the Apache License, Version 2.0 (the "License");
'you may not use this file except in compliance with the License.
'You may obtain a copy of the License at
'
'http://www.apache.org/licenses/LICENSE-2.0
'
'Unless required by applicable law or agreed to in writing, software
'distributed under the License is distributed on an "AS IS" BASIS,
'WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'See the License for the specific language governing permissions and
'limitations under the License.
'
'----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Imports System.ServiceModel
Imports System.ServiceModel.Description

Public Class Main
    'The ADVL Application Network is used to manage Andorville applications and exchange information between them.

    'Application code name: AMI-Net (Andorville Machine Intelligence Network).

#Region " CODING NOTES"
    'CODING NOTES:

    'ADD THE SYSTEM UTILITIES REFERENCE: ==========================================================================================
    'The following references are required by this software: 
    'Project \ Add Reference... \ ADVL_System_Utilties.dll

    'ADD THE SERVICE REFERENCE: ===================================================================================================
    'A service reference to the Message Service must be added to the source code before this service can be used.

    'Adding the service referenc to a project that includes the WcfMsgServiceLib project: -----------------------------------------
    'Project \ Add Service Reference
    'Press the Discover button.
    'Expand the items in the Services window and select IMsgService.
    'Press OK.
    '------------------------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------------------------
    'Adding the service reference to other projects that dont include the WcfMsgServiceLib project: -------------------------------
    'Run the ADVL_Info_Exchange application to start the Info Exchange message service.
    'In Microsoft Visual Studio select: Project \ Add Service Reference
    'Press the down arrow and select the address of the service used by the Message Exchange:
    'http://localhost:8733/Design_Time_Addresses/WcfMsgServiceLib/Service1/mex
    'Press the Go button.
    'MsgService is found.
    'Press OK to add ServiceReference1 to the project.
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'ADD THE MsgServiceCallback CODE: ---------------------------------------------------------------------------------------------
    'In Microsoft Visual Studio select: Project \ Add Class
    'MsgServiceCallback.vb
    'Add the following code to the class:
    'Imports System.ServiceModel
    'Public Class MsgServiceCallback
    '    Implements ServiceReference1.IMsgServiceCallback
    '    Public Sub OnSendMessage(message As String) Implements ServiceReference1.IMsgServiceCallback.OnSendMessage
    '        'A message has been received.
    '        'Set the InstrReceived property value to the XMessage. This will also apply the instructions in the XMessage.
    '        Main.InstrReceived = message
    '    End Sub
    'End Class
    '------------------------------------------------------------------------------------------------------------------------------
#End Region

#Region " Variable Declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------

    Public WithEvents ApplicationInfo As New ADVL_Utilities_Library_1.ApplicationInfo 'This object is used to store application information.
    Public WithEvents Project As New ADVL_Utilities_Library_1.Project 'This object is used to store Project information.
    Public WithEvents Message As New ADVL_Utilities_Library_1.Message 'This object is used to display messages in the Messages window.
    Public WithEvents ApplicationUsage As New ADVL_Utilities_Library_1.Usage 'This object stores application usage information.

    'Declare objects used to connect to the Application Network: ----------------------------------------------------------------------
    '  Public client As ServiceReference1.MsgServiceClient
    'Public client As 
    'Public client As ServiceModel.ClientBase(Of MsgService) '????? Test

    'Public client As ServiceModel.
    Public WithEvents XMsg As New ADVL_Utilities_Library_1.XMessage
    Dim XDoc As New System.Xml.XmlDocument
    Public Status As New System.Collections.Specialized.StringCollection
    Dim ClientName As String 'The name of the client requesting coordinate operations
    Dim MessageText As String 'The text of a message sent through the MessageExchange
    Dim MessageDest As String 'The destination of a message sent through the MessageExchange.
    '----------------------------------------------------------------------------------------------------------------------------------

    Dim myMsgService As MsgService '=  New MsgService

    'Dim baseAddress As Uri = New Uri("Http://localhost:8080/Service1")

    'Dim Host As System.ServiceModel.ServiceHost
    'Dim Host As ServiceHost = New ServiceHost(TypeOf(myMsgService) , baseAddress)
    Dim selfHost As ServiceHost

    Private Shared myHost As ServiceHost
    Dim smb As ServiceMetadataBehavior



    'Flags used for adding new connections or applications: ---------------------------------------------------------------------------
    Dim AddNewConnection As Boolean = False 'If True, a new connection can be added to the connection list.
    Dim AddNewApplication As Boolean = False 'If True, a new application can be added to the application list.
    'If an application name is already on the application list, AddNewApplication is set to False.
    '----------------------------------------------------------------------------------------------------------------------------------

    'Application List: ----------------------------------------------------------------------------------------------------------------
    Dim App As New App 'App contains a list of all applications. App also contains methods to read, add and save the list.

    'Project Application List: --------------------------------------------------------------------------------------------------------
    Dim ProjectApp As New App 'ProjectApp contains a list of applications used in the selected project.

    '----------------------------------------------------------------------------------------------------------------------------------

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Properties - All the properties used in this form and this application" '------------------------------------------------------------------------------------------------------------

    Private _instrReceived As String = "" 'Contains Instructions received from the Application Network message service.
    Property InstrReceived As String
        Get
            Return _instrReceived
        End Get
        Set(value As String)
            If value = Nothing Then
                Message.Add("Empty message received!")
            Else
                _instrReceived = value

                'Add the message to the XMessages window:
                Message.Color = Color.Blue
                Message.FontStyle = FontStyle.Bold
                'Message.Add("Message received: " & vbCrLf)
                Message.XAdd("Message received: " & vbCrLf)
                Message.SetNormalStyle()
                Message.XAdd(_instrReceived & vbCrLf & vbCrLf)

                If _instrReceived.StartsWith("<XMsg>") Then 'This is an XMessage set of instructions.
                    Try
                        Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
                        XDoc.LoadXml(XmlHeader & vbCrLf & _instrReceived)
                        XMsg.Run(XDoc, Status)
                    Catch ex As Exception
                        Message.Add("Error running XMsg: " & ex.Message & vbCrLf)
                    End Try

                    'XMessage has been run.
                    'Reply to this message:
                    'Add the message reply to the XMessages window:
                    If ClientName = "" Then
                        'No client to send a message to!
                    Else
                        Message.Color = Color.Red
                        Message.FontStyle = FontStyle.Bold
                        'Message.Add("Message sent to " & ClientName & ":" & vbCrLf)
                        Message.XAdd("Message sent to " & ClientName & ":" & vbCrLf)
                        Message.SetNormalStyle()
                        Message.XAdd(MessageText & vbCrLf & vbCrLf)
                        MessageDest = ClientName
                        'SendMessage sends the contents of MessageText to MessageDest.
                        SendMessage() 'This subroutine triggers the timer to send the message after a short delay.
                    End If

                Else

                End If
            End If

        End Set
    End Property

#End Region 'Properties -----------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Process XML files - Read and write XML files." '-------------------------------------------------------------------------------------------------------------------------------------

    Private Sub SaveFormSettings()
        'Save the form settings in an XML document.
        Dim settingsData = <?xml version="1.0" encoding="utf-8"?>
                           <!---->
                           <!--Form settings for Main form.-->
                           <FormSettings>
                               <Left><%= Me.Left %></Left>
                               <Top><%= Me.Top %></Top>
                               <Width><%= Me.Width %></Width>
                               <Height><%= Me.Height %></Height>
                               <!---->
                               <SelectedTabIndex><%= TabControl1.SelectedIndex %></SelectedTabIndex>
                               <ConnectionApplicationNameColumnWidth><%= dgvConnections.Columns(0).Width %></ConnectionApplicationNameColumnWidth>
                               <ConnectionTypeColumnWidth><%= dgvConnections.Columns(1).Width %></ConnectionTypeColumnWidth>
                               <ConnectionCallbackHashcodeColumnWidth><%= dgvConnections.Columns(2).Width %></ConnectionCallbackHashcodeColumnWidth>
                               <ConnectionStartTimeColumnWidth><%= dgvConnections.Columns(3).Width %></ConnectionStartTimeColumnWidth>
                               <ApplicationNameColumnWidth><%= dgvApplications.Columns(0).Width %></ApplicationNameColumnWidth>
                               <ApplicationDescriptionColumnWidth><%= dgvApplications.Columns(1).Width %></ApplicationDescriptionColumnWidth>
                               <ConnectAppToNetwork><%= chkConnect.Checked %></ConnectAppToNetwork>
                           </FormSettings>
        'The Application Path is no longer shown in the dgvApplications grid view:
        '                               <ApplicationPathColumnWidth><%= dgvApplications.Columns(2).Width %></ApplicationPathColumnWidth>

        'Add code to include other settings to save after the comment line <!---->

        Dim SettingsName As String = "Formsettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Project.SaveXmlSettings(SettingsName, settingsData)
    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        Dim SettingsName As String = "Formsettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"

        If Project.SettingsFileExists(SettingsName) Then
            Dim Settings As System.Xml.Linq.XDocument
            Project.ReadXmlSettings(SettingsName, Settings)

            If IsNothing(Settings) Then 'There is no Settings XML data.
                Exit Sub
            End If

            'Restore form position and size:
            If Settings.<FormSettings>.<Left>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Left = Settings.<FormSettings>.<Left>.Value
            End If

            If Settings.<FormSettings>.<Top>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Top = Settings.<FormSettings>.<Top>.Value
            End If

            If Settings.<FormSettings>.<Height>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Height = Settings.<FormSettings>.<Height>.Value
            End If

            If Settings.<FormSettings>.<Width>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Width = Settings.<FormSettings>.<Width>.Value
            End If

            'Read other settings:
            If Settings.<FormSettings>.<SelectedTabIndex>.Value = Nothing Then
            Else
                TabControl1.SelectedIndex = Settings.<FormSettings>.<SelectedTabIndex>.Value
            End If
            If Settings.<FormSettings>.<ConnectionApplicationNameColumnWidth>.Value = Nothing Then
            Else
                dgvConnections.Columns(0).Width = Settings.<FormSettings>.<ConnectionApplicationNameColumnWidth>.Value
            End If
            If Settings.<FormSettings>.<ConnectionTypeColumnWidth>.Value = Nothing Then
            Else
                dgvConnections.Columns(1).Width = Settings.<FormSettings>.<ConnectionTypeColumnWidth>.Value
            End If
            If Settings.<FormSettings>.<ConnectionCallbackHashcodeColumnWidth>.Value = Nothing Then
            Else
                dgvConnections.Columns(2).Width = Settings.<FormSettings>.<ConnectionCallbackHashcodeColumnWidth>.Value
            End If
            If Settings.<FormSettings>.<ConnectionStartTimeColumnWidth>.Value = Nothing Then
            Else
                dgvConnections.Columns(3).Width = Settings.<FormSettings>.<ConnectionStartTimeColumnWidth>.Value
            End If
            If Settings.<FormSettings>.<ApplicationNameColumnWidth>.Value = Nothing Then
            Else
                dgvApplications.Columns(0).Width = Settings.<FormSettings>.<ApplicationNameColumnWidth>.Value
            End If
            If Settings.<FormSettings>.<ApplicationDescriptionColumnWidth>.Value = Nothing Then
            Else
                dgvApplications.Columns(1).Width = Settings.<FormSettings>.<ApplicationDescriptionColumnWidth>.Value
            End If
            'If Settings.<FormSettings>.<ApplicationPathColumnWidth>.Value = Nothing Then
            'Else
            '    dgvApplications.Columns(2).Width = Settings.<FormSettings>.<ApplicationPathColumnWidth>.Value
            'End If
            If Settings.<FormSettings>.<ConnectAppToNetwork>.Value = Nothing Then
                'Leave at defulat value.
            Else
                If Settings.<FormSettings>.<ConnectAppToNetwork>.Value = True Then
                    chkConnect.Checked = True
                Else
                    chkConnect.Checked = False
                End If
            End If

        End If
    End Sub

    Private Sub ReadApplicationInfo()
        'Read the Application Information.
        'Generate a new ApplicationInfo file if none exists.
        'ApplicationInfo.ApplicationDir = My.Application.Info.DirectoryPath.ToString 'Set the Application Directory property
        If ApplicationInfo.FileExists Then
            ApplicationInfo.ReadFile()
        Else
            'There is no Application_Info.xml file.
            'Set up default application properties:
            DefaultAppProperties()
        End If
    End Sub

    Private Sub DefaultAppProperties()

        ApplicationInfo.Name = "ADVL_Application_Network_1"

        'ApplicationInfo.ApplicationDir is set when the application is started.
        ApplicationInfo.ExecutablePath = Application.ExecutablePath

        ApplicationInfo.Description = "The Application Network is used to link Andorville (TM) software applications."
        ApplicationInfo.CreationDate = "4-Jul-2016 20:47:00"

        'Author -----------------------------------------------------------------------------------------------------------
        ApplicationInfo.Author.Name = "Signalworks Pty Ltd"
        ApplicationInfo.Author.Description = "Signalworks Pty Ltd" & vbCrLf &
            "Australian Proprietary Company" & vbCrLf &
            "ABN 26 066 681 598" & vbCrLf &
            "Registration Date 05/10/1994"

        ApplicationInfo.Author.Contact = "http://www.andorville.com.au/"


        'File Associations: -----------------------------------------------------------------------------------------------
        'Dim Assn1 As New ADVL_System_Utilities.FileAssociation
        'Assn1.Extension = "ADVLCoord"
        'Assn1.Description = "Andorville (TM) software coordinate system parameter file"
        'ApplicationInfo.FileAssociations.Add(Assn1)

        'Version ----------------------------------------------------------------------------------------------------------
        'http://stackoverflow.com/questions/4014687/application-productversion-always-returns-1-0-0-0
        ApplicationInfo.Version.Major = My.Application.Info.Version.Major
        ApplicationInfo.Version.Minor = My.Application.Info.Version.Minor
        ApplicationInfo.Version.Build = My.Application.Info.Version.Build
        ApplicationInfo.Version.Revision = My.Application.Info.Version.Revision

        'Cant write messages yet! Message object not yet created.
        'Message.Add("My.Application.Info.Version.ToString = " & My.Application.Info.Version.ToString & vbCrLf)
        'Debug.Print("My.Application.Info.Version.ToString = " & My.Application.Info.Version.ToString & vbCrLf) 'STILL 1.0.0.0 !!!!!

        'ApplicationInfo.Version.Major = My.Application.Deployment.CurrentVersion.Major 'An unhandled exception of type 'System.Deployment.Application.InvalidDeploymentException' occurred in System.Deployment.dll
        'ApplicationInfo.Version.Minor = My.Application.Deployment.CurrentVersion.Minor
        'ApplicationInfo.Version.Build = My.Application.Deployment.CurrentVersion.Build
        'ApplicationInfo.Version.Revision = My.Application.Deployment.CurrentVersion.Revision

        'Copyright --------------------------------------------------------------------------------------------------------
        ApplicationInfo.Copyright.OwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        ApplicationInfo.Copyright.PublicationYear = "2016"

        'Trademarks -------------------------------------------------------------------------------------------------------
        Dim Trademark1 As New ADVL_Utilities_Library_1.Trademark
        Trademark1.OwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        Trademark1.Text = "Andorville"
        Trademark1.Registered = False
        Trademark1.GenericTerm = "software"
        ApplicationInfo.Trademarks.Add(Trademark1)
        Dim Trademark2 As New ADVL_Utilities_Library_1.Trademark
        Trademark2.OwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        Trademark2.Text = "AL-H7"
        Trademark2.Registered = False
        Trademark2.GenericTerm = "software"
        ApplicationInfo.Trademarks.Add(Trademark2)

        'License -------------------------------------------------------------------------------------------------------
        ApplicationInfo.License.Type = ADVL_Utilities_Library_1.License.Types.Apache_License_2_0
        ApplicationInfo.License.CopyrightOwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        ApplicationInfo.License.PublicationYear = "2016"
        ApplicationInfo.License.Notice = ApplicationInfo.License.ApacheLicenseNotice
        ApplicationInfo.License.Text = ApplicationInfo.License.ApacheLicenseText

        'Source Code: --------------------------------------------------------------------------------------------------
        ApplicationInfo.SourceCode.Language = "Visual Basic 2015"
        ApplicationInfo.SourceCode.FileName = ""
        ApplicationInfo.SourceCode.FileSize = 0
        ApplicationInfo.SourceCode.FileHash = ""
        ApplicationInfo.SourceCode.WebLink = ""
        ApplicationInfo.SourceCode.Contact = ""
        ApplicationInfo.SourceCode.Comments = ""

        'ModificationSummary: -----------------------------------------------------------------------------------------
        ApplicationInfo.ModificationSummary.BaseCodeName = ""
        ApplicationInfo.ModificationSummary.BaseCodeDescription = ""
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Major = 0
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Minor = 0
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Build = 0
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Revision = 0
        ApplicationInfo.ModificationSummary.Description = "This is the first released version of the application. No earlier base code used."

        'Library List: ------------------------------------------------------------------------------------------------
        'Add ADVL_System_Utilties library:
        Dim NewLib As New ADVL_Utilities_Library_1.LibrarySummary
        NewLib.Name = "ADVL_System_Utilities"
        NewLib.Description = "System Utility classes used in Andorville (TM) software development system applications"
        NewLib.CreationDate = "7-Jan-2016 12:00:00"
        NewLib.LicenseNotice = "Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598" & vbCrLf &
                               vbCrLf &
                               "Licensed under the Apache License, Version 2.0 (the ""License"");" & vbCrLf &
                               "you may not use this file except in compliance with the License." & vbCrLf &
                               "You may obtain a copy of the License at" & vbCrLf &
                               vbCrLf &
                               "http://www.apache.org/licenses/LICENSE-2.0" & vbCrLf &
                               vbCrLf &
                               "Unless required by applicable law or agreed to in writing, software" & vbCrLf &
                               "distributed under the License is distributed on an ""AS IS"" BASIS," & vbCrLf &
                               "WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied." & vbCrLf &
                               "See the License for the specific language governing permissions and" & vbCrLf &
                               "limitations under the License." & vbCrLf

        NewLib.CopyrightNotice = "Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598"

        NewLib.Version.Major = 1
        NewLib.Version.Minor = 0
        NewLib.Version.Build = 1
        NewLib.Version.Revision = 0

        NewLib.Author.Name = "Signalworks Pty Ltd"
        NewLib.Author.Description = "Signalworks Pty Ltd" & vbCrLf &
            "Australian Proprietary Company" & vbCrLf &
            "ABN 26 066 681 598" & vbCrLf &
            "Registration Date 05/10/1994"

        NewLib.Author.Contact = "http://www.andorville.com.au/"

        Dim NewClass1 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass1.Name = "ZipComp"
        NewClass1.Description = "The ZipComp class is used to compress files into and extract files from a zip file."
        NewLib.Classes.Add(NewClass1)
        Dim NewClass2 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass2.Name = "XSequence"
        NewClass2.Description = "The XSequence class is used to run an XML property sequence (XSequence) file. XSequence files are used to record and replay processing sequences in Andorville (TM) software applications."
        NewLib.Classes.Add(NewClass2)
        Dim NewClass3 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass3.Name = "XMessage"
        NewClass3.Description = "The XMessage class is used to read an XML Message (XMessage). An XMessage is a simplified XSequence used to exchange information between Andorville (TM) software applications."
        NewLib.Classes.Add(NewClass3)
        Dim NewClass4 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass4.Name = "Location"
        NewClass4.Description = "The Location class consists of properties and methods to store data in a location, which is either a directory or archive file."
        NewLib.Classes.Add(NewClass4)
        Dim NewClass5 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass5.Name = "Project"
        NewClass5.Description = "An Andorville (TM) software application can store data within one or more projects. Each project stores a set of related data files. The Project class contains properties and methods used to manage a project."
        NewLib.Classes.Add(NewClass5)
        Dim NewClass6 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass6.Name = "ProjectSummary"
        NewClass6.Description = "ProjectSummary stores a summary of a project."
        NewLib.Classes.Add(NewClass6)
        Dim NewClass7 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass7.Name = "DataFileInfo"
        NewClass7.Description = "The DataFileInfo class stores information about a data file."
        NewLib.Classes.Add(NewClass7)
        Dim NewClass8 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass8.Name = "Message"
        NewClass8.Description = "The Message class contains text properties and methods used to display messages in an Andorville (TM) software application."
        NewLib.Classes.Add(NewClass8)
        Dim NewClass9 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass9.Name = "ApplicationSummary"
        NewClass9.Description = "The ApplicationSummary class stores a summary of an Andorville (TM) software application."
        NewLib.Classes.Add(NewClass9)
        Dim NewClass10 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass10.Name = "LibrarySummary"
        NewClass10.Description = "The LibrarySummary class stores a summary of a software library used by an application."
        NewLib.Classes.Add(NewClass10)
        Dim NewClass11 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass11.Name = "ClassSummary"
        NewClass11.Description = "The ClassSummary class stores a summary of a class contained in a software library."
        NewLib.Classes.Add(NewClass11)
        Dim NewClass12 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass12.Name = "ModificationSummary"
        NewClass12.Description = "The ModificationSummary class stores a summary of any modifications made to an application or library."
        NewLib.Classes.Add(NewClass12)
        Dim NewClass13 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass13.Name = "ApplicationInfo"
        NewClass13.Description = "The ApplicationInfo class stores information about an Andorville (TM) software application."
        NewLib.Classes.Add(NewClass13)
        Dim NewClass14 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass14.Name = "Version"
        NewClass14.Description = "The Version class stores application, library or project version information."
        NewLib.Classes.Add(NewClass14)
        Dim NewClass15 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass15.Name = "Author"
        NewClass15.Description = "The Author class stores information about an Author."
        NewLib.Classes.Add(NewClass15)
        Dim NewClass16 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass16.Name = "FileAssociation"
        NewClass16.Description = "The FileAssociation class stores the file association extension and description. An application can open files on its file association list."
        NewLib.Classes.Add(NewClass16)
        Dim NewClass17 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass17.Name = "Copyright"
        NewClass17.Description = "The Copyright class stores copyright information."
        NewLib.Classes.Add(NewClass17)
        Dim NewClass18 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass18.Name = "License"
        NewClass18.Description = "The License class stores license information."
        NewLib.Classes.Add(NewClass18)
        Dim NewClass19 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass19.Name = "SourceCode"
        NewClass19.Description = "The SourceCode class stores information about the source code for the application."
        NewLib.Classes.Add(NewClass19)
        Dim NewClass20 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass20.Name = "Usage"
        NewClass20.Description = "The Usage class stores information about application or project usage."
        NewLib.Classes.Add(NewClass20)
        Dim NewClass21 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass21.Name = "Trademark"
        NewClass21.Description = "The Trademark class stored information about a trademark used by the author of an application or data."
        NewLib.Classes.Add(NewClass21)

        ApplicationInfo.Libraries.Add(NewLib)

        'Add other library information here: --------------------------------------------------------------------------


    End Sub

#End Region 'Process XML Files ----------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Display Methods - Code used to display this form." '----------------------------------------------------------------------------------------------------------------------------

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Write the startup messages in a stringbuilder object.
        'Messages cannot be written using Message.Add until this is set up later in the startup sequence.
        Dim sb As New System.Text.StringBuilder
        sb.Append("------------------- Starting Application: ADVL Application Network ------------------------------------------------------------------ " & vbCrLf)

        'Set the Application Directory path: ------------------------------------------------
        Project.ApplicationDir = My.Application.Info.DirectoryPath.ToString
        sb.Append("Application Directory = " & Project.ApplicationDir & vbCrLf)

        'Read the Application Information file: ---------------------------------------------
        ApplicationInfo.ApplicationDir = My.Application.Info.DirectoryPath.ToString 'Set the Application Directory property

        If ApplicationInfo.ApplicationLocked Then
            MessageBox.Show("The application is locked. If the application is not already in use, remove the 'Application_Info.lock file from the application directory: " & ApplicationInfo.ApplicationDir, "Notice", MessageBoxButtons.OK)
            Dim dr As Windows.Forms.DialogResult
            dr = MessageBox.Show("Press 'Yes' to unlock the application", "Notice", MessageBoxButtons.YesNo)
            If dr = Windows.Forms.DialogResult.Yes Then
                ApplicationInfo.UnlockApplication()
            Else
                Application.Exit()
                'System.Windows.Forms.Application.Exit()
            End If
        End If

        ReadApplicationInfo()
        ApplicationInfo.LockApplication()

        'Read the Application Usage information: --------------------------------------------
        ApplicationUsage.StartTime = Now
        ApplicationUsage.SaveLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
        ApplicationUsage.SaveLocn.Path = Project.ApplicationDir
        ApplicationUsage.RestoreUsageInfo()
        sb.Append("Application usage: Total duration = " & ApplicationUsage.TotalDuration.TotalHours & " hours" & vbCrLf)

        'Restore Project information: -------------------------------------------------------
        Project.ApplicationName = ApplicationInfo.Name
        Project.ReadLastProjectInfo()
        Project.ReadProjectInfoFile()
        Project.Usage.StartTime = Now

        ApplicationInfo.SettingsLocn = Project.SettingsLocn

        'Set up the Message object:
        Message.ApplicationName = ApplicationInfo.Name
        Message.SettingsLocn = Project.SettingsLocn

        'Set up dgvConnections
        'Columns in the DataGridView are:  Application Name, Connection Type, Get All Warnings, Get All Messages, Callback HashCode, Connection Time
        dgvConnections.ColumnCount = 6
        dgvConnections.Columns(0).HeaderText = "Application Name"
        dgvConnections.Columns(1).HeaderText = "Connection Type"
        dgvConnections.Columns(2).HeaderText = "Get All Warnings"
        dgvConnections.Columns(3).HeaderText = "Get All Messages"
        dgvConnections.Columns(4).HeaderText = "Callback HashCode"
        dgvConnections.Columns(5).HeaderText = "Connection Start Time"
        dgvConnections.Rows.Clear()
        dgvConnections.AutoResizeColumns()
        dgvConnections.AutoResizeRows()
        dgvConnections.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

        'Set up dgvApplications:
        'Columns in the DataGridView are: Application Name, Description
        dgvApplications.ColumnCount = 2
        dgvApplications.Columns(0).HeaderText = "Name"
        dgvApplications.Columns(1).HeaderText = "Description"
        dgvApplications.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'dgvApplications.Columns(2).HeaderText = "Directory"
        'dgvApplications.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'dgvApplications.Columns(3).HeaderText = "Executable Path"
        'dgvApplications.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvApplications.Rows.Clear()
        dgvApplications.AutoResizeColumns()
        dgvApplications.AutoResizeRows()
        'dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        dgvApplications.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells

        'Set up dgvProjects:
        dgvProjects.ColumnCount = 4
        dgvProjects.Columns(0).HeaderText = "Name"
        dgvProjects.Columns(1).HeaderText = "Host Application"
        dgvProjects.Columns(2).HeaderText = "Type"
        dgvProjects.Columns(3).HeaderText = "Description"
        dgvProjects.Rows.Clear()
        dgvProjects.AutoResizeColumns()
        dgvProjects.AutoResizeRows()
        dgvProjects.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells

        'Automatically connect to the message server:
        '   client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))

        'Host = System.ServiceModel.ServiceHost(TypeOf(MsgService))
        'Host = New ServiceHost(TypeOf(MsgService.),baseAddress)
        'Host = New ServiceHost(TypeOf(myMsgService), baseAddress)
        'Using Host As ServiceHost = New ServiceHost(TypeOf(myMsgService) Is , baseAddress)
        'End Using

        'myMsgService = New MsgService
        'Host = New ServiceHost(GetType(myMsgService), baseAddress)
        'Host = New ServiceHost(GetType(myMsgService))
        'Host = New ServiceHost(TypeOf)

        'EXAMPLE CODE:
        'https://msdn.microsoft.com/en-us/library/ms730935(v=vs.110).aspx

        'Dim baseAddress As Uri = New Uri("http://localhost:8080/Service1")
        'Dim selfHost As New ServiceHost(GetType(MsgService), baseAddress)

        'SetUpHostV1() 'Version 1 of the Set Up Host code
        SetUpHostV2() 'Version 2 of the Set Up Host code


        'selfHost = New ServiceHost(GetType(MsgService), baseAddress)
        'Dim binding As NetNamedPipeBinding = New NetNamedPipeBinding(NetNamedPipeSecurityMode.Transport)
        'binding.Name = "Binding1"
        'binding.OpenTimeout = New TimeSpan(0, 1, 0)
        'binding.ReceiveTimeout = New TimeSpan(0, 10, 0)
        'binding.SendTimeout = New TimeSpan(0, 10, 0)
        'binding.TransactionFlow = False
        'binding.TransactionProtocol = System.ServiceModel.TransactionProtocol.OleTransactions
        'binding.TransferMode = System.ServiceModel.TransferMode.Buffered
        'binding.HostNameComparisonMode = System.ServiceModel.HostNameComparisonMode.StrongWildcard
        'binding.MaxBufferPoolSize = 524288
        'binding.MaxBufferSize = 65536
        'binding.MaxConnections = 10
        'binding.MaxReceivedMessageSize = 65536

        'Dim address As String = "net.pipe://localhost.Service1"
        'selfHost.AddServiceEndpoint(GetType(IMsgService), binding, address)

        'Dim smb As ServiceModel.Description.ServiceMetadataBehavior = New ServiceModel.Description.ServiceMetadataBehavior
        'smb.HttpGetEnabled = True
        'selfHost.Description.Behaviors.Add(smb)
        'selfHost.Open()

        'selfHost.AddServiceEndpoint( _
        '    GetType(IMsgService), _
        '    New WSHttpBinding(), _
        '    "MsgService")




        'Dim Result As Boolean
        ''     Result = client.Connect("ApplicationNetwork", ServiceReference1.clsConnectionenumAppType.MainNode, False, False)





        'If Result = True Then
        '    Message.Add("Connected to the Application Network as 'ApplicationNetwork'" & vbCrLf)
        'Else
        '    Message.SetWarningStyle()
        '    Message.Add("Connection to Application Network failed!" & vbCrLf)
        '    Message.SetNormalStyle()
        'End If

        chkConnect.Checked = True 'Connect to network is selected by default

        'Restore the form settings: ---------------------------------------------------------
        RestoreFormSettings()

        rbAllApplications.Checked = True 'By default show all applications.

        ReadApplicationList()
        ReadProjectApplicationList()

        'Show the project information:
        txtProjectName.Text = Project.Name
        txtProjectDescription.Text = Project.Description
        Select Case Project.Type
            Case ADVL_Utilities_Library_1.Project.Types.Directory
                txtProjectType.Text = "Directory"
            Case ADVL_Utilities_Library_1.Project.Types.Archive
                txtProjectType.Text = "Archive"
            Case ADVL_Utilities_Library_1.Project.Types.Hybrid
                txtProjectType.Text = "Hybrid"
            Case ADVL_Utilities_Library_1.Project.Types.None
                txtProjectType.Text = "None"
        End Select
        txtCreationDate.Text = Format(Project.Usage.FirstUsed, "d-MMM-yyyy H:mm:ss")
        txtLastUsed.Text = Format(Project.Usage.LastUsed, "d-MMM-yyyy H:mm:ss")
        Select Case Project.SettingsLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtSettingsLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtSettingsLocationType.Text = "Archive"
        End Select
        txtSettingsLocationPath.Text = Project.SettingsLocn.Path
        Select Case Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtDataLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtDataLocationType.Text = "Archive"
        End Select
        txtDataLocationPath.Text = Project.DataLocn.Path

        sb.Append("------------------- Started OK ------------------------------------------------------------------------------------------------------------------------ " & vbCrLf & vbCrLf)
        Me.Show() 'Show this form before showing the Message form
        Message.Add(sb.ToString)

    End Sub

    'Private Sub SetUpHostV1()
    '    'Version 1 of Set Up Host code:

    '    'Code Source:
    '    'http://www.xtremevbtalk.com/archive/index.php/t-326796.html


    '    Dim HttpBaseAddress As Uri = New Uri("http://localhost:8000/Service/") 'The address on which the service will run.
    '    Dim NetTcpBaseAddress As Uri = New Uri("net.tcp://localhost:8001/Service")
    '    Dim BaseAddresses As Uri() = {HttpBaseAddress, NetTcpBaseAddress}
    '    myHost = New ServiceModel.ServiceHost(GetType(MsgService), BaseAddresses) 'Create a new local service.
    '    Dim MetaDataBehavior As ServiceModel.Description.ServiceMetadataBehavior = myHost.Description.Behaviors.Find(Of Description.ServiceMetadataBehavior)() 'Create new metadata.

    '    If MetaDataBehavior Is Nothing Then
    '        MetaDataBehavior = New System.ServiceModel.Description.ServiceMetadataBehavior
    '        With MetaDataBehavior
    '            .HttpsGetEnabled = True
    '            .HttpGetEnabled = True
    '        End With
    '    End If

    '    myHost.Description.Behaviors.Add(MetaDataBehavior)
    '    myHost.AddServiceEndpoint(GetType(IMsgService), New System.ServiceModel.WSDualHttpBinding(), HttpBaseAddress) ' Add the contract to the channel.
    '    myHost.AddServiceEndpoint(GetType(IMsgService), New System.ServiceModel.NetTcpBinding(), NetTcpBaseAddress)
    '    myHost.AddServiceEndpoint(Description.ServiceMetadataBehavior.MexContractName, Description.MetadataExchangeBindings.CreateMexHttpBinding(), "mex") ' Add the metadata chennel to the service.
    '    myHost.Open()

    'End Sub

    Private Sub SetUpHostV2()
        'Version 2 of Set Up Host code:

        'Code Source:
        'https://msdn.microsoft.com/en-us/library/ms731758(v=vs.110).aspx?cs-save-lang=1&cs-lang=vb#code-snippet-4

        'Dim baseAddress As Uri = New Uri("http://localhost:8080/hello")
        'Dim baseAddress As Uri = New Uri("http://localhost:8000/MyService")
        'Dim baseAddress As Uri = New Uri("http://localhost:8733/MyService")
        Dim baseAddress As Uri = New Uri("http://localhost:8733/ADVLService")
        myHost = New ServiceModel.ServiceHost(GetType(MsgService), baseAddress)

        smb = New ServiceMetadataBehavior()
        smb.HttpGetEnabled = True
        'smb.HttpGetBinding.

        ''smb.HttpsGetBinding.OpenTimeout = New TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds
        'smb.HttpGetBinding.ReceiveTimeout = New TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds
        'smb.HttpGetBinding.OpenTimeout = New TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds
        'smb.HttpGetBinding.SendTimeout = New TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds
        'smb.HttpGetBinding.ReceiveTimeout = New TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds



        smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15
        myHost.Description.Behaviors.Add(smb)




        'Dim binding As NetNamedPipeBinding = New NetNamedPipeBinding(NetNamedPipeSecurityMode.Transport)
        'binding.Name = "Binding1"
        'binding.OpenTimeout = New TimeSpan(0, 1, 0)
        'binding.ReceiveTimeout = New TimeSpan(0, 10, 0)
        'binding.SendTimeout = New TimeSpan(0, 10, 0)
        'binding.TransactionFlow = False
        'binding.TransactionProtocol = System.ServiceModel.TransactionProtocol.OleTransactions
        'binding.TransferMode = System.ServiceModel.TransferMode.Buffered
        'binding.HostNameComparisonMode = System.ServiceModel.HostNameComparisonMode.StrongWildcard
        'binding.MaxBufferPoolSize = 524288
        'binding.MaxBufferSize = 65536
        'binding.MaxConnections = 10
        'binding.MaxReceivedMessageSize = 65536

        'selfHost.AddServiceEndpoint(GetType(IMsgService), binding, address)

        'Dim binding As New WSHttpBinding
        Dim binding As New WSDualHttpBinding
        binding.ReceiveTimeout = New TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds
        binding.OpenTimeout = New TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds
        binding.SendTimeout = New TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds
        binding.ReceiveTimeout = New TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds
        binding.MaxReceivedMessageSize = 2147483647
        binding.MaxBufferPoolSize = 2147483647
        binding.BypassProxyOnLocal = True
        binding.MessageEncoding = WSMessageEncoding.Text
        binding.ReaderQuotas.MaxArrayLength = 2147483647
        binding.ReaderQuotas.MaxStringContentLength = 2147483647
        binding.ReaderQuotas.MaxBytesPerRead = 2147483647
        binding.ReaderQuotas.MaxDepth = 2147483647
        binding.ReaderQuotas.MaxNameTableCharCount = 2147483647
        binding.ReliableSession.InactivityTimeout = New TimeSpan(1, 0, 0) '1 hour, 0 minutes, 0 seconds


        'myHost.AddServiceEndpoint(GetType(IMsgService), New ServiceModel.WSDualHttpBinding(), baseAddress)
        myHost.AddServiceEndpoint(GetType(IMsgService), binding, baseAddress)



        myHost.Open() 'Additional information: Contract requires Duplex, but Binding 'BasicHttpBinding' doesn't support it or isn't configured properly to support it.


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Application

        'Save the form settings: ------------------------------------------------------------
        SaveFormSettings()

        'Update the Application Information file: -------------------------------------------
        ApplicationInfo.WriteFile()
        ApplicationInfo.UnlockApplication()

        'Update the Project Information file: -----------------------------------------------
        Project.SaveProjectInfoFile()

        'Save Application Usage information: ------------------------------------------------
        ApplicationUsage.SaveUsageInfo()

        SendClosingMessage() 'This line causes the program to freeze!!!!

        ''Remove the project lock file:
        'Try
        '    'System.IO.File.Delete(ProjectPath & "\" & "Project.lock")
        '    'System.IO.File.Delete(Project.SettingsLocn. & "\" & "Project.lock")
        '    Project.DeleteSettings("Project.lock")

        'Catch ex As Exception
        '    MessageBox.Show("Error deleting project lock file: " & ex.Message, "Warning", MessageBoxButtons.OK)
        'End Try

        WriteApplicationList()
        WriteProjectApplicationList()

        Application.Exit()
        'System.Windows.Forms.Application.Exit()

    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------


    Private Sub ReadApplicationList()
        'Read the Application_List.xml file in the Application Directory.

        If System.IO.File.Exists(Project.ApplicationDir & "\Application_List.xml") Then
            Dim AppListXDoc As System.Xml.Linq.XDocument
            AppListXDoc = XDocument.Load(Project.ApplicationDir & "\Application_List.xml")

            Dim Apps = From item In AppListXDoc.<ApplicationList>.<Application>

            App.List.Clear()

            For Each item In Apps
                Dim NewApp As New ApplicationInfo
                NewApp.Name = item.<Name>.Value
                NewApp.Description = item.<Description>.Value
                NewApp.Directory = item.<Directory>.Value
                NewApp.ExecutablePath = item.<ExecutablePath>.Value
                App.List.Add(NewApp)
            Next

            UpdateApplicationGrid

        End If

    End Sub

    Private Sub ReadProjectApplicationList()
        'Read the Project Application list in the Project Directory.

        Dim DataFileName As String = "Project_Application_List.xml"
        Dim ProjectAppListXDoc As System.Xml.Linq.XDocument
        Project.ReadXmlData(DataFileName, ProjectAppListXDoc)

        ProjectApp.List.Clear()

        If IsNothing(ProjectAppListXDoc) Then
            Exit Sub
        End If

        Dim ProjectApps = From item In ProjectAppListXDoc.<ProjectApplicationList>.<Application>

        For Each item In ProjectApps
            Dim NewApp As New ApplicationInfo
            NewApp.Name = item.<Name>.Value
            NewApp.Description = item.<Description>.Value
            NewApp.Directory = item.<Directory>.Value
            NewApp.ExecutablePath = item.<ExecutablePath>.Value
            ProjectApp.List.Add(NewApp)
        Next

    End Sub

    Private Sub UpdateApplicationGrid()
        'Update dgvApplication with the contents of App.List

        dgvApplications.Rows.Clear()

        If rbAllApplications.Checked = True Then 'Show all applications in the list
            Dim NApps As Integer = App.List.Count

            If NApps = 0 Then
                Exit Sub
            End If

            Dim Index As Integer

            For Index = 0 To NApps - 1
                dgvApplications.Rows.Add()
                dgvApplications.Rows(Index).Cells(0).Value = App.List(Index).Name
                dgvApplications.Rows(Index).Cells(1).Value = App.List(Index).Description
                'dgvApplications.Rows(Index).Cells(2).Value = App.List(Index).Directory
                'dgvApplications.Rows(Index).Cells(3).Value = App.List(Index).ExecutablePath
            Next
        Else 'Show only the project applications.
            Dim NApps As Integer = ProjectApp.List.Count

            If NApps = 0 Then
                Exit Sub
            End If

            Dim Index As Integer

            For Index = 0 To NApps - 1
                dgvApplications.Rows.Add()
                dgvApplications.Rows(Index).Cells(0).Value = ProjectApp.List(Index).Name
                dgvApplications.Rows(Index).Cells(1).Value = ProjectApp.List(Index).Description
                'dgvApplications.Rows(Index).Cells(2).Value = App.List(Index).Directory
                'dgvApplications.Rows(Index).Cells(3).Value = App.List(Index).ExecutablePath
            Next
        End If

        dgvApplications.AutoResizeColumns()

    End Sub

    Private Sub WriteApplicationList()
        'Write the Application List in App.List() to the Application_List.xml file in the Application Directory.

        Dim ApplicationListXDoc = <?xml version="1.0" encoding="utf-8"?>
                                  <!---->
                                  <!--Application List File-->
                                  <ApplicationList>
                                      <%= From item In App.List
                                          Select
                                          <Application>
                                              <Name><%= item.Name %></Name>
                                              <Description><%= item.Description %></Description>
                                              <Directory><%= item.Directory %></Directory>
                                              <ExecutablePath><%= item.ExecutablePath %></ExecutablePath>
                                          </Application>
                                      %>
                                  </ApplicationList>

        ApplicationListXDoc.Save(Project.ApplicationDir & "\Application_List.xml")

    End Sub

    Private Sub WriteProjectApplicationList()
        'Write the Project Application List in ProjectApp.List() to the Project_Application_List.xml file in the Project Data Location.

        Dim ProjectApplicationListXDoc = <?xml version="1.0" encoding="utf-8"?>
                                         <!---->
                                         <!--ProjectApplication List File-->
                                         <ProjectApplicationList>
                                             <%= From item In ProjectApp.List
                                                 Select
                                          <Application>
                                              <Name><%= item.Name %></Name>
                                              <Description><%= item.Description %></Description>
                                              <Directory><%= item.Directory %></Directory>
                                              <ExecutablePath><%= item.ExecutablePath %></ExecutablePath>
                                          </Application>
                                             %>
                                         </ProjectApplicationList>

        Project.SaveXmlData("Project_Application_List.xml", ProjectApplicationListXDoc)

    End Sub

    Private Sub SendClosingMessage()
        'Send a message to all connections to notify them that the Application Network is closing.

        'Create XML document:
        'Dim doc As XDocument =
        '    <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
        '    <XMsg>
        '        <MessageExchangeClosing>"True"</MessageExchangeClosing>
        '    </XMsg>

        'Create XML document:
        Dim doc As XDocument =
                   <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                   <XMsg>
                       <ApplicationNetworkClosing>"True"</ApplicationNetworkClosing>
                   </XMsg>


        'If IsNothing(client) Then
        '    Message.Add("No client connection available!" & vbCrLf)
        'Else
        '    If client.State = ServiceModel.CommunicationState.Faulted Then
        '        Message.Add("client state is faulted. Message not sent!" & vbCrLf)
        '        'Dim StateFlag As System.Enum
        '        'Dim StateHasFlag As Boolean
        '        'StateHasFlag = client.State.HasFlag(StateFlag)
        '    Else
        '        'Main.client.SendMessageAsync(txtDestination.Text, rtbMessageToSend.Text)
        '        'client.SendMessageAsync("CoordinateServer", doc.ToString)

        '        'rtbInstructionsSent.Text = "--- XMessage sent to all connections: ---" & vbCrLf
        '        'rtbInstructionsSent.AppendText(doc.ToString)
        '        Message.XAdd("--- XMessage sent to all connections: ---" & vbCrLf)
        '        Message.XAdd(doc.ToString & vbCrLf)

        '        client.SendAllMessage(doc.ToString, "ApplicationNetwork")
        '    End If

        'End If


    End Sub


    Private Sub btnProject_Click(sender As Object, e As EventArgs) Handles btnProject.Click
        Project.SelectProject()
    End Sub

    Private Sub btnAppInfo_Click(sender As Object, e As EventArgs) Handles btnAppInfo.Click
        ApplicationInfo.ShowInfo()
    End Sub

    Private Sub btnMessages_Click(sender As Object, e As EventArgs) Handles btnMessages.Click
        Message.ApplicationName = ApplicationInfo.Name
        Message.SettingsLocn = Project.SettingsLocn
        Message.Show()
        Message.MessageForm.BringToFront()
    End Sub

    'Private Sub btnAutoResize_Click(sender As Object, e As EventArgs) Handles btnAutoResize.Click
    '    dgvApplications.AutoResizeRows()
    '    dgvConnections.AutoResizeRows()
    'End Sub

    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter

    End Sub

    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        dgvConnections.AutoResizeColumns()
    End Sub

    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter
        dgvApplications.AutoResizeRows()
    End Sub

    Private Sub btnStartApp_Click(sender As Object, e As EventArgs) Handles btnStartApp.Click
        'Start the selected application

        If dgvApplications.SelectedRows.Count > 0 Then 'At least one Application has been selected.
            Dim AppNo As Integer = dgvApplications.SelectedRows(0).Index
            Dim ExePath As String

            If rbAllApplications.Checked = True Then 'The list of all Applications is displayed.
                ExePath = App.List(AppNo).ExecutablePath
            Else 'The list of Project Applications is displayed.
                ExePath = ProjectApp.List(AppNo).ExecutablePath
            End If

            If System.IO.File.Exists(ExePath) Then
                If chkConnect.Checked = True Then
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim ConnectDoc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    Dim xcommand As New XElement("Command", "ConnectToAppNet")
                    xmessage.Add(xcommand)
                    ConnectDoc.Add(xmessage)
                    'Start the application with the argument string containing the instruction to connect to the AppNet
                    Shell(Chr(34) & ExePath & Chr(34) & " " & Chr(34) & ConnectDoc.ToString & Chr(34), AppWinStyle.NormalFocus)
                Else
                    Shell(Chr(34) & ExePath & Chr(34), AppWinStyle.NormalFocus) 'Start the application with no argument
                End If
            Else
                Message.SetWarningStyle()
                Message.Add("Executable file not found: " & vbCrLf)
                Message.Add(ExePath & vbCrLf & vbCrLf)
                Message.SetNormalStyle()
            End If
        Else
            'No Application is selected.
        End If

        'This test code generates two strings to use as arguments passed to the application when it is started:
        'Dim Arg1 As String = "Argument 1 String Test"
        'Dim Arg2 As String = "Argument 2 String Test"

        'This test code passes the two argument strings to the application when it is started:
        'Shell(Chr(34) & ExePath & Chr(34) & " " & Chr(34) & Arg1 & Chr(34) & " " & Chr(34) & Arg2 & Chr(34), AppWinStyle.NormalFocus)

    End Sub

    Private Sub btnRemoveApp_Click(sender As Object, e As EventArgs) Handles btnRemoveApp.Click
        'Remove the selected application
        If dgvApplications.SelectedRows.Count > 0 Then
            Dim AppNo As Integer = dgvApplications.SelectedRows(0).Index

            If rbAllApplications.Checked = True Then 'The list of all Applications is displayed.
                App.List.RemoveAt(AppNo)
            Else 'The list of Project Applications is displayed.
                ProjectApp.List.RemoveAt(AppNo)
            End If

            UpdateApplicationGrid()
        Else
            'No Application is selected.
        End If
    End Sub

    Private Sub rbAllApplications_CheckedChanged(sender As Object, e As EventArgs) Handles rbAllApplications.CheckedChanged
        UpdateApplicationGrid()
    End Sub

    Private Sub dgvApplications_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvApplications.CellContentClick

        'If dgvApplications.SelectedRows.Count > 0 Then
        If e.RowIndex > -1 Then
            Dim RowNo As Integer = e.RowIndex
            dgvApplications.Rows(RowNo).Selected = True
            If rbAllApplications.Checked = True Then
                txtDirectory.Text = App.List(RowNo).Directory
                txtExePath.Text = App.List(RowNo).ExecutablePath
            Else
                txtDirectory.Text = ProjectApp.List(RowNo).Directory
                txtExePath.Text = ProjectApp.List(RowNo).ExecutablePath
            End If

        End If

    End Sub

    Private Sub btnAndorville_Click(sender As Object, e As EventArgs) Handles btnAndorville.Click
        ApplicationInfo.ShowInfo()
    End Sub


#Region "Run XMessage Statements"

    Private Sub XMsg_ErrorMsg(ErrMsg As String) Handles XMsg.ErrorMsg
        'Process the error message:
        Message.Add("XMsg Error message: " & ErrMsg & vbCrLf)
    End Sub

    'Private Sub XMsg_Instruction(Locn As String, Info As String) Handles XMsg.Instruction
    Private Sub XMsg_Instruction(Info As String, Locn As String) Handles XMsg.Instruction
        'Process each Property Path and Property Value instruction.

        'These flags must be declared at the start of the forms code, to save the state between subroutine calls.
        'Dim AddNewConnection As Boolean = False 'If True, a new connection can be added to the connection list.

        'Dim AddNewApplication As Boolean = False 'If True, a new application can be added to the application list.
        ''If an application name is already on the application list, AddNewApplication is set to False.

        Select Case Locn
            'Add a new connection entry -----------------------------------------------------------------------------------------------------------------------------
            Case "NewConnectionInfo:ApplicationName"
                'A new row is added to the dgvConnection grid when a new connection application name is received.
                'dgvConnections.Rows.Add()

                'PROBLEM: Grid starts with a blank row. Need to initially add data to this first blank row, then add new row for later records.
                'Application Name, Connection Type, Get All Warnings, Get All Messages, Callback HashCode, Connection Time

                If ConnectionAppNameAvailable(Info) Then
                    AddNewConnection = True
                    dgvConnections.Rows.Add()
                    Dim CurrentRow As Integer = dgvConnections.Rows.Count - 2
                    dgvConnections.Rows(CurrentRow).Cells(0).Value = Info
                    dgvConnections.AutoResizeRows()
                Else
                    AddNewConnection = False
                End If
            Case "NewConnectionInfo:ConnectionType"
                If AddNewConnection = True Then
                    Dim CurrentRow As Integer = dgvConnections.Rows.Count - 2
                    dgvConnections.Rows(CurrentRow).Cells(1).Value = Info
                    dgvConnections.AutoResizeRows()
                End If
            Case "NewConnectionInfo:GetAllWarnings"
                If AddNewConnection = True Then
                    Dim CurrentRow As Integer = dgvConnections.Rows.Count - 2
                    dgvConnections.Rows(CurrentRow).Cells(2).Value = Info
                    dgvConnections.AutoResizeRows()
                End If
            Case "NewConnectionInfo:GetAllMessages"
                If AddNewConnection = True Then
                    Dim CurrentRow As Integer = dgvConnections.Rows.Count - 2
                    dgvConnections.Rows(CurrentRow).Cells(3).Value = Info
                    dgvConnections.AutoResizeRows()
                End If
            Case "NewConnectionInfo:CallbackHashcode"
                If AddNewConnection = True Then
                    Dim CurrentRow As Integer = dgvConnections.Rows.Count - 2
                    dgvConnections.Rows(CurrentRow).Cells(4).Value = Info
                    dgvConnections.AutoResizeRows()
                End If
            Case "NewConnectionInfo:ConnectionStartTime"
                If AddNewConnection = True Then
                    Dim CurrentRow As Integer = dgvConnections.Rows.Count - 2
                    dgvConnections.Rows(CurrentRow).Cells(5).Value = Info
                    dgvConnections.AutoResizeRows()
                End If
                '---------------------------------------------------------------------------------------------------------------------------------------------
                'Add an Application Info entry ---------------------------------------------------------------------------------------------------------------
            Case "ApplicationInfo:Name"
                If ApplicationNameAvailable(Info) Then
                    AddNewApplication = True
                    dgvApplications.Rows.Add()
                    Dim CurrentRow As Integer = dgvApplications.Rows.Count - 2
                    dgvApplications.Rows(CurrentRow).Cells(0).Value = Info
                    Dim NewAppInfo As New ApplicationInfo
                    NewAppInfo.Name = Info
                    App.List.Add(NewAppInfo)
                Else
                    AddNewApplication = False
                End If
                'dgvApplications.Rows.Add()
                'dgvApplications.Rows(dgvApplications.Rows.Count - 2).Cells(0).Value = Prop
            Case "ApplicationInfo:Directory"
                If AddNewApplication = True Then
                    Dim CurrentRow As Integer = dgvApplications.Rows.Count - 2
                    'Applications grid now shows only Name and Description
                    'dgvApplications.Rows(CurrentRow).Cells(2).Value = Info
                    'dgvApplications.AutoResizeRows()
                    App.List(CurrentRow).Directory = Info
                End If
                'dgvApplications.Rows(dgvApplications.Rows.Count - 2).Cells(2).Value = Prop
            Case "ApplicationInfo:Description"
                If AddNewApplication = True Then
                    Dim CurrentRow As Integer = dgvApplications.Rows.Count - 2
                    dgvApplications.Rows(CurrentRow).Cells(1).Value = Info
                    dgvApplications.AutoResizeRows()
                    App.List(CurrentRow).Description = Info
                End If
                'dgvApplications.Rows(dgvApplications.Rows.Count - 2).Cells(1).Value = Prop
            Case "ApplicationInfo:ExecutablePath"
                If AddNewApplication = True Then
                    Dim CurrentRow As Integer = dgvApplications.Rows.Count - 2
                    'Applications grid now shows only Name and Description
                    'dgvApplications.Rows(CurrentRow).Cells(3).Value = Info
                    'dgvApplications.AutoResizeRows()
                    App.List(CurrentRow).ExecutablePath = Info
                End If
                '----------------------------------------------------------------------------------------------------------------------------------------------
                'Remove a connection entry --------------------------------------------------------------------------------------------------------------------
            Case "RemovedConnectionInfo:ApplicationName"
                RemoveConnectionWithAppName(Info)

            Case "EndOfSequence"
                AddNewConnection = False
                AddNewApplication = False
            Case Else
                Message.Add("Instruction not recognised:  " & Locn & "    Property:  " & Info & vbCrLf)

        End Select

    End Sub

    'Private Function ConnectionAppNameAvailable(ByVal AppName As String) As Boolean
    Public Function ConnectionAppNameAvailable(ByVal AppName As String) As Boolean
        'If AppName is not in the Connection list, ConnectionAppNameAvailable is set to True.
        'If AppName is already on the list, the name is not available for a new connection.

        Dim NameFound As Boolean = False
        Dim I As Integer 'Loop index
        For I = 0 To dgvConnections.Rows.Count - 1
            If dgvConnections.Rows(I).Cells(0).Value = AppName Then
                NameFound = True
                Exit For
            End If
        Next

        If NameFound = True Then
            Return False
        Else
            Return True
        End If

    End Function

    'Private Sub RemoveConnectionWithAppName(ByVal AppName As String)
    Public Sub RemoveConnectionWithAppName(ByVal AppName As String)
        'Remove the connection entry for AppName

        'Dim NameFound As Boolean = False
        Dim I As Integer 'Loop index
        For I = 0 To dgvConnections.Rows.Count - 1
            If dgvConnections.Rows(I).Cells(0).Value = AppName Then
                'NameFound = True
                dgvConnections.Rows.Remove(dgvConnections.Rows(I))
                Exit For
            End If
        Next
    End Sub

    Private Function ApplicationNameAvailable(ByVal AppName As String) As Boolean
        'If AppName is not in the Application list, ApplicationNameAvailable is set to True.

        Dim NameFound As Boolean = False
        Dim I As Integer 'Loop index
        For I = 0 To dgvApplications.Rows.Count - 1
            If dgvApplications.Rows(I).Cells(0).Value = AppName Then
                NameFound = True
                Exit For
            End If
        Next

        If NameFound = True Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub dgvApplications_Resize(sender As Object, e As EventArgs) Handles dgvApplications.Resize
        If dgvApplications.Columns.Count > 3 Then
            Dim DGVerticalScroll = dgvApplications.Controls.OfType(Of VScrollBar).SingleOrDefault.Visible

            If DGVerticalScroll Then
                dgvApplications.Columns(3).Width = dgvApplications.Width - dgvApplications.Columns(0).Width - dgvApplications.Columns(1).Width - dgvApplications.Columns(2).Width - dgvApplications.RowHeadersWidth - 22
                'dgvApplications.AutoResizeColumns()
                'dgvApplications.AutoResizeColumn(3)
                dgvApplications.AutoResizeRows()
            Else
                dgvApplications.Columns(3).Width = dgvApplications.Width - dgvApplications.Columns(0).Width - dgvApplications.Columns(1).Width - dgvApplications.Columns(2).Width - dgvApplications.RowHeadersWidth - 4
                'dgvApplications.AutoResizeColumns()
                'dgvApplications.AutoResizeColumn(3)
                dgvApplications.AutoResizeRows()
            End If
        Else
            'dgvAplications has not been configured with 4 columns yet.
        End If
    End Sub

#End Region 'Run XMessage Statements

#Region " Send XMessages"

    Private Sub SendMessage()
        'Code used to send a message after a timer delay.
        'The message destination is stored in MessageDest
        'The message text is stored in MessageText
        Timer1.Interval = 100 '100ms delay
        Timer1.Enabled = True 'Start the timer.
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        'If IsNothing(client) Then
        '    Message.SetWarningStyle()
        '    Message.Add("No client connection available!" & vbCrLf)
        'Else
        '    If client.State = ServiceModel.CommunicationState.Faulted Then
        '        Message.SetWarningStyle()
        '        Message.Add("client state is faulted. Message not sent!" & vbCrLf)
        '    Else
        '        Try
        '            Message.Add("Sending a message. Number of characters: " & MessageText.Length & vbCrLf)
        '            client.SendMessage(MessageDest, MessageText)
        '            Message.XAdd(MessageText & vbCrLf)
        '            MessageText = "" 'Clear the message after it has been sent.
        '        Catch ex As Exception
        '            Message.SetWarningStyle()
        '            Message.Add("Error sending message: " & ex.Message & vbCrLf)
        '        End Try
        '    End If
        'End If

        'Stop timer:
        Timer1.Enabled = False
    End Sub




#End Region 'Send XMessages

#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Events - Events that can be triggered by this form." '--------------------------------------------------------------------------------------------------------------------------
#End Region 'Form Events ----------------------------------------------------------------------------------------------------------------------------------------------------------------------


End Class 'Main

'Public Class Application 
'The Application class was renamed the App class.
'    If a class is named Application, existing Application.Exit() code must be changed to System.Windows.Forms.Application.Exit()

Public Class App
    'Class holds a list of applications.

    Public List As New List(Of ApplicationInfo) 'A list of applications

#Region "Application Methods" '--------------------------------------------------------------------------------------

#End Region 'Application Methods ------------------------------------------------------------------------------------

End Class 'App

Public Class ApplicationInfo
    'Class holds information for an Application.

    Private _name As String = ""
    Property Name As String 'The name of the Application.
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Private _description As String = ""
    Property Description As String 'A description of the Application.
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Private _directory As String = ""
    Property Directory As String  'The directory containing the application.
        Get
            Return _directory
        End Get
        Set(value As String)
            _directory = value
        End Set
    End Property

    Private _executablePath As String = ""
    Property ExecutablePath As String 'The path of the Application Executable File.
        Get
            Return _executablePath
        End Get
        Set(value As String)
            _executablePath = value
        End Set
    End Property


End Class 'ApplicationInfo
