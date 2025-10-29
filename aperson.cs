using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class aperson {

		#region Campos
            private bool _capsestper;
            private string _capsnomper;
            private string _capsapepat;
            private string _capsapemat;
            private string _capsdirper;
            private string _capsnumcel;
            private string _capscorele;
            private string _papscodper;
            private string _capsnumcid;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public bool capsestper
            { 
                get{ return this._capsestper;}
                set{ this._capsestper = value;}
            } 
		    public string capsnomper
            { 
                get{ return this._capsnomper;}
                set{ this._capsnomper = value;}
            } 
		    public string capsapepat
            { 
                get{ return this._capsapepat;}
                set{ this._capsapepat = value;}
            } 
		    public string capsapemat
            { 
                get{ return this._capsapemat;}
                set{ this._capsapemat = value;}
            } 
		    public string capsdirper
            { 
                get{ return this._capsdirper;}
                set{ this._capsdirper = value;}
            } 
		    public string capsnumcel
            { 
                get{ return this._capsnumcel;}
                set{ this._capsnumcel = value;}
            } 
		    public string capscorele
            { 
                get{ return this._capscorele;}
                set{ this._capscorele = value;}
            } 
		    public string papscodper
            { 
                get{ return this._papscodper;}
                set{ this._papscodper = value;}
            } 
		    public string capsnumcid
            { 
                get{ return this._capsnumcid;}
                set{ this._capsnumcid = value;}
            } 
        #endregion

        #region Constructor
            public aperson()
            { 
		        this._capsestper = true;
		        this._capsnomper = "";
		        this._capsapepat = "";
		        this._capsapemat = "";
		        this._capsdirper = "";
		        this._capsnumcel = "";
		        this._capscorele = "";
		        this._papscodper = "";
		        this._capsnumcid = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
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
                             "from aperson " +
                             "where "+
                                    "papscodper = @papscodper";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@papscodper",this._papscodper);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._capsestper=ResultadoConsulta.GetBoolean(0);
                    this._capsnomper=ResultadoConsulta.GetString(1);
                    this._capsapepat=ResultadoConsulta.GetString(2);
                    this._capsapemat=ResultadoConsulta.GetString(3);
                    this._capsdirper=ResultadoConsulta.GetString(4);
                    this._capsnumcel=ResultadoConsulta.GetString(5);
                    this._capscorele=ResultadoConsulta.GetString(6);
                    this._papscodper=ResultadoConsulta.GetString(7);
                    this._capsnumcid=ResultadoConsulta.GetString(8);
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
                                     "capsestper," +
                                     "capsnomper," +
                                     "capsapepat," +
                                     "capsapemat," +
                                     "capsdirper," +
                                     "capsnumcel," +
                                     "capscorele," +
                                     "papscodper," +
                                     "capsnumcid " + 
                             "from aperson " +
                             "where " +
                                    "papscodper = @papscodper";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@papscodper",this._papscodper);

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

            public bool VerificarExistenciaCI()
        {
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
                         "from aperson " +
                         "where " +
                                "capsnumcid = @capsnumcid";

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@capsnumcid", this._capsnumcid);

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
			        string sql = "insert into aperson (" +
                                                       "capsestper," +
                                                       "capsnomper," +
                                                       "capsapepat," +
                                                       "capsapemat," +
                                                       "capsdirper," +
                                                       "capsnumcel," +
                                                       "capscorele," +
                                                       "papscodper," +
                                                       "capsnumcid" +
                                                       ") " +
	                             "values (" + 
                                          "@capsestper," +
                                          "@capsnomper," +
                                          "@capsapepat," +
                                          "@capsapemat," +
                                          "@capsdirper," +
                                          "@capsnumcel," +
                                          "@capscorele," +
                                          "@papscodper," +
                                          "@capsnumcid" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroLogico("@capsestper",this._capsestper);
                    this.Conexion.AsignarParametroCadena("@capsnomper",this._capsnomper);
                    this.Conexion.AsignarParametroCadena("@capsapepat",this._capsapepat);
                    this.Conexion.AsignarParametroCadena("@capsapemat",this._capsapemat);
                    this.Conexion.AsignarParametroCadena("@capsdirper",this._capsdirper);
                    this.Conexion.AsignarParametroCadena("@capsnumcel",this._capsnumcel);
                    this.Conexion.AsignarParametroCadena("@capscorele",this._capscorele);
                    this.Conexion.AsignarParametroCadena("@papscodper",this._papscodper);
                    this.Conexion.AsignarParametroCadena("@capsnumcid",this._capsnumcid);

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
			        string sql = "update aperson set " +
                                                     "capsestper = @capsestper, " +
                                                     "capsnomper = @capsnomper, " +
                                                     "capsapepat = @capsapepat, " +
                                                     "capsapemat = @capsapemat, " +
                                                     "capsdirper = @capsdirper, " +
                                                     "capsnumcel = @capsnumcel, " +
                                                     "capscorele = @capscorele, " +
                                                     "capsnumcid = @capsnumcid" +
                                 " where " +
                                        "papscodper = @papscodper";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroLogico("@capsestper",this._capsestper);
                    this.Conexion.AsignarParametroCadena("@capsnomper",this._capsnomper);
                    this.Conexion.AsignarParametroCadena("@capsapepat",this._capsapepat);
                    this.Conexion.AsignarParametroCadena("@capsapemat",this._capsapemat);
                    this.Conexion.AsignarParametroCadena("@capsdirper",this._capsdirper);
                    this.Conexion.AsignarParametroCadena("@capsnumcel",this._capsnumcel);
                    this.Conexion.AsignarParametroCadena("@capscorele",this._capscorele);
                    this.Conexion.AsignarParametroCadena("@papscodper",this._papscodper);
                    this.Conexion.AsignarParametroCadena("@capsnumcid",this._capsnumcid);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<aperson> Lista(string where)
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
                             "from aperson " ;
 
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
        #endregion 

	}
}

