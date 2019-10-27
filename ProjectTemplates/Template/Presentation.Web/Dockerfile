#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-nanoserver-1809 AS build
WORKDIR /src
COPY ["$ext_safeprojectname$/$ext_safeprojectname$.Presentation.Web/$ext_safeprojectname$.Presentation.Web.csproj", "$ext_safeprojectname$/$ext_safeprojectname$.Presentation.Web/"]
COPY ["$ext_safeprojectname$/$ext_safeprojectname$.Application/$ext_safeprojectname$.Application.csproj", "$ext_safeprojectname$/$ext_safeprojectname$.Application/"]
COPY ["$ext_safeprojectname$/$ext_safeprojectname$.Domain/$ext_safeprojectname$.Domain.csproj", "$ext_safeprojectname$/$ext_safeprojectname$.Domain/"]
COPY ["$ext_safeprojectname$/$ext_safeprojectname$.Persistence/$ext_safeprojectname$.Persistence.csproj", "$ext_safeprojectname$/$ext_safeprojectname$.Persistence/"]
COPY ["$ext_safeprojectname$/$ext_safeprojectname$.Resources/$ext_safeprojectname$.Resources.csproj", "$ext_safeprojectname$/$ext_safeprojectname$.Resources/"]
RUN dotnet restore "$ext_safeprojectname$/$ext_safeprojectname$.Presentation.Web/$ext_safeprojectname$.Presentation.Web.csproj"
COPY . .
WORKDIR "/src/$ext_safeprojectname$/$ext_safeprojectname$.Presentation.Web"
RUN dotnet build "$ext_safeprojectname$.Presentation.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "$ext_safeprojectname$.Presentation.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "$ext_safeprojectname$.Presentation.Web.dll"]