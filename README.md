# VirtualMachineManagement

Desarrollo pureba tecnica para la empresa ifx.corp

1. Se contruye la aplicación en .Net 8 implementado la arquitectura (clean architecture). El proyecto tiene el nombre de VirtualMachineManagement.api.
2. Se crea un proyecto Web Api "VirtualMachineManagement.Api" el cual contiene los controladores, Middlewares(para poder realizar las excepciones personalizadas) y una carpeta de contrato para las rutas.
3. Se crea un proyecto de biblioteca de clases "VirtualMachineManagement.Core" el cual tiene toda la logica del negocio "servicios, interfaces, excepciones, mappings y las entidades de negocio y dtos"
4. Se crea un proyecto de biblioteca de clases "VirtualMachineManagement.Infrastruture" el implementa el patron repositorio generico para las consultas y para los metodos de escritura.
5. Se implementa EntityFrameworkCore para los metodos de escritura y lectura (desde la clases BaseRepository).
6. Se maneja una base de datos sql server. Se agrega al final del apartado el script y bacpac. de la base de datos.
7. Se realiza creación de excepciones personalizadas BusinessException.
8. Se crea un proyecto web "VirtualMachineManagement.WebUl" el cual realiza el llamado a la api para obtener el token por medio de JWT y ese token es enviado al proyecto api para cada metodo get, post, put y delete.
9. Se implementa autenticacion con jwt el cual recibe un usario una contraseña y un rol especifico (Administrado o Developer)
10. Se crea la tabla VirtualMachine a cual va tener la informacion de las VM.
11. Se crea la tabla Usuario a cual va tener el usuario y contraseña.
11. Se crea la tabla Seguridad a cual va tener el usuario y contraseña y el rol que va a tener para realizar las peticiones.
12.  Se creo un controlador SecurityController para crear registros en la tabla Seguridad y asi crear los nuevos usuarios con su rol respectivo.
