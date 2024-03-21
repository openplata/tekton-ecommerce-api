# TEKTON ECOMMERCE API
#### Demo on line en:
https://tekton-ecommerce-api.openplata.com/docs/specification/index.html

# Breve descripción del patrón y arquitectura usada en el proyecto

La arquitectura implementada sigue el enfoque de Microservicios, que es un estilo arquitectónico donde una aplicación se compone de varios servicios pequeños, independientes y altamente cohesionados, cada uno de los cuales se enfoca en realizar una tarea específica dentro del dominio del negocio. Estos servicios se pueden desarrollar, desplegar y escalar de forma independiente, lo que permite una mayor flexibilidad y mantenibilidad del sistema en su conjunto.

El patrón utilizado en esta arquitectura es el CQRS (Command Query Responsibility Segregation), que propone separar las operaciones de lectura (consultas) de las operaciones de escritura (comandos) en modelos de dominio distintos. Esto se refleja en la estructura de la aplicación de la siguiente manera:

### Api (Tekton.ECommerce.Api): 
Este es el punto de entrada de la aplicación donde se exponen los endpoints para interactuar con los servicios. Aquí se reciben las solicitudes del cliente y se gestionan las respuestas.

### CrossCutting:
##### Tekton.ECommerce.Dto: 
Contiene los objetos de transferencia de datos (DTO) que se utilizan para comunicarse entre la capa de aplicación y la capa de presentación (cliente).
##### Tekton.ECommerce.Map: 
Aquí se realizan los mapeos entre las entidades del dominio y los DTO, lo que facilita la transferencia de datos entre capas.
##### Tekton.ECommerce.Utility: 
Contiene clases o funciones de apoyo que pueden ser utilizadas en diferentes partes de la aplicación.

# Core:

### Application:
##### Tekton.ECommerce.Application: 
Aquí residen los servicios del API, implementando la lógica de negocio y manipulando los datos. Estos servicios se comunican con la capa de persistencia para realizar operaciones CRUD.

##### Tekton.ECommerce.IApplication: 
Aquí residen las interfaces de los servicios del API.

### Domain:
##### Tekton.ECommerce.Domain.Entity: 
Contiene las entidades del dominio que representan los conceptos principales del negocio.
##### Tekton.ECommerce.Domain.ICommand: 
Define las interfaces para los comandos, que representan las operaciones de escritura.
##### Tekton.ECommerce.Domain.IQuery: 
Define las interfaces para las consultas, que representan las operaciones de lectura.

# Infraestructure:

### Persistence:
#### Tekton.ECommerce.Persistence.SQLServer: 
Aquí se implementan las clases que se comunican con la base de datos SQL Server para realizar operaciones de persistencia.

# Tabla de Contenido de los directorios

## 00 Docs
Se encuenta el manual de instalación en el ambiente de desarrollo y en el ambiente productivo.

## 01 installers
Se encuentra el instalador del redis .

## 02 database
Script de los objetos creados para el motor de base de datos SQL Server 2019.

## 03 src
Fuentes del API.

## 04 resources
Paquetes Nuget creados para la implementación.

## 05 postman
Json de las colecciones y del develop environment.

