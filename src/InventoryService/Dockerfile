FROM microsoft/aspnetcore

WORKDIR /app

COPY bin/Release/PublishOutput .

ENTRYPOINT ["dotnet", "InventoryService.dll"]