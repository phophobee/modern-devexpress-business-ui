Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace Components

    Public Class DashboardCard
        Inherits PanelControl

        Private ReadOnly headerPanel As New PanelControl()
        Private ReadOnly lblTitle As New LabelControl()
        Private ReadOnly lblValue As New LabelControl()
        Private ReadOnly lblDescription As New LabelControl()
        Private ReadOnly picIcon As New PictureEdit()

        Private normalBackColor As Color =
            Color.White

        Private hoverBackColor As Color =
            Color.FromArgb(245, 247, 250)

        Public Sub New()

            InitializeCard()

        End Sub


        '==================================================
        ' Initialize Card
        '==================================================

        Private Sub InitializeCard()

            Me.BorderStyle =
                DevExpress.XtraEditors.Controls.BorderStyles.Simple

            Me.Padding =
                New Padding(10)

            Me.Margin =
                New Padding(5)

            Me.Cursor =
                Cursors.Hand

            Me.LookAndFeel.UseDefaultLookAndFeel =
                False

            Me.LookAndFeel.Style =
                DevExpress.LookAndFeel.LookAndFeelStyle.Flat

            Me.Appearance.Options.UseBackColor =
                True

            Me.Appearance.Options.UseBorderColor =
                True

            Me.Appearance.BackColor =
                Color.White

            Me.Appearance.BorderColor =
                Color.FromArgb(225, 228, 232)


            InitializeHeader()

            InitializeTitle()

            InitializeValue()

            InitializeDescription()

            InitializeIcon()


            '==================================================
            ' Add Controls
            '==================================================

            headerPanel.Controls.Add(picIcon)

            headerPanel.Controls.Add(lblTitle)


            Me.Controls.Add(lblDescription)

            Me.Controls.Add(lblValue)

            Me.Controls.Add(headerPanel)


            '==================================================
            ' Events
            '==================================================

            AddHandler Me.Click,
                AddressOf Card_Click

            AddHandler headerPanel.Click,
                AddressOf Card_Click

            AddHandler lblTitle.Click,
                AddressOf ChildControl_Click

            AddHandler lblValue.Click,
                AddressOf ChildControl_Click

            AddHandler lblDescription.Click,
                AddressOf ChildControl_Click

            AddHandler picIcon.Click,
                AddressOf ChildControl_Click


            AddHandler Me.MouseEnter,
                AddressOf Card_MouseEnter

            AddHandler Me.MouseLeave,
                AddressOf Card_MouseLeave

            AddHandler headerPanel.MouseEnter,
                AddressOf Card_MouseEnter

            AddHandler headerPanel.MouseLeave,
                AddressOf Card_MouseLeave

            AddHandler lblTitle.MouseEnter,
                AddressOf Card_MouseEnter

            AddHandler lblTitle.MouseLeave,
                AddressOf Card_MouseLeave

            AddHandler lblValue.MouseEnter,
                AddressOf Card_MouseEnter

            AddHandler lblValue.MouseLeave,
                AddressOf Card_MouseLeave

            AddHandler lblDescription.MouseEnter,
                AddressOf Card_MouseEnter

            AddHandler lblDescription.MouseLeave,
                AddressOf Card_MouseLeave

            AddHandler picIcon.MouseEnter,
                AddressOf Card_MouseEnter

            AddHandler picIcon.MouseLeave,
                AddressOf Card_MouseLeave

        End Sub


        '==================================================
        ' Header
        '==================================================

        Private Sub InitializeHeader()

            headerPanel.Dock =
                DockStyle.Top

            headerPanel.Height =
                40

            headerPanel.BorderStyle =
                DevExpress.XtraEditors.Controls.BorderStyles.NoBorder

            headerPanel.Appearance.Options.UseBackColor =
                True

            headerPanel.Appearance.BackColor =
                Color.Transparent

            headerPanel.LookAndFeel.UseDefaultLookAndFeel =
                False

            headerPanel.LookAndFeel.Style =
                DevExpress.LookAndFeel.LookAndFeelStyle.Flat

        End Sub


        '==================================================
        ' Title
        '==================================================

        Private Sub InitializeTitle()

            lblTitle.Appearance.Font =
                New Font(
                    "Segoe UI",
                    9.5!,
                    FontStyle.Regular
                )

            lblTitle.Appearance.ForeColor =
                Color.DimGray

            lblTitle.Appearance.Options.UseForeColor =
                True

            lblTitle.AutoSizeMode =
                LabelAutoSizeMode.None

            lblTitle.Location =
                New Point(
                    0,
                    2
                )

            lblTitle.Size =
                New Size(
                    180,
                    20
                )

        End Sub


        '==================================================
        ' Value
        '==================================================

        Private Sub InitializeValue()

            lblValue.Appearance.Font =
                New Font(
                    "Segoe UI Semibold",
                    18.0!,
                    FontStyle.Bold
                )

            lblValue.Appearance.Options.UseForeColor =
                True

            lblValue.AutoSizeMode =
                LabelAutoSizeMode.None

            lblValue.Dock =
                DockStyle.Top

            lblValue.Height =
                40

        End Sub


        '==================================================
        ' Description
        '==================================================

        Private Sub InitializeDescription()

            lblDescription.Appearance.Font =
                New Font(
                    "Segoe UI",
                    9.0!,
                    FontStyle.Regular
                )

            lblDescription.Appearance.Options.UseForeColor =
                True

            lblDescription.AutoSizeMode =
                LabelAutoSizeMode.None

            lblDescription.Dock =
                DockStyle.Top

        End Sub


        '==================================================
        ' Icon
        '==================================================

        Private Sub InitializeIcon()

            picIcon.Properties.ShowCameraMenuItem =
                False

            picIcon.Properties.ShowMenu =
                False

            picIcon.Properties.SizeMode =
                DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom

            picIcon.Size =
                New Size(
                    32,
                    32
                )

            picIcon.Location =
                New Point(
                    0,
                    4
                )

            picIcon.Anchor =
                AnchorStyles.Top Or
                AnchorStyles.Right

            picIcon.Dock =
                DockStyle.None

            picIcon.BackColor =
                Color.Transparent

            picIcon.BorderStyle =
                DevExpress.XtraEditors.Controls.BorderStyles.NoBorder

        End Sub


        '==================================================
        ' Keep Icon Right
        '==================================================

        Protected Overrides Sub OnSizeChanged(
            e As EventArgs
        )

            MyBase.OnSizeChanged(e)

            If headerPanel Is Nothing Then
                Return
            End If

            If picIcon Is Nothing Then
                Return
            End If

            picIcon.Location =
                New Point(
                    headerPanel.ClientSize.Width -
                    picIcon.Width,
                    4
                )

        End Sub


        '==================================================
        ' Properties
        '==================================================

        <Category("Dashboard Card")>
        <Description("Title displayed on the dashboard card.")>
        Public Property CardTitle As String

            Get
                Return lblTitle.Text
            End Get

            Set(value As String)
                lblTitle.Text = value
            End Set

        End Property


        <Category("Dashboard Card")>
        <Description("Main value displayed on the dashboard card.")>
        Public Property CardValue As String

            Get
                Return lblValue.Text
            End Get

            Set(value As String)
                lblValue.Text = value
            End Set

        End Property


        <Category("Dashboard Card")>
        <Description("Description displayed on the dashboard card.")>
        Public Property CardDescription As String

            Get
                Return lblDescription.Text
            End Get

            Set(value As String)
                lblDescription.Text = value
            End Set

        End Property


        <Category("Dashboard Card")>
        <Description("Color of the main value.")>
        Public Property ValueColor As Color

            Get
                Return lblValue.Appearance.ForeColor
            End Get

            Set(value As Color)

                lblValue.Appearance.ForeColor =
                    value

            End Set

        End Property


        <Category("Dashboard Card")>
        <Description("Background color of the card.")>
        Public Property CardBackColor As Color

            Get
                Return normalBackColor
            End Get

            Set(value As Color)

                normalBackColor =
                    value

                Me.Appearance.Options.UseBackColor =
                    True

                Me.Appearance.BackColor =
                    value

            End Set

        End Property


        <Category("Dashboard Card")>
        <Description("Background color when mouse is over the card.")>
        Public Property CardHoverColor As Color

            Get
                Return hoverBackColor
            End Get

            Set(value As Color)

                hoverBackColor =
                    value

            End Set

        End Property


        <Category("Dashboard Card")>
        <Description("Icon displayed on the dashboard card.")>
        Public Property CardIcon As Image

            Get
                Return picIcon.Image
            End Get

            Set(value As Image)

                picIcon.Image =
                    value

            End Set

        End Property


        <Category("Dashboard Card")>
        <Description("SVG icon displayed on the dashboard card.")>
        Public Property CardSvgIcon As DevExpress.Utils.Svg.SvgImage

            Get
                Return picIcon.SvgImage
            End Get

            Set(value As DevExpress.Utils.Svg.SvgImage)

                picIcon.SvgImage =
                    value

            End Set

        End Property


        '==================================================
        ' Methods
        '==================================================

        Public Sub SetData(
            title As String,
            value As String,
            description As String,
            Optional icon As Image = Nothing
        )

            CardTitle =
                title

            CardValue =
                value

            CardDescription =
                description

            If icon IsNot Nothing Then

                CardIcon =
                    icon

            End If

        End Sub


        Public Sub ApplyTheme(
    theme As ThemeManager.ThemeMode
)

            Me.LookAndFeel.UseDefaultLookAndFeel =
        False

            Me.LookAndFeel.Style =
        DevExpress.LookAndFeel.LookAndFeelStyle.Flat

            Me.Appearance.Options.UseBackColor =
        True

            Me.Appearance.Options.UseBorderColor =
        True

            Select Case theme

                Case ThemeManager.ThemeMode.Light

                    normalBackColor =
                Color.White

                    hoverBackColor =
                Color.FromArgb(
                    245,
                    247,
                    250
                )

                    Me.Appearance.BackColor =
                normalBackColor

                    Me.Appearance.BorderColor =
                Color.FromArgb(
                    225,
                    228,
                    232
                )

                    lblTitle.Appearance.Options.UseForeColor =
                True

                    lblTitle.Appearance.ForeColor =
                Color.DimGray

                    lblDescription.Appearance.Options.UseForeColor =
                True

                    lblDescription.Appearance.ForeColor =
                Color.Gray

                    picIcon.BackColor =
                Color.Transparent


                Case ThemeManager.ThemeMode.Dark

                    normalBackColor =
                Color.FromArgb(
                    37,
                    37,
                    38
                )

                    hoverBackColor =
                Color.FromArgb(
                    50,
                    50,
                    52
                )

                    Me.Appearance.BackColor =
                normalBackColor

                    Me.Appearance.BorderColor =
                Color.FromArgb(
                    65,
                    65,
                    68
                )

                    lblTitle.Appearance.Options.UseForeColor =
                True

                    lblTitle.Appearance.ForeColor =
                Color.FromArgb(
                    225,
                    225,
                    225
                )

                    lblDescription.Appearance.Options.UseForeColor =
                True

                    lblDescription.Appearance.ForeColor =
                Color.FromArgb(
                    165,
                    165,
                    170
                )

                    picIcon.BackColor =
                Color.Transparent

            End Select

        End Sub


        '==================================================
        ' Hover
        '==================================================

        Private Sub Card_MouseEnter(
            sender As Object,
            e As EventArgs
        )

            Me.Appearance.BackColor =
                hoverBackColor

        End Sub


        Private Sub Card_MouseLeave(
            sender As Object,
            e As EventArgs
        )

            Me.Appearance.BackColor =
                normalBackColor

        End Sub


        '==================================================
        ' Click
        '==================================================

        Public Event CardClick As EventHandler


        Private Sub Card_Click(
            sender As Object,
            e As EventArgs
        )

            RaiseEvent CardClick(
                Me,
                EventArgs.Empty
            )

        End Sub


        Private Sub ChildControl_Click(
            sender As Object,
            e As EventArgs
        )

            RaiseEvent CardClick(
                Me,
                EventArgs.Empty
            )

        End Sub


    End Class

End Namespace