
Imports System.ServiceModel

'WcfMsgServiceLib is a Windows Communications Foundation service library.
'It provides a messaging service between applications.
'An application can connect to the service.
'Once connected, an application can send a message to any other connected application.

'<ServiceContract(CallbackContract:=GetType(IMsgServiceCallback))> _
'<ServiceBehavior(ConcurrencyMode:=ConcurrencyMode.Multiple)> _
<ServiceContract(CallbackContract:=GetType(IMsgServiceCallback))> _
Public Interface IMsgService

    <OperationContract()> _
    Function Connect(ByVal appName As String, ByVal appType As clsConnection.AppTypes, ByVal getAllWarnings As Boolean, ByVal getAllMessages As Boolean) As Boolean
    'Sub Connect(ByVal appName As String)

    <OperationContract()> _
    Sub SendMessage(ByVal appName As String, ByVal message As String)

    <OperationContract()> _
    Sub SendAllMessage(ByVal message As String, ByVal SenderName As String)

    '<OperationContract()> _
    'Function AdminConnect(ByVal appName As String, ByVal getWarnings As Boolean, ByVal getAllMessages As Boolean) As Boolean

    '<OperationContract()> _
    'Sub SendAdminMessage(ByVal message As String)

    <OperationContract()> _
    Sub SendMainNodeMessage(ByVal message As String)

    '<OperationContract()> _
    'Sub SendAdminWarning(ByVal warning As String)

    <OperationContract()> _
    Sub GetConnectionList()

    '<OperationContract()> _
    'Sub GetAdminConnectionList()

    <OperationContract()> _
    Function Disconnect(ByVal appName As String) As Boolean

    '<OperationContract()> _
    'Function AdminDisconnect(ByVal appName As String) As Boolean

    <OperationContract()> _
    Function IsAlive() As Boolean


End Interface

'        <CallbackBehavior(ConcurrencyMode:=ConcurrencyMode.Multiple, UseSynchronizationContext:=False)> _
'<ServiceBehavior(ConcurrencyMode:=ConcurrencyMode.Multiple)> _

Public Interface IMsgServiceCallback

    '<OperationContract(IsOneWay:=True)> _
    <OperationContract(IsOneWay:=True)> _
    Sub OnSendMessage(ByVal message As String)
End Interface


