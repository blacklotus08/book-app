# book-app

#Develop Backend Structure Format
#Configure DTO > Entity > Repository > Register Service (Infrastructure Service) > Business Logic (Management) > Register Service (Application Service) > Api

#Setup Migration

#Run dotnet ef migrations add InitialCreate --project Library.Infrastructure --startup-project Library.Api in root directory of service folder

#Run dotnet ef database update --project Library.Infrastructure --startup-project Library.Api in root directory of service folder
