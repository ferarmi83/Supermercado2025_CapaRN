using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class acompra {

		#region Campos
            private bool _cacpestcom;
            private DateTime _cacpferhor;
            private decimal _cacpmontot;
            private string _pacpcodcom;
            private string _cacpobscom;
            private string _facpcoddor;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public bool cacpestcom
            { 
                get{ return this._cacpestcom;}
                set{ this._cacpestcom = value;}
            } 
		    public DateTime cacpferhor
            { 
                get{ return this._cacpferhor;}
                set{ this._cacpferhor = value;}
            } 
		    public decimal cacpmontot
            { 
                get{ return this._cacpmontot;}
                set{ this._cacpmontot = value;}
            } 
		    public string pacpcodcom
            { 
                get{ return this._pacpcodcom;}
                set{ this._pacpcodcom = value;}
            } 
		    public string cacpobscom
            { 
                get{ return this._cacpobscom;}
                set{ this._cacpobscom = value;}
            } 
		    public string facpcoddor
            { 
                get{ return this._facpcoddor;}
                set{ this._facpcoddor = value;}
            } 
        #endregion

        #region Constructor
            public acompra()
            { 
		        this._cacpestcom = true;
		        this._cacpferhor = DateTime.Now;
		        this._cacpmontot = 0;
		        this._pacpcodcom = "";
		        this._cacpobscom = "";
		        this._facpcoddor = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
                this.Conexion.Conectar();
			    string sql = "select " +
                                     "cacpestcom," +
                                     "cacpferhor," +
                                     "cacpmontot," +
                                     "pacpcodcom," +
                                     "cacpobscom," +
                                     "facpcoddor " + 
                             "from acompra " +
                             "where "+
                                    "pacpcodcom = @pacpcodcom";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@pacpcodcom",this._pacpcodcom);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._cacpestcom=ResultadoConsulta.GetBoolean(0);
                    this._cacpferhor=ResultadoConsulta.GetDateTime(1);
                    this._cacpmontot=ResultadoConsulta.GetDecimal(2);
                    this._pacpcodcom=ResultadoConsulta.GetString(3);
                    this._cacpobscom=ResultadoConsulta.GetString(4);
                    this._facpcoddor=ResultadoConsulta.GetString(5);
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
                                     "cacpestcom," +
                                     "cacpferhor," +
                                     "cacpmontot," +
                                     "pacpcodcom," +
                                     "cacpobscom," +
                                     "facpcoddor " + 
                             "from acompra " +
                             "where " +
                                    "pacpcodcom = @pacpcodcom";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@pacpcodcom",this._pacpcodcom);

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
			        string sql = "insert into acompra (" +
                                                       "cacpestcom," +
                                                       "cacpferhor," +
                                                       "cacpmontot," +
                                                       "pacpcodcom," +
                                                       "cacpobscom," +
                                                       "facpcoddor" +
                                                       ") " +
	                             "values (" + 
                                          "@cacpestcom," +
                                          "@cacpferhor," +
                                          "@cacpmontot," +
                                          "@pacpcodcom," +
                                          "@cacpobscom," +
                                          "@facpcoddor" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroLogico("@cacpestcom",this._cacpestcom);
                    this.Conexion.AsignarParametroFechaHora("@cacpferhor",this._cacpferhor);
                    this.Conexion.AsignarParametroDecimal("@cacpmontot",this._cacpmontot);
                    this.Conexion.AsignarParametroCadena("@pacpcodcom",this._pacpcodcom);
                    this.Conexion.AsignarParametroCadena("@cacpobscom",this._cacpobscom);
                    this.Conexion.AsignarParametroCadena("@facpcoddor",this._facpcoddor);

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
			        string sql = "update acompra set " +
                                                     "cacpestcom = @cacpestcom, " +
                                                     "cacpferhor = @cacpferhor, " +
                                                     "cacpmontot = @cacpmontot, " +
                                                     "cacpobscom = @cacpobscom, " +
                                                     "facpcoddor = @facpcoddor" +
                                 " where " +
                                        "pacpcodcom = @pacpcodcom";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroLogico("@cacpestcom",this._cacpestcom);
                    this.Conexion.AsignarParametroFechaHora("@cacpferhor",this._cacpferhor);
                    this.Conexion.AsignarParametroDecimal("@cacpmontot",this._cacpmontot);
                    this.Conexion.AsignarParametroCadena("@pacpcodcom",this._pacpcodcom);
                    this.Conexion.AsignarParametroCadena("@cacpobscom",this._cacpobscom);
                    this.Conexion.AsignarParametroCadena("@facpcoddor",this._facpcoddor);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<acompra> Lista(string where)
            { 
                List<acompra> ListaResultado = new List<acompra>();
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "cacpestcom," +
                                     "cacpferhor," +
                                     "cacpmontot," +
                                     "pacpcodcom," +
                                     "cacpobscom," +
                                     "facpcoddor " + 
                             "from acompra " ;
 
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
                          acompra Auxiliar = new acompra();
                          Auxiliar.cacpestcom = ResultadoConsulta.GetBoolean(0);
                          Auxiliar.cacpferhor = ResultadoConsulta.GetDateTime(1);
                          Auxiliar.cacpmontot = ResultadoConsulta.GetDecimal(2);
                          Auxiliar.pacpcodcom = ResultadoConsulta.GetString(3);
                          Auxiliar.cacpobscom = ResultadoConsulta.GetString(4);
                          Auxiliar.facpcoddor = ResultadoConsulta.GetString(5);
                          ListaResultado.Add(Auxiliar);
                    }

                }
                this.Conexion.Desconectar();
                return ListaResultado;
            } 
        #endregion 

	}
}

