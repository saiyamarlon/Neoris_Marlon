FROM mcr.microsoft.com/dotnet/nightly/sdk:6.0 AS build
WORKDIR webapp

EXPOSE 80
EXPOSE 5001

COPY ./*.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/nightly/sdk:6.0
WORKDIR /webapp
COPY --from=build /webapp/out/ .

ENTRYPOINT [ "dotnet", "Test_1.dll" ]
