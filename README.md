# Proyecto Task Manager
El proposito del proyecto fue Generar APIs REST en NET Core simulando la generación de tareas. se realizó el diseño, creación de la BD, y desarrollo de las APIS. La información se muestra a través de swagger, pero pueden ser consumidas desde cualquier aplicación de terceros (Postman, Insomnia, Hoppscotch, etc).

Dentro del proyecto se considera lo siguiente:

* El tipo de proyecto generado es de tipo **Web API Net Core** usando la versión de .NET 8.

* Se uso la metodología de **CodeFirst** para la generación de la Base de dato.

* Se realizó la implementación del **Patrón repository** dentro del proyecto.

* Se hizo uso de las **Migrations** para la BD en SQL Server.

* Se hace uso **Dependency Injection** para los servicios de **DbContext y Mapper**

* Se realiza la implementación de **middleware** para manejo de respuestas HTTP adecuadas.

* Se hace uso de **Fluent Validation** para validaciones en los payloads de entrada (Titulo no
puede estar vacio, no se puede exceder mas de 50 caracteres, el status debe ser Pending,
InProgress, o Completed).

* Se realiza la documentación haciendo uso de Swagger por medio de los atributos y
decoradores que aparecen el controlador.

## Tecnologías utilizadas:
* .NET Core 8
* .ORM Entity Framework Core 9

## Tipos de proyectos generados:
* .ASP.NET Core Web API
* .Proyecto de BD SQL Server

## Ejecución del proyecto
Una vez descargado el proyecto, sera necesario abrir el proyecto con Visual Studio 2022 ademas de tener SQL server en el equipo donde se realizara la prueba.

Dentro del proyecto existe una migración de la BD, por lo que será necesario corroborar si el ConnectionString es de acuerdo al equipo en donde se esta probando. En otro caso se puede modificar en el archivo “appsettings.Development.json”.

https://github.com/ivan3911/TaskManager/blob/master/assets/ConnectionString.png

![ConnectionString](https://github.com/ivan3911/TaskManager/blob/master/assets/ConnectionString.png)

Una vez que la ruta se encuentre de manera correcta, podemos dirigirnos hacia la consola del administrador de paquetes nuget y colocar la instrucción “update- database” como se muestra en la imagen siguiente.

![UpdateDatabase](https://github.com/ivan3911/TaskManager/blob/master/assets/UpdateDatabase.png)

Posteriormente

![DBSQL](https://github.com/ivan3911/TaskManager/blob/master/assets/DBSQL.png)

Al ejecutar el proyecto deberan aparecer todos los endpoint con su respectivo funcionamiento.

![endpoints](https://github.com/ivan3911/TaskManager/blob/master/assets/endpoints.png)


## Acerca del proyecto

Se crea la entidad correspondiente a la tabla tareas.

   ![EntityTask](https://github.com/ivan3911/TaskManager/blob/master/assets/EntityTask.png)

Son considerados los siguientes paquetes dentro del proyecto.

   ![PackagesInProject](https://github.com/ivan3911/TaskManager/blob/master/assets/PackagesInProject.png)

Implementación del Patron Repository.

   ![PatronRepository](https://github.com/ivan3911/TaskManager/blob/master/assets/PatronRepository.png)


Uso de la inyección de dependencias.

   ![DependecyInjection](https://github.com/ivan3911/TaskManager/blob/master/assets/DependecyInjection.png)

Implementación del middleware.

   ![Middleware](https://github.com/ivan3911/TaskManager/blob/master/assets/Middleware.png)
   
Validaciones con FluentValidation

   ![FluentValidation](https://github.com/ivan3911/TaskManager/blob/master/assets/FluentValidation.png)

Documentación Swagger

   ![Swagger](https://github.com/ivan3911/TaskManager/blob/master/assets/Swagger.png)
