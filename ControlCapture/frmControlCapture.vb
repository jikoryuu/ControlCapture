Public Class frmControlCapture
    Private Declare Function SendMessage Lib "User32.dll" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Long
    Private Declare Sub ReleaseCapture Lib "User32.dll" ()
    Private Declare Function GetDesktopWindow Lib "user32.dll" () As IntPtr
    Const WM_NCLBUTTONDOWN = &HA1
    Const HTCAPTION = 2
    Private Declare Function GetDC Lib "user32.dll" (ByVal hwnd As IntPtr) As IntPtr
    Private Declare Function BitBlt Lib "gdi32.dll" (
     ByVal hDestDC As IntPtr,
     ByVal x As Int32,
     ByVal y As Int32,
     ByVal nWidth As Int32,
     ByVal nHeight As Int32,
     ByVal hSrcDC As IntPtr,
     ByVal xSrc As Int32,
     ByVal ySrc As Int32,
     ByVal dwRop As Int32) As Long
    Const SRCCOPY As Int32 = &HCC0020
    Private Declare Function ReleaseDC Lib "user32.dll" (
     ByVal hwnd As IntPtr,
     ByVal hdc As IntPtr) As IntPtr
    Private Declare Function GetWindowDC Lib "user32.dll" (ByVal hwnd As IntPtr) As IntPtr
    Private hDesktopWnd As IntPtr
    Private hDesktopDC As IntPtr
    Private Structure POINTAPI
        Public x As Int32
        Public y As Int32
    End Structure
    Private Structure LOGPEN
        Public lopnStyle As Long
        Public lopnWidth As POINTAPI
        Public lopnColor As Long
    End Structure
    Private Structure RECT
        Public Left As Int32
        Public Top As Int32
        Public Right As Int32
        Public Bottom As Int32
    End Structure
    Private Declare Function GetWindowRect Lib "user32" (ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    Private Declare Function GetCursorPos Lib "user32.dll" (ByRef lpPoint As POINTAPI) As Long
    Private Declare Function WindowFromPoint Lib "user32.dll" (
     ByVal xPoint As Int32,
     ByVal yPoint As Int32) As IntPtr
    Private pCursor As POINTAPI
    Private Declare Function InvertRect Lib "user32.dll" (
     ByVal hdc As IntPtr,
     ByRef lpRect As RECT) As Boolean
    Private hOldControl As IntPtr
    Private Declare Function CreateDC Lib "gdi32.dll" Alias "CreateDCA" (
     ByVal lpDriverName As String,
     ByVal lpDeviceName As String,
     ByVal lpOutput As String,
     ByVal lpInitData As Int32) As IntPtr
    'ByRef lpInitData As DEVMODE) As IntPtr
    'Private Structure DEVMODE
    '    Public dmDeviceName As String '* CCHDEVICENAME
    '    Public dmSpecVersion As Int16
    '    Public dmDriverVersion As Int16
    '    Public dmSize As Int16
    '    Public dmDriverExtra As Int16
    '    Public dmFields As Int32
    '    Public dmOrientation As Int16
    '    Public dmPaperSize As Int16
    '    Public dmPaperLength As Int16
    '    Public dmPaperWidth As Int16
    '    Public dmScale As Int16
    '    Public dmCopies As Int16
    '    Public dmDefaultSource As Int16
    '    Public dmPrintQuality As Int16
    '    Public dmColor As Int16
    '    Public dmDuplex As Int16
    '    Public dmYResolution As Int16
    '    Public dmTTOption As Int16
    '    Public dmCollate As Int16
    '    Public dmFormName As String '* CCHFORMNAME
    '    Public dmUnusedPadding As Int16
    '    Public dmBitsPerPel As Int16
    '    Public dmPelsWidth As Int32
    '    Public dmPelsHeight As Int32
    '    Public dmDisplayFlags As Int32
    '    Public dmDisplayFrequency As Int32
    'End Structure
    Private Declare Function CreateCompatibleDC Lib "gdi32.dll" (ByVal hdc As IntPtr) As IntPtr
    Private Declare Function SelectObject Lib "gdi32.dll" (
     ByVal hdc As IntPtr,
     ByVal hObject As IntPtr) As IntPtr
    Private Declare Function OpenClipboard Lib "user32.dll" (ByVal hwnd As IntPtr) As Boolean
    Private Declare Function EmptyClipboard Lib "user32.dll" () As Boolean
    Private Declare Function SetClipboardData Lib "user32.dll" (
     ByVal wFormat As Int32,
     ByVal hMem As IntPtr) As IntPtr
    Private Declare Function CloseClipboard Lib "user32.dll" () As Boolean
    Private Declare Function CreateCompatibleBitmap Lib "gdi32.dll" (
     ByVal hdc As IntPtr,
     ByVal nWidth As Int32,
     ByVal nHeight As Int32) As Int32
    Private Const CF_BITMAP As Long = 2
    Private Declare Function DeleteDC Lib "gdi32.dll" (
     ByVal hdc As IntPtr) As Boolean
    Private Enum DWMWINDOWATTRIBUTE
        DWMWA_NCRENDERING_ENABLED = 1
        DWMWA_NCRENDERING_POLICY
        DWMWA_TRANSITIONS_FORCEDISABLED
        DWMWA_ALLOW_NCPAINT
        DWMWA_CAPTION_BUTTON_BOUNDS
        DWMWA_NONCLIENT_RTL_LAYOUT
        DWMWA_FORCE_ICONIC_REPRESENTATION
        DWMWA_FLIP3D_POLICY
        DWMWA_EXTENDED_FRAME_BOUNDS
        DWMWA_LAST
    End Enum
    Private Declare Function DwmGetWindowAttribute Lib "dwmapi.dll" (
     ByVal hwnd As IntPtr,
     ByVal dwAttribute As DWMWINDOWATTRIBUTE,
     ByRef pvAttribute As RECT,
     ByVal cbAttribute As Int32) As Boolean

    Private psSaveFolder As String

    Private Sub frmControlCapture_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            Call ReleaseCapture()
            Call SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0&)
        End If
    End Sub

    Private Sub picScreen_Click(sender As Object, e As EventArgs) Handles picScreen.Click
        Me.Hide()
        System.Threading.Thread.Sleep(1000)
        Dim hDeskTop As Long
        hDeskTop = GetDesktopWindow()
        Dim bmp As New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.CopyFromScreen(New Point(0, 0), New Point(0, 0), bmp.Size)
        g.Dispose()
        With frmScreen
            .Top = 0
            .Left = 0
            .Width = Screen.GetBounds(Me).Width
            .Height = Screen.GetBounds(Me).Height
            .Show()
            With .picScreen
                .Top = 0
                .Left = 0
                .Width = Screen.GetBounds(Me).Width
                .Height = Screen.GetBounds(Me).Height
                .Image = bmp
            End With
        End With
    End Sub

    Private Sub picControlCapture_MouseMove(sender As Object, e As MouseEventArgs) Handles picControlCapture.MouseMove
        Dim rDesktop As RECT
        Dim rDesktop2 As RECT
        Dim pAPI As POINTAPI
        Dim hControl As IntPtr
        If e.Button = MouseButtons.Left Then
            If 反転表示ToolStripMenuItem.Checked = False Then Exit Sub
            Call GetCursorPos(pAPI)
            hControl = WindowFromPoint(pAPI.x, pAPI.y)
            If (hOldControl <> hControl) Then
                If hOldControl <> 0 Then
                    If DwmGetWindowAttribute(hOldControl, DWMWINDOWATTRIBUTE.DWMWA_EXTENDED_FRAME_BOUNDS, rDesktop, System.Runtime.InteropServices.Marshal.SizeOf(rDesktop)) = True Then
                        GetWindowRect(hOldControl, rDesktop)
                    End If
                    hDesktopWnd = GetDesktopWindow()
                    hDesktopDC = GetWindowDC(hDesktopWnd)
                    InvertRect(hDesktopDC, rDesktop)
                    rDesktop2.Top = rDesktop.Top + 5
                    rDesktop2.Left = rDesktop.Left + 5
                    rDesktop2.Bottom = rDesktop.Bottom - 5
                    rDesktop2.Right = rDesktop.Right - 5
                    InvertRect(hDesktopDC, rDesktop2)
                    Call ReleaseDC(hDesktopWnd, hDesktopDC)
                End If
                hOldControl = hControl
                If DwmGetWindowAttribute(hControl, DWMWINDOWATTRIBUTE.DWMWA_EXTENDED_FRAME_BOUNDS, rDesktop, System.Runtime.InteropServices.Marshal.SizeOf(rDesktop)) = True Then
                    GetWindowRect(hControl, rDesktop)
                End If
                hDesktopWnd = GetDesktopWindow()
                hDesktopDC = GetWindowDC(hDesktopWnd)
                InvertRect(hDesktopDC, rDesktop)
                rDesktop2.Top = rDesktop.Top + 5
                rDesktop2.Left = rDesktop.Left + 5
                rDesktop2.Bottom = rDesktop.Bottom - 5
                rDesktop2.Right = rDesktop.Right - 5
                InvertRect(hDesktopDC, rDesktop2)
                Call ReleaseDC(hDesktopWnd, hDesktopDC)
            End If
        End If

    End Sub

    Private Sub picControlCapture_MouseUp(sender As Object, e As MouseEventArgs) Handles picControlCapture.MouseUp
        Dim rDesktop As RECT
        Dim rDesktop2 As RECT
        Dim pAPI As POINTAPI
        Dim hControl As IntPtr
        hOldControl = 0
        If e.Button = MouseButtons.Left Then
            Call GetCursorPos(pAPI)
            hControl = WindowFromPoint(pAPI.x, pAPI.y)
            If DwmGetWindowAttribute(hControl, DWMWINDOWATTRIBUTE.DWMWA_EXTENDED_FRAME_BOUNDS, rDesktop, System.Runtime.InteropServices.Marshal.SizeOf(rDesktop)) = True Then
                GetWindowRect(hControl, rDesktop)
            End If
            hDesktopWnd = GetDesktopWindow()
            hDesktopDC = GetWindowDC(hDesktopWnd)
            If 反転表示ToolStripMenuItem.Checked Then
                InvertRect(hDesktopDC, rDesktop)
                rDesktop2.Top = rDesktop.Top + 5
                rDesktop2.Left = rDesktop.Left + 5
                rDesktop2.Bottom = rDesktop.Bottom - 5
                rDesktop2.Right = rDesktop.Right - 5
                InvertRect(hDesktopDC, rDesktop2)
            End If
            Dim hdcScreen As IntPtr
            Dim hdc_mem_screen As IntPtr
            Dim hBitmap As IntPtr
            hdcScreen = CreateDC("DISPLAY", vbNullString, vbNullString, 0&)
            hdc_mem_screen = CreateCompatibleDC(hdcScreen)
            hBitmap = CreateCompatibleBitmap(hdcScreen, rDesktop.Right - rDesktop.Left, rDesktop.Bottom - rDesktop.Top)
            Call SelectObject(hdc_mem_screen, hBitmap)
            Call BitBlt(hdc_mem_screen, 0&, 0&, rDesktop.Right - rDesktop.Left, rDesktop.Bottom - rDesktop.Top, hDesktopDC, rDesktop.Left, rDesktop.Top, SRCCOPY)
            If OpenClipboard(hDesktopWnd) = True Then
                Call EmptyClipboard()
                Call SetClipboardData(CF_BITMAP, hBitmap)
                Call CloseClipboard()
            End If
            Call DeleteDC(hdc_mem_screen)
            Call ReleaseDC(hDesktopWnd, hDesktopDC)

            Call SaveImage()
        End If

    End Sub

    Private Sub 反転表示ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 反転表示ToolStripMenuItem.Click
        反転表示ToolStripMenuItem.Checked = Not 反転表示ToolStripMenuItem.Checked
    End Sub

    Private Sub JpegToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JpegToolStripMenuItem.Click
        JpegToolStripMenuItem.Checked = True
        GifToolStripMenuItem.Checked = False
        BmpToolStripMenuItem.Checked = False
        PngToolStripMenuItem.Checked = False
    End Sub

    Private Sub GifToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GifToolStripMenuItem.Click
        JpegToolStripMenuItem.Checked = False
        GifToolStripMenuItem.Checked = True
        BmpToolStripMenuItem.Checked = False
        PngToolStripMenuItem.Checked = False
    End Sub

    Private Sub PngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PngToolStripMenuItem.Click
        JpegToolStripMenuItem.Checked = False
        GifToolStripMenuItem.Checked = False
        BmpToolStripMenuItem.Checked = False
        PngToolStripMenuItem.Checked = True
    End Sub

    Private Sub BmpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BmpToolStripMenuItem.Click
        JpegToolStripMenuItem.Checked = False
        GifToolStripMenuItem.Checked = False
        BmpToolStripMenuItem.Checked = True
        PngToolStripMenuItem.Checked = False
    End Sub

    Private Sub 保存ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存ToolStripMenuItem.Click
        Call SaveImage(True)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMinimized_Click(sender As Object, e As EventArgs) Handles btnMinimized.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        btnClose.BackColor = System.Drawing.SystemColors.ControlLight
    End Sub

    Private Sub btnClose_MouseMove(sender As Object, e As MouseEventArgs) Handles btnClose.MouseMove
        btnClose.BackColor = System.Drawing.Color.Red
    End Sub

    Public Sub SaveImage(Optional ByVal vbSaveFile As Boolean = False)
        Dim img As Image = Clipboard.GetImage()
        If vbSaveFile = False Then
            If 自動保存ToolStripMenuItem.Checked = False Then Return
        End If
        If img IsNot Nothing Then
            Dim oDateTime As DateTime
            Dim sDateTime As String
            oDateTime = DateTime.Now
            sDateTime = oDateTime.ToString("yyyyMMddHHmmss") & "." & oDateTime.Millisecond
            Select Case True
                Case JpegToolStripMenuItem.Checked
                    img.Save(psSaveFolder & sDateTime & ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg)
                Case GifToolStripMenuItem.Checked
                    img.Save(psSaveFolder & sDateTime & ".gif", System.Drawing.Imaging.ImageFormat.Gif)
                Case BmpToolStripMenuItem.Checked
                    img.Save(psSaveFolder & sDateTime & ".bmp", System.Drawing.Imaging.ImageFormat.Bmp)
                Case PngToolStripMenuItem.Checked
                    img.Save(psSaveFolder & sDateTime & ".png", System.Drawing.Imaging.ImageFormat.Png)
            End Select
        End If
    End Sub

    Private Sub フォルダ指定ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles フォルダ指定ToolStripMenuItem.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            psSaveFolder = FolderBrowserDialog1.SelectedPath & "\"
        End If
    End Sub

    Private Sub frmControlCapture_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            ' ドラッグ中のファイルやディレクトリの取得
            Dim drags() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
            For Each d As String In drags
                If Not System.IO.File.Exists(d) Then Return
                Select Case Split(d, ".")(UBound(Split(d, "."))).ToLower
                    Case "jpeg"
                    Case "jpg"
                    Case "png"
                    Case "bmp"
                    Case "gif"
                    Case Else
                        Return
                End Select
            Next
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub frmControlCapture_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        Dim saFiles = CType(e.Data.GetData(DataFormats.FileDrop), String())
        For i As Long = 0 To UBound(saFiles)
            Dim oImage As Image = Image.FromFile(saFiles(i))
            Dim oImage2 As Image
            Dim oSize As New Size(oImage.Width * 0.5, oImage.Height * 0.5)
            Dim sFileType As String
            oImage2 = oImage.GetThumbnailImage(oSize.Width, oSize.Height, Nothing, IntPtr.Zero)
            oImage.Dispose()
            sFileType = GetFileExists(GetFileName(saFiles(i))).ToLower
            Select Case sFileType
                Case "jpeg"
                    oImage2.Save(GetFolderPath(saFiles(i)) & "\thumb_" & GetOrignFileName(GetFileName(saFiles(i))) & "." & GetFileExists(GetFileName(saFiles(i))), Imaging.ImageFormat.Jpeg)
                Case "jpg"
                    oImage2.Save(GetFolderPath(saFiles(i)) & "\thumb_" & GetOrignFileName(GetFileName(saFiles(i))) & "." & GetFileExists(GetFileName(saFiles(i))), Imaging.ImageFormat.Jpeg)
                Case "png"
                    oImage2.Save(GetFolderPath(saFiles(i)) & "\thumb_" & GetOrignFileName(GetFileName(saFiles(i))) & "." & GetFileExists(GetFileName(saFiles(i))), Imaging.ImageFormat.Png)
                Case "bmp"
                    oImage2.Save(GetFolderPath(saFiles(i)) & "\thumb_" & GetOrignFileName(GetFileName(saFiles(i))) & "." & GetFileExists(GetFileName(saFiles(i))), Imaging.ImageFormat.Bmp)
                Case "gif"
                    oImage2.Save(GetFolderPath(saFiles(i)) & "\thumb_" & GetOrignFileName(GetFileName(saFiles(i))) & "." & GetFileExists(GetFileName(saFiles(i))), Imaging.ImageFormat.Gif)
            End Select
            oImage2.Dispose()
        Next
    End Sub

    Private Function GetFolderPath(ByVal vsFilePath As String) As String
        Dim i As Long
        Dim sFolder As String = Split(vsFilePath, "\")(0)
        For i = 1 To UBound(Split(vsFilePath, "\")) - 1
            sFolder = sFolder & "\" & Split(vsFilePath, "\")(i)
        Next
        GetFolderPath = sFolder
    End Function

    Private Function GetOrignFileName(ByVal vsFileName As String) As String
        Dim i As Long
        Dim sOrignFileName As String = Split(vsFileName, ".")(0)
        For i = 1 To UBound(Split(vsFileName, ".")) - 1
            sOrignFileName = sOrignFileName & "." & Split(vsFileName, ".")(i)
        Next
        GetOrignFileName = sOrignFileName
    End Function

    Private Function GetFileExists(ByVal vsFileName As String) As String
        GetFileExists = Split(vsFileName, ".")(UBound(Split(vsFileName, ".")))
    End Function

    Private Function GetFileName(ByVal vsFilePath As String) As String
        GetFileName = Split(vsFilePath, "\")(UBound(Split(vsFilePath, "\")))
    End Function

    Private Sub 保存フォルダを開くToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存フォルダを開くToolStripMenuItem.Click
        If psSaveFolder = "" Then
            System.Diagnostics.Process.Start(My.Application.Info.DirectoryPath.ToString())
        Else
            System.Diagnostics.Process.Start(psSaveFolder)
        End If
    End Sub

    Private Sub 自動保存ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 自動保存ToolStripMenuItem.Click
        自動保存ToolStripMenuItem.Checked = Not 自動保存ToolStripMenuItem.Checked
    End Sub

    Private Sub バージョン情報ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles バージョン情報ToolStripMenuItem.Click
        Call MsgBox("ControlCapture ver 4.1", vbOKOnly, "バージョン情報")
    End Sub
End Class
