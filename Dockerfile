FROM mcr.microsoft.com/dotnet/aspnet:3.1
COPY BookStore-BackEnd/bin/Debug/netcoreapp3.1/ .
ENTRYPOINT ["dotnet", "BookStore-BackEnd.dll"]