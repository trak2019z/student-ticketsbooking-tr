FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Microservices.Booking/Microservices.Booking.csproj Microservices.Booking/
RUN dotnet restore Microservices.Booking/Microservices.Booking.csproj
COPY . .
WORKDIR /src/Microservices.Booking
RUN dotnet build Microservices.Booking.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservices.Booking.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservices.Booking.dll"]
