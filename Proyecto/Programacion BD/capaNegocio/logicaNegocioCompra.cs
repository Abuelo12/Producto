using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidades;

namespace capaNegocio
{
    public class logicaNegocioCompra
    {
        accesoDatosCompra aco = new accesoDatosCompra();
        public int insertarCompra(compra co)
        {
            return aco.insertarCompra(co);
        }
        public List<compra> ListarCompra()
        {
            return aco.ListarCompras();
        }
        public int EditarCompra(compra co)
        {
            return aco.EditarCompra(co);
        }
        public int EliminarCompra(int id_compra)
        {
            return aco.EliminarCompra(id_compra);
        }
        public compra BuscarCompraXcodigo(int idcom)
        {
            return aco.BuscarCompraXcodigo(idcom);
        }
        public List<compra> BuscaCompraDatos(String dato)
        {
            return aco.BuscaCompraDatos(dato);
        }
    }
}
