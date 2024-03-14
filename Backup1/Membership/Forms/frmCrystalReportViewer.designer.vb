<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrystalReportViewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.crptViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crptViewer
        '
        Me.crptViewer.ActiveViewIndex = -1
        Me.crptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crptViewer.DisplayGroupTree = False
        Me.crptViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crptViewer.Location = New System.Drawing.Point(0, 0)
        Me.crptViewer.Name = "crptViewer"
        Me.crptViewer.SelectionFormula = ""
        Me.crptViewer.Size = New System.Drawing.Size(784, 562)
        Me.crptViewer.TabIndex = 0
        Me.crptViewer.ViewTimeSelectionFormula = ""
        '
        'frmCrystalReportViewer
        '
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.crptViewer)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCrystalReportViewer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents crptViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
