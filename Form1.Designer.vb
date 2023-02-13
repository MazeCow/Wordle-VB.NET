<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.CustomTitle = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.flowBoard = New System.Windows.Forms.FlowLayoutPanel()
        Me.CustomTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomTitle
        '
        Me.CustomTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.CustomTitle.Controls.Add(Me.Label1)
        Me.CustomTitle.Controls.Add(Me.btnExit)
        Me.CustomTitle.Controls.Add(Me.btnMinimize)
        Me.CustomTitle.Location = New System.Drawing.Point(0, 0)
        Me.CustomTitle.Name = "CustomTitle"
        Me.CustomTitle.Size = New System.Drawing.Size(800, 61)
        Me.CustomTitle.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Candara", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(156, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(210, 59)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "WORDLE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(458, -6)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(63, 75)
        Me.btnExit.TabIndex = 1
        Me.btnExit.TabStop = False
        Me.btnExit.Text = "X"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnMinimize
        '
        Me.btnMinimize.BackColor = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.btnMinimize.FlatAppearance.BorderSize = 0
        Me.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimize.Font = New System.Drawing.Font("MS Reference Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinimize.ForeColor = System.Drawing.Color.White
        Me.btnMinimize.Location = New System.Drawing.Point(396, -13)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(63, 75)
        Me.btnMinimize.TabIndex = 2
        Me.btnMinimize.TabStop = False
        Me.btnMinimize.Text = "__"
        Me.btnMinimize.UseVisualStyleBackColor = False
        '
        'flowBoard
        '
        Me.flowBoard.Location = New System.Drawing.Point(15, 77)
        Me.flowBoard.Name = "flowBoard"
        Me.flowBoard.Size = New System.Drawing.Size(490, 599)
        Me.flowBoard.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(19, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(520, 691)
        Me.Controls.Add(Me.flowBoard)
        Me.Controls.Add(Me.CustomTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.Text = "Wordle!"
        Me.CustomTitle.ResumeLayout(False)
        Me.CustomTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CustomTitle As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnMinimize As Button
    Friend WithEvents flowBoard As FlowLayoutPanel
End Class
