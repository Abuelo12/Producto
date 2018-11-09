using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidades;

namespace capaNegocio
{
    public class logicoNegocioProveedor
    {
        accesoDatosProveedor ap = new accesoDatosProveedor();
        public int insertarProveedor(proveedor pv)
        {
            return ap.insertarProveedor(pv);
        }
        public List<proveedor> ListarProveedores()
        {
            return ap.ListarProveedores();
        }
        public int EditarProveedores(proveedor pv)
        {
            return ap.EditarProveedor(pv);
        }
        public int EliminarProveedor(int id_proveedor)
        {
            return ap.EliminarProveedor(id_proveedor);
        }
        public proveedor BuscarProveedorXcodigo(int idpro)
        {
            return ap.BuscarProveedorXcodigo(idpro);
        }
        public List<proveedor> BuscaProveedorDatos(String dato)
        {
            return ap.BuscaProveedorDatos(dato);
        }
    }
}
