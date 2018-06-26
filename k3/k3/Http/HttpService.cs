using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace k3.Http
{
    class HttpService
    {
        public static CookieContainer GetCookie(string url)
        {
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            CookieContainer cc = new CookieContainer();
            try
            {
                req = (HttpWebRequest)WebRequest.Create(url);
                
                req.Method = "GET";
                req.AllowAutoRedirect = false;
                req.KeepAlive = false;
                req.ContentType = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 UBrowser/6.2.4092.1 Safari/537.36";
                req.CookieContainer = cc;
                res = (HttpWebResponse)req.GetResponse();
                return cc;
            }
            catch (Exception ex)
            {


                throw ex;
            }
        }
        public static string GetHtml(string getUrl, CookieContainer cookieContainer)
        {
            //Thread.Sleep(1000);
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            Stream responseStream = null;

            try
            {
                req = (HttpWebRequest)HttpWebRequest.Create(getUrl);
                req.CookieContainer = cookieContainer;
                req.ContentType = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                //req.ServicePoint.ConnectionLimit = header.maxTry;
                //req.Accept = header.accept;
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 UBrowser/6.2.4092.1 Safari/537.36";
                req.Method = "GET";
                res = (HttpWebResponse)req.GetResponse();

                responseStream = res.GetResponseStream();
                string html = new StreamReader(res.GetResponseStream()).ReadToEnd();

                return html;
            }
            catch 
            {
                return string.Empty;
            }
            finally
            {
                responseStream.Close();
                req.Abort();
                res.Close();
            }
        }

    }
}
