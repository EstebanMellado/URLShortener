# Introduction
Acortador de direcciones WebAPI. Crea un token alfanumerico aleatorio a partir de una URL válida (ejemplo: https://miweb.com)

### CRUD de URL:
1. Se puede obtener todas las URLs generadas
2. Obtener una URL a partir de la URL corta
3. Obtener una URL a partir de la URL larga
4. Crear una URL corta a partir de una URL larga válida
5. Eliminar una URL corta

### Estadísticas:
1. Obtener las cantidades de veces que se usaron cada URL

### Logs:
Usando Serilog, se registra la creación y eliminación de URL cortas. 


# Get Started
## Requisitos
- .NET Core 3.1
- Docker
- Heroku CLI
- MongoDb

# Deploy to Heroku
En la carpeta de la solución:
```bash
dotnet publish -c Release
```
Agregar un Dockerfile en la ruta del _publish_ (<RUTA_AL_PROYECTO>\\URLShortener\\URLShortener.Api\\bin\\Release\\netcoreapp3.1\\publish) con el siguiente contenido:
```Dockerfile
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet URLShortener.Api.dll
```
Luego creamos la imágen
```bash
docker build -t urlshortenerserviceapi <RUTA_AL_PROYECTO>\\URLShortener\\URLShortener.Api\\bin\\Release\\netcoreapp3.1\\publish
```
Creamos un tag
```bash
docker tag urlshortenerserviceapi registry.heroku.com/urlshortenerserviceapi/web
```
Y la registramos
```bash
docker push registry.heroku.com/urlshortenerserviceapi/web
```
Debemos iniciar sesión en heroku a través de la terminal:
```bash
heroku login
```
```bash
heroku container:login
```
Creamos una nueva app en heroku. (si ya está creada no hace falta)
```bash
heroku apps:create urlshortenerserviceapi
```
Y por último subimos nuestra imágen de Docker a heroku
```bash
heroku container:release web -a urlshortenerserviceapi
```
Finalmente si vamos al [dashboard de heroku](https://dashboard.heroku.com/apps) veremos nuestra app
