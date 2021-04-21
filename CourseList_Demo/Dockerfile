FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app


COPY *.csproj ./
RUN dotnet restore


COPY . ./
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
# ENTRYPOINT [ "dotnet", "HerokuApp.dll" ]
# Use the following instead for Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CourseList_Demo.dll