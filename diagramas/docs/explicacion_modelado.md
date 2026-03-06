# Explicación del Modelado del Sistema

El sistema desarrollado corresponde a una aplicación de gestión de inventario y ventas para la tienda TechZone Solutions, especializada en productos electrónicos para computadoras.

El modelado del sistema fue realizado utilizando diagramas UML generados mediante PlantUML, lo que permite mantener el diseño versionado dentro del repositorio GitHub.

## Entidades principales del sistema

### Categoria

Permite clasificar los productos dentro del inventario de la tienda.

Atributos principales:
- Id
- Nombre
- Descripcion

---

### Producto

Representa los productos electrónicos disponibles para la venta.

Atributos principales:

- Id
- Nombre
- Marca
- PrecioBs
- Stock
- CategoriaId

Todos los valores monetarios del sistema se manejan en Bolivianos (Bs).

---

### Cliente

Representa a las personas que realizan compras en la tienda.

Atributos:

- Id
- Nombre
- Apellido
- CedulaIdentidad
- Telefono

La cédula de identidad permite identificar de forma única a cada cliente dentro del sistema.

---

### Venta

Representa una transacción realizada en la tienda.

Atributos:

- Id
- FechaVenta
- TotalVentaBs
- ClienteId

El total de la venta se calcula automáticamente a partir de los productos vendidos.

---

### DetalleVenta

Permite registrar los productos incluidos dentro de una venta.

Atributos:

- Id
- Cantidad
- PrecioUnitarioBs
- SubtotalBs
- ProductoId
- VentaId

El subtotal se calcula multiplicando el precio unitario por la cantidad vendida.

---

## Relaciones entre entidades

Categoria clasifica múltiples productos.

Un cliente puede realizar múltiples ventas.

Una venta puede contener varios detalles de venta.

Cada detalle de venta corresponde a un producto específico.

---

## Objetivo del modelo

Este diseño permite gestionar correctamente:

- inventario de productos
- registro de clientes
- registro de ventas
- cálculo automático de montos en Bolivianos
- control del stock disponible

El modelo está preparado para ser implementado posteriormente en una aplicación web utilizando ASP.NET MVC, Entity Framework y SQL Server.
