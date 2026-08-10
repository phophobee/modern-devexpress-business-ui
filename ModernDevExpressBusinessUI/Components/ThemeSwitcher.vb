Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace Components

    Public Class ThemeSwitcher
        Inherits UserControl

        Private ReadOnly btnLight As New SimpleButton()
        Private ReadOnly btnDark As New SimpleButton()

        Private _currentTheme As ThemeManager.ThemeMode =
            ThemeManager.ThemeMode.Light

        Public Sub New()

            InitializeSwitcher()

        End Sub


        '==================================================
        ' Initialize
        '==================================================

        Private Sub InitializeSwitcher()

            Me.Size =
                New Size(100, 36)

            Me.MinimumSize =
                New Size(100, 36)

            Me.BackColor =
                Color.Transparent


            '==================================================
            ' Light Button
            '==================================================

            btnLight.Text =
                "☀"

            btnLight.Size =
                New Size(45, 30)

            btnLight.Location =
                New Point(2, 3)

            btnLight.ToolTip =
                "Light Theme"


            '==================================================
            ' Dark Button
            '==================================================

            btnDark.Text =
                "☾"

            btnDark.Size =
                New Size(45, 30)

            btnDark.Location =
                New Point(50, 3)

            btnDark.ToolTip =
                "Dark Theme"


            '==================================================
            ' Appearance
            '==================================================

            ConfigureButton(
                btnLight
            )

            ConfigureButton(
                btnDark
            )


            '==================================================
            ' Events
            '==================================================

            AddHandler btnLight.Click,
                AddressOf LightButton_Click

            AddHandler btnDark.Click,
                AddressOf DarkButton_Click


            '==================================================
            ' Add Controls
            '==================================================

            Me.Controls.Add(btnLight)

            Me.Controls.Add(btnDark)


            UpdateButtonState()

        End Sub


        '==================================================
        ' Button Configuration
        '==================================================

        Private Sub ConfigureButton(
            button As SimpleButton
        )

            button.LookAndFeel.UseDefaultLookAndFeel =
                False

            button.LookAndFeel.Style =
                DevExpress.LookAndFeel.LookAndFeelStyle.Flat

            button.ButtonStyle =
                DevExpress.XtraEditors.Controls.BorderStyles.NoBorder

            button.Appearance.Font =
                New Font(
                    "Segoe UI",
                    13.0!,
                    FontStyle.Regular
                )

            button.Appearance.Options.UseFont =
                True

            button.Appearance.Options.UseBackColor =
                True

            button.Appearance.Options.UseForeColor =
                True

            button.Cursor =
                Cursors.Hand

        End Sub


        '==================================================
        ' Current Theme
        '==================================================

        Public Property CurrentTheme As ThemeManager.ThemeMode

            Get

                Return _currentTheme

            End Get

            Set(value As ThemeManager.ThemeMode)

                _currentTheme =
            value

                UpdateButtonState()

                RaiseEvent ThemeChanged(
            Me,
            EventArgs.Empty
        )

            End Set

        End Property


        '==================================================
        ' Button State
        '==================================================

        Private Sub UpdateButtonState()

            If _currentTheme =
        ThemeManager.ThemeMode.Light Then

                '==============================================
                ' LIGHT ACTIVE
                '==============================================

                btnLight.Appearance.Options.UseBackColor = True
                btnLight.Appearance.Options.UseForeColor = True

                btnLight.Appearance.BackColor =
            Color.FromArgb(
                230,
                232,
                235
            )

                btnLight.Appearance.ForeColor =
            Color.FromArgb(
                40,
                40,
                40
            )


                '==============================================
                ' DARK INACTIVE
                '==============================================

                btnDark.Appearance.Options.UseBackColor = True
                btnDark.Appearance.Options.UseForeColor = True

                btnDark.Appearance.BackColor =
            Color.Transparent

                btnDark.Appearance.ForeColor =
            Color.Gray


            Else

                '==============================================
                ' DARK ACTIVE
                '==============================================

                btnDark.Appearance.Options.UseBackColor = True
                btnDark.Appearance.Options.UseForeColor = True

                btnDark.Appearance.BackColor =
            Color.FromArgb(
                65,
                65,
                68
            )

                btnDark.Appearance.ForeColor =
            Color.White


                '==============================================
                ' LIGHT INACTIVE
                '==============================================

                btnLight.Appearance.Options.UseBackColor = True
                btnLight.Appearance.Options.UseForeColor = True

                btnLight.Appearance.BackColor =
            Color.Transparent

                btnLight.Appearance.ForeColor =
            Color.Gray

            End If

        End Sub

        '==================================================
        ' Button Events
        '==================================================

        Private Sub LightButton_Click(
            sender As Object,
            e As EventArgs
        )

            CurrentTheme =
                ThemeManager.ThemeMode.Light

        End Sub


        Private Sub DarkButton_Click(
            sender As Object,
            e As EventArgs
        )

            CurrentTheme =
                ThemeManager.ThemeMode.Dark

        End Sub


        '==================================================
        ' Event
        '==================================================

        Public Event ThemeChanged As EventHandler

    End Class

End Namespace