# Tech Task- Cron Parser

## Introduction

This is a simple console app for parsing a cron expression and expands each field
to show the times at which it will run. 

For example, the following input argument:
*/15 0 1,15 * 1-5 /usr/bin/find

Should yield the following output:
```
| Time Fields   | Expanded valus              |
| --------------|-----------------------------|
| minute        | 0 15 30 45                  |
| hour          | 0                           |
| day of month  | 1 15                        |
| month         | 1 2 3 4 5 6 7 8 9 10 11 12  |
| day of week   | 1 2 3 4 5                   |
| command       | /usr/bin/find               |
```

### Supported Cron Expression

| Type     | Example      | When triggered     |
| ------------- | ------------- | -------- |
| A specific value          | 0 5 * * *          | Once every hour of the day at minute 5 of each hour  |
| All values (*)           | 0 * 5 * * *         | At every minute in the hour, beginning at hour 5  |
| A range (- operator)           | 5-7 * * * *          | Three times a minute - at seconds 5 through 7 during every minute of every hour of each day  |
| A set of values (, operator)           | 5,8,10 * * * *          | Three times a minute - at seconds 5, 8, and 10 during every minute of every hour of each day  |
| An interval value (/ operator)           | 0 * 5 * *          | At every minute in the hour, beginning at hour 5  |
| All values (*)           | 0 */5 * * *          | 12 times an hour - at second 0 of every 5th minute of every hour of each day  |

## Pre-req for running it locally.

### .netcore3.1

## Running it locally (Windows):

- ### STEPS
  1. Clone the project to your local 
  2. Open Windows Command Prompt
  3. CD to the App project folder of the cloned repo: ..\Deliveroo.CronEx.Parser\Source\Deliveroo.CronEx.Parser.App
  4. RUN COMMAND: dotnet build
  5. RUN COMMAND: dotnet run "*/15 0 1,15 * 1-5 /usr/bin/find"
  6. Enjoy!

## Tech stacks:

1. .netcore3.1
2. .NET Standard 2.1
3. Console app
4. C#
5. xUnit

## Code coverage:

### I have added some unit tests covering happy and non happy flow. And i have added acceptance tests which covers the whole flow without any mocked services. Due to time constraints, The code coverage covered CronExpressionService, FieldValidatorSimpleFactory and one validator (IntervalValuesFieldValidator).

## Improvements:

1. Implement caching so we serve similar parsed cron expression from the cach instead of going through the whole parsing operation
2. Dockerize the solution and deploy image to kubernetes with helmchart
3. Add more code coverage


