using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class aitecom {

		#region Campos
            private decimal _caiccanpro;
            private decimal _caicpreuni;
            private string _paiccodite;
            private string _faiccodpro;
            private string _faiccodcom;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public decimal caiccanpro
            { 
                get{ return this._caiccanpro;}
                set{ this._caiccanpro = value;}
            } 
		    public decimal caicpreuni
            { 
                get{ return this._caicpreuni;}
                set{ this._caicpreuni = value;}
            } 
		    public string paiccodite
            { 
                get{ return this._paiccodite;}
                set{ this._paiccodite = value;}
            } 
		    public string faiccodpro
            { 
                get{ return this._faiccodpro;}
                set{ this._faiccodpro = value;}
            } 
		    public string faiccodcom
            { 
                get{ return this._faiccodcom;}
                set{ this._faiccodcom = value;}
            } 
        #endregion

        #region Constructor
            public aitecom()
            { 
		        this._caiccanpro = 0;
		        this._caicpreuni = 0;
		        this._paiccodite = "";
		        this._faiccodpro = "";
		        this._faiccodcom = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
                this.Conexion.Conectar();
			    string sql = "select " +
                                     "caiccanpro," +
                                     "caicpreuni," +
                                     "paiccodite," +
                                     "faiccodpro," +
                                     "faiccodcom " + 
                             "from aitecom " +
                             "where "+
                                    "paiccodite = @paiccodite";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@paiccodite",this._paiccodite);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._caiccanpro=ResultadoConsulta.GetDecimal(0);
                    this._caicpreuni=ResultadoConsulta.GetDecimal(1);
                    this._paiccodite=ResultadoConsulta.GetString(2);
                    this._faiccodpro=ResultadoConsulta.GetString(3);
                    this._faiccodcom=ResultadoConsulta.GetString(4);
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
                                     "caiccanpro," +
                                     "caicpreuni," +
                                     "paiccodite," +
                                     "faiccodpro," +
                                     "faiccodcom " + 
                             "from aitecom " +
                             "where " +
                                    "paiccodite = @paiccodite";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@paiccodite",this._paiccodite);

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
			        string sql = "insert into aitecom (" +
                                                       "caiccanpro," +
                                                       "caicpreuni," +
                                                       "paiccodite," +
                                                       "faiccodpro," +
                                                       "faiccodcom" +
                                                       ") " +
	                             "values (" + 
                                          "@caiccanpro," +
                                          "@caicpreuni," +
                                          "@paiccodite," +
                                          "@faiccodpro," +
                                          "@faiccodcom" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroDecimal("@caiccanpro",this._caiccanpro);
                    this.Conexion.AsignarParametroDecimal("@caicpreuni",this._caicpreuni);
                    this.Conexion.AsignarParametroCadena("@paiccodite",this._paiccodite);
                    this.Conexion.AsignarParametroCadena("@faiccodpro",this._faiccodpro);
                    this.Conexion.AsignarParametroCadena("@faiccodcom",this._faiccodcom);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                } 
            }

            public bool Grabar(List<aitecom> Items)
            {
                xnumcor correlativo = new xnumcor();
                correlativo.pxnctipcor = "aitecom";
                if (correlativo.ObtenerSiguiente(Items.Count))
                {
                    this.paiccodite = correlativo.cxncnumcor.ToString();
                }
                this.Conexion.Conectar();
                string sql = "insert into aitecom (" +
                                                       "paiccodite," +                                                                                                              
                                                       "faiccodpro," +
                                                       "faiccodcom," +
                                                       "caiccanpro," +
                                                       "caicpreuni" +
                                                ") " +
                            "values ";
                bool primero = true;
                foreach (aitecom a in Items)
                {
                    if (!primero)
                    {
                        sql = this.Conexion.ObtenerComando() + ",";
                    }
                    else
                        primero = false;

                    sql += "(" +                                          
                                          "@paiccodite," +
                                          "@faiccodpro," +
                                          "@faiccodcom," +
                                          "@caiccanpro," +
                                          "@caicpreuni " +
                                                    ")";
                    this.Conexion.PrepararComando(sql);
                
                this.Conexion.AsignarParametroCadena("@paiccodite", this._paiccodite);
                this.Conexion.AsignarParametroCadena("@faiccodpro", a.faiccodpro);
                this.Conexion.AsignarParametroCadena("@faiccodcom", this._faiccodcom);
                this.Conexion.AsignarParametroDecimal("@caiccanpro", a.caiccanpro);
                this.Conexion.AsignarParametroDecimal("@caicpreuni", a.caicpreuni);
                this._paiccodite = (Convert.ToInt32(this._paiccodite) + 1).ToString();
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
			        string sql = "update aitecom set " +
                                                     "caiccanpro = @caiccanpro, " +
                                                     "caicpreuni = @caicpreuni, " +
                                                     "faiccodpro = @faiccodpro, " +
                                                     "faiccodcom = @faiccodcom" +
                                 " where " +
                                        "paiccodite = @paiccodite";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroDecimal("@caiccanpro",this._caiccanpro);
                    this.Conexion.AsignarParametroDecimal("@caicpreuni",this._caicpreuni);
                    this.Conexion.AsignarParametroCadena("@paiccodite",this._paiccodite);
                    this.Conexion.AsignarParametroCadena("@faiccodpro",this._faiccodpro);
                    this.Conexion.AsignarParametroCadena("@faiccodcom",this._faiccodcom);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<aitecom> Lista(string where)
            { 
                List<aitecom> ListaResultado = new List<aitecom>();
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "caiccanpro," +
                                     "caicpreuni," +
                                     "paiccodite," +
                                     "faiccodpro," +
                                     "faiccodcom " + 
                             "from aitecom " ;
 
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
                          aitecom Auxiliar = new aitecom();
                          Auxiliar.caiccanpro = ResultadoConsulta.GetDecimal(0);
                          Auxiliar.caicpreuni = ResultadoConsulta.GetDecimal(1);
                          Auxiliar.paiccodite = ResultadoConsulta.GetString(2);
                          Auxiliar.faiccodpro = ResultadoConsulta.GetString(3);
                          Auxiliar.faiccodcom = ResultadoConsulta.GetString(4);
                          ListaResultado.Add(Auxiliar);
                    }

                }
                this.Conexion.Desconectar();
                return ListaResultado;
            } 
        #endregion 

	}
}

