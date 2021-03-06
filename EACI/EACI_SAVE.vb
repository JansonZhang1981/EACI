﻿Imports ProductStructureTypeLib
Imports MECMOD
Imports PARTITF
Imports HybridShapeTypeLib
Imports INFITF
Imports AdvancedDataGridView
Public Class EACI_SAVE

    Private Sub EACI_SAVE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim root As TreeGridNode = TreeGridView1.Nodes.Add(oProduct.PartNumber, oProduct.Definition, oProduct.Revision, oProduct.DescriptionRef, oProduct.Nomenclature, "", oProduct.ReferenceProduct.Parent.path, oProduct.ReferenceProduct.Parent.name)
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
        Dim flg As Boolean = False
        For Each child In Children
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
            ChildNode = iNode.Nodes.Add(child.PartNumber, child.Definition, child.Revision, child.DescriptionRef, child.Nomenclature, "1", child.ReferenceProduct.Parent.path, child.ReferenceProduct.Parent.name)

            If isPart(child.ReferenceProduct.Parent.name) Then
                ChildNode.ImageIndex = 1
            Else
                ChildNode.ImageIndex = 0
            End If
            FillTRV(child, ChildNode)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'For i = 0 To TreeGridView1.RowCount - 1
        '    Dim pn As String = TreeGridView1.Rows.Item(i).Cells(0).Value
        '    Dim name As String = TreeGridView1.Rows.Item(i).Cells(7).Value
        '    Dim x As Aras.IOM.Item = ModelExist(pn, name.Substring(InStrRev(name, ".") + 1))
        '    If x.getItemCount <= 0 Then
        '        '  Dim ifn As String = Create_Thumbnails(TreeGridView1.Rows(i).Cells(6).Value, TreeGridView1.Rows(i).Cells(7).Value)
        '        '  Dim t As Aras.IOM.Item = Addfile(ifn)
        '        '  Dim pf As String = p.FullPath
        '        '    Dim n As Aras.IOM.Item = Addugfile(pf)
        '        '   Dim ap As Aras.IOM.Item = addUGPart(p, "0", t, t, n)
        '        '    myDictionary.Add(pn, ap)
        '    Else
        '        Dim y As Aras.IOM.Item = x.getItemByIndex(0)
        '        If user.getID = y.getProperty("locked_by_id") Then
        '            Dim ifn As String = createpreview(p, workspace)
        '            Dim t As Aras.IOM.Item = Addfile(ifn)
        '            Dim pf As String = p.FullPath
        '            Dim n As Aras.IOM.Item = Addugfile(pf)
        '            Dim ap As Aras.IOM.Item = UpdateUGPart(p, x, t, t, n)
        '            delete_old_Structure(ap)  '删掉原先的结构
        '            myDictionary.Add(pn, ap)
        '        Else
        '            myDictionary.Add(y.getProperty("item_number"), y)

        '        End If

        '    End If

        'Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim s As String = Create_Thumbnails(TreeGridView1.Rows(1).Cells(6).Value, TreeGridView1.Rows(1).Cells(7).Value)
        MsgBox(s)
    End Sub

End Class