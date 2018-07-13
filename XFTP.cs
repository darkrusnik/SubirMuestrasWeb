using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Drawing.Imaging;


namespace SubirFotoWebBrazalete
{
    public class XFTP
    {
        public string servidor, usuario, password;
        public string mensajeError = "";
        private string rutaBaseApp = "/httpdocs/";
        private FtpWebRequest ftp;
       

        public XFTP(string server, string user, string password)
        {
            this.servidor = server;
            this.usuario = user;
            this.password = password;
        }

        public XFTP()
        {
            this.servidor = this.servidor;
            this.usuario = this.usuario;
            this.password = this.password;
            this.rutaBaseApp = "";
        }


        public bool subirArchivo(string rutaDestino, string rutaOriginal)
        {
            try
            {
                string RutaCompleta = this.servidor + this.rutaBaseApp + rutaDestino;
                this.ftp = (FtpWebRequest)FtpWebRequest.Create(RutaCompleta);
                ftp.Credentials = new NetworkCredential(this.usuario, this.password);

                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;
                FileStream fs = System.IO.File.OpenRead(rutaOriginal);

                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                Stream ftpstream = ftp.GetRequestStream();

                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();
                ftp.Abort();
                return true;
            }
            catch (Exception ex)
            {
                this.mensajeError = ex.Message;
                this.ftp.Abort();
                return false;
            }

        }
        public bool subirArchivoHttp(string rutaDestino, string urlfoto)
        {
            try
            {
                string requestUriString = this.servidor + this.rutaBaseApp + rutaDestino;
                this.ftp = (FtpWebRequest)WebRequest.Create(requestUriString);
                this.ftp.Credentials = new NetworkCredential(this.usuario, this.password);
                this.ftp.KeepAlive = true;
                this.ftp.UseBinary = true;
                this.ftp.Method = "STOR";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlfoto);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Image image = Image.FromStream(response.GetResponseStream());
                response.Close();
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                byte[] buffer = stream.ToArray();
                Stream requestStream = this.ftp.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Close();
                this.ftp.Abort();
                return true;
            }
            catch (Exception exception)
            {
                this.mensajeError = exception.Message;
                this.ftp.Abort();
                return false;
            }
        }

        public bool subirArchivoHttpFile(string rutaDestino, string urlfoto)
        {
            try
            {
                string requestUriString = this.servidor + this.rutaBaseApp + rutaDestino;
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(requestUriString);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(this.usuario, this.password);

                Stream ftpStream = request.GetRequestStream();
                FileStream file = File.OpenRead(urlfoto);

                int length = 1024;
                byte[] buffer = new byte[length];
                int bytesread = 0;

                do
                {
                    bytesread = file.Read(buffer, 0, length);
                    ftpStream.Write(buffer, 0, bytesread);
                }
                while (bytesread != 0);

                file.Close();
                ftpStream.Close();
                this.ftp.Abort();
                return true;
            }
            catch (Exception exception)
            {
                this.mensajeError = exception.Message;
                this.ftp.Abort();
                return false;
            }
        }

        public void crearDirectorio(string RutaDirectorio)
        {
            FtpWebResponse ftpResponse = null;

            try
            {
                /* Create an FTP Request */
                /*ftp = (FtpWebRequest)WebRequest.Create("/Prueba");*/
                ftp = (FtpWebRequest)WebRequest.Create(this.servidor + this.rutaBaseApp + RutaDirectorio);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftp.Credentials = new NetworkCredential(this.usuario, this.password);
                /* When in doubt, use these options */
                ftp.UseBinary = true;
                ftp.UsePassive = true;
                ftp.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
                /* Establish Return Communication with the FTP Server */
                try
                {
                    ftpResponse = (FtpWebResponse)ftp.GetResponse();
                }
                catch (Exception ex)
                {
                    string e = ex.Message;
                }
                finally
                {
                    /* Resource Cleanup */
                    ftpResponse.Close();
                    ftp = null;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
            //try
            //{
            //    string directorio = this.servidor + this.rutaBaseApp + RutaDirectorio;
            //    WebRequest request = WebRequest.Create(directorio);
            //    request.Method = WebRequestMethods.Ftp.MakeDirectory;

            //    request.Credentials = new NetworkCredential(this.usuario, this.password);

            //    using (var resp = (FtpWebResponse)request.GetResponse())
            //    {
            //        Console.WriteLine(resp.StatusCode);
            //    }
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    this.mensajeError = ex.Message;
            //    return false;
            //}
        }
    }
}
