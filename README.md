# 🌳 Árbol Binario Visual en C# (Windows Forms)

Este proyecto permite crear y visualizar un árbol binario de manera interactiva con una interfaz gráfica. Fue desarrollado en **C# con Windows Forms**, ideal para aprender sobre estructuras de datos y programación de interfaces gráficas.

---

## 🎯 Funcionalidades

- Crear un nodo raíz con nombre personalizado.
- Agregar nodos hijos (izquierda o derecha) al nodo seleccionado.
- Visualizar el árbol binario con un `TreeView`.
- Recorrer el árbol en:
  - PreOrden
  - InOrden
  - PostOrden
- Mostrar:
  - Altura del árbol
  - Ancho del árbol (cantidad de hojas)

---

## 🧠 Lógica del programa – Explicación de funciones

### `crearNodo()`
Muestra un `InputBox` para ingresar el nombre del nodo. Devuelve un objeto `Nodo` con ese nombre.
> Se requiere agregar la referencia a `Microsoft.VisualBasic`.

---

### `RecorridoPreOrden(Nodo n)`
Recorre el árbol en orden **PreOrden**:
1. Visita el nodo actual.
2. Recorre el hijo izquierdo.
3. Recorre el hijo derecho.

---

### `RecorridoPostOrden(Nodo n)`
Recorre el árbol en orden **PostOrden**:
1. Recorre el hijo izquierdo.
2. Recorre el hijo derecho.
3. Visita el nodo actual.

---

### `RecorridoInOrden(Nodo n)`
⚠️ Esta implementación tiene un detalle: **visita el nodo primero**. El orden tradicional sería:
1. Recorre el hijo izquierdo.
2. Visita el nodo.
3. Recorre el hijo derecho.

---

### `Visitar(Nodo n)`
Agrega el nombre del nodo visitado al `TextBox` `txtRecorrido`.

---

### `EvaluarArbol()`
Calcula y muestra:
- `Altura`: profundidad máxima del árbol.
- `Ancho`: cantidad de hojas (nodos sin hijos).

---

### `Alto(Nodo n)`
Devuelve la altura del árbol. Es recursiva:
- Si el nodo es nulo, devuelve 0.
- Si tiene hijos, devuelve el máximo entre altura izquierda y derecha + 1.

---

### `Ancho(Nodo n, ref int ancho)`
Cuenta cuántos nodos **no tienen hijos** (hojas). Es una función recursiva con un contador pasado por referencia.

---

### `button1_Click`
Crea el nodo raíz. Si ya existe, pregunta al usuario si desea eliminarlo y crear uno nuevo. Luego actualiza la vista (`TreeView`).

---

### `LlenarTreeView()`
Limpia y vuelve a cargar todo el `TreeView` a partir de la raíz actual. Luego muestra la altura y ancho actualizados.

---

### `MostrarNodo(Nodo n, TreeNode tnpadre, string lado)`
Agrega cada nodo al `TreeView`, indicando si es izquierdo ("I") o derecho ("D"). Si no tiene padre, lo considera raíz.

---

### `treeView1_AfterSelect(object sender, TreeViewEventArgs e)`
Evento que se dispara al seleccionar un nodo en el `TreeView`. Actualiza el nodo seleccionado.

---

### `CambiarSeleccion(Nodo n)`
Actualiza la variable `seleccionado` y muestra su nombre en pantalla.

---

### `button2_Click`
Agrega un hijo a la **derecha** del nodo actualmente seleccionado.

---

### `button3_Click`
Agrega un hijo a la **izquierda** del nodo actualmente seleccionado.

---

### `button4_Click`
Ejecuta recorrido **InOrden** desde la raíz y muestra el resultado.

---

### `button5_Click`
Ejecuta recorrido **PreOrden** desde la raíz y muestra el resultado.

---

### `button6_Click`
Ejecuta recorrido **PostOrden** desde la raíz y muestra el resultado.

---

## 🧱 Clase Nodo (modelo de datos)

```csharp
public class Nodo
{
    public string Nombre { get; set; }
    public Nodo Izquierda { get; set; }
    public Nodo Derecha { get; set; }

    public Nodo(string nombre)
    {
        Nombre = nombre;
        Izquierda = null;
        Derecha = null;
    }
}

