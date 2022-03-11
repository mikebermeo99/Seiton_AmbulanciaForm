# Seiton_AmbulanciaForm
### Dependencias
1. Visual Studio 2019 (C#)
2. Postgres 13

### Base de Datos (Postgres 13)

1. Abrir una consola o shell y crear la base de datos.
```bash
$ psql -U postgres
# CREATE DATABASE "seiton";
# \q
```
2. Crear la estructura de tablas ejecutando el script **ambulancia.sql**.
```bash
$ cd Seiton_ambulanciaForm
$ psql -U postgres seiton < ambulancia.sql
```
### Contacto

- Consultas o dudas: [mike.bermeo@yachaytech.edu.ec](mailto:mike.bermeo@yachaytech.edu.ec)
