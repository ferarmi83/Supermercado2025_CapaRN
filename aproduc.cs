using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class aproduc {

		#region Campos
            private bool _capdestado;
            private decimal _capdcansto;
            private decimal _capdconpro;
            private string _capdenvpro;
            private string _capdfotogr;
            private string _capdmarpro;
            private string _capdnompro;
            private string _capdtippro;
            private string _papdcodpro;
            private string _capdunimed;
            private string _capdcodbar;
            private string _capddescor;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public bool capdestado
            { 
                get{ return this._capdestado;}
                set{ this._capdestado = value;}
            } 
		    public decimal capdcansto
            { 
                get{ return this._capdcansto;}
                set{ this._capdcansto = value;}
            } 
		    public decimal capdconpro
            { 
                get{ return this._capdconpro;}
                set{ this._capdconpro = value;}
            } 
		    public string capdenvpro
            { 
                get{ return this._capdenvpro;}
                set{ this._capdenvpro = value;}
            } 
		    public string capdfotogr
            { 
                get{ return this._capdfotogr;}
                set{ this._capdfotogr = value;}
            } 
		    public string capdmarpro
            { 
                get{ return this._capdmarpro;}
                set{ this._capdmarpro = value;}
            } 
		    public string capdnompro
            { 
                get{ return this._capdnompro;}
                set{ this._capdnompro = value;}
            } 
		    public string capdtippro
            { 
                get{ return this._capdtippro;}
                set{ this._capdtippro = value;}
            } 
		    public string papdcodpro
            { 
                get{ return this._papdcodpro;}
                set{ this._papdcodpro = value;}
            } 
		    public string capdunimed
            { 
                get{ return this._capdunimed;}
                set{ this._capdunimed = value;}
            } 
		    public string capdcodbar
            { 
                get{ return this._capdcodbar;}
                set{ this._capdcodbar = value;}
            } 
		    public string capddescor
            { 
                get{ return this._capddescor;}
                set{ this._capddescor = value;}
            } 
        #endregion

        #region Constructor
            public aproduc()
            { 
		        this._capdestado = true;
		        this._capdcansto = 0;
		        this._capdconpro = 0;
		        this._capdenvpro = "";
		        this._capdfotogr = "";
		        this._capdmarpro = "";
		        this._capdnompro = "";
		        this._capdtippro = "";
		        this._papdcodpro = "";
		        this._capdunimed = "";
		        this._capdcodbar = "";
		        this._capddescor = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
                this.Conexion.Conectar();
			    string sql = "select " +
                                     "capdestado," +
                                     "capdcansto," +
                                     "capdconpro," +
                                     "capdenvpro," +
                                     "capdfotogr," +
                                     "capdmarpro," +
                                     "capdnompro," +
                                     "capdtippro," +
                                     "papdcodpro," +
                                     "capdunimed," +
                                     "capdcodbar," +
                                     "capddescor " + 
                             "from aproduc " +
                             "where "+
                                    "papdcodpro = @papdcodpro";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@papdcodpro",this._papdcodpro);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._capdestado=ResultadoConsulta.GetBoolean(0);
                    this._capdcansto=ResultadoConsulta.GetDecimal(1);
                    this._capdconpro=ResultadoConsulta.GetDecimal(2);
                    this._capdenvpro=ResultadoConsulta.GetString(3);
                    this._capdfotogr=ResultadoConsulta.GetString(4);
                    this._capdmarpro=ResultadoConsulta.GetString(5);
                    this._capdnompro=ResultadoConsulta.GetString(6);
                    this._capdtippro=ResultadoConsulta.GetString(7);
                    this._papdcodpro=ResultadoConsulta.GetString(8);
                    this._capdunimed=ResultadoConsulta.GetString(9);
                    this._capdcodbar=ResultadoConsulta.GetString(10);
                    this._capddescor=ResultadoConsulta.GetString(11);
                    this.Conexion.Desconectar();

                    return true;
                }
                else
                {
                    this.Conexion.Desconectar();
                    return false;
                }
            }

        public bool ObtenerDatosPorCB()
        {
            this.Conexion.Conectar();
            string sql = "select " +
                                 "capdestado," +
                                 "capdcansto," +
                                 "capdconpro," +
                                 "capdenvpro," +
                                 "capdfotogr," +
                                 "capdmarpro," +
                                 "capdnompro," +
                                 "capdtippro," +
                                 "papdcodpro," +
                                 "capdunimed," +
                                 "capdcodbar," +
                                 "capddescor " +
                         "from aproduc " +
                         "where " +
                                "capdcodbar = @capdcodbar";

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@capdcodbar", this._capdcodbar);

            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta.Read())
            {
                this._capdestado = ResultadoConsulta.GetBoolean(0);
                this._capdcansto = ResultadoConsulta.GetDecimal(1);
                this._capdconpro = ResultadoConsulta.GetDecimal(2);
                this._capdenvpro = ResultadoConsulta.GetString(3);
                this._capdfotogr = ResultadoConsulta.GetString(4);
                this._capdmarpro = ResultadoConsulta.GetString(5);
                this._capdnompro = ResultadoConsulta.GetString(6);
                this._capdtippro = ResultadoConsulta.GetString(7);
                this._papdcodpro = ResultadoConsulta.GetString(8);
                this._capdunimed = ResultadoConsulta.GetString(9);
                this._capdcodbar = ResultadoConsulta.GetString(10);
                this._capddescor = ResultadoConsulta.GetString(11);
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
                                     "capdestado," +
                                     "capdcansto," +
                                     "capdconpro," +
                                     "capdenvpro," +
                                     "capdfotogr," +
                                     "capdmarpro," +
                                     "capdnompro," +
                                     "capdtippro," +
                                     "papdcodpro," +
                                     "capdunimed," +
                                     "capdcodbar," +
                                     "capddescor " + 
                             "from aproduc " +
                             "where " +
                                    "papdcodpro = @papdcodpro";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@papdcodpro",this._papdcodpro);

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
			        string sql = "insert into aproduc (" +
                                                       "capdestado," +
                                                       "capdcansto," +
                                                       "capdconpro," +
                                                       "capdenvpro," +
                                                       "capdfotogr," +
                                                       "capdmarpro," +
                                                       "capdnompro," +
                                                       "capdtippro," +
                                                       "papdcodpro," +
                                                       "capdunimed," +
                                                       "capdcodbar," +
                                                       "capddescor" +
                                                       ") " +
	                             "values (" + 
                                          "@capdestado," +
                                          "@capdcansto," +
                                          "@capdconpro," +
                                          "@capdenvpro," +
                                          "@capdfotogr," +
                                          "@capdmarpro," +
                                          "@capdnompro," +
                                          "@capdtippro," +
                                          "@papdcodpro," +
                                          "@capdunimed," +
                                          "@capdcodbar," +
                                          "@capddescor" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroLogico("@capdestado",this._capdestado);
                    this.Conexion.AsignarParametroDecimal("@capdcansto",this._capdcansto);
                    this.Conexion.AsignarParametroDecimal("@capdconpro",this._capdconpro);
                    this.Conexion.AsignarParametroCadena("@capdenvpro",this._capdenvpro);
                    this.Conexion.AsignarParametroCadena("@capdfotogr",this._capdfotogr);
                    this.Conexion.AsignarParametroCadena("@capdmarpro",this._capdmarpro);
                    this.Conexion.AsignarParametroCadena("@capdnompro",this._capdnompro);
                    this.Conexion.AsignarParametroCadena("@capdtippro",this._capdtippro);
                    this.Conexion.AsignarParametroCadena("@papdcodpro",this._papdcodpro);
                    this.Conexion.AsignarParametroCadena("@capdunimed",this._capdunimed);
                    this.Conexion.AsignarParametroCadena("@capdcodbar",this._capdcodbar);
                    this.Conexion.AsignarParametroCadena("@capddescor",this._capddescor);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                } 
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
			        string sql = "update aproduc set " +
                                                     "capdestado = @capdestado, " +
                                                     "capdcansto = @capdcansto, " +
                                                     "capdconpro = @capdconpro, " +
                                                     "capdenvpro = @capdenvpro, " +
                                                     "capdfotogr = @capdfotogr, " +
                                                     "capdmarpro = @capdmarpro, " +
                                                     "capdnompro = @capdnompro, " +
                                                     "capdtippro = @capdtippro, " +
                                                     "capdunimed = @capdunimed, " +
                                                     "capdcodbar = @capdcodbar, " +
                                                     "capddescor = @capddescor" +
                                 " where " +
                                        "papdcodpro = @papdcodpro";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroLogico("@capdestado",this._capdestado);
                    this.Conexion.AsignarParametroDecimal("@capdcansto",this._capdcansto);
                    this.Conexion.AsignarParametroDecimal("@capdconpro",this._capdconpro);
                    this.Conexion.AsignarParametroCadena("@capdenvpro",this._capdenvpro);
                    this.Conexion.AsignarParametroCadena("@capdfotogr",this._capdfotogr);
                    this.Conexion.AsignarParametroCadena("@capdmarpro",this._capdmarpro);
                    this.Conexion.AsignarParametroCadena("@capdnompro",this._capdnompro);
                    this.Conexion.AsignarParametroCadena("@capdtippro",this._capdtippro);
                    this.Conexion.AsignarParametroCadena("@papdcodpro",this._papdcodpro);
                    this.Conexion.AsignarParametroCadena("@capdunimed",this._capdunimed);
                    this.Conexion.AsignarParametroCadena("@capdcodbar",this._capdcodbar);
                    this.Conexion.AsignarParametroCadena("@capddescor",this._capddescor);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<aproduc> Lista(string where)
            { 
                List<aproduc> ListaResultado = new List<aproduc>();
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "capdestado," +
                                     "capdcansto," +
                                     "capdconpro," +
                                     "capdenvpro," +
                                     "capdfotogr," +
                                     "capdmarpro," +
                                     "capdnompro," +
                                     "capdtippro," +
                                     "papdcodpro," +
                                     "capdunimed," +
                                     "capdcodbar," +
                                     "capddescor " + 
                             "from aproduc " ;
 
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
                          aproduc Auxiliar = new aproduc();
                          Auxiliar.capdestado = ResultadoConsulta.GetBoolean(0);
                          Auxiliar.capdcansto = ResultadoConsulta.GetDecimal(1);
                          Auxiliar.capdconpro = ResultadoConsulta.GetDecimal(2);
                          Auxiliar.capdenvpro = ResultadoConsulta.GetString(3);
                          Auxiliar.capdfotogr = ResultadoConsulta.GetString(4);
                          Auxiliar.capdmarpro = ResultadoConsulta.GetString(5);
                          Auxiliar.capdnompro = ResultadoConsulta.GetString(6);
                          Auxiliar.capdtippro = ResultadoConsulta.GetString(7);
                          Auxiliar.papdcodpro = ResultadoConsulta.GetString(8);
                          Auxiliar.capdunimed = ResultadoConsulta.GetString(9);
                          Auxiliar.capdcodbar = ResultadoConsulta.GetString(10);
                          Auxiliar.capddescor = ResultadoConsulta.GetString(11);
                          ListaResultado.Add(Auxiliar);
                    }

                }
                this.Conexion.Desconectar();
                return ListaResultado;
            }

            public List<String> CargarComboNombre() {
                List<String> Resultado = new List<string>();
                this.Conexion.Conectar();
                String sql = "select distinct capdnompro from aproduc order by capdnompro;";
                this.Conexion.PrepararComando(sql);
                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();
                if (ResultadoConsulta != null)
                {
                    while (ResultadoConsulta.Read())
                    {
                        String Auxiliar = "";
                        Auxiliar = ResultadoConsulta.GetString(0);                    
                        Resultado.Add(Auxiliar);
                    }
                }
                this.Conexion.Desconectar();
                return Resultado;
            }

        public List<String> CargarComboMarca(String nombreProducto)
        {
            List<String> Resultado = new List<string>();
            this.Conexion.Conectar();
            String sql = "select distinct capdmarpro from aproduc  where capdnompro='" 
                         + nombreProducto + "' order by capdmarpro;";
            this.Conexion.PrepararComando(sql);
            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();
            if (ResultadoConsulta != null)
            {
                while (ResultadoConsulta.Read())
                {
                    String Auxiliar = "";
                    Auxiliar = ResultadoConsulta.GetString(0);
                    Resultado.Add(Auxiliar);
                }
            }
            this.Conexion.Desconectar();
            return Resultado;
        }
        #endregion

    }
}

