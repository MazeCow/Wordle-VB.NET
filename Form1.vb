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

    'IMPORTANT! Replace the CustomTitle and Label1 objects with whatever objects you used in your custom title bar (this does not include the exit or minimize buttons).
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
            Return _word.ToUpper
        End Get
        Set(ByVal value As String)
            _word = value
        End Set
    End Property

    Private selectwords() As String = My.Resources.selected.Split(",")
    Private choicewords() As String = My.Resources.choices.Split(",")

    Private Sub setrandomword()
        word = selectwords(GetRandom(0, selectwords.Length))
    End Sub

    Private cells(5, 4) As Label

    Private Sub generateboard()
        Me.Focus()
        endofgame = False
        endofgame_forreal = False
        flowBoard.Controls.Clear()
        setrandomword()
        currentcell = 0
        currentrow = 0
        For cell As Integer = 0 To cells.Length - 1
        Next
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
                End With
                flowBoard.Controls.Add(cell)
                cells(row, item) = cell
            Next
        Next
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

    Private endofgame_forreal As Boolean = False

    Private _lastrow As Boolean = False

    Property lastrow() As Boolean
        Get
            If currentrow >= 5 Then
                Return True
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            _lastrow = value
        End Set
    End Property

    Private allowedletters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    Private Sub KeyboardPress(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, CustomTitle.KeyDown, lblResults.KeyDown
        If Not endofgame_forreal Then

            'save the last key pressed
            Static lastKey As Keys = Keys.None
            lastKey = e.KeyCode

            'type letter
            If allowedletters.Contains(e.KeyCode.ToString.ToUpper) AndAlso Not fullrow Then
                cells(currentrow, currentcell).Text = e.KeyCode.ToString
                currentcell += 1
                If (currentcell < 5) Then
                    cells(currentrow, currentcell).Focus()
                End If
            End If

            'backspace
            If e.KeyCode = Keys.Back Then
                If currentcell >= 1 Then
                    currentcell -= 1
                    cells(currentrow, currentcell).Text = ""
                    cells(currentrow, currentcell).Focus()
                End If
            End If

            'enter
            If fullrow AndAlso e.KeyCode = Keys.Return AndAlso validword() Then
                confirmRow()
            End If

        End If
    End Sub

    Dim _end As Boolean = True
    Property endofgame As Boolean
        Get
            _end = True
            For cellnum As Integer = 0 To 4
                Dim cellobject As Label = cells(currentrow, cellnum)
                If word(cellnum) <> cellobject.Text Then
                    _end = False
                End If
            Next
            Return _end
        End Get
        Set(value As Boolean)
            _end = value
        End Set
    End Property

    Private Function validword()
        Dim word As String = ""
        For i As Integer = 0 To 4
            word += cells(currentrow, i).Text.ToUpper()
        Next
        Dim valid_word As Boolean = False
        For x As Integer = 0 To choicewords.Length - 1
            If choicewords(x).ToUpper = word Then
                valid_word = True
            End If
        Next
        Return valid_word
    End Function

    Private Sub confirmRow()
        Dim wordcounts As New Dictionary(Of String, Integer)

        'counts how many of each letter there are in a row
        For i As Integer = 0 To 4
            If Not wordcounts.ContainsKey(word(i)) Then
                wordcounts(word(i)) = 1
            Else
                wordcounts(word(i)) += 1
            End If
        Next

        Dim changecolor = Sub(label As Label, color As Color) label.BackColor = color

        For i As Integer = 0 To 4
            If cells(currentrow, i).Text = word(i) Then
                changecolor(cells(currentrow, i), Color.Green)
                wordcounts(cells(currentrow, i).Text) -= 1
            End If
        Next

        For i As Integer = 0 To 4
            If word.Contains(cells(currentrow, i).Text) AndAlso cells(currentrow, i).Text <> word(i) AndAlso wordcounts(cells(currentrow, i).Text) > 0 Then
                changecolor(cells(currentrow, i), Color.FromArgb(255, 100, 100, 0))
                wordcounts(cells(currentrow, i).Text) -= 1
            End If
        Next

        If Not endofgame_forreal AndAlso Not endofgame Then
            If Not lastrow Then
                currentrow += 1
            Else
                pnlRestart.Visible = True
                lblResults.Text = String.Format("YOU LOSE! THE WORD WAS {0}. PLAY AGAIN?", word.ToUpper)
            End If
            currentcell = 0
        ElseIf endofgame Then
            endofgame_forreal = True
            pnlRestart.Visible = True
            lblResults.Text = String.Format("YOU WIN! THE WORD WAS {0}. PLAY AGAIN?", word.ToUpper)
        End If
    End Sub

    Private Sub btnPlayAgainNo_Click(sender As Object, e As EventArgs) Handles btnPlayAgainNo.Click
        Me.Close()
    End Sub

    Private Sub btnPlayAgainYes_Click(sender As Object, e As EventArgs) Handles btnPlayAgainYes.Click
        pnlRestart.Visible = False
        generateboard()
    End Sub

    Private Sub lblResults_Click(sender As Object, e As EventArgs)

    End Sub
End Class




