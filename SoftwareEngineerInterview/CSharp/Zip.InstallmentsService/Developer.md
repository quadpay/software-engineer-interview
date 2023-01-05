Project - Calculate Payment Installment

Description - Based on data provided by user calculate installment details and store them into DB. And based on unique Id user can fetch installment details as well.

Below are prerequisites to run the projects

Prerequisite - 
Visual Studio 2022 
Sql Server Management Studio 2018

Services - 
Exposed Layer - InstallmentCalculationAPI
Business logic -  Zip.InstallmentService 
Data Access Logic - Zip.InstallmentService.DataAccess
Test Project - Zip.InstallmentService.Test 

Nuget Packages -
NLog(5.1.0) 
NLog.Extensions.Logging(5.2.0)
SwashBuckle.AspNetCore(6.2.3)
System.Data.SqlClient(4.8.5) 
Misrosoft.Extension.Configuration(7.0.0) 
Moq(4.18.3)
Microsoft.AspNetCore.MVC.Versioning(5.0.0)
Microsoft.EntityFrameworkCore.SqlServer(7.0.1)


Logging nlog.config path - {baseDir}\log-{shortdate}.log

DB Details -
Microsoft SQL Server Management Studio 18
Database Name - PaymentInstallment
Table Names -
1. Installments 
	Id - Primary Key,uniqueidentifier
	DueDate - Date
	Amount - decimal
	PaymentPlanId - uniqueidentifier (foreign key-Id in Payment Plan)
2. PaymentPlan 
	Id - Primary Key,uniqueidentifier
	PurchaseAmount - decimal

Exposed APIs -
1. CreatePaymentPlan -
	Input Parameters 
	a. startDate - Date from installment start
	b. orderAmount - toatl purchase amount
	c. installments - Total number of installments 
	d. frequencyOfInstallment - gap between two installments in days

postman url - https://localhost:7033/api/v1/InstallmentCalculation
sample input - 
{
"startDate": "2022-12-21T07:09:55.305Z",
"orderAmount": 200,
"installments": 4,
"frequencyOfInstallment":20 
}
2. GetInstallmentSummary -
	Input Parameters
	a. guid - unique id of payment installment

postman url/sample input - https://localhost:7033/api/v1/InstallmentCalculation?guid=BBA85D17-3F6B-4839-B0C0-F1E3FAE7B454
 
