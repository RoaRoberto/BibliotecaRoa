<h1 align="center">Bienvenido a Biblioteca Roa 👋</h1>
<p>
 
  <a href="tarjet//dd" target="_blank">
    <img alt="Documentation" src="https://img.shields.io/badge/documentation-yes-brightgreen.svg" />
  </a>
  
</p>

> Challenge Tecnico Nexos

### 🏠 Homepage

Web Api que permite administrar Libros y Autores

* DotnetCore 3.1
* Oracle Entity Framework core 5.2

Front en Angular que permite interactuar con el Web Api y con el Usuario Final

* Angular CLI: 12.2.10
* Node: 12.18.4
* Package Manager: npm 6.14.6
* OS: win32 x64
* ng-bootstrap/ng-bootstrap 10
* bootstrap 4.5







## Configuración
 
Modificar el archivo appsettings.json
 
1. Cambiar los valores de la cadena de conexion a la base de datos oracle
 
 ```sh
	 "ConnectionStrings": {    
		"myconn": "User Id=system;Password=oracle;Data Source=192.168.0.9:49161/xe;"
	  }
```

2. Cambiar los valores de la llave maximaCantidadLibros , por defecto esta en 3
 
```sh
	 "maximaCantidadLibros": 3,
```

3. correr el script "script base de datos .sql" ubicado en la carpeta documentacion



## Desplegar el web Api

para correr el web api , ejecutar las siguientes sentencias en una terminal.

```sh
    dotnet clean
    dotnet build
	dotnet run
```

## Desplegar el Front Angular

Para desplegar el proyecto front ejecutar las siguientes sentencia en una terminal ubicada en la raiz del proyecto

```sh
    npm install
	ng serve -o
```

## Rutas Web Api
El proyecto web api se despliega en localhost por el puerto 44336
y este cuenta con los siguientes endpoints:

Libros
```sh
 Url Base https://localhost:44336/api/libro
 
 * Post  
 * Put
 * Delete
 * Get
 * GetById
```

Autores
```sh
 Url Base https://localhost:44336/api/autor
 
 * Post  
 * Put
 * Delete
 * Get
 * GetById
```

Ciudades
```sh
 Url Base https://localhost:44336/api/ciudad
 
 * Post  
 * Put
 * Delete
 * Get
 * GetById
```

nota: en la carpeta de documentacion se encuentra el archivo libreriaCollection.postman_collection.json, que puede ser importado desde Postman para hacer las pruebas de los endpoints.


## Rutas Front End

El proyecto Angular se despliega en localhost por el puerto 4200



## Author

👤 **Roberto Ferney Contreras Roa**

* Website:  https://www.linkedin.com/in/roberto-contreras-76a3b017a/

* Github: [@RoaRoberto](https://github.com/roaroberto)
* LinkedIn: [@roberto-contreras-76a3b017a](https://www.linkedin.com/in/roberto-contreras-76a3b017a/)

### Show your support

Give a ⭐️ if this project helped you!

***
_This README was generated with ❤️ by [readme-md-generator](https://github.com/kefranabg/readme-md-generator)_