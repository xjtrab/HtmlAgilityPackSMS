FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["HtmlAgilityPackSMS.csproj", "./"]
RUN dotnet restore "./HtmlAgilityPackSMS.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "HtmlAgilityPackSMS.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HtmlAgilityPackSMS.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HtmlAgilityPackSMS.dll"]
ENV Development=Development
ENV DbConnectionString=Server=localhost;Port=3307;Database=ef;User=root;Password=wo113661;
ENV AdminEmailAccount=xjtrab
ENV AdminEmailPassword=test