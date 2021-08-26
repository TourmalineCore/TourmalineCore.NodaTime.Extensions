# TourmalineCore.NodaTime.Extensions

The libary extends NodaTime with useful structs/classes and extensions.

We use NodaTime libary as an alternative to .NET DateTime because it makes us make less mistakes.

# Table of Content

- [Period](#Period)
    - [Basic Usage](#basic-usage)
    - [Period Methods](#period-methods)
- [Utilities](#utilities)

# Period

## Basic Usage

`Period` struct has two properties: `StartDate` and `EndDate` of `NodaTime.LocalDate` type.

### Example

```csharp
using NodaTime;
using TourmalineCore.NodaTime.Extensions;
...

LocalDate periodStartDate = new LocalDate(2021, 05, 01);
LocalDate periodEndDate = new LocalDate(2021, 05, 31);

Period period = new Period(periodStartDate, periodEndDate);
```

## Period Methods

`Period` has useful methods to be able to check if a date is a part of the period or not, is it before or after.

### Example

```csharp

var date = new LocalDate(2021, 05, 14);

period.Includes(date); //true
period.After(date); //false
period.Before(date); //false
```

# Utilities

Package has one utility to get current time in UTC.

### Example

```csharp
using NodaTime;
using TourmalineCore.NodaTime.Extensions;
...

var currentDateTimeAtUtc = MachineNodaTime.UtcNow;
var currentDatePlusMonth = currentDateTimeAtUtc.Date.PlusMonths(1);

Period period = new Period(currentDateTimeAtUtc, datePlusMonth)
```
