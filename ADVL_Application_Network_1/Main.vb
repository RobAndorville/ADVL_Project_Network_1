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

Imports System.Security.Permissions
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
<System.Runtime.InteropServices.ComVisibleAttribute(True)>
Public Class Main
    'The ADVL Application Network is used to manage Andorville applications and exchange information between them.

    'Application code name: AMI-Net (Andorville Machine Intelligence Network).

#Region " CODING NOTES" '============================================================================================================================================
    'CODING NOTES:

    'ADD THE SYSTEM UTILITIES REFERENCE: ==========================================================================================
    'The following references are required by this software: 
    'Project \ Add Reference... \ ADVL_System_Utilities.dll   SEE NEW LIBRARY NAME BELOW
    'Project \ Add Reference... \ ADVL_Utilities_Library_1.dll (or add the project ADVL_Utilities_Library_1.vbprog if it has been added to the solution)

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
    '
    'Calling JavaScript from VB.NET:
    'The following Imports statement and permissions are required for the Main form:
    'Imports System.Security.Permissions
    '<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    '<System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    'NOTE: the line continuation characters (_) will disappear form the code view after they have been typed!
    '------------------------------------------------------------------------------------------------------------------------------
    'Calling VB.NET from JavaScript
    'Add the following line to the Main.Load method:
    '  Me.WebBrowser1.ObjectForScripting = Me
    '------------------------------------------------------------------------------------------------------------------------------

#End Region 'Coding Notes --------------------------------------------------------------------------------------------------------------------------------

#Region " Variable Declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------

    Public WithEvents ApplicationInfo As New ADVL_Utilities_Library_1.ApplicationInfo 'This object is used to store application information.
    Public WithEvents Project As New ADVL_Utilities_Library_1.Project 'This object is used to store Project information.
    Public WithEvents Message As New ADVL_Utilities_Library_1.Message 'This object is used to display messages in the Messages window.
    Public WithEvents ApplicationUsage As New ADVL_Utilities_Library_1.Usage 'This object stores application usage information.

    'Declare Forms used by the application:
    Public WithEvents HtmlDisplay As frmHtmlDisplay
    Public WithEvents AddApplication As frmAddApplication
    Public WithEvents WebPageList As frmWebPageList

    Public WithEvents NewHtmlDisplay As frmHtmlDisplay
    Public HtmlDisplayFormList As New ArrayList 'Used for displaying multiple HtmlDisplay forms.

    Public WithEvents NewWebPage As frmWebPage
    Public WebPageFormList As New ArrayList 'Used for displaying multiple WebView forms.


    'Declare objects used to connect to the Application Network: ----------------------------------------------------------------------
    Public client As ServiceReference1.MsgServiceClient
    Public WithEvents XMsg As New ADVL_Utilities_Library_1.XMessage
    Dim XDoc As New System.Xml.XmlDocument
    Public Status As New System.Collections.Specialized.StringCollection
    Dim ClientAppName As String 'The name of the client requesting coordinate operations
    Dim ClientAppNetName As String = "" 'The name of thge client Application Network requesting service. ADDED 2Feb19.
    Dim ClientConnName As String = "" 'The name of the client connection requesting service
    Dim MessageText As String 'The text of a message sent through the MessageExchange
    Dim MessageXDoc As System.Xml.Linq.XDocument
    Dim xmessage As XElement 'This will contain the message. It will be added to MessageXDoc.
    Dim xlocns As New List(Of XElement) 'A list of locations. Each location forms part of the reply message. The information in the reply message will be sent to the specified location in the client application.

    Dim MessageDest As String 'The destination of a message sent through the MessageExchange.

    Public ConnectionName As String

    Public AppNetName As String = "" 'Added 2Fab19

    Public MsgServiceAppPath As String = "" 'The application path of the Message Service application (ComNet). This is where the "Application.Lock" file will be while ComNet is running
    Public MsgServiceExePath As String = "" 'The executable path of the Message Service.
    '----------------------------------------------------------------------------------------------------------------------------------

    'Flags used for adding new connections or applications: ---------------------------------------------------------------------------
    Dim AddNewConnection As Boolean = False 'If True, a new connection can be added to the connection list.
    Dim AddNewApplication As Boolean = False 'If True, a new application can be added to the application list.
    Dim ApplicationNo As Integer 'The index number of an application that has been found in the App list.
    'If an application name is already on the application list, AddNewApplication is set to False.
    '----------------------------------------------------------------------------------------------------------------------------------

    'Variables used to start a new application: ---------------------------------------------------------------------------------------
    Dim StartAppName As String = ""
    Dim StartAppConnName As String = ""
    Dim StartAppProjectName As String = "" 'For starting an application with a specific project name.
    Dim StartAppProjectID As String = ""   'For starting an application with a specific project ID.
    Dim StartAppProjectPath As String = "" 'For starting an application with a specific project path.
    '----------------------------------------------------------------------------------------------------------------------------------


    'Application Dictionary: ----------------------------------------------------------------------------------------------------------
    Dim AddNewApp As Boolean = False 'If True, a new application can be added to the AppInfo dictionary.
    Dim AppName As String = ""    'The name of the new App. (This is also the key for the AppInfo dictionary.)
    Dim AppText As String = ""    'The text of the new App (Displayed on the AppTree).
    Public AppInfo As New Dictionary(Of String, clsAppInfo) 'Dictionary of information about each application shown in the AppTreeView. The Name is the key.

    'Project Dictionary: --------------------------------------------------------------------------------------------------------------
    Dim AddNewProject As Boolean = False 'If True, a new project is being added to the ProjectInfo dictionary.
    Dim ProjectName As String = ""       'The name of the new project. (This is also the key for the ProjectInfo dictionary.) 
    Dim ProjectText As String = ""       'The text of the new project (displayed on the AppTree).
    Dim ProjInfo As New Dictionary(Of String, clsProjInfo) 'Dictionary of information about each project shown in the AppTreeView.
    'The dictionary key is the ID and ".Proj"

    'Project Tree Dictionary: ---------------------------------------------------------------------------------------------------------
    Dim ProjTreeInfo As New Dictionary(Of String, clsProjInfo) 'Dictionary of information about each project shown in the ProjTreeView.
    'The dictionary Key is the ProjectID
    'Info fields: Name, Description, Type, Path, ID, ApplicationName, ParentProjectName, ParentProjectID, IconNumber, OpenIconNumber.
    'NOTE: clsProjInfo is reused from the ProjInfo dictionary. The ID field is redundant - ID is also used as the dictionary key.

    Dim NApplicationIcons As Integer = 0 'The number of application icons.
    Dim NProjectIcons As Integer = 8 'The number of Project icons. (These 8 icons are stored in ProjectIconImageList and added to AppTreeImageList when an App Tree is opened.)

    Dim NProjectTreeIcons As Integer = 0 'The number of Project Tree icons.

    'Main.Load variables:
    Dim ProjectSelected As Boolean = False 'If True, a project has been selected using Command Arguments. Used in Main.Load.
    Dim StartupConnectionName As String = "" 'If not "" the application will be connected to the ComNet using this connection name in  Main.Load.


    'The following variables are used to run JavaScript in Web Pages loaded into the Document View: -------------------
    Public WithEvents XSeq As New ADVL_Utilities_Library_1.XSequence
    'To run an XSequence:
    '  XSeq.RunXSequence(xDoc, Status) 'ImportStatus in Import
    '    Handle events:
    '      XSeq.ErrorMsg
    '      XSeq.Instruction(Info, Locn)

    Private XStatus As New System.Collections.Specialized.StringCollection

    'Variables used to restore Item values on a web page.
    Private FormName As String
    Private ItemName As String
    Private SelectId As String

    'StartProject variables:
    Private StartProject_AppName As String  'The application name
    Private StartProject_ConnName As String 'The connection name
    Private StartProject_ProjID As String   'The project ID
    Private StartProject_ProjName As String ' The project name

    'Get AppList in Add Application form
    Dim NewAppName As String 'The new application name that is being added to the the AppList dictionary in the Add Application form.

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Properties - All the properties used in this form and this application" '------------------------------------------------------------------------------------------------------------

    Private _connectedToComNet As Boolean = False  'True if the application is connected to the Communication Network.
    Property ConnectedToComNet As Boolean
        Get
            Return _connectedToComNet
        End Get
        Set(value As Boolean)
            _connectedToComNet = value
        End Set
    End Property

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
                Message.XAddText("Message received: " & vbCrLf, "XmlReceivedNotice")
                If _instrReceived.StartsWith("<XMsg>") Then 'This is an XMessage set of instructions.
                    Try
                        'Inititalise the reply message:
                        Dim Decl As New XDeclaration("1.0", "utf-8", "yes")
                        MessageXDoc = New XDocument(Decl, Nothing) 'Reply message - this will be sent to the Client App.
                        xmessage = New XElement("XMsg")
                        xlocns.Add(New XElement("Main")) 'Initially set the location in the Client App to Main.

                        'Run the received message:
                        Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
                        XDoc.LoadXml(XmlHeader & vbCrLf & _instrReceived)
                        Message.XAddXml(XDoc)
                        Message.XAddText(vbCrLf, "Normal") 'Add extra line
                        XMsg.Run(XDoc, Status)
                    Catch ex As Exception
                        Message.Add("Error running XMsg: " & ex.Message & vbCrLf)
                    End Try

                    'XMessage has been run.
                    'Reply to this message:
                    'Add the message reply to the XMessages window:
                    'Complete the MessageXDoc:
                    xmessage.Add(xlocns(xlocns.Count - 1)) 'Add the last location reply instructions to the message.
                    MessageXDoc.Add(xmessage)
                    MessageText = MessageXDoc.ToString

                    If ClientAppName = "" Then
                        'No client to send a message to!
                    Else
                        Message.XAddText("Message sent to " & ClientAppName & ":" & vbCrLf, "XmlSentNotice")
                        Message.XAddXml(MessageText)
                        Message.XAddText(vbCrLf, "Normal") 'Add extra line
                        SendMessage() 'This subroutine triggers the timer to send the message after a short delay.
                    End If
                Else 'This is not an XMessage!
                    Message.XAddText("The message is not an XMessage: " & _instrReceived & vbCrLf, "Normal")
                End If
            End If
        End Set
    End Property

    Private _closedFormNo As Integer 'Temporarily holds the number of the form that is being closed. 
    Property ClosedFormNo As Integer
        Get
            Return _closedFormNo
        End Get
        Set(value As Integer)
            _closedFormNo = value
        End Set
    End Property

    Private _startPageFileName As String = "" 'The file name of the html document displayed in the Start Page tab.
    Public Property StartPageFileName As String
        Get
            Return _startPageFileName
        End Get
        Set(value As String)
            _startPageFileName = value
            'txtDocumentFile.Text = _fileName
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
                               <MsgServiceAppPath><%= MsgServiceAppPath %></MsgServiceAppPath>
                               <MsgServiceExePath><%= MsgServiceExePath %></MsgServiceExePath>
                               <!---->
                               <SelectedTabIndex><%= TabControl1.SelectedIndex %></SelectedTabIndex>
                               <Connect1AppToNetwork><%= chkConnect1.Checked %></Connect1AppToNetwork>
                               <Connect2AppToNetwork><%= chkConnect2.Checked %></Connect2AppToNetwork>
                               <AppTreeTabSplitDistance><%= SplitContainer1.SplitterDistance %></AppTreeTabSplitDistance>
                               <ProjTreeTabSplitDistance><%= SplitContainer2.SplitterDistance %></ProjTreeTabSplitDistance>
                               <!--Application List Tab: Data Grid View Column Widths-->
                               <ChildProjectAuthor>
                                   <Name><%= txtAuthorName.Text %></Name>
                                   <Description><%= txtAuthorDescription.Text %></Description>
                                   <Contact><%= txtAuthorContact.Text %></Contact>
                               </ChildProjectAuthor>
                           </FormSettings>

        Dim SettingsName As String = "FormSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Project.SaveXmlSettings(SettingsName, settingsData)
    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        Dim SettingsName As String = "FormSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"

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

            If Settings.<FormSettings>.<MsgServiceAppPath>.Value <> Nothing Then MsgServiceAppPath = Settings.<FormSettings>.<MsgServiceAppPath>.Value
            If Settings.<FormSettings>.<MsgServiceExePath>.Value <> Nothing Then MsgServiceExePath = Settings.<FormSettings>.<MsgServiceExePath>.Value

            'Read other settings:
            If Settings.<FormSettings>.<SelectedTabIndex>.Value = Nothing Then
            Else
                TabControl1.SelectedIndex = Settings.<FormSettings>.<SelectedTabIndex>.Value
            End If

            If Settings.<FormSettings>.<Connect1AppToNetwork>.Value = Nothing Then
                'Leave at default value.
            Else
                If Settings.<FormSettings>.<Connect1AppToNetwork>.Value = True Then
                    chkConnect1.Checked = True
                Else
                    chkConnect1.Checked = False
                End If
            End If

            If Settings.<FormSettings>.<Connect2AppToNetwork>.Value = Nothing Then
                'Leave at default value.
            Else
                If Settings.<FormSettings>.<Connect2AppToNetwork>.Value = True Then
                    chkConnect2.Checked = True
                Else
                    chkConnect2.Checked = False
                End If
            End If

            If Settings.<FormSettings>.<AppTreeTabSplitDistance>.Value <> Nothing Then SplitContainer1.SplitterDistance = Settings.<FormSettings>.<AppTreeTabSplitDistance>.Value

            If Settings.<FormSettings>.<ProjTreeTabSplitDistance>.Value <> Nothing Then SplitContainer2.SplitterDistance = Settings.<FormSettings>.<ProjTreeTabSplitDistance>.Value

            'Child Project Author information:
            If Settings.<FormSettings>.<ChildProjectAuthor>.<Name>.Value <> Nothing Then txtAuthorName.Text = Settings.<FormSettings>.<ChildProjectAuthor>.<Name>.Value
            If Settings.<FormSettings>.<ChildProjectAuthor>.<Description>.Value <> Nothing Then txtAuthorDescription.Text = Settings.<FormSettings>.<ChildProjectAuthor>.<Description>.Value
            If Settings.<FormSettings>.<ChildProjectAuthor>.<Contact>.Value <> Nothing Then txtAuthorContact.Text = Settings.<FormSettings>.<ChildProjectAuthor>.<Contact>.Value


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
        ApplicationInfo.License.Code = ADVL_Utilities_Library_1.License.Codes.Apache_License_2_0
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

    Private Sub SaveProjectSettings()
        'Save the project settings in an xml file.

    End Sub

    Private Sub RestoreProjectSettings()
        'Restore the project settings from an xml file.

    End Sub

#End Region 'Process XML Files ----------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Display Methods - Code used to display this form." '----------------------------------------------------------------------------------------------------------------------------

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Loading the Main application form.

        'Set the Application Directory path: ------------------------------------------------
        Project.ApplicationDir = My.Application.Info.DirectoryPath.ToString

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
                Exit Sub
            End If
        End If

        ReadApplicationInfo()

        'Read the Application Usage information: --------------------------------------------
        ApplicationUsage.StartTime = Now
        ApplicationUsage.SaveLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
        ApplicationUsage.SaveLocn.Path = Project.ApplicationDir
        ApplicationUsage.RestoreUsageInfo()

        'Restore Project information: -------------------------------------------------------
        Project.ApplicationName = ApplicationInfo.Name

        'Set up the Message object:
        Message.ApplicationName = ApplicationInfo.Name

        'Set up a temporary initial settings location:
        Dim TempLocn As New ADVL_Utilities_Library_1.FileLocation
        TempLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
        TempLocn.Path = ApplicationInfo.ApplicationDir
        Message.SettingsLocn = TempLocn

        Me.Show() 'Show this form before showing the Message form - This will show the App icon on top in the TaskBar.

        'Start showing messages here - Message system is set up.
        Message.AddText("------------------- Starting Application: ADVL Application Network  ----------------- " & vbCrLf, "Heading")
        Message.AddText("Application usage: Total duration = " & Format(ApplicationUsage.TotalDuration.TotalHours, "#.##") & " hours" & vbCrLf, "Normal")

        'https://msdn.microsoft.com/en-us/library/z2d603cy(v=vs.80).aspx#Y550
        'Process any command line arguments:
        Try
            For Each s As String In My.Application.CommandLineArgs
                Message.Add("Command line argument: " & vbCrLf)
                Message.AddXml(s & vbCrLf & vbCrLf)
                InstrReceived = s
            Next
        Catch ex As Exception
            Message.AddWarning("Error processing command line arguments: " & ex.Message & vbCrLf)
        End Try


        If ProjectSelected = False Then
            'Read the Settings Location for the last project used:
            Project.ReadLastProjectInfo()
            'The Last_Project_Info.xml file contains:
            '  Project Name and Description. Settings Location Type and Settings Location Path.
            Message.Add("Last project info has been read." & vbCrLf)
            Message.Add("Project.Type.ToString  " & Project.Type.ToString & vbCrLf)
            Message.Add("Project.Path  " & Project.Path & vbCrLf)

            'At this point read the application start arguments, if any.
            'The selected project may be changed here.

            'Check if the project is locked:
            If Project.ProjectLocked Then
                Message.AddWarning("The project is locked: " & Project.Name & vbCrLf)
                Dim dr As System.Windows.Forms.DialogResult
                dr = MessageBox.Show("Press 'Yes' to unlock the project", "Notice", MessageBoxButtons.YesNo)
                If dr = System.Windows.Forms.DialogResult.Yes Then
                    Project.UnlockProject()
                    Message.AddWarning("The project has been unlocked: " & Project.Name & vbCrLf)
                    'Read the Project Information file: -------------------------------------------------
                    Message.Add("Reading project info." & vbCrLf)
                    Project.ReadProjectInfoFile() 'Read the file in the SettingsLocation: ADVL_Project_Info.xml

                    Project.ReadParameters()
                    If Project.ParameterExists("AppNetName") Then
                        AppNetName = Project.Parameter("AppNetName").Value
                    Else
                        Project.AddParameter("AppNetName", Project.Name, "Application Network Name (= Project.Name).")
                        AppNetName = Project.Parameter("AppNetName").Value
                    End If


                    Message.Add("1" & vbCrLf) 'DEBUGGING
                    Project.LockProject() 'Lock the project while it is open in this application.
                    'Set the project start time. This is used to track project usage.
                    Project.Usage.StartTime = Now
                    ApplicationInfo.SettingsLocn = Project.SettingsLocn
                    'Set up the Message object:
                    Message.SettingsLocn = Project.SettingsLocn
                Else
                    'Continue without any project selected.
                    Project.Name = ""
                    Project.Type = ADVL_Utilities_Library_1.Project.Types.None
                    Project.Description = ""
                    Project.SettingsLocn.Path = ""
                    Project.DataLocn.Path = ""
                End If
            Else
                'Read the Project Information file: -------------------------------------------------
                Message.Add("Reading project info." & vbCrLf)
                Project.ReadProjectInfoFile()    'Read the file in the SettingsLocation: ADVL_Project_Info.xml

                Project.ReadParameters()
                If Project.ParameterExists("AppNetName") Then
                    AppNetName = Project.Parameter("AppNetName").Value
                Else
                    Project.AddParameter("AppNetName", Project.Name, "Application Network Name (= Project.Name).")
                    AppNetName = Project.Parameter("AppNetName").Value
                End If


                Message.Add("2" & vbCrLf) 'DEBUGGING
                Project.LockProject() 'Lock the project while it is open in this application.
                'Set the project start time. This is used to track project usage.
                Project.Usage.StartTime = Now
                ApplicationInfo.SettingsLocn = Project.SettingsLocn
                'Set up the Message object:
                Message.SettingsLocn = Project.SettingsLocn
            End If
        Else  'Project has been opened using Command Line arguments.
            Project.ReadParameters()

            'NOTE: The default AppNetName for an Application Network app is the Project.Name.
            If Project.ParameterExists("AppNetName") Then
                AppNetName = Project.Parameter("AppNetName").Value
            Else
                Project.AddParameter("AppNetName", Project.Name, "Application Network Name (= Project.Name).")
                AppNetName = Project.Parameter("AppNetName").Value
            End If

            Project.LockProject() 'Lock the project while it is open in this application.
            ProjectSelected = False 'Reset the Project Selected flag.
        End If


        'START Initialise the form: ===============================================================

        cmbNewChildProjectType.Items.Add("Directory")
        cmbNewChildProjectType.Items.Add("Archive")
        cmbNewChildProjectType.Items.Add("Hybrid")

        Me.WebBrowser1.ObjectForScripting = Me

        InitialiseForm() 'Initialise the form for a new project.

        'END   Initialise the form: ---------------------------------------------------------------

        'Restore the form settings: ---------------------------------------------------------
        RestoreFormSettings()

        ShowProjectInfo()   'Show the project information.

        Message.AddText("------------------- Started OK -------------------------------------------------------------------------- " & vbCrLf & vbCrLf, "Heading")

        If StartupConnectionName = "" Then
            If Project.ConnectOnOpen Then
                ConnectToComNet() 'The Project is set to connect when it is opened.
            ElseIf ApplicationInfo.ConnectOnStartup Then
                ConnectToComNet() 'The Application is set to connect when it is started.
            Else
                'Don't connect to ComNet.
            End If

        Else
            'Connect to ComNet using the connection name StartupConnectionName.
            ConnectToComNet(StartupConnectionName)
        End If

        'Start the timer to keep the connection awake:
        'Timer4.Interval = 10000 '10 seconds - for testing
        Timer4.Interval = TimeSpan.FromMinutes(55).TotalMilliseconds '55 minute interval
        Timer4.Enabled = True
        Timer4.Start()

    End Sub

    Private Sub InitialiseForm()
        'Initialise the form for a new project.

        AppTreeImageList.Images.Clear()
        ProjTreeImageList.Images.Clear()

        OpenStartPage()

        'Show the Open Project Name
        txtOpenProjectName.Text = Project.Name

        trvAppTree.ImageList = AppTreeImageList
        OpenAppTree()

        trvProjTree.ImageList = ProjTreeImageList
        OpenProjTree()

        'Set up Create Child Project tab:
        txtHPSettingsName.Text = "Settings"
        cmbHPSettingsType.Items.Clear()
        cmbHPSettingsType.Items.Add("Directory")
        cmbHPSettingsType.Items.Add("Archive")
        cmbHPSettingsType.SelectedIndex = 0

        txtHPDataName.Text = "Data"
        cmbHPDataType.Items.Clear()
        cmbHPDataType.Items.Add("Directory")
        cmbHPDataType.Items.Add("Archive")
        cmbHPDataType.SelectedIndex = 1

        txtHPSystemName.Text = "System"
        cmbHPSystemType.Items.Clear()
        cmbHPSystemType.Items.Add("Directory")
        cmbHPSystemType.Items.Add("Archive")
        cmbHPSystemType.SelectedIndex = 1

        CheckProjTreePaths()

        'Add list of projects from the AppInfo dictionary to the cmbNewChildProjectApplication list
        For Each item In AppInfo
            cmbNewChildProjectApplication.Items.Add(item.Key)
        Next

    End Sub

    Private Sub CheckProjTreePaths()
        'Check the Project Tree Paths.
        'If an AppNet project has been moved, the Project Tree paths must be updated.

        'The current Application Network Project ID is: Project.ID

        'Check if the ProjTreeInfo dictionary contains the current AppNet project: ID = Project.ID
        If ProjTreeInfo.ContainsKey(Project.ID) Then
            'Check if the dictionary entry has the correct path:
            If ProjTreeInfo(Project.ID).Path = Project.Path Then
                'The ProjTreeInfo paths are correct.
            Else
                'Update the ProjTreeInfo path:

                Message.AddWarning("The Project has been moved. The Project Paths will be updated. " & vbCrLf)

                'Select the AppNet project node in the Project Tree View:
                Dim tn() As TreeNode
                tn = trvProjTree.Nodes.Find(Project.ID, True)

                If tn.Length = 0 Then
                    Message.AddWarning("The Application Network project has the wrong path in the Project Tree and the corresponding node can not be found." & vbCrLf)
                ElseIf tn.Length = 1 Then
                    'Update the ProjTreeInfo path:
                    ProjTreeInfo(Project.ID).Path = Project.Path
                    'Update the project paths in all the child nodes:
                    UpdateChildNode(tn(0)) 'This method calls itself recursively to process all child nodes.
                Else
                    Message.AddWarning("The Application Network project has the wrong path in the Project Tree and two or more corresponding nodes have been found." & vbCrLf)
                End If
            End If
        Else
            Message.AddWarning("The Project ID was not found in the ProjTreeInfo dictionary: " & Project.ID & vbCrLf)
        End If
    End Sub

    Private Sub UpdateChildNode(ByVal ParentNode As TreeNode)
        'Update the Project Paths in the ChildNodes of the ParentNode.

        Dim NewParentProjectPath As String = ProjTreeInfo(ParentNode.Name).Path

        For Each Node In ParentNode.Nodes()
            Message.Add("===========================================================================" & vbCrLf)
            Message.Add("Processing Project: " & ProjTreeInfo(Node.Name).Name & vbCrLf)
            Message.Add("Update ParentProjectPath from: " & ProjTreeInfo(Node.Name).ParentProjectPath & " to: " & NewParentProjectPath & vbCrLf)
            ProjTreeInfo(Node.Name).ParentProjectPath = NewParentProjectPath 'Update the Parent Project Path.
            Message.Add("Update Path from: " & ProjTreeInfo(Node.Name).Path & " to: " & NewParentProjectPath & ProjTreeInfo(Node.Name).RelativePath & vbCrLf)
            ProjTreeInfo(Node.Name).Path = NewParentProjectPath & ProjTreeInfo(Node.Name).RelativePath 'Update the Project Path.

            'Update ProjInfo dictionary:
            If ProjInfo.ContainsKey(Node.Name & ".Proj") Then
                Message.Add("Updating the corresponding project in the ProjInfo dictionary:" & vbCrLf)
                Message.Add("New Parent Project Path: " & NewParentProjectPath & vbCrLf)
                Message.Add("New Path: " & NewParentProjectPath & ProjInfo(Node.Name & ".Proj").RelativePath & vbCrLf)
                ProjInfo(Node.Name & ".Proj").ParentProjectPath = NewParentProjectPath
                ProjInfo(Node.Name & ".Proj").Path = NewParentProjectPath & ProjInfo(Node.Name & ".Proj").RelativePath
            End If
            UpdateChildNode(Node) 'Recursively process the Child Nodes.
        Next

    End Sub

    Private Sub ShowProjectInfo()
        'Show the project information:

        txtProjectName.Text = Project.Name
        txtAppNetName.Text = Project.GetParameter("AppNetName")
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

        txtProjectPath.Text = Project.Path

        Select Case Project.SettingsLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtSettingsLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtSettingsLocationType.Text = "Archive"
        End Select
        txtSettingsPath.Text = Project.SettingsLocn.Path

        Select Case Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtDataLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtDataLocationType.Text = "Archive"
        End Select
        txtDataPath.Text = Project.DataLocn.Path

        Select Case Project.SystemLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtSystemLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtSystemLocationType.Text = "Archive"
        End Select
        txtSystemPath.Text = Project.SystemLocn.Path

        If Project.ConnectOnOpen Then
            chkConnect.Checked = True
        Else
            chkConnect.Checked = False
        End If


        txtTotalDuration.Text = Project.Usage.TotalDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                                Project.Usage.TotalDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                                Project.Usage.TotalDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                                Project.Usage.TotalDuration.Seconds.ToString.PadLeft(2, "0"c)

        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                                  Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                                  Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                                  Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)

    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Application

        DisconnectFromComNet() 'Disconnect from the Communication Network.

        SaveProjectInfo() 'Save the Project Information.

        'Update the Application Information file: -------------------------------------------
        ApplicationInfo.WriteFile()

        'Save Application Usage information: ------------------------------------------------
        ApplicationUsage.SaveUsageInfo()
        ApplicationInfo.UnlockApplication() 'Added 19Aug18

        SendClosingMessage() 'This line causes the program to freeze!!!!

        Application.Exit()

    End Sub

    Private Sub SaveProjectInfo()
        'Save Project Information before closing the project.

        SaveAppTree() 'Save the Application Tree
        SaveProjTree() 'Save the Project Tree

        'Save the form settings: ------------------------------------------------------------
        SaveFormSettings()

        Project.SaveLastProjectInfo() 'Save information about the last project used.
        Project.SaveParameters() 'ADDED 3Feb19
        Project.Usage.SaveUsageInfo() 'Save Project usage information.
        Project.UnlockProject() 'Unlock the project.

    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------


    Private Sub btnAddApplication_Click(sender As Object, e As EventArgs) Handles btnAddApplication.Click
        'Open the Add Application form.

        If IsNothing(AddApplication) Then
            AddApplication = New frmAddApplication
            AddApplication.Show()
        Else
            AddApplication.Show()
        End If
    End Sub

    Private Sub AddApplication_FormClosed(sender As Object, e As FormClosedEventArgs) Handles AddApplication.FormClosed
        AddApplication = Nothing
    End Sub

    Private Sub btnWebPages_Click(sender As Object, e As EventArgs) Handles btnWebPages.Click
        'Open the Web Pages form.

        If IsNothing(WebPageList) Then
            WebPageList = New frmWebPageList
            WebPageList.Show()
        Else
            WebPageList.Show()
        End If
    End Sub

    Private Sub WebPageList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles WebPageList.FormClosed
        WebPageList = Nothing
    End Sub


