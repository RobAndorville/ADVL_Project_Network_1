Public Class clsConnection
    'This class specifies the Connection items in the Connection list.
    'These items contain the AppName, Callback, GetAllWarnings and GetAllMessages fields.
    'AppName is the name of the application with the Admin Connection.
    'Callback is the connection used to send the message.
    'GetAllWarnings is a flag that indicates if all warning messages are to be received.
    'GetAllMessages is a flag that indicates if all messages are to be received.

    Private _appName As String
    Friend Property AppName As String
        Get
            Return _appName
        End Get
        Set(value As String)
            _appName = value
        End Set
    End Property

    'Public Enum enumAppType
    Public Enum AppTypes
        Application
        MainNode
        Node
    End Enum

    'Private _appType As enumAppType = enumAppType.Application
    Private _appType As AppTypes = AppTypes.Application
    Friend Property AppType As AppTypes
        Get
            Return _appType
        End Get
        Set(value As AppTypes)
            _appType = value
        End Set
    End Property

    Private _callback As IMsgServiceCallback
    Friend Property Callback As IMsgServiceCallback
        Get
            Return _callback
        End Get
        Set(value As IMsgServiceCallback)
            _callback = value
        End Set
    End Property

    Private _getAllWarnings As Boolean = False
    Friend Property GetAllWarnings As Boolean
        Get
            Return _getAllWarnings
        End Get
        Set(value As Boolean)
            _getAllWarnings = value
        End Set
    End Property

    Private _getAllMessages As Boolean = False
    Friend Property GetAllMessages As Boolean
        Get
            Return _getAllMessages
        End Get
        Set(value As Boolean)
            _getAllMessages = value
        End Set
    End Property

    Friend Sub New(ByVal newAppName As String, ByRef newAppType As AppTypes, ByRef newCallback As IMsgServiceCallback, ByVal newGetAllWarnings As Boolean, ByVal newGetAllMessages As Boolean)
        AppName = newAppName
        AppType = newAppType
        Callback = newCallback
        GetAllWarnings = newGetAllWarnings
        GetAllMessages = newGetAllMessages
    End Sub

End Class
