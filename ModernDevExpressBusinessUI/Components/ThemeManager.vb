Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace Components

    Public NotInheritable Class ThemeManager

        Private Sub New()
        End Sub


        '==================================================
        ' Theme Definition
        '==================================================

        Public Enum ThemeMode
            Light
            Dark
        End Enum


        '==================================================
        ' Current Theme
        '==================================================

        Private Shared _currentTheme As ThemeMode =
            ThemeMode.Light

        Public Shared ReadOnly Property CurrentTheme As ThemeMode

            Get
                Return _currentTheme
            End Get

        End Property


        '==================================================
        ' Apply Theme
        '==================================================

        Public Shared Sub ApplyTheme(
            form As Form,
            theme As ThemeMode
        )

            If form Is Nothing Then
                Return
            End If


            _currentTheme = theme


            '==================================================
            ' Apply recursively
            '==================================================

            ApplyThemeToControl(
                form,
                theme
            )

        End Sub


        '==================================================
        ' Recursive Theme Engine
        '==================================================

        Private Shared Sub ApplyThemeToControl(
            control As Control,
            theme As ThemeMode
        )

            If control Is Nothing Then
                Return
            End If


            '==================================================
            ' FORM
            '==================================================

            If TypeOf control Is Form Then

                Select Case theme

                    Case ThemeMode.Light

                        control.BackColor =
                            Color.FromArgb(
                                245,
                                247,
                                250
                            )

                    Case ThemeMode.Dark

                        control.BackColor =
                            Color.FromArgb(
                                30,
                                30,
                                30
                            )

                End Select

            End If


            '==================================================
            ' DASHBOARD CARD
            '==================================================

            If TypeOf control Is DashboardCard Then

                DirectCast(
                    control,
                    DashboardCard
                ).ApplyTheme(theme)

            End If


            '==================================================
            ' LABEL
            '==================================================

            If TypeOf control Is LabelControl Then

                Dim label =
                    DirectCast(
                        control,
                        LabelControl
                    )

                label.Appearance.Options.UseForeColor =
                    True


                Select Case theme

                    Case ThemeMode.Light

                        label.Appearance.ForeColor =
                            Color.FromArgb(
                                45,
                                45,
                                48
                            )

                    Case ThemeMode.Dark

                        label.Appearance.ForeColor =
                            Color.FromArgb(
                                235,
                                235,
                                235
                            )

                End Select

            End If


            '==================================================
            ' CHILD CONTROLS
            '==================================================

            For Each child As Control In control.Controls

                ApplyThemeToControl(
                    child,
                    theme
                )

            Next

        End Sub

    End Class

End Namespace