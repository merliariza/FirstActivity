# Sistema de Encuestas

Un sistema completo de gestión de encuestas desarrollado con tecnologías .NET modernas, diseñado para crear, administrar y analizar encuestas de manera eficiente.

## 🛠️ Tecnologías Utilizadas

- **Backend**: C# .NET 8
- **ORM**: Entity Framework Core 8.x
- **Base de Datos**: MySQL 8.0+
- **Arquitectura**: Code First con Entity Framework

## Estructura de la Base de Datos

El sistema está diseñado con un modelo relacional robusto que incluye las siguientes entidades principales:

### Entidades Principales

- **Surveys (Encuestas)**: Contenedor principal de cada encuesta
- **Chapters (Capítulos)**: Organización jerárquica de las encuestas
- **Questions (Preguntas)**: Preguntas individuales dentro de cada capítulo
- **Categories Catalog**: Catálogo de categorías para clasificación
- **Category Options**: Opciones disponibles para cada categoría
- **Sub Questions**: Preguntas anidadas para mayor granularidad
- **Option Questions**: Preguntas con opciones de selección múltiple
- **Options Response**: Respuestas a las opciones de preguntas
- **Summary Options**: Opciones de resumen y análisis

### Características del Modelo

- **Auditoría completa**: Todas las tablas incluyen campos `created_at` y `updated_at`
- **Relaciones bien definidas**: Foreign keys que garantizan la integridad referencial
- **Flexibilidad**: Soporte para diferentes tipos de preguntas y respuestas
- **Escalabilidad**: Diseño preparado para grandes volúmenes de datos

## Configuración del Proyecto

### Prerrequisitos

- .NET 8 SDK
- MySQL Server 8.0+
- Visual Studio 2022 / VS Code
- MySQL Workbench (opcional, para administración de BD)

### Instalación

1. **Clonar el repositorio**

   ```bash
   git clone [url-del-repositorio]
   cd sistema-encuestas
   ```

2. **Configurar la cadena de conexión**

   Actualiza el archivo `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=survey_system;Uid=root;Pwd=tu_password;"
     }
   }
   ```

3. **Instalar dependencias**

   ```bash
   dotnet restore
   ```

4. **Aplicar migraciones**

   ```bash
   dotnet ef database update
   ```

5. **Ejecutar la aplicación**

   ```bash
   dotnet run
   ```

