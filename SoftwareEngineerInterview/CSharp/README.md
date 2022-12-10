# CSharp Project
- This API supports .net core 3.1 (LTS) and created from Visual studio 2022.
- This includes Depandency injection, repository pattern, SOLID principles, EF In Memory database, automapper, swagger, Azure Application insight for Exception handling.
- There are basically 3 main layers or project solutions
   1) Zip.InstallmentsService.API (API controllers)
   2) Zip.InstallmentsService.Core (Bussiness layer + AutoMapper)
   3) Zip.InstallmentsService.Data (Data Access layer)
   4) Zip.InstallmentsService.Entity (Dto and request/response objects)

## Testing steps or details
Now to test this API please find below steps
- Make sure Zip.InstallmentsService.API is set as a start project
- Run the project from visual studio 2022 and it shuld open swagger UI page (https://localhost:44336/swagger/index.html)
- Now here you will see 2 api one is to create payment plan (HttpPOST) and one is to get payment plan by PaymentPlanId (HttpGet)
- So you can click on 'Try it out' button and provide input and test it there on swagger UI itself.


## Requirements
```
Microsoft Visual Studio Community 2022 (64-bit) > Version 17.4.2
.Net Core 3.1 (LTS)
```

## Install
```
cd Zip.InstallmentsService
dotnet restore
```

## Quick Start
```
cd Zip.InstallmentsService
dotnet run
```

## Run Tests
```
cd Zip.InstallmentsService
dotnet test Zip.InstallmentsService.sln
```
