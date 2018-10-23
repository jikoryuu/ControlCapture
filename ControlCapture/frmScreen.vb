Imports System.ComponentModel

Public Class frmScreen
    Private Structure RECT
        Public Left As Int32
        Public Top As Int32
        Public Right As Int32
        Public Bottom As Int32
    End Structure
    Private Declare Function DrawFocusRect Lib "user32" (ByVal hDC As IntPtr, ByRef lpRect As RECT) As Boolean
    Private Declare Function GetDC Lib "user32" (ByVal hWnd As IntPtr) As IntPtr
    Declare Function ReleaseDC Lib "user32" (ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As Boolean
    Private Structure POINTAPI
        Public x As Int32
        Public y As Int32
    End Structure
    Private Declare Function GetCursorPos Lib "user32.dll" (ByRef lpPoint As POINTAPI) As Long
    Private pPoint As POINTAPI
    Private Declare Function CreateDC Lib "gdi32.dll" Alias "CreateDCA" (
     ByVal lpDriverName As String,
     ByVal lpDeviceName As String,
     ByVal lpOutput As String,
     ByVal lpInitData As Int32) As IntPtr
    Private Declare Function CreateCompatibleDC Lib "gdi32.dll" (ByVal hdc As IntPtr) As IntPtr
    Private Declare Function CreateCompatibleBitmap Lib "gdi32.dll" (
     ByVal hdc As IntPtr,
     ByVal nWidth As Int32,
     ByVal nHeight As Int32) As Int32
    Private Declare Function SelectObject Lib "gdi32.dll" (
     ByVal hdc As IntPtr,
     ByVal hObject As IntPtr) As IntPtr
    Private Const SRCCOPY As Int32 = &HCC0020
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
    Private Declare Function OpenClipboard Lib "user32.dll" (ByVal hwnd As IntPtr) As Boolean
    Private Declare Function EmptyClipboard Lib "user32.dll" () As Boolean
    Private Declare Function SetClipboardData Lib "user32.dll" (
     ByVal wFormat As Int32,
     ByVal hMem As IntPtr) As IntPtr
    Private Declare Function CloseClipboard Lib "user32.dll" () As Boolean
    Private Declare Function DeleteDC Lib "gdi32.dll" (
     ByVal hdc As IntPtr) As Boolean
    Private Const CF_BITMAP As Long = 2


    Private Sub picScreen_MouseDown(sender As Object, e As MouseEventArgs) Handles picScreen.MouseDown
        If e.Button = MouseButtons.Left Then
            pPoint.x = e.X
            pPoint.y = e.Y
        End If

    End Sub

    Private Sub picScreen_MouseUp(sender As Object, e As MouseEventArgs) Handles picScreen.MouseUp
        If e.Button = MouseButtons.Left Then
            picScreen.Refresh()
            Dim rRect As RECT
            Dim hDc As IntPtr
            If pPoint.x < e.X Then
                rRect.Left = pPoint.x
                rRect.Right = e.X '- pPoint.x
            Else
                rRect.Left = e.X
                rRect.Right = pPoint.x '- e.X
            End If
            If pPoint.y < e.Y Then
                rRect.Top = pPoint.y
                rRect.Bottom = e.Y '- pPoint.y
            Else
                rRect.Top = e.Y
                rRect.Bottom = pPoint.y '- e.Y
            End If
            hDc = GetDC(picScreen.Handle)

            Dim hdcScreen As IntPtr
            Dim hdc_mem_screen As IntPtr
            Dim hBitmap As IntPtr
            hdcScreen = CreateDC("DISPLAY", vbNullString, vbNullString, 0&)
            hdc_mem_screen = CreateCompatibleDC(hdcScreen)
            hBitmap = CreateCompatibleBitmap(hdcScreen, rRect.Right - rRect.Left, rRect.Bottom - rRect.Top)
            Call SelectObject(hdc_mem_screen, hBitmap)
            Call BitBlt(hdc_mem_screen, 0&, 0&, rRect.Right - rRect.Left, rRect.Bottom - rRect.Top, hDc, rRect.Left, rRect.Top, SRCCOPY)
            If OpenClipboard(picScreen.Handle) = True Then
                Call EmptyClipboard()
                Call SetClipboardData(CF_BITMAP, hBitmap)
                Call CloseClipboard()
            End If
            Call DeleteDC(hdc_mem_screen)
            Call ReleaseDC(picScreen.Handle, hDc)

            Me.Hide()
            frmControlCapture.Show()

            Call frmControlCapture.SaveImage()
        End If

    End Sub

    Private Sub picScreen_MouseMove(sender As Object, e As MouseEventArgs) Handles picScreen.MouseMove

        If e.Button = MouseButtons.Left Then
            picScreen.Refresh()
            Dim rRect As RECT
            Dim hDc As IntPtr
            If pPoint.x < e.X Then
                rRect.Left = pPoint.x
                rRect.Right = e.X '- pPoint.x
            Else
                rRect.Left = e.X
                rRect.Right = pPoint.x '- e.X
            End If
            If pPoint.y < e.Y Then
                rRect.Top = pPoint.y
                rRect.Bottom = e.Y '- pPoint.y
            Else
                rRect.Top = e.Y
                rRect.Bottom = pPoint.y '- e.Y
            End If
            hDc = GetDC(picScreen.Handle)
            DrawFocusRect(hDc, rRect)
            ReleaseDC(picScreen.Handle, hDc)
        End If

    End Sub

End Class