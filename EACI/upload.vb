Imports Aras.IOM
Imports System.IO

Public Class upload
    Private Sub upload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        Dim parts As Item = AllParts()
        If parts.getItemCount > 0 Then
            For i = 0 To parts.getItemCount - 1
                Dim Part As Item = parts.getItemByIndex(i)
                ComboBox1.Items.Add(New ComboxItem(Part.getProperty("item_number"), Part.getID))
            Next

        End If



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As Boolean = False
        For Each ob In ComboBox1.Items
            If ob.ToString = ComboBox1.Text Then
                f = True
                Exit For
            End If
        Next

        If f = False Then
            MsgBox("请输入正确的零件号")
        Else
            Dim fb As New FolderBrowserDialog
            fb.ShowDialog()
            Dim fp As String = fb.SelectedPath
            DataGridView1.Rows.Clear()
            FillDR(fp)
            Button2.Enabled = True
        End If
    End Sub
    Private Sub FillDR(dc As String)
        Dim dir As New DirectoryInfo(dc)
        Dim sDirs As DirectoryInfo() = dir.GetDirectories()

        Dim files As FileInfo() = dir.GetFiles
        For i = 0 To files.Length - 1
            If files(i).Name <> "Thumbs.db" Then
                DataGridView1.Rows.Add(files(i).Name, files(i).FullName)
            End If
        Next
        For i = 0 To sDirs.Length - 1
            FillDR(sDirs(i).FullName)
        Next
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim Rectangle As Rectangle = New Rectangle(e.RowBounds.Location.X,
      e.RowBounds.Location.Y,
      DataGridView1.RowHeadersWidth - 4,
      e.RowBounds.Height)

        TextRenderer.DrawText(e.Graphics,
          (e.RowIndex + 1).ToString(),
           DataGridView1.RowHeadersDefaultCellStyle.Font,
           Rectangle,
           DataGridView1.RowHeadersDefaultCellStyle.ForeColor,
           TextFormatFlags.VerticalCenter Or TextFormatFlags.Right)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim item As ComboxItem = CType(ComboBox1.SelectedItem, ComboxItem)
        Dim part As Aras.IOM.Item = inn.getItemById("Part", item.Value)
        For i = 0 To DataGridView1.RowCount - 1
            Dim r As DataGridViewRow = DataGridView1.Rows.Item(i)
            Dim file As Aras.IOM.Item = Addfile(r.Cells(1).Value, r.Cells(0).Value)
            otherfile(part, file)
        Next
        MsgBox("导入成功！")
        Button2.Enabled = False

    End Sub
End Class