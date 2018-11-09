using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidades;
using capaNegocio;

namespace formProveedorProductos
{
    public partial class Form1 : Form
    {
        logicoNegocioProveedor lN = new logicoNegocioProveedor();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            logicoNegocioProveedor lN = new logicoNegocioProveedor();

            try
            {
                proveedor objProveedor = new proveedor();
                objProveedor.nombre = txtNombres.Text;
                objProveedor.direccion = txtDireccion.Text;
                objProveedor.telefono = txtTelefono.Text;

                if (lN.insertarProveedor(objProveedor) > 0)
                {
                    MessageBox.Show("Agregado con éxito!");
                    txtDireccion.Text = "";
                    txtNombres.Text = "";
                    txtTelefono.Text = "";
                    
                }

                else { MessageBox.Show("Error al agregar proveedor"); }
            }
            catch
            {
                MessageBox.Show("Errorrrrrrr");
            }
        }
    }
}
