Imports AdvancedDataGridView
Module ArasUtil
    Public ItemList As List(Of TreeGridNode)
    Public PartID As String = ""

    Public Function ModelExist(item_number As String, Type As String) As Aras.IOM.Item
        Dim CADs As Aras.IOM.Item = inn.newItem()
        Dim aml As String = "<Item type='CAD' action='get' ><item_number condition='eq'>" + item_number + "</item_number><classification condition='eq'>Mechanical/" & Type & "</classification></Item>"
        CADs.loadAML(aml)
        CADs = CADs.apply()
        Return CADs
    End Function

    Function Addfile(file As String) As Aras.IOM.Item
        Dim it As Aras.IOM.Item = Nothing
        If file <> "" Then
            Dim fileitem As Aras.IOM.Item = inn.newItem("File", "add")
            fileitem.setFileName(file)
            ' fileitem.attachPhysicalFile(file)

            'Dim result As Aras.IOM.Item
            'result = fileitem.apply()
            it = fileitem.apply

            ''删除同名的文件关联
            'Dim f1 As Aras.IOM.Item = inn.newItem("File", "get")
            'f1.setProperty("filename", result.getProperty("filename"))
            'f1 = f1.apply()
            'it = f1

        End If
        Return it
    End Function
    Function Addugfile(file As String) As Aras.IOM.Item
        Dim it As Aras.IOM.Item = Nothing
        If file <> "" Then
            Dim fileitem As Aras.IOM.Item = inn.newItem("File", "add")
            fileitem.setFileName(file)
            '  fileitem.attachPhysicalFile(file)
            fileitem.setProperty("file_type", "FA3ED4A0494C4E92BDCDE8ED18950999") 'UG文件类型，避免和Proe冲突

            'Dim result As Aras.IOM.Item
            'result = fileitem.apply()
            it = fileitem.apply

            ''删除同名的文件关联
            'Dim f1 As Aras.IOM.Item = inn.newItem("File", "get")
            'f1.setProperty("filename", result.getProperty("filename"))
            'f1 = f1.apply()
            'it = f1

        End If
        Return it
    End Function
    Function UpdateUGPart(catobj As ArasObj, CAD As Aras.IOM.Item, thumbnail As Aras.IOM.Item, viewable_file As Aras.IOM.Item, native_file As Aras.IOM.Item) As Aras.IOM.Item
        '    Dim ConfigItem As System.Xml.XmlDocument = New System.Xml.XmlDocument
        '    Dim Node As System.Xml.XmlNode
        '    Dim nodelist As System.Xml.XmlNodeList
        '    ConfigItem.Load(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "mapping.xml")
        '    Node = ConfigItem.SelectSingleNode("//Part")
        '    nodelist = Node.SelectNodes("attribute")

        '    For Each Node In nodelist
        '        Dim ugattrname As String = Node.Attributes("ug").Value
        '        Dim plmattrname As String = Node.Attributes("plm").Value
        '        '        Dim ugattrvalue As String = readugattr(ugpart, ugattrname)
        '        CAD.setProperty(plmattrname, ugattrvalue)
        '    Next

        '    CAD.setAction("version")
        '    '      CAD.setProperty("is_standard", is_standard)
        '    CAD.setProperty("thumbnail", "vault:///?fileId=" + thumbnail.getID)  '缩略图
        '    CAD.setPropertyItem("viewable_file", viewable_file)  '预览文件，file类型
        '    CAD.setPropertyItem("native_file", native_file)  '源文件,file类型
        '    CAD.setProperty("authoring_tool", "CATIA")  '编辑工具NX
        '    CAD.setProperty("authoring_tool_version", catia_version) 
        '    CAD.setProperty("classification", "Mechanical/NXModel")  'classfication
        '    Dim y As Aras.IOM.Item = CAD.apply()

        '    y.unlockItem()

        '    Return y
    End Function
    Function addCATIADoc(catobject As ArasObj, is_standard As String, thumbnail As Aras.IOM.Item, viewable_file As Aras.IOM.Item, native_file As Aras.IOM.Item) As Aras.IOM.Item
        Dim CAD As Aras.IOM.Item = Nothing

        Dim item_number As String = ""

        item_number = catobject.PartNumber

        Dim results As Aras.IOM.Item = ModelExist(item_number, catobject.Type)
        If results.getItemCount <= 0 Then
            CAD = inn.newItem("CAD", "add")

            CAD.setProperty("item_number", item_number)  '
            CAD.setProperty("name", catobject.Name)  '
            CAD.setProperty("Material", catobject.Material)  '

            '      CAD.setProperty("is_standard", is_standard)
            CAD.setProperty("thumbnail", "vault:///?fileId=" + thumbnail.getID)  '缩略图
            CAD.setPropertyItem("viewable_file", viewable_file)  '预览文件，file类型
            CAD.setPropertyItem("native_file", native_file)  '源文件,file类型
            CAD.setProperty("authoring_tool", "CATIA")  '编辑工具NX
            CAD.setProperty("authoring_tool_version", catia_version)  '8.5版本
            CAD.setProperty("classification", "Mechanical/" & catobject.Type)  'classfication
            CAD = CAD.apply()
        Else
            CAD = results.getItemByIndex(0)
        End If
        '  MsgBox("5")
        Return CAD

    End Function
    Public Function findpart(ByVal th As String) As String
        Dim part As Aras.IOM.Item = inn.newItem()

        Dim amlstring As String
        amlstring = "<Item type='Part' action='get'  select='id,item_number,state' ><item_number condition='eq'>" + th + "</item_number></Item>"
        part.loadAML(amlstring)
        Dim results As Aras.IOM.Item = part.apply()

        Dim count As Integer = results.getItemCount()
        ' MsgBox(count)
        If count > 0 Then
            findpart = "借用"
        Else

            findpart = "新建" '系统中没有，需要创建

        End If

    End Function

    Public Function addpart(ByVal th, ByVal mc, ByVal bb, ByVal cl, ByVal lx) As Aras.IOM.Item
        Dim part As Aras.IOM.Item
        part = inn.newItem
        Dim aml As String


        aml = "<Item type='Part'  action='add'><item_number>" + th + "</item_number><name>" + mc + "</name><revision>" + bb + "</revision><material>" + cl + "</material><type>" + lx + "</type><classification>Component</classification></Item>"

        part.loadAML(aml)
        Dim result As Aras.IOM.Item = part.apply()
        'MsgBox(th)


        addpart = result

    End Function

    Public Function updatepart(ByVal th As String, ByVal mc As String, ByVal bb As String, ByVal cl As String, ByVal lx As String, ByVal isroot As Boolean) As Aras.IOM.Item

        Dim part1 As Aras.IOM.Item = inn.newItem("Part", "get")
        part1.setProperty("item_number", th)
        Dim ps As Aras.IOM.Item = part1.apply
        Dim p As Aras.IOM.Item = ps.getItemByIndex(0)

        p.setProperty("name", mc)
        p.setProperty("item_number", th)
        p.setProperty("revision", bb)
        p.setProperty("material", cl)
        p.setProperty("type", lx)


        Dim r As Aras.IOM.Item = p.apply("edit")
        Return r

    End Function

    Public Sub addbom(ByVal p As Aras.IOM.Item, ByVal s As Aras.IOM.Item, ByVal sl As String)

        Dim boms As Aras.IOM.Item = inn.newItem
        Dim amlstring As String = "<Item type='Part BOM'  action='add' ><quantity>" + sl + "</quantity><related_id>" + s.getID() + "</related_id><source_id>" + p.getID() + "</source_id></Item>"
        boms.loadAML(amlstring)

        Dim result As Aras.IOM.Item
        result = boms.apply

    End Sub
    Public Function findexistpart(ByVal th As String) As Aras.IOM.Item
        Dim part As Aras.IOM.Item = inn.newItem()

        Dim amlstring As String
        amlstring = "<Item type='Part' action='get'  select='id,item_number' ><item_number>" + th + "</item_number></Item>"
        part.loadAML(amlstring)
        Dim results As Aras.IOM.Item = part.apply()

        Dim count As Integer = results.getItemCount()

        Dim p As Aras.IOM.Item = results.getItemByIndex(0)

        findexistpart = p
    End Function
    Public Sub delete_old_bom(ByVal p As Aras.IOM.Item)
        Dim pm As Aras.IOM.Item = inn.newItem("Part BOM", "delete")
        pm.setAttribute("where", "[PART_BOM].source_id='" + p.getID + "'")
        Dim results As Aras.IOM.Item = pm.apply()
    End Sub

    Public Function partisexist(ByVal th As String) As Integer
        Dim part As Aras.IOM.Item = inn.newItem()

        Dim amlstring As String
        amlstring = "<Item type='Part' action='get'  select='id,item_number,state' ><item_number condition='eq'>" + th + "</item_number></Item>"
        part.loadAML(amlstring)
        Dim results As Aras.IOM.Item = part.apply()

        Dim count As Integer = results.getItemCount()
        ' MsgBox(count)
        If count > 0 Then
            Dim result As Aras.IOM.Item = results.getItemByIndex(0)
            If result.getProperty("state") = "Preliminary" Then
                Return 2 '可更新
            Else
                Return 3 '借用
            End If

        Else
            Return 1 '新建
        End If
    End Function
    Public Sub partfile(ByVal part As Aras.IOM.Item, ByVal file As Aras.IOM.Item)

        '删除同名的文件关联
        Dim f1 As Aras.IOM.Item = inn.newItem("File", "get")
        f1.setProperty("filename", file.getProperty("filename"))
        f1 = f1.apply()

        On Error Resume Next
        For j = 0 To f1.getItemCount - 1
            Dim pm As Aras.IOM.Item = inn.newItem("Part File", "delete")
            pm.setAttribute("where", "source_id='" + part.getID() + "'and related_id='" + f1.getItemByIndex(j).getID + "'")
            Dim results As Aras.IOM.Item = pm.apply()
        Next
        '删除完成

        Dim partfile As Aras.IOM.Item = inn.newItem
        Dim amlstring1 As String = "<Item type='Part File'  action='add' ><related_id>" + file.getID() + "</related_id><source_id>" + part.getID() + "</source_id></Item>"
        partfile.loadAML(amlstring1)

        Dim result1 As Aras.IOM.Item
        result1 = partfile.apply()

    End Sub

    Sub AddtoList(ByVal node As TreeGridNode)
        If ItemList.Count = 0 Then
            ItemList.Add(node)
        Else
            PartID = node.Cells(0).Value
                Dim resultp As TreeGridNode = ItemList.Find(AddressOf FindPart)
                If resultp Is Nothing Then
                    ItemList.Add(node)
                End If
            End If

    End Sub
    Public Function FindPart(ByVal node As TreeGridNode) As Boolean
        If node.Cells(0).Value = PartID Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
