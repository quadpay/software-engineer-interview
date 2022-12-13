# Zip Software Engineer Interview

## Design:
- This system is designed using clean architecture. Below are the sub-component of this application.
- #### 1. Zip.InstallmentsService.SharedKarnel: 
  This is project contains defination for base model and couple of important interfaces.
- #### 2. Zip.InstallmentsService.ApiContracts: 
  This is project contains defination for api models which are used in request and responses.
- #### 3. Zip.InstallmentsService.Core: 
  This is project contains core buisness logic which is resposible for creating payment plan.
- #### 4. Zip.InstallmentsService.Infrastructure: 
  This is project contains logic for connecting with databases and performing CURD operation on DB.
- #### 5. Zip.InstallmentsService.Api: 
  This is project contains logic for payment plan api.

## Assumption:
1. Minimum value for purchase amount will be $ 1.
2. Min value for number of installments is 1.
3. Min value for frequency is 1.
4. Purhcase date shold not be null or default.

## Api details:
#### 1. Create Payment Plan

| Request Url | https://localhost:5001/api/v1/PaymentPlan |
| :--- | :--- |
| Request Type | Post |
| Request headers | 1. accept:application/json <br/> 2. Content-Type=application/json; Version=1.0 |
##### Sample Request Body
```json
{
    "purchaseAmount": 100,
    "purhcaseDate": "2022-12-08T09:56:51.958Z",
    "numberOfInstallments": 4,
    "frequency": 14
}
```
##### Sample Response Body
```json
{
    "paymentPlanId": "ef148f64-da1d-4d18-9abe-6a1c9b9e2bd7",
    "purchaseAmount": 100,
    "installments": [
        {
            "installmentId": "17cfdc50-ad86-46fc-bb4a-e9677f6d1616",
            "dueDate": "Dec 08, 2022",
            "amount": 25
        },
        {
            "installmentId": "64cd8b3d-d9b5-49ba-91d3-0b35ca08f2f5",
            "dueDate": "Dec 22, 2022",
            "amount": 25
        },
        {
            "installmentId": "eb49d6f3-f4b0-42d4-bb30-a32f83f91dd3",
            "dueDate": "Jan 05, 2023",
            "amount": 25
        },
        {
            "installmentId": "a03cef75-4c94-4b1e-a781-f1167a81b3c6",
            "dueDate": "Jan 19, 2023",
            "amount": 25
        }
    ]
}
```
##### Parameter Details
| Parameter | Data Type | Comment|
| :--- | :--- |:--- |
| purchaseAmount | Decimal | Purchase amount|
| purhcaseDate | Datetime | Purchase date|
| numberOfInstallments | int | Number of installments|
| frequency | int | frequency for installments|

##### Curl Request
```
curl --location --request POST 'https://localhost:5001/api/v1/PaymentPlan' \
--header 'accept: application/json' \
--header 'Content-Type: application/json; Version=1.0' \
--data-raw '{
    "purchaseAmount": 100,
    "purhcaseDate": "2022-12-08T09:56:51.958Z",
    "numberOfInstallments": 4,
    "frequency": 14
}'
```

### 2. Get Payment Plan by Id
| Request Url | https://localhost:5001/api/v1/PaymentPlan/id/{{PaymentPlanId}} |
| :--- | :--- |
| Request Type | Get |
| Request headers | 1. accept:application/json |
##### Sample Response Body
```json
{
    "paymentPlanId": "ef148f64-da1d-4d18-9abe-6a1c9b9e2bd7",
    "purchaseAmount": 100,
    "installments": [
        {
            "installmentId": "17cfdc50-ad86-46fc-bb4a-e9677f6d1616",
            "dueDate": "Dec 08, 2022",
            "amount": 25
        },
        {
            "installmentId": "64cd8b3d-d9b5-49ba-91d3-0b35ca08f2f5",
            "dueDate": "Dec 22, 2022",
            "amount": 25
        },
        {
            "installmentId": "eb49d6f3-f4b0-42d4-bb30-a32f83f91dd3",
            "dueDate": "Jan 05, 2023",
            "amount": 25
        },
        {
            "installmentId": "a03cef75-4c94-4b1e-a781-f1167a81b3c6",
            "dueDate": "Jan 19, 2023",
            "amount": 25
        }
    ]
}
```

##### Parameter Details
| Url Parameter | Data Type | Comment|
| :--- | :--- |:--- |
| PaymentPlanId | Guid | Payment plan id|

##### Curl Request
```
curl --location --request GET 'https://localhost:5001/api/v1/PaymentPlan/id/b3b157c7-5d30-48c0-8f69-34472cfacaa1' \
--header 'accept: application/json'
```

## Prerequisite To Run Code:
1. VS 2022
2. .Net 5 SDK
3.  Postman

 ## How to run code in VS 2022?
- Download or clone code from this repo.
- Open VS 2022.
- Browse solution file from cloned folder.
- Set Zip.InstallmentsService.Api as startup project.
- Validate Serilog in appsettings.json. It should be as below
    ```
    "Serilog": 
    {
      "MinimumLevel": 
      {
        "Default": "Information",
        "Microsoft": "Information",
        "Microsoft.Hosting.Lifetime": "Information"
	    },
	  "Using": ["Serilog.Sinks.Console", "Serilog.Sinks.File"],
	  "WriteTo":[{
            "Name": "Console"
        },
        {
          "Name": "File",
          "Args":
          {
            "path": "./bin/logs/log.txt",
            "rollingInterval": "Day"
          }
        }
      ]
    }
    ```
