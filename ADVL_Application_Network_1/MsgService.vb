
Imports System.ServiceModel

'<ServiceBehavior(ConcurrencyMode:=ConcurrencyMode.Reentrant, UseSynchronizationContext:=False)> _
'<CallbackBehavior(ConcurrencyMode:=ConcurrencyMode.Reentrant, UseSynchronizationContext:=False)> _
<CallbackBehavior(ConcurrencyMode:=ConcurrencyMode.Multiple, UseSynchronizationContext:=False)> _
Public Class MsgService
    Implements IMsgService

    Private Shared ReadOnly connections As New List(Of clsConnection)()
    'connections is a list of connection information.
    'Each item contains the application name and the callback used to send a message to the application, a GetAllWarningsflag and a GetAllMessages flag.

    'Private Shared ReadOnly adminConnections As New List(Of clsConnection)()
    'adminConnections is a list of Admin Connection information.
    'Each item contains the application name, the callback used to send a message to the application, a GetWarnings flag and a GetAllMessages flag.

    'The Main Node is an application associated with this message service. It has a user interface that displays a list of connected applications.
    'Private _mainNodeName As String = ""
    Private Shared _mainNodeName As String = ""
    Property MainNodeName As String
        Get
            Return _mainNodeName
        End Get
        Set(value As String)
            _mainNodeName = value
        End Set
    End Property

    'The Main Node callback - used to send a message to the Main Node application.
    'Private _mainNodeCallback As IMsgServiceCallback
    Private Shared _mainNodeCallback As IMsgServiceCallback
    Property MainNodeCallback As IMsgServiceCallback
        Get
            Return _mainNodeCallback
        End Get
        Set(value As IMsgServiceCallback)
            _mainNodeCallback = value
        End Set
    End Property

    Public Function Connect(ByVal appName As String, ByVal appType As clsConnection.AppTypes, ByVal getAllWarnings As Boolean, ByVal getAllMessages As Boolean) As Boolean Implements IMsgService.Connect
        'The Connect function adds a connection to the connections list.
        Try
            Dim callback As IMsgServiceCallback = OperationContext.Current.GetCallbackChannel(Of IMsgServiceCallback)()
            'Dim Connection As New clsConnection(appName, callback)
            Dim Connection As New clsConnection(appName, appType, callback, getAllWarnings, getAllMessages)

            'Dim Connected As Boolean = False 'True if connection is made.

            'If connections.Count = 0 Then
            '    connections.Add(Connection)
            '    If Connection.AppType = clsConnection.AppTypes.MainNode Then
            '        Debug.Print("Connection.AppName = " & Connection.AppName & vbCrLf)
            '        MainNodeName = Connection.AppName
            '        Debug.Print("MainNodeName property = " & MainNodeName & vbCrLf)
            '        MainNodeCallback = Connection.Callback
            '    End If
            '    'Connected = True
            '    'Return True
            '    Connect = True
            'Else
            'Check if appName is already on the connections list:
            Dim conn As clsConnection
            conn = connections.Find(Function(item As clsConnection)
                                        If IsNothing(item) Then
                                            'An error is raised if an item of nothing is used in the Return code.
                                        Else
                                            Return item.AppName = appName
                                        End If
                                    End Function)
            If IsNothing(conn) Then 'appName is not already on the list
                connections.Add(Connection)

                If Connection.AppType = clsConnection.AppTypes.MainNode Then
                    MainNodeName = Connection.AppName
                    MainNodeCallback = Connection.Callback
                    'NOTE: Program freezes if an attempt is made to send a message to the Main Node before the Main Note form has been displayed.
                    'Connection information is not sent for the Main Node connection.
                Else
                    'OLD CODE: Used for application version using a separate WCF service. ------------------------------------------
                    'Send Connection information to the Main Node connection:
                    'Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    'Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    'Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    'Dim newConnectionInfo As New XElement("NewConnectionInfo")
                    'Dim applicationName As New XElement("ApplicationName", appName)
                    'newConnectionInfo.Add(applicationName)
                    'Dim appTypeString As String = ""
                    'Select Case appType
                    '    Case clsConnection.AppTypes.Application
                    '        appTypeString = "Application"
                    '    Case clsConnection.AppTypes.MainNode
                    '        appTypeString = "Main Node"
                    '    Case clsConnection.AppTypes.Node
                    '        appTypeString = "Node"
                    'End Select
                    'Dim connectionType As New XElement("ConnectionType", appTypeString)
                    'newConnectionInfo.Add(connectionType)
                    'Dim TrueFalseString As String = False
                    'Select Case getAllWarnings
                    '    Case True
                    '        TrueFalseString = "True"
                    '    Case False
                    '        TrueFalseString = "False"
                    'End Select
                    'Dim connectionGetAllWarnings As New XElement("GetAllWarnings", TrueFalseString)
                    'newConnectionInfo.Add(connectionGetAllWarnings)
                    'Select Case getAllMessages
                    '    Case True
                    '        TrueFalseString = "True"
                    '    Case False
                    '        TrueFalseString = "False"
                    'End Select
                    'Dim connectionGetAllMessages As New XElement("GetAllMessages", TrueFalseString)
                    'newConnectionInfo.Add(connectionGetAllMessages)
                    'Dim callbackHashCode As New XElement("CallbackHashcode", callback.GetHashCode)
                    'newConnectionInfo.Add(callbackHashCode)
                    'Dim connectionStartTime As New XElement("ConnectionStartTime", Format(Now, "d-MMM-yyyy H:mm:ss"))
                    'newConnectionInfo.Add(connectionStartTime)
                    'xmessage.Add(newConnectionInfo)
                    'doc.Add(xmessage)
                    ''Send the XMessage to the Main Node connection:
                    'SendMessage("ApplicationNetwork", doc.ToString)
                    'SendMessage("ApplicationNetwork", "Debugging info: The value of the property MainNodeName is:" & MainNodeName & ": " & vbCrLf)

                    'NEW CODE: Uses self hosted WCF service. --------------------------------------------------------------------------
                    'Add the new connection information to the data grid:
                    If Main.ConnectionAppNameAvailable(appName) Then
                        Main.dgvConnections.Rows.Add()
                        Dim CurrentRow As Integer = Main.dgvConnections.Rows.Count - 2
                        Main.dgvConnections.Rows(CurrentRow).Cells(0).Value = appName 'New connection App Name
                        Select Case appType
                            Case clsConnection.AppTypes.Application
                                Main.dgvConnections.Rows(CurrentRow).Cells(1).Value = "Application" 'New connection App Type
                            Case clsConnection.AppTypes.MainNode
                                Main.dgvConnections.Rows(CurrentRow).Cells(1).Value = "Main Node" 'New connection App Type
                            Case clsConnection.AppTypes.Node
                                Main.dgvConnections.Rows(CurrentRow).Cells(1).Value = "Node" 'New connection App Type
                        End Select
                        'Main.dgvConnections.Rows(CurrentRow).Cells(1).Value = appTypeString 'New connection App Type
                        'Main.dgvConnections.Rows(CurrentRow).Cells(2).Value = appTypeString 'New connection App Type
                        Select Case getAllWarnings
                            Case True
                                Main.dgvConnections.Rows(CurrentRow).Cells(2).Value = "True" 'New connection GetAllWarnings is True
                            Case False
                                Main.dgvConnections.Rows(CurrentRow).Cells(2).Value = "False" 'New connection GetAllWarnings is False
                        End Select
                        Select Case getAllMessages
                            Case True
                                Main.dgvConnections.Rows(CurrentRow).Cells(3).Value = "True" 'New connection GetAllMessages is True
                            Case False
                                Main.dgvConnections.Rows(CurrentRow).Cells(3).Value = "False" 'New connection GetAllMessages is False
                        End Select
                        Main.dgvConnections.Rows(CurrentRow).Cells(4).Value = callback.GetHashCode 'New connection Callback hash code
                        Main.dgvConnections.Rows(CurrentRow).Cells(5).Value = Format(Now, "d-MMM-yyyy H:mm:ss") 'New connection start time
                    Else
                        'Connection App Name not available.

                    End If

                End If
                'Connected = True
                'Return True
                Connect = True
            Else
                'appName is already on the list.
                SendMainNodeMessage("WARNING: Connection failed because " & appName & " is already on the connections list." & vbCrLf)
                Return False
            End If
            'End If
        Catch ex As Exception
            'SendWarning("WARNING: Connection failed: " & ex.Message & vbCrLf)
            SendMainNodeMessage("WARNING: Connection failed: " & ex.Message & vbCrLf)
            Return False

        End Try
    End Function

    'Public Function AdminConnect(ByVal appName As String, ByVal getWarnings As Boolean, ByVal getAllMessages As Boolean) As Boolean Implements IMsgService.AdminConnect
    '    'The AdminConnect function adds an administration connection to the adminConnections list.
    '    'Admin connections can receive all warnings and all messages.
    '    'The getWarnings and getAllMessages flags are used to indicate which messagese are sent.

    '    Try
    '        Dim callback As IMsgServiceCallback = OperationContext.Current.GetCallbackChannel(Of IMsgServiceCallback)()
    '        Dim AdminConnection As New clsConnection(appName, callback, getWarnings, getAllMessages)
    '        If adminConnections.Count = 0 Then
    '            adminConnections.Add(AdminConnection)
    '            Return True
    '        Else
    '            'Check if appName is already on the adminConnections list:
    '            Dim conn As clsConnection
    '            conn = adminConnections.Find(Function(item As clsConnection)
    '                                             If IsNothing(item) Then
    '                                                 'An error is raised if an item of nothing is used in the Return code.
    '                                             Else
    '                                                 Return item.AppName = appName
    '                                             End If
    '                                         End Function)
    '            If IsNothing(conn) Then 'appName is not already on the list.
    '                'adminConnections.Add(conn)
    '                adminConnections.Add(AdminConnection)
    '                Return True
    '            Else
    '                'appName is already on the list.
    '                Return False
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Return False
    '    End Try


    'End Function

    Public Sub SendMessage(ByVal appName As String, ByVal message As String) Implements IMsgService.SendMessage
        'Send the message to the application with the connection name appName.

        'Find the connection for the application corresponding to appName:
        Dim conn As clsConnection
        conn = connections.Find(Function(item As clsConnection)
                                    If IsNothing(item) Then
                                        'An error is raised if an item of nothing is used in the Return code.
                                    Else
                                        Return item.AppName = appName
                                    End If
                                End Function)
        If IsNothing(conn) Then
            'The connection is not on the list!

            If appName = "ApplicationNetwork" Then
                Main.InstrReceived = message
            Else
                'SendWarning("Connection name: " & appName & " not found." & vbCrLf)
                'SendMainNodeMessage("Connection name: " & appName & " not found." & vbCrLf)
                Main.Message.Add("Connection name: " & appName & " not found." & vbCrLf)
            End If
        Else
            If DirectCast(conn.Callback, ICommunicationObject).State = CommunicationState.Opened Then
                'conn.Callback.OnSendMessage(message)

                'Send a message showing the callers callback:
                Dim callback As IMsgServiceCallback = OperationContext.Current.GetCallbackChannel(Of IMsgServiceCallback)()
                'conn.Callback.OnSendMessage("The message was sent from: " & callback.GetHashCode & vbCrLf)
                Dim SenderName As String
                Dim connMatch = From conn2 In connections Where conn2.Callback.GetHashCode = callback.GetHashCode
                If connMatch.Count > 0 Then
                    'conn.Callback.OnSendMessage("The message was sent from: " & connMatch(0).AppName & vbCrLf)
                    'conn.Callback.OnSendMessage(connMatch(0).AppName & "> ")
                Else
                    conn.Callback.OnSendMessage("The sender is not on the connection list " & vbCrLf)
                End If
                conn.Callback.OnSendMessage(message)
            Else
                connections.Remove(conn)
            End If
        End If
    End Sub

    Public Sub SendAllMessage(ByVal message As String, ByVal SenderName As String) Implements IMsgService.SendAllMessage
        'Send the message to all connections in the connections list.
        Dim I As Integer 'Loop index
        For I = 1 To connections.Count
            If connections(I - 1).AppName = SenderName Then
                'Dont send the message back to the sender.
            Else
                If DirectCast(connections(I - 1).Callback, ICommunicationObject).State = CommunicationState.Opened Then
                    connections(I - 1).Callback.OnSendMessage(message)
                Else

                End If
            End If
           
        Next
    End Sub

    'Public Sub SendAdminMessage(ByVal message As String) Implements IMsgService.SendAdminMessage
    '    'Send the message to all connections in the adminConnections list.
    '    Dim I As Integer 'Loop index
    '    For I = 1 To adminConnections.Count
    '        If DirectCast(adminConnections(I - 1).Callback, ICommunicationObject).State = CommunicationState.Opened Then
    '            adminConnections(I - 1).Callback.OnSendMessage(message)
    '        Else

    '        End If
    '    Next
    'End Sub

    Public Sub SendMainNodeMessage(ByVal message As String) Implements IMsgService.SendMainNodeMessage
        'Send the message to the Main Node.
        'ADD TRY ... CATCH ------------------------------------------------------------
        If MainNodeName <> "" Then
            MainNodeCallback.OnSendMessage(message)
        End If
    End Sub

    Public Sub GetConnectionList() Implements IMsgService.GetConnectionList
        Dim callback As IMsgServiceCallback = OperationContext.Current.GetCallbackChannel(Of IMsgServiceCallback)() 'The connection list will be sent back to the requesting connection.
        callback.OnSendMessage("Connection list: (AppName | Connection Code)" & vbCrLf)
        For Each item In connections
            callback.OnSendMessage(item.AppName & " | " & item.Callback.GetHashCode & vbCrLf)
        Next

    End Sub

    'Public Sub GetAdminConnectionList() Implements IMsgService.GetAdminConnectionList
    '    Dim callback As IMsgServiceCallback = OperationContext.Current.GetCallbackChannel(Of IMsgServiceCallback)() 'The connection list will be sent back to the requesting connection.
    '    callback.OnSendMessage("Admin connection list: (AppName | Connection Code | Get Warnings | Get All Messages)" & vbCrLf)
    '    For Each item In adminConnections
    '        callback.OnSendMessage(item.AppName & " | " & item.Callback.GetHashCode & " | " & item.GetWarnings & " | " & item.GetAllMessages & vbCrLf)
    '    Next
    'End Sub

    'Public Sub SendWarning(ByVal warning As String) Implements IMsgService.SendAdminWarning
    '    'Sends the warning to all connections in the adminConnections list with the getWarnings flag set.

    '    Dim I As Integer 'Loop index
    '    For I = 1 To adminConnections.Count
    '        If adminConnections(I - 1).GetWarnings = True Then
    '            If DirectCast(adminConnections(I - 1).Callback, ICommunicationObject).State = CommunicationState.Opened Then
    '                adminConnections(I - 1).Callback.OnSendMessage(warning)
    '            Else

    '            End If

    '        Else
    '            'Warnings are not requested for this Admin Connection.
    '        End If
    '    Next

    'End Sub

    Public Function IsAlive() As Boolean Implements IMsgService.IsAlive
        'Returns True if the service is running
        Return True
    End Function

    Public Function Disconnect(ByVal appName As String) As Boolean Implements IMsgService.Disconnect
        'The Disconnect function removes a connection from the connections list.
        'Find the connection for the application corresponding to appName:
        Dim conn As clsConnection
        conn = connections.Find(Function(item As clsConnection)
                                    If IsNothing(item) Then
                                        'An error is raised if an item of nothing is used in the Return code.
                                    Else
                                        Return item.AppName = appName
                                    End If
                                End Function)
        If IsNothing(conn) Then
            'The connection is not on the list!
            'SendWarning("WARNING: Disconnection failed because " & appName & " is not on the connections list." & vbCrLf)
            'SendMainNodeMessage("WARNING: Disconnection failed because " & appName & " is not on the connections list." & vbCrLf)
            Main.Message.Add("WARNING: Disconnection failed because " & appName & " is not on the connections list." & vbCrLf)
            Return False
        Else
            connections.Remove(conn)

            'OLD CODE: Used for application version using a separate WCF service. ------------------------------------------
            'Send removed connection information to the Main Node connection:
            'Dim decl As New XDeclaration("1.0", "utf-8", "yes")
            'Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
            'Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
            'Dim removedConnectionInfo As New XElement("RemovedConnectionInfo")
            'Dim applicationName As New XElement("ApplicationName", appName)
            'removedConnectionInfo.Add(applicationName)
            'xmessage.Add(removedConnectionInfo)
            'doc.Add(xmessage)
            'SendMainNodeMessage(doc.ToString)

            'NEW CODE: Uses self hosted WCF service. --------------------------------------------------------------------------
            Main.RemoveConnectionWithAppName(appName)

            Return True
        End If
    End Function

    'Public Function AdminDisconnect(ByVal appName As String) As Boolean Implements IMsgService.AdminDisconnect
    '    'The AdminDisconnect function removes an administration connection from the adminConnections list.
    '    'Find the connection for the application corresponding to appName:
    '    Dim conn As clsConnection
    '    conn = adminConnections.Find(Function(item As clsConnection)
    '                                     If IsNothing(item) Then
    '                                         'An error is raised if an item of nothing is used in the Return code.
    '                                     Else
    '                                         Return item.AppName = appName
    '                                     End If
    '                                 End Function)
    '    If IsNothing(conn) Then
    '        'The connection is not on the list!
    '        Return False
    '    Else
    '        adminConnections.Remove(conn)
    '        Return True
    '    End If
    'End Function

End Class
