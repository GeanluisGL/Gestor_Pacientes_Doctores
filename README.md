 
# 🏥 Gestor de Pacientes y Doctores

![Versión](https://img.shields.io/badge/versión-1.0-blue)
![Estado](https://img.shields.io/badge/estado-finalizado-brightgreen)
![.NET](https://img.shields.io/badge/.NET-Core-512BD4)
![Licencia](https://img.shields.io/badge/licencia-MIT-green)

---

## 📋 Descripción del Proyecto

**Gestor de Pacientes y Doctores** es una aplicación de escritorio desarrollada en .NET Core que permite administrar de manera eficiente la información de pacientes y médicos. Este sistema está diseñado para optimizar la gestión de citas, expedientes y la relación entre doctores y pacientes en un entorno clínico o consultorio médico.

El proyecto sigue una arquitectura limpia y modular, separando claramente las capas de dominio, aplicación, infraestructura y presentación, lo que facilita su mantenimiento y escalabilidad.

---

## 🏗️ Arquitectura del Proyecto

El repositorio está organizado siguiendo los principios de **Arquitectura Limpia** y **Patrón CQRS**, con las siguientes capas:

### Estructura de Carpetas

```
Gestor_Pacientes_Doctores/
│
├── D_B.Core.Domain/          # Capa de Dominio (Entidades, Value Objects, Interfaces)
├── D_P.Core.Application/     # Capa de Aplicación (Lógica de negocio, DTOs, Servicios)
├── D_P.Core/                 # Núcleo de la aplicación (Interfaces y abstracciones comunes)
├── D_P.Domain/               # Capa de Dominio (Entidades principales y reglas de negocio)
├── D_P.InfrastructurePersistence/ # Capa de Infraestructura (Persistencia de datos, Repositorios)
├── Doctores_Pacientes/       # Capa de Presentación (Interfaz de usuario - UI)
│
├── .vs/                      # Archivos de configuración de Visual Studio
└── Doctores_Pacientes.sln    # Archivo de solución de Visual Studio
```

### Detalle de Capas

| Capa | Descripción |
|------|-------------|
| **Domain** | Contiene las entidades principales (Paciente, Doctor, Cita), los Value Objects y las reglas de negocio fundamentales. |
| **Application** | Implementa la lógica de negocio, los casos de uso y los DTOs (Data Transfer Objects) para la comunicación entre capas. |
| **Infrastructure** | Gestiona la persistencia de datos, el acceso a bases de datos y la implementación de repositorios. |
| **Presentation** | Interfaz de usuario que permite la interacción con el sistema, mostrando datos y capturando entradas del usuario. |

---

## ✨ Características Principales

- **Gestión de Pacientes**: Alta, baja, modificación y consulta de expedientes de pacientes.
- **Gestión de Doctores**: Administración del directorio de médicos, sus especialidades y horarios.
- **Asignación de Citas**: Relación entre pacientes y doctores para la gestión de consultas.
- **Historial Clínico**: Registro y seguimiento de las atenciones médicas.
- **Arquitectura Limpia**: Código organizado, desacoplado y fácil de mantener.

---

## 💻 Tecnologías Utilizadas

- **.NET Core**: Plataforma de desarrollo principal.
- **C#**: Lenguaje de programación.
- **Entity Framework Core**: ORM para la gestión de la base de datos.
- **SQL Server**: Sistema de gestión de base de datos.
- **Visual Studio**: Entorno de desarrollo integrado (IDE).
- **Patrón CQRS** (Command Query Responsibility Segregation): Separación de operaciones de lectura y escritura.

---

## 🚀 Instalación y Configuración

### Requisitos Previos

- **.NET Core SDK** (versión 3.1 o superior)
- **SQL Server** (o SQL Server Express)
- **Visual Studio 2019/2022**

### Pasos para Ejecutar el Proyecto

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/GeanluisGL/Gestor_Pacientes_Doctores.git
   ```

2. **Abrir la solución**
   - Navegar a la carpeta del proyecto y abrir el archivo `Doctores_Pacientes.sln` con Visual Studio.

3. **Configurar la conexión a la base de datos**
   - Modificar la cadena de conexión en el archivo `appsettings.json` dentro del proyecto de presentación (`Doctores_Pacientes`).
   - Ejemplo:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=GestorDB;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
     ```

4. **Aplicar migraciones de base de datos**
   - Abrir la **Consola del Administrador de Paquetes** en Visual Studio.
   - Seleccionar el proyecto de infraestructura como predeterminado.
   - Ejecutar el comando:
     ```bash
     Update-Database
     ```

5. **Ejecutar la aplicación**
   - Presionar `F5` o hacer clic en "Iniciar" en Visual Studio.

---

## 📊 Funcionalidades por Rol

| Función | Usuario | Administrador |
|---------|---------|---------------|
| Ver lista de pacientes | ✅ | ✅ |
| Gestionar pacientes | ❌ | ✅ |
| Ver lista de doctores | ✅ | ✅ |
| Gestionar doctores | ❌ | ✅ |
| Asignar citas | ✅ | ✅ |
| Ver historial médico | ✅ | ✅ |
| Gestionar usuarios | ❌ | ✅ |

---

## 🔮 Futuras Mejoras

- [ ] Implementar autenticación y autorización con roles avanzados.
- [ ] Módulo de reportes estadísticos.
- [ ] Interfaz web (migración a ASP.NET Core MVC o Blazor).
- [ ] Integración con APIs de envío de correos y SMS para recordatorios de citas.
- [ ] Soporte para múltiples clínicas o consultorios.

---

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas! Si deseas mejorar este proyecto:

1. **Fork** el repositorio.
2. **Crea una rama** para tu funcionalidad:
   ```bash
   git checkout -b feature/NuevaFuncionalidad
   ```
3. **Realiza tus cambios** y haz commit:
   ```bash
   git commit -m 'Añade: descripción de la nueva funcionalidad'
   ```
4. **Sube tus cambios**:
   ```bash
   git push origin feature/NuevaFuncionalidad
   ```
5. **Abre un Pull Request**.

---

## 📝 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.

---

## 👏 Agradecimientos

- A la comunidad de desarrolladores de .NET.
- A los profesionales de la salud por su invaluable labor.
- A todos los que contribuyan con sugerencias y mejoras al proyecto.

---

## 📧 Contacto

**Autor**: GeanluisGL  
**GitHub**: [@GeanluisGL](https://github.com/GeanluisGL)

---

**¡Gracias por usar Gestor de Pacientes y Doctores!** 🩺
```
