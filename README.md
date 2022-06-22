EasyOrder

## Entidades básicas 📄

- User
- Menu
- Order


| Entidad | Propiedades |
| ----- | ----- |
| User | Nombre, Apellido, Email, Password, Id |
| Menu | Nombre, Precio, Descripción, Id |
| Order | Precio, Nro. Mesa, Menu elegido, Observaciones, Fecha de creación, UsuarioId |


---------------------------------------

## Características y Funcionalidades ⌨️

### Usuario

- Los usuarios se crean con Nombre, Apellido, Correo electrónico y contraseña.
- Si el usuario/email YA EXISTE entonces, no lo vuelve a crear. 
- Los campos son todos obligatorios


### Menu

- Solo el usuario administrador puede crear/modificar el menu.

### Pedidos

- Un usuario puede crear un pedido solicitado por el cliente.