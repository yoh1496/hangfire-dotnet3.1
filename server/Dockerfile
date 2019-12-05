FROM mcr.microsoft.com/dotnet/core/runtime:3.0

COPY bin/Release/netcoreapp3.0/publish /opt/app
WORKDIR /opt/app

ENTRYPOINT ["dotnet", "server.dll"]