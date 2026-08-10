# Dashboard Card — Theme & Customization

The `DashboardCard` component supports customization of its visual appearance through properties.

## Available Properties

### CardTitle

Defines the title displayed on the card.

```vbnet
salesCard.CardTitle = "SALES TODAY"
```

### CardValue

Defines the primary business value.

```vbnet
salesCard.CardValue = "Rp 12.500.000"
```

### CardDescription

Defines additional information.

```vbnet
salesCard.CardDescription = "125 Transactions"
```

### ValueColor

Controls the color of the primary value.

```vbnet
salesCard.ValueColor = Color.SeaGreen
```

### CardBackColor

Controls the background color.

```vbnet
salesCard.CardBackColor = Color.White
```

### CardIcon

Allows an image to be displayed on the card.

```vbnet
salesCard.CardIcon = My.Resources.sales
```

---

## Example

```vbnet
Dim salesCard As New DashboardCard()

salesCard.SetData(
    "SALES TODAY",
    "Rp 12.500.000",
    "125 Transactions"
)

salesCard.ValueColor =
    Color.SeaGreen

salesCard.CardBackColor =
    Color.White
```

---

## Event Handling

The component provides a `CardClick` event.

```vbnet
AddHandler salesCard.CardClick,
    AddressOf SalesCard_Click
```

Example:

```vbnet
Private Sub SalesCard_Click(
    sender As Object,
    e As EventArgs)

    'Navigate to sales report

End Sub
```

This allows dashboard cards to act as navigation elements rather than purely visual components.

---

## Design Philosophy

The component is intentionally kept lightweight.

Its responsibilities are limited to:

* Displaying business metrics
* Providing basic visual customization
* Handling user interaction
* Supporting reuse across multiple dashboards

Business logic and database queries should remain outside the component.

For example, the component should **not** directly query SQL Server.

Instead:

```text
Database
    ↓
Business Logic
    ↓
Dashboard Form
    ↓
DashboardCard
```

This separation keeps the component reusable and easier to maintain.