#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub SaveAppTree()
        'Save the Application Tree.
        'This is named AppTree.Lib
        'This is stored in the Project Data Location.

        Message.Add("START: SaveAppTree()" & vbCrLf)

        Dim decl As New XDeclaration("1.0", "utf-8", "yes")
        Dim XDoc As New XDocument(decl, Nothing)
        XDoc.Add(New XComment(""))
        XDoc.Add(New XComment("Application Tree Information"))

        Dim myAppTree As New XElement("ApplicationTree")

        Dim AppTreeImageListCount As New XElement("NApplicationIcons", AppTreeImageList.Images.Count - NProjectIcons)
        myAppTree.Add(AppTreeImageListCount)
        SaveAppTreeImageList()

        SaveAppTreeNode(myAppTree, "", trvAppTree.Nodes)

        XDoc.Add(myAppTree)

        Project.SaveXmlData("AppTree.Lib", XDoc)

    End Sub

    Private Sub SaveAppTreeNode(ByRef myElement As XElement, Parent As String, ByRef tnc As TreeNodeCollection)
        'Save the nodes in the TreeNodeCollection in the XElement.
        'This method calls itself recursively to save all nodes in trvAppTree.

        Dim I As Integer

        If tnc.Count = 0 Then 'Leaf

        Else
            For I = 0 To tnc.Count - 1
                Dim NodeKey As String = tnc(I).Name
                Dim myNode As New XElement(System.Xml.XmlConvert.EncodeName(NodeKey)) 'A space character os not allowed in an XElement name. Replace spaces with &sp characters.
                Dim myNodeText As New XElement("Text", tnc(I).Text)
                myNode.Add(myNodeText)

                If tnc(I).Nodes.Count > 0 Then
                    Message.Add("Node name = " & tnc(I).Name & " IsExpanded: " & tnc(I).IsExpanded & vbCrLf)
                End If

                If NodeKey = "ADVL_Application_Network_1" Then 'This the root node of the Application Tree.
                    'Save:
                    '  Description
                    '  ExecutablePath
                    '  Directory
                    '  IconNumber
                    '  OpenIconNumber
                    Dim myAppDescr As New XElement("Description", AppInfo(NodeKey).Description)
                    myNode.Add(myAppDescr)
                    Dim myAppExePath As New XElement("ExecutablePath", AppInfo(NodeKey).ExecutablePath)
                    myNode.Add(myAppExePath)
                    Dim myAppDirectory As New XElement("Directory", AppInfo(NodeKey).Directory)
                    myNode.Add(myAppDirectory)
                    Dim myAppIconNumber As New XElement("IconNumber", AppInfo(NodeKey).IconNumber)
                    myNode.Add(myAppIconNumber)
                    Dim myAppOpenIconNumber As New XElement("OpenIconNumber", AppInfo(NodeKey).OpenIconNumber)
                    myNode.Add(myAppOpenIconNumber)

                Else  'Non-root node.
                    If tnc(I).Nodes.Count > 0 Then
                        Dim isExpanded As New XElement("IsExpanded", tnc(I).IsExpanded)
                        myNode.Add(isExpanded)
                    End If

                    If NodeKey.EndsWith(".Proj") Then 'Project Node
                        'Save:
                        '  Name
                        '  Description
                        '  Type
                        '  SettingsLocnType NO LONGER SAVED
                        '  SettingsLocnPath NO LONGER SAVED
                        '  DataLocnType     NO LONGER SAVED
                        '  DataLocnPath     NO LONGER SAVED
                        '  Path
                        '  ID
                        '  ApplicationName
                        '  ApplicationDir   NO LONGER SAVED
                        '  ParentProjectName
                        '  ParentProjectID
                        '  RelativePath  (The project path relative to the Parent Project path)
                        '  IconNumber
                        '  OpenIconNumber

                        Dim myProjName As New XElement("Name", ProjInfo(NodeKey).Name)
                        myNode.Add(myProjName)

                        Dim myProjCreationDate As New XElement("CreationDate", Format(ProjInfo(NodeKey).CreationDate, "d-MMM-yyyy H:mm:ss"))
                        myNode.Add(myProjCreationDate)

                        Dim myProjDescr As New XElement("Description", ProjInfo(NodeKey).Description)
                        myNode.Add(myProjDescr)
                        Dim myProjType As New XElement("Type", ProjInfo(NodeKey).Type)
                        myNode.Add(myProjType)

                        Dim myProjPath As New XElement("Path", ProjInfo(NodeKey).Path)
                        myNode.Add(myProjPath)
                        Dim myProjRelativePath As New XElement("RelativePath", ProjInfo(NodeKey).RelativePath)
                        myNode.Add(myProjRelativePath)

                        Dim myProjID As New XElement("ID", ProjInfo(NodeKey).ID)
                        myNode.Add(myProjID)

                        Dim myProjAppName As New XElement("ApplicationName", ProjInfo(NodeKey).ApplicationName)
                        myNode.Add(myProjAppName)

                        Dim myProjParentProjName As New XElement("ParentProjectName", ProjInfo(NodeKey).ParentProjectName)
                        myNode.Add(myProjParentProjName)
                        Dim myProjParentProjID As New XElement("ParentProjectID", ProjInfo(NodeKey).ParentProjectID)
                        myNode.Add(myProjParentProjID)

                        Dim myProjParentProjPath As New XElement("ParentProjectPath", ProjInfo(NodeKey).ParentProjectPath)
                        myNode.Add(myProjParentProjPath)

                        Dim myProjIconNo As New XElement("IconNumber", ProjInfo(NodeKey).IconNumber)
                        myNode.Add(myProjIconNo)
                        Dim myProjOpenIconNo As New XElement("OpenIconNumber", ProjInfo(NodeKey).OpenIconNumber)
                        myNode.Add(myProjOpenIconNo)

                    Else 'Application Node
                        'Save:
                        '  Description
                        '  ExecutablePath
                        '  Directory
                        '  IconNumber
                        '  OpenIconNumber
                        Dim myAppDescr As New XElement("Description", AppInfo(NodeKey).Description)
                        myNode.Add(myAppDescr)
                        Dim myAppExePath As New XElement("ExecutablePath", AppInfo(NodeKey).ExecutablePath)
                        myNode.Add(myAppExePath)
                        Dim myAppDirectory As New XElement("Directory", AppInfo(NodeKey).Directory)
                        myNode.Add(myAppDirectory)
                        Dim myAppIconNumber As New XElement("IconNumber", AppInfo(NodeKey).IconNumber)
                        myNode.Add(myAppIconNumber)
                        Dim myAppOpenIconNumber As New XElement("OpenIconNumber", AppInfo(NodeKey).OpenIconNumber)
                        myNode.Add(myAppOpenIconNumber)
                    End If
                End If
                SaveAppTreeNode(myNode, tnc(I).Name, tnc(I).Nodes)
                myElement.Add(myNode)
            Next
        End If
    End Sub

    Private Sub OpenAppTree()
        'Open the Application Tree.
        'This is named AppTree.Lib
        'This is stored in the Project Data Location.
        'If the file is not found, trvAppTree is shown with just the Application Network.

        trvAppTree.Nodes.Clear()
        AppInfo.Clear()
        ProjInfo.Clear()

        If Project.DataFileExists("AppTree.Lib") Then
            Dim XTree As XDocument
            Project.ReadXmlData("AppTree.Lib", XTree)

            If XTree.<ApplicationTree>.<NApplicationIcons>.Value = Nothing Then
                NApplicationIcons = 0
            Else
                NApplicationIcons = XTree.<ApplicationTree>.<NApplicationIcons>.Value
                OpenAppTreeImageList()
            End If

            OpenXTree(XTree)
        Else
            LoadProjectIcons()
            'Get the Icon for the Application Network:
            Dim myIcon = System.Drawing.Icon.ExtractAssociatedIcon(Me.ApplicationInfo.ExecutablePath)
            AppTreeImageList.Images.Add(myIcon)
            trvAppTree.ImageList = AppTreeImageList
            trvAppTree.Nodes.Add("ADVL_Application_Network_1", "Application Network", 8, 8) 'Key, Text, ImageIndex, SelectedImageIndex.
            AppInfo.Add("ADVL_Application_Network_1", New clsAppInfo)
            AppInfo("ADVL_Application_Network_1").Description = ApplicationInfo.Description
            AppInfo("ADVL_Application_Network_1").Directory = ApplicationInfo.ApplicationDir
            AppInfo("ADVL_Application_Network_1").ExecutablePath = ApplicationInfo.ExecutablePath
            AppInfo("ADVL_Application_Network_1").IconNumber = 8
            AppInfo("ADVL_Application_Network_1").OpenIconNumber = 8
        End If
    End Sub

    Private Sub OpenProjTree()
        'Open the Project Tree.
        'This is named ProjTree.Lib
        'This is stored in the Project Data Location.

        trvProjTree.Nodes.Clear()
        ProjTreeInfo.Clear()

        If Project.DataFileExists("ProjTree.Lib") Then
            Dim XTree As XDocument
            Project.ReadXmlData("ProjTree.Lib", XTree)
            If XTree.<ProjectTree>.<NProjectTreeIcons>.Value = Nothing Then
                NProjectTreeIcons = 0
            Else
                NProjectTreeIcons = XTree.<ProjectTree>.<NProjectTreeIcons>.Value
                OpenProjectTreeImageList()
            End If
            OpenProjectXTree(XTree)
            RestoreProjectTreeImageListKeys()
        Else
            'Message.AddWarning("Project Tree file not found: ProjTree.Lib" & vbCrLf)
            'Add the current AppNet project to the Project Tree:
            AddCurrentProjectToTree()
        End If
    End Sub

    Private Sub AddCurrentProjectToTree()
        'Add the current AppNet project to the Project Tree.

        Dim myAppName As String = ApplicationInfo.Name
        Dim myProjectType As String = Project.Type.ToString

        If myProjectType = "None" Then
            Message.AddWarning("Default projects cannot be added to the Project Tree." & vbCrLf)
            Exit Sub
        End If

        Dim myProjectText As String = Project.Name
        Dim IconNumber As Integer = ProjTreeImageNumber(myAppName, myProjectType, False)
        Dim OpenIconNumber As Integer = ProjTreeImageNumber(myAppName, myProjectType, True)

        Dim myKey As String = Project.ID
        If myKey = "" Then
            Message.AddWarning("The Project ID is blank." & vbCrLf)
        Else
            If ProjTreeInfo.ContainsKey(myKey) Then
                Message.AddWarning("The Project is already in the Project Tree." & vbCrLf)
            Else
                'Saving: Name, Description, Type, Path, ID, ApplicationName, ParentProjectname, ParentProjectID, IconNumber, OpenIconNumber
                trvProjTree.Nodes.Add(myKey, myProjectText, IconNumber, OpenIconNumber) 'Add the Node to the Project Tree
                'Add the Node info to the ProjTreeInfo dictionary.
                ProjTreeInfo.Add(myKey, New clsProjInfo)
                ProjTreeInfo(myKey).Name = Project.Name
                ProjTreeInfo(myKey).CreationDate = Project.CreationDate
                ProjTreeInfo(myKey).Description = Project.Description

                Select Case myProjectType
                    Case "None"
                        ProjTreeInfo(myKey).Type = ADVL_Utilities_Library_1.Project.Types.None
                    Case "Directory"
                        ProjTreeInfo(myKey).Type = ADVL_Utilities_Library_1.Project.Types.Directory
                    Case "Archive"
                        ProjTreeInfo(myKey).Type = ADVL_Utilities_Library_1.Project.Types.Archive
                    Case "Hybrid"
                        ProjTreeInfo(myKey).Type = ADVL_Utilities_Library_1.Project.Types.Hybrid
                    Case Else
                        Message.AddWarning("Unknown Project Type: " & myProjectType & vbCrLf)
                End Select

                ProjTreeInfo(myKey).Path = Project.Path
                ProjTreeInfo(myKey).ID = myKey
                ProjTreeInfo(myKey).ApplicationName = ApplicationInfo.Name
                ProjTreeInfo(myKey).ParentProjectName = Project.ParentProjectName
                ProjTreeInfo(myKey).ParentProjectID = Project.ParentProjectID
                ProjTreeInfo(myKey).IconNumber = IconNumber
                ProjTreeInfo(myKey).OpenIconNumber = OpenIconNumber
            End If
        End If
    End Sub

    Private Sub RestoreProjectTreeImageListKeys()
        'Restore the ImageKeys in the ProjTreeImageList.

        'ProjTreeInfo: Name, Description, Type, Path, ID, ApplicationName, ParentProjectname, ParentProjectID, IconNumber, OpenIconNumber

        Dim I As Integer
        Dim AppName As String
        Dim ProjectType As String
        Dim ImageKey As String
        Dim ImageIndex As Integer
        'Process each item in the ProjTreeInfo dictionary.
        For I = 0 To ProjTreeInfo.Count - 1
            Try
                AppName = ProjTreeInfo.ElementAt(I).Value.ApplicationName
                ProjectType = ProjTreeInfo.ElementAt(I).Value.Type
                'Set ImageKey for ClosedIcon:
                ImageIndex = ProjTreeInfo.ElementAt(I).Value.IconNumber
                ImageKey = AppName & "_" & ProjectType
                ProjTreeImageList.Images.Keys(ImageIndex) = ImageKey

                'Set ImageKey for OpenIcon:
                ImageIndex = ProjTreeInfo.ElementAt(I).Value.OpenIconNumber
                ImageKey = "Open_" & AppName & "_" & ProjectType
                ProjTreeImageList.Images.Keys(ImageIndex) = ImageKey
            Catch ex As Exception
                Message.AddWarning("Error restoring Project Tree ImageList keys: " & ex.Message & vbCrLf)
            End Try
        Next
    End Sub

    Private Sub SaveAppTreeImageList()
        'Save all of the images in AppTreeImageList
        Dim NImages As Integer = AppTreeImageList.Images.Count
        Dim I As Integer
        For I = NProjectIcons To NImages - 1
            Try
                Dim imageData As New IO.MemoryStream
                AppTreeImageList.Images(I).Save(imageData, Imaging.ImageFormat.Bmp)
                imageData.Position = 0
                Project.SaveData("AppTreeImage" & I & ".bmp", imageData)
            Catch ex As Exception
                Message.AddWarning("Error saving AppTree image no: " & I & " " & ex.Message & vbCrLf)
            End Try
        Next
    End Sub

    Private Sub SaveProjTreeImageList()
        'Save all of the images in ProjTreeImageList
        Dim NImages As Integer = ProjTreeImageList.Images.Count
        Dim I As Integer
        For I = 0 To NImages - 1
            Try
                Dim imageData As New IO.MemoryStream
                ProjTreeImageList.Images(I).Save(imageData, Imaging.ImageFormat.Bmp)
                imageData.Position = 0
                Project.SaveData("ProjTreeImage" & I & ".bmp", imageData)
            Catch ex As Exception
                Message.AddWarning("Error saving ProjTree image no: " & I & " " & ex.Message & vbCrLf)
            End Try
        Next
    End Sub

    Private Sub LoadProjectIcons()
        'Load the Project icons into AppTreeImageList:

        AppTreeImageList.Images.Clear() 'Clear all existing images in the AppTreeImageList

        AppTreeImageList.Images.Add(ProjectIconImageList.Images(0)) 'Default Project icon
        AppTreeImageList.Images.Add(ProjectIconImageList.Images(1)) 'Open Default Project icon
        AppTreeImageList.Images.Add(ProjectIconImageList.Images(2)) 'Directory Project icon
        AppTreeImageList.Images.Add(ProjectIconImageList.Images(3)) 'Open Directory Project icon
        AppTreeImageList.Images.Add(ProjectIconImageList.Images(4)) 'Archive Project icon
        AppTreeImageList.Images.Add(ProjectIconImageList.Images(5)) 'Open Archive Project icon
        AppTreeImageList.Images.Add(ProjectIconImageList.Images(6)) 'Hybrid Project icon
        AppTreeImageList.Images.Add(ProjectIconImageList.Images(7)) 'Open Hybrid Project icon
    End Sub

    Private Sub OpenAppTreeImageList()
        'Open all of the images in AppTreeImageList

        AppTreeImageList.Images.Clear()

        If NApplicationIcons = 0 Then
            LoadProjectIcons()
            'There are no Application icons to load.
        Else
            LoadProjectIcons()
            Dim I As Integer
            For I = NProjectIcons To NApplicationIcons + NProjectIcons - 1
                Dim imageData As New IO.MemoryStream
                Project.ReadData("AppTreeImage" & I & ".bmp", imageData)
                imageData.Position = 0
                AppTreeImageList.Images.Add(Bitmap.FromStream(imageData))
            Next
        End If
    End Sub

    Private Sub OpenProjectTreeImageList()
        'Open all the images in ProjectTreeImageList.

        ProjTreeImageList.Images.Clear()

        If NProjectTreeIcons = 0 Then
            'There are no Project Tree icons to load.
        Else
            Dim I As Integer
            For I = 0 To NProjectTreeIcons - 1
                Dim imageData As New IO.MemoryStream
                Project.ReadData("ProjTreeImage" & I & ".bmp", imageData)
                imageData.Position = 0
                ProjTreeImageList.Images.Add(Bitmap.FromStream(imageData))
            Next
        End If
    End Sub

    Private Sub OpenXTree(ByRef XTree As XDocument)
        'Open the Application Tree stored in XTree.

        Dim I As Integer

        'Need to convert the XDocument to an XmlDocument:
        Dim XDoc As New System.Xml.XmlDocument
        XDoc.LoadXml(XTree.ToString)

        ProcessChildNode(XDoc.DocumentElement, trvAppTree.Nodes, "", True)
    End Sub

    Private Sub OpenProjectXTree(ByRef XTree As XDocument)
        'Open the Project Tree stored in XTree.

        Dim I As Integer

        'Need to convert the XDocument to an XmlDocument:
        Dim XDoc As New System.Xml.XmlDocument
        XDoc.LoadXml(XTree.ToString)

        ProcessProjectTreeChildNode(XDoc.DocumentElement, trvProjTree.Nodes, "", True)
    End Sub

    Private Sub ProcessChildNode(ByVal xml_Node As System.Xml.XmlNode, ByVal tnc As TreeNodeCollection, ByVal Spaces As String, ByVal ParentNodeIsExpanded As Boolean)
        'Opening the AppTree.Lib file containing the Application Tree.
        'This subroutine calls itself to process the child node branches.

        Dim NodeInfo As System.Xml.XmlNode
        Dim NodeText As String = ""
        Dim NodeKey As String = ""
        Dim IsExpanded As Boolean = True
        Dim HasNodes As Boolean = True

        For Each ChildNode As System.Xml.XmlNode In xml_Node.ChildNodes
            Dim myNodeText As System.Xml.XmlNode
            myNodeText = ChildNode.SelectSingleNode("Text")
            If IsNothing(myNodeText) Then
                'Message.Add("/Text node not found. " & vbCrLf)
            Else
                Dim myNodeTextValue As String = myNodeText.InnerText 'This is the text displayed next to the node in the tree view.
                If ChildNode.Name = "ADVL_Application_Network_1" Then 'This the root node of the Application Tree.
                    NodeKey = System.Xml.XmlConvert.DecodeName(ChildNode.Name)
                    If AppInfo.ContainsKey(NodeKey) Then
                        Message.AddWarning("The Application Network node is already listed in the AppInfo dictionary: " & NodeKey & vbCrLf)
                    Else
                        AppInfo.Add(NodeKey, New clsAppInfo) 'Add the App name to the AppInfo dictionary.
                        'Read the App Description:
                        NodeInfo = ChildNode.SelectSingleNode("Description")
                        If IsNothing(NodeInfo) Then
                            AppInfo(NodeKey).Description = ""
                        Else
                            AppInfo(NodeKey).Description = NodeInfo.InnerText
                        End If
                        'Read the App Executable Path:
                        NodeInfo = ChildNode.SelectSingleNode("ExecutablePath")
                        If IsNothing(NodeInfo) Then
                            AppInfo(NodeKey).ExecutablePath = ""
                        Else
                            AppInfo(NodeKey).ExecutablePath = NodeInfo.InnerText
                        End If
                        'Read the App Directory:
                        NodeInfo = ChildNode.SelectSingleNode("Directory")
                        If IsNothing(NodeInfo) Then
                            AppInfo(NodeKey).Directory = ""
                        Else
                            AppInfo(NodeKey).Directory = NodeInfo.InnerText
                        End If
                        'Read the App IconNumber:
                        NodeInfo = ChildNode.SelectSingleNode("IconNumber")
                        If IsNothing(NodeInfo) Then
                            AppInfo(NodeKey).IconNumber = ""
                        Else
                            AppInfo(NodeKey).IconNumber = NodeInfo.InnerText
                        End If
                        'Read the App OpenIconNumber:
                        NodeInfo = ChildNode.SelectSingleNode("OpenIconNumber")
                        If IsNothing(NodeInfo) Then
                            AppInfo(NodeKey).OpenIconNumber = ""
                        Else
                            AppInfo(NodeKey).OpenIconNumber = NodeInfo.InnerText
                        End If
                        'Read Node IsExpanded:
                        NodeInfo = ChildNode.SelectSingleNode("IsExpanded")
                        If IsNothing(NodeInfo) Then
                            IsExpanded = True
                        Else
                            IsExpanded = NodeInfo.InnerText
                        End If

                        Dim new_Node As TreeNode = tnc.Add(NodeKey, myNodeTextValue, AppInfo(NodeKey).IconNumber, AppInfo(NodeKey).OpenIconNumber)

                        ProcessChildNode(ChildNode, new_Node.Nodes, Spaces, IsExpanded)

                        If IsExpanded Then
                            new_Node.Expand()
                        End If

                    End If
                ElseIf ChildNode.Name.EndsWith(".Proj") Then 'Project node.
                    NodeKey = System.Xml.XmlConvert.DecodeName(ChildNode.Name)
                    If ProjInfo.ContainsKey(NodeKey) Then
                        Message.AddWarning("The Project node is already listed in the ProjectInfo dictionary: " & NodeKey & vbCrLf)
                    Else
                        ProjInfo.Add(NodeKey, New clsProjInfo) 'Add the Project Name to the ProjectInfo dictionary.
                        'Read the Project Name:
                        NodeInfo = ChildNode.SelectSingleNode("Name")
                        If IsNothing(NodeInfo) Then
                            ProjInfo(NodeKey).Name = ""
                        Else
                            ProjInfo(NodeKey).Name = NodeInfo.InnerText
                        End If

                        'Read the Project Creation Date:
                        NodeInfo = ChildNode.SelectSingleNode("CreationDate")
                        If IsNothing(NodeInfo) Then
                            ProjInfo(NodeKey).CreationDate = "1-Jan-2000 12:00:00"
                        Else
                            ProjInfo(NodeKey).CreationDate = NodeInfo.InnerText
                        End If

                        'Read the Project Description:
                        NodeInfo = ChildNode.SelectSingleNode("Description")
                        If IsNothing(NodeInfo) Then
                            ProjInfo(NodeKey).Description = ""
                        Else
                            ProjInfo(NodeKey).Description = NodeInfo.InnerText
                        End If
                        'Read the Project Type:
                        NodeInfo = ChildNode.SelectSingleNode("Type")
                        If IsNothing(NodeInfo) Then
                            ProjInfo(NodeKey).Type = ADVL_Utilities_Library_1.Project.Types.None
                        Else
                            Select Case NodeInfo.InnerText
                                Case "None"
                                    ProjInfo(NodeKey).Type = ADVL_Utilities_Library_1.Project.Types.None
                                Case "Directory"
                                    ProjInfo(NodeKey).Type = ADVL_Utilities_Library_1.Project.Types.Directory
                                Case "Archive"
                                    ProjInfo(NodeKey).Type = ADVL_Utilities_Library_1.Project.Types.Archive
                                Case "Hybrid"
                                    ProjInfo(NodeKey).Type = ADVL_Utilities_Library_1.Project.Types.Hybrid
                                Case Else
                                    ProjInfo(NodeKey).Type = ADVL_Utilities_Library_1.Project.Types.None
                            End Select
                        End If
                        'Read the Project Path:
                        NodeInfo = ChildNode.SelectSingleNode("Path")
                        If IsNothing(NodeInfo) Then
                            ProjInfo(NodeKey).Path = ""
                        Else
                            ProjInfo(NodeKey).Path = NodeInfo.InnerText
                        End If

                        'Read the Relative Path (The Project Path relative to the Parent Path.)
                        NodeInfo = ChildNode.SelectSingleNode("RelativePath")
                        If IsNothing(NodeInfo) Then
                            ProjInfo(NodeKey).RelativePath = ""
                        Else
                            ProjInfo(NodeKey).RelativePath = NodeInfo.InnerText
                        End If

                        'Read the Project ID:
                        NodeInfo = ChildNode.SelectSingleNode("ID")
                        If IsNothing(NodeInfo) Then
                            ProjInfo(NodeKey).ID = ""
                        Else
                            ProjInfo(NodeKey).ID = NodeInfo.InnerText
                        End If

                        'Read the Application Name:
                        NodeInfo = ChildNode.SelectSingleNode("ApplicationName")
                        If IsNothing(NodeInfo) Then
                            ProjInfo(NodeKey).ApplicationName = ""
                        Else
                            ProjInfo(NodeKey).ApplicationName = NodeInfo.InnerText
                        End If

                        'Read the Parent Project Name:
                        'Legacy code version: (In case an old file version contains <HostProjectName>)
                        NodeInfo = ChildNode.SelectSingleNode("HostProjectName")
                        If IsNothing(NodeInfo) Then
                            ProjInfo(NodeKey).ParentProjectName = ""
                        Else
                            ProjInfo(NodeKey).ParentProjectName = NodeInfo.InnerText
                        End If
                        'Updated code version:
                        NodeInfo = ChildNode.SelectSingleNode("ParentProjectName")
                        If IsNothing(NodeInfo) Then
                            'ProjInfo(NodeKey).ParentProjectName = "" 'DONT CHANGE THIS - THE CODE ABOVE WILL HAVE SET THE CORRECT VALUE
                        Else
                            ProjInfo(NodeKey).ParentProjectName = NodeInfo.InnerText
                        End If

                        'Read the Parent Project ID:
                        'Legacy code version: (In case an old file version contains <HostProjectID>)
                        NodeInfo = ChildNode.SelectSingleNode("HostProjectID")
                        If IsNothing(NodeInfo) Then
                            ProjInfo(NodeKey).ParentProjectID = ""
                        Else
                            ProjInfo(NodeKey).ParentProjectID = NodeInfo.InnerText
                        End If
                        'Updated code version:
                        NodeInfo = ChildNode.SelectSingleNode("ParentProjectID")
                        If IsNothing(NodeInfo) Then
                            'ProjInfo(NodeKey).ParentProjectID = "" 'DONT CHANGE THIS - THE CODE ABOVE WILL HAVE SET THE CORRECT VALUE
                        Else
                            ProjInfo(NodeKey).ParentProjectID = NodeInfo.InnerText
                        End If

                        'Read the ParentProject Path:
                        NodeInfo = ChildNode.SelectSingleNode("ParentProjectPath")
                        If IsNothing(NodeInfo) Then
                            ProjInfo(NodeKey).ParentProjectPath = ""
                        Else
                            ProjInfo(NodeKey).ParentProjectPath = NodeInfo.InnerText
                        End If

                        'Read the Icon Number
                        NodeInfo = ChildNode.SelectSingleNode("IconNumber")
                        If IsNothing(NodeInfo) Then
                            ProjInfo(NodeKey).IconNumber = ""
                        Else
                            ProjInfo(NodeKey).IconNumber = NodeInfo.InnerText
                        End If
                        'Read the Open Icon Number:
                        NodeInfo = ChildNode.SelectSingleNode("OpenIconNumber")
                        If IsNothing(NodeInfo) Then
                            ProjInfo(NodeKey).OpenIconNumber = ""
                        Else
                            ProjInfo(NodeKey).OpenIconNumber = NodeInfo.InnerText
                        End If
                        'Read Node IsExpanded:
                        NodeInfo = ChildNode.SelectSingleNode("IsExpanded")
                        If IsNothing(NodeInfo) Then
                            IsExpanded = True
                        Else
                            IsExpanded = NodeInfo.InnerText
                        End If

                        Dim new_Node As TreeNode = tnc.Add(NodeKey, myNodeTextValue, ProjInfo(NodeKey).IconNumber, ProjInfo(NodeKey).OpenIconNumber)

                        ProcessChildNode(ChildNode, new_Node.Nodes, Spaces, IsExpanded)

                        If IsExpanded Then
                            new_Node.Expand()
                        End If
                    End If
                Else 'Application node.
                    NodeKey = System.Xml.XmlConvert.DecodeName(ChildNode.Name)
                    If AppInfo.ContainsKey(NodeKey) Then
                        Message.AddWarning("The Application node is already listed in the AppInfo dictionary: " & NodeKey & vbCrLf)
                    Else
                        AppInfo.Add(NodeKey, New clsAppInfo) 'Add the App name to the AppInfo dictionary.
                        'Read the App Description:
                        NodeInfo = ChildNode.SelectSingleNode("Description")
                        If IsNothing(NodeInfo) Then
                            AppInfo(NodeKey).Description = ""
                        Else
                            AppInfo(NodeKey).Description = NodeInfo.InnerText
                        End If
                        'Read the App Executable Path:
                        NodeInfo = ChildNode.SelectSingleNode("ExecutablePath")
                        If IsNothing(NodeInfo) Then
                            AppInfo(NodeKey).ExecutablePath = ""
                        Else
                            AppInfo(NodeKey).ExecutablePath = NodeInfo.InnerText
                        End If
                        'Read the App Directory:
                        NodeInfo = ChildNode.SelectSingleNode("Directory")
                        If IsNothing(NodeInfo) Then
                            AppInfo(NodeKey).Directory = ""
                        Else
                            AppInfo(NodeKey).Directory = NodeInfo.InnerText
                        End If
                        'Read the App IconNumber:
                        NodeInfo = ChildNode.SelectSingleNode("IconNumber")
                        If IsNothing(NodeInfo) Then
                            AppInfo(NodeKey).IconNumber = ""
                        Else
                            AppInfo(NodeKey).IconNumber = NodeInfo.InnerText
                        End If
                        'Read the App OpenIconNumber:
                        NodeInfo = ChildNode.SelectSingleNode("OpenIconNumber")
                        If IsNothing(NodeInfo) Then
                            AppInfo(NodeKey).OpenIconNumber = ""
                        Else
                            AppInfo(NodeKey).OpenIconNumber = NodeInfo.InnerText
                        End If
                        'Read Node IsExpanded:
                        NodeInfo = ChildNode.SelectSingleNode("IsExpanded")
                        If IsNothing(NodeInfo) Then
                            IsExpanded = True
                        Else
                            IsExpanded = NodeInfo.InnerText
                        End If

                        Dim new_Node As TreeNode = tnc.Add(NodeKey, myNodeTextValue, AppInfo(NodeKey).IconNumber, AppInfo(NodeKey).OpenIconNumber)

                        ProcessChildNode(ChildNode, new_Node.Nodes, Spaces, IsExpanded)

                        If IsExpanded Then
                            new_Node.Expand()
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub ProcessProjectTreeChildNode(ByVal xml_Node As System.Xml.XmlNode, ByVal tnc As TreeNodeCollection, ByVal Spaces As String, ByVal ParentNodeIsExpanded As Boolean)
        'Opening the ProjTree.Lib file containing the Project Tree.
        'This method calls itself to process the child nodes.

        Dim NodeInfo As System.Xml.XmlNode
        Dim NodeText As String = ""
        Dim NodeKey As String = ""
        Dim IsExpanded As Boolean = True
        Dim HasNodes As Boolean = True

        For Each ChildNode As System.Xml.XmlNode In xml_Node.ChildNodes
            Dim myNodeText As System.Xml.XmlNode
            myNodeText = ChildNode.SelectSingleNode("Text")
            If IsNothing(myNodeText) Then
                'Text node not found
            Else
                Dim myNodeTextValue As String = myNodeText.InnerText 'This is the text displayed next to the node in the tree view.
                NodeKey = System.Xml.XmlConvert.DecodeName(ChildNode.Name)
                If ProjTreeInfo.ContainsKey(NodeKey) Then
                    Message.AddWarning("The Project node is already listed in the Project Tree Info dictionary: " & NodeKey & vbCrLf)
                Else
                    ProjTreeInfo.Add(NodeKey, New clsProjInfo) 'Add the Project Name to the Project Tree Info dictionary.

                    'Read the Project Name:
                    NodeInfo = ChildNode.SelectSingleNode("Name")
                    If IsNothing(NodeInfo) Then
                        ProjTreeInfo(NodeKey).Name = ""
                    Else
                        ProjTreeInfo(NodeKey).Name = NodeInfo.InnerText
                    End If

                    'Read the Project Creation Date:
                    NodeInfo = ChildNode.SelectSingleNode("CreationDate")
                    If IsNothing(NodeInfo) Then
                        ProjTreeInfo(NodeKey).CreationDate = "1-Jan-2000 12:00:00"
                    Else
                        ProjTreeInfo(NodeKey).CreationDate = NodeInfo.InnerText
                    End If

                    'Read the Project Description:
                    NodeInfo = ChildNode.SelectSingleNode("Description")
                    If IsNothing(NodeInfo) Then
                        ProjTreeInfo(NodeKey).Description = ""
                    Else
                        ProjTreeInfo(NodeKey).Description = NodeInfo.InnerText
                    End If

                    'Read the Project Type:
                    NodeInfo = ChildNode.SelectSingleNode("Type")
                    If IsNothing(NodeInfo) Then
                        ProjTreeInfo(NodeKey).Type = ADVL_Utilities_Library_1.Project.Types.None
                    Else
                        Select Case NodeInfo.InnerText
                            Case "None"
                                ProjTreeInfo(NodeKey).Type = ADVL_Utilities_Library_1.Project.Types.None
                            Case "Directory"
                                ProjTreeInfo(NodeKey).Type = ADVL_Utilities_Library_1.Project.Types.Directory
                            Case "Archive"
                                ProjTreeInfo(NodeKey).Type = ADVL_Utilities_Library_1.Project.Types.Archive
                            Case "Hybrid"
                                ProjTreeInfo(NodeKey).Type = ADVL_Utilities_Library_1.Project.Types.Hybrid
                            Case Else
                                ProjTreeInfo(NodeKey).Type = ADVL_Utilities_Library_1.Project.Types.None
                        End Select
                    End If

                    'Read the Project Path:
                    NodeInfo = ChildNode.SelectSingleNode("Path")
                    If IsNothing(NodeInfo) Then
                        ProjTreeInfo(NodeKey).Path = ""
                    Else
                        ProjTreeInfo(NodeKey).Path = NodeInfo.InnerText
                    End If

                    'Read the Relative Path (The Project Path relative to the Parent Path.)
                    NodeInfo = ChildNode.SelectSingleNode("RelativePath")
                    If IsNothing(NodeInfo) Then
                        ProjTreeInfo(NodeKey).RelativePath = ""
                    Else
                        ProjTreeInfo(NodeKey).RelativePath = NodeInfo.InnerText
                    End If

                    'Read the Project ID:
                    NodeInfo = ChildNode.SelectSingleNode("ID")
                    If IsNothing(NodeInfo) Then
                        ProjTreeInfo(NodeKey).ID = ""
                    Else
                        ProjTreeInfo(NodeKey).ID = NodeInfo.InnerText
                    End If

                    'Read the Application Name:
                    NodeInfo = ChildNode.SelectSingleNode("ApplicationName")
                    If IsNothing(NodeInfo) Then
                        ProjTreeInfo(NodeKey).ApplicationName = ""
                    Else
                        ProjTreeInfo(NodeKey).ApplicationName = NodeInfo.InnerText
                    End If

                    'Read the Parent Project Name:
                    NodeInfo = ChildNode.SelectSingleNode("ParentProjectName")
                    If IsNothing(NodeInfo) Then
                        ProjTreeInfo(NodeKey).ParentProjectName = ""
                    Else
                        ProjTreeInfo(NodeKey).ParentProjectName = NodeInfo.InnerText
                    End If

                    'Read the Parent Project ID:
                    NodeInfo = ChildNode.SelectSingleNode("ParentProjectID")
                    If IsNothing(NodeInfo) Then
                        ProjTreeInfo(NodeKey).ParentProjectID = ""
                    Else
                        ProjTreeInfo(NodeKey).ParentProjectID = NodeInfo.InnerText
                    End If

                    'Read the Parent Project Path:
                    NodeInfo = ChildNode.SelectSingleNode("ParentProjectPath")
                    If IsNothing(NodeInfo) Then
                        ProjTreeInfo(NodeKey).ParentProjectPath = ""
                    Else
                        ProjTreeInfo(NodeKey).ParentProjectPath = NodeInfo.InnerText
                    End If

                    'Read the Icon Number
                    NodeInfo = ChildNode.SelectSingleNode("IconNumber")
                    If IsNothing(NodeInfo) Then
                        ProjTreeInfo(NodeKey).IconNumber = ""
                    Else
                        ProjTreeInfo(NodeKey).IconNumber = NodeInfo.InnerText
                    End If

                    'Read the Open Icon Number:
                    NodeInfo = ChildNode.SelectSingleNode("OpenIconNumber")
                    If IsNothing(NodeInfo) Then
                        ProjTreeInfo(NodeKey).OpenIconNumber = ""
                    Else
                        ProjTreeInfo(NodeKey).OpenIconNumber = NodeInfo.InnerText
                    End If

                    'Read Node IsExpanded:
                    NodeInfo = ChildNode.SelectSingleNode("IsExpanded")
                    If IsNothing(NodeInfo) Then
                        IsExpanded = True
                    Else
                        IsExpanded = NodeInfo.InnerText
                    End If

                    Dim new_Node As TreeNode = tnc.Add(NodeKey, myNodeTextValue, ProjTreeInfo(NodeKey).IconNumber, ProjTreeInfo(NodeKey).OpenIconNumber)

                    ProcessProjectTreeChildNode(ChildNode, new_Node.Nodes, Spaces, IsExpanded)

                    If IsExpanded Then
                        new_Node.Expand()
                    End If
                End If
            End If
        Next
    End Sub

    Public Sub AddAppNodeToAppTree(ByVal AppName As String)
        'Add the Application Node to the AppTree.
        'The Application name is AppName.
        'The application information has already been added to AppInfo().

        Dim myIcon = System.Drawing.Icon.ExtractAssociatedIcon(AppInfo(AppName).ExecutablePath)
        AppTreeImageList.Images.Add(AppName, myIcon)
        AppInfo(AppName).IconNumber = AppTreeImageList.Images.IndexOfKey(AppName)
        AppInfo(AppName).OpenIconNumber = AppTreeImageList.Images.IndexOfKey(AppName)
        trvAppTree.TopNode.Nodes.Add(AppName, AppText, AppInfo(AppName).IconNumber, AppInfo(AppName).OpenIconNumber)

    End Sub

    Private Sub OpenAppTree_Old()
        'Open the Application Tree. OLD VERSION - THIS IS NO LONGER USED.
        'This is named AppTree.Lib
        'This is stored in the Application Directory.
        'If the file is not found, trvAppTree is show with just the Application Network.

        trvAppTree.Nodes.Clear()

        If System.IO.File.Exists(Project.ApplicationDir & "\AppTree.lib") Then

        Else
            AppTreeImageList.Images.Clear() 'Clear all existing images in the AppTreeImageList
            'Get the Icon for the Application Network:
            Dim myIcon = System.Drawing.Icon.ExtractAssociatedIcon(Me.ApplicationInfo.ExecutablePath)
            AppTreeImageList.Images.Add(myIcon)
            trvAppTree.ImageList = AppTreeImageList
            trvAppTree.Nodes.Add("Application_Network", "Application Network", 0)

        End If

    End Sub

    Private Sub SaveProjTree()
        'Save the Project Tree.
        'This is named ProjTree.Lib
        'This is stored in the Project Data Directory.

        Message.Add("START: SaveProjTree()" & vbCrLf)

        Dim decl As New XDeclaration("1.0", "utf-8", "yes")
        Dim XDoc As New XDocument(decl, Nothing)
        XDoc.Add(New XComment(""))
        XDoc.Add(New XComment("Project Tree Information"))

        Dim myProjTree As New XElement("ProjectTree")

        Dim ProjTreeImageListCount As New XElement("NProjectTreeIcons", ProjTreeImageList.Images.Count)
        myProjTree.Add(ProjTreeImageListCount)
        SaveProjTreeImageList()

        SaveProjTreeNode(myProjTree, "", trvProjTree.Nodes)

        XDoc.Add(myProjTree)

        Project.SaveXmlData("ProjTree.Lib", XDoc)

    End Sub

    Private Sub SaveProjTreeNode(ByRef myElement As XElement, Parent As String, ByRef tnc As TreeNodeCollection)
        'Save the nodes in the TreeNodeCollection in the XElement.
        'This method calls itself recursively to save all nodes in trvProjTree.

        Dim I As Integer

        If tnc.Count = 0 Then 'Leaf

        Else
            For I = 0 To tnc.Count - 1
                Dim NodeKey As String = tnc(I).Name
                Dim myNode As New XElement(System.Xml.XmlConvert.EncodeName(NodeKey)) 'A space character os not allowed in an XElement name. Replace spaces with &sp characters.
                Dim myNodeText As New XElement("Text", tnc(I).Text)
                myNode.Add(myNodeText)

                If tnc(I).Nodes.Count > 0 Then
                    Message.Add("Node name = " & tnc(I).Name & " IsExpanded: " & tnc(I).IsExpanded & vbCrLf)
                    Dim isExpanded As New XElement("IsExpanded", tnc(I).IsExpanded)
                    myNode.Add(isExpanded)
                End If

                'Save: Name, Description, Type, Path, ID, ApplicationName, ParentProjectname, ParentProjectID, IconNumber, OpenIconNumber
                Dim myProjName As New XElement("Name", ProjTreeInfo(NodeKey).Name)
                myNode.Add(myProjName)

                Dim myProjCreationDate As New XElement("CreationDate", Format(ProjTreeInfo(NodeKey).CreationDate, "d-MMM-yyyy H:mm:ss"))
                myNode.Add(myProjCreationDate)

                Dim myProjDescr As New XElement("Description", ProjTreeInfo(NodeKey).Description)
                myNode.Add(myProjDescr)
                Dim myProjType As New XElement("Type", ProjTreeInfo(NodeKey).Type)
                myNode.Add(myProjType)
                Dim myProjPath As New XElement("Path", ProjTreeInfo(NodeKey).Path)
                myNode.Add(myProjPath)
                Dim myProjRelativePath As New XElement("RelativePath", ProjTreeInfo(NodeKey).RelativePath)
                myNode.Add(myProjRelativePath)
                Dim myProjID As New XElement("ID", ProjTreeInfo(NodeKey).ID)
                myNode.Add(myProjID)
                Dim myProjAppName As New XElement("ApplicationName", ProjTreeInfo(NodeKey).ApplicationName)
                myNode.Add(myProjAppName)
                Dim myProjParentProjName As New XElement("ParentProjectName", ProjTreeInfo(NodeKey).ParentProjectName)
                myNode.Add(myProjParentProjName)
                Dim myProjParentProjID As New XElement("ParentProjectID", ProjTreeInfo(NodeKey).ParentProjectID)
                myNode.Add(myProjParentProjID)

                Dim myProjParentProjPath As New XElement("ParentProjectPath", ProjTreeInfo(NodeKey).ParentProjectPath)
                myNode.Add(myProjParentProjPath)

                Dim myProjIconNo As New XElement("IconNumber", ProjTreeInfo(NodeKey).IconNumber)
                myNode.Add(myProjIconNo)
                Dim myProjOpenIconNo As New XElement("OpenIconNumber", ProjTreeInfo(NodeKey).OpenIconNumber)
                myNode.Add(myProjOpenIconNo)

                SaveProjTreeNode(myNode, tnc(I).Name, tnc(I).Nodes)
                myElement.Add(myNode)
            Next
        End If

        'NOTE:
        'After the ProjTree.Lib file is read, the ProjTreeImageList ImageKeys are generated from the AppName and ProjectType:
        'AppName & "_Directory"
        'AppName & "_Archive"
        'AppName & "_Hybrid"
        '"Open_" & AppName & "_Directory"
        '"Open_" & AppName & "_Archive"
        '"Open_" & AppName & "_Hybrid"

    End Sub

    Private Sub SendClosingMessage()
        'Send a message to all connections to notify them that the Application Network is closing.

        'Create XML document:
        Dim doc As XDocument =
                   <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                   <XMsg>
                       <ApplicationNetworkClosing>"True"</ApplicationNetworkClosing>
                   </XMsg>

        ' myMsg
    End Sub


    Private Sub btnProject_Click(sender As Object, e As EventArgs) Handles btnProject.Click
        Project.SelectProject()
    End Sub

    Private Sub btnParameters_Click(sender As Object, e As EventArgs) Handles btnParameters.Click
        Project.ShowParameters()
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

    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter
        'Update the current duration:

        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                                  Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                                  Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                                  Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)

        Timer3.Interval = 5000 '5 seconds
        Timer3.Enabled = True
        Timer3.Start()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        'Update the current duration:

        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                                  Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                                  Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                                  Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)
    End Sub

    Private Sub TabPage1_Leave(sender As Object, e As EventArgs) Handles TabPage1.Leave
        Timer3.Enabled = False
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Add the current project to the Message Service list.

        If Project.ParentProjectName <> "" Then
            Message.AddWarning("This project has a parent: " & Project.ParentProjectName & vbCrLf)
            Message.AddWarning("Child projects can not be added to the list." & vbCrLf)
            Exit Sub
        End If

        If ConnectedToComNet = False Then
            Message.AddWarning("The application is not connected to the Message Service." & vbCrLf)
        Else 'Connected to the Message Service (ComNet).
            If IsNothing(client) Then
                Message.Add("No client connection available!" & vbCrLf)
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("Client state is faulted. Message not sent!" & vbCrLf)
                Else
                    'Construct the XMessage to send to AppNet:
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    Dim projectInfo As New XElement("ProjectInfo")

                    Dim Path As New XElement("Path", Project.Path)
                    projectInfo.Add(Path)
                    xmessage.Add(projectInfo)
                    doc.Add(xmessage)

                    'Show the message sent to AppNet:
                    Message.XAddText("Message sent to " & "MessageService" & ":" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(doc.ToString)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    'client.SendMessage("MessageService", doc.ToString)
                    client.SendMessage("", "MessageService", doc.ToString) 'UPDATED 2Feb19
                End If
            End If
        End If
    End Sub

    Private Sub btnOpenProject_Click(sender As Object, e As EventArgs) Handles btnOpenProject.Click
        If Project.Type = ADVL_Utilities_Library_1.Project.Types.Archive Then

        Else
            Process.Start(Project.Path)
        End If
    End Sub

    Private Sub btnOpenSettings_Click(sender As Object, e As EventArgs) Handles btnOpenSettings.Click
        If Project.SettingsLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory Then
            Process.Start(Project.SettingsLocn.Path)
        End If
    End Sub

    Private Sub btnOpenData_Click(sender As Object, e As EventArgs) Handles btnOpenData.Click
        If Project.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory Then
            Process.Start(Project.DataLocn.Path)
        End If
    End Sub

    Private Sub btnOpenSystem_Click(sender As Object, e As EventArgs) Handles btnOpenSystem.Click
        If Project.SystemLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory Then
            Process.Start(Project.SystemLocn.Path)
        End If
    End Sub

    Private Sub btnOpenAppDir_Click(sender As Object, e As EventArgs) Handles btnOpenAppDir.Click
        Process.Start(ApplicationInfo.ApplicationDir)
    End Sub

    Public Sub StartApp_ProjectName(ByVal AppName As String, ByVal ProjectName As String, ByVal ConnectionName As String)
        'Start the application with the name AppName.
        'If ProjectName is not "" then open the specified project.
        'If ConnectToComNet is True then connect to the Communication Network.

        If AppInfo.ContainsKey(AppName) Then
            'Start the application:
            If ProjectName = "" And ConnectionName = "" Then
                'No project selected and application will not be connected to the network.
                Shell(Chr(34) & AppInfo(AppName).ExecutablePath & Chr(34), AppWinStyle.NormalFocus) 'Start the application with no argument
            Else
                If client.ConnectionAvailable(AppNetName, ConnectionName) Then
                    'Build the Application start message:
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim ConnectDoc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    If ProjectName <> "" Then
                        Dim xproject As New XElement("ProjectName", ProjectName)
                        xmessage.Add(xproject)
                    End If
                    If ConnectionName <> "" Then
                        Dim xconnection As New XElement("ConnectionName", ConnectionName)
                        xmessage.Add(xconnection)
                    End If
                    ConnectDoc.Add(xmessage)
                    If System.IO.File.Exists(AppInfo(AppName).ExecutablePath) Then
                        Shell(Chr(34) & AppInfo(AppName).ExecutablePath & Chr(34) & " " & Chr(34) & ConnectDoc.ToString & Chr(34), AppWinStyle.NormalFocus)
                    Else
                        Message.AddWarning("Application " & AppName & " executable path was not found: " & AppInfo(AppName).ExecutablePath & vbCrLf)
                    End If
                Else
                    Message.AddWarning("Connection name already in use: ConnName: " & ConnectionName & " in the Application Network: " & AppNetName & vbCrLf)
                End If
            End If
        End If
    End Sub

    Private Sub StartApp_ProjectID(ByVal AppName As String, ByVal ProjectID As String, ByVal ConnectionName As String)
        'Start the application with the name AppName.
        'If ProjectID is not "" then open the specified project.
        'If ConnectionName is not "" then connect to the Application Network.

        If AppInfo.ContainsKey(AppName) Then
            'Start the application:
            If ProjectID = "" And ConnectionName = "" Then
                'No project selected and application will not be connected to the network.
                Shell(Chr(34) & AppInfo(AppName).ExecutablePath & Chr(34), AppWinStyle.NormalFocus) 'Start the application with no argument
            Else
                If client.ConnectionAvailable(AppNetName, ConnectionName) Then
                    'Get the ProjectPath:
                    Dim ProjectPath As String
                    If ProjTreeInfo.ContainsKey(ProjectID) Then
                        ProjectPath = ProjTreeInfo(ProjectID).Path
                    Else
                        ProjectPath = ""
                        Message.AddWarning("Project ID not found in the ProjTreeInfo dictionary: " & ProjectID & vbCrLf)
                    End If
                    'Build the Application start message:
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim ConnectDoc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    If ProjectPath <> "" Then
                        Dim xproject As New XElement("ProjectPath", ProjectPath)
                        xmessage.Add(xproject)
                    End If
                    If ConnectionName <> "" Then
                        Dim xconnection As New XElement("ConnectionName", ConnectionName)
                        xmessage.Add(xconnection)
                    End If
                    ConnectDoc.Add(xmessage)

                    If System.IO.File.Exists(AppInfo(AppName).ExecutablePath) Then
                        Shell(Chr(34) & AppInfo(AppName).ExecutablePath & Chr(34) & " " & Chr(34) & ConnectDoc.ToString & Chr(34), AppWinStyle.NormalFocus)
                    Else
                        Message.AddWarning("Application " & AppName & " executable path was not found: " & AppInfo(AppName).ExecutablePath & vbCrLf)
                    End If
                Else
                    Message.AddWarning("Connection name already in use: ConnName: " & ConnectionName & " in the Application Network: " & AppNetName & vbCrLf)
                End If

            End If
        End If
    End Sub

    Private Sub StartApp_ProjectPath(ByVal AppName As String, ByVal ProjectPath As String, ByVal ConnectionName As String)
        'Start the application with the name AppName.
        'If ProjectPath is not "" then open the specified project.
        'If ConnectionName is not "" then connect to the Application Network.

        If AppInfo.ContainsKey(AppName) Then
            'Start the application:
            If ProjectPath = "" And ConnectionName = "" Then
                'No project selected and application will not be connected to the network.
                Shell(Chr(34) & AppInfo(AppName).ExecutablePath & Chr(34), AppWinStyle.NormalFocus) 'Start the application with no argument
            Else
                If client.ConnectionAvailable(AppNetName, ConnectionName) Then
                    'Build the Application start message:
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim ConnectDoc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    If ProjectPath <> "" Then
                        Dim xproject As New XElement("ProjectPath", ProjectPath)
                        xmessage.Add(xproject)
                    End If
                    If ConnectionName <> "" Then
                        Dim xconnection As New XElement("ConnectionName", ConnectionName)
                        xmessage.Add(xconnection)
                    End If
                    ConnectDoc.Add(xmessage)

                    If System.IO.File.Exists(AppInfo(AppName).ExecutablePath) Then
                        Shell(Chr(34) & AppInfo(AppName).ExecutablePath & Chr(34) & " " & Chr(34) & ConnectDoc.ToString & Chr(34), AppWinStyle.NormalFocus)
                    Else
                        Message.AddWarning("Application " & AppName & " executable path was not found: " & AppInfo(AppName).ExecutablePath & vbCrLf)
                    End If
                Else
                    Message.AddWarning("Connection name already in use: ConnName: " & ConnectionName & " in the Application Network: " & AppNetName & vbCrLf)
                End If
            End If
        Else
            Message.AddWarning("The application named " & AppName & " was not found in the application list." & vbCrLf)
        End If
    End Sub


    Private Sub btnAndorville_Click(sender As Object, e As EventArgs) Handles btnAndorville.Click
        ApplicationInfo.ShowInfo()
    End Sub

    Private Sub Project_ErrorMessage(Message As String) Handles Project.ErrorMessage
        Me.Message.SetWarningStyle()
        Me.Message.Add(Message & vbCrLf)
        Me.Message.SetNormalStyle()
    End Sub

    Private Sub Project_Message(Message As String) Handles Project.Message
        Me.Message.SetNormalStyle()
        Me.Message.Add(Message & vbCrLf)
    End Sub

    Private Sub trvAppTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvAppTree.AfterSelect
        txtNodeKey.Text = e.Node.Name
        If e.Node.Name.EndsWith(".Proj") Then
            'Project node
            'Application node
            txtItemType.Text = "Project"
            txtItemDescription.Text = ProjInfo(e.Node.Name).Description
            txtIconNo.Text = ProjInfo(e.Node.Name).IconNumber
            txtOpenIconNo.Text = ProjInfo(e.Node.Name).OpenIconNumber
            pbIcon.Image = AppTreeImageList.Images(ProjInfo(e.Node.Name).IconNumber)
            pbOpenIcon.Image = AppTreeImageList.Images(ProjInfo(e.Node.Name).OpenIconNumber)

            txtExePath2.Text = ""
            txtAppDirectory.Text = ""

            txtNodeText.Text = e.Node.Text

            txtProjName.Text = ProjInfo(e.Node.Name).Name
            txtProjType.Text = ProjInfo(e.Node.Name).Type.ToString
            txtProjPath.Text = ProjInfo(e.Node.Name).Path
            txtProjID.Text = ProjInfo(e.Node.Name).ID
            txtApplicationName.Text = ProjInfo(e.Node.Name).ApplicationName
            txtParentProjectName.Text = ProjInfo(e.Node.Name).ParentProjectName
            txtParentProjectID.Text = ProjInfo(e.Node.Name).ParentProjectID

            btnAddToProjTree.Enabled = True
        Else
            'Application node
            txtItemType.Text = "Application"
            txtItemDescription.Text = AppInfo(e.Node.Name).Description
            txtIconNo.Text = AppInfo(e.Node.Name).IconNumber
            txtOpenIconNo.Text = AppInfo(e.Node.Name).OpenIconNumber
            pbIcon.Image = AppTreeImageList.Images(AppInfo(e.Node.Name).IconNumber)
            pbOpenIcon.Image = AppTreeImageList.Images(AppInfo(e.Node.Name).OpenIconNumber)
            txtExePath2.Text = AppInfo(e.Node.Name).ExecutablePath
            txtAppDirectory.Text = AppInfo(e.Node.Name).Directory

            txtNodeText.Text = e.Node.Text

            txtProjName.Text = ""
            txtProjType.Text = ""
            txtProjPath.Text = ""
            txtProjID.Text = ""
            txtApplicationName.Text = ""
            txtParentProjectName.Text = ""
            txtParentProjectID.Text = ""

            btnAddToProjTree.Enabled = False
        End If

    End Sub

    Private Sub btnDeleteNode_Click(sender As Object, e As EventArgs) Handles btnDeleteNode.Click
        'Delete the selected node.
        If trvAppTree.SelectedNode Is Nothing Then
            'No node has been selected.
        Else
            Dim Node As TreeNode
            Node = trvAppTree.SelectedNode
            Dim NodeName As String = Node.Name
            If Node.Nodes.Count > 0 Then
                Message.AddWarning("The selected node has child nodes. Delete the child nodes before deleting this node." & vbCrLf)
            Else
                If NodeName = "ADVL_Application_Network_1" Then
                    Message.AddWarning("The ADVL_Application_Network_1 node cannot be deleted." & vbCrLf)
                Else
                    If NodeName.EndsWith(".Proj") Then
                        'Deleting a Project node.
                        'Delete the ProjInfo entry:
                        ProjInfo.Remove(NodeName)
                        If Node.Parent Is Nothing Then
                            Node.Remove()
                        Else
                            Dim Parent As TreeNode = Node.Parent
                            Parent.Nodes.RemoveAt(Node.Index)
                        End If
                    Else
                        'Deleting an Application node.
                        'Delete the application icons:
                        If AppInfo(NodeName).IconNumber = AppInfo(NodeName).OpenIconNumber Then
                            'Delete the OpenIcon (same as Icon)
                            AppTreeImageList.Images.RemoveAt(AppInfo(NodeName).IconNumber) 'Remove the deleted node's icon.

                            Dim I As Integer
                            'Update the icon index numbers in AppInfo()
                            For I = 0 To AppInfo.Count - 1
                                If AppInfo(AppInfo.Keys(I)).IconNumber > AppInfo(NodeName).IconNumber Then
                                    AppInfo(AppInfo.Keys(I)).IconNumber -= 1
                                End If
                                If AppInfo(AppInfo.Keys(I)).OpenIconNumber > AppInfo(NodeName).IconNumber Then
                                    AppInfo(AppInfo.Keys(I)).OpenIconNumber -= 1
                                End If
                            Next
                            'Update the icon index numbers in ProjectInfo()
                            For I = 0 To ProjInfo.Count - 1
                                If ProjInfo(ProjInfo.Keys(I)).IconNumber > AppInfo(NodeName).IconNumber Then
                                    ProjInfo(ProjInfo.Keys(I)).IconNumber -= 1
                                End If
                                If ProjInfo(ProjInfo.Keys(I)).OpenIconNumber > AppInfo(NodeName).IconNumber Then
                                    ProjInfo(ProjInfo.Keys(I)).OpenIconNumber -= 1
                                End If
                            Next
                        ElseIf AppInfo(NodeName).IconNumber < AppInfo(NodeName).OpenIconNumber Then
                            'Delete the OpenIcon first. (Deleting the Icon will change the index numbers of following icons.)
                            AppTreeImageList.Images.RemoveAt(AppInfo(NodeName).OpenIconNumber)
                            AppTreeImageList.Images.RemoveAt(AppInfo(NodeName).IconNumber)

                            'Update the icon index numbers in AppInfo()
                            Dim I As Integer
                            Dim Shift As Integer = 0
                            For I = 0 To AppInfo.Count - 1
                                If AppInfo(AppInfo.Keys(I)).IconNumber > AppInfo(NodeName).IconNumber Then
                                    Shift += 1
                                End If
                                If AppInfo(AppInfo.Keys(I)).IconNumber > AppInfo(NodeName).OpenIconNumber Then
                                    Shift += 1
                                End If
                                AppInfo(AppInfo.Keys(I)).IconNumber -= Shift
                                Shift = 0
                                If AppInfo(AppInfo.Keys(I)).OpenIconNumber > AppInfo(NodeName).IconNumber Then
                                    Shift += 1
                                End If
                                If AppInfo(AppInfo.Keys(I)).OpenIconNumber > AppInfo(NodeName).OpenIconNumber Then
                                    Shift += 1
                                End If
                                AppInfo(AppInfo.Keys(I)).OpenIconNumber -= Shift
                                Shift = 0
                            Next
                            'Update the icon index numbers in ProjectInfo()
                            For I = 0 To ProjInfo.Count - 1
                                If ProjInfo(ProjInfo.Keys(I)).IconNumber > AppInfo(NodeName).IconNumber Then
                                    Shift += 1
                                End If
                                If ProjInfo(ProjInfo.Keys(I)).IconNumber > AppInfo(NodeName).OpenIconNumber Then
                                    Shift += 1
                                End If
                                ProjInfo(ProjInfo.Keys(I)).IconNumber -= Shift
                                Shift = 0
                                If ProjInfo(ProjInfo.Keys(I)).OpenIconNumber > AppInfo(NodeName).IconNumber Then
                                    Shift += 1
                                End If
                                If ProjInfo(ProjInfo.Keys(I)).OpenIconNumber > AppInfo(NodeName).OpenIconNumber Then
                                    Shift += 1
                                End If
                                ProjInfo(ProjInfo.Keys(I)).OpenIconNumber -= Shift
                            Next
                        Else
                            'Delete the OpenIcon last.
                            AppTreeImageList.Images.RemoveAt(AppInfo(NodeName).IconNumber)
                            AppTreeImageList.Images.RemoveAt(AppInfo(NodeName).OpenIconNumber)

                            'Update the icon index numbers in AppInfo()
                            Dim I As Integer
                            Dim Shift As Integer = 0
                            For I = 0 To AppInfo.Count - 1
                                If AppInfo(AppInfo.Keys(I)).IconNumber > AppInfo(NodeName).IconNumber Then
                                    Shift += 1
                                End If
                                If AppInfo(AppInfo.Keys(I)).IconNumber > AppInfo(NodeName).OpenIconNumber Then
                                    Shift += 1
                                End If
                                AppInfo(AppInfo.Keys(I)).IconNumber -= Shift
                                Shift = 0
                                If AppInfo(AppInfo.Keys(I)).OpenIconNumber > AppInfo(NodeName).IconNumber Then
                                    Shift += 1
                                End If
                                If AppInfo(AppInfo.Keys(I)).OpenIconNumber > AppInfo(NodeName).OpenIconNumber Then
                                    Shift += 1
                                End If
                                AppInfo(I).OpenIconNumber -= Shift
                                Shift = 0
                            Next
                            'Update the icon index numbers in ProjectInfo()
                            For I = 0 To ProjInfo.Count - 1
                                If ProjInfo(ProjInfo.Keys(I)).IconNumber > AppInfo(NodeName).IconNumber Then
                                    Shift += 1
                                End If
                                If ProjInfo(ProjInfo.Keys(I)).IconNumber > AppInfo(NodeName).OpenIconNumber Then
                                    Shift += 1
                                End If
                                ProjInfo(ProjInfo.Keys(I)).IconNumber -= Shift
                                Shift = 0
                                If ProjInfo(ProjInfo.Keys(I)).OpenIconNumber > AppInfo(NodeName).IconNumber Then
                                    Shift += 1
                                End If
                                If ProjInfo(ProjInfo.Keys(I)).OpenIconNumber > AppInfo(NodeName).OpenIconNumber Then
                                    Shift += 1
                                End If
                                ProjInfo(ProjInfo.Keys(I)).OpenIconNumber -= Shift
                            Next
                        End If

                        'Delete the AppInfo entry:
                        AppInfo.Remove(NodeName)

                        If Node.Parent Is Nothing Then
                            Node.Remove()
                        Else
                            Dim Parent As TreeNode = Node.Parent
                            Parent.Nodes.RemoveAt(Node.Index)
                        End If
                        UpdateAppTreeImageIndexes(trvAppTree.TopNode) 'This is needed to update the TreeView node icons.
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub UpdateAppTreeImageIndexes(ByRef Node As TreeNode)
        'Update the AppTree inages indexes.

        If Node.Name.EndsWith(".Proj") Then
            'Project node - The project icon indexes do not change.
        Else
            'Application node - update the icons.
            Node.ImageIndex = AppInfo(Node.Name).IconNumber
            Node.SelectedImageIndex = AppInfo(Node.Name).OpenIconNumber
        End If

        For Each ChildNode As TreeNode In Node.Nodes
            UpdateAppTreeImageIndexes(ChildNode)
        Next

    End Sub

    Private Sub btnStartApp2_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        'Start the selected application.

        Dim AppName As String = trvAppTree.SelectedNode.Name
        If AppName.EndsWith(".Proj") Then
            'Project node.
            Dim StartAppName As String = txtApplicationName.Text
            Dim StartAppConnName As String = txtApplicationName.Text
            Dim StartAppProjectPath As String = txtProjPath.Text
            If chkConnect2.Checked = True Then 'Start App and connect to ComNet
                If Not ConnectedToComNet Then
                    ConnectToComNet()
                End If
                StartApp_ProjectPath(StartAppName, StartAppProjectPath, StartAppConnName)
            Else 'Start App only.
                StartApp_ProjectPath(StartAppName, StartAppProjectPath, "")
            End If
        Else
            If AppInfo.ContainsKey(AppName) Then
                Dim ExePath As String = AppInfo(AppName).ExecutablePath
                If System.IO.File.Exists(ExePath) Then
                    If chkConnect2.Checked = True Then
                        If Not ConnectedToComNet Then
                            ConnectToComNet()
                        End If
                        Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                        Dim ConnectDoc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                        Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                        Dim xConnName As New XElement("ConnectionName", AppName) 'Use the AppName as the Connection Name.
                        xmessage.Add(xConnName)
                        ConnectDoc.Add(xmessage)
                        'Start the application with the argument string containing the instruction to connect to the ComNet
                        Shell(Chr(34) & ExePath & Chr(34) & " " & Chr(34) & ConnectDoc.ToString & Chr(34), AppWinStyle.NormalFocus)
                    Else
                        Shell(Chr(34) & ExePath & Chr(34), AppWinStyle.NormalFocus) 'Start the application with no argument.
                    End If
                Else
                    Message.AddWarning("The application: " & AppName & " executable path: " & ExePath & " was not found." & vbCrLf)
                End If
            Else
                Message.AddWarning("The application: " & AppName & " was not found in the application list." & vbCrLf)
            End If
        End If
    End Sub

    Private Sub trvAppTree_DragDrop(sender As Object, e As DragEventArgs) Handles trvAppTree.DragDrop
        'DragDrop.

        Dim Path As String()
        Path = e.Data.GetData(DataFormats.FileDrop)

        Message.Add(vbCrLf & "------------------------------------------------------------------------------------------------------------ " & vbCrLf) 'Add separator line.
        Message.Add("Path.Count: " & Path.Count & vbCrLf)

        Dim I As Integer
        For I = 0 To Path.Count - 1
            Message.Add(vbCrLf & "Path(" & I & "): " & Path(I) & vbCrLf)
            ProcessDragDropProject(Path(I))
        Next

    End Sub

    Private Sub ProcessDragDropProject(ByVal ProjectPath As String)
        'Process a Project that has been dragged into the Application Tree View:

        Message.Add(vbCrLf & "Processing Project:" & vbCrLf)
        Message.Add("Project path: " & ProjectPath & vbCrLf)

        'Check if ProjectPath is a File or a Directory:
        Dim Attr As System.IO.FileAttributes = IO.File.GetAttributes(ProjectPath)
        If Attr.HasFlag(IO.FileAttributes.Directory) Then
            Message.Add("Project path is a Directory." & vbCrLf)
            If System.IO.File.Exists(ProjectPath & "\Project_Info_ADVL_2.xml") Then
                Message.Add("The directory is an Andorville(TM) project." & vbCrLf)
                ReadDragDropDirectoryProjectInfo(ProjectPath)
            ElseIf System.IO.File.Exists(ProjectPath & "\ADVL_Project_Info.xml") Then
                Message.Add("The directory is an Andorville(TM) project. (Old ADVL_1 format version.)" & vbCrLf)
                'Convert the ADVL_Project_Info.xml file into a Project_Info_ADVL_2.xml file:
                Dim ProjInfoConversion As New ADVL_Utilities_Library_1.FormatConvert.ProjectInfoFileConversion
                ProjInfoConversion.ProjectType = ADVL_Utilities_Library_1.FormatConvert.ProjectInfoFileConversion.ProjectTypes.Directory
                ProjInfoConversion.ProjectPath = ProjectPath
                ProjInfoConversion.InputFileName = "ADVL_Project_Info.xml"
                ProjInfoConversion.InputFormatCode = ADVL_Utilities_Library_1.FormatConvert.ProjectInfoFileConversion.FormatCodes.ADVL_1
                ProjInfoConversion.OutputFormatCode = ADVL_Utilities_Library_1.FormatConvert.ProjectInfoFileConversion.FormatCodes.ADVL_2
                ProjInfoConversion.Convert()
                If System.IO.File.Exists(ProjectPath & "\Project_Info_ADVL_2.xml") Then
                    ReadDragDropDirectoryProjectInfo(ProjectPath)
                Else
                    Message.AddWarning("The Project Information file could not be converted to the ADVL_2 format version." & vbCrLf)
                End If
            Else
                Message.Add("The directory is not an Andorville(TM) project." & vbCrLf)
            End If
        Else
            Message.Add("Project path is a File." & vbCrLf)
            If ProjectPath.EndsWith(".AdvlProject") Then
                Message.Add("The file is an Andorville(TM) project." & vbCrLf)
                ReadDragDropArchiveProjectInfo(ProjectPath)
            Else
                Message.Add("The file is not an Andorville(TM) project." & vbCrLf)
            End If
        End If

    End Sub

    Private Sub ReadDragDropDirectoryProjectInfo(ByVal ProjectPath As String)
        'Read the Project Information from a Directory Project.

        Dim ProjectInfo As System.Xml.Linq.XDocument = XDocument.Load(ProjectPath & "\Project_Info_ADVL_2.xml")

        Message.Add(vbCrLf) 'Add a blank line.

        Dim ProjectName As String
        If ProjectInfo.<Project>.<Name>.Value = Nothing Then
            ProjectName = ""
        Else
            ProjectName = ProjectInfo.<Project>.<Name>.Value
        End If
        Message.Add("Project Name = " & ProjectName & vbCrLf)

        Dim ProjectID As String
        If ProjectInfo.<Project>.<ID>.Value = Nothing Then
            ProjectID = ""
            Message.AddWarning("The Project ID is blank." & vbCrLf)
        Else
            ProjectID = ProjectInfo.<Project>.<ID>.Value
        End If
        Message.Add("Project ID = " & ProjectID & vbCrLf)

        Dim ProjectType As String
        If ProjectInfo.<Project>.<Type>.Value = Nothing Then
            ProjectType = ""
        Else
            ProjectType = ProjectInfo.<Project>.<Type>.Value
        End If
        Message.Add("Project Type = " & ProjectType & vbCrLf)

        Message.Add("Project Path= " & ProjectPath & vbCrLf)

        Dim ProjectDescription As String
        If ProjectInfo.<Project>.<Description>.Value = Nothing Then
            ProjectDescription = ""
        Else
            ProjectDescription = ProjectInfo.<Project>.<Description>.Value
        End If
        Message.Add("Project Description = " & ProjectDescription & vbCrLf)

        Dim ApplicationName As String
        If ProjectInfo.<Project>.<Application>.<Name>.Value = Nothing Then
            ApplicationName = ""
        Else
            ApplicationName = ProjectInfo.<Project>.<Application>.<Name>.Value
        End If
        Message.Add("Application Name = " & ApplicationName & vbCrLf)

        Dim ParentProjectName As String
        'Legacy code version:
        If ProjectInfo.<Project>.<HostProject>.<Name>.Value = Nothing Then
            ParentProjectName = ""
        Else
            ParentProjectName = ProjectInfo.<Project>.<HostProject>.<Name>.Value
        End If

        'Updated code version:
        If ProjectInfo.<Project>.<ParentProject>.<Name>.Value = Nothing Then
            'ParentProjectName = ""  'NO NEED TO CHANGE THIS - THE CODE ABOVE SHOULD HAVE SET THE CORRECT VALUE.
        Else
            ParentProjectName = ProjectInfo.<Project>.<ParentProject>.<Name>.Value
        End If

        Message.Add("Parent Project Name = " & ParentProjectName & vbCrLf)

        Dim ParentProjectID As String
        'Legacy code version:
        If ProjectInfo.<Project>.<HostProject>.<ID>.Value = Nothing Then
            ParentProjectID = ""
        Else
            ParentProjectID = ProjectInfo.<Project>.<HostProject>.<ID>.Value
        End If

        'Updated code version:
        If ProjectInfo.<Project>.<ParentProject>.<ID>.Value = Nothing Then
            'ParentProjectID = "" 'NO NEED TO CHANGE THIS - THE CODE ABOVE SHOULD HAVE SET THE CORRECT VALUE.
        Else
            ParentProjectID = ProjectInfo.<Project>.<ParentProject>.<ID>.Value
        End If

        Message.Add("Parent Project ID = " & ParentProjectID & vbCrLf)

        'Add project to the AppTree -----------------------------------------------------
        'This is displayed in the Applcation Tree tab.
        If ProjInfo.ContainsKey(ProjectID & ".Proj") Then
            Message.Add("Project is already in the TreeView. Project ID = " & ProjectID & vbCrLf)
        Else
            ProjInfo.Add(ProjectID & ".Proj", New clsProjInfo)
            ProjInfo(ProjectID & ".Proj").Name = ProjectName
            ProjInfo(ProjectID & ".Proj").ID = ProjectID

            ProjInfo(ProjectID & ".Proj").Path = ProjectPath
            ProjInfo(ProjectID & ".Proj").Description = ProjectDescription
            ProjInfo(ProjectID & ".Proj").ApplicationName = ApplicationName
            ProjInfo(ProjectID & ".Proj").ParentProjectName = ParentProjectName
            ProjInfo(ProjectID & ".Proj").ParentProjectID = ParentProjectID

            Select Case ProjectType
                Case "None"
                    ProjInfo(ProjectID & ".Proj").Type = ADVL_Utilities_Library_1.Project.Types.None
                    ProjInfo(ProjectID & ".Proj").IconNumber = 0
                    ProjInfo(ProjectID & ".Proj").OpenIconNumber = 1
                    Dim node As TreeNode()
                    If ApplicationName = trvAppTree.TopNode.Name Then
                        node = trvAppTree.Nodes.Find(ApplicationName, False)
                    Else
                        node = trvAppTree.TopNode.Nodes.Find(ApplicationName, False)
                    End If
                    If node Is Nothing Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    ElseIf node.Length = 0 Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    Else
                        trvAppTree.SelectedNode = node(0)
                        trvAppTree.SelectedNode.Nodes.Add(ProjectID & ".Proj", ProjectName, 0, 1) '0, 1 Default project icons.
                    End If
                Case "Directory"
                    ProjInfo(ProjectID & ".Proj").Type = ADVL_Utilities_Library_1.Project.Types.Directory
                    ProjInfo(ProjectID & ".Proj").IconNumber = 2
                    ProjInfo(ProjectID & ".Proj").OpenIconNumber = 3
                    Dim node As TreeNode()
                    If ApplicationName = trvAppTree.TopNode.Name Then
                        node = trvAppTree.Nodes.Find(ApplicationName, False)
                    Else
                        node = trvAppTree.TopNode.Nodes.Find(ApplicationName, False)
                    End If
                    If node Is Nothing Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    ElseIf node.Length = 0 Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    Else
                        trvAppTree.SelectedNode = node(0)
                        trvAppTree.SelectedNode.Nodes.Add(ProjectID & ".Proj", ProjectName, 2, 3) '2, 3 Directory project icons.
                    End If
                Case "Archive"
                    ProjInfo(ProjectID & ".Proj").Type = ADVL_Utilities_Library_1.Project.Types.Archive
                    ProjInfo(ProjectID & ".Proj").IconNumber = 4
                    ProjInfo(ProjectID & ".Proj").OpenIconNumber = 5
                    Dim node As TreeNode()
                    If ApplicationName = trvAppTree.TopNode.Name Then
                        node = trvAppTree.Nodes.Find(ApplicationName, False)
                    Else
                        node = trvAppTree.TopNode.Nodes.Find(ApplicationName, False)
                    End If
                    If node Is Nothing Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    ElseIf node.Length = 0 Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    Else
                        trvAppTree.SelectedNode = node(0)
                        trvAppTree.SelectedNode.Nodes.Add(ProjectID & ".Proj", ProjectName, 4, 5) '4, 5 Archive project icons.
                    End If
                Case "Hybrid"
                    ProjInfo(ProjectID & ".Proj").Type = ADVL_Utilities_Library_1.Project.Types.Hybrid
                    ProjInfo(ProjectID & ".Proj").IconNumber = 6
                    ProjInfo(ProjectID & ".Proj").OpenIconNumber = 7

                    Dim node As TreeNode()
                    If ApplicationName = trvAppTree.TopNode.Name Then
                        node = trvAppTree.Nodes.Find(ApplicationName, False)
                    Else
                        node = trvAppTree.TopNode.Nodes.Find(ApplicationName, False)
                    End If

                    If node Is Nothing Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    ElseIf node.Length = 0 Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    Else
                        trvAppTree.SelectedNode = node(0)
                        trvAppTree.SelectedNode.Nodes.Add(ProjectID & ".Proj", ProjectName, 6, 7) '6, 7 Hybrid project icons.
                    End If
                Case Else
                    Message.AddWarning("Unknown project type: " & ProjectType & vbCrLf)
            End Select
        End If
    End Sub

    Private Sub ReadDragDropArchiveProjectInfo(ByVal ProjectPath As String)
        'Read the Project Information from an Archive Project.

        Dim ProjectInfo As System.Xml.Linq.XDocument

        Dim Zip As New ADVL_Utilities_Library_1.ZipComp
        Zip.ArchivePath = ProjectPath

        If Zip.EntryExists("Project_Info_ADVL_2.xml") Then
            ProjectInfo = XDocument.Parse("<?xml version=""1.0"" encoding=""utf-8""?>" & Zip.GetText("Project_Info_ADVL_2.xml"))
        Else
            'Convert the ADVL_Project_Info.xml file into a Project_Info_ADVL_2.xml file:
            Dim ProjInfoConversion As New ADVL_Utilities_Library_1.FormatConvert.ProjectInfoFileConversion
            ProjInfoConversion.ProjectType = ADVL_Utilities_Library_1.FormatConvert.ProjectInfoFileConversion.ProjectTypes.Archive
            ProjInfoConversion.ProjectPath = ProjectPath
            ProjInfoConversion.InputFormatCode = ADVL_Utilities_Library_1.FormatConvert.ProjectInfoFileConversion.FormatCodes.ADVL_1
            ProjInfoConversion.OutputFormatCode = ADVL_Utilities_Library_1.FormatConvert.ProjectInfoFileConversion.FormatCodes.ADVL_2
            ProjInfoConversion.Convert()
            If Zip.EntryExists("Project_Info_ADVL_2.xml") Then
                ProjectInfo = XDocument.Parse("<?xml version=""1.0"" encoding=""utf-8""?>" & Zip.GetText("Project_Info_ADVL_2.xml"))
            Else
                Message.AddWarning("The Project Information file could not be converted to the ADVL_2 format version." & vbCrLf)
                Exit Sub
            End If
        End If

        If ProjectInfo Is Nothing Then
            Message.AddWarning("Project Info file not found in the Archive project" & vbCrLf)
            Exit Sub
        End If

        Message.Add(vbCrLf) 'Add a blank line.

        Dim ProjectName As String
        If ProjectInfo.<Project>.<Name>.Value = Nothing Then
            ProjectName = ""
        Else
            ProjectName = ProjectInfo.<Project>.<Name>.Value
        End If
        Message.Add("Project Name = " & ProjectName & vbCrLf)

        Dim ProjectID As String
        If ProjectInfo.<Project>.<ID>.Value = Nothing Then
            ProjectID = ""
        Else
            ProjectID = ProjectInfo.<Project>.<ID>.Value
        End If
        Message.Add("Project ID = " & ProjectID & vbCrLf)

        Dim ProjectType As String
        If ProjectInfo.<Project>.<Type>.Value = Nothing Then
            ProjectType = ""
        Else
            ProjectType = ProjectInfo.<Project>.<Type>.Value
        End If
        Message.Add("Project Type = " & ProjectType & vbCrLf)

        Message.Add("Project Path= " & ProjectPath & vbCrLf)

        Dim ProjectDescription As String
        If ProjectInfo.<Project>.<Description>.Value = Nothing Then
            ProjectDescription = ""
        Else
            ProjectDescription = ProjectInfo.<Project>.<Description>.Value
        End If
        Message.Add("Project Description = " & ProjectDescription & vbCrLf)

        Dim ApplicationName As String
        If ProjectInfo.<Project>.<Application>.<Name>.Value = Nothing Then
            ApplicationName = ""
        Else
            ApplicationName = ProjectInfo.<Project>.<Application>.<Name>.Value
        End If
        Message.Add("Application Name = " & ApplicationName & vbCrLf)

        Dim ParentProjectName As String
        'Legacy code version:
        If ProjectInfo.<Project>.<HostProject>.<Name>.Value = Nothing Then
            ParentProjectName = ""
        Else
            ParentProjectName = ProjectInfo.<Project>.<HostProject>.<Name>.Value
        End If

        'Updated code version:
        If ProjectInfo.<Project>.<ParentProject>.<Name>.Value = Nothing Then
            'ParentProjectName = ""  'NO NEED TO CHANGE THIS - THE CODE ABOVE SHOULD HAVE SET THE CORRECT VALUE.
        Else
            ParentProjectName = ProjectInfo.<Project>.<ParentProject>.<Name>.Value
        End If

        Message.Add("Parent Project Name = " & ParentProjectName & vbCrLf)

        Dim ParentProjectID As String
        'Legacy code version:
        If ProjectInfo.<Project>.<HostProject>.<ID>.Value = Nothing Then
            ParentProjectID = ""
        Else
            ParentProjectID = ProjectInfo.<Project>.<HostProject>.<ID>.Value
        End If

        'Updated code version:
        If ProjectInfo.<Project>.<ParentProject>.<ID>.Value = Nothing Then
            'ParentProjectID = "" 'NO NEED TO CHANGE THIS - THE CODE ABOVE SHOULD HAVE SET THE CORRECT VALUE.
        Else
            ParentProjectID = ProjectInfo.<Project>.<ParentProject>.<ID>.Value
        End If

        Message.Add("Parent Project ID = " & ParentProjectID & vbCrLf)

        'Add project to the AppTree -----------------------------------------------------
        'This is displayed in the Applcation Tree tab.
        If ProjInfo.ContainsKey(ProjectID & ".Proj") Then
            Message.Add("Project is already in the TreeView. Project ID = " & ProjectID & vbCrLf)
        Else
            ProjInfo.Add(ProjectID & ".Proj", New clsProjInfo)
            ProjInfo(ProjectID & ".Proj").Name = ProjectName
            ProjInfo(ProjectID & ".Proj").ID = ProjectID

            ProjInfo(ProjectID & ".Proj").Path = ProjectPath
            ProjInfo(ProjectID & ".Proj").Description = ProjectDescription
            ProjInfo(ProjectID & ".Proj").ApplicationName = ApplicationName
            ProjInfo(ProjectID & ".Proj").ParentProjectName = ParentProjectName
            ProjInfo(ProjectID & ".Proj").ParentProjectID = ParentProjectID

            Select Case ProjectType
                Case "None"
                    ProjInfo(ProjectID & ".Proj").Type = ADVL_Utilities_Library_1.Project.Types.None
                    ProjInfo(ProjectID & ".Proj").IconNumber = 0
                    ProjInfo(ProjectID & ".Proj").OpenIconNumber = 1
                    Dim node As TreeNode()
                    If ApplicationName = trvAppTree.TopNode.Name Then
                        node = trvAppTree.Nodes.Find(ApplicationName, False)
                    Else
                        node = trvAppTree.TopNode.Nodes.Find(ApplicationName, False)
                    End If
                    If node Is Nothing Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    ElseIf node.Length = 0 Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    Else
                        trvAppTree.SelectedNode = node(0)
                        trvAppTree.SelectedNode.Nodes.Add(ProjectID & ".Proj", ProjectName, 0, 1) '0, 1 Default project icons.
                    End If
                Case "Directory"
                    ProjInfo(ProjectID & ".Proj").Type = ADVL_Utilities_Library_1.Project.Types.Directory
                    ProjInfo(ProjectID & ".Proj").IconNumber = 2
                    ProjInfo(ProjectID & ".Proj").OpenIconNumber = 3
                    Dim node As TreeNode()
                    If ApplicationName = trvAppTree.TopNode.Name Then
                        node = trvAppTree.Nodes.Find(ApplicationName, False)
                    Else
                        node = trvAppTree.TopNode.Nodes.Find(ApplicationName, False)
                    End If
                    If node Is Nothing Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    ElseIf node.Length = 0 Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    Else
                        trvAppTree.SelectedNode = node(0)
                        trvAppTree.SelectedNode.Nodes.Add(ProjectID & ".Proj", ProjectName, 2, 3) '2, 3 Directory project icons.
                    End If
                Case "Archive"
                    ProjInfo(ProjectID & ".Proj").Type = ADVL_Utilities_Library_1.Project.Types.Archive
                    ProjInfo(ProjectID & ".Proj").IconNumber = 4
                    ProjInfo(ProjectID & ".Proj").OpenIconNumber = 5
                    Dim node As TreeNode()
                    If ApplicationName = trvAppTree.TopNode.Name Then
                        node = trvAppTree.Nodes.Find(ApplicationName, False)
                    Else
                        node = trvAppTree.TopNode.Nodes.Find(ApplicationName, False)
                    End If
                    If node Is Nothing Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    ElseIf node.Length = 0 Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    Else
                        trvAppTree.SelectedNode = node(0)
                        trvAppTree.SelectedNode.Nodes.Add(ProjectID & ".Proj", ProjectName, 4, 5) '4, 5 Archive project icons.
                    End If
                Case "Hybrid"
                    ProjInfo(ProjectID & ".Proj").Type = ADVL_Utilities_Library_1.Project.Types.Hybrid
                    ProjInfo(ProjectID & ".Proj").IconNumber = 6
                    ProjInfo(ProjectID & ".Proj").OpenIconNumber = 7

                    Dim node As TreeNode()
                    If ApplicationName = trvAppTree.TopNode.Name Then
                        node = trvAppTree.Nodes.Find(ApplicationName, False)
                    Else
                        node = trvAppTree.TopNode.Nodes.Find(ApplicationName, False)
                    End If

                    If node Is Nothing Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    ElseIf node.Length = 0 Then
                        'Node not found.
                        Message.AddWarning("Application node not found for " & ApplicationName & vbCrLf)
                    Else
                        trvAppTree.SelectedNode = node(0)
                        trvAppTree.SelectedNode.Nodes.Add(ProjectID & ".Proj", ProjectName, 6, 7) '6, 7 Hybrid project icons.
                    End If
                Case Else
                    Message.AddWarning("Unknown project type: " & ProjectType & vbCrLf)
            End Select
        End If
    End Sub


    Private Sub trvAppTree_DragEnter(sender As Object, e As DragEventArgs) Handles trvAppTree.DragEnter
        'DragEnter: An object has been dragged into the trvAppTree.

        'This code is required to get the link to the item(s) being dragged into the trvAppTree:
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Link
        End If
    End Sub

    Private Sub btnMoveUp_Click(sender As Object, e As EventArgs) Handles btnMoveUp.Click
        'Move the selected item up in the Application Tree.

        If trvAppTree.SelectedNode Is Nothing Then
            'No node has been selected.
        Else
            Dim Node As TreeNode
            Node = trvAppTree.SelectedNode
            Dim index As Integer = Node.Index
            If index = 0 Then
                'Already at the first node.
                Node.TreeView.Focus()
            Else
                Dim Parent As TreeNode = Node.Parent
                Parent.Nodes.RemoveAt(index)
                Parent.Nodes.Insert(index - 1, Node)
                trvAppTree.SelectedNode = Node
                Node.TreeView.Focus()
            End If
        End If
    End Sub

    Private Sub btnMoveDown_Click(sender As Object, e As EventArgs) Handles btnMoveDown.Click
        'Move the selected item down in the Application Tree.

        If trvAppTree.SelectedNode Is Nothing Then
            'No node has been selected.
        Else
            Dim Node As TreeNode
            Node = trvAppTree.SelectedNode
            Dim index As Integer = Node.Index
            Dim Parent As TreeNode = Node.Parent
            If index < Parent.Nodes.Count - 1 Then
                Parent.Nodes.RemoveAt(index)
                Parent.Nodes.Insert(index + 1, Node)
                trvAppTree.SelectedNode = Node
                Node.TreeView.Focus()
            Else
                'Already at the last node.
                Node.TreeView.Focus()
            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'Update the selected node text.

        If trvAppTree.SelectedNode Is Nothing Then

        Else
            trvAppTree.SelectedNode.Text = txtNodeText.Text
        End If

    End Sub

    Private Sub btnCreateDirectoryProject_Click(sender As Object, e As EventArgs) Handles btnCreateDirectoryProject.Click
        'Create a new Child Directory Project.

        If trvProjTree.SelectedNode Is Nothing Then
            'No node selected as parent.
            Message.AddWarning("No node has been selected as the Parent project." & vbCrLf)
        ElseIf txtPTProjType.Text = "Archive" Then
            Message.AddWarning("An Archive project cannot be the Parent project." & vbCrLf)
        ElseIf cmbNewChildProjectApplication.SelectedIndex = -1 Then
            Message.AddWarning("The new project application has not been selected." & vbCrLf)
        ElseIf cmbNewChildProjectType.SelectedIndex = -1 Then
            Message.AddWarning("The new project type has not been selected." & vbCrLf)
        ElseIf txtNewChildProjectName.Text = "" Then
            Message.AddWarning("The new project name has not been specified." & vbCrLf)
        ElseIf txtProjectDirectoryName.Text = "" Then
            Message.AddWarning("The new project directory name has not been specified." & vbCrLf)

        Else
            'OK to create child project:
            Dim NewProject As New ADVL_Utilities_Library_1.Project
            Dim DirectoryPath As String = txtPTProjPath.Text 'This is the Parent Project directory. The new Child Project will be created in this directory.
            If System.IO.Directory.Exists(DirectoryPath) Then
                'ProjectPath exists.
            Else
                Message.AddWarning("The new project cannot be created. The Parent Project directory does not exist: " & DirectoryPath & vbCrLf)
                Exit Sub
            End If
            Dim NewProjectDirectoryname As String = txtProjectDirectoryName.Text
            Dim NewProjectDirectoryPath As String = DirectoryPath & "\" & NewProjectDirectoryname

            'Check if the NewProjectDirectoryPath already exists:
            If System.IO.Directory.Exists(NewProjectDirectoryPath) Then
                Message.AddWarning("The new project cannot be created. The specified new project directory already exists: " & NewProjectDirectoryPath & vbCrLf)
                Exit Sub
            Else
                System.IO.Directory.CreateDirectory(NewProjectDirectoryPath) 'The new project directory has been created.
            End If

            NewProject.Type = Project.Types.Directory
            NewProject.Path = NewProjectDirectoryPath
            NewProject.RelativePath = txtProjectDirectoryRelativePath.Text
            NewProject.Name = txtNewChildProjectName.Text
            NewProject.Description = txtNewChildProjectDescription.Text
            NewProject.CreationDate = Format(Now, "d-MMM-yyyy H:mm:ss")

            Dim IDString As String = NewProject.Name & " " & Format(NewProject.CreationDate, "d-MMM-yyyy H:mm:ss")
            NewProject.ID = IDString.GetHashCode

            'All relative locations point to the Project Directory:
            NewProject.SettingsRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
            NewProject.SettingsRelLocn.Path = ""
            NewProject.DataRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
            NewProject.DataRelLocn.Path = ""
            NewProject.SystemRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
            NewProject.SystemRelLocn.Path = ""

            'All locations are the same as the Project Directory:
            NewProject.SettingsLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
            NewProject.SettingsLocn.Path = NewProjectDirectoryPath
            NewProject.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
            NewProject.DataLocn.Path = NewProjectDirectoryPath
            NewProject.SystemLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
            NewProject.SystemLocn.Path = NewProjectDirectoryPath

            NewProject.Author.Name = txtAuthorName.Text
            NewProject.Author.Description = txtAuthorDescription.Text
            NewProject.Author.Contact = txtAuthorContact.Text

            NewProject.ParentProjectName = txtPTProjName.Text
            NewProject.ParentProjectID = txtPTProjID.Text
            NewProject.ParentProjectPath = txtPTProjPath.Text
            NewProject.ParentProjectCreationDate = txtPTProjCreationDate.Text

            NewProject.Usage.FirstUsed = NewProject.CreationDate
            NewProject.Usage.LastUsed = Format(Now, "d-MMM-yyyy H:mm:ss")

            NewProject.ApplicationName = cmbNewChildProjectApplication.SelectedItem.ToString 'Same as NewProject.Application.Name (?)

            'Get the Application Information
            If AppInfo.ContainsKey(NewProject.ApplicationName) Then
                Dim NewProjectAppInfo As New ADVL_Utilities_Library_1.ApplicationInfo
                NewProject.ApplicationDir = AppInfo(NewProject.ApplicationName).Directory
                NewProjectAppInfo.ApplicationDir = NewProject.ApplicationDir
                NewProjectAppInfo.ReadFile() 'Read the Application Information file.
                NewProject.Application.Name = NewProjectAppInfo.Name
                NewProject.Application.Description = NewProjectAppInfo.Description
                NewProject.Application.CreationDate = NewProjectAppInfo.CreationDate
                NewProject.Application.Version.Major = NewProjectAppInfo.Version.Major
                NewProject.Application.Version.Minor = NewProjectAppInfo.Version.Minor
                NewProject.Application.Version.Build = NewProjectAppInfo.Version.Build
                NewProject.Application.Version.Revision = NewProjectAppInfo.Version.Revision
                NewProject.Application.Author.Name = NewProjectAppInfo.Author.Name
                NewProject.Application.Author.Description = NewProjectAppInfo.Author.Description
                NewProject.Application.Author.Contact = NewProjectAppInfo.Author.Contact

                NewProject.SaveProjectInfoFile() 'Save the Project Information file.

                'Add the New Child Project to the Project Tree:
                'AppName: NewProject.ApplicationName
                'ProjectType: Directory
                'ProjectText: NewProject.Name (txtNewChildProjectName.Text)
                'ProjectKey: NewProject.ID
                Dim IconNumber As Integer = ProjTreeImageNumber(NewProject.ApplicationName, "Directory", False)
                Dim OpenIconNumber As Integer = ProjTreeImageNumber(NewProject.ApplicationName, "Directory", True)
                If NewProject.ID = "" Then
                    Message.AddWarning("The New Child Project ID is blank." & vbCrLf)
                ElseIf ProjTreeInfo.ContainsKey(NewProject.ID) Then
                    Message.AddWarning("The New Child Project is already in the Project Tree." & vbCrLf)
                Else
                    'OK to add the new child tree to the TreeView:
                    trvProjTree.SelectedNode.Nodes.Add(NewProject.ID, NewProject.Name, IconNumber, OpenIconNumber)
                    ProjTreeInfo.Add(NewProject.ID, New clsProjInfo)
                    ProjTreeInfo(NewProject.ID).Name = NewProject.Name
                    ProjTreeInfo(NewProject.ID).CreationDate = NewProject.CreationDate
                    ProjTreeInfo(NewProject.ID).Description = NewProject.Description
                    ProjTreeInfo(NewProject.ID).Type = ADVL_Utilities_Library_1.Project.Types.Directory
                    ProjTreeInfo(NewProject.ID).Path = NewProject.Path
                    ProjTreeInfo(NewProject.ID).RelativePath = NewProject.RelativePath
                    ProjTreeInfo(NewProject.ID).ID = NewProject.ID
                    ProjTreeInfo(NewProject.ID).ApplicationName = NewProject.ApplicationName
                    ProjTreeInfo(NewProject.ID).ParentProjectName = txtPTProjName.Text
                    ProjTreeInfo(NewProject.ID).ParentProjectID = txtPTProjID.Text
                    ProjTreeInfo(NewProject.ID).ParentProjectPath = NewProject.ParentProjectPath
                    ProjTreeInfo(NewProject.ID).IconNumber = IconNumber
                    ProjTreeInfo(NewProject.ID).OpenIconNumber = OpenIconNumber
                End If
            Else
                Message.AddWarning("The child project application was not found in the list: " & NewProject.ApplicationName & vbCrLf)
            End If
        End If
    End Sub

    Private Sub CreateChildArchiveProject()
        'Create a new Child Archive Project.

    End Sub

    Private Sub CreateChildHybridProject()
        'Create a new Child Hybrid Project.

    End Sub

    Private Sub btnAddToProjTree_Click(sender As Object, e As EventArgs) Handles btnAddToProjTree.Click
        'Add the selected Project to the Project Tree.

        Dim myAppName As String = txtApplicationName.Text
        Dim myProjectType As String = txtProjType.Text

        If myProjectType = "None" Then
            Message.AddWarning("Default projects cannot be added to the Project Tree." & vbCrLf)
            Exit Sub
        End If

        Dim myProjectText As String = txtProjName.Text 'CHECK THAT THIS IS THE NODE TEXT!!!
        Dim IconNumber As Integer = ProjTreeImageNumber(myAppName, myProjectType, False)
        Dim OpenIconNumber As Integer = ProjTreeImageNumber(myAppName, myProjectType, True)

        Dim myKey As String = txtProjID.Text
        If myKey = "" Then
            Message.AddWarning("The Project ID is blank." & vbCrLf)
        Else
            If ProjTreeInfo.ContainsKey(myKey) Then
                Message.AddWarning("The Project is already in the Project Tree." & vbCrLf)
            Else
                'Saving: Name, Description, Type, Path, ID, ApplicationName, ParentProjectname, ParentProjectID, IconNumber, OpenIconNumber
                trvProjTree.Nodes.Add(myKey, myProjectText, IconNumber, OpenIconNumber) 'Add the Node to the Project Tree
                'Add the Node info to the ProjTreeInfo dictionary.
                ProjTreeInfo.Add(myKey, New clsProjInfo)
                ProjTreeInfo(myKey).Name = txtProjName.Text
                ProjTreeInfo(myKey).Description = txtItemDescription.Text

                Select Case myProjectType
                    Case "None"
                        ProjTreeInfo(myKey).Type = ADVL_Utilities_Library_1.Project.Types.None
                    Case "Directory"
                        ProjTreeInfo(myKey).Type = ADVL_Utilities_Library_1.Project.Types.Directory
                    Case "Archive"
                        ProjTreeInfo(myKey).Type = ADVL_Utilities_Library_1.Project.Types.Archive
                    Case "Hybrid"
                        ProjTreeInfo(myKey).Type = ADVL_Utilities_Library_1.Project.Types.Hybrid
                    Case Else
                        Message.AddWarning("Unknown Project Type: " & myProjectType & vbCrLf)
                End Select

                ProjTreeInfo(myKey).Path = txtProjPath.Text
                ProjTreeInfo(myKey).ID = myKey
                ProjTreeInfo(myKey).ApplicationName = txtApplicationName.Text
                ProjTreeInfo(myKey).ParentProjectName = txtParentProjectName.Text
                ProjTreeInfo(myKey).ParentProjectID = txtParentProjectID.Text
                ProjTreeInfo(myKey).IconNumber = IconNumber
                ProjTreeInfo(myKey).OpenIconNumber = OpenIconNumber
            End If
        End If
    End Sub

    Private Function ProjTreeImageNumber(ByVal AppName As String, ByVal ProjectType As String, ByVal Open As Boolean) As Integer
        'Returns the number of the image in ProjTreeImageList for the Project Tree icon corresponding to the AppName, ProjectType and Open (True/False).
        'If the image is not in the Image List, the correct image will be generated.

        Dim ImageKey As String

        If Open = True Then 'Find the image corresponding to an open project.
            Select Case ProjectType
                Case "Directory"
                    ImageKey = "Open_" & AppName & "_Directory"
                Case "Archive"
                    ImageKey = "Open_" & AppName & "_Archive"
                Case "Hybrid"
                    ImageKey = "Open_" & AppName & "_Hybrid"
                Case Else
                    Message.AddWarning("Unknown Project type: " & ProjectType & vbCrLf)
                    ImageKey = ""
            End Select

        Else 'Find the image corresponding to a closed project.
            Select Case ProjectType
                Case "Directory"
                    ImageKey = AppName & "_Directory"
                Case "Archive"
                    ImageKey = AppName & "_Archive"
                Case "Hybrid"
                    ImageKey = AppName & "_Hybrid"
                Case Else
                    Message.AddWarning("Unknown Project type: " & ProjectType & vbCrLf)
                    ImageKey = ""
            End Select
        End If

        If ImageKey = "" Then
            Return -1 'Unknown project type!
        Else
            If ProjTreeImageList.Images.ContainsKey(ImageKey) Then
                Return UpdateProjTreeImage(AppName, ProjectType, Open)
            Else
                Return CreateProjTreeImage(AppName, ProjectType, Open)
            End If
        End If

    End Function

    Private Function CreateProjTreeImage(ByVal AppName As String, ByVal ProjectType As String, ByVal Open As Boolean) As Integer
        'Creates an image in ProjTreeImageList for the Project Tree icon corresponding to the AppName, ProjectType and Open (True/False).
        'The index of the image in ProjectTreeImageList is returned.

        Dim ImageKey As String
        Dim ProjectImage As Bitmap 'The Project Image

        If Open = True Then 'Find the image corresponding to an open project.
            Select Case ProjectType
                Case "Directory"
                    ImageKey = "Open_" & AppName & "_Directory"
                    ProjectImage = ProjectIconImageList.Images(3) 'Open Directory
                Case "Archive"
                    ImageKey = "Open_" & AppName & "_Archive"
                    ProjectImage = ProjectIconImageList.Images(5) 'Open Archive
                Case "Hybrid"
                    ImageKey = "Open_" & AppName & "_Hybrid"
                    ProjectImage = ProjectIconImageList.Images(7) 'Open Hybrid
                Case Else
                    Message.AddWarning("Unknown Project type: " & ProjectType & vbCrLf)
                    ImageKey = ""
            End Select

        Else 'Find the image corresponding to a closed project.
            Select Case ProjectType
                Case "Directory"
                    ImageKey = AppName & "_Directory"
                    ProjectImage = ProjectIconImageList.Images(2) 'Closed Directory
                Case "Archive"
                    ImageKey = AppName & "_Archive"
                    ProjectImage = ProjectIconImageList.Images(4) 'Closed Archive
                Case "Hybrid"
                    ImageKey = AppName & "_Hybrid"
                    ProjectImage = ProjectIconImageList.Images(6) 'Closed Hybrid
                Case Else
                    Message.AddWarning("Unknown Project type: " & ProjectType & vbCrLf)
                    ImageKey = ""
            End Select
        End If

        If ImageKey = "" Then
            Return -1 'Unknown project type!
        Else
            If AppInfo.ContainsKey(AppName) Then
                Dim ExePath As String = AppInfo(AppName).ExecutablePath
                Dim AppIcon = System.Drawing.Icon.ExtractAssociatedIcon(ExePath) 'The Application Icon.
                Dim AppProjImage As Bitmap = New Bitmap(64, 32) 'Create a blank bitmap 64 pixels wide and 32 pixels high to contain the AppIcon and Project Image.
                Dim Grx As Graphics = Graphics.FromImage(AppProjImage)
                Grx.DrawImage(AppIcon.ToBitmap, 0, 0, 32, 32) 'x, y width, height - Add the AppIcon to the left of the image.
                Grx.DrawImage(ProjectImage, 32, 0, 32, 32) 'x, y width, height - Add the Project Icon to the right of the image.
                'AppProjImage now contains the combined Application and Project images.
                'Add it to the ProjTreeImageList:
                ProjTreeImageList.Images.Add(ImageKey, AppProjImage)
                Return ProjTreeImageList.Images.IndexOfKey(ImageKey)
            Else
                Message.AddWarning("The application name was not found in the list: " & AppName & vbCrLf)
                Return -1
            End If
        End If

    End Function

    Private Function UpdateProjTreeImage(ByVal AppName As String, ByVal ProjectType As String, ByVal Open As Boolean) As Integer
        'Creates an image in ProjTreeImageList for the Project Tree icon corresponding to the AppName, ProjectType and Open (True/False).
        'Any existing images that use the same ImageKey will be updated. (Used to test modified Project Tree icons.)
        'The index of the image in ProjectTreeImageList is returned.

        Dim ImageKey As String
        Dim ProjectImage As Bitmap 'The Project Image

        If Open = True Then 'Find the image corresponding to an open project.
            Select Case ProjectType
                Case "Directory"
                    ImageKey = "Open_" & AppName & "_Directory"
                    ProjectImage = ProjectIconImageList.Images(3) 'Open Directory
                Case "Archive"
                    ImageKey = "Open_" & AppName & "_Archive"
                    ProjectImage = ProjectIconImageList.Images(5) 'Open Archive
                Case "Hybrid"
                    ImageKey = "Open_" & AppName & "_Hybrid"
                    ProjectImage = ProjectIconImageList.Images(7) 'Open Hybrid
                Case Else
                    Message.AddWarning("Unknown Project type: " & ProjectType & vbCrLf)
                    ImageKey = ""
            End Select

        Else 'Find the image corresponding to a closed project.
            Select Case ProjectType
                Case "Directory"
                    ImageKey = AppName & "_Directory"
                    ProjectImage = ProjectIconImageList.Images(2) 'Closed Directory
                Case "Archive"
                    ImageKey = AppName & "_Archive"
                    ProjectImage = ProjectIconImageList.Images(4) 'Closed Archive
                Case "Hybrid"
                    ImageKey = AppName & "_Hybrid"
                    ProjectImage = ProjectIconImageList.Images(6) 'Closed Hybrid
                Case Else
                    Message.AddWarning("Unknown Project type: " & ProjectType & vbCrLf)
                    ImageKey = ""
            End Select
        End If

        If ImageKey = "" Then
            Return -1 'Unknown project type!
        Else
            If AppInfo.ContainsKey(AppName) Then
                Dim ExePath As String = AppInfo(AppName).ExecutablePath
                Dim AppIcon = System.Drawing.Icon.ExtractAssociatedIcon(ExePath) 'The Application Icon.
                Dim AppProjImage As Bitmap = New Bitmap(64, 32) 'Create a blank bitmap 64 pixels wide and 32 pixels high to contain the AppIcon and Project Image.
                Dim Grx As Graphics = Graphics.FromImage(AppProjImage)
                Grx.DrawImage(AppIcon.ToBitmap, 0, 0, 32, 32) 'x, y width, height - Add the AppIcon to the left of the image.
                Grx.DrawImage(ProjectImage, 32, 0, 32, 32) 'x, y width, height - Add the Project Icon to the right of the image.
                'AppProjImage now contains the combined Application and Project images.
                'Add it to the ProjTreeImageList:
                If ProjTreeImageList.Images.ContainsKey(ImageKey) Then 'Overwrite the existing image
                    ProjTreeImageList.Images.Item(ProjTreeImageList.Images.IndexOfKey(ImageKey)) = AppProjImage
                    Message.AddWarning("Updating image: " & ImageKey & vbCrLf)
                Else 'Add the new image
                    ProjTreeImageList.Images.Add(ImageKey, AppProjImage)
                End If
                Return ProjTreeImageList.Images.IndexOfKey(ImageKey)
            Else
                Message.AddWarning("The application name was not found in the list: " & AppName & vbCrLf)
                Return -1
            End If
        End If

    End Function

    Private Sub btnDeleteProjNode_Click(sender As Object, e As EventArgs)
        'Delete the selected node in the Project Tree.

        If trvProjTree.SelectedNode Is Nothing Then
            'No node has been selected.
        Else
            Dim Node As TreeNode
            Node = trvProjTree.SelectedNode
            Dim NodeKey As String = Node.Name
            If Node.Nodes.Count > 0 Then
                Message.AddWarning("The selected node has child nodes. Delete the child nodes before deleting this node." & vbCrLf)
            Else
                ProjTreeInfo.Remove(NodeKey)
                If Node.Parent Is Nothing Then
                    Node.Remove()
                Else
                    Dim Parent As TreeNode = Node.Parent
                    Parent.Nodes.RemoveAt(Node.Index)
                End If
            End If
        End If

    End Sub

    Private Sub trvProjTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvProjTree.AfterSelect

        Dim NodeKey As String = e.Node.Name
        txtPTProjNodeKey.Text = NodeKey 'The Node key

        txtNodeIndex.Text = e.Node.Index

        If ProjTreeInfo.ContainsKey(NodeKey) Then
            txtPTProjDescription.Text = ProjTreeInfo(NodeKey).Description
            txtPTProjName.Text = ProjTreeInfo(NodeKey).Name
            txtPTProjType.Text = ProjTreeInfo(NodeKey).Type.ToString
            txtPTProjID.Text = ProjTreeInfo(NodeKey).ID
            txtPTProjPath.Text = ProjTreeInfo(NodeKey).Path
            txtPTProjRelativePath.Text = ProjTreeInfo(NodeKey).RelativePath

            txtPTProjCreationDate.Text = Format(ProjTreeInfo(NodeKey).CreationDate, "d-MMM-yyyy H:mm:ss")

            txtPTProjAppName.Text = ProjTreeInfo(NodeKey).ApplicationName
            txtPTProjParentProjectName.Text = ProjTreeInfo(NodeKey).ParentProjectName
            txtPTProjParentProjectID.Text = ProjTreeInfo(NodeKey).ParentProjectID
            txtPTProjParentProjectPath.Text = ProjTreeInfo(NodeKey).ParentProjectPath

            txtNewChildParentName.Text = ProjTreeInfo(NodeKey).Name
            txtNewChildParentText.Text = e.Node.Text
            txtNewChildParentID.Text = ProjTreeInfo(NodeKey).ID

            If TabControl2.SelectedIndex = 1 Then 'The New Child Project tab is selected
                If ProjTreeInfo(NodeKey).ParentProjectPath.EndsWith(".AdvlProject") Then
                    Message.AddWarning("An archive project currently cannot have a child project." & vbCrLf)
                End If
            End If
        Else
            Message.AddWarning("The Key was not found in the Project List: " & NodeKey & vbCrLf)
        End If

    End Sub

    Private Sub cmbNewChildProjectType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNewChildProjectType.SelectedIndexChanged
        UpdateProjectTreeIcons()
        If cmbNewChildProjectType.SelectedItem.ToString = "Directory" Then
            TabControl3.SelectedIndex = 0
        ElseIf cmbNewChildProjectType.SelectedItem.ToString = "Archive" Then
            TabControl3.SelectedIndex = 1
        ElseIf cmbNewChildProjectType.SelectedItem.ToString = "Hybrid" Then
            TabControl3.SelectedIndex = 2
        End If
    End Sub

    Private Sub cmbNewChildProjectApplication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNewChildProjectApplication.SelectedIndexChanged
        UpdateProjectTreeIcons()
    End Sub

    Private Sub UpdateProjectTreeIcons()

        If cmbNewChildProjectApplication.SelectedItem = Nothing Then
            'No appliction selected.
            'Message.AddWarning("No application has been selected for the new Child Project." & vbCrLf)
            pbAppDirIcon.Image = Nothing
            pbOpenAppDirIcon.Image = Nothing
        Else
            If cmbNewChildProjectType.SelectedItem = Nothing Then
                pbAppDirIcon.Image = Nothing
                pbOpenAppDirIcon.Image = Nothing
            Else
                Dim AppName As String = cmbNewChildProjectApplication.SelectedItem.ToString

                If AppInfo.ContainsKey(AppName) Then
                    Dim ExePath As String = AppInfo(AppName).ExecutablePath
                    Dim myAppIcon = System.Drawing.Icon.ExtractAssociatedIcon(ExePath)
                    pbAppDirIcon.Image = myAppIcon.ToBitmap

                    Dim ProjectImage As Bitmap
                    Dim OpenProjectImage As Bitmap
                    Dim AppProjImage As Bitmap = New Bitmap(64, 32) 'Create a blank bitmap 64 pixels wide and 32 pixels high.
                    Dim OpenAppProjImage As Bitmap = New Bitmap(64, 32) 'Create a blank bitmap 64 pixels wide and 32 pixels high.

                    Select Case cmbNewChildProjectType.SelectedItem.ToString
                        Case "Directory"
                            ProjectImage = ProjectIconImageList.Images(2)
                            OpenProjectImage = ProjectIconImageList.Images(3)
                        Case "Archive"
                            ProjectImage = ProjectIconImageList.Images(4)
                            OpenProjectImage = ProjectIconImageList.Images(5)
                        Case "Hybrid"
                            ProjectImage = ProjectIconImageList.Images(6)
                            OpenProjectImage = ProjectIconImageList.Images(7)
                        Case Else
                            If cmbNewChildProjectType.SelectedItem.ToString = "" Then
                                Message.AddWarning("New Child Project type not selected." & vbCrLf)
                            Else
                                Message.AddWarning("Unknown new Child Project type: " & cmbNewChildProjectType.SelectedItem.ToString & vbCrLf)
                            End If
                    End Select

                    'Combine the two icons:
                    'Application-Project image:
                    Dim Grx As Graphics = Graphics.FromImage(AppProjImage)
                    Grx.DrawImage(myAppIcon.ToBitmap, 0, 0, 32, 32)
                    Grx.DrawImage(ProjectImage, 32, 0, 32, 32) 'x, y width, height
                    pbAppDirIcon.Image = AppProjImage

                    'Open Application-Project image:
                    Grx = Graphics.FromImage(OpenAppProjImage)
                    Grx.DrawImage(myAppIcon.ToBitmap, 0, 0, 32, 32)
                    Grx.DrawImage(OpenProjectImage, 32, 0, 32, 32) 'x, y width, height
                    pbOpenAppDirIcon.Image = OpenAppProjImage
                Else
                    Message.AddWarning("The application name was not found in the list: " & AppName & vbCrLf)
                End If
            End If

        End If
    End Sub

    Private Sub TabPage9_Enter(sender As Object, e As EventArgs) Handles TabPage9.Enter
        'Directory Project Tab.
        cmbNewChildProjectType.SelectedIndex = 0 'Select Directory project
    End Sub

    Private Sub TabPage10_Enter(sender As Object, e As EventArgs) Handles TabPage10.Enter
        'Archive Project tab.
        cmbNewChildProjectType.SelectedIndex = 1 'Select Archive project
    End Sub

    Private Sub TabPage11_Enter(sender As Object, e As EventArgs) Handles TabPage11.Enter
        'Hybrid Project tab.
        'A Hybrid project can contain three sub-directories or archives for storing data:
        'SettingsLocation - For saving temporary settings such as form sizes and positions.
        'SystemLocation - Stores System data - This is copied when and Andorville(TM) Solution is copied.
        'DataLocation - Stores Data used and generated by and Andorville(TM) Solution.

        cmbNewChildProjectType.SelectedIndex = 2 'Select Hybrid project
    End Sub

    Private Sub btnDeleteProjNode_Click_1(sender As Object, e As EventArgs) Handles btnDeleteProjNode.Click
        'Delete the selected node.

        If trvProjTree.SelectedNode Is Nothing Then
            'No node has been selected.
        Else
            Dim Node As TreeNode
            Node = trvProjTree.SelectedNode
            Dim NodeName As String = Node.Name
            If Node.Nodes.Count > 0 Then
                Message.AddWarning("The selected node has child nodes. Delete the child nodes before deleting this node." & vbCrLf)
            Else
                If ProjTreeInfo.ContainsKey(NodeName) Then
                    'Delete the ProjTreeInfo() entry:
                    ProjTreeInfo.Remove(NodeName)
                End If

                'Delete the node from trvProjTree:
                If Node.Parent Is Nothing Then
                    Node.Remove()
                Else
                    Dim Parent As TreeNode = Node.Parent
                    Parent.Nodes.RemoveAt(Node.Index)
                End If
            End If
        End If

    End Sub

    Public Sub UpdateWebPage(ByVal FileName As String)
        'Update the web page in WebPageFormList if the Web file name is FileName.

        Dim NPages As Integer = WebPageFormList.Count
        Dim I As Integer

        Try
            For I = 0 To NPages - 1
                If IsNothing(WebPageFormList(I)) Then
                    'Web page has been deleted!
                Else
                    If WebPageFormList(I).FileName = FileName Then
                        WebPageFormList(I).OpenDocument
                    End If
                End If
            Next
        Catch ex As Exception
            Message.AddWarning(ex.Message & vbCrLf)
        End Try
    End Sub

#Region " Start Page Code" '=========================================================================================================================================

    Public Sub OpenStartPage()
        'Open the StartPage.html file and display in the Start Page tab.

        If Project.DataFileExists("StartPage.html") Then
            StartPageFileName = "StartPage.html"
            DisplayStartPage()
        Else
            CreateStartPage()
            StartPageFileName = "StartPage.html"
            DisplayStartPage()
        End If

    End Sub

    Public Sub DisplayStartPage()
        'Display the StartPage.html file in the Start Page tab.

        If Project.DataFileExists(StartPageFileName) Then
            Dim rtbData As New IO.MemoryStream
            Project.ReadData(StartPageFileName, rtbData)
            rtbData.Position = 0
            Dim sr As New IO.StreamReader(rtbData)
            WebBrowser1.DocumentText = sr.ReadToEnd()
        Else
            Message.AddWarning("Web page file not found: " & StartPageFileName & vbCrLf)
            'StartPageFileName = ""
        End If
    End Sub

    Private Sub CreateStartPage()
        'Create a new default StartPage.html file.

        Dim htmData As New IO.MemoryStream
        Dim sw As New IO.StreamWriter(htmData)
        sw.Write(DefaultHtmlString("Start Page"))
        sw.Flush()
        Project.SaveData("StartPage.html", htmData)
    End Sub

    Public Function DefaultHtmlString(ByVal DocumentTitle As String) As String
        'Create a blank HTML Web Page.

        Dim sb As New System.Text.StringBuilder

        sb.Append("<!DOCTYPE html>" & vbCrLf)
        sb.Append("<html>" & vbCrLf & "<head>" & vbCrLf & "<title>" & DocumentTitle & "</title>" & vbCrLf)
        sb.Append("</head>" & vbCrLf & "<body>" & vbCrLf & vbCrLf)
        sb.Append("<h1>Start Page</h1>" & vbCrLf & vbCrLf)

        'Add JavaScript section:
        sb.Append("<script>" & vbCrLf & vbCrLf)

        'START: User defined JavaScript functions ==========================================================================
        'Add functions to implement the main actions performed by this web page.
        sb.Append("//START: User defined JavaScript functions ==========================================================================" & vbCrLf)
        sb.Append("//  Add functions to implement the main actions performed by this web page." & vbCrLf & vbCrLf)

        sb.Append("//END:   User defined JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf & vbCrLf)
        'END:   User defined JavaScript functions --------------------------------------------------------------------------


        'START: User modified JavaScript functions ==========================================================================
        'Modify these function to save all required web page settings and process all expected XMessage instructions.
        sb.Append("//START: User modified JavaScript functions ==========================================================================" & vbCrLf)
        sb.Append("//  Modify these function to save all required web page settings and process all expected XMessage instructions." & vbCrLf & vbCrLf)

        'Add the SaveSettings function - This is used to save web page settings between sessions.
        sb.Append("//Save the web page settings." & vbCrLf)
        sb.Append("function SaveSettings() {" & vbCrLf)
        sb.Append("  var xSettings = ""<Settings>"" + "" \n"" ; //String containing the web page settings in XML format." & vbCrLf)
        sb.Append("  //Add xml lines to save each setting." & vbCrLf & vbCrLf)
        sb.Append("  xSettings +=    ""</Settings>"" + ""\n"" ; //End of the Settings element." & vbCrLf)
        sb.Append(vbCrLf)
        sb.Append("  //Save the settings as an XML file in the project." & vbCrLf)
        sb.Append("  window.external.SaveHtmlSettings(xSettings) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Process a single XMsg instruction (Information:Location pair)
        sb.Append("//Process an XMessage instruction:" & vbCrLf)
        sb.Append("function XMsgInstruction(Info, Locn) {" & vbCrLf)
        sb.Append("  switch(Locn) {" & vbCrLf)
        sb.Append("  //Insert case statements here." & vbCrLf)
        sb.Append("  default:" & vbCrLf)
        sb.Append("    window.external.AddWarning(""Unknown location: "" + Locn + ""\r\n"") ;" & vbCrLf)
        sb.Append("  }" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        sb.Append("//END:   User modified JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf & vbCrLf)
        'END:   User modified JavaScript functions --------------------------------------------------------------------------

        'START: Required Document Library Web Page JavaScript functions ==========================================================================
        sb.Append("//START: Required Document Library Web Page JavaScript functions ==========================================================================" & vbCrLf & vbCrLf)

        'Add the AddText function - This sends a message to the message window using a named text type.
        sb.Append("//Add text to the Message window using a named txt type:" & vbCrLf)
        sb.Append("function AddText(Msg, TextType) {" & vbCrLf)
        sb.Append("  window.external.AddText(Msg, TextType) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the AddMessage function - This sends a message to the message window using default black text.
        sb.Append("//Add a message to the Message window using the default black text:" & vbCrLf)
        sb.Append("function AddMessage(Msg) {" & vbCrLf)
        sb.Append("  window.external.AddMessage(Msg) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the AddWarning function - This sends a red, bold warning message to the message window.
        sb.Append("//Add a warning message to the Message window using bold red text:" & vbCrLf)
        sb.Append("function AddWarning(Msg) {" & vbCrLf)
        sb.Append("  window.external.AddWarning(Msg) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the RestoreSettings function - This is used to restore web page settings.
        sb.Append("//Restore the web page settings." & vbCrLf)
        sb.Append("function RestoreSettings() {" & vbCrLf)
        sb.Append("  window.external.RestoreHtmlSettings() " & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'This line runs the RestoreSettings function when the web page is loaded.
        sb.Append("//Restore the web page settings when the page loads." & vbCrLf)
        sb.Append("window.onload = RestoreSettings; " & vbCrLf)
        sb.Append(vbCrLf)

        'Restores a single setting on the web page.
        sb.Append("//Restore a web page setting." & vbCrLf)
        sb.Append("  function RestoreSetting(FormName, ItemName, ItemValue) {" & vbCrLf)
        sb.Append("  document.forms[FormName][ItemName].value = ItemValue ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the RestoreOption function - This is used to add an option to a Select list.
        sb.Append("//Restore a Select control Option." & vbCrLf)
        sb.Append("function RestoreOption(SelectId, OptionText) {" & vbCrLf)
        sb.Append("  var x = document.getElementById(SelectId) ;" & vbCrLf)
        sb.Append("  var option = document.createElement(""Option"") ;" & vbCrLf)
        sb.Append("  option.text = OptionText ;" & vbCrLf)
        sb.Append("  x.add(option) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        sb.Append("//END:   Required Document Library Web Page JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf)
        'END:   Required Document Library Web Page JavaScript functions --------------------------------------------------------------------------

        sb.Append("</script>" & vbCrLf & vbCrLf)

        sb.Append("</body>" & vbCrLf & "</html>" & vbCrLf)

        Return sb.ToString

    End Function

#End Region 'Start Page Code ------------------------------------------------------------------------------------------------------------------------------------------------------------------



#Region " Methods Called by JavaScript - A collection of methods that can be called by JavaScript in a web page shown in WebBrowser1" '========================================================
    'These methods are used to display HTML pages in the Document tab.
    'The same methods can be found in the WebView form, which displays web pages on seprate forms.

    Public Sub JSMethodTest1()
        'Test method that is called from JavaScript.
        Message.Add("JSMethodTest1 called OK." & vbCrLf)
    End Sub

    Public Sub JSMethodTest2(ByVal Var1 As String, ByVal Var2 As String)
        'Test method that is called from JavaScript.
        Message.Add("Var1 = " & Var1 & " Var2 = " & Var2 & vbCrLf)
    End Sub

    Public Sub JSDisplayXml(ByRef XDoc As XDocument)
        Message.Add(XDoc.ToString & vbCrLf & vbCrLf)
    End Sub

    Public Sub ShowMessage(ByVal Msg As String)
        Message.Add(Msg)
    End Sub

    Public Sub SaveHtmlSettings(ByVal xSettings As String, ByVal FileName As String)
        'Save the Html settings for a web page.

        'Convert the XSettings to XML format:

        Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"

        Dim XDocSettings As New System.Xml.Linq.XDocument

        Try
            XDocSettings = System.Xml.Linq.XDocument.Parse(XmlHeader & vbCrLf & xSettings)
        Catch ex As Exception
            Message.AddWarning("Error saving HTML settings file. " & ex.Message & vbCrLf)
        End Try

        Project.SaveXmlData(FileName, XDocSettings)

    End Sub

    Public Sub RestoreHtmlSettings_Old(ByVal FileName As String)
        'Restore the Html settings for a web page.

        Dim XDocSettings As New System.Xml.Linq.XDocument
        Project.ReadXmlData(FileName, XDocSettings)

        If XDocSettings Is Nothing Then
            'Message.Add("No HTML Settings file : " & FileName & vbCrLf)
        Else
            Dim XSettings As New System.Xml.XmlDocument
            Try
                XSettings.LoadXml(XDocSettings.ToString)

                'Run the Settings file:
                XSeq.RunXSequence(XSettings, XStatus)
            Catch ex As Exception
                Message.AddWarning("Error restoring HTML settings. " & ex.Message & vbCrLf)
            End Try
        End If
    End Sub

    Public Sub RestoreHtmlSettings()
        'Restore the Html settings for a web page.

        Dim SettingsFileName As String = txtNodeKey.Text & "Settings"

        Dim XDocSettings As New System.Xml.Linq.XDocument
        Project.ReadXmlData(SettingsFileName, XDocSettings)

        If XDocSettings Is Nothing Then
            'Message.Add("No HTML Settings file : " & SettingsFileName & vbCrLf)
        Else
            Dim XSettings As New System.Xml.XmlDocument
            Try
                XSettings.LoadXml(XDocSettings.ToString)
                'Run the Settings file:
                XSeq.RunXSequence(XSettings, Status)
            Catch ex As Exception
                Message.AddWarning("Error restoring HTML settings. " & ex.Message & vbCrLf)
            End Try
        End If
    End Sub

    Private Sub XSeq_ErrorMsg(ErrMsg As String) Handles XSeq.ErrorMsg
        Message.AddWarning(ErrMsg & vbCrLf)
    End Sub


    Private Sub XSeq_Instruction(Info As String, Locn As String) Handles XSeq.Instruction
        'Execute each instruction produced by running the XSeq file.

        Select Case Locn
            Case "Settings:Form:Name"
                FormName = Info

            Case "Settings:Form:Item:Name"
                ItemName = Info

            Case "Settings:Form:Item:Value"
                RestoreSetting(FormName, ItemName, Info)

            Case "Settings:Form:SelectId"
                SelectId = Info

            Case "Settings:Form:OptionText"
                RestoreOption(SelectId, Info)

            'Start Project commands: ----------------------------------------------------
            Case "StartProject:AppName"
                StartProject_AppName = Info

            Case "StartProject:ConnectionName"
                StartProject_ConnName = Info

            Case "StartProject:ProjectID"
                StartProject_ProjID = Info

            Case "StartProject_ProjName"
                StartProject_ProjName = Info

            Case "StartProject:Command"
                Select Case Info
                    Case "Apply"
                        'StartApp_ProjectID(StartProject_AppName, StartProject_ProjID, StartProject_ConnName)
                        If StartProject_ProjName <> "" Then
                            StartApp_ProjectName(StartProject_AppName, StartProject_ProjName, StartProject_ConnName)
                        ElseIf StartProject_ProjID <> "" Then
                            StartApp_ProjectID(StartProject_AppName, StartProject_ProjID, StartProject_ConnName)
                        Else
                            Message.AddWarning("Project not specified. Project Name and Project ID are blank." & vbCrLf)
                        End If
                    Case Else
                        Message.AddWarning("Unknown Start Project command : " & Info & vbCrLf)
                End Select

            'END Start project commands ---------------------------------------------

            Case "Settings"

            Case "EndOfSequence"
                'Main.Message.Add("End of processing sequence" & Info & vbCrLf)
                'Clear the StartProject variables:
                StartProject_AppName = ""
                StartProject_ConnName = ""
                StartProject_ProjID = ""
                StartProject_ProjName = ""

            Case Else
                'Main.Message.AddWarning("Unknown location: " & Locn & "  Info: " & Info & vbCrLf)
                Message.AddWarning("Unknown location: " & Locn & "  Info: " & Info & vbCrLf)

        End Select
    End Sub


    Public Sub RestoreSetting(ByVal FormName As String, ByVal ItemName As String, ByVal ItemValue As String)
        'Restore the setting value with the specified Form Name and Item Name.

        Me.WebBrowser1.Document.InvokeScript("RestoreSetting", New String() {FormName, ItemName, ItemValue})

    End Sub

    Public Sub RestoreOption(ByVal SelectId As String, ByVal OptionText As String)
        'Restore the Option text in the Select control with the Id SelectId.

        Me.WebBrowser1.Document.InvokeScript("RestoreOption", New String() {SelectId, OptionText})
    End Sub

    Private Sub SaveWebPageSettings()
        'Call the SaveSettings JavaScript function:
        Try
            Me.WebBrowser1.Document.InvokeScript("SaveSettings")
        Catch ex As Exception
            Message.AddWarning("Web page settings not saved: " & ex.Message & vbCrLf)
        End Try

    End Sub

    Public Function GetFormNo() As String
        'Return FormNo.ToString
        Return "-1"
    End Function

    Public Sub AddText(ByVal Msg As String, ByVal TextType As String)
        Message.AddText(Msg, TextType)
    End Sub

    Public Sub AddMessage(ByVal Msg As String)
        Message.Add(Msg)
    End Sub

    Public Sub AddWarning(ByVal Msg As String)
        Message.AddWarning(Msg)
    End Sub


    Public Sub SendXMessage(ByVal ConnName As String, ByVal XMsg As String)
        'Send the XMessage to the application with the connection name ConnName.


    End Sub

    Public Sub RunXSequence(ByVal XSequence As String)
        'Run the XMSequence
        Dim XmlSeq As New System.Xml.XmlDocument
        XmlSeq.LoadXml(XSequence)
        XSeq.RunXSequence(XmlSeq, Status)

    End Sub


#End Region 'Methods Called by JavaScript -----------------------------------------------------------------------------------------------------------------------------------------------------



#Region "Run XMessage Statements"

    Private Sub XMsg_ErrorMsg(ErrMsg As String) Handles XMsg.ErrorMsg
        'Process the error message:
        Message.Add("XMsg Error message: " & ErrMsg & vbCrLf)
    End Sub

    Private Sub XMsg_Instruction(Info As String, Locn As String) Handles XMsg.Instruction
        'Process each Property Path and Property Value instruction.

        'These flags must be declared at the start of the forms code, to save the state between subroutine calls.

        Select Case Locn

                'Start an Application ---------------------------------------------------------------------------------------------------------------
            Case "StartApplication:Name"
                StartAppName = Info
            Case "StartApplication:ConnectionName"
                StartAppConnName = Info
            Case "StartApplication:ProjectName"
                'StartAppProject = Info
                StartAppProjectName = Info
            Case "StartApplication:ProjectID"
                StartAppProjectID = Info
            Case "StartApplication:ProjectPath"
                StartAppProjectPath = Info
            Case "StartApplication:Command"
                Select Case Info
                    Case "Apply"
                        'StartApp(StartAppName, StartAppProject, StartAppConnName)
                        'StartApp(StartAppName, StartAppProjectName, StartAppConnName)
                        If StartAppProjectName <> "" Then
                            StartApp_ProjectName(StartAppName, StartAppProjectName, StartAppConnName)
                        ElseIf StartAppProjectID <> "" Then
                            StartApp_ProjectID(StartAppName, StartAppProjectID, StartAppConnName)
                        ElseIf StartAppProjectPath <> "" Then
                            StartApp_ProjectPath(StartAppName, StartAppProjectPath, StartAppConnName)
                        Else

                        End If

                End Select

           'Get AppList in Add Application form ======================================
            Case "ApplicationList:Application:Name"
                If IsNothing(AddApplication) Then
                    'AddApplication form is not open
                Else
                    AddApplication.dgvApplications.Rows.Add()
                    AddApplication.dgvApplications.Rows(AddApplication.dgvApplications.RowCount - 1).Cells(0).Value = Info
                    If AppInfo.ContainsKey(Info) Then
                        AddApplication.dgvApplications.Rows(AddApplication.dgvApplications.RowCount - 1).DefaultCellStyle.ForeColor = Color.Gray
                    End If

                End If
            Case "ApplicationList:Application:Description"
                If IsNothing(AddApplication) Then
                    'AddApplication form is not open
                Else
                    AddApplication.dgvApplications.Rows(AddApplication.dgvApplications.RowCount - 1).Cells(1).Value = Info
                    'AddApplication.AppInfo(NewAppName).Description = Info
                End If

            Case "ApplicationList:Application:Directory"
                If IsNothing(AddApplication) Then
                    'AddApplication form is not open
                Else
                    AddApplication.dgvApplications.Rows(AddApplication.dgvApplications.RowCount - 1).Cells(2).Value = Info
                    'AddApplication.AppInfo(NewAppName).Directory = Info
                End If

            Case "ApplicationList:Application:ExecutablePath"
                If IsNothing(AddApplication) Then
                    'AddApplication form is not open
                Else
                    AddApplication.dgvApplications.Rows(AddApplication.dgvApplications.RowCount - 1).Cells(3).Value = Info
                    'AddApplication.AppInfo(NewAppName).ExecutablePath = Info
                End If

            '--------------------------------------------------------------------------


            'Application Information returned from client.GetApplicationInfo method ======================================
            Case "ApplicationInfo:Name"
                AppName = Info

            Case "ApplicationInfo:Description"
                If AppName = "" Then
                    'Error getting application information from the Message Service.
                ElseIf AppInfo.ContainsKey(AppName) Then
                    AppInfo(AppName).Description = Info
                Else
                    Message.AddWarning("An application named " & AppName & " was not found in the list. The application parameters were not updated." & vbCrLf)
                End If

            Case "ApplicationInfo:Directory"
                If AppName = "" Then
                    'Error getting application information from the Message Service.
                ElseIf AppInfo.ContainsKey(AppName) Then
                    AppInfo(AppName).Directory = Info
                End If

            Case "ApplicationInfo:ExecutablePath"
                If AppName = "" Then
                    'Error getting application information from the Message Service.
                ElseIf AppInfo.ContainsKey(AppName) Then
                    AppInfo(AppName).ExecutablePath = Info
                End If

            Case "ApplicationInfo:Status"
                Message.Add(Info & vbCrLf) 'Show the status message.

           '--------------------------------------------------------------------------

           'Startup Command Arguments ================================================
            Case "AppNetName"
                'This is currently not used.
                'The AppNetName is determined elsewhere.

            Case "ProjectName"
                If Project.OpenProject(Info) = True Then
                    ProjectSelected = True 'Project has been opened OK.
                Else
                    ProjectSelected = False 'Project could not be opened.
                End If

            Case "ProjectID"
                Message.AddWarning("Add code to handle ProjectID parameter at StartUp!" & vbCrLf)
                'Note the ComNet will usually select a project using ProjectPath.

            Case "ProjectPath"
                If Project.OpenProjectPath(Info) = True Then
                    ProjectSelected = True 'Project has been opened OK.
                Else
                    ProjectSelected = False 'Project could not be opened.
                End If

            Case "ConnectionName"
                StartupConnectionName = Info
            '--------------------------------------------------------------------------

            'Application Information  =================================================
            'returned by client.GetMessageServiceAppInfoAsync()
            Case "MessageServiceAppInfo:Name"
                'The name of the Message Service Application. (Not used.)

            Case "MessageServiceAppInfo:ExePath"
                'The executable file path of the Message Service Application.
                MsgServiceExePath = Info

            Case "MessageServiceAppInfo:Path"
                'The path of the Message Service Application (ComNet). (This is where an Application.Lock file will be found while ComNet is running.)
                MsgServiceAppPath = Info
            '---------------------------------------------------------------------------

            Case "EndOfSequence"
                If AddNewApp = True Then
                    'Add the new application node to the tree:
                    trvAppTree.TopNode.Nodes.Add(AppName, AppText, AppInfo(AppName).IconNumber, AppInfo(AppName).OpenIconNumber)
                End If
                AddNewConnection = False
                AddNewApplication = False
                AddNewApp = False
                AppName = ""
                StartAppName = ""
                StartAppConnName = ""
                StartAppProjectName = ""
                StartAppProjectID = ""
                StartAppProjectPath = ""

            Case Else
                Message.Add("Instruction not recognised:  " & Locn & "    Property:  " & Info & vbCrLf)

        End Select

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

        If IsNothing(client) Then
            Message.AddWarning("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.AddWarning("client state is faulted. Message not sent!" & vbCrLf)
            Else
                Try
                    'Message.Add("Sending a message. Number of characters: " & MessageText.Length & vbCrLf)
                    client.SendMessage(ClientAppNetName, ClientConnName, MessageText)
                    'Message.XAdd(MessageText & vbCrLf) 'NOTE this is displayed in Property InstrReceived
                    MessageText = "" 'Clear the message after it has been sent.
                    ClientAppName = "" 'Clear the Client Application Name after the message has been sent.
                    ClientConnName = "" 'Clear the Client Application Name after the message has been sent.
                    xlocns.Clear()
                Catch ex As Exception
                    Message.AddWarning("Error sending message: " & ex.Message & vbCrLf)
                End Try
            End If
        End If

        'Stop timer:
        Timer1.Enabled = False
    End Sub


    Private Sub Message_ErrorMessage(Message As String) Handles Message.ErrorMessage
        'MessageBox.Show(Message, "Error")
    End Sub

    Private Sub Message_Message(Message As String) Handles Message.Message
        'MessageBox.Show(Message, "Message")
    End Sub

    Private Sub ApplicationInfo_UpdateExePath() Handles ApplicationInfo.UpdateExePath
        'Update the Executable Path.
        ApplicationInfo.ExecutablePath = Application.ExecutablePath
    End Sub

    Private Sub btnStartProject_Click(sender As Object, e As EventArgs) Handles btnStartProject.Click
        'Start the Project corresponding to the selected node.
        StartProject()

    End Sub

    Private Sub StartProject()
        'Start the Project corresponding to the selected node.

        Dim NodeName As String = trvProjTree.SelectedNode.Name
        Dim ProjectPath As String = txtPTProjPath.Text
        Dim ProjectId As String = txtPTProjID.Text
        Dim AppName As String = txtPTProjAppName.Text
        Dim ConnName As String = AppName

        'Check is the Application has an Exe Path:
        If AppInfo(AppName).ExecutablePath = "" Then
            'Update the executable path:

        ElseIf System.IO.File.Exists(AppInfo(AppName).ExecutablePath) Then
            'Executable file found.
        Else
            'Update the executable path:
            If IsNothing(client) Then
                Message.AddWarning("The executable path for the application " & AppName & " is not valid." & vbCrLf)
                Message.AddWarning("Connect to the Message Service and try to start the application again. " & vbCrLf)
                Message.AddWarning("The Message Service will provide updated application information if avaialable. " & vbCrLf)
                Exit Sub
            Else
                client.GetApplicationInfoAsync(txtAppName.Text) 'Request the application info from ComNet.
                If AppInfo(AppName).ExecutablePath = "" Then
                    Message.AddWarning("The executable path for the application " & AppName & " is not valid." & vbCrLf)
                    Exit Sub
                ElseIf System.IO.File.Exists(AppInfo(AppName).ExecutablePath) Then
                    Message.Add("The executable path for the application " & AppName & " was updated." & vbCrLf)
                Else
                    Message.AddWarning("The executable path for the application " & AppName & " is not valid." & vbCrLf)
                    Exit Sub
                End If
            End If

        End If

        'Check if the Project is locked:
        If Project.LockedAtPath(ProjectPath) Then
            Message.AddWarning("The project is locked." & vbCrLf)
            Message.AddWarning("If the project is not in use, remove the Project.Lock file form the project at: " & vbCrLf & ProjectPath & vbCrLf & vbCrLf)
        Else
            'StartApp_ProjectPath(AppName, ProjectPath, ConnName)
            If chkConnect1.Checked Then 'Connect the project to ComNet when it is started.
                If Not ConnectedToComNet Then
                    ConnectToComNet()
                End If

                StartApp_ProjectID(AppName, ProjectId, ConnName)
            Else 'Do not connect the project to ComNet when it is started.
                StartApp_ProjectID(AppName, ProjectId, "")
            End If
        End If
    End Sub

    Private Sub btnMovePTNodeUp_Click(sender As Object, e As EventArgs) Handles btnMovePTNodeUp.Click
        'Move the selected item up in the Project Tree.

        If trvProjTree.SelectedNode Is Nothing Then
            'No node has been selected.
        Else
            Dim Node As TreeNode
            Node = trvProjTree.SelectedNode
            Dim index As Integer = Node.Index
            If index = 0 Then
                'Already at the first node.
                Node.TreeView.Focus()
            ElseIf Node.Parent Is Nothing Then
                'Message.AddWarning("Selected node has no parent!" & vbCrLf)
                'Use trvProjTree as the Parent:
                trvProjTree.Nodes.RemoveAt(index)
                trvProjTree.Nodes.Insert(index - 1, Node)
                trvProjTree.SelectedNode = Node
                Node.TreeView.Focus()
            Else
                Dim Parent As TreeNode = Node.Parent
                Parent.Nodes.RemoveAt(index)
                Parent.Nodes.Insert(index - 1, Node)
                trvProjTree.SelectedNode = Node
                Node.TreeView.Focus()
            End If
        End If

    End Sub

    Private Sub btnMovePTNodeDown_Click(sender As Object, e As EventArgs) Handles btnMovePTNodeDown.Click
        'Move the selected item down in the Project Tree.

        If trvProjTree.SelectedNode Is Nothing Then
            'No node has been selected.
        Else
            Dim Node As TreeNode
            Node = trvProjTree.SelectedNode
            If Node.Parent Is Nothing Then
                'Message.AddWarning("Selected node has no parent!" & vbCrLf)
                'Use trvProjTree as the Parent:
                Dim index As Integer = Node.Index
                If index < trvProjTree.Nodes.Count - 1 Then
                    trvProjTree.Nodes.RemoveAt(index)
                    trvProjTree.Nodes.Insert(index + 1, Node)
                    trvProjTree.SelectedNode = Node
                    Node.TreeView.Focus()
                Else
                    'Already at the last node.
                    Node.TreeView.Focus()
                End If
            Else
                Dim index As Integer = Node.Index
                Dim Parent As TreeNode = Node.Parent
                If index < Parent.Nodes.Count - 1 Then
                    Parent.Nodes.RemoveAt(index)
                    Parent.Nodes.Insert(index + 1, Node)
                    trvProjTree.SelectedNode = Node
                    Node.TreeView.Focus()
                Else
                    'Already at the last node.
                    Node.TreeView.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Project_Closing() Handles Project.Closing
        'Close the current project:
        SaveFormSettings() 'Save the form settings
        SaveProjectSettings() 'Save the project settings.
        Project.Usage.SaveUsageInfo() 'Save the current project usage information.

    End Sub

    Private Sub Project_Selected() Handles Project.Selected
        'A new project has been selected.

        Project.ReadProjectInfoFile()

        Project.ReadParameters()
        If Project.ParameterExists("AppNetName") Then
            AppNetName = Project.Parameter("AppNetName").Value
        Else
            Project.AddParameter("AppNetName", Project.Name, "Application Network Name (= Project.Name).")
            AppNetName = Project.Parameter("AppNetName").Value
        End If

        Message.Add("4" & vbCrLf) 'DEBUGGING
        Project.LockProject() 'Lock the project while it is open in this application.
        'Set the project start time. This is used to track project usage.
        Project.Usage.StartTime = Now
        ApplicationInfo.SettingsLocn = Project.SettingsLocn
        'Set up the Message object:
        Message.SettingsLocn = Project.SettingsLocn

        InitialiseForm()

        RestoreFormSettings()

        RestoreProjectSettings() 'Restore the project settings.

        ShowProjectInfo()

    End Sub

    Private Sub cmbHPSettingsType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHPSettingsType.SelectedIndexChanged
        If cmbHPSettingsType.SelectedItem.ToString = "Archive" Then
            Label74.Text = ".zip"
        Else '
            Label74.Text = ""
        End If
    End Sub

    Private Sub cmbHPDataType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHPDataType.SelectedIndexChanged
        If cmbHPDataType.SelectedItem.ToString = "Archive" Then
            Label73.Text = ".zip"
        Else '
            Label73.Text = ""
        End If
    End Sub

    Private Sub cmbHPSystemType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHPSystemType.SelectedIndexChanged
        If cmbHPSystemType.SelectedItem.ToString = "Archive" Then
            Label75.Text = ".zip"
        Else '
            Label75.Text = ""
        End If
    End Sub

    Private Sub btnCreateHybridProject_Click(sender As Object, e As EventArgs) Handles btnCreateHybridProject.Click
        'Create a new Child Hybrid Project.

        If trvProjTree.SelectedNode Is Nothing Then
            'No node selected as parent.
            Message.AddWarning("No node has been selected as the Parent project." & vbCrLf)
        ElseIf txtPTProjType.Text = "Archive" Then
            Message.AddWarning("An Archive project cannot be the Parent project." & vbCrLf)
        ElseIf cmbNewChildProjectApplication.SelectedIndex = -1 Then
            Message.AddWarning("The new project application has not been selected." & vbCrLf)
        ElseIf cmbNewChildProjectType.SelectedIndex = -1 Then
            Message.AddWarning("The new project type has not been selected." & vbCrLf)
        ElseIf txtNewChildProjectName.Text = "" Then
            Message.AddWarning("The new project name has not been specified." & vbCrLf)
        ElseIf txtHPDirectoryName.Text = "" Then
            Message.AddWarning("The new hybrid project directory name has not been specified." & vbCrLf)
        Else
            'OK to create child project:
            Dim NewProject As New ADVL_Utilities_Library_1.Project
            Dim DirectoryPath As String = txtPTProjPath.Text 'This is the Parent Project directory. The new Child Project will be created in this directory.
            If System.IO.Directory.Exists(DirectoryPath) Then
                'ProjectPath exists.
            Else
                Message.AddWarning("The new project cannot be created. The Parent Project directory does not exist: " & DirectoryPath & vbCrLf)
                Exit Sub
            End If
            Dim NewProjectDirectoryname As String = txtHPDirectoryName.Text
            Dim NewProjectDirectoryPath As String = DirectoryPath & "\" & NewProjectDirectoryname

            'Check if the NewProjectDirectoryPath already exists:
            If System.IO.Directory.Exists(NewProjectDirectoryPath) Then
                Message.AddWarning("The new project cannot be created. The specified new project directory already exists: " & NewProjectDirectoryPath & vbCrLf)
                Exit Sub
            Else
                System.IO.Directory.CreateDirectory(NewProjectDirectoryPath) 'The new project directory has been created.
            End If

            NewProject.Type = Project.Types.Hybrid
            NewProject.Path = NewProjectDirectoryPath
            NewProject.RelativePath = txtHybridProjectRelativePath.Text
            NewProject.Name = txtNewChildProjectName.Text
            NewProject.Description = txtNewChildProjectDescription.Text
            NewProject.CreationDate = Format(Now, "d-MMM-yyyy H:mm:ss")

            Dim IDString As String = NewProject.Name & " " & Format(NewProject.CreationDate, "d-MMM-yyyy H:mm:ss")
            NewProject.ID = IDString.GetHashCode

            'Set up the Settings Location:
            If Trim(txtHPSettingsName.Text) = "" Then
                txtHPSettingsName.Text = "Settings"
            End If
            If cmbHPSettingsType.SelectedItem.ToString = "Directory" Then
                'Set up the Settings relative location:
                NewProject.SettingsRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
                NewProject.SettingsRelLocn.Path = "\" & Trim(txtHPSettingsName.Text)
                'Set up the Settings location:
                NewProject.SettingsLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
                NewProject.SettingsLocn.Path = NewProjectDirectoryPath & NewProject.SettingsRelLocn.Path
                'Create the Settings Directory:
                System.IO.Directory.CreateDirectory(NewProject.SettingsLocn.Path)
            ElseIf cmbHPSettingsType.SelectedItem.ToString = "Archive" Then
                'Set up the Settings relative location:
                NewProject.SettingsRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive
                NewProject.SettingsRelLocn.Path = "\" & Trim(txtHPSettingsName.Text) & ".zip"
                'Set up the Settings location:
                NewProject.SettingsLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive
                NewProject.SettingsLocn.Path = NewProjectDirectoryPath & NewProject.SettingsRelLocn.Path
                'Create the Settings Archive:
                Dim Zip As New ADVL_Utilities_Library_1.ZipComp
                Zip.NewArchivePath = NewProject.SettingsLocn.Path
                Zip.CreateArchive() 'The new project file has been created.
            Else 'Unknown settings location type.
                Message.AddWarning("Unknown settings location type: " & cmbHPSettingsType.SelectedItem.ToString & vbCrLf)
                Message.AddWarning("A settings directory location will be created." & vbCrLf)
                'Set up the Settings relative location:
                NewProject.SettingsRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
                NewProject.SettingsRelLocn.Path = "\" & Trim(txtHPSettingsName.Text)
                'Set up the Settings location:
                NewProject.SettingsLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
                NewProject.SettingsLocn.Path = NewProjectDirectoryPath & NewProject.SettingsRelLocn.Path
                'Create the Settings Directory:
                System.IO.Directory.CreateDirectory(NewProject.SettingsLocn.Path)
            End If

            'Set up the Data Location:
            If Trim(txtHPDataName.Text) = "" Then
                txtHPDataName.Text = "Data"
            End If
            If cmbHPDataType.SelectedItem.ToString = "Directory" Then
                'Set up the Data relative location:
                NewProject.DataRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
                NewProject.DataRelLocn.Path = "\" & Trim(txtHPDataName.Text)
                'Set up the Data location:
                NewProject.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
                NewProject.DataLocn.Path = NewProjectDirectoryPath & NewProject.DataRelLocn.Path
                'Create the Data Directory:
                System.IO.Directory.CreateDirectory(NewProject.DataLocn.Path)
            ElseIf cmbHPDataType.SelectedItem.ToString = "Archive" Then
                'Set up the Data relative location:
                NewProject.DataRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive
                NewProject.DataRelLocn.Path = "\" & Trim(txtHPDataName.Text) & ".zip"
                'Set up the Data location:
                NewProject.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive
                NewProject.DataLocn.Path = NewProjectDirectoryPath & NewProject.DataRelLocn.Path
                'Create the Data Archive:
                Dim Zip As New ADVL_Utilities_Library_1.ZipComp
                Zip.NewArchivePath = NewProject.DataLocn.Path
                Zip.CreateArchive() 'The new project file has been created.
            Else 'Unknown Data location type.
                Message.AddWarning("Unknown settings location type: " & cmbHPDataType.SelectedItem.ToString & vbCrLf)
                Message.AddWarning("A settings directory location will be created." & vbCrLf)
                'Set up the Data relative location:
                NewProject.DataRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
                NewProject.DataRelLocn.Path = "\" & Trim(txtHPDataName.Text)
                'Set up the Data location:
                NewProject.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
                NewProject.DataLocn.Path = NewProjectDirectoryPath & NewProject.DataRelLocn.Path
                'Create the Data Directory:
                System.IO.Directory.CreateDirectory(NewProject.DataLocn.Path)
            End If

            'Set up the System Location:
            If Trim(txtHPSystemName.Text) = "" Then
                txtHPSystemName.Text = "System"
            End If
            If cmbHPSystemType.SelectedItem.ToString = "Directory" Then
                'Set up the System relative location:
                NewProject.SystemRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
                NewProject.SystemRelLocn.Path = "\" & Trim(txtHPSystemName.Text)
                'Set up the System location:
                NewProject.SystemLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
                NewProject.SystemLocn.Path = NewProjectDirectoryPath & NewProject.SystemRelLocn.Path
                'Create the System Directory:
                System.IO.Directory.CreateDirectory(NewProject.SystemLocn.Path)
            ElseIf cmbHPSystemType.SelectedItem.ToString = "Archive" Then
                'Set up the System relative location:
                NewProject.SystemRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive
                NewProject.SystemRelLocn.Path = "\" & Trim(txtHPSystemName.Text) & ".zip"
                'Set up the System location:
                NewProject.SystemLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive
                NewProject.SystemLocn.Path = NewProjectDirectoryPath & NewProject.SystemRelLocn.Path
                'Create the System Archive:
                Dim Zip As New ADVL_Utilities_Library_1.ZipComp
                Zip.NewArchivePath = NewProject.SystemLocn.Path
                Zip.CreateArchive() 'The new project file has been created.
            Else 'Unknown System location type.
                Message.AddWarning("Unknown settings location type: " & cmbHPSystemType.SelectedItem.ToString & vbCrLf)
                Message.AddWarning("A settings directory location will be created." & vbCrLf)
                'Set up the System relative location:
                NewProject.SystemRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
                NewProject.SystemRelLocn.Path = "\" & Trim(txtHPSystemName.Text)
                'Set up the System location:
                NewProject.SystemLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
                NewProject.SystemLocn.Path = NewProjectDirectoryPath & NewProject.SystemRelLocn.Path
                'Create the System Directory:
                System.IO.Directory.CreateDirectory(NewProject.SystemLocn.Path)
            End If

            NewProject.Author.Name = txtAuthorName.Text
            NewProject.Author.Description = txtAuthorDescription.Text
            NewProject.Author.Contact = txtAuthorContact.Text

            NewProject.ParentProjectName = txtPTProjName.Text
            NewProject.ParentProjectID = txtPTProjID.Text
            NewProject.ParentProjectPath = txtPTProjPath.Text
            NewProject.ParentProjectCreationDate = txtPTProjCreationDate.Text

            NewProject.Usage.FirstUsed = NewProject.CreationDate
            NewProject.Usage.LastUsed = Format(Now, "d-MMM-yyyy H:mm:ss")

            NewProject.ApplicationName = cmbNewChildProjectApplication.SelectedItem.ToString 'Same as NewProject.Application.Name (?)

            'Get the Application Information
            If AppInfo.ContainsKey(NewProject.ApplicationName) Then
                Dim NewProjectAppInfo As New ADVL_Utilities_Library_1.ApplicationInfo
                NewProject.ApplicationDir = AppInfo(NewProject.ApplicationName).Directory
                NewProjectAppInfo.ApplicationDir = NewProject.ApplicationDir
                NewProjectAppInfo.ReadFile() 'Read the Application Information file.
                NewProject.Application.Name = NewProjectAppInfo.Name
                NewProject.Application.Description = NewProjectAppInfo.Description
                NewProject.Application.CreationDate = NewProjectAppInfo.CreationDate
                NewProject.Application.Version.Major = NewProjectAppInfo.Version.Major
                NewProject.Application.Version.Minor = NewProjectAppInfo.Version.Minor
                NewProject.Application.Version.Build = NewProjectAppInfo.Version.Build
                NewProject.Application.Version.Revision = NewProjectAppInfo.Version.Revision
                NewProject.Application.Author.Name = NewProjectAppInfo.Author.Name
                NewProject.Application.Author.Description = NewProjectAppInfo.Author.Description
                NewProject.Application.Author.Contact = NewProjectAppInfo.Author.Contact

                NewProject.SaveProjectInfoFile() 'Save the Project Information file.

                'Add the New Child Project to the Project Tree:
                'AppName: NewProject.ApplicationName
                'ProjectType: Directory
                'ProjectText: NewProject.Name (txtNewChildProjectName.Text)
                'ProjectKey: NewProject.ID
                Dim IconNumber As Integer = ProjTreeImageNumber(NewProject.ApplicationName, "Hybrid", False)
                Dim OpenIconNumber As Integer = ProjTreeImageNumber(NewProject.ApplicationName, "Hybrid", True)
                'If ProjTreeInfo.ContainsKey(NewProject.ID) Then
                If NewProject.ID = "" Then
                    Message.AddWarning("The New Child Project ID is blank." & vbCrLf)
                ElseIf ProjTreeInfo.ContainsKey(NewProject.ID) Then
                    Message.AddWarning("The New Child Project is already in the Project Tree." & vbCrLf)
                Else
                    'OK to add the new child tree to the TreeView:
                    trvProjTree.SelectedNode.Nodes.Add(NewProject.ID, NewProject.Name, IconNumber, OpenIconNumber)
                    ProjTreeInfo.Add(NewProject.ID, New clsProjInfo)
                    ProjTreeInfo(NewProject.ID).Name = NewProject.Name
                    ProjTreeInfo(NewProject.ID).CreationDate = NewProject.CreationDate
                    ProjTreeInfo(NewProject.ID).Description = NewProject.Description
                    ProjTreeInfo(NewProject.ID).Type = ADVL_Utilities_Library_1.Project.Types.Hybrid
                    ProjTreeInfo(NewProject.ID).Path = NewProject.Path
                    ProjTreeInfo(NewProject.ID).RelativePath = NewProject.RelativePath
                    ProjTreeInfo(NewProject.ID).ID = NewProject.ID
                    ProjTreeInfo(NewProject.ID).ApplicationName = NewProject.ApplicationName
                    ProjTreeInfo(NewProject.ID).ParentProjectName = txtPTProjName.Text
                    ProjTreeInfo(NewProject.ID).ParentProjectID = txtPTProjID.Text
                    ProjTreeInfo(NewProject.ID).ParentProjectPath = NewProject.ParentProjectPath
                    ProjTreeInfo(NewProject.ID).IconNumber = IconNumber
                    ProjTreeInfo(NewProject.ID).OpenIconNumber = OpenIconNumber
                End If
            Else
                Message.AddWarning("The child project application was not found in the list: " & NewProject.ApplicationName & vbCrLf)
            End If
        End If
    End Sub

    Private Sub btnCreateArchiveProject_Click(sender As Object, e As EventArgs) Handles btnCreateArchiveProject.Click
        'Create a new Child Archive Project.

        If trvProjTree.SelectedNode Is Nothing Then
            'No node selected as parent.
            Message.AddWarning("No node has been selected as the Parent project." & vbCrLf)
        ElseIf txtPTProjType.Text = "Archive" Then
            Message.AddWarning("An Archive project cannot be the Parent project." & vbCrLf)
        ElseIf cmbNewChildProjectApplication.SelectedIndex = -1 Then
            Message.AddWarning("The new project application has not been selected." & vbCrLf)
        ElseIf cmbNewChildProjectType.SelectedIndex = -1 Then
            Message.AddWarning("The new project type has not been selected." & vbCrLf)
        ElseIf txtNewChildProjectName.Text = "" Then
            Message.AddWarning("The new project name has not been specified." & vbCrLf)
            'ElseIf txtProjectDirectoryName.Text = "" Then
        ElseIf txtProjectArchiveName.Text = "" Then
            Message.AddWarning("The new project archive name has not been specified." & vbCrLf)
        Else
            'OK to create child project:
            Dim NewProject As New ADVL_Utilities_Library_1.Project
            Dim DirectoryPath As String = txtPTProjPath.Text 'This is the Parent Project directory. The new Child Project will be created in this directory.
            If System.IO.Directory.Exists(DirectoryPath) Then
                'ProjectPath exists.
            Else
                Message.AddWarning("The new project cannot be created. The Parent Project directory does not exist: " & DirectoryPath & vbCrLf)
                Exit Sub
            End If
            'Dim NewProjectDirectoryname As String = txtProjectDirectoryName.Text
            Dim NewProjectArchiveName As String = txtProjectArchiveName.Text & ".AdvlProject"
            'Dim NewProjectDirectoryPath As String = DirectoryPath & "\" & NewProjectDirectoryname
            Dim NewProjectArchivePath As String = DirectoryPath & "\" & NewProjectArchiveName

            'Check if the New Project Archive file already exists:
            If System.IO.File.Exists(NewProjectArchivePath) Then
                Message.AddWarning("The new project cannot be created. The specified new project archive file already exists: " & NewProjectArchivePath & vbCrLf)
                Exit Sub
            Else
                Dim Zip As New ADVL_Utilities_Library_1.ZipComp
                Zip.NewArchivePath = NewProjectArchivePath
                Zip.CreateArchive() 'The new project file has been created.
            End If

            NewProject.Type = ADVL_Utilities_Library_1.Project.Types.Archive
            NewProject.Path = NewProjectArchivePath
            NewProject.RelativePath = txtProjectArchiveRelativePath.Text
            NewProject.Name = txtNewChildProjectName.Text
            NewProject.Description = txtNewChildProjectDescription.Text
            NewProject.CreationDate = Format(Now, "d-MMM-yyyy H:mm:ss")

            Dim IDString As String = NewProject.Name & " " & Format(NewProject.CreationDate, "d-MMM-yyyy H:mm:ss")
            NewProject.ID = IDString.GetHashCode

            'All relative locations point to the Project Archive:
            NewProject.SettingsRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive
            NewProject.SettingsRelLocn.Path = ""
            NewProject.DataRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive
            NewProject.DataRelLocn.Path = ""
            NewProject.SystemRelLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive
            NewProject.SystemRelLocn.Path = ""

            'All locations are the same as the Project Archive:
            NewProject.SettingsLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive
            NewProject.SettingsLocn.Path = NewProjectArchivePath
            NewProject.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive
            NewProject.DataLocn.Path = NewProjectArchivePath
            NewProject.SystemLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive
            NewProject.SystemLocn.Path = NewProjectArchivePath

            NewProject.Author.Name = txtAuthorName.Text
            NewProject.Author.Description = txtAuthorDescription.Text
            NewProject.Author.Contact = txtAuthorContact.Text

            NewProject.ParentProjectName = txtPTProjName.Text
            NewProject.ParentProjectID = txtPTProjID.Text
            NewProject.ParentProjectPath = txtPTProjPath.Text
            NewProject.ParentProjectCreationDate = txtPTProjCreationDate.Text

            NewProject.Usage.FirstUsed = NewProject.CreationDate
            NewProject.Usage.LastUsed = Format(Now, "d-MMM-yyyy H:mm:ss")

            NewProject.ApplicationName = cmbNewChildProjectApplication.SelectedItem.ToString 'Same as NewProject.Application.Name (?)

            'Get the Application Information
            If AppInfo.ContainsKey(NewProject.ApplicationName) Then
                Dim NewProjectAppInfo As New ADVL_Utilities_Library_1.ApplicationInfo
                NewProject.ApplicationDir = AppInfo(NewProject.ApplicationName).Directory
                NewProjectAppInfo.ApplicationDir = NewProject.ApplicationDir
                NewProjectAppInfo.ReadFile() 'Read the Application Information file.
                NewProject.Application.Name = NewProjectAppInfo.Name
                NewProject.Application.Description = NewProjectAppInfo.Description
                NewProject.Application.CreationDate = NewProjectAppInfo.CreationDate
                NewProject.Application.Version.Major = NewProjectAppInfo.Version.Major
                NewProject.Application.Version.Minor = NewProjectAppInfo.Version.Minor
                NewProject.Application.Version.Build = NewProjectAppInfo.Version.Build
                NewProject.Application.Version.Revision = NewProjectAppInfo.Version.Revision
                NewProject.Application.Author.Name = NewProjectAppInfo.Author.Name
                NewProject.Application.Author.Description = NewProjectAppInfo.Author.Description
                NewProject.Application.Author.Contact = NewProjectAppInfo.Author.Contact

                NewProject.SaveProjectInfoFile() 'Save the Project Information file.

                'Add the New Child Project to the Project Tree:
                'AppName: NewProject.ApplicationName
                'ProjectType: Archive
                'ProjectText: NewProject.Name (txtNewChildProjectName.Text)
                'ProjectKey: NewProject.ID
                Dim IconNumber As Integer = ProjTreeImageNumber(NewProject.ApplicationName, "Archive", False)
                Dim OpenIconNumber As Integer = ProjTreeImageNumber(NewProject.ApplicationName, "Archive", True)
                If NewProject.ID = "" Then
                    Message.AddWarning("The New Child Project ID is blank." & vbCrLf)
                ElseIf ProjTreeInfo.ContainsKey(NewProject.ID) Then
                    Message.AddWarning("The New Child Project is already in the Project Tree." & vbCrLf)
                Else
                    'OK to add the new child tree to the TreeView:
                    trvProjTree.SelectedNode.Nodes.Add(NewProject.ID, NewProject.Name, IconNumber, OpenIconNumber)
                    ProjTreeInfo.Add(NewProject.ID, New clsProjInfo)
                    ProjTreeInfo(NewProject.ID).Name = NewProject.Name
                    ProjTreeInfo(NewProject.ID).CreationDate = NewProject.CreationDate
                    ProjTreeInfo(NewProject.ID).Description = NewProject.Description
                    ProjTreeInfo(NewProject.ID).Type = ADVL_Utilities_Library_1.Project.Types.Archive
                    ProjTreeInfo(NewProject.ID).Path = NewProject.Path
                    ProjTreeInfo(NewProject.ID).RelativePath = NewProject.RelativePath
                    ProjTreeInfo(NewProject.ID).ID = NewProject.ID
                    ProjTreeInfo(NewProject.ID).ApplicationName = NewProject.ApplicationName
                    ProjTreeInfo(NewProject.ID).ParentProjectName = txtPTProjName.Text
                    ProjTreeInfo(NewProject.ID).ParentProjectID = txtPTProjID.Text
                    ProjTreeInfo(NewProject.ID).ParentProjectPath = NewProject.ParentProjectPath
                    ProjTreeInfo(NewProject.ID).IconNumber = IconNumber
                    ProjTreeInfo(NewProject.ID).OpenIconNumber = OpenIconNumber
                End If
            Else
                Message.AddWarning("The child project application was not found in the list: " & NewProject.ApplicationName & vbCrLf)
            End If
        End If
    End Sub

    Private Sub txtProjectDirectoryName_TextChanged(sender As Object, e As EventArgs) Handles txtProjectDirectoryName.TextChanged
        'The Project Directory Name has changed.
        txtProjectDirectoryRelativePath.Text = "\" & txtProjectDirectoryName.Text
    End Sub

    Private Sub txtProjectArchiveName_TextChanged(sender As Object, e As EventArgs) Handles txtProjectArchiveName.TextChanged
        'The Project Archive Name has changed.
        txtProjectArchiveRelativePath.Text = "\" & txtProjectArchiveName.Text & ".AdvlProject"
    End Sub

    Private Sub txtHPDirectoryName_TextChanged(sender As Object, e As EventArgs) Handles txtHPDirectoryName.TextChanged
        'The Hybrid Project Directory Name has changed.
        txtHybridProjectRelativePath.Text = "\" & txtHPDirectoryName.Text
    End Sub

    Private Sub trvProjTree_DoubleClick(sender As Object, e As EventArgs) Handles trvProjTree.DoubleClick
        'The Project Tree View has been double-clicked.
        'Start the project corresponding to the selected node:
        StartProject()
    End Sub

    Private Sub btnFindNode_Click(sender As Object, e As EventArgs) Handles btnFindNode.Click
        'Find the node with the ID shown in txtFindNodeProjID

        Dim tn() As TreeNode
        tn = trvProjTree.Nodes.Find(txtFindNodeProjID.Text, True)

        If tn.Length > 0 Then
            trvProjTree.SelectedNode = tn(0)
        End If

    End Sub

    Private Sub ToolStripMenuItem1_OpenProject_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1_OpenProject.Click
        StartProject()
    End Sub


#End Region 'Send XMessages

    Private Sub btnOnline_Click(sender As Object, e As EventArgs) Handles btnOnline.Click
        'Connect to or disconnect from the Communication Network (Message Service).
        If ConnectedToComNet = False Then
            ConnectToComNet()
        Else
            DisconnectFromComNet()
        End If
    End Sub


    Private Sub ConnectToComNet()
        'Connect to the Communication Network. (Message Service)

        If IsNothing(client) Then
            client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
        End If

        If ComNetRunning() Then
            'The Message Service is Running.
        Else  'The Message Service is NOT Running.
            'Start the Message Service:
            If System.IO.File.Exists(MsgServiceExePath) Then 'OK to start the Message Service application:
                Shell(Chr(34) & MsgServiceExePath & Chr(34), AppWinStyle.NormalFocus) 'Start Message Service application with no argument
            Else
                'Incorrect Message Service Executable path.
            End If
        End If

        If client.State = ServiceModel.CommunicationState.Faulted Then
            Message.AddWarning("Client state is faulted. Connection not made!" & vbCrLf)
        Else
            Try

                'Check if AppNetName is already being used in the Message Service:
                If client.AppNetNameUsed(AppNetName) Then
                    Message.AddWarning("The Application Network Name: " & AppNetName & " is already used in the Message Service." & vbCrLf)
                    Message.AddWarning("This name can be changed in the Project Information tab." & vbCrLf & vbCrLf)
                    Exit Sub
                Else
                    Message.Add("Connecting to the Message Service with the Application Network name: " & AppNetName & vbCrLf)
                End If

                'client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 8) 'Temporarily set the send timeaout to 8 seconds (NOTE: THIS SOMETIMES TIMES-OUT ON A SLOW COMPUTER!)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 16) 'Temporarily set the send timeaout to 16 seconds

                ConnectionName = ApplicationInfo.Name 'This name will be modified if it is already used in an existing connection.
                ConnectionName = client.Connect(AppNetName, ApplicationInfo.Name, ConnectionName, Project.Name, Project.Description, Project.Type, Project.Path, False, False) 'UPDATED 2Feb19

                If ConnectionName <> "" Then
                    Message.Add("Connected to the Message Service with Connection Name: " & ConnectionName & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                    btnOnline.Text = "Online"
                    btnOnline.ForeColor = Color.ForestGreen
                    ConnectedToComNet = True
                    SendApplicationInfo()

                    client.GetMessageServiceAppInfoAsync() 'Update the Exe Path in case it has changed. This path may be needed in the future to start the ComNet (Message Service).
                Else
                    Message.Add("Connection to the Communication Network failed!" & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                End If
            Catch ex As System.TimeoutException
                Message.Add("Timeout error. Check if the Communication Network is running." & vbCrLf)
            Catch ex As Exception
                Message.Add("Error message: " & ex.Message & vbCrLf)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
            End Try
        End If
    End Sub

    Private Sub ConnectToComNet(ByVal ConnName As String)
        'Connect to the Application Network with the connection name ConnName.

        If ConnectedToComNet = False Then
            Dim Result As Boolean

            If IsNothing(client) Then
                client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
            End If

            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.AddWarning("client state is faulted. Connection not made!" & vbCrLf)
            Else
                Try
                    'client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 8) 'Temporarily set the send timeaout to 8 seconds
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 16) 'Temporarily set the send timeaout to 16 seconds
                    ConnectionName = ConnName 'This name will be modified if it is already used in an existing connection.
                    ConnectionName = client.Connect(AppNetName, ApplicationInfo.Name, ConnectionName, Project.Name, Project.Description, Project.Type, Project.Path, False, False) 'UPDATED 2Feb19

                    If ConnectionName <> "" Then
                        Message.Add("Connected to the Communication Network as " & ConnectionName & vbCrLf)
                        client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                        btnOnline.Text = "Online"
                        btnOnline.ForeColor = Color.ForestGreen
                        ConnectedToComNet = True
                        SendApplicationInfo()
                    Else
                        Message.Add("Connection to the Communication Network failed!" & vbCrLf)
                        client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                    End If
                Catch ex As System.TimeoutException
                    Message.Add("Timeout error. Check if the Communication Network is running." & vbCrLf)
                Catch ex As Exception
                    Message.Add("Error message: " & ex.Message & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                End Try
            End If
        Else
            Message.AddWarning("Already connected to the Communication Network." & vbCrLf)
        End If

    End Sub

    Private Sub SendApplicationInfo()
        'Send the application information to the Administrator connections.

        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("Client state is faulted. Message not sent!" & vbCrLf)
            Else
                'Create the XML instructions to send application information.
                Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                Dim applicationInfo As New XElement("ApplicationInfo")
                Dim name As New XElement("Name", Me.ApplicationInfo.Name)
                applicationInfo.Add(name)

                Dim text As New XElement("Text", "Application Network")
                applicationInfo.Add(text)

                Dim exePath As New XElement("ExecutablePath", Me.ApplicationInfo.ExecutablePath)
                applicationInfo.Add(exePath)

                Dim directory As New XElement("Directory", Me.ApplicationInfo.ApplicationDir)
                applicationInfo.Add(directory)
                Dim description As New XElement("Description", Me.ApplicationInfo.Description)
                applicationInfo.Add(description)
                xmessage.Add(applicationInfo)
                doc.Add(xmessage)

                'Show the message sent to ComNet:
                Message.XAddText("Message sent to " & "MessageService" & ":" & vbCrLf, "XmlSentNotice")
                Message.XAddXml(doc.ToString)
                Message.XAddText(vbCrLf, "Normal") 'Add extra line

                client.SendMessage("", "MessageService", doc.ToString)
            End If
        End If

    End Sub

    Private Sub DisconnectFromComNet()
        'Disconnect from the Communication Network.

        If IsNothing(client) Then
            'Message.Add("Already disconnected from the Application Network." & vbCrLf)
            Message.Add("Already disconnected from the Communication Network." & vbCrLf)
            btnOnline.Text = "Offline"
            btnOnline.ForeColor = Color.Red
            ConnectedToComNet = False
            ConnectionName = ""
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted." & vbCrLf)
                ConnectionName = ""
            Else
                Try
                    If client.Disconnect(AppNetName, ConnectionName) Then
                        Message.Add("Disconnected OK." & vbCrLf)
                    Else
                        Message.AddWarning("Disconnection error!" & vbCrLf)
                    End If

                    btnOnline.Text = "Offline"
                    btnOnline.ForeColor = Color.Red
                    ConnectedToComNet = False
                    ConnectionName = ""
                    Message.Add("Disconnected from the Communication Network." & vbCrLf)
                Catch ex As Exception
                    Message.AddWarning("Error disconnecting from Communication Network: " & ex.Message & vbCrLf)
                End Try
            End If
        End If
    End Sub

    Private Sub btnGetConnectionList_Click(sender As Object, e As EventArgs) Handles btnGetConnectionList.Click
        'Get the connection list from Message Service.

        If IsNothing(client) Then
            Message.AddWarning("No client connection available!" & vbCrLf)
        Else
            Try
                'client.GetConnectionList() 'THIS TIMES OUT!!!
                client.GetConnectionListAsync()

            Catch ex As Exception
                Message.AddWarning("Error getting connection list: " & ex.Message & vbCrLf)
            End Try

        End If

        Exit Sub

    End Sub

    Private Sub btnGetAppList_Click(sender As Object, e As EventArgs) Handles btnGetAppList.Click
        'Get the application list from Message Service.
        If IsNothing(client) Then
            Message.AddWarning("No client connection available!" & vbCrLf)
        Else
            Try
                client.GetApplicationListAsync()

            Catch ex As Exception
                Message.AddWarning("Error getting the application list: " & ex.Message & vbCrLf)
            End Try
        End If
    End Sub

    Private Sub btnGetComNetAppInfo_Click(sender As Object, e As EventArgs) Handles btnGetComNetAppInfo.Click
        'Get the Message Service application information.
        If IsNothing(client) Then
            Message.AddWarning("No client connection available!" & vbCrLf)
        Else
            Try
                client.GetMessageServiceAppInfoAsync()
            Catch ex As Exception
                Message.AddWarning("Error getting the application list: " & ex.Message & vbCrLf)
            End Try
        End If
    End Sub

    Private Sub btnSetUpComNetClient_Click(sender As Object, e As EventArgs) Handles btnSetUpComNetClient.Click
        If IsNothing(client) Then
            Message.Add("ComNet client is Nothing - setting up client..." & vbCrLf)
            client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))

            Message.Add("client.State.ToString: " & client.State.ToString & vbCrLf)

        Else
            Message.Add("ComNet client is already set up." & vbCrLf)
        End If

    End Sub

    Private Sub btnCheckComNet_Click(sender As Object, e As EventArgs) Handles btnCheckComNet.Click

        If ComNetRunning() Then
            Message.Add("ComNet is running" & vbCrLf)
        Else
            Message.Add("ComNet is NOT running" & vbCrLf)
        End If

        Exit Sub
        'NEW VERSION.
        'This just checks if there is an Application.Lock file at the ComNet application path.
        'This will indicate ComNet is running unless ComNet has stopped running without removing the lock file.

        If System.IO.File.Exists(MsgServiceAppPath & "\Application.Lock") Then
            Message.Add("ComNet is running" & vbCrLf)
        Else
            Message.Add("ComNet is NOT running" & vbCrLf)
        End If

        Exit Sub

        'This is the old version.
        'Too slow as it must wait a while to confirm that the endpoint is not listening!

        Dim NewClient As New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
        Dim NewConnectionName As String = "Test"
        Try
            NewClient.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 4) 'Set the send timeaout to 1 second
            ConnectionName = client.Connect(AppNetName, "Test1", NewConnectionName, "Test", "Test", ADVL_Utilities_Library_1.Project.Types.Directory, "Test", False, False) 'UPDATED 2Feb19

            If NewClient.IsAlive Then
                Message.Add("ComNet is running" & vbCrLf)
            Else
                Message.Add("ComNet is NOT running" & vbCrLf)
            End If

            Message.Add("Closing ComNet" & vbCrLf)
            NewClient.Disconnect(AppNetName, NewConnectionName)
            NewClient.Close()

        Catch ex As Exception
            Message.Add("ComNet is NOT running" & vbCrLf & ex.Message & vbCrLf)
            NewClient = Nothing
        End Try

        If NewClient Is Nothing Then
            Message.Add("NewClient is Nothing" & vbCrLf)
        End If

    End Sub

    Private Function ComNetRunning() As Boolean
        'Return True if ComNet (Message Service) is running.
        If System.IO.File.Exists(MsgServiceAppPath & "\Application.Lock") Then
            Return True
        Else
            Return False
        End If
    End Function


    'Public Function NewWebPage() As Integer
    Public Function OpenNewWebPage() As Integer
        'Open a new HTML Web View window, or reuse an existing one if avaiable.
        'The new forms index number in WebViewFormList is returned.

        NewWebPage = New frmWebPage
        If WebPageFormList.Count = 0 Then
            WebPageFormList.Add(NewWebPage)
            WebPageFormList(0).FormNo = 0
            WebPageFormList(0).Show
            Return 0 'The new HTML Display is at position 0 in WebViewFormList()
        Else
            Dim I As Integer
            Dim FormAdded As Boolean = False
            For I = 0 To WebPageFormList.Count - 1 'Check if there are closed forms in WebViewFormList. They can be re-used.
                If IsNothing(WebPageFormList(I)) Then
                    WebPageFormList(I) = NewWebPage
                    WebPageFormList(I).FormNo = I
                    WebPageFormList(I).Show
                    FormAdded = True
                    Return I 'The new Html Display is at position I in WebViewFormList()
                    Exit For
                End If
            Next
            If FormAdded = False Then 'Add a new form to WebViewFormList
                Dim FormNo As Integer
                WebPageFormList.Add(NewWebPage)
                FormNo = WebPageFormList.Count - 1
                WebPageFormList(FormNo).FormNo = FormNo
                WebPageFormList(FormNo).Show
                Return FormNo 'The new WebPage is at position FormNo in WebPageFormList()
            End If

        End If
    End Function

    Public Sub WebPageFormClosed()
        'This subroutine is called when the Web Page form has been closed.
        'The subroutine is usually called from the FormClosed event of the WebPage form.
        'The WebPage form may have multiple instances.
        'The ClosedFormNumber property should contains the number of the instance of the WebPage form.
        'This property should be updated by the WebPage form when it is being closed.
        'The ClosedFormNumber property value is used to determine which element in WebPageList should be set to Nothing.

        If WebPageFormList.Count < ClosedFormNo + 1 Then
            'ClosedFormNo is too large to exist in WebPageFormList
            Exit Sub
        End If

        If IsNothing(WebPageFormList(ClosedFormNo)) Then
            'The form is already set to nothing
        Else
            WebPageFormList(ClosedFormNo) = Nothing
        End If
    End Sub

    Public Function OpenNewHtmlDisplayPage() As Integer
        'Open a new HTML display window, or reuse an existing one if avaiable.
        'The new forms index number in HtmlDisplayFormList is returned.

        NewHtmlDisplay = New frmHtmlDisplay
        If HtmlDisplayFormList.Count = 0 Then
            HtmlDisplayFormList.Add(NewHtmlDisplay)
            HtmlDisplayFormList(0).FormNo = 0
            HtmlDisplayFormList(0).Show
            Return 0 'The new HTML Display is at position 0 in HtmlDisplayFormList()
        Else
            Dim I As Integer
            Dim FormAdded As Boolean = False
            For I = 0 To HtmlDisplayFormList.Count - 1 'Check if there are closed forms in HtmlDisplayFormList. They can be re-used.
                If IsNothing(HtmlDisplayFormList(I)) Then
                    HtmlDisplayFormList(I) = NewHtmlDisplay
                    HtmlDisplayFormList(I).FormNo = I
                    HtmlDisplayFormList(I).Show
                    FormAdded = True
                    Return I 'The new Html Display is at position I in HtmlDisplayFormList()
                    Exit For
                End If
            Next
            If FormAdded = False Then 'Add a new form to HtmlDisplayFormList
                Dim FormNo As Integer
                HtmlDisplayFormList.Add(NewHtmlDisplay)
                FormNo = HtmlDisplayFormList.Count - 1
                HtmlDisplayFormList(FormNo).FormNo = FormNo
                HtmlDisplayFormList(FormNo).Show
                Return FormNo 'The new HtmlDisplay is at position FormNo in HtmlDisplayFormList()
            End If

        End If

    End Function

    Private Sub btnGetAppInfo_Click(sender As Object, e As EventArgs) Handles btnGetAppInfo.Click
        'Get information about the application with the name in txtAppName

        If IsNothing(client) Then
            Message.AddWarning("No client connection available!" & vbCrLf)
        Else
            client.GetApplicationInfoAsync(txtAppName.Text) 'Request the application info from ComNet.
        End If

    End Sub

    Private Sub btnUpdateAppNetName_Click(sender As Object, e As EventArgs) Handles btnUpdateAppNetName.Click
        'Update the Application Network name.
        'Apply the updates to the Child projects.

    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        'Keet the connection awake with each tick:

        If ConnectedToComNet = True Then
            Try
                If client.IsAlive() Then
                    Message.Add(Format(Now, "HH:mm:ss") & " Connection OK." & vbCrLf)
                    Timer4.Interval = TimeSpan.FromMinutes(55).TotalMilliseconds '55 minute interval
                Else
                    Message.Add(Format(Now, "HH:mm:ss") & " Connection Fault." & vbCrLf)
                    Timer4.Interval = TimeSpan.FromMinutes(55).TotalMilliseconds '55 minute interval
                End If
            Catch ex As Exception
                Message.AddWarning(ex.Message & vbCrLf)
                'Set interval to five minutes - try again in five minutes:
                Timer4.Interval = TimeSpan.FromMinutes(5).TotalMilliseconds '5 minute interval
            End Try
        Else
            Message.Add(Format(Now, "HH:mm:ss") & " Not connected." & vbCrLf)
        End If

    End Sub


    Private Sub chkConnect_LostFocus(sender As Object, e As EventArgs) Handles chkConnect.LostFocus
        If chkConnect.Checked Then
            Project.ConnectOnOpen = True
        Else
            Project.ConnectOnOpen = False
        End If
        Project.SaveProjectInfoFile()

    End Sub


#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Events - Events that can be triggered by this form." '--------------------------------------------------------------------------------------------------------------------------
#End Region 'Form Events ----------------------------------------------------------------------------------------------------------------------------------------------------------------------


End Class 'Main

'Public Class Application 
'The Application class was renamed the App class.
'    If a class is named Application, existing Application.Exit() code must be changed to System.Windows.Forms.Application.Exit()

Public Class App
    'Class holds a list of applications.
    'This is used by the App and ProjectApp objects that contain a list of all apps and project apps.

    Public List As New List(Of AppSummary) 'A list of applications

#Region "Application Methods" '--------------------------------------------------------------------------------------

    'Public Function FindName(ByVal AppName As String) As ApplicationInfo
    Public Function FindName(ByVal AppName As String) As AppSummary
        'Return the AppSummary corresponding to the Application with name AppName
        Dim FoundName As AppSummary

        FoundName = List.Find(Function(item As AppSummary)
                                  If IsNothing(item) Then
                                      '
                                  Else
                                      Return item.Name = AppName
                                  End If
                              End Function)
        If IsNothing(FoundName) Then
            'Return New ApplicationInfo 'Return blank record.
            Return New AppSummary 'Return blank record.
        Else
            Return FoundName
        End If
    End Function

#End Region 'Application Methods ------------------------------------------------------------------------------------

End Class 'App

'Public Class ApplicationInfo
Public Class AppSummary
    'Class holds summary information about an Application.
    'This is used by the App class and displayed in the Application List tab.

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


End Class 'AppSummary

Public Class clsAppInfo
    'Information about each Application in the AppTreeView.
    'This is stored in the AppInfo dictionary.

    'Note: The Name is the key for the AppInfo dictionary. It does not need to be repeated in this class.
    'Note: The Text label is not stored in the ProjInfo dictionary. It is displayed in the AppTreeView.     'Text            The text label shown in the AppTreeView.

    'Description     A description of the application.
    'ExecutablePath  The path to the applications executable file.
    'Directory       The application directory.
    'IconNumber      The AppTreeImageList index number of the application's icon.
    'OpenIconNumber  The AppTreeImageList index number of the application's icon for an open application.

    Private _description As String = "" 'A description of the application.
    Property Description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Private _executablePath As String = "" 'The path to the applications executable file.
    Property ExecutablePath As String
        Get
            Return _executablePath
        End Get
        Set(value As String)
            _executablePath = value
        End Set
    End Property

    Private _directory As String = "" 'The application directory.
    Property Directory As String
        Get
            Return _directory
        End Get
        Set(value As String)
            _directory = value
        End Set
    End Property

    Private _iconNumber As Integer = 0 'The AppTreeImageList index number of the application's icon.
    Property IconNumber As Integer
        Get
            Return _iconNumber
        End Get
        Set(value As Integer)
            _iconNumber = value
        End Set
    End Property

    Private _openIconNumber As Integer = 0 'The AppTreeImageList index number of the application's open icon.
    Property OpenIconNumber As Integer
        Get
            Return _openIconNumber
        End Get
        Set(value As Integer)
            _openIconNumber = value
        End Set
    End Property

End Class

Public Class clsProjInfo
    'Information about each Project in the AppTreeView.
    'This is stored in the ProjectInfo dictionary.
    'The dictionary key is the ID and ".Proj"

    'Name               The name of the project. (The name may be duplicated in other projects.)
    'CreationDate
    'Description        A description of the project.
    'Type               The type of project (Directory, Archive, Hybrid or None.) (If the type is None, the Default project will be used.)
    'Path               The path of the project directory or archive.
    'RelativePath       The path of the project directory or archive relative to the Parent Project.
    'ID                 The project ID. this is the hashcode generated from the string ProjectName & " " & CreationDate.
    'ApplicationName    The name of the application that uses the project.
    'ParentProjectName  If the project is contained within another project (the Parent), this is the name of the parent project.
    'ParentProjectID    If the project is contained within another project (the Parent), this is the ID of the parent project.
    'ParentProjectPath  The path of the parent project.
    'IconNumber         The AppTreeImageList index number of the project's icon.
    'OpenIconNumber     The AppTreeImageList index number of the project's icon for an open project.


    Private _name As String = "" 'The Name of the project.
    Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Private _creationDate As DateTime = "1-Jan-2000 12:00:00" 'The project creation date.
    Property CreationDate As DateTime
        Get
            Return _creationDate
        End Get
        Set(value As DateTime)
            _creationDate = value
        End Set
    End Property

    Private _description As String = "" 'A description of the project.
    Property Description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Private _type As ADVL_Utilities_Library_1.Project.Types = ADVL_Utilities_Library_1.Project.Types.Directory 'The type of location (None, Directory, Archive, Hybrid).
    Property Type As ADVL_Utilities_Library_1.Project.Types
        Get
            Return _type
        End Get
        Set(value As ADVL_Utilities_Library_1.Project.Types)
            _type = value
        End Set
    End Property

    Private _path As String = "" 'The path to the Project directory or archive.
    Property Path As String
        Get
            Return _path
        End Get
        Set(value As String)
            _path = value
        End Set
    End Property

    Private _relativePath As String = "" 'The path relative to the Parent Project. (eg \Import for a directory or \Import.AdvlProject for an archive)
    Property RelativePath As String
        Get
            Return _relativePath
        End Get
        Set(value As String)
            _relativePath = value
        End Set
    End Property

    Private _iD As String = "" 'The ID code of the project. This is the hashcode generated from the ProjectName and CreationDate.
    Property ID As String
        Get
            Return _iD
        End Get
        Set(value As String)
            _iD = value
        End Set
    End Property

    Private _applicationName As String = "" 'The name of the application that created the project.
    Property ApplicationName As String
        Get
            Return _applicationName
        End Get
        Set(value As String)
            _applicationName = value
        End Set
    End Property

    Private _parentProjectName As String = "" 'The Name of the Parent Project.
    Property ParentProjectName As String
        Get
            Return _parentProjectName
        End Get
        Set(value As String)
            _parentProjectName = value
        End Set
    End Property

    Private _parentProjectID As String = "" 'The ID code of the Parent Project. This is the hashcode generated from the ParentProjectName and CreationDate.
    Property ParentProjectID As String
        Get
            Return _parentProjectID
        End Get
        Set(value As String)
            _parentProjectID = value
        End Set
    End Property

    Private _parentProjectPath As String = "" 'The path to the Parent Project directory (or archive?).
    Property ParentProjectPath As String
        Get
            Return _parentProjectPath
        End Get
        Set(value As String)
            _parentProjectPath = value
        End Set
    End Property

    Private _iconNumber As Integer = 0 'The AppTreeImageList index number of the project's icon.
    Property IconNumber As Integer
        Get
            Return _iconNumber
        End Get
        Set(value As Integer)
            _iconNumber = value
        End Set
    End Property

    Private _openIconNumber As Integer = 0 'The AppTreeImageList index number of the project's open icon.
    Property OpenIconNumber As Integer
        Get
            Return _openIconNumber
        End Get
        Set(value As Integer)
            _openIconNumber = value
        End Set
    End Property

End Class

Public Class Proj
    'Class holds a list of projects.
    'This is used by the Proj object that contain a list of all projects.

    Public List As New List(Of ProjSummary) 'A list of projects

#Region "Application Methods" '--------------------------------------------------------------------------------------

    Public Function FindID(ByVal ProjID As String) As ProjSummary
        'Return the ProjSummary corresponding to the Project with ID ProjID

        Dim FoundID As ProjSummary

        FoundID = List.Find(Function(item As ProjSummary)
                                If IsNothing(item) Then
                                    '
                                Else
                                    Return item.ID = ProjID
                                End If
                            End Function)
        If IsNothing(FoundID) Then
            Return New ProjSummary 'Return blank record.
        Else
            Return FoundID
        End If
    End Function

#End Region 'Application Methods ------------------------------------------------------------------------------------

End Class 'Proj

Public Class ProjSummary
    'Class holds summary information about a project.
    'This is used by the Proj class and displayed in the Project List tab.

    Private _name As String = "" 'The name of the project.
    Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Private _iD As String = "" 'The project ID.
    Property ID As String
        Get
            Return _iD
        End Get
        Set(value As String)
            _iD = value
        End Set
    End Property

    Private _type As ADVL_Utilities_Library_1.Project.Types = ADVL_Utilities_Library_1.Project.Types.Directory 'The type of location (None, Directory, Archive, Hybrid).
    Property Type As ADVL_Utilities_Library_1.Project.Types
        Get
            Return _type
        End Get
        Set(value As ADVL_Utilities_Library_1.Project.Types)
            _type = value
        End Set
    End Property

    Private _path As String = "" 'The path to the Project directory or archive.
    Property Path As String
        Get
            Return _path
        End Get
        Set(value As String)
            _path = value
        End Set
    End Property

    Private _description As String = "" 'A description of the project.
    Property Description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Private _applicationName As String = "" 'The name of the application that created the project.
    Property ApplicationName As String
        Get
            Return _applicationName
        End Get
        Set(value As String)
            _applicationName = value
        End Set
    End Property

    Private _parentProjectName As String = "" 'The Name of the Parent Project.
    Property ParentProjectName As String
        Get
            Return _parentProjectName
        End Get
        Set(value As String)
            _parentProjectName = value
        End Set
    End Property

    Private _parentProjectID As String = "" 'The parent project ID.
    Property ParentProjectID As String
        Get
            Return _parentProjectID
        End Get
        Set(value As String)
            _parentProjectID = value
        End Set
    End Property

End Class
