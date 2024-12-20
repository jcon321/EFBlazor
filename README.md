# LibraryBlazorCRUD2


vs2022
new project, "Blazor Web App"
do not place proj and solution in same dir - so test proj can be added
.net 8 lts
no auth, configure https, rendermode=server per page/component, include sample pages, dont use top lvl statements, no aspire
used vs to create git repo, added readme, added default .gitignore
deleted sample project files
added ef core with sqllite
	dotnet add package Microsoft.EntityFrameworkCore.Sqlite
	dotnet add package Microsoft.EntityFrameworkCore.Design
	dotnet add package Microsoft.EntityFrameworkCore.Tools
added base models and dbcontext
registered dbcontext/datasource in program.cs
did migrations
	dotnet ef migrations add InitialCreate
	dotnet ef database update
added services
create new test project, "Console App"
.net 8 lt, do not use top level statements
deleted program.cs
in vs added project reference to main project
added servicetest classes
added test packages
	dotnet add package xunit
	dotnet add package xunit.runner.visualstudio
	dotnet add package Microsoft.NET.Test.Sdk
	dotnet add package Microsoft.EntityFrameworkCore.InMemory
tests passed
added razor pages