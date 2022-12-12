# CSharp Project
- This API supports .net core 3.1 (LTS) and created from Visual studio 2022.
- This includes Depandency injection, repository pattern, SOLID principles, EF In Memory database, automapper, swagger, Enabled global cors policy (We can customise as per need),
	Azure Application insight for Exception handling (Need to add application telementry key for make it work)
	JWT Authentication (Logic added fully now to make it work we need to have separte auth api which whould generate token and same token will be validated in this api if we uncomment some 
	code like Authorise attribute and UseAuthentication in startup file),
	//ToDo or good to have : Move all exception handling logic to custom or global middleware

- There are basically 3 main layers or project solutions
   1) Zip.InstallmentsService.API (API controllers)
   2) Zip.InstallmentsService.Core (Bussiness layer + AutoMapper)
   3) Zip.InstallmentsService.Data (Data Access layer)
   4) Zip.InstallmentsService.Entity (Dto and request/response objects)
   5) Zip.InstallmentsService.Core.Test (This is for test cases) 

## Testing steps or details
Now to test this API please find below steps
- Make sure Zip.InstallmentsService.API is set as a start project
- Run the project from visual studio 2022 and it shuld open swagger UI page (https://localhost:44336/swagger/index.html)
- Now here you will see 2 api one is to create payment plan (HttpPOST) and one is to get payment plan by PaymentPlanId (HttpGet)
- So you can click on 'Try it out' button and provide input and test it there on swagger UI itself.
  
  OR 
- if you wish to test it via PostMan you can test it via postman as well.
  1) HttpPost > https://localhost:44336/api/PaymentPlan
	Body > 
	{
		"userId": "504A683D-B4C3-4770-962B-4B5F3F89BB91",
		"purchaseAmount": "100.00",
		"purchaseDate":"2022-01-01",
		"noOfInstallments":"4",
		"frequencyInDays":"14"
	}

  2) HttpGet > https://localhost:44336/api/PaymentPlan/{PaymentPlanId}
  Note: PaymentPlanId is the one which is creted from point1

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
dotnet test Zip.InstallmentsService.Core.Test.sln
```
