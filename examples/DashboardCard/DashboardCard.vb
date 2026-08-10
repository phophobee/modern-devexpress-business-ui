Imports System.Drawing
Imports DevExpress.XtraEditors

Public Class DashboardCard
    Inherits PanelControl

    Private ReadOnly lblTitle As New LabelControl()
    Private ReadOnly lblValue As New LabelControl()
    Private ReadOnly lblDescription As New LabelControl()

    Public Sub New()
        InitializeCard()
    End Sub

    Private Sub InitializeCard()

        Me.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder

        Me.Padding = New Padding(20)

        lblTitle.Appearance.Font =
            New Font("Segoe UI", 10, FontStyle.Regular)

        lblTitle.Appearance.ForeColor =
            Color.DimGray

        lblTitle.AutoSizeMode =
            LabelAutoSizeMode.None

        lblTitle.Dock = DockStyle.Top

        lblTitle.Height = 25

        lblValue.Appearance.Font =
            New Font("Segoe UI Semibold", 20, FontStyle.Bold)

        lblValue.Appearance.ForeColor =
            Color.Black

        lblValue.AutoSizeMode =
            LabelAutoSizeMode.None

        lblValue.Dock = DockStyle.Top

        lblValue.Height = 45

        lblDescription.Appearance.Font =
            New Font("Segoe UI", 9, FontStyle.Regular)

        lblDescription.Appearance.ForeColor =
            Color.Gray

        lblDescription.AutoSizeMode =
            LabelAutoSizeMode.None

        lblDescription.Dock = DockStyle.Fill

        Me.Controls.Add(lblDescription)
        Me.Controls.Add(lblValue)
        Me.Controls.Add(lblTitle)

    End Sub

    Public Property CardTitle As String
        Get
            Return lblTitle.Text
        End Get
        Set(value As String)
            lblTitle.Text = value
        End Set
    End Property

    Public Property CardValue As String
        Get
            Return lblValue.Text
        End Get
        Set(value As String)
            lblValue.Text = value
        End Set
    End Property

    Public Property CardDescription As String
        Get
            Return lblDescription.Text
        End Get
        Set(value As String)
            lblDescription.Text = value
        End Set
    End Property

End Class
