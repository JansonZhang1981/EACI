Imports ProductStructureTypeLib
Imports MECMOD
Imports PARTITF
Imports HybridShapeTypeLib
Imports INFITF
Imports AdvancedDataGridView
Public Class BomSave
    Private Sub BomSave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ItemList = New List(Of TreeGridNode)
        TreeGridView1.Rows.Clear()

        catia = GetObject(, "CATIA.Application")
        If Err.Number <> 0 Then
            catia = CreateObject("CATIA.Application")
            catia.Visible = True
        End If
        catia_version = "5." & catia.SystemConfiguration.Release
        Dim oDocument As Document = catia.ActiveDocument
        Dim oProduct As Product = oDocument.Product

        Dim RootChildren As Products = oProduct.Products
        '   Dim root As New TreeGridNode
        ' root.SetValues(oProduct.PartNumber, oProduct.DescriptionRef, "", "", "")
        TreeGridView1.ImageList = ImageList1
        Dim root As TreeGridNode = TreeGridView1.Nodes.Add(oProduct.PartNumber, oProduct.Definition, oProduct.Revision, oProduct.DescriptionRef, oProduct.Nomenclature, "", "", "", "1")
        If partisexist(oProduct.PartNumber) = 3 Then
            save.Enabled = False
            root.DefaultCellStyle.BackColor = Color.Lime
            root.Cells(6).Value = "3"
        ElseIf partisexist(oProduct.PartNumber) = 2 Then
            root.DefaultCellStyle.BackColor = Color.LightGray
            root.Cells(6).Value = "2"
        Else
            root.Cells(6).Value = "1"
        End If

        If isPart(oProduct.ReferenceProduct.Parent.name) Then
            root.ImageIndex = 1
        Else
            root.ImageIndex = 0
        End If
        FillTRV(oProduct, root)

    End Sub
    Sub FillTRV(oProduct As Product, iNode As TreeGridNode)
        Dim Children As Products = oProduct.Products
        Dim child As Product
        For Each child In Children
            Dim flg As Boolean = False
            Dim ChildNode As TreeGridNode
            For i = 0 To iNode.Nodes.Count - 1
                If iNode.Nodes.Item(i).Cells(0).Value = child.PartNumber Then
                    Dim qty As Integer = CInt(iNode.Nodes.Item(i).Cells(5).Value)
                    qty = qty + 1
                    iNode.Nodes.Item(i).Cells(5).Value = qty
                    flg = True
                    Continue For
                End If
            Next

            If flg Then
                Continue For
            End If
            ChildNode = iNode.Nodes.Add(child.PartNumber, child.Definition, child.Revision, child.DescriptionRef, child.Nomenclature, "1", "", "", "1")

            If partisexist(child.PartNumber) = 3 Then
                ChildNode.DefaultCellStyle.BackColor = Color.Lime
                ChildNode.Cells(6).Value = "3"
            ElseIf partisexist(child.PartNumber) = 2 Then
                ChildNode.DefaultCellStyle.BackColor = Color.LightGray
                ChildNode.Cells(6).Value = "2"
            Else
                If ChildNode.Cells(4).Value = "PUR" Then
                    ChildNode.DefaultCellStyle.BackColor = Color.Red
                    ChildNode.Cells(7).Value = "系统中无此采购件"
                    ChildNode.Cells(6).Value = "1"
                ElseIf ChildNode.Cells(4).Value = "STD" Then
                    ChildNode.DefaultCellStyle.BackColor = Color.Red
                    ChildNode.Cells(7).Value = "系统中无此标准件"
                    ChildNode.Cells(6).Value = "1"
                Else
                    ChildNode.Cells(6).Value = "1"
                End If

            End If

            If isPart(child.ReferenceProduct.Parent.name) Then
                ChildNode.ImageIndex = 1
            Else
                ChildNode.ImageIndex = 0
            End If
            FillTRV(child, ChildNode)
        Next
    End Sub

    'Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
    '    save.Enabled = False
    '    save.Text = "正在导入"
    '    Dim s = MsgBox("是否确认导入？", MsgBoxStyle.OkCancel)

    '    If s = MsgBoxResult.Ok Then
    '        If TreeGridView1.Rows(0).Cells(6).Value = 3 Then
    '            MsgBox("零部件当前状态不可编辑！")
    '        ElseIf TreeGridView1.Rows(0).Cells(6).Value = 2 Then
    '            Dim q = MsgBox("零部件虽然已存在，但是为准备状态，是否更新？", MsgBoxStyle.OkCancel)
    '            If q = MsgBoxResult.Ok Then
    '                Dim rootnode As TreeGridNode = TreeGridView1.Nodes(0)
    '                Dim root As Aras.IOM.Item = updatepart(rootnode.Cells(0).Value, rootnode.Cells(1).Value, rootnode.Cells(2).Value, rootnode.Cells(3).Value, rootnode.Cells(4).Value, True)
    '                '添加完成
    '                delete_old_bom(root)
    '                setchildren(rootnode, root)
    '                MsgBox("导入完成！请进入到系统查看。")
    '            End If
    '        Else '新建
    '            Dim rootnode As TreeGridNode = TreeGridView1.Nodes(0)
    '            Dim root As Aras.IOM.Item = addpart(rootnode.Cells(0).Value, rootnode.Cells(1).Value, rootnode.Cells(2).Value, rootnode.Cells(3).Value, rootnode.Cells(4).Value)
    '            setchildren(rootnode, root)

    '            MsgBox("导入完成！请进入到系统查看。")

    '        End If
    '        Me.save.Enabled = False
    '        save.Text = "导入完成"
    '    Else
    '        MsgBox("已取消操作！")
    '    End If
    'End Sub

    Public Sub setchildren(node As TreeGridNode, root As Aras.IOM.Item)
        Dim p As Aras.IOM.Item
        For i = 0 To node.Nodes.Count - 1
            Dim child As TreeGridNode
            child = node.Nodes(i)
            Dim th As String = child.Cells(0).Value
            Dim mc As String = child.Cells(1).Value
            Dim bb As String = child.Cells(2).Value
            Dim cl As String = child.Cells(3).Value
            Dim lx As String = child.Cells(4).Value
            Dim sl As String = child.Cells(5).Value
            If child.Cells(6).Value = 1 Then '不存在
                p = addpart(th, mc, bb, cl, lx)
                addbom(root, p, sl)

            ElseIf child.Cells(6).Value = 3 Then '归档
                p = findexistpart(th)
                addbom(root, p, sl)
            ElseIf child.Cells(6).Value = 2 Then '准备   
                p = updatepart(th, mc, bb, cl, lx, False)
                delete_old_bom(p)
                addbom(root, p, sl)
            End If
            setchildren(child, p)
        Next

    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs) Handles delete.Click
        Dim node As TreeGridNode = TreeGridView1.CurrentNode
        node.Cells(8).Value = "0" '删除标记
        TreeGridView1.Rows.Remove(TreeGridView1.Rows(node.RowIndex))

    End Sub

    'Private Sub TreeGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles TreeGridView1.CellDoubleClick
    '    If e.ColumnIndex = 5 Then
    '        TreeGridView1.BeginEdit(True)
    '    End If


    'End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        save.Enabled = False
        delete.Enabled = False
        save.Text = "正在导入"
        Dim s = MsgBox("是否确认导入？", MsgBoxStyle.OkCancel)

        If s = MsgBoxResult.Ok Then
            Dim rootnode As TreeGridNode = TreeGridView1.Nodes(0)
            AddtoList(rootnode)
            foreachnode(rootnode)

            For i = 0 To ItemList.Count - 1
                Dim nd As TreeGridNode = ItemList.Item(i)
                Dim th As String = nd.Cells(0).Value
                Dim mc As String = nd.Cells(1).Value
                Dim bb As String = nd.Cells(2).Value
                Dim cl As String = nd.Cells(3).Value
                Dim lx As String = nd.Cells(4).Value
                Dim sl As String = nd.Cells(5).Value
                If nd.Cells(8).Value = "1" Then
                    If nd.Cells(6).Value = 2 Then
                        Dim item As Aras.IOM.Item = updatepart(nd.Cells(0).Value, nd.Cells(1).Value, nd.Cells(2).Value, nd.Cells(3).Value, nd.Cells(4).Value, True)
                        delete_old_bom(item)
                    ElseIf nd.Cells(6).Value = 1 Then
                        Dim item As Aras.IOM.Item = addpart(nd.Cells(0).Value, nd.Cells(1).Value, nd.Cells(2).Value, nd.Cells(3).Value, nd.Cells(4).Value)
                    End If
                End If

            Next

            If rootnode.Cells(8).Value = "1" Then
                Dim root As Aras.IOM.Item = findexistpart(rootnode.Cells(0).Value)
                AddChildren(rootnode, root)
            End If

        End If

        MsgBox("导入成功！")

    End Sub

    Public Sub foreachnode(node As TreeGridNode)
        For i = 0 To node.Nodes.Count - 1
            Dim child As TreeGridNode = node.Nodes(i)

            AddtoList(node.Nodes(i))
            foreachnode(child)
        Next
    End Sub

    Public Sub AddChildren(node As TreeGridNode, root As Aras.IOM.Item)
        Dim p As Aras.IOM.Item
        For i = 0 To node.Nodes.Count - 1
            Dim child As TreeGridNode
            child = node.Nodes(i)
            Dim th As String = child.Cells(0).Value
            Dim sl As String = child.Cells(5).Value
            '  MsgBox("before is " & child.Cells(8).Value)
            If child.Cells(8).Value = "1" Then
                '      MsgBox(child.Cells(8).Value)
                p = findexistpart(th)
                addbom(root, p, sl)
                AddChildren(child, p)
            End If
        Next

    End Sub
End Class