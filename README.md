# 🌳 Árbol Binario Visual en C# (Windows Forms)

Este proyecto es una aplicación de escritorio desarrollada en **C# con Windows Forms** que permite construir, visualizar y recorrer un **árbol binario** de manera interactiva.

## 🎯 Funcionalidades principales

- Crear la raíz del árbol binario con nombre personalizado.
- Agregar nodos hijos a la **izquierda** o **derecha** del nodo seleccionado.
- Visualizar la estructura del árbol en un `TreeView`.
- Realizar recorridos:
  - PreOrden
  - InOrden
  - PostOrden
- Mostrar:
  - Altura del árbol (profundidad máxima)
  - Ancho del árbol (cantidad de hojas)

## 🖼️ Interfaz gráfica

- La interfaz contiene botones para:
  - Crear raíz
  - Agregar hijo izquierdo/derecho
  - Ejecutar recorridos
- Un `TreeView` visualiza la estructura jerárquica.
- Un `TextBox` muestra el resultado de los recorridos.

## 🛠️ Tecnologías utilizadas

- Lenguaje: **C#**
- Framework: **.NET Framework** (Windows Forms)
- Librerías adicionales:
  - `Microsoft.VisualBasic` (para mostrar un `InputBox` al ingresar nombres de nodos)

## 📦 Estructura del proyecto

```plaintext
- Form1.cs          // Lógica principal de la app
- Nodo.cs           // Clase Nodo (no incluida aquí)
- Form1.Designer.cs // Código generado automáticamente para el formulario
- Program.cs        // Punto de entrada
