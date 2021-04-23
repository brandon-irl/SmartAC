  # syntax=docker/dockerfile:1
  FROM mcr.microsoft.com/dotnet/aspnet:5.0
  COPY bin/Release/net5.0/publish App/
  WORKDIR /App

  #Use this  line for local dev
  ENTRYPOINT ["dotnet", "Web.dll"]
  
  #And use this line for Heroku
  #CMD ASPNETCORE_URLS=http://*:$PORT dotnet Web.dll 