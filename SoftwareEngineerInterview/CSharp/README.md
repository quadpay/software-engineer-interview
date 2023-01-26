# CSharp Project

## Requirements
```
Visual Studio Code
Dotnet SDK 6.0
```

## Install
```
cd Zip.InstallmentsService
dotnet restore
```

## Quick Start
```
cd Zip.InstallmentsService\ZipPayment.API
dotnet run
```

## Run Tests
```
cd Zip.InstallmentsService
dotnet test Zip.InstallmentsService.sln
```

## Install Entity framework and update database
```
cd Zip.InstallmentsService
dotnet tool install --global dotnet-ef --version 6.*

cd Zip.InstallmentsService\ZipPayment.API
dotnet ef database update
```

## Api endpoint document and specifications
```
https://localhost:7211/index.html
https://localhost:7211/swagger/ZipPaymentOpenAPISpecification/swagger.json

http://localhost:5211/index.html
http://localhost:5211/swagger/ZipPaymentOpenAPISpecification/swagger.json
```
