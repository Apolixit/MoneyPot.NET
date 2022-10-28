#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MoneyPot_BlazorFront/MoneyPot_BlazorFront.csproj", "MoneyPot_BlazorFront/"]
COPY ["Shared_MoneyPot/MoneyPot_Shared.csproj", "Shared_MoneyPot/"]
COPY ["MoneyPot_NetApiExt/MoneyPot_NetApiExt.csproj", "MoneyPot_NetApiExt/"]
COPY ["MoneyPot_RestClient/MoneyPot_RestClient.csproj", "MoneyPot_RestClient/"]
RUN dotnet restore "MoneyPot_BlazorFront/MoneyPot_BlazorFront.csproj"
COPY . .
WORKDIR "/src/MoneyPot_BlazorFront"
RUN dotnet build "MoneyPot_BlazorFront.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MoneyPot_BlazorFront.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoneyPot_BlazorFront.dll"]