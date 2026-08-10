Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Public Class DashboardCard
    Inherits PanelControl

    Private ReadOnly lblTitle As New LabelControl()
    Private ReadOnly lblValue As New LabelControl()
    Private ReadOnly lblDescription As New LabelControl()
    Private ReadOnly picIcon As New PictureEdit()

    Public Sub New()

        InitializeCard()

    End Sub

    Private Sub InitializeCard()

        Me.BorderStyle =
            DevExpress.XtraEditors.Controls.BorderStyles.NoBorder

        Me.Padding = New Padding(20)

        Me.Cursor = Cursors.Hand

        InitializeTitle()
        InitializeValue()
        InitializeDescription()
        InitializeIcon()

        Me.Controls.Add(lblDescription)
        Me.Controls.Add(lblValue)
        Me.Controls.Add(lblTitle)
        Me.Controls.Add(picIcon)

        ApplyTheme()

    End Sub

    Private Sub InitializeTitle()

        lblTitle.Appearance.Font =
            New Font("Segoe UI", 10, FontStyle.Regular)

        lblTitle.AutoSizeMode =
            LabelAutoSizeMode.None

        lblTitle.Dock = DockStyle.Top

        lblTitle.Height = 25

    End Sub

    Private Sub InitializeValue()

        lblValue.Appearance.Font =
            New Font("Segoe UI Semibold", 20, FontStyle.Bold)

        lblValue.AutoSizeMode =
            LabelAutoSizeMode.None

        lblValue.Dock = DockStyle.Top

        lblValue.Height = 45

    End Sub

    Private Sub InitializeDescription()

        lblDescription.Appearance.Font =
            New Font("Segoe UI", 9, FontStyle.Regular)

        lblDescription.AutoSizeMode =
            LabelAutoSizeMode.None

        lblDescription.Dock = DockStyle.Fill

    End Sub

    Private Sub InitializeIcon()

        picIcon.Properties.ShowCameraMenuItem = False
        picIcon.Properties.ShowMenu = False

        picIcon.Properties.SizeMode =
            DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom

        picIcon.Size = New Size(48, 48)

        picIcon.Anchor =
            AnchorStyles.Top Or AnchorStyles.Right

        picIcon.Location =
            New Point(Me.Width - 68, 20)

        picIcon.BackColor = Color.Transparent

    End Sub

    '==========================================================
    ' Properties
    '==========================================================

    <Category("Dashboard Card")>
    <Description("The title displayed on the dashboard card.")>
    Public Property CardTitle As String
        Get
            Return lblTitle.Text
        End Get
        Set(value As String)
            lblTitle.Text = value
        End Set
    End Property

    <Category("Dashboard Card")>
    <Description("The main value displayed on the dashboard card.")>
    Public Property CardValue As String
        Get
            Return lblValue.Text
        End Get
        Set(value As String)
            lblValue.Text = value
        End Set
    End Property

    <Category("Dashboard Card")>
    <Description("Additional information displayed on the dashboard card.")>
    Public Property CardDescription As String
        Get
            Return lblDescription.Text
        End Get
        Set(value As String)
            lblDescription.Text = value
        End Set
    End Property

    <Category("Dashboard Card")>
    <Description("Icon displayed on the dashboard card.")>
    Public Property CardIcon As Image
        Get
            Return picIcon.Image
        End Get
        Set(value As Image)
            picIcon.Image = value
        End Set
    End Property

    <Category("Dashboard Card")>
    <Description("Color used to display the main value.")>
    Public Property ValueColor As Color
        Get
            Return lblValue.Appearance.ForeColor
        End Get
        Set(value As Color)
            lblValue.Appearance.ForeColor = value
        End Set
    End Property

    <Category("Dashboard Card")>
    <Description("Background color of the dashboard card.")>
    Public Property CardBackColor As Color
        Get
            Return Me.Appearance.BackColor
        End Get
        Set(value As Color)
            Me.Appearance.BackColor = value
        End Set
    End Property

    '==========================================================
    ' Methods
    '==========================================================

    Public Sub SetData(
        title As String,
        value As String,
        description As String,
        Optional icon As Image = Nothing
    )

        CardTitle = title
        CardValue = value
        CardDescription = description

        If icon IsNot Nothing Then
            CardIcon = icon
        End If

    End Sub

    Public Sub ApplyTheme()

        lblTitle.Appearance.ForeColor =
            Color.DimGray

        lblDescription.Appearance.ForeColor =
            Color.Gray

        If ValueColor = Color.Empty Then
            lblValue.Appearance.ForeColor =
                Color.Black
        End If

        If CardBackColor = Color.Empty Then
            Me.Appearance.BackColor =
                Color.White
        End If

    End Sub

    '==========================================================
    ' Events
    '==========================================================

    Public Event CardClick As EventHandler

    Protected Overrides Sub OnClick(e As EventArgs)

        MyBase.OnClick(e)

        RaiseEvent CardClick(Me, EventArgs.Empty)

    End Sub

End Class