- Once everything looks fine, Run project.
- System will open swagger in browser window.
- Click on Post request for /api/v1/PaymentPlan
- System will expand the tab.
- In tab, click on Try it out button.
- Compose request body as below and click on execute button.
```
{
    "purchaseAmount": 100,
    "purhcaseDate": "2022-12-08T09:56:51.958Z",
    "numberOfInstallments": 4,
    "frequency": 14
}
```
- In case of success, system will response as below.
  ![image](https://user-images.githubusercontent.com/120372002/207064997-ca147283-6034-40be-b137-58546da33594.png)
   
## Running Unit Test Cases:
- In VS 2022, Click View --> select Test Explorer
- System will open window as below
![image](https://user-images.githubusercontent.com/120372002/207065342-7abc1e95-d62b-409e-9b19-fd1508237cab.png)
- Right click on Zip.InstallmentsService.UnitTests and select run.

## Running Integration Tests:
- Open postman.
- Click on import in top left hand side. It opens below pop-up window
![image](https://user-images.githubusercontent.com/120372002/207066427-fb2b71db-ec7f-4d5f-ad0f-e57616ebd523.png)
- Click on choose file and select file Zip.InstallmentsService.IntegrationTests.postman_collection from Zip.InstallmentsService\Zip.InstallmentsService.IntegrationTests location.
- System will show below screen. Click on import
![image](https://user-images.githubusercontent.com/120372002/207066903-6ec5d29b-bdab-4479-8d58-dc4c9c5a96b3.png)
- Once collection is imported --> Right click on collection and click on Run collection.
![image](https://user-images.githubusercontent.com/120372002/207067387-d89c58e2-b5d6-4790-a675-0f73e6e39cbc.png)
- Click on Run PaymentPlan button.
- System will run the integration test and show results as below.
![image](https://user-images.githubusercontent.com/120372002/207067773-fdb174b3-9148-43d0-af7c-374b69b9cdfd.png)

## Techonology and Nugets used:
1. Net 6
2. AutoMapper.Extensions.Microsoft.DependencyInjection
3. FluentValidation.AspNetCore
4. Hellang.Middleware.ProblemDetails
5. MediatR
6. MediatR.Extensions.Microsoft.DependencyInjection
7. Microsoft.AspNetCore.Mvc.Versioning
8. Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
9. Microsoft.EntityFrameworkCore.InMemory
10. Microsoft.Extensions.Configuration.Abstractions
11. Microsoft.Extensions.DependencyInjection.Abstractions
12. Serilog.AspNetCore
13. Serilog.Sinks.Console
14. Serilog.Sinks.File
15. Swashbuckle.AspNetCore
16. Microsoft.Extensions.Logging.Abstractions
17. Microsoft.NET.Test.Sdk" Version
18. MockQueryable.FakeItEasy
19. Moq
20. Shouldly
21. xunit

### Note: Below is the problem statement.

## Overview

Zip is a payment gateway that lets consumers split purchases into 4 interest free installments, every two weeks. The first 25% is taken when the purchase is made, and the remaining 3 installments of 25% are automatically taken every 14 days. We help customers manage their cash-flow while helping merchants increase conversion rates and average order values.

It may help to see our [product in action online](https://www.fanatics.com/mlb/new-york-yankees/new-york-yankees-nike-home-replica-custom-jersey-white/o-8976+t-36446587+p-2520909211+z-8-3193055640?_ref=p-CLP:m-GRID:i-r0c1:po-1), checkout our app on [ios](https://apps.apple.com/us/app/quadpay-buy-now-pay-later/id1425045070) or [android](https://play.google.com/store/apps/details?id=com.quadpay.quadpay&hl=en_US), and to read our documentation (https://docs.us.zip.co).

## Background

One of the cornerstones of Zip's culture is openness and transparency. When reviewing our existing interview structure, we found that pair-programming challenges rarely replicated what our employees actually do in their day-to-day work. For example, when was the last time you coded without google, or when the requirements weren't clearly defined? To tackle that, we've decided to publish our pair programming interview and share it directly with candidates beforehand.

As an Engineer at Zip you’ll help solve interesting problems on a daily basis. Some areas that you'll work on include fraud prevention, building real-time credit-decisioning models and, most importantly, shipping products that are secure, frictionless, and deliver a high-quality consumer experience.

The pair programming challenge will take an hour, and will more closely replicate a day-in-the-life at Zip. You’re free to use whichever resources help you to get the job done. When we evaluate your code at the end of the session, we will be looking for: 
- A high code health
- Simplicity
- Readability
- Presence of tests or planning for future tests
- And maintainability

While we mainly use .NET and C# in our back-end, we welcome candidates who are more familiar with other languages. We ask that you simply confirm your language with your recruiter beforehand. At the moment, we have only finalized starter code for C#, but feel free to look through that to prepare for your assignment even if using another language.

## The Pair Programming Interview

### The Challenge

During the interview, you will build a core service for our business, an Installment Calculator. There is no need to build anything before the interview, but feel free to investigate the boilerplate code and do some research on how you would set this up.

#### Installment Calculator
##### User Story

As a Zip Customer, I would like to establish a payment plan spread over 6 weeks that splits the original charge evenly over 4 installments.

##### Acceptance Criteria
- Given it is the 1st of January, 2020
- When I create an order of $100.00
- And I select 4 Installments
- And I select a frequency of 14 days
- Then I should be charged these 4 installments
  - `01/01/2020   -   $25.00`
  - `01/15/2020   -   $25.00`
  - `01/29/2020   -   $25.00`
  - `02/12/2020   -   $25.00`
