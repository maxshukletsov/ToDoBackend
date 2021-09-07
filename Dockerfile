ARG registry=mcr.microsoft.com
ARG nuget=https://api.nuget.org/v3/index.json

FROM ${registry}/dotnet/sdk:5.0 AS build

WORKDIR /app

COPY *.sln .
COPY API/*.csproj ./API/
COPY Application/*.csproj ./Application/
COPY DataAccess/*.csproj ./DataAccess/
COPY Domain/*.csproj ./Domain/

RUN dotnet restore "API/API.csproj"

COPY . .

RUN dotnet publish API --runtime linux-musl-x64 -c Release -o out

FROM ${registry}/dotnet/runtime-deps:5.0-alpine3.12
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["./API"]