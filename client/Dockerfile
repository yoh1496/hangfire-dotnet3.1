FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY bin/Release/netcoreapp3.1/publish /opt/app/
WORKDIR /opt/app/

ENTRYPOINT [ "dotnet", "client.dll" ]