# 🛒  ECommerce - Gestión de Ventas

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D4?style=for-the-badge&logo=windows&logoColor=white)

Aplicación de escritorio desarrollada en **.NET C# con Windows Forms** para la gestión de una tienda híbrida. El sistema administra un catálogo mixto (productos físicos y digitales), clientes y un registro histórico de ventas, asegurando el desacoplamiento de los datos a lo largo del tiempo mediante persistencia en archivos CSV.

## 🚀 Características Principales

El sistema está estructurado en tres módulos principales (CRUDs) que interactúan entre sí, respetando principios de Programación Orientada a Objetos:

### 1. Gestión de Productos (Catálogo)
Maneja dos tipos de productos aplicando herencia desde una clase base `Producto`:
*   **Productos Físicos:** Gestionan stock finito (que se descuenta en cada venta) y costos de envío.
*   **Productos Digitales:** Cuentan con un formato específico, URL de descarga y disponibilidad infinita (no aplican costos de envío ni control de stock).

### 2. Gestión de Clientes
Registro y control de compradores. Garantiza la unicidad de cada cliente mediante la validación de su documento de identidad al crear o actualizar registros.

### 3. Registro de Ventas (Desacoplado)
Implementa el patrón de detalle de venta (`SaleDetail`) para mantener la integridad histórica. 
*   Las ventas no guardan referencias directas a los productos del catálogo.
*   Al momento de la transacción, se copian los valores estáticos (descripción, precio en ese instante y cantidad).
*   Si un producto cambia de precio o es eliminado del catálogo en el futuro, el historial de la venta permanece inalterable.

## 💾 Persistencia de Datos

La aplicación no utiliza una base de datos tradicional. Toda la persistencia se realiza mediante archivos locales `.csv` gestionados con **CsvHelper**.

*   Al iniciar la aplicación, se cargan los datos desde los archivos a la memoria.
*   Cada creación, actualización o eliminación (CRUD) reescribe automáticamente los datos en su respectivo archivo.
*   **Archivos generados:** `productos.csv`, `clientes.csv`, `ventas.csv` y `detalles_venta.csv`.

## 🛠️ Tecnologías Utilizadas

*   **Lenguaje:** C#
*   **Framework:** .NET 
*   **Interfaz Gráfica:** Windows Forms (WinForms)
*   **Librerías de terceros:** [CsvHelper](https://joshclose.github.io/CsvHelper/) para la lectura y escritura de archivos CSV.

## ⚙️ Instalación y Uso

1. Clonar el repositorio:
   ```bash
   git clone git@github.com:tu-usuario/tu-repositorio.git
