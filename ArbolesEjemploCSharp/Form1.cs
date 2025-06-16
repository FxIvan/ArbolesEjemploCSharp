using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbolesEjemploCSharp
{
    /*
     Este programa en C# con Windows Forms permite construir y visualizar un árbol binario de manera interactiva,
     agregando nodos a la izquierda o derecha del nodo actualmente seleccionado. También muestra elárbol en un TreeView,
     permite recorrerlo en orden, preorden y postorden, y calcula su altura y ancho.
     */
    public partial class Form1 : Form
    {
        Nodo raiz;
        Nodo seleccionado;
        /*
         raiz: es el nodo raíz del árbol.
         seleccionado: nodo que el usuario selecciona en el TreeView, para agregar hijos
         */
        public Form1()
        {
            InitializeComponent();
        }
        // Devuelve Nodo nuevo con respecto el nombre
        Nodo crearNodo()
        {
            /*
             Pide al usuario un nombre por un InputBox y devuelve un nuevo nodo con ese nombre.
            */
            // Para usar interaction tenemos que usar la libreria using Microsoft.VisualBasic;
            // y agregarlo en Agregar > Referencia... > Agregar referencia > (ESM o Ensamblados)Tildamos el que dice Microsoft.VisualBasic
            string nombre = Interaction.InputBox("Ingrese nombre del nodo");
            return new Nodo(nombre);
        }

        void RecorridoPreOrden(Nodo n)
        {
            /*
             PreOrden: primero visita el nodo, luego el izquierdo, luego el derecho.
             */
            if (n == null) return;

            Visitar(n);
            RecorridoPreOrden(n.Izquierda);
            RecorridoPreOrden(n.Derecha);
        }

        void RecorridoPostOrden(Nodo n)
        {
            // PostOrden: primero izquierdo, luego derecho, y al final el nodo actual.
            if (n == null) return;

            RecorridoPostOrden(n.Izquierda);
            RecorridoPostOrden(n.Derecha);
            Visitar(n);
        }

        void EvaluarArbol()
        {
            // Calcula la altura y ancho del árbol y los muestra en etiquetas (lblAltura, lblAncho).
            this.lblAltura.Text = $"Altura:{Alto(raiz)}";
            int inicio = 0;
            this.lblAncho.Text = $"Ancho:{Ancho(raiz,ref inicio)}";
        }



        int Ancho(Nodo n, ref int ancho)
        {
            // Cuenta el número de hojas (nodos sin hijos).
            if (n.Derecha == null && n.Izquierda == null)
                ancho += 1;

            if (n.Derecha != null)  Ancho(n.Derecha, ref ancho);
            if (n.Izquierda != null)  Ancho(n.Izquierda, ref ancho);

            return ancho;
        }
        int Alto(Nodo n)
        {
            // Calcula recursivamente la profundidad del árbol (número de niveles).
            if (n == null) return 0;

            int izq = Alto(n.Izquierda) + 1;
            int der = Alto(n.Derecha) + 1;
            return Math.Max(izq, der);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*
             Si ya hay una raíz, pregunta si deseas reemplazarla.
             Luego crea la raíz, actualiza selección y repinta el TreeView.
             */
            // Evaluamos si la raiz ya existe
            if (raiz != null)
            {
                DialogResult r = MessageBox.Show("Se eliminará el árbol, desea continuar?", "Consulta", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    raiz = crearNodo();
                    
                }
            }
            else
            {
                raiz = crearNodo();
            }

            // Recibe un parametro del nodo que quiero seleccionar y muestra el nodo seleccionado
            CambiarSeleccion(raiz);
            // Lleno el treView que nos permite ver la estructura
            LlenarTreeView();
        }


        public void LlenarTreeView()
        {
            /*
             Limpia y reconstruye el TreeView visual.
             */
            treeView1.Nodes.Clear();
            MostrarNodo(raiz, null, string.Empty);
            treeView1.ExpandAll(); //para mostrar el treeviee desplegado
            EvaluarArbol();
        }

        public void MostrarNodo(Nodo n, TreeNode tnpadre, string lado)
        {
            /*
             Construye cada nodo visualmente:
                - Si es raíz → se agrega directo.
                - Si no, se marca como hijo izquierdo ("I") o derecho ("D").
                - Se usa Tag para guardar una referencia al objeto Nodo.
             */
            if (n == null) return;
            TreeNode nuevo = new TreeNode();
            if (tnpadre == null && lado==String.Empty)
            {
                //si entra en este  if, es porque Nodo es el raiz
                tnpadre = new TreeNode();
                nuevo.Text = n.Nombre;
                nuevo.Tag = n;
                treeView1.Nodes.Add(nuevo);
            }
            else
            {
               
                nuevo.Text = $"{lado} - {n.Nombre}";
                nuevo.Tag = n;
                
                tnpadre.Nodes.Add(nuevo);
            }

            if (n.Derecha != null) MostrarNodo(n.Derecha, nuevo, "D");
            if (n.Izquierda != null) MostrarNodo(n.Izquierda, nuevo, "I");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CambiarSeleccion((Nodo)e.Node.Tag);
        }


        void CambiarSeleccion(Nodo n)
        {
            // Cuando seleccionas un nodo visual, se guarda como seleccionado.
            seleccionado = n;
            this.lblNombreNodo.Text = n.Nombre;
        }

        /*
         button2_Click → agrega un hijo derecho al nodo seleccionado.
         button3_Click → agrega un hijo izquierdo al nodo seleccionado.
         */
        private void button2_Click(object sender, EventArgs e)
        {
            if (seleccionado != null)
            {
                seleccionado.Derecha = crearNodo();
                LlenarTreeView();
            }
            else
                MessageBox.Show("Debe tener algun nodo seleccionado");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (seleccionado != null)
            {
                seleccionado.Izquierda = crearNodo();
                LlenarTreeView();
            }
            else
                MessageBox.Show("Debe tener algun nodo seleccionado");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.txtRecorrido.Text = string.Empty;
            RecorridoInOrden(raiz);
        }

        void RecorridoInOrden(Nodo n)
        {
            Visitar(n);
            if (n.Izquierda!=null)  RecorridoInOrden(n.Izquierda);
            if (n.Derecha != null) RecorridoInOrden(n.Derecha);
        }

        void Visitar(Nodo n)
        {
            // Agrega el nombre del nodo al TextBox txtRecorrido.
            this.txtRecorrido.Text += "-"  + n.Nombre;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.txtRecorrido.Text = string.Empty;
            RecorridoPreOrden(raiz);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.txtRecorrido.Text = string.Empty;
            RecorridoPostOrden(raiz);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
