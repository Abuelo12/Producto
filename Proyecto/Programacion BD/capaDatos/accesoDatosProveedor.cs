﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using System.Data.SqlClient;
using System.Data;

namespace capaDatos
{
    public class accesoDatosProveedor
    {
        SqlConnection cnx; //conexion
        proveedor prov = new proveedor(); //capa de entidad
        Conexion cn = new Conexion();//para la cobexion
        SqlCommand cm = null; //para los comando sql
        int indicador = 0; //variablae k indica si el metodo se ejecuto
        SqlDataReader dr = null;
        List<proveedor> listaProv = null;

        public int insertarProveedor(proveedor pv)
        {
            try
            {
                SqlConnection cnx = cn.conectar(); //conexion

                cm = new SqlCommand("nuevoProveedor", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@idcodigoP", "");
                cm.Parameters.AddWithValue("@nombre", pv.nombre);
                cm.Parameters.AddWithValue("@direccion", pv.direccion);
                cm.Parameters.AddWithValue("@telefono", pv.telefono);

                cm.CommandType = CommandType.StoredProcedure; //PARA EL PROCEDIMIENTO ALMACENADO
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

        public List<proveedor> ListarProveedores()
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("nuevoProveedor", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@idCodigoP", "");
                cm.Parameters.AddWithValue("@nombre", "");
                cm.Parameters.AddWithValue("@direccion", "");
                cm.Parameters.AddWithValue("@telefono", "");
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaProv = new List<proveedor>();
                while (dr.Read())
                {
                    proveedor p = new proveedor();
                    p.idcodigoP = Convert.ToInt32(dr["idcodigoP"].ToString());
                    p.nombre = dr["nombre"].ToString();
                    p.direccion = dr["direccion"].ToString();
                    p.telefono = dr["telefono"].ToString();
                    listaProv.Add(p);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaProv = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaProv;
        }


        public int EliminarProveedor(int id_proveedor)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("nuevoProveedor", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@idcodigoP", id_proveedor);
                cm.Parameters.AddWithValue("@nombre", "");
                cm.Parameters.AddWithValue("@direccion", "");
                cm.Parameters.AddWithValue("@telefono", "");

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

        public int EditarProveedor(proveedor pv)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("nuevoProveedor", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@idcodigoP", pv.idcodigoP);
                cm.Parameters.AddWithValue("@nombre", pv.nombre);
                cm.Parameters.AddWithValue("@direccion", pv.direccion);
                cm.Parameters.AddWithValue("@telefono", pv.telefono);

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

        public List<proveedor> BuscaProveedorDatos(String dato)
        {

            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("nuevoProveedor", cnx);
                cm.Parameters.AddWithValue("@b", 6);
                cm.Parameters.AddWithValue("@idcodigoP", "");
                cm.Parameters.AddWithValue("@nombre", dato);
                cm.Parameters.AddWithValue("@direccion", dato);
                cm.Parameters.AddWithValue("@telefono", "");
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaProv = new List<proveedor>();
                while (dr.Read())
                {
                    proveedor p = new proveedor();
                    p.idcodigoP = Convert.ToInt32(dr["idcodigoP"].ToString());
                    p.nombre = dr["nombre"].ToString();
                    p.direccion = dr["direccion"].ToString();
                    p.telefono = dr["telefono"].ToString();
                    listaProv.Add(p);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaProv = null;
            }
            finally { cm.Connection.Close(); }
            return listaProv;
        }

        public proveedor BuscarProveedorXcodigo(int idpro)
        {
            proveedor p = new proveedor();
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("nuevoProveedor", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@idcodigoP", idpro);
                cm.Parameters.AddWithValue("@nombre", "");
                cm.Parameters.AddWithValue("@direccion", "");
                cm.Parameters.AddWithValue("@telefono", "");
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                dr.Read();

                p.idcodigoP = Convert.ToInt32(dr["idcodigoP"].ToString());
                p.nombre = dr["nombre"].ToString();
                p.direccion = dr["direccion"].ToString();
                p.telefono = dr["telefono"].ToString();

            }
            catch (Exception e)
            {
                e.Message.ToString();
                p = null;
            }
            finally
            {
                cm.Connection.Close();

            }
            return p;
        }
    }
}
