using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubirFotoWebBrazalete
{
   public class Configuracion
    {
        public static DatosDB DatosDBXenotes,
           DatosDBXcaret,
           DatosDBXelha,
           DatosDBXplor,
           DatosDBXplorFuego,
           DatosDBXoximilco,
           DatosDBXenses;

        public struct DatosDB
        {
            public string db;
            public string url;
            public string userdb;
            public string passdb;
            public string ftp;
            public string userFTP;
            public string passFTP;
            public string rutaProd;
            public string rutaHist;
            public string rutaFTP;
            public string rutaFTPOri;

            public DatosDB(string userdb, string passdb, string db, string url , string ftp  , string userFTP        , string passFTP   , string rutaProd , string rutaHist, string rutaFTP, string rutaFTPOri)
            {
                this.db = db;
                this.url = url;
                this.userdb = userdb;
                this.passdb = passdb;
                 this.ftp = ftp;
                 this.userFTP = userFTP;
                 this.passFTP = passFTP;
                 this.rutaProd = rutaProd;
                 this.rutaHist = rutaHist;
                  this.rutaFTP = rutaFTP;
                this.rutaFTPOri = rutaFTPOri;

            }
        }

        public static void getDatosDB()
        {
            //PosCarga.Properties.Settings.Default.ConexionXcaret[0];
            DatosDBXcaret = new DatosDB(
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXcaret[0],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXcaret[1],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXcaret[2],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXcaret[3],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXcaret[4],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXcaret[5],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXcaret[6],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXcaret[7],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXcaret[8],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXcaret[9],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXcaret[10]
                                            );
            DatosDBXelha = new DatosDB(
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[0],
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[1],
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[2],
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[3],
                                              SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[4],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[5],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[6],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[7],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[8],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[9],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[10]);
            DatosDBXenotes = new DatosDB(
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXenotes[0],
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXenotes[1],
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXenotes[2],
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXenotes[3],
                                               SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[4],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[5],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[6],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[7],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[8],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[9],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[10]);
                                           
            DatosDBXplor = new DatosDB(
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXplor[0],
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXplor[1],
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXplor[2],
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXplor[3],
                                               SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[4],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[5],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[6],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[7],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[8],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[9],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[10]);
                                           
            DatosDBXplorFuego = new DatosDB(
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXplorFuego[0],
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXplorFuego[1],
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXplorFuego[2],
                                           SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXplorFuego[3],
                                               SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[4],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[5],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[6],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[7],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[8],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[9],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[10]);
            DatosDBXoximilco = new DatosDB(
                                          SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXoximilco[0],
                                          SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXoximilco[1],
                                          SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXoximilco[2],
                                          SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXoximilco[3],
                                              SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[4],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[5],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[6],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[7],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[8],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[9],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[10]);

            DatosDBXenses = new DatosDB(
                                         SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXenses[0],
                                         SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXenses[1],
                                         SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXenses[2],
                                         SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXenses[3],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[4],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[5],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[6],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[7],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[8],
                                            SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[9],
                                             SubirFotoWebBrazalete.Properties.Settings.Default.ConexionXelha[10]);


        }
    }
}
