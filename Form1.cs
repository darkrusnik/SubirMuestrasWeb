using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using WinSCP;
using System.IO;
using System.Net;

namespace SubirFotoWebBrazalete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (cmbParque.SelectedItem != null)
            {
                var parque = cmbParque.SelectedItem;
                var rutaM = cmbRuta.SelectedItem;
                //conexión a base de datos
                Configuracion.getDatosDB();
                Configuracion.DatosDB datosdb = Datos(cmbParque.SelectedItem.ToString());
                string sCnn;
                sCnn = "data source = " + datosdb.url + "; initial catalog = " + datosdb.db + "; user id = " + datosdb.userdb + "; password = " + datosdb.passdb + "";
                string rutaMedio = "";
                if (rutaM.Equals("Producción"))
                {
                    rutaMedio = datosdb.rutaProd;
                } else
                {
                    rutaMedio  = datosdb.rutaHist;
                }
                
                string sSel = @"select mv.idMultimedio id ,REPLACE(replace (m.RutaMultimedioMiniatura,'M:','"+ rutaMedio + "'),'\', '/') ruta , m.idubicacion ubi from foto.multimediovisitante mv with(nolock) inner join foto.multimedio m with(nolock) on m.idmultimedio = mv.idmultimedio where mv.codigobrazalete = '" + txtbraza.Text + "' and convert(date, mv.fecha) = '" + txtfecha.Text + "'";

                SqlDataAdapter da;
                DataTable dt = new DataTable();

                try
                {
                    da = new SqlDataAdapter(sSel, sCnn);
                    da.Fill(dt);


                    try
                    {
                        XFTP xftp = new XFTP("ftp://"+ datosdb.ftp + "", datosdb.userFTP, datosdb.passFTP);

                        if (Directory.Exists("C:\\foto\\Fotos\\" + txtbraza))
                        {
                            Console.WriteLine("That path exists already.");
                            return;
                        }
                        else
                        {
                            Directory.CreateDirectory("C:\\foto\\Fotos\\" + txtbraza.Text);
                        }


                        foreach (DataRow row in dt.Rows)
                        {
                            GuardarImagen(@"C:\foto\Fotos\" + txtbraza.Text + @"\" + row[0].ToString() + ".JPG", @row[1].ToString());
                            //File.Copy(@row[1].ToString(), Path.Combine(@"C:\foto\Fotos\"+txtbraza, @row[1].ToString()+".JPG"), true);

                            //lblruta.Text = @row[1].ToString();
                            //
                        }
                        SessionOptions sessionOptions = new SessionOptions
                        {
                            Protocol = Protocol.Sftp,
                            PortNumber = 7580,
                            HostName = datosdb.ftp,
                            UserName = datosdb.userFTP,
                            Password = datosdb.passFTP,
                            GiveUpSecurityAndAcceptAnySshHostKey = true
                        };

                        foreach (DataRow row in dt.Rows)
                        {
                            
                            string rutaSFTP = @"C:\foto\Fotos\" + txtbraza.Text + @"\" + row[0].ToString() + ".JPG";
                            using (Session session = new Session())
                            {
                                // Connect
                                session.Open(sessionOptions);

                                // Download files
                                TransferOptions transferOptions = new TransferOptions();
                                transferOptions.TransferMode = TransferMode.Binary;
                                string [] d = txtfecha.Text.Split('-');
                                TransferOperationResult transferResult; //fotoxcaret.com/httpdocs/fotos/1
                                //transferResult = session.GetFiles("/var/www/vhosts/photoxenotes.com/httpdocs/datos/datos1/",rutaSFTP, false, transferOptions);
                                transferResult = session.PutFiles(rutaSFTP, "/var/www/vhosts/" + datosdb.rutaFTP + "/"+d[0]+"/"+d[1]+"/"+d[0]+ d[1] + d[2] + "/" + row[2].ToString() + "/MINI/", false, transferOptions);

                                // Throw on any error
                                transferResult.Check();

                                // Print results
                                foreach (TransferEventArgs transfer in transferResult.Transfers)
                                {
                                    Console.WriteLine("Download of {0} succeeded", transfer.FileName);
                                }
                            }
                        }






                    }
                    catch (Exception ex)
                    {
                        //tarea.CancelAsync();
                        MessageBox.Show("error al subir zip, verificar conexion de red");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error al subir zip, verificar conexion de red");
                }
            }
        }

        public void GuardarImagen(string file_name, string url)
        {
            //  System.ComponentModel.BackgroundWorker tarea = new System.ComponentModel.BackgroundWorker();
            try
            {
                byte[] content;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                using (BinaryReader br = new BinaryReader(stream))
                {
                    content = br.ReadBytes(50000000);
                    br.Close();
                }
                response.Close();

                FileStream fs = new FileStream(file_name, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                /*if (File.Exists(@""+file_name))
                {
                    fs.Close();
                    bw.Close();
                }*/
                try
                {
                    bw.Write(content);
                    fs.Close();
                    bw.Close();

                }
                finally
                {
                    fs.Close();
                    bw.Close();
                }
            }
            catch (Exception er)
            {
                er.ToString();
            }
            
        }

        public Configuracion.DatosDB Datos(string parque)
        {
            Configuracion.DatosDB datosdb = new Configuracion.DatosDB();


            if (parque.Equals("Xcaret"))
            {
                datosdb = Configuracion.DatosDBXcaret;

            }
            else if (parque.Equals("Xelha"))
            {
                datosdb = Configuracion.DatosDBXelha;
            }
            else if (parque.Equals("Xenotes"))
            {
                datosdb = Configuracion.DatosDBXenotes;
            }
            else if (parque.Equals("Xplor"))
            {
                datosdb = Configuracion.DatosDBXplor;
            }
            else if (parque.Equals("XplorFuego"))
            {
                datosdb = Configuracion.DatosDBXplorFuego;

            }
            else if (parque.Equals("Xoximilco"))
            {
                datosdb = Configuracion.DatosDBXoximilco;
            }
            else if (parque.Equals("Xenses"))
            {
                datosdb = Configuracion.DatosDBXenses;
            }
            else
            {
                MessageBox.Show("No se encontraron el parque seleccionado");

            }
            return datosdb;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (cmbParque.SelectedItem != null)
            {
                var parque = cmbParque.SelectedItem;
                var rutaM = cmbRuta.SelectedItem;
                //conexión a base de datos
                Configuracion.getDatosDB();
                Configuracion.DatosDB datosdb = Datos(cmbParque.SelectedItem.ToString());
                string sCnn;
                sCnn = "data source = " + datosdb.url + "; initial catalog = " + datosdb.db + "; user id = " + datosdb.userdb + "; password = " + datosdb.passdb + "";
                string rutaMedio = "";
                if (rutaM.Equals("Producción"))
                {
                    rutaMedio = datosdb.rutaProd;
                }
                else
                {
                    rutaMedio = datosdb.rutaHist;
                }

                string sSel = @"select v.idMultimedio ,REPLACE(replace (m.RutaMultimedio,'M:','" + rutaMedio + "'),"+@"'\'"+ ", '/') ruta, replace(convert(date,m.fCaptura),'-','') fecha from pdv.VentaIntenet v with(nolock) inner join foto.Multimedio m with(nolock) on m.idMultimedio = v.idMultimedio where idpedido= " + txtbraza.Text+"";

                SqlDataAdapter da;
                DataTable dt = new DataTable();

                try
                {
                    da = new SqlDataAdapter(sSel, sCnn);
                    da.Fill(dt);


                    try
                    {
                        XFTP xftp = new XFTP("ftp://" + datosdb.ftp + "", datosdb.userFTP, datosdb.passFTP);

                        if (Directory.Exists("C:\\foto\\Fotos\\" + txtbraza))
                        {
                            Console.WriteLine("That path exists already.");
                            return;
                        }
                        else
                        {
                            Directory.CreateDirectory("C:\\foto\\Fotos\\" + txtbraza.Text);
                        }


                        foreach (DataRow row in dt.Rows)
                        {
                            GuardarImagen(@"C:\foto\Fotos\" + txtbraza.Text + @"\" + row[0].ToString() + ".JPG", @row[1].ToString());
                            //File.Copy(@row[1].ToString(), Path.Combine(@"C:\foto\Fotos\"+txtbraza, @row[1].ToString()+".JPG"), true);

                            //lblruta.Text = @row[1].ToString();
                            //
                        }
                        SessionOptions sessionOptions = new SessionOptions
                        {
                            Protocol = Protocol.Sftp,
                            PortNumber = 7580,
                            HostName = datosdb.ftp,
                            UserName = datosdb.userFTP,
                            Password = datosdb.passFTP,
                            GiveUpSecurityAndAcceptAnySshHostKey = true
                        };

                        foreach (DataRow row in dt.Rows)
                        {

                            string rutaSFTP = @"C:\foto\Fotos\" + txtbraza.Text + @"\" + row[0].ToString() + ".JPG";
                            using (Session session = new Session())
                            {
                                // Connect
                                session.Open(sessionOptions);

                                // Download files
                                TransferOptions transferOptions = new TransferOptions();
                                transferOptions.TransferMode = TransferMode.Binary;
                                string[] d = txtfecha.Text.Split('-');
                                TransferOperationResult transferResult; //fotoxcaret.com/httpdocs/fotos/1
                                if (!session.FileExists("/var/www/vhosts/" + datosdb.rutaFTPOri + row[2].ToString() + "/"))
                                {
                                    session.CreateDirectory("/var/www/vhosts/" + datosdb.rutaFTPOri + row[2].ToString() + "/");
                                }
                                //transferResult = session.GetFiles("/var/www/vhosts/photoxenotes.com/httpdocs/datos/datos1/",rutaSFTP, false, transferOptions);
                                transferResult = session.PutFiles(rutaSFTP, "/var/www/vhosts/" + datosdb.rutaFTPOri  + row[2].ToString() + "/", false, transferOptions);

                                // Throw on any error
                                transferResult.Check();

                                // Print results
                                foreach (TransferEventArgs transfer in transferResult.Transfers)
                                {
                                    Console.WriteLine("Download of {0} succeeded", transfer.FileName);
                                }
                            }
                        }






                    }
                    catch (Exception ex)
                    {
                        //tarea.CancelAsync();
                        MessageBox.Show("error al subir zip, verificar conexion de red");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error al subir zip, verificar conexion de red");
                }
            }
        }
    }
}
