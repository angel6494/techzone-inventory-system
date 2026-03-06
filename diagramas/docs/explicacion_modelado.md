# Explicación del Modelado del Sistema

Para el sistema de gestión de inventario de la tienda TechZone Solutions se definieron tres entidades principales:

## Producto
Representa los productos electrónicos disponibles en la tienda.

Atributos:
- Id
- Nombre
- Marca
- Precio
- Stock

## Categoria
Permite clasificar los productos en diferentes grupos.

Atributos:
- Id
- Nombre
- Descripcion

## Venta
Representa las ventas realizadas en la tienda.

Atributos:
- Id
- FechaVenta
- Cantidad

## Relaciones

Producto pertenece a una categoría.

Una venta registra un producto vendido.
