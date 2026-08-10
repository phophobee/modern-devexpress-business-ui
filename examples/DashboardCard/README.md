# Dashboard Card

A reusable dashboard card component built with **VB.NET and DevExpress** for Windows Forms business applications.

## Overview

Dashboard cards are commonly used in business applications to display important operational metrics such as:

* Sales
* Purchasing
* Profit
* Customers
* Inventory
* Outstanding Receivables
* Outstanding Payables

The component provides a simple reusable structure for displaying a title, primary value, and description.

---

## Example

```text
┌──────────────────────────────┐
│ SALES TODAY                  │
│                              │
│ Rp 12.500.000                │
│                              │
│ 125 Transactions             │
└──────────────────────────────┘
```

---

## Usage

```vbnet
Dim salesCard As New DashboardCard()

salesCard.CardTitle = "SALES TODAY"
salesCard.CardValue = "Rp 12.500.000"
salesCard.CardDescription = "125 Transactions"

salesCard.Dock = DockStyle.Fill

PanelDashboard.Controls.Add(salesCard)
```

---

## Properties

| Property          | Description                                      |
| ----------------- | ------------------------------------------------ |
| `CardTitle`       | Main title displayed on the card                 |
| `CardValue`       | Primary value displayed on the card              |
| `CardDescription` | Additional information displayed below the value |

---

## Technology

* VB.NET
* Windows Forms
* DevExpress
* .NET

---

## Design Goals

The component is designed to be:

* Simple
* Reusable
* Easy to customize
* Suitable for business applications
* Easy to integrate with database-driven dashboards

---

## Example Business Metrics

```vbnet
salesCard.CardTitle = "SALES TODAY"
salesCard.CardValue = "Rp 12.500.000"
salesCard.CardDescription = "125 Transactions"
```

```vbnet
profitCard.CardTitle = "PROFIT"
profitCard.CardValue = "Rp 3.200.000"
profitCard.CardDescription = "Today's Profit"
```

```vbnet
customerCard.CardTitle = "CUSTOMERS"
customerCard.CardValue = "1,250"
customerCard.CardDescription = "Active Customers"
```

---

## Portfolio Note

This component is part of the **Modern DevExpress Business UI** project by **Hanina Aplikasi**.

The project demonstrates practical patterns for building modern Windows business applications using VB.NET and DevExpress.
