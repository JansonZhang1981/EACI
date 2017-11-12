Public Class ComboxItem
    Public Text As String
    Public Value As String

    Public Sub New(text As String, value As String)
        Me.Text = text
        Me.Value = value
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Text
    End Function
End Class
