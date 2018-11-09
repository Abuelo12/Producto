using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using System.Data.SqlClient;
using System.Data;

namespace capaDatos
{
    public class accesoDatosProd_prov
    {
        SqlConnection cnx;
        Prod_prov cl = new Prod_prov();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Prod_prov> listaProd_prove = null;

        public int insertarProd_prove(Prod_prov pp)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("nuevoProd_prove", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@id_pp", "");
                cm.Parameters.AddWithValue("@precio", pp.precio);
                cm.Parameters.AddWithValue("@cantidad", pp.cantidad);
                cm.Parameters.AddWithValue("@id_producto", pp.id_producto);
                cm.Parameters.AddWithValue("@idcodigoP", pp.idcodigoP);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally { cm.Connection.Close(); }
            return indicador;
        }

        public List<Prod_prov> ListarProducto_proveedor()
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("nuevoProducto_proveedor", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@id_pp", "");
                cm.Parameters.AddWithValue("@precio", "");
                cm.Parameters.AddWithValue("@cantidad", "");
                cm.Parameters.AddWithValue("@id_producto", "");
                cm.Parameters.AddWithValue("@idcodigoP", "");
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaProd_prove = new List<Prod_prov>();
                while (dr.Read())
                {
                    Prod_prov pp = new Prod_prov();
                    pp.id_pp = Convert.ToInt32(dr["id_pp"].ToString());
                    pp.precio = int.Parse(dr["precio"].ToString());
                    pp.cantidad = int.Parse(dr["cantidad"].ToString());
                    pp.id_producto = Convert.ToInt32(dr["id_producto"].ToString());
                    pp.idcodigoP = Convert.ToInt32(dr["idcodigoP"].ToString());
                    listaProd_prove.Add(pp);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaProd_prove = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaProd_prove;
        }


        public int EliminarProd_prove(int id_pp)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("nuevoProducto_proveedor", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@id_pp", id_pp);
                cm.Parameters.AddWithValue("@precio", "");
                cm.Parameters.AddWithValue("@dcantidad", "");
                cm.Parameters.AddWithValue("@id_producto", "");
                cm.Parameters.AddWithValue("@idcodigoP", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            { cm.Connection.Close(); }
            return indicador;
        }

        public int EditarProd_prove(Prod_prov p_p)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("nuevoProd_prove", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@id_pp", p_p.id_pp);
                cm.Parameters.AddWithValue("@precio", p_p.precio);
                cm.Parameters.AddWithValue("@cantidad", p_p.cantidad);
                cm.Parameters.AddWithValue("@id_producto", p_p.id_producto);
                cm.Parameters.AddWithValue("@idcodigoP", p_p.idcodigoP);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally { cm.Connection.Close(); }
            return indicador;
        }

        public List<Prod_prov> BuscaProd_proveDatos(String dato)
        {

            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("nuevoProd_prove", cnx);
                cm.Parameters.AddWithValue("@b", 6);
                cm.Parameters.AddWithValue("@id_pp", "");
                cm.Parameters.AddWithValue("@precio", dato);
                cm.Parameters.AddWithValue("@cantidad", dato);
                cm.Parameters.AddWithValue("@id_producto", "");
                cm.Parameters.AddWithValue("@idcodigoP", "");
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaProd_prove = new List<Prod_prov>();
                while (dr.Read())
                {
                    Prod_prov pp = new Prod_prov();
                    pp.id_pp = Convert.ToInt32(dr["id_pp"].ToString());
                    pp.precio = int.Parse(dr["precio"].ToString());
                    pp.cantidad = int.Parse(dr["cantidad"].ToString());
                    pp.id_producto = Convert.ToInt32(dr["id_producto"].ToString());
                    pp.idcodigoP = Convert.ToInt32(dr["idcodigoP"].ToString());
                    listaProd_prove.Add(pp);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaProd_prove = null;
            }
            finally { cm.Connection.Close(); }
            return listaProd_prove;
        }

        public Prod_prov BuscarProd_proveXcodigo(int idpp)
        {
            Prod_prov pp = new Prod_prov();
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("nuevoProd_prove", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@id_pp", idpp);
                cm.Parameters.AddWithValue("@precio", "");
                cm.Parameters.AddWithValue("@cantidad", "");
                cm.Parameters.AddWithValue("@id_producto", "");
                cm.Parameters.AddWithValue("@idcodigoP", "");
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                dr.Read();

                pp.id_pp = Convert.ToInt32(dr["id_pp"].ToString());
                pp.precio = int.Parse(dr["precio"].ToString());
                pp.cantidad = int.Parse(dr["cantidad"].ToString());
                pp.id_producto = Convert.ToInt32(dr["id_producto"].ToString());
                pp.idcodigoP = Convert.ToInt32(dr["idcodigoP"].ToString());

            }
            catch (Exception e)
            {
                e.Message.ToString();
                pp = null;
            }
            finally
            {
                cm.Connection.Close();

            }
            return pp;
        }
    }
}
