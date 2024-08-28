# Usar una imagen base del SDK de .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Establecer el directorio de trabajo
WORKDIR /app

# Copiar los archivos csproj y restaurar las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos del proyecto
COPY . ./

# Exponer el puerto que utiliza la aplicación
EXPOSE 5233

# Comando para mantener el contenedor en ejecución, `dotnet watch` se manejará desde docker-compose
CMD ["tail", "-f", "/dev/null"]
