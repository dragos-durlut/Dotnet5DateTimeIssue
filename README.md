# Dotnet5DateTimeIssue
The code to show the demo for upgrade from .NET Core 3.1 to .NET 5 Changes the DateTime Type (DateTimeKind) handling.

Recently encounterd issue where upgrading an exising application from .NET Core 3.1 to .NET 5 (.NET Core 5) showed wrong dates in UI.
Tried to isolate the route cause via eliminating EF Core and all other dependencies.

Finally found looks like the EF Core 5 somehow treats the DateTime as UTC instead of Local which was the case in .NET Core 3.1.

To see the issue,

1) Download this solution
2) Run the project Dotnet31 and in browser type https://localhost:44368/home/checkdate?date=2021-04-20T00:00:00Z (Change the port and URL as per your runtime settings).
3) Note the datetime type shown. It will show DateTimeKind as LOCAL.
4) You can try with as well https://localhost:44368/home/checkdate?date=2021-04-20T00:00:00-04:00 . It shows same results.
5) Now run the project Dotnet5 which is copy of Donet31, with exception of its ugpraded to .NET 5.
6) Type the URL again (as per the new port), It will now show the DateTimeKind as UTC.

Below are the steps to reproduce the issue if you want to try yourself.

1) Create ASP.NET MVC Core Web application using default/standard template with .NET Core 3.1.
2) Create a web method which takes DateTime as the parameter.
3) Create view to show this parameter's underlying DateTime.Kind.
4) Run the project, check the type displayed.
5) Upgrade the project to .NET 5.
6) Run the project again, check the type displayed.

| Info | .NET 3.1       | .NET 5                      |
|-----------------|-----------------|-----------------------------|
| Date Time Kind Is | Local | Utc |
| Date Is | 2021-04-20 3:00:00 AM | 2021-04-20 12:00:00 AM |
| Date String | "2021-04-20T03:00:00+03:00" | "2021-04-20T00:00:00Z" |

