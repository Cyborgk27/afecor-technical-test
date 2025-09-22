# Guía para levantar el proyecto

Este proyecto tiene un **frontend en Angular**, un **backend en .NET** y una **base de datos** que se recomienda levantar con Docker. Sigue los pasos a continuación para ponerlo en marcha.

---

## 1. Levantar la base de datos con Docker

1. Asegúrate de tener **Docker** y **Docker Compose** instalados en tu máquina.
2. Desde la raíz del proyecto, ejecuta el siguiente comando:

```bash
docker-compose up -d
```

Esto levantará los contenedores necesarios, incluyendo la base de datos.

2. Configurar la base de datos
Abre tu herramienta preferida de administración de bases de datos (por ejemplo, DBAdmin, SQL Server Management Studio, según corresponda).

Ejecuta el script SQL que inicializa la base de datos y las tablas necesarias. Esto es importante para que la API funcione correctamente.

3. Levantar el backend (.NET API)
Navega a la carpeta del proyecto backend.

