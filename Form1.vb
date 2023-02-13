Imports System.Net.WebRequestMethods
Imports System.Runtime.InteropServices

Public Class Form1
#Region "TitleBar"
    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2

    <DllImportAttribute("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImportAttribute("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub CustomTitle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CustomTitle.MouseDown, Label1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

#End Region

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Private _word As String
    Property word() As String
        Get
            Return _word
        End Get
        Set(ByVal value As String)
            _word = value
        End Set
    End Property
    Private Sub setrandomword()
        Dim words As Array = My.Resources.newwords.Split(",")
        word = words(GetRandom(0, words.Length))
    End Sub

    Private cells(5, 4) As Label

    Private Sub generateboard()
        Dim cellfont As New Font("Candara", 25, FontStyle.Bold)
        For row As Integer = 0 To 5
            For item As Integer = 0 To 4
                Dim cell As New Label
                With cell
                    .Text = ""
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Name = String.Format("lbl_r{0}c{1}", row + 1, item + 1)
                    .ForeColor = Color.White
                    .BackColor = Color.FromArgb(255, 18, 18, 19)
                    .BorderStyle = BorderStyle.FixedSingle
                    .Font = cellfont
                    .AutoSize = False
                    .Size = New System.Drawing.Size(90, 90)
                    .Margin = New Padding(4, 4, 4, 4)
                    'FromLogFont("Candara, 18pt, style=Bold")
                End With
                flowBoard.Controls.Add(cell)
                cells(row, item) = cell

            Next
        Next
        setrandomword()
    End Sub

    Private Sub formLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        generateboard()
    End Sub

    Private _currentrow As Integer = 0
    Property currentrow() As Integer
        Get
            Return _currentrow
        End Get
        Set(value As Integer)
            _currentrow = value
        End Set
    End Property

    Private _currentcell As Integer = 0

    Property currentcell() As Integer
        Get
            Return _currentcell
        End Get
        Set(value As Integer)
            _currentcell = value
        End Set
    End Property


    Private _fullrow As Boolean = False
    Property fullrow() As Boolean
        Get
            If currentcell >= 5 Then
                Return True
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            _fullrow = value
        End Set
    End Property

    Private allowedletters As String = "ABCDEFGHIJKLMNOPQRSTUVXYZ"
    Private Sub KeyboardPress(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' Save the last key pressed
        Static lastKey As Keys = Keys.None
        lastKey = e.KeyCode
        If fullrow AndAlso e.KeyCode = Keys.Enter Then
            '
            '
            '
        End If
        If allowedletters.Contains(e.KeyCode.ToString.ToUpper) AndAlso Not fullrow Then
            cells(currentrow, currentcell).Text = e.KeyCode.ToString
            currentcell += 1
        End If

    End Sub

    Private Sub confirmRow()

    End Sub

End Class




