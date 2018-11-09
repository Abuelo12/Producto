using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidades;

namespace capaNegocio
{
    public class logicaNegocioProd_prov
    {
        accesoDatosProd_prov app = new accesoDatosProd_prov();
        public int insertarProd_prove(Prod_prov pp)
        {
            return app.insertarProd_prove(pp);
        }

        public List<Prod_prov> ListarProd_prove()
        {
            return app.ListarProducto_proveedor();
        }
        public int EditarProd_prove(Prod_prov p_p)
        {
            return app.EditarProd_prove(p_p);
        }
        public int EliminarProd_prove(int id_pp)
        {
            return app.EliminarProd_prove(id_pp);
        }
        public Prod_prov BuscarProd_proveXcodigo(int idpp)
        {
            return app.BuscarProd_proveXcodigo(idpp);
        }
        public List<Prod_prov> BuscaProd_proveDatos(String dato)
        {
            return app.BuscaProd_proveDatos(dato);
        }
    }
}
