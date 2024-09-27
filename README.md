# ModularMonolith
This is a modular monolith approach for a bookstore application

# Pre requisites
In order to run, you have first to install some things beforehand:
- Must have EF Core tools installed
	> `dotnet tool install --global dotnet-ef`
	or maybe you just gotta update it.
	> `dotnet tool update --global dotnet-ef`
- Default Instance of LocalDB with integrated security
	- Can be replaced, but just for the sake of the example, we used MSSQL LocalDB