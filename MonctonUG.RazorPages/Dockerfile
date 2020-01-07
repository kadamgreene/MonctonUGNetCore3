FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY MonctonUG.RazorPages/MonctonUG.RazorPages.csproj MonctonUG.RazorPages/
RUN dotnet restore "MonctonUG.RazorPages/MonctonUG.RazorPages.csproj"
COPY . .
WORKDIR "/src/MonctonUG.RazorPages"
RUN dotnet build "MonctonUG.RazorPages.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MonctonUG.RazorPages.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MonctonUG.RazorPages.dll"]
