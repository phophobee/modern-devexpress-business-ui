Imports System.ComponentModel.Design.Serialization
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Data
Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors

Public Class MainForm

    Private themeSwitcher As Components.ThemeSwitcher

    Private salesCard As Components.DashboardCard
    Private purchasingCard As Components.DashboardCard
    Private profitCard As Components.DashboardCard
    Private customerCard As Components.DashboardCard

    Private salesChart As ChartControl
    Private transactionGrid As DevExpress.XtraGrid.GridControl
    Private transactionView As DevExpress.XtraGrid.Views.Grid.GridView
    Private productGrid As DevExpress.XtraGrid.GridControl
    Private productView As DevExpress.XtraGrid.Views.Grid.GridView

    Private Sub MainForm_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load
        Me.MinimumSize =
    New Size(
        1100,
        650
    )
        InitializeDashboard()

    End Sub

    Private Sub InitializeDashboard()
        Dim salesIcon As DevExpress.Utils.Svg.SvgImage =
        Global.ModernDevExpressBusinessUI.Components.SvgResourceHelper.Load(
            "ModernDevExpressBusinessUI.sales.svg"
        )

        Dim purchasingIcon As DevExpress.Utils.Svg.SvgImage =
        Global.ModernDevExpressBusinessUI.Components.SvgResourceHelper.Load(
            "ModernDevExpressBusinessUI.purchasing.svg"
        )

        Dim profitIcon As DevExpress.Utils.Svg.SvgImage =
        Global.ModernDevExpressBusinessUI.Components.SvgResourceHelper.Load(
            "ModernDevExpressBusinessUI.profit.svg"
        )

        Dim customersIcon As DevExpress.Utils.Svg.SvgImage =
        Global.ModernDevExpressBusinessUI.Components.SvgResourceHelper.Load(
            "ModernDevExpressBusinessUI.customers.svg"
        )

        salesCard = CreateCard(
            "SALES TODAY",
            "Rp 12.500.000",
            "125 Transactions", salesIcon
        )

        purchasingCard = CreateCard(
            "PURCHASING",
            "Rp 8.200.000",
            "42 Transactions", purchasingIcon
        )

        profitCard = CreateCard(
            "PROFIT",
            "Rp 3.200.000",
            "Today's Profit", profitIcon
        )

        customerCard = CreateCard(
            "CUSTOMERS",
            "1,250",
            "Active Customers", customersIcon
        )

        salesCard.ValueColor = Color.SeaGreen
        purchasingCard.ValueColor = Color.DarkOrange
        profitCard.ValueColor = Color.SteelBlue
        customerCard.ValueColor = Color.MediumPurple

        AddHandler salesCard.CardClick,
            AddressOf SalesCard_Click

        AddHandler purchasingCard.CardClick,
            AddressOf PurchasingCard_Click

        AddHandler profitCard.CardClick,
            AddressOf ProfitCard_Click

        AddHandler customerCard.CardClick,
            AddressOf CustomerCard_Click

        CreateDashboardLayout()

    End Sub

    Private Function CreateCard(
    title As String,
    value As String,
    description As String,
    icon As DevExpress.Utils.Svg.SvgImage
    ) As Global.ModernDevExpressBusinessUI.Components.DashboardCard

        Dim card As New Global.ModernDevExpressBusinessUI.Components.DashboardCard()

        card.SetData(
        title,
        value,
        description
    )

        card.CardSvgIcon =
        icon

        'card.CardBackColor =
        'Color.White

        card.Dock =
        DockStyle.Fill

        Return card

    End Function

    Private Sub CreateDashboardLayout()

        Dim mainLayout As New TableLayoutPanel() With {
        .Dock = DockStyle.Fill,
        .ColumnCount = 1,
        .RowCount = 4
    }

        mainLayout.RowStyles.Add(
    New RowStyle(
        SizeType.Absolute,
        90
    )
)

        mainLayout.RowStyles.Add(
    New RowStyle(
        SizeType.Absolute,
        175
    )
)

        mainLayout.RowStyles.Add(
    New RowStyle(
        SizeType.Percent,
        45.0!
    )
)

        mainLayout.RowStyles.Add(
    New RowStyle(
        SizeType.Percent,
        55.0!
    )
)

        '==================================================
        ' Header
        '==================================================

        Dim header As New PanelControl() With {
        .Dock = DockStyle.Fill,
        .BorderStyle =
            DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
    }

        themeSwitcher = New Components.ThemeSwitcher()

        themeSwitcher.Anchor =
    AnchorStyles.Top Or AnchorStyles.Right

        themeSwitcher.Location =
    New Point(
        header.ClientSize.Width -
        themeSwitcher.Width -
        20,
        10
    )

        '==================================================
        ' Event harus dipasang SEBELUM CurrentTheme
        '==================================================

        AddHandler themeSwitcher.ThemeChanged,
    AddressOf ThemeSwitcher_ThemeChanged



        Dim lblTitle As New LabelControl() With {
        .Text = "HANINA APLIKASI"
    }

        lblTitle.Appearance.Font =
        New Font(
            "Segoe UI Semibold",
            18,
            FontStyle.Bold
        )

        lblTitle.Location =
        New Point(20, 12)

        lblTitle.AutoSizeMode =
        LabelAutoSizeMode.Default


        Dim lblSubtitle As New LabelControl() With {
        .Text = "eCash - Business Management System v2.0"
    }

        lblSubtitle.Appearance.Font =
        New Font(
            "Segoe UI",
            10.0!,
            FontStyle.Regular
        )

        lblSubtitle.Appearance.ForeColor =
        Color.Gray

        lblSubtitle.Location =
        New Point(20, 48)

        header.Controls.Add(lblSubtitle)
        header.Controls.Add(lblTitle)
        header.Controls.Add(themeSwitcher)

        AddHandler header.Resize,
    Sub(sender As Object, e As EventArgs)

        If themeSwitcher Is Nothing Then
            Return
        End If

        themeSwitcher.Location =
            New Point(
                header.ClientSize.Width -
                themeSwitcher.Width -
                20,
                10
            )

    End Sub

        '==================================================
        ' Cards Container
        '==================================================

        Dim cardsLayout As New TableLayoutPanel() With {
        .Dock = DockStyle.Fill,
        .ColumnCount = 4,
        .RowCount = 1,
        .Padding = New Padding(
            20,
            10,
            20,
            20
        )
    }


        For i As Integer = 0 To 3

            cardsLayout.ColumnStyles.Add(
            New ColumnStyle(
                SizeType.Percent,
                25.0!
            )
        )

        Next


        cardsLayout.RowStyles.Add(
        New RowStyle(
            SizeType.Percent,
            100.0!
        )
    )


        '==================================================
        ' Add Cards
        '==================================================

        cardsLayout.Controls.Add(
        salesCard,
        0,
        0
    )

        cardsLayout.Controls.Add(
        purchasingCard,
        1,
        0
    )

        cardsLayout.Controls.Add(
        profitCard,
        2,
        0
    )

        cardsLayout.Controls.Add(
        customerCard,
        3,
        0
    )

        '==================================================
        ' Create Sales Chart
        '==================================================

        salesChart = CreateSalesChart()
        transactionGrid = CreateTransactionGrid()
        Dim bottomLayout As New TableLayoutPanel() With {
    .Dock = DockStyle.Fill,
    .ColumnCount = 2,
    .RowCount = 1,
    .Padding = New Padding(
        0,
        10,
        0,
        20
    )
}

        bottomLayout.ColumnStyles.Add(
    New ColumnStyle(
        SizeType.Percent,
        60.0!
    )
)

        bottomLayout.ColumnStyles.Add(
    New ColumnStyle(
        SizeType.Percent,
        40.0!
    )
)

        productGrid = CreateProductGrid()

        bottomLayout.Controls.Add(
    transactionGrid,
    0,
    0
)

        bottomLayout.Controls.Add(
    productGrid,
    1,
    0
)

        '==================================================
        ' Main Layout
        '==================================================

        mainLayout.Controls.Add(
        header,
        0,
        0
    )

        mainLayout.Controls.Add(
        cardsLayout,
        0,
        1
    )

        mainLayout.Controls.Add(
    salesChart,
    0,
    2
)

        mainLayout.Controls.Add(
    bottomLayout,
    0,
    3
)

        Me.Controls.Add(mainLayout)

        '==================================================
        ' Load Saved Theme
        '==================================================

        Dim savedTheme As Components.ThemeManager.ThemeMode = ModernDevExpressBusinessUI.Components.ThemeManager.ThemeMode.Light

        If Not String.IsNullOrWhiteSpace(
    My.Settings.ThemeMode
) Then

            If Not [Enum].TryParse(
        My.Settings.ThemeMode,
        True,
        savedTheme
    ) Then

                savedTheme =
            ModernDevExpressBusinessUI.Components.ThemeManager.ThemeMode.Light
            End If

        End If


        '==================================================
        ' Set Theme
        '==================================================

        themeSwitcher.CurrentTheme =
    savedTheme

        ApplyChartTheme(savedTheme)
        ApplyTransactionGridTheme(savedTheme)
        ApplyProductGridTheme(savedTheme)

    End Sub

    Private Sub ThemeSwitcher_ThemeChanged(
    sender As Object,
    e As EventArgs
)

        If themeSwitcher Is Nothing Then
            Return
        End If


        '==================================================
        ' Apply Theme
        '==================================================

        Global.ModernDevExpressBusinessUI.Components.ThemeManager.ApplyTheme(
        Me,
        themeSwitcher.CurrentTheme
    )

        ApplyChartTheme(themeSwitcher.CurrentTheme)
        ApplyTransactionGridTheme(themeSwitcher.CurrentTheme)
        ApplyProductGridTheme(themeSwitcher.CurrentTheme)

        '==================================================
        ' Save User Preference
        '==================================================

        My.Settings.ThemeMode =
        themeSwitcher.CurrentTheme.ToString()

        My.Settings.Save()

    End Sub


    '==================================================
    ' Card Events
    '==================================================

    Private Sub SalesCard_Click(
        sender As Object,
        e As EventArgs)

        XtraMessageBox.Show(
            "Open Sales Report",
            "Dashboard"
        )

    End Sub

    Private Sub PurchasingCard_Click(
        sender As Object,
        e As EventArgs)

        XtraMessageBox.Show(
            "Open Purchasing Report",
            "Dashboard"
        )

    End Sub

    Private Sub ProfitCard_Click(
        sender As Object,
        e As EventArgs)

        XtraMessageBox.Show(
            "Open Profit Report",
            "Dashboard"
        )

    End Sub

    Private Sub CustomerCard_Click(
        sender As Object,
        e As EventArgs)

        XtraMessageBox.Show(
            "Open Customer Management",
            "Dashboard"
        )

    End Sub

    Private Function CreateSalesChart() As ChartControl

        Dim chart As New ChartControl() With {
            .Dock = DockStyle.Fill
        }


        '==================================================
        ' Chart Title
        '==================================================

        Dim title As New ChartTitle() With {
            .Text = "Sales Overview",
            .Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold)
       }

        chart.Titles.Add(title)


        '==================================================
        ' Data
        '==================================================

        Dim data As New List(Of Components.SalesData) From {
        New Components.SalesData With {
            .Day = "Mon",
            .Amount = 2500000
        },
        New Components.SalesData With {
            .Day = "Tue",
            .Amount = 3200000
        },
        New Components.SalesData With {
            .Day = "Wed",
            .Amount = 2800000
        },
        New Components.SalesData With {
            .Day = "Thu",
            .Amount = 4100000
        },
        New Components.SalesData With {
            .Day = "Fri",
            .Amount = 3600000
        },
        New Components.SalesData With {
            .Day = "Sat",
            .Amount = 4800000
        },
        New Components.SalesData With {
            .Day = "Sun",
            .Amount = 3900000
        }
    }


        '==================================================
        ' Series
        '==================================================

        Dim series As New Series(
        "Sales",
        ViewType.Line
    )


        For Each item In data

            series.Points.Add(
                New SeriesPoint(
                    item.Day,
                    item.Amount
                )
            )

        Next


        chart.Series.Add(series)


        '==================================================
        ' Line Style
        '==================================================

        Dim lineView =
            TryCast(
                series.View,
                LineSeriesView
            )

        If lineView IsNot Nothing Then

            lineView.LineStyle.Thickness = 3

            lineView.MarkerVisibility =
                DevExpress.Utils.DefaultBoolean.True

        End If


        '==================================================
        ' Axis
        '==================================================

        Dim diagram =
            TryCast(
                chart.Diagram,
                XYDiagram
            )

        If diagram IsNot Nothing Then

            diagram.AxisX.Title.Text =
                "Day"

            diagram.AxisY.Title.Text =
                "Sales"


            diagram.AxisY.Label.TextPattern =
                "{V:N0}"

        End If


        '==================================================
        ' Legend
        '==================================================

        chart.Legend.Visibility =
            DevExpress.Utils.DefaultBoolean.False


        Return chart

    End Function

    Private Sub ApplyChartTheme(
    theme As Components.ThemeManager.ThemeMode
)

        If salesChart Is Nothing Then
            Return
        End If


        Dim diagram =
            TryCast(
                salesChart.Diagram,
                DevExpress.XtraCharts.XYDiagram
            )

        If diagram Is Nothing Then
            Return
        End If


        Select Case theme

        '==================================================
        ' LIGHT
        '==================================================

            Case ModernDevExpressBusinessUI.Components.ThemeManager.ThemeMode.Light

                salesChart.BackColor = Color.White
                salesChart.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False
                diagram.DefaultPane.BorderVisible = False
                diagram.DefaultPane.BackColor = Color.White
                diagram.AxisX.Color = Color.FromArgb(210, 210, 210)
                diagram.AxisY.Color = Color.FromArgb(210, 210, 210)
                diagram.AxisX.Label.TextColor = Color.FromArgb(90, 90, 90)
                diagram.AxisY.Label.TextColor = Color.FromArgb(90, 90, 90)
                diagram.AxisX.Title.TextColor = Color.FromArgb(80, 80, 80)
                diagram.AxisY.Title.TextColor = Color.FromArgb(80, 80, 80)

        '==================================================
        ' DARK
        '==================================================

            Case ModernDevExpressBusinessUI.Components.ThemeManager.ThemeMode.Dark

                salesChart.BackColor =
                    Color.FromArgb(
                        37,
                        37,
                        38
                    )

                salesChart.BorderOptions.Visibility =
                    DevExpress.Utils.DefaultBoolean.False

                diagram.DefaultPane.BorderVisible = False
                diagram.DefaultPane.BackColor = Color.FromArgb(
                        37,
                        37,
                        38
                    )
                diagram.AxisX.Color =
                    Color.FromArgb(
                        70,
                        70,
                        73
                    )

                diagram.AxisY.Color =
                    Color.FromArgb(
                        70,
                        70,
                        73
                    )


                diagram.AxisX.Label.TextColor =
                    Color.FromArgb(
                        190,
                        190,
                        195
                    )

                diagram.AxisY.Label.TextColor =
                    Color.FromArgb(
                        190,
                        190,
                        195
                    )


                diagram.AxisX.Title.TextColor =
                    Color.FromArgb(
                        210,
                        210,
                        215
                    )

                diagram.AxisY.Title.TextColor =
                    Color.FromArgb(
                        210,
                        210,
                        215
                    )

        End Select

        If salesChart.Titles.Count > 0 Then

            Select Case theme

                Case ModernDevExpressBusinessUI.Components.ThemeManager.ThemeMode.Light

                    salesChart.Titles(0).TextColor =
                    Color.FromArgb(
                        45,
                        45,
                        48
                    )

                Case ModernDevExpressBusinessUI.Components.ThemeManager.ThemeMode.Dark

                    salesChart.Titles(0).TextColor =
                    Color.FromArgb(
                        235,
                        235,
                        235
                    )

            End Select

        End If


    End Sub
    Private Function CreateTransactionGrid() As DevExpress.XtraGrid.GridControl

        Dim grid As New DevExpress.XtraGrid.GridControl() With {
            .Dock = DockStyle.Fill
        }


        '==================================================
        ' Grid View
        '==================================================

        Dim view As New DevExpress.XtraGrid.Views.Grid.GridView()

        transactionView = view


        grid.MainView =
            view

        grid.ViewCollection.Add(
            view
        )


        '==================================================
        ' Data
        '==================================================

        Dim data As New List(Of Components.TransactionData) From {
        New Components.TransactionData With {
            .Invoice = "INV-0001",
            .Customer = "Customer A",
            .DateTime = DateTime.Now.AddMinutes(-10),
            .Amount = 250000,
            .Payment = "Cash"
        },
        New Components.TransactionData With {
            .Invoice = "INV-0002",
            .Customer = "Customer B",
            .DateTime = DateTime.Now.AddMinutes(-25),
            .Amount = 175000,
            .Payment = "Cash"
        },
        New Components.TransactionData With {
            .Invoice = "INV-0003",
            .Customer = "Customer C",
            .DateTime = DateTime.Now.AddMinutes(-40),
            .Amount = 325000,
            .Payment = "Transfer"
        },
        New Components.TransactionData With {
            .Invoice = "INV-0004",
            .Customer = "Customer D",
            .DateTime = DateTime.Now.AddMinutes(-55),
            .Amount = 450000,
            .Payment = "Cash"
        },
        New Components.TransactionData With {
            .Invoice = "INV-0005",
            .Customer = "Customer E",
            .DateTime = DateTime.Now.AddHours(-1),
            .Amount = 125000,
            .Payment = "QRIS"
        }
    }


        grid.DataSource =
        data


        '==================================================
        ' Appearance
        '==================================================

        view.OptionsView.ShowGroupPanel =
            False

        view.OptionsView.ShowIndicator =
            False

        view.OptionsView.ShowVerticalLines =
            DevExpress.Utils.DefaultBoolean.False

        view.OptionsSelection.EnableAppearanceFocusedCell =
            False

        view.FocusRectStyle =
            DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus


        '==================================================
        ' Columns
        '==================================================

        If view.Columns("Invoice") IsNot Nothing Then

            view.Columns("Invoice").Caption =
                "Invoice"

            view.Columns("Invoice").Width =
                100

        End If


        If view.Columns("Customer") IsNot Nothing Then

            view.Columns("Customer").Caption =
                "Customer"

        End If


        If view.Columns("DateTime") IsNot Nothing Then

            view.Columns("DateTime").Caption =
                "Time"

            view.Columns("DateTime").DisplayFormat.FormatType =
                DevExpress.Utils.FormatType.DateTime

            view.Columns("DateTime").DisplayFormat.FormatString =
                "HH:mm"

        End If


        If view.Columns("Amount") IsNot Nothing Then

            view.Columns("Amount").Caption =
                "Amount"

            view.Columns("Amount").DisplayFormat.FormatType =
                DevExpress.Utils.FormatType.Numeric

            view.Columns("Amount").DisplayFormat.FormatString =
                "Rp #,##0"

        End If


        If view.Columns("Payment") IsNot Nothing Then

            view.Columns("Payment").Caption =
                "Payment"

        End If


        Return grid

    End Function
    Private Sub ApplyTransactionGridTheme(
    theme As Components.ThemeManager.ThemeMode
)

        If transactionView Is Nothing Then
            Return
        End If


        Select Case theme

        '==================================================
        ' LIGHT
        '==================================================

            Case ModernDevExpressBusinessUI.Components.ThemeManager.ThemeMode.Light

                transactionView.Appearance.Row.BackColor =
                    Color.White

                transactionView.Appearance.Row.ForeColor =
                    Color.FromArgb(
                        45,
                        45,
                        48
                    )

                transactionView.Appearance.HeaderPanel.BackColor =
                    Color.FromArgb(
                        245,
                        247,
                        250
                    )

                transactionView.Appearance.HeaderPanel.ForeColor =
                    Color.FromArgb(
                        70,
                        70,
                        70
                    )

                transactionView.Appearance.FocusedRow.BackColor =
                    Color.FromArgb(
                        235,
                        240,
                        245
                    )

                transactionView.Appearance.FocusedRow.ForeColor =
                    Color.FromArgb(
                        40,
                        40,
                        40
                    )


        '==================================================
        ' DARK
        '==================================================

            Case ModernDevExpressBusinessUI.Components.ThemeManager.ThemeMode.Dark

                transactionView.Appearance.Row.BackColor =
                    Color.FromArgb(
                        37,
                        37,
                        38
                    )

                transactionView.Appearance.Row.ForeColor =
                    Color.FromArgb(
                        225,
                        225,
                        225
                    )

                transactionView.Appearance.HeaderPanel.BackColor =
                    Color.FromArgb(
                        225,
                        225,
                        225
                    )

                transactionView.Appearance.HeaderPanel.ForeColor =
                    Color.FromArgb(
                        37,
                        37,
                        38
                    )

                transactionView.Appearance.FocusedRow.BackColor =
                    Color.FromArgb(
                        55,
                        55,
                        58
                    )

                transactionView.Appearance.FocusedRow.ForeColor =
                    Color.White

        End Select

    End Sub
    Private Function CreateProductGrid() As DevExpress.XtraGrid.GridControl

        Dim grid As New DevExpress.XtraGrid.GridControl() With {
            .Dock = DockStyle.Fill
        }

        Dim view As New DevExpress.XtraGrid.Views.Grid.GridView()

        productView = view

        grid.MainView = view

        grid.ViewCollection.Add(view)


        '==================================================
        ' Dummy Data
        '==================================================

        Dim data As New List(Of Components.ProductData) From {
        New Components.ProductData With {
            .Rank = 1,
            .ProductName = "Product A",
            .Category = "Beverage",
            .Quantity = 125,
            .Amount = 3750000
        },
        New Components.ProductData With {
            .Rank = 2,
            .ProductName = "Product B",
            .Category = "Food",
            .Quantity = 98,
            .Amount = 2940000
        },
        New Components.ProductData With {
            .Rank = 3,
            .ProductName = "Product C",
            .Category = "Snack",
            .Quantity = 76,
            .Amount = 2280000
        },
        New Components.ProductData With {
            .Rank = 4,
            .ProductName = "Product D",
            .Category = "Household",
            .Quantity = 54,
            .Amount = 1890000
        },
        New Components.ProductData With {
            .Rank = 5,
            .ProductName = "Product E",
            .Category = "Personal Care",
            .Quantity = 42,
            .Amount = 1470000
        }
    }

        grid.DataSource = data


        '==================================================
        ' Appearance
        '==================================================

        view.OptionsView.ShowGroupPanel =
            False

        view.OptionsView.ShowIndicator =
            False

        view.OptionsView.ShowVerticalLines =
            DevExpress.Utils.DefaultBoolean.False

        view.OptionsSelection.EnableAppearanceFocusedCell =
            False

        view.FocusRectStyle =
            DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus


        '==================================================
        ' Columns
        '==================================================

        If view.Columns("Rank") IsNot Nothing Then

            view.Columns("Rank").Caption = "#"

            view.Columns("Rank").Width = 35

            view.Columns("Rank").AppearanceCell.TextOptions.HAlignment =
                DevExpress.Utils.HorzAlignment.Center

        End If


        If view.Columns("ProductName") IsNot Nothing Then

            view.Columns("ProductName").Caption =
                "Product"

        End If


        If view.Columns("Category") IsNot Nothing Then

            view.Columns("Category").Caption =
                "Category"

        End If


        If view.Columns("Quantity") IsNot Nothing Then

            view.Columns("Quantity").Caption =
                "Qty"

            view.Columns("Quantity").Width =
                55

            view.Columns("Quantity").AppearanceCell.TextOptions.HAlignment =
                DevExpress.Utils.HorzAlignment.Center

        End If


        If view.Columns("Amount") IsNot Nothing Then

            view.Columns("Amount").Caption =
                "Sales"

            view.Columns("Amount").DisplayFormat.FormatType =
                DevExpress.Utils.FormatType.Numeric

            view.Columns("Amount").DisplayFormat.FormatString =
                "Rp #,##0"

        End If


        Return grid

    End Function
    Private Sub ApplyProductGridTheme(
    theme As Components.ThemeManager.ThemeMode
)

        If productView Is Nothing Then
            Return
        End If


        Select Case theme

            Case ModernDevExpressBusinessUI.Components.ThemeManager.ThemeMode.Light

                productView.Appearance.Row.BackColor =
                    Color.White

                productView.Appearance.Row.ForeColor =
                    Color.FromArgb(
                        45,
                        45,
                        48
                    )

                productView.Appearance.HeaderPanel.BackColor =
                    Color.FromArgb(
                        245,
                        247,
                        250
                    )

                productView.Appearance.HeaderPanel.ForeColor =
                    Color.FromArgb(
                        70,
                        70,
                        70
                    )

                productView.Appearance.FocusedRow.BackColor =
                    Color.FromArgb(
                        235,
                        240,
                        245
                    )

                productView.Appearance.FocusedRow.ForeColor =
                    Color.FromArgb(
                        40,
                        40,
                        40
                    )


            Case ModernDevExpressBusinessUI.Components.ThemeManager.ThemeMode.Dark

                productView.Appearance.Row.BackColor =
                    Color.FromArgb(
                        37,
                        37,
                        38
                    )

                productView.Appearance.Row.ForeColor =
                    Color.FromArgb(
                        225,
                        225,
                        225
                    )

                productView.Appearance.HeaderPanel.BackColor =
                    Color.FromArgb(
                        225,
                        225,
                        225
                    )


                productView.Appearance.HeaderPanel.ForeColor =
                    Color.FromArgb(
                        37,
                        37,
                        38
                    )

                productView.Appearance.FocusedRow.BackColor =
                    Color.FromArgb(
                        55,
                        55,
                        58
                    )

                productView.Appearance.FocusedRow.ForeColor =
                    Color.White

        End Select

    End Sub

End Class