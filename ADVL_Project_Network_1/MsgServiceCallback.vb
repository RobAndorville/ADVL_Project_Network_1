﻿Imports System.ServiceModel
Public Class MsgServiceCallback
    Implements ServiceReference1.IMsgServiceCallback
    'Implements IMsgServiceCallback
    Public Sub OnSendMessage(message As String) Implements ServiceReference1.IMsgServiceCallback.OnSendMessage
        'Public Sub OnSendMessage(message As String) Implements IMsgServiceCallback.OnSendMessage
        'A message has been received.
        'Set the InstrReceived property value to the XMessage. This will also apply the instructions in the XMessage.
        'Main.Message.Add("Message received: " & vbCrLf & message & vbCrLf)

        Main.InstrReceived = message
    End Sub
End Class
