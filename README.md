### API .NET 8 
**REQUISITOS**

- NET SDK es necesario para ejecutar el backend (API en C#).

En este caso se utilizo .NET 8 y utiliza los siguientes paquetes:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tool
- Swashbuckle.AspNetCore

Ademas de instalar SQL SERVER Management Studio 20.

`<Enlace descarga SDK>` : <https://dotnet.microsoft.com/es-es/download/dotnet>

`<Enlace descarga Visual Studio>` : <https://visualstudio.microsoft.com/es/vs/community/>

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

Importante ejecutar la API en **http** porque en primera instancia los certificados SSL no están configurados localmente, entonces para no tener problemas se ejecuta de esta manera.

![image](https://github.com/user-attachments/assets/f4b5bcec-7974-4362-9573-c58854668c2f)


Esta seria la configuración para que el API funcione adecuadamente, no olvidar cargar la base de datos que esta como un archivo .bak llamado **CatFactDb.bak**.

### Frontend (Vue)
**REQUISITOS**
Instalar Node.js y nmp en su ultima versión
- Node.js es necesario para ejecutar el frontend (Vue.js).
- npm es el gestor de paquetes de Node.js.
- 
`<Enlace descarga>` : <https://nodejs.org/es>

Tener cuidado ya que en algunas ocaciones se puede presentar el error "No se puede ejecutar el archivo por que la ejecución de scripts esta deshabilitada" lo cual ya es una configuración que se tiene que realizar
en su equipo. 
Si todo salio bien, se tendra que tener un editor de código en este caso de utiliza ***Visual Studio Code** para mayor comodidad. 

`<Enlace descarga>` : <https://code.visualstudio.com/download>

Cargado el proyecto se tendran que realizar las siguientes configuraciones:

**Puertos de comunicación** 

En la ruta **cat-fact-gif\src\components** esta el archivo **CurrentResult.vue** donde estara la variable **API_BASE_URL** en la linea 21 y en esta unicamente se cambiara el puerto y se colocara el que usa el API.

![image](https://github.com/user-attachments/assets/7b87330d-6b0f-4690-8372-3bffbd18ea4e)

Lo mismo se realizara para la siguiente ruta **cat-fact-gif\src\components** en el archivo **SearchHistory.vue** en la linea 38, donde se cambiara el puerto y se colocara el que usa el API.

![image](https://github.com/user-attachments/assets/405c6516-8ddb-4104-a8d9-d1e10b81c655)

Esta seria la unica configuración que se tendria que hacer por la parte del Frontend.


### Ejecutar Proyecto

1. Primero se tendra que ejecutar el API que al momento de hacer nos tendra que salir esto: 
![image](https://github.com/user-attachments/assets/b06a5e7f-2fa5-49bf-aa45-f16ea4358b3e)

Como se puede ver, nos indica el puerto que va usar y el cual tendremos que colocar en las configuraciones para el **Frontend (Vue)**.

2. Ejecutamos el **Frontend (Vue)** abriendo una terminal  en la carpeta raiz de nuestro poryecto y ejecutando el siguiente comando:
 ```
npm run serve
```
![image](https://github.com/user-attachments/assets/25fdd5ea-fccb-4ed7-a80a-f5455f01bc58)

Al momento de ejecutarlo nos dara lo siguiente:

![image](https://github.com/user-attachments/assets/003489bd-2ed8-493c-a191-97b772e41f89)

Copiaremos ese ruta y la pegaremos en nuestro navegador (Recomendado ejecutarlos en Microsfot Edge) y nos dara el siguiente resultado

![image](https://github.com/user-attachments/assets/4916db85-8a2c-4285-9ebe-aecb243e57cf)

ya pudiendo interactual con el programa.
