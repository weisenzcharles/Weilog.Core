using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Weilog.Core
{
    /// <summary>
    /// 提供 WebApi Http 相关方法。
    /// </summary>
    public class WebApiHttpUtils
    {
        private const string USER_AGENT = "Weilog";
        private const string token = "uht2luuSExqVnzF5KsLm4ZTuWsb+HLao9jNl2mUFU4yP3jKu9rEL3A==";
        /// <summary>
        /// 执行 HTTP PUT 请求。
        /// </summary>
        /// <param name="url">请求 URL。</param>
        /// <returns>HTTP 响应。</returns>
        public static string DoPut(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "PUT";
            req.KeepAlive = true;
            req.UserAgent = "Weilog";
            req.Timeout = 300000;
            req.ContentType = "application/json-patch+json";
            req.Headers["token"] = token;
            //byte[] putData = Encoding.UTF8.GetBytes(parameters);
            req.ContentLength = 0;


            string result = string.Empty;

            //using (Stream reqStream = req.GetRequestStream())
            //{
            //    reqStream.Write(putData, 0, putData.Length);

            //    reqStream.Close();
            //}

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            Stream stream = resp.GetResponseStream();

            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }


        /// <summary>
        /// 执行 HTTP PUT 请求。
        /// </summary>
        /// <param name="url">请求 URL。</param>
        /// <param name="parameters">请求参数。</param>
        /// <returns>HTTP响应。</returns>
        public static string DoPut(string url, string parameters)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //req.AllowAutoRedirect = true;  //允许重定向
            req.Method = "PUT";
            req.KeepAlive = true;
            req.UserAgent = "Weilog";
            req.Timeout = 300000;
            req.ContentType = "application/json-patch+json";
            //req.Connection = "keep-alive";
            req.Headers["token"] = token;
            byte[] postData = Encoding.UTF8.GetBytes(parameters);
            req.ContentLength = postData.Length;

            string result = string.Empty;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(postData, 0, postData.Length);

                reqStream.Close();
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            Stream stream = resp.GetResponseStream();

            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// 执行 HTTP PUT 请求。
        /// </summary>
        /// <param name="url">请求 URL。</param>
        /// <param name="parameters">请求参数。</param>
        /// <returns>HTTP响应。</returns>
        public static string DoPut(string url, IDictionary<string, string> parameters)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //req.AllowAutoRedirect = true;  //允许重定向
            req.Method = "PUT";
            req.KeepAlive = true;
            req.UserAgent = "Weilog";
            req.Timeout = 300000;
            req.ContentType = "application/json-patch+json";
            //req.Connection = "keep-alive";
            req.Headers["token"] = token;
            byte[] postData = Encoding.UTF8.GetBytes(BuildPostData(parameters, false));
            req.ContentLength = postData.Length;

            string result = string.Empty;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(postData, 0, postData.Length);

                reqStream.Close();
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            Stream stream = resp.GetResponseStream();

            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }



        /// <summary>
        /// 执行 HTTP POST 请求。
        /// </summary>
        /// <param name="url">请求容器URL。</param>
        /// <param name="parameters">请求参数。</param>
        /// <returns>HTTP响应。</returns>
        public static string DoPost(string url, string parameters)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //req.AllowAutoRedirect = true;  //允许重定向
            req.Method = "POST";
            req.KeepAlive = true;
            req.UserAgent = "Weilog";
            req.Timeout = 300000;
            req.ContentType = "application/json-patch+json";
            //req.Connection = "keep-alive";
            req.Headers["token"] = token;
            byte[] postData = Encoding.UTF8.GetBytes(parameters);
            req.ContentLength = postData.Length;
            //Stream reqStream = req.GetRequestStream();
            //reqStream.Write(postData, 0, postData.Length);
            //reqStream.Close();

            string result = string.Empty;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(postData, 0, postData.Length);

                reqStream.Close();
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            Stream stream = resp.GetResponseStream();

            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;

            //HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
            //if (rsp.CharacterSet != null)
            //{
            //    Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
            //    return GetResponseAsString(rsp, encoding);
            //}
            //else
            //{
            //    return string.Empty;
            //}
        }

        /// <summary>
        /// 执行HTTP POST请求。
        /// </summary>
        /// <param name="url">请求容器URL。</param>
        /// <param name="parameters">请求参数。</param>
        /// <returns>HTTP响应。</returns>
        public static string DoPost(string url, IDictionary<string, string> parameters)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //req.AllowAutoRedirect = true;  //允许重定向
            req.Method = "POST";
            req.KeepAlive = true;
            req.UserAgent = "Weilog";
            req.Timeout = 300000;
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            req.Headers["token"] = token;
            byte[] postData = Encoding.UTF8.GetBytes(BuildPostData(parameters));
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();

            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
            if (rsp.CharacterSet != null)
            {
                Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
                return GetResponseAsString(rsp, encoding);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 执行HTTP GET请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>HTTP响应</returns>
        public static string DoGet(string url, IDictionary<string, string> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildPostData(parameters);
                }
                else
                {
                    url = url + "?" + BuildPostData(parameters);
                }
            }

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ServicePoint.Expect100Continue = false;
            req.Method = "GET";
            req.KeepAlive = true;
            req.UserAgent = "Weilog";
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            req.Headers["token"] = token;
            HttpWebResponse rsp = null;
            try
            {
                rsp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException webEx)
            {
                if (webEx.Status == WebExceptionStatus.Timeout)
                {
                    rsp.Close();
                }
            }

            if (rsp != null)
            {
                if (rsp.CharacterSet != null)
                {
                    Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
                    return GetResponseAsString(rsp, encoding);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 执行HTTP GET请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="userAgent">代理</param>
        /// <returns>HTTP响应</returns>
        public static string DoGet(string url, IDictionary<string, string> parameters, string userAgent)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildPostData(parameters);
                }
                else
                {
                    url = url + "?" + BuildPostData(parameters);
                }
            }

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ServicePoint.Expect100Continue = false;
            req.Method = "GET";
            req.KeepAlive = true;
            req.UserAgent = userAgent;
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            HttpWebResponse rsp = null;
            try
            {
                rsp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException webEx)
            {
                if (webEx.Status == WebExceptionStatus.Timeout)
                {
                    rsp.Close();
                }
            }

            if (rsp != null)
            {
                if (rsp.CharacterSet != null)
                {
                    Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
                    return GetResponseAsString(rsp, encoding);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }


        ///// <summary>
        ///// 执行带文件上传的HTTP POST请求。
        ///// </summary>
        ///// <param name="url">请求地址</param>
        ///// <param name="textParams">请求文本参数</param>
        ///// <param name="fileParams">请求文件参数</param>
        ///// <returns>HTTP响应</returns>
        //public static string DoPost(string url, IDictionary<string, string> textParams, IDictionary<string, FileItem> fileParams)
        //{
        //    // 如果没有文件参数，则走普通POST请求
        //    if (fileParams == null || fileParams.Count == 0)
        //    {
        //        return DoPost(url, textParams);
        //    }

        //    string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线

        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        //    req.Method = "POST";
        //    req.KeepAlive = true;
        //    req.UserAgent = "Top4Net";
        //    req.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;

        //    Stream reqStream = req.GetRequestStream();
        //    byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
        //    byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

        //    // 组装文本请求参数
        //    string textTemplate = "Content-Disposition:form-data;name=\"{0}\"\r\nContent-Type:text/plain\r\n\r\n{1}";
        //    IEnumerator<KeyValuePair<string, string>> textEnum = textParams.GetEnumerator();
        //    while (textEnum.MoveNext())
        //    {
        //        string textEntry = string.Format(textTemplate, textEnum.Current.Key, textEnum.Current.Value);
        //        byte[] itemBytes = Encoding.UTF8.GetBytes(textEntry);
        //        reqStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
        //        reqStream.Write(itemBytes, 0, itemBytes.Length);
        //    }

        //    // 组装文件请求参数
        //    string fileTemplate = "Content-Disposition:form-data;name=\"{0}\";filename=\"{1}\"\r\nContent-Type:{2}\r\n\r\n";
        //    IEnumerator<KeyValuePair<string, FileItem>> fileEnum = fileParams.GetEnumerator();
        //    while (fileEnum.MoveNext())
        //    {
        //        string key = fileEnum.Current.Key;
        //        FileItem fileItem = fileEnum.Current.Value;
        //        string fileEntry = string.Format(fileTemplate, key, fileItem.GetFileName(), fileItem.GetMimeType());
        //        byte[] itemBytes = Encoding.UTF8.GetBytes(fileEntry);
        //        reqStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
        //        reqStream.Write(itemBytes, 0, itemBytes.Length);

        //        byte[] fileBytes = fileItem.GetContent();
        //        reqStream.Write(fileBytes, 0, fileBytes.Length);
        //    }

        //    reqStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
        //    reqStream.Close();

        //    HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
        //    Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
        //    return GetResponseAsString(rsp, encoding);
        //}

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        private static string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            StringBuilder result = new StringBuilder();
            Stream stream = null;
            StreamReader reader = null;

            try
            {

                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                //rsp.Close();
                reader = new StreamReader(stream, encoding);

                // 每次读取不大于256个字符，并写入字符串
                char[] buffer = new char[256];
                int readBytes = 0;
                while ((readBytes = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    result.Append(buffer, 0, readBytes);
                }
            }
            catch (WebException webEx)
            {
                if (webEx.Status == WebExceptionStatus.Timeout)
                {
                    result = new StringBuilder();
                }
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }

            return result.ToString();
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典。</param>
        /// <returns>URL编码后的请求数据。</returns>
        public static string BuildPostData(IDictionary<string, string> parameters)
        {
            return BuildPostData(parameters, true);
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典。</param>
        /// <param name="isEscapeData">Value是否进行转义。</param>
        /// <returns>URL编码后的请求数据。</returns>
        public static string BuildPostData(IDictionary<string, string> parameters, bool isEscapeData)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;

            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }

                    postData.Append(name);
                    postData.Append("=");
                    if (isEscapeData)
                    {
                        postData.Append(Uri.EscapeDataString(value));
                    }
                    else
                    {
                        postData.Append(value);
                    }

                    hasParam = true;
                }
            }

            return postData.ToString();
        }

        private const Dictionary<string, string> _defaultHeaderDict = null;
        private const Dictionary<string, string> _defaultPostDict = null;
        private const int _defaultTimeout = 30 * 1000;
        private const string _defaultPostData = null;
        private const int _defaultReadWriteTimeout = 30 * 1000;
        private const string _defultCharset = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headerDict"></param>
        /// <param name="postDict"></param>
        /// <param name="timeout"></param>
        /// <param name="postData"></param>
        /// <param name="readWriteTimeout"></param>
        /// <returns></returns>
        public HttpWebResponse _getUrlResponse(string url,
                                 Dictionary<string, string> headerDict = _defaultHeaderDict,
                                 Dictionary<string, string> postDict = _defaultPostDict,
                                 int timeout = _defaultTimeout,
                                 string postData = _defaultPostData,
                                 int readWriteTimeout = _defaultReadWriteTimeout)
        {

            HttpWebResponse webResponse = null;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.AllowAutoRedirect = true;
            webRequest.Accept = "*/*";
            webRequest.KeepAlive = true;
            webRequest.UserAgent = "Souke";
            webRequest.Headers["Accept-Encoding"] = "gzip, deflate";
            webRequest.AutomaticDecompression = DecompressionMethods.GZip;
            webRequest.Proxy = null;

            if (timeout > 0)
            {
                webRequest.Timeout = timeout;
            }

            if (readWriteTimeout > 0)
            {
                webRequest.ReadWriteTimeout = readWriteTimeout;
            }

            if ((headerDict != null) && (headerDict.Count > 0))
            {
                foreach (string header in headerDict.Keys)
                {
                    string headerValue = "";
                    if (headerDict.TryGetValue(header, out headerValue))
                    {
                        if (header.ToLower() == "referer")
                        {
                            webRequest.Referer = headerValue;
                        }
                        else if (header.ToLower() == "allowautoredirect")
                        {
                            bool isAllow = false;
                            if (bool.TryParse(headerValue, out isAllow))
                            {
                                webRequest.AllowAutoRedirect = isAllow;
                            }
                        }
                        else if (header.ToLower() == "accept")
                        {
                            webRequest.Accept = headerValue;
                        }
                        else if (header.ToLower() == "keepalive")
                        {
                            bool isKeepAlive = false;
                            if (bool.TryParse(headerValue, out isKeepAlive))
                            {
                                webRequest.KeepAlive = isKeepAlive;
                            }
                        }
                        else if (header.ToLower() == "accept-language")
                        {
                            webRequest.Headers["Accept-Language"] = headerValue;
                        }
                        else if (header.ToLower() == "useragent")
                        {
                            webRequest.UserAgent = headerValue;
                        }
                        else if (header.ToLower() == "content-type")
                        {
                            webRequest.ContentType = headerValue;
                        }
                        else
                        {
                            webRequest.Headers[header] = headerValue;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (((postDict != null) && (postDict.Count > 0)) || (!string.IsNullOrEmpty(postData)))
            {
                webRequest.Method = "POST";
                if (webRequest.ContentType == null)
                {
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                }

                if ((postDict != null) && (postDict.Count > 0))
                {
                    postData = BuildPostData(postDict);
                }

                //byte[] postBytes = Encoding.GetEncoding("utf-8").GetBytes(postData);
                byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                webRequest.ContentLength = postBytes.Length;

                Stream postDataStream = webRequest.GetRequestStream();
                postDataStream.Write(postBytes, 0, postBytes.Length);
                postDataStream.Close();
            }
            else
            {
                webRequest.Method = "GET";
            }

            try
            {
                webResponse = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException webEx)
            {
                if (webEx.Status == WebExceptionStatus.Timeout)
                {
                    webResponse = null;
                }
            }

            return webResponse;
        }

    }
}
