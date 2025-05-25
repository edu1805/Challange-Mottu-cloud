# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar arquivos necessários
COPY Challange-Mottu-dotnet/*.sln .
COPY Challange-Mottu-dotnet/Cp2WebApplication.csproj ./Challange-Mottu-dotnet/
RUN dotnet restore "Challange-Mottu-dotnet/Cp2WebApplication.csproj"

# Copiar todo o código fonte
COPY Challange-Mottu-dotnet/ ./Challange-Mottu-dotnet/

# Gerar arquivo XML de documentação e publicar
WORKDIR /src/Challange-Mottu-dotnet
RUN dotnet publish -c Release -o /app/publish \
    /p:GenerateDocumentationFile=true \
    /p:DocumentationFile=/app/publish/Cp2WebApplication.xml

# Estágio de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Adiciona usuário não-root antes de copiar arquivos
RUN addgroup --system --gid 1000 appuser && \
    adduser --system --uid 1000 --ingroup appuser --disabled-password appuser

# Copia arquivos e ajusta permissões em um único layer
COPY --from=build --chown=appuser:appuser /app/publish .

# Configurações da aplicação
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true

USER appuser

CMD ["dotnet", "Cp2WebApplication.dll"]