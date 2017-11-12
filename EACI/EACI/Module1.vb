Option Strict Off
Imports System
Imports System.IO
Imports System.IO.File
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Configuration
Imports System.Reflection
Imports System.Xml
Imports ProductStructureTypeLib
Imports MECMOD
Imports HybridShapeTypeLib
Imports INFITF
Imports AdvancedDataGridView
Module Module1
    Public inn As Aras.IOM.Innovator
    Public conn As Aras.IOM.HttpServerConnection
    Public sr As System.IO.StreamReader
    Public path As String
    Public pwd As String
    Public username As String
    Public url As String
    Public db As String
    Public is_admin As Boolean = False
    Public login_reslut As Aras.IOM.Item
    Public jc_module As Integer = 0
    Public loginstatus As Boolean = False

    Public vServer As String = ""
    Public vDatabase As String
    Public vDefaultVault As String = ""
    Public XML As String = ""
    Public UGHandle As String
    Public pid As Integer = 0
    Public user As Aras.IOM.Item
    Public workspace As String = ""
    Public State As String()
    Public catia As INFITF.Application
    Public catia_version As String

    Sub initialization()
        loginstatus = False
        Dim path = Reflection.Assembly.GetExecutingAssembly.Location
        path = path + ".config"

        Dim filePath As String = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", String.Empty) + ".config"
        Dim xDoc As XmlDocument = New XmlDocument()
        xDoc.Load(filePath)

        Dim node As XmlNode = xDoc.SelectSingleNode("//appSettings")

        Dim element As XmlElement = node.SelectSingleNode("//add[@key='server']")

        If Not element Is Nothing Then
            vServer = element.GetAttribute("value")
        End If

        element = node.SelectSingleNode("//add[@key='database']")
        If Not element Is Nothing Then
            vDatabase = element.GetAttribute("value")
        End If

        element = node.SelectSingleNode("//add[@key='LifeCycleState']")
        If Not element Is Nothing Then
            '   State = element.GetAttribute("value")

            State = Split(element.GetAttribute("value"), ",")

        End If
    End Sub

    Public Function isPart(name As String) As Boolean
        Dim b As String
        b = Right(name, Len(name) - InStrRev(name, "."))
        If b = "CATPart" Then
            Return True
        ElseIf b = "CATProduct" Then
            Return False
        Else
            Return False
        End If
    End Function
    Public Function Create_Thumbnails(path As String, filename As String) As String
        Dim fullpath = path & "\" & filename
        Dim I As Integer
        Dim myIdent As Integer
        Dim oDocument As Document
        Dim specsAndGeomWindow1 As SpecsAndGeomWindow
        Dim myViewer As Viewer
        Dim varmyViewer As Viewer


        oDocument = catia.Documents.Open(fullpath)
        oDocument.Activate()

        '' Set the file name
        Dim myfile As String
        myfile = path + "\" + filename.Substring(0, Len(filename) - InStrRev(filename, ".")) + ".jpg"

        '    ' Get the viewer
        specsAndGeomWindow1 = catia.ActiveWindow
        myViewer = specsAndGeomWindow1.ActiveViewer
        varmyViewer = myViewer

        '    ' Store the background color
        Dim color(2)
        varmyViewer.GetBackgroundColor(color)

        '    ' Turn the background color into blanck
        '    varmyViewer.PutBackgroundColor({1, 1, 1})
        myViewer.RenderingMode = 1
        myViewer.Reframe()
        specsAndGeomWindow1.Layout = 1
        catia.ActiveWindow.ActiveViewer.CaptureToFile(CatCaptureFormat.catCaptureFormatJPEG, myfile)

        '    ' Turn the background color into the original one
        '        varmyViewer.PutBackgroundColor color
        catia.ActiveDocument.Close()              ' Close it

        Return myfile

    End Function

End Module
