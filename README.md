# TourmalineCore.NodaTime.Extensions

The libary has create for extentions NodaTime.
We are using NodaTime libary as alternative date and time API for .NET.

# Table of Content

- [Period](#Period)
    - [Basic Usage](#basic)
    - [Period Methods](#period-methods)
- [Utilities](#utilities)

# Period

## Basic

Class Period has two properties: `StartDate` and `EndDate` with `NodaTime.LocalDate` type.

Example of creation:

```csharp
LocalDate PeriodStartDate = new LocalDate(2021, 05, 01);
LocalDate PeriodEndDate = new LocalDate(2021, 05, 31);

Period period = new Period(PeriodStartDate, PeriodEndDate);
```

Properties has all `NodaTime.LocalDate` methods from NodaTime library.

## Period Methods

Class `Period` has methods for checking `NodaTime.LocalDate` custom dates.

Example:

```csharp
...
var date = new LocalDate(2021, 05, 14);

period.Include(date); //true
period.Behind(date); //false
period.Before(date); //false
...
```
# Utilities

Package has one utility to get current time in UTC.

```csharp
...
var currentDateTimeAtUtc = MachineNodaTime.UtcNow;
var currentDatePlusMonth = currentDateTimeAtUtc.Date.PlusMonths(1);

Period period = new Period(currentDateTimeAtUtc, datePlusMonth)
...
```