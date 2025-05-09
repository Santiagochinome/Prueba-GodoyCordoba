### API .NET 8 
**REQUISITOS**

- NET SDK es necesario para ejecutar el backend (API en C#).

En este caso se utilizo .NET 8 y utiliza los siguientes paquetes:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tool
- Swashbuckle.AspNetCore

Ademas de instalar SQL SERVER Management Studio 20.

**Conexion a SQL SERVER**
![image](https://github.com/user-attachments/assets/7a5dd04b-4bc1-49c9-838e-2eec7736bcdb)

La conexion se encuentra en el archivo **Program.cs** en la linea 18, esta por defecto para que se conecte con la autenticación del sistema, pero se puede cambiar para solicitar credenciales si se quiere: 

```
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=localhost;Database=CatFactDb;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;TrustServerCertificate=True"));
```
Tambien se configuro el CORS (Cross-Origin Resource Sharing) en la API para que el **frontend(Vue)** pueda comunicarse con el backend sin ser bloqueado por el navegador por motivos de seguridad.
![image](https://github.com/user-attachments/assets/60eced99-6061-40d7-9562-636bf603a386)

```
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:8082")  // 👈 Solo permite peticiones desde este origen (tu frontend Vue)
              .AllowAnyMethod()                      // 👈 Permite todos los métodos HTTP: GET, POST, PUT, etc.
              .AllowAnyHeader();                     // 👈 Permite todos los headers en las peticiones
    });
});
```
Por favor, actualiza la configuración del puerto para este proyecto. **El frontend (Vue)** utilizará este puerto para establecer la comunicación, asi que el puerto que utilice Vue en su equipo, remplácelo en esta parte. Es importante verificar esta configuración para asegurar una conexión exitosa.
Este se encuentra ubicado en el archivo **Program.cs** en la linea 22 hasta la linea 30, pero siendo la que importa la linea 26.

Esta seria la configuración para que el API funcione adecuadamente, no olvidar cargar la base de datos que esta como un archivo .bak llamado **CatFactDb.bak**.

### Frontend (Vue)
`<Enlace descarga>` : <https://nodejs.org/es>
