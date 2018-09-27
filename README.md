dotnet new sln -o Restaurants
cd Restaurants/

dotnet new classlib -o Restaurants.Domain.Core
dotnet new classlib -o Restaurants.Application
dotnet new classlib -o Restaurants.Domain
dotnet new classlib -o Restaurants.Data
dotnet new classlib -o Restaurants.Infra.Crosscutting
dotnet new webapi -o Restaurants.Api
 
dotnet sln Restaurants.sln add Restaurants.Application/*.csproj
dotnet sln Restaurants.sln add Restaurants.Domain.Core/*.csproj
dotnet sln Restaurants.sln add Restaurants.Domain/*.csproj
dotnet sln Restaurants.sln add Restaurants.Data/*.csproj
dotnet sln Restaurants.sln add Restaurants.Infra.Crosscutting/*.csproj
dotnet sln Restaurants.sln add Restaurants.Api/*.csproj


dotnet add Restaurants.Application/*.csproj reference Restaurants.Domain/*.csproj
dotnet add Restaurants.Application/*.csproj reference Restaurants.Data/*.csproj

dotnet add Restaurants.Domain/*.csproj reference Restaurants.Domain.Core/*.csproj

dotnet add Restaurants.Data/*.csproj reference Restaurants.Domain/*.csproj

dotnet add Restaurants.Api/*.csproj reference Restaurants.Application/*.csproj
dotnet add Restaurants.Api/*.csproj reference Restaurants.Infra.Crosscutting/*.csproj

dotnet add Restaurants.Data/*.csproj package Microsoft.EntityFrameworkCore.Design
dotnet add Restaurants.Data/*.csproj package Microsoft.EntityFrameworkCore.SqlServer
dotnet add Restaurants.Data/*.csproj package Microsoft.Extensions.Configuration.FileExtensions
dotnet add Restaurants.Data/*.csproj package Microsoft.Extensions.Configuration.Json

dotnet add Restaurants.Infra.Crosscutting/*.csproj reference Restaurants.Application/*.csproj
dotnet add Restaurants.Infra.Crosscutting/*.csproj reference Restaurants.Domain/*.csproj
dotnet add Restaurants.Infra.Crosscutting/*.csproj reference Restaurants.Data/*.csproj

dotnet add Restaurants.Application/*.csproj package AutoMapper

dotnet add Restaurants.Api/*.csproj package AutoMapper.Extensions.Microsoft.DependencyInjection

cd Restaurants.Data
dotnet ef migrations add InitialCreate
dotnet ef database update
cd ..

