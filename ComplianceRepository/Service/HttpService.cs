using System;
using System.IO;
using System.Net;
using System.Text;

namespace ComplianceRepository.Service
{
    public class HttpService
    {
        public HttpService(string url)
        {
            _url = url;
        }

        #region PrivateField
        private readonly string _url;
        #endregion PrivateField

        #region PrivateMethod
        private HttpWebRequest GetRequest(string url)
        {
            var request = WebRequest.CreateHttp(new Uri(url));
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Method = "GET";
            request.Timeout = 60000;

            return request;
        }

        private static string GetResponse(HttpWebRequest request)
        {
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
        #endregion PrivateMethod

        #region PublicMethod
        public string RequestGet(string requestQuery)
        {
            try
            {
                HttpWebRequest request = GetRequest($"{_url}/{requestQuery}");
                return GetResponse(request);
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    try
                    {
                        using (Stream responseStream = wex.Response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }

                return wex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion PublicMethod
    }
}