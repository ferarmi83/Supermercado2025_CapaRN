using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class aprovee {

		#region Campos
            private bool _capvestdor;
            private string _capvnomdor;
            private string _capvdirdor;
            private string _papvcoddor;
            private string _capvnitdor;
            private string _capvmerdor;
            private string _capvteldor;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public bool capvestdor
            { 
                get{ return this._capvestdor;}
                set{ this._capvestdor = value;}
            } 
		    public string capvnomdor
            { 
                get{ return this._capvnomdor;}
                set{ this._capvnomdor = value;}
            } 
		    public string capvdirdor
            { 
                get{ return this._capvdirdor;}
                set{ this._capvdirdor = value;}
            } 
		    public string papvcoddor
            { 
                get{ return this._papvcoddor;}
                set{ this._papvcoddor = value;}
            } 
		    public string capvnitdor
            { 
                get{ return this._capvnitdor;}
                set{ this._capvnitdor = value;}
            } 
		    public string capvmerdor
            { 
                get{ return this._capvmerdor;}
                set{ this._capvmerdor = value;}
            } 
		    public string capvteldor
            { 
                get{ return this._capvteldor;}
                set{ this._capvteldor = value;}
            } 
        #endregion

        #region Constructor
            public aprovee()
            { 
		        this._capvestdor = true;
		        this._capvnomdor = "";
		        this._capvdirdor = "";
		        this._papvcoddor = "";
		        this._capvnitdor = "";
		        this._capvmerdor = "";
		        this._capvteldor = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
                this.Conexion.Conectar();
			    string sql = "select " +
                                     "capvestdor," +
                                     "capvnomdor," +
                                     "capvdirdor," +
                                     "papvcoddor," +
                                     "capvnitdor," +
                                     "capvmerdor," +
                                     "capvteldor " + 
                             "from aprovee " +
                             "where "+
                                    "papvcoddor = @papvcoddor";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@papvcoddor",this._papvcoddor);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._capvestdor=ResultadoConsulta.GetBoolean(0);
                    this._capvnomdor=ResultadoConsulta.GetString(1);
                    this._capvdirdor=ResultadoConsulta.GetString(2);
                    this._papvcoddor=ResultadoConsulta.GetString(3);
                    this._capvnitdor=ResultadoConsulta.GetString(4);
                    this._capvmerdor=ResultadoConsulta.GetString(5);
                    this._capvteldor=ResultadoConsulta.GetString(6);
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
                                     "capvestdor," +
                                     "capvnomdor," +
                                     "capvdirdor," +
                                     "papvcoddor," +
                                     "capvnitdor," +
                                     "capvmerdor," +
                                     "capvteldor " + 
                             "from aprovee " +
                             "where " +
                                    "papvcoddor = @papvcoddor";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@papvcoddor",this._papvcoddor);

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
			        string sql = "insert into aprovee (" +
                                                       "capvestdor," +
                                                       "capvnomdor," +
                                                       "capvdirdor," +
                                                       "papvcoddor," +
                                                       "capvnitdor," +
                                                       "capvmerdor," +
                                                       "capvteldor" +
                                                       ") " +
	                             "values (" + 
                                          "@capvestdor," +
                                          "@capvnomdor," +
                                          "@capvdirdor," +
                                          "@papvcoddor," +
                                          "@capvnitdor," +
                                          "@capvmerdor," +
                                          "@capvteldor" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroLogico("@capvestdor",this._capvestdor);
                    this.Conexion.AsignarParametroCadena("@capvnomdor",this._capvnomdor);
                    this.Conexion.AsignarParametroCadena("@capvdirdor",this._capvdirdor);
                    this.Conexion.AsignarParametroCadena("@papvcoddor",this._papvcoddor);
                    this.Conexion.AsignarParametroCadena("@capvnitdor",this._capvnitdor);
                    this.Conexion.AsignarParametroCadena("@capvmerdor",this._capvmerdor);
                    this.Conexion.AsignarParametroCadena("@capvteldor",this._capvteldor);

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
			        string sql = "update aprovee set " +
                                                     "capvestdor = @capvestdor, " +
                                                     "capvnomdor = @capvnomdor, " +
                                                     "capvdirdor = @capvdirdor, " +
                                                     "capvnitdor = @capvnitdor, " +
                                                     "capvmerdor = @capvmerdor, " +
                                                     "capvteldor = @capvteldor" +
                                 " where " +
                                        "papvcoddor = @papvcoddor";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroLogico("@capvestdor",this._capvestdor);
                    this.Conexion.AsignarParametroCadena("@capvnomdor",this._capvnomdor);
                    this.Conexion.AsignarParametroCadena("@capvdirdor",this._capvdirdor);
                    this.Conexion.AsignarParametroCadena("@papvcoddor",this._papvcoddor);
                    this.Conexion.AsignarParametroCadena("@capvnitdor",this._capvnitdor);
                    this.Conexion.AsignarParametroCadena("@capvmerdor",this._capvmerdor);
                    this.Conexion.AsignarParametroCadena("@capvteldor",this._capvteldor);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<aprovee> Lista(string where)
            { 
                List<aprovee> ListaResultado = new List<aprovee>();
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "capvestdor," +
                                     "capvnomdor," +
                                     "capvdirdor," +
                                     "papvcoddor," +
                                     "capvnitdor," +
                                     "capvmerdor," +
                                     "capvteldor " + 
                             "from aprovee " ;
 
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
                          aprovee Auxiliar = new aprovee();
                          Auxiliar.capvestdor = ResultadoConsulta.GetBoolean(0);
                          Auxiliar.capvnomdor = ResultadoConsulta.GetString(1);
                          Auxiliar.capvdirdor = ResultadoConsulta.GetString(2);
                          Auxiliar.papvcoddor = ResultadoConsulta.GetString(3);
                          Auxiliar.capvnitdor = ResultadoConsulta.GetString(4);
                          Auxiliar.capvmerdor = ResultadoConsulta.GetString(5);
                          Auxiliar.capvteldor = ResultadoConsulta.GetString(6);
                          ListaResultado.Add(Auxiliar);
                    }

                }
                this.Conexion.Desconectar();
                return ListaResultado;
            }

            public List<aperson> ObtenerContactos()
            {
            List<aperson> ListaResultado = new List<aperson>();
            this.Conexion.Conectar();
            string sql = "select " +
                                 "capsestper," +
                                 "capsnomper," +
                                 "capsapepat," +
                                 "capsapemat," +
                                 "capsdirper," +
                                 "capsnumcel," +
                                 "capscorele," +
                                 "papscodper," +
                                 "capsnumcid " +
                         "from aperson,aconpro " +
                         "where papscodper=facpcodper and " +
                         "facpcoddor=@facpcoddor;";
            
            this.Conexion.PrepararComando(sql);
            this.Conexion.AsignarParametroCadena("@facpcoddor", this._papvcoddor);
            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta != null)
            {
                while (ResultadoConsulta.Read())
                {
                    aperson Auxiliar = new aperson();
                    Auxiliar.capsestper = ResultadoConsulta.GetBoolean(0);
                    Auxiliar.capsnomper = ResultadoConsulta.GetString(1);
                    Auxiliar.capsapepat = ResultadoConsulta.GetString(2);
                    Auxiliar.capsapemat = ResultadoConsulta.GetString(3);
                    Auxiliar.capsdirper = ResultadoConsulta.GetString(4);
                    Auxiliar.capsnumcel = ResultadoConsulta.GetString(5);
                    Auxiliar.capscorele = ResultadoConsulta.GetString(6);
                    Auxiliar.papscodper = ResultadoConsulta.GetString(7);
                    Auxiliar.capsnumcid = ResultadoConsulta.GetString(8);
                    ListaResultado.Add(Auxiliar);
                }

            }
            this.Conexion.Desconectar();
            return ListaResultado;
        }
        public void EliminarContactos()
        {            
            this.Conexion.Conectar();
            string sql = "delete " +                                
                         "from aconpro " +
                         "where "+
                         "facpcoddor=@facpcoddor;";
            this.Conexion.PrepararComando(sql);
            this.Conexion.AsignarParametroCadena("@facpcoddor", this._papvcoddor);
            this.Conexion.EjecutarTransaccion();
            this.Conexion.Desconectar();            
        }
        #endregion

    }
}

