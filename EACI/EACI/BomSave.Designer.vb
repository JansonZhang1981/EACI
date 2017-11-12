<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BomSave
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BomSave))
        Me.TreeGridView1 = New AdvancedDataGridView.TreeGridView()
        Me.PartNumber = New AdvancedDataGridView.TreeGridColumn()
        Me.partname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.revision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.memo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.save = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.delete = New System.Windows.Forms.Button()
        CType(Me.TreeGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeGridView1
        '
        Me.TreeGridView1.AllowUserToAddRows = False
        Me.TreeGridView1.AllowUserToDeleteRows = False
        Me.TreeGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumber, Me.partname, Me.revision, Me.material, Me.type, Me.quantity, Me.Column1, Me.memo, Me.remark})
        Me.TreeGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TreeGridView1.ImageList = Nothing
        Me.TreeGridView1.Location = New System.Drawing.Point(12, 12)
        Me.TreeGridView1.MultiSelect = False
        Me.TreeGridView1.Name = "TreeGridView1"
        Me.TreeGridView1.RowHeadersVisible = False
        Me.TreeGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TreeGridView1.Size = New System.Drawing.Size(645, 364)
        Me.TreeGridView1.TabIndex = 0
        '
        'PartNumber
        '
        Me.PartNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.PartNumber.DefaultNodeImage = Nothing
        Me.PartNumber.FillWeight = 152.0737!
        Me.PartNumber.HeaderText = "零件号"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PartNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'partname
        '
        Me.partname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.partname.FillWeight = 166.5155!
        Me.partname.HeaderText = "名称"
        Me.partname.Name = "partname"
        Me.partname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'revision
        '
        Me.revision.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.revision.FillWeight = 60.78291!
        Me.revision.HeaderText = "版本"
        Me.revision.Name = "revision"
        Me.revision.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'material
        '
        Me.material.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.material.FillWeight = 77.05717!
        Me.material.HeaderText = "材料/品牌"
        Me.material.Name = "material"
        Me.material.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'type
        '
        Me.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.type.FillWeight = 51.81976!
        Me.type.HeaderText = "类型"
        Me.type.Name = "type"
        Me.type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'quantity
        '
        Me.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.quantity.FillWeight = 56.85537!
        Me.quantity.HeaderText = "数量"
        Me.quantity.Name = "quantity"
        Me.quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.FillWeight = 53.29949!
        Me.Column1.HeaderText = "State"
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Visible = False
        '
        'memo
        '
        Me.memo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.memo.FillWeight = 181.596!
        Me.memo.HeaderText = "备注"
        Me.memo.Name = "memo"
        Me.memo.ReadOnly = True
        Me.memo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'remark
        '
        Me.remark.HeaderText = "remark"
        Me.remark.Name = "remark"
        Me.remark.ReadOnly = True
        Me.remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.remark.Visible = False
        '
        'save
        '
        Me.save.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.save.Location = New System.Drawing.Point(676, 12)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(75, 23)
        Me.save.TabIndex = 1
        Me.save.Text = "保存"
        Me.save.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "CATIA Product.bmp")
        Me.ImageList1.Images.SetKeyName(1, "CATIA Part.BMP")
        Me.ImageList1.Images.SetKeyName(2, "CATIA Drawing.bmp")
        '
        'delete
        '
        Me.delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.delete.Location = New System.Drawing.Point(676, 64)
        Me.delete.Name = "delete"
        Me.delete.Size = New System.Drawing.Size(75, 23)
        Me.delete.TabIndex = 2
        Me.delete.Text = "删行"
        Me.delete.UseVisualStyleBackColor = True
        '
        'BomSave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 380)
        Me.Controls.Add(Me.delete)
        Me.Controls.Add(Me.save)
        Me.Controls.Add(Me.TreeGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BomSave"
        Me.Text = "BomSave"
        CType(Me.TreeGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TreeGridView1 As AdvancedDataGridView.TreeGridView
    Friend WithEvents save As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents delete As Button
    Friend WithEvents PartNumber As AdvancedDataGridView.TreeGridColumn
    Friend WithEvents partname As DataGridViewTextBoxColumn
    Friend WithEvents revision As DataGridViewTextBoxColumn
    Friend WithEvents material As DataGridViewTextBoxColumn
    Friend WithEvents type As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents memo As DataGridViewTextBoxColumn
    Friend WithEvents remark As DataGridViewTextBoxColumn
End Class
