Imports System.Reflection
Imports System.IO
Imports DevExpress.Utils.Svg

Namespace Components

    Public NotInheritable Class SvgResourceHelper

        Private Sub New()
        End Sub

        Public Shared Function Load(
            resourceName As String
        ) As SvgImage

            Dim assembly As Assembly =
                Assembly.GetExecutingAssembly()

            Using stream As Stream =
                assembly.GetManifestResourceStream(
                    resourceName
                )

                If stream Is Nothing Then

                    Throw New FileNotFoundException(
                        "SVG resource tidak ditemukan: " &
                        resourceName
                    )

                End If

                Return SvgImage.FromStream(stream)

            End Using

        End Function

    End Class

End Namespace