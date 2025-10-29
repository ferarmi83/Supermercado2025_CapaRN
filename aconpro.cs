using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;
using System.Runtime;

namespace CapaRN
{
	public class aconpro {

		#region Campos
            private string _pacpcodcon;
            private string _facpcoddor;
            private string _facpcodper;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public string pacpcodcon
            { 
                get{ return this._pacpcodcon;}
                set{ this._pacpcodcon = value;}
            } 
		    public string facpcoddor
            { 
                get{ return this._facpcoddor;}
                set{ this._facpcoddor = value;}
            } 
		    public string facpcodper
            { 
                get{ return this._facpcodper;}
                set{ this._facpcodper = value;}
            } 
        #endregion

        #region Constructor
            public aconpro()
            { 
		        this._pacpcodcon = "";
		        this._facpcoddor = "";
		        this._facpcodper = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
                this.Conexion.Conectar();
			    string sql = "select " +
                                     "pacpcodcon," +
                                     "facpcoddor," +
                                     "facpcodper " + 
                             "from aconpro " +
                             "where "+
                                    "pacpcodcon = @pacpcodcon";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@pacpcodcon",this._pacpcodcon);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._pacpcodcon=ResultadoConsulta.GetString(0);
                    this._facpcoddor=ResultadoConsulta.GetString(1);
                    this._facpcodper=ResultadoConsulta.GetString(2);
                    this.Conexion.Desconectar();

                    return true;
                }
                else
                {
                    this.Conexion.Desconectar();
                    return false;
                }
            }
            public bool VerificarExistencia()
            { 
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "pacpcodcon," +
                                     "facpcoddor," +
                                     "facpcodper " + 
                             "from aconpro " +
                             "where " +
                                    "pacpcodcon = @pacpcodcon";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@pacpcodcon",this._pacpcodcon);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.HasRows)
                {
                this.Conexion.Desconectar();

                    return true;
                }
                else 
                { 

                this.Conexion.Desconectar();
                    return false;
                } 
            } 
            public bool Grabar()
            { 
                if (this.VerificarExistencia())
                {
                    return false;
                }
                else 
                { 
                    this.Conexion.Conectar();
			        string sql = "insert into aconpro (" +
                                                       "pacpcodcon," +
                                                       "facpcoddor," +
                                                       "facpcodper" +
                                                       ") " +
	                             "values (" + 
                                          "@pacpcodcon," +
                                          "@facpcoddor," +
                                          "@facpcodper" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroCadena("@pacpcodcon",this._pacpcodcon);
                    this.Conexion.AsignarParametroCadena("@facpcoddor",this._facpcoddor);
                    this.Conexion.AsignarParametroCadena("@facpcodper",this._facpcodper);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                } 
            }

            public bool Grabar(List<aperson> Contactos)
            {
                xnumcor correlativo = new xnumcor();
                correlativo.pxnctipcor = "aconpro";
                if (correlativo.ObtenerSiguiente(Contactos.Count))
                {
                    this.pacpcodcon = correlativo.cxncnumcor.ToString();
                }
                this.Conexion.Conectar();
                string sql = "insert into aconpro (" +
                                                "pacpcodcon," +
                                                "facpcoddor," +
                                                "facpcodper" +
                                                ") " +
                            "values ";
                bool primero = true;
                foreach (aperson a in Contactos)
                {
                if (!primero)
                {
                    sql = this.Conexion.ObtenerComando()+",";
                }
                else
                    primero = false;

                    sql += "(" +
                                        "@pacpcodcon," +
                                        "@facpcoddor," +
                                        "@facpcodper" +
                                                    ")";
                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroCadena("@pacpcodcon", this._pacpcodcon);
                    this.Conexion.AsignarParametroCadena("@facpcoddor", this._facpcoddor);
                    this.Conexion.AsignarParametroCadena("@facpcodper", a.papscodper);
                    this._pacpcodcon= (Convert.ToInt32(this._pacpcodcon)+1).ToString();
                }
                sql = this.Conexion.ObtenerComando();
                sql = sql.Substring(0, sql.Length - 1);
                sql += ";";
                this.Conexion.EjecutarTransaccion();
                this.Conexion.Desconectar();

                return true;                
            }
        public bool Modificar()
            { 
                if (!this.VerificarExistencia())
                {
                    return false;
                }
                else 
                { 
                    this.Conexion.Conectar();
			        string sql = "update aconpro set " +
                                                     "facpcoddor = @facpcoddor, " +
                                                     "facpcodper = @facpcodper" +
                                 " where " +
                                        "pacpcodcon = @pacpcodcon";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroCadena("@pacpcodcon",this._pacpcodcon);
                    this.Conexion.AsignarParametroCadena("@facpcoddor",this._facpcoddor);
                    this.Conexion.AsignarParametroCadena("@facpcodper",this._facpcodper);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<aconpro> Lista(string where)
            { 
                List<aconpro> ListaResultado = new List<aconpro>();
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "pacpcodcon," +
                                     "facpcoddor," +
                                     "facpcodper " + 
                             "from aconpro " ;
 
                if (where.Replace(" ", "") != "")
                {
                    sql+= "where " + where;
                }

 
                this.Conexion.PrepararComando(sql); 
                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta!=null)
                {
                    while (ResultadoConsulta.Read())
                    {
                          aconpro Auxiliar = new aconpro();
                          Auxiliar.pacpcodcon = ResultadoConsulta.GetString(0);
                          Auxiliar.facpcoddor = ResultadoConsulta.GetString(1);
                          Auxiliar.facpcodper = ResultadoConsulta.GetString(2);
                          ListaResultado.Add(Auxiliar);
                    }

                }
                this.Conexion.Desconectar();
                return ListaResultado;
            } 
        #endregion 

	}
}

