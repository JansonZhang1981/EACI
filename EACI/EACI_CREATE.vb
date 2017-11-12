Imports ProductStructureTypeLib
Imports MECMOD
Imports PARTITF
Imports HybridShapeTypeLib
Imports INFITF
Imports AdvancedDataGridView

Public Class EACI_create

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        commandButton1.Enabled = False


        On Error Resume Next
        catia = GetObject(, "CATIA.Application")
        If Err.Number <> 0 Then
            catia = CreateObject("CATIA.application")
            catia.Visible = True
        End If
        On Error GoTo 0

        ComboBox1.Items.Add("PART")
        ComboBox1.Items.Add("PRODUCT")

        ComboBox2.Items.Add("ALUMINUM_PROFILE  铝型材")
        ComboBox2.Items.Add("ANGLE  角铁、L型连接块")
        ComboBox2.Items.Add("BASE  地板")
        ComboBox2.Items.Add("BENDING_PART  折弯件")
        ComboBox2.Items.Add("BUSHING  衬套")
        ComboBox2.Items.Add("BUTTON_BOX  按钮盒")
        ComboBox2.Items.Add("CABLE  电缆")
        ComboBox2.Items.Add("CASTING_PART  铸件")
        ComboBox2.Items.Add("COVER  盖板")
        ComboBox2.Items.Add("FEAME  框架")
        ComboBox2.Items.Add("FOUNDATION_PLATE  地脚板")
        ComboBox2.Items.Add("GUIDE  导向")
        ComboBox2.Items.Add("GUIDE_CARRIAGE  滑块")
        ComboBox2.Items.Add("GUIDE_RAIL  导轨")
        ComboBox2.Items.Add("HANDLE  手柄")
        ComboBox2.Items.Add("INSULATION_BUSH  绝缘衬套")
        ComboBox2.Items.Add("INSULATION_SHIMS  绝缘垫片")
        ComboBox2.Items.Add("NC_CLAMP  压紧块")
        ComboBox2.Items.Add("NC_SUPPORT  支撑块")
        ComboBox2.Items.Add("PIN  定位销")
        ComboBox2.Items.Add("PLATE  连接板")
        ComboBox2.Items.Add("PMMA  亚克力板")
        ComboBox2.Items.Add("PULLEY  同步带轮")
        ComboBox2.Items.Add("RISER  立柱")
        ComboBox2.Items.Add("ROBOT_RISER  机器人底座")
        ComboBox2.Items.Add("ROLLER  滚轮")
        ComboBox2.Items.Add("RUBBER  橡胶")
        ComboBox2.Items.Add("SHAFT  轴")
        ComboBox2.Items.Add("SHIMS  调整垫片")
        ComboBox2.Items.Add("SIGNBOARD  标牌")
        ComboBox2.Items.Add("SPACER  调整垫块")
        ComboBox2.Items.Add("STOPPER  限位块")
        ComboBox2.Items.Add("THREADED  螺纹杆")
        ComboBox2.Items.Add("THREADED_BUSH  螺纹套")
        ComboBox2.Items.Add("WELDING_PART  焊接件")

        ComboBox3.Items.Add("Q235")
        ComboBox3.Items.Add("45")
        ComboBox3.Items.Add("40Cr")

        Dim doc As Document

        On Error GoTo Exc

        doc = CATIA.ActiveDocument
        Dim p As Product
        p = doc.Product

        If Not p Is Nothing Then
            addtolist(p)
        End If

        Exit Sub
Exc:
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "PART" Then
            ComboBox3.Enabled = True
        Else
            ComboBox3.Enabled = False
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        commandButton1.Enabled = True
    End Sub

    Private Sub commandButton1_Click(sender As Object, e As EventArgs) Handles commandButton1.Click
        If TextBox3.Text = "" Then
            commandButton1.Enabled = False
            MsgBox("请输入零件编号")
            Exit Sub
        End If

        Dim documents1 As Documents
        '  On Error Resume Next
        '   documents1 = catia.Documents

        Dim doc As Document
        Dim product1 As Product

        Dim f As Product
        If ListBox1.Items.Count > 0 Then

            If ListBox1.Text <> "" Then
                doc = catia.ActiveDocument
                f = doc.GetItem(ListBox1.Text)
            Else
                f = Nothing
            End If

        End If

        If ComboBox1.Text = "PART" Then

            If Not f Is Nothing Then

                product1 = f.Products.AddNewComponent("Part", TextBox3.Text)
            Else
                Dim partDocument1 As PartDocument

                partDocument1 = catia.Documents.Add("Part")
                product1 = partDocument1.Product
                product1.PartNumber = TextBox3.Text


            End If

            product1.Revision = TextBox2.Text

            If InStr(1, ComboBox2.Text, " ") <> 0 Then
                product1.Definition = Microsoft.VisualBasic.Left(ComboBox2.Text, InStr(1, ComboBox2.Text, " ") - 1)
            Else
                product1.Definition = ComboBox2.Text
            End If

            product1.DescriptionRef = ComboBox3.Text
            product1.Nomenclature = ComboBox1.Text

            MsgBox("零件属性创建成功！"）
            clearTb()

        ElseIf ComboBox1.Text = "PRODUCT" Then

            If Not f Is Nothing Then

                product1 = f.Products.AddNewComponent("Product", TextBox3.Text)
            Else
                Dim productDocument1 As ProductDocument
                productDocument1 = catia.Documents.Add("Product")
                product1 = productDocument1.Product
                product1.PartNumber = TextBox3.Text

            End If

            product1.Revision = TextBox2.Text

            If InStr(1, ComboBox2.Text, " ") <> 0 Then
                product1.Definition = Microsoft.VisualBasic.Left(ComboBox2.Text, InStr(1, ComboBox2.Text, " ") - 1)
            Else
                product1.Definition = ComboBox2.Text
            End If

            product1.DescriptionRef = ComboBox3.Text
            product1.Nomenclature = ComboBox1.Text

            MsgBox("部件属性创建成功！")

            clearTb()
        Else

            MsgBox("请选择需要新建的文件！")

        End If

        ListBox1.Items.Clear()


        On Error GoTo Exc
        doc = catia.ActiveDocument

        Dim p As Product
        p = doc.Product

        If Not p Is Nothing Then
            addtolist(p)
        End If

        Me.Close()

        EACI_MENU.Show()

Exc:

    End Sub
    Sub addtolist(oProduct As Product)
        Dim name As String
        name = oProduct.ReferenceProduct.Parent.name

        Dim CATType As String
        CATType = Microsoft.VisualBasic.Right(name, Len(name) - InStrRev(name, "."))

        If CATType = "CATProduct" Then
            ListBox1.Items.Add(oProduct.PartNumber)
            Dim child As Product
            For Each child In oProduct.Products
                addtolist(child)
            Next
        End If

    End Sub

    Sub clearTb()
        TextBox3.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
    End Sub

    Private Sub EACI_create_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        EACI_MENU.Show()
    End Sub
End Class