<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmControlCapture
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControlCapture))
        Me.picControlCapture = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.JpegToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GifToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PngToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BmpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.自動保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.フォルダ指定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存フォルダを開くToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.反転表示ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.picScreen = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnMinimized = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.バージョン情報ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.picControlCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.picScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picControlCapture
        '
        Me.picControlCapture.ContextMenuStrip = Me.ContextMenuStrip1
        Me.picControlCapture.Image = CType(resources.GetObject("picControlCapture.Image"), System.Drawing.Image)
        Me.picControlCapture.Location = New System.Drawing.Point(0, 0)
        Me.picControlCapture.Name = "picControlCapture"
        Me.picControlCapture.Size = New System.Drawing.Size(48, 49)
        Me.picControlCapture.TabIndex = 0
        Me.picControlCapture.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.保存ToolStripMenuItem, Me.ToolStripSeparator1, Me.JpegToolStripMenuItem, Me.GifToolStripMenuItem, Me.PngToolStripMenuItem, Me.BmpToolStripMenuItem, Me.ToolStripSeparator3, Me.自動保存ToolStripMenuItem, Me.ToolStripSeparator4, Me.フォルダ指定ToolStripMenuItem, Me.保存フォルダを開くToolStripMenuItem, Me.ToolStripSeparator2, Me.反転表示ToolStripMenuItem, Me.ToolStripSeparator5, Me.バージョン情報ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(162, 276)
        '
        '保存ToolStripMenuItem
        '
        Me.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem"
        Me.保存ToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.保存ToolStripMenuItem.Text = "保存"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(158, 6)
        '
        'JpegToolStripMenuItem
        '
        Me.JpegToolStripMenuItem.Name = "JpegToolStripMenuItem"
        Me.JpegToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.JpegToolStripMenuItem.Text = "Jpeg"
        '
        'GifToolStripMenuItem
        '
        Me.GifToolStripMenuItem.Name = "GifToolStripMenuItem"
        Me.GifToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.GifToolStripMenuItem.Text = "Gif"
        '
        'PngToolStripMenuItem
        '
        Me.PngToolStripMenuItem.Checked = True
        Me.PngToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PngToolStripMenuItem.Name = "PngToolStripMenuItem"
        Me.PngToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.PngToolStripMenuItem.Text = "Png"
        '
        'BmpToolStripMenuItem
        '
        Me.BmpToolStripMenuItem.Name = "BmpToolStripMenuItem"
        Me.BmpToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.BmpToolStripMenuItem.Text = "Bmp"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(158, 6)
        '
        '自動保存ToolStripMenuItem
        '
        Me.自動保存ToolStripMenuItem.Checked = True
        Me.自動保存ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.自動保存ToolStripMenuItem.Name = "自動保存ToolStripMenuItem"
        Me.自動保存ToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.自動保存ToolStripMenuItem.Text = "自動保存"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(158, 6)
        '
        'フォルダ指定ToolStripMenuItem
        '
        Me.フォルダ指定ToolStripMenuItem.Name = "フォルダ指定ToolStripMenuItem"
        Me.フォルダ指定ToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.フォルダ指定ToolStripMenuItem.Text = "フォルダ指定"
        '
        '保存フォルダを開くToolStripMenuItem
        '
        Me.保存フォルダを開くToolStripMenuItem.Name = "保存フォルダを開くToolStripMenuItem"
        Me.保存フォルダを開くToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.保存フォルダを開くToolStripMenuItem.Text = "保存フォルダを開く"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(158, 6)
        '
        '反転表示ToolStripMenuItem
        '
        Me.反転表示ToolStripMenuItem.Checked = True
        Me.反転表示ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.反転表示ToolStripMenuItem.Name = "反転表示ToolStripMenuItem"
        Me.反転表示ToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.反転表示ToolStripMenuItem.Text = "反転表示"
        '
        'picScreen
        '
        Me.picScreen.ContextMenuStrip = Me.ContextMenuStrip1
        Me.picScreen.Image = CType(resources.GetObject("picScreen.Image"), System.Drawing.Image)
        Me.picScreen.Location = New System.Drawing.Point(47, 0)
        Me.picScreen.Name = "picScreen"
        Me.picScreen.Size = New System.Drawing.Size(48, 48)
        Me.picScreen.TabIndex = 1
        Me.picScreen.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClose.Location = New System.Drawing.Point(120, 0)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(22, 20)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "×"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnMinimized
        '
        Me.btnMinimized.Location = New System.Drawing.Point(98, 0)
        Me.btnMinimized.Name = "btnMinimized"
        Me.btnMinimized.Size = New System.Drawing.Size(20, 20)
        Me.btnMinimized.TabIndex = 3
        Me.btnMinimized.Text = "＿"
        Me.btnMinimized.UseVisualStyleBackColor = True
        '
        'バージョン情報ToolStripMenuItem
        '
        Me.バージョン情報ToolStripMenuItem.Name = "バージョン情報ToolStripMenuItem"
        Me.バージョン情報ToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.バージョン情報ToolStripMenuItem.Text = "バージョン情報"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(158, 6)
        '
        'frmControlCapture
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(144, 48)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ControlBox = False
        Me.Controls.Add(Me.btnMinimized)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.picScreen)
        Me.Controls.Add(Me.picControlCapture)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(144, 48)
        Me.MinimumSize = New System.Drawing.Size(144, 48)
        Me.Name = "frmControlCapture"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        CType(Me.picControlCapture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.picScreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picControlCapture As PictureBox
    Friend WithEvents picScreen As PictureBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents 反転表示ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnClose As Button
    Friend WithEvents btnMinimized As Button
    Friend WithEvents 保存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents JpegToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GifToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PngToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BmpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents フォルダ指定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents 保存フォルダを開くToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 自動保存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents バージョン情報ToolStripMenuItem As ToolStripMenuItem
End Class
