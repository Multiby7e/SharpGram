using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Collections;

namespace SharpGram
{
    public static class Client
    {
        public static XmlDocument XML = new XmlDocument();
        public static Dictionary<string, string> Info = new Dictionary<string, string>();
        public static Dictionary<string, string> Link = new Dictionary<string, string>();
        public static Dictionary<string, string> Header = new Dictionary<string, string>();
        public static Dictionary<string, string> reqData = new Dictionary<string, string>();
        public static Dictionary<string, string> responseData = new Dictionary<string, string>();
        public static Dictionary<string, string> Token = new Dictionary<string, string>();

        public static void LoadSettings(string clientName)
        {
            XML.Load("Clients/" + clientName + ".xml");

            Info["Name"] = Load("Info", "Name");
            Info["Authorize"] = Load("Info", "Authorize");
            Info["ClientID"] = Load("Info", "ClientID");
            Info["RedirectUri"] = Load("Info", "RedirectUri");
            Info["ResponseType"] = Load("Info", "ResponseType");
            Info["Scope"] = Load("Info", "Scope");
            Info["MaxReq"] = Load("Info", "MaxReq");

            Link["Like"] = Load("Link", "Like");
            Link["Follow"] = Load("Link", "Follow");
            Link["Comment"] = Load("Link", "Comment");
            Link["Feed"] = Load("Link", "Feed");

            Header["Host"] = Load("Header", "Host");
            Header["Accept"] = Load("Header", "Accept");
            Header["Accept-Language"] = Load("Header", "Accept-Language");
            Header["Accept-Encoding"] = Load("Header", "Accept-Encoding");
            Header["ContentType"] = Load("Header", "ContentType");
            Header["X-Requested-With"] = Load("Header", "X-Requested-With");
            Header["Pragma"] = Load("Header", "Pragma");
            Header["Cache-Control"] = Load("Header", "Cache-Control");

            reqData["Like"] = Load("reqData", "Like");
            reqData["Follow"] = Load("reqData", "Follow");
            reqData["Comment"] = Load("reqData", "Comment");

            responseData["Like"] = Load("responseData", "Like");
            responseData["Follow"] = Load("responseData", "Follow");
            responseData["Comment"] = Load("responseData", "Comment");
        }

        public static string Load(string Tab, string Name)
        {
            return XML.SelectSingleNode("Config/" + Tab + "/" + Name).InnerText;
        }
    }

    public static class Bot
    {
        #region Variables
        public static CookieContainer Cookies = new CookieContainer();
        public static Dictionary<string, string> RegexArray = new Dictionary<string, string>();

        public static ArrayList LikedIDs = new ArrayList();
        public static ArrayList FollowedIDs = new ArrayList();
        public static ArrayList CommentedIDs = new ArrayList();
        public static List<string> Tags = new List<string>();
        public static List<string> Comments = new List<string>();

        public static string CSRF = null;
        #endregion

        public static void MainFunction()
        {
            CSRF = GetCSRF(GetHTML());
            RegexArray["GetPhotoID"] = @"""id\"":\""[0-9]{19}\"",\""display_src";
            RegexArray["GetPhotoIDReplace1"] = @"""id"":""";
            RegexArray["GetPhotoIDReplace2"] = @""",""display_src";
            RegexArray["GetPhotoOwner"] = @"owner"":{""id"":""[0-9]{10}""},""comments";
            RegexArray["GetPhotoOwnerReplace1"] = @"owner"":{""id"":""";
            RegexArray["GetPhotoOwnerReplace2"] = @"""},""comments";
        }

        public static bool Login(string Username, string Password)
        {
            try
            {
                byte[] bytes = ASCIIEncoding.UTF8.GetBytes("username=" + Username + "&password=" + Password);
                HttpWebRequest postReq = (HttpWebRequest)WebRequest.Create("https://instagram.com/accounts/login/ajax/");
                WebHeaderCollection postHeaders = postReq.Headers;
                postReq.Method = "POST";
                postReq.Host = "instagram.com";
                postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
                postReq.Accept = "*/*";
                postHeaders.Add("Accept-Language", "it-IT,it;q=0.8,en-US;q=0.5,en;q=0.3");
                postHeaders.Add("Accept-Encoding", "gzip, deflate");
                postReq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                postHeaders.Add("X-Instagram-AJAX", "1");
                postHeaders.Add("X-CSRFToken", CSRF);
                postHeaders.Add("X-Requested-With", "XMLHttpRequest");
                postReq.Referer = "https://instagram.com/accounts/login/";
                postReq.ContentLength = bytes.Length;

                Cookies = new CookieContainer();
                Cookies.Add(new Cookie("csrftoken", CSRF) { Domain = postReq.Host });
                postReq.CookieContainer = Cookies;
                postReq.KeepAlive = true;
                postHeaders.Add("Pragma", "no-cache");
                postHeaders.Add("Cache-Control", "no-cache");
                Stream postStream = postReq.GetRequestStream();
                postStream.Write(bytes, 0, bytes.Length);
                postStream.Close();
                HttpWebResponse postResponse;
                postResponse = (HttpWebResponse)postReq.GetResponse();
                StreamReader reader = new StreamReader(postResponse.GetResponseStream());
                if (reader.ReadToEnd().Contains("true"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex) { return false; }
        }

        public static string Authorize()
        {
            try
            {
                string AuthURL = Client.Info["Authorize"].Replace("[ID]", Client.Info["ClientID"]).Replace("[RedirectUri]", Client.Info["RedirectUri"]).Replace("[ResponseType]", Client.Info["ResponseType"]).Replace("[Scope]", Client.Info["Scope"]);
                byte[] bytes = ASCIIEncoding.UTF8.GetBytes("csrfmiddlewaretoken=" + CSRF + "&allow=Authorize");
                HttpWebRequest postReq = (HttpWebRequest)WebRequest.Create(AuthURL);
                postReq.AutomaticDecompression = DecompressionMethods.GZip;
                WebHeaderCollection postHeaders = postReq.Headers;
                postReq.Method = "POST";
                postReq.Timeout = 20000;
                postReq.Host = "instagram.com";
                postReq.UserAgent = "Instagram 7.8 Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25";
                postReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                postHeaders.Add("Accept-Language", "it-IT,it;q=0.8,en-US;q=0.5,en;q=0.3");
                postHeaders.Add("Accept-Encoding", "gzip, deflate");
                postReq.ContentType = "application/x-www-form-urlencoded";
                postReq.Referer = AuthURL;
                postReq.ContentLength = bytes.Length;
                postReq.CookieContainer = Cookies;
                postReq.KeepAlive = true;
                Stream postStream = postReq.GetRequestStream();
                postStream.Write(bytes, 0, bytes.Length);
                postStream.Close();
                HttpWebResponse postResponse;
                postResponse = (HttpWebResponse)postReq.GetResponse();
                StreamReader reader = new StreamReader(postResponse.GetResponseStream());
                string Response = reader.ReadToEnd();
                return Response;
            }
            catch (Exception Ex) { return "Fail"; }
        }

        public static string LikePhoto(string MediaID, string UserID)
        {
            try
            {
                string Method = GetMethod(Client.reqData["Like"]);
                if (Method == "GET")
                {
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Client.Link["Like"].Replace("[GET]", "").Replace("[MediaID]", MediaID).Replace("[UserID]", UserID).Replace("[_UserID]", "_" + UserID));
                    myRequest.AutomaticDecompression = DecompressionMethods.GZip;
                    WebHeaderCollection getHeaders = myRequest.Headers;
                    myRequest.Method = "GET";
                    myRequest.Timeout = 10000;
                    myRequest.Host = Client.Header["Host"];
                    myRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
                    myRequest.Accept = Client.Header["Accept"];
                    getHeaders.Add("Accept-Language", Client.Header["Accept-Language"]);
                    getHeaders.Add("Accept-Encoding", Client.Header["Accept-Encoding"]);
                    getHeaders.Add("X-Requested-With", Client.Header["X-Requested-With"]);
                    getHeaders.Add("X-CSRF-Token", Bot.CSRF);
                    myRequest.Referer = Client.Link["Feed"];
                    myRequest.CookieContainer = Cookies;
                    myRequest.KeepAlive = true;

                    WebResponse myResponse = myRequest.GetResponse();
                    StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                    string Result = sr.ReadToEnd();
                    sr.Close();
                    myResponse.Close();
                    if (Result.Contains(Client.responseData["Like"]))
                        return "OK";
                    else if (Result.Contains(Client.Info["MaxReq"]))
                        return "Max";
                    else
                        return "Fail";
                }
                else if (Method == "POST")
                {
                    byte[] bytes = ASCIIEncoding.UTF8.GetBytes(Client.reqData["Like"].Replace("[POST]", "").Replace("[MediaID]", MediaID).Replace("[UserID]", UserID).Replace("[_UserID]", "_" + UserID).Replace("[Token]", Client.Token[Client.Info["Name"]]));
                    HttpWebRequest postReq = (HttpWebRequest)WebRequest.Create(Client.Link["Like"].Replace("[MediaID]", MediaID).Replace("[UserID]", UserID).Replace("[_UserID]", "_" + UserID).Replace("[Token]", Client.Token[Client.Info["Name"]]));
                    postReq.AutomaticDecompression = DecompressionMethods.GZip;
                    WebHeaderCollection postHeaders = postReq.Headers;
                    postReq.Method = "POST";
                    postReq.Timeout = 10000;
                    postReq.Host = Client.Header["Host"];
                    postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
                    postReq.Accept = Client.Header["Accept"];
                    postHeaders.Add("Accept-Language", Client.Header["Accept-Language"]);
                    postHeaders.Add("Accept-Encoding", Client.Header["Accept-Encoding"]);
                    postReq.ContentType = Client.Header["ContentType"];
                    postHeaders.Add("X-Requested-With", Client.Header["X-Requested-With"]);
                    postReq.Referer = Client.Link["Feed"];
                    postReq.ContentLength = bytes.Length;
                    postReq.CookieContainer = Cookies;
                    postReq.KeepAlive = true;
                    postHeaders.Add("Pragma", Client.Header["Pragma"]);
                    postHeaders.Add("Cache-Control", Client.Header["Cache-Control"]);
                    Stream postStream = postReq.GetRequestStream();
                    postStream.Write(bytes, 0, bytes.Length);
                    postStream.Close();
                    HttpWebResponse postResponse;
                    postResponse = (HttpWebResponse)postReq.GetResponse();
                    StreamReader reader = new StreamReader(postResponse.GetResponseStream());
                    string Result = reader.ReadToEnd();
                    if (Result.Contains(Client.responseData["Like"]))
                        return "OK";
                    else if (Result.Contains(Client.Info["MaxReq"]))
                        return "Max";
                    else
                        return "Fail";
                }
                return "Fail";
            }
            catch (Exception Ex) { return "Fail"; };
        }

        public static string FollowUser(string UserID)
        {
            try
            {
                string Method = GetMethod(Client.reqData["Follow"]);
                if (Method == "GET")
                {
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Client.Link["Follow"].Replace("[GET]", "").Replace("[UserID]", UserID));
                    myRequest.AutomaticDecompression = DecompressionMethods.GZip;
                    myRequest.Method = "GET";
                    myRequest.Timeout = 10000;
                    myRequest.CookieContainer = Cookies;
                    WebResponse myResponse = myRequest.GetResponse();
                    StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                    string Result = sr.ReadToEnd();
                    sr.Close();
                    myResponse.Close();
                    if (Result.Contains(Client.responseData["Follow"]))
                        return "OK";
                    else if (Result.Contains(Client.Info["MaxReq"]))
                        return "Max";
                    else
                        return "Fail";
                }
                else if (Method == "POST")
                {
                    byte[] bytes = ASCIIEncoding.UTF8.GetBytes(Client.reqData["Follow"].Replace("[POST]", "").Replace("[UserID]", UserID).Replace("[Token]", Client.Token[Client.Info["Name"]]));
                    HttpWebRequest postReq = (HttpWebRequest)WebRequest.Create(Client.Link["Follow"].Replace("[UserID]", UserID));
                    postReq.AutomaticDecompression = DecompressionMethods.GZip;
                    WebHeaderCollection postHeaders = postReq.Headers;
                    postReq.Method = "POST";
                    postReq.Timeout = 10000;
                    postReq.Host = Client.Header["Host"];
                    postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
                    postReq.Accept = Client.Header["Accept"];
                    postHeaders.Add("Accept-Language", Client.Header["Accept-Language"]);
                    postHeaders.Add("Accept-Encoding", Client.Header["Accept-Encoding"]);
                    postReq.ContentType = Client.Header["ContentType"];
                    postHeaders.Add("X-Requested-With", Client.Header["X-Requested-With"]);
                    postReq.Referer = Client.Link["Feed"];
                    postReq.ContentLength = bytes.Length;
                    postReq.CookieContainer = Cookies;
                    postReq.KeepAlive = true;
                    postHeaders.Add("Pragma", Client.Header["Pragma"]);
                    postHeaders.Add("Cache-Control", Client.Header["Cache-Control"]);
                    Stream postStream = postReq.GetRequestStream();
                    postStream.Write(bytes, 0, bytes.Length);
                    postStream.Close();
                    HttpWebResponse postResponse;
                    postResponse = (HttpWebResponse)postReq.GetResponse();
                    StreamReader reader = new StreamReader(postResponse.GetResponseStream());
                    string Result = reader.ReadToEnd();
                    if (Result.Contains(Client.responseData["Follow"]))
                        return "OK";
                    else if (Result.Contains(Client.Info["MaxReq"]))
                        return "Max";
                    else
                        return "Fail";
                }
                return "Fail";
            }
            catch (Exception Ex) { return "Fail"; };
        }

        public static string CommentPhoto(string MediaID, string UserID, string Data)
        {
            try
            {
                if (Client.reqData["Comment"] == "NO_COMMENT")
                    return "NoSupport";
                string Method = GetMethod(Client.reqData["Comment"]);
                if (Method == "GET")
                {
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Client.Link["Comment"].Replace("[Data]", Data).Replace("[MediaID]", MediaID).Replace("[UserID]", UserID).Replace("[_UserID]", "_" + UserID).Replace("[Token]", Client.Token[Client.Info["Name"]]));
                    myRequest.AutomaticDecompression = DecompressionMethods.GZip;
                    myRequest.Method = "GET";
                    myRequest.Timeout = 10000;
                    myRequest.CookieContainer = Cookies;
                    WebResponse myResponse = myRequest.GetResponse();
                    StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                    string Result = sr.ReadToEnd();
                    sr.Close();
                    myResponse.Close();
                    if (Result.Contains(Client.responseData["Comment"]))
                        return "OK";
                    else if (Result.Contains(Client.Info["MaxReq"]))
                        return "Max";
                    else
                        return "Fail";
                }
                else if (Method == "POST")
                {
                    byte[] bytes = ASCIIEncoding.UTF8.GetBytes(Client.reqData["Comment"].Replace("[POST]", null).Replace("[Data]", Data).Replace("[MediaID]", MediaID).Replace("[UserID]", UserID).Replace("[_UserID]", "_" + UserID));
                    HttpWebRequest postReq = (HttpWebRequest)WebRequest.Create(Client.Link["Comment"].Replace("[MediaID]", MediaID).Replace("[Data]", Data).Replace("[UserID]", UserID).Replace("[_UserID]", "_" + UserID));
                    postReq.AutomaticDecompression = DecompressionMethods.GZip;
                    WebHeaderCollection postHeaders = postReq.Headers;
                    postReq.Method = "POST";
                    postReq.Timeout = 10000;
                    postReq.Host = Client.Header["Host"];
                    postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
                    postReq.Accept = Client.Header["Accept"];
                    postHeaders.Add("Accept-Language", Client.Header["Accept-Language"]);
                    postHeaders.Add("Accept-Encoding", Client.Header["Accept-Encoding"]);
                    postReq.ContentType = Client.Header["ContentType"];
                    postHeaders.Add("X-Requested-With", Client.Header["X-Requested-With"]);
                    postReq.Referer = Client.Link["Feed"];
                    postReq.ContentLength = bytes.Length;
                    postReq.CookieContainer = Cookies;
                    postReq.KeepAlive = false;
                    postHeaders.Add("Pragma", Client.Header["Pragma"]);
                    postHeaders.Add("Cache-Control", Client.Header["Cache-Control"]);
                    Stream postStream = postReq.GetRequestStream();
                    postStream.Write(bytes, 0, bytes.Length);
                    HttpWebResponse postResponse;
                    postResponse = (HttpWebResponse)postReq.GetResponse();
                    StreamReader reader = new StreamReader(postResponse.GetResponseStream());
                    string Result = reader.ReadToEnd();
                    if (Result.Contains(Client.responseData["Comment"]))
                        return "OK";
                    else if (Result.Contains(Client.Info["MaxReq"]))
                        return "Max";
                    else if (Client.responseData["Comment"] == "[NUMBER]"){
                        int n;
                        bool isNumeric = int.TryParse("123", out n);
                        if (isNumeric)
                            return "OK";
                    }
                    else
                        return "Fail";
                }
                return "Fail";
            }
            catch { return "Fail"; }
        }

        public static string[] GetPhotoIDs(string HTML)
        {
            List<string> IDs = new List<string>();
            HTML.Replace(@"\", string.Empty);
            string Reg = RegexArray["GetPhotoID"];
            Regex regex = new Regex(Reg);
            foreach (Match Match in regex.Matches(HTML))
            {
                IDs.Add(Match.ToString().Replace(RegexArray["GetPhotoIDReplace1"], "").Replace(RegexArray["GetPhotoIDReplace2"], ""));
            }
            return IDs.ToArray();
        }

        public static string[] GetPhotoOwners(string HTML)
        {
            List<string> Owners = new List<string>();
            Regex regex = new Regex(RegexArray["GetPhotoOwner"]);
            foreach (Match Match in regex.Matches(HTML))
            {
                Owners.Add(Match.ToString().Replace(RegexArray["GetPhotoOwnerReplace1"], "").Replace(RegexArray["GetPhotoOwnerReplace2"], ""));
            }
            return Owners.ToArray();
        }

        public static string GetCSRF(string HTML)
        {
            Regex Regex = new Regex(@"csrf_token"":""(.*)""},""");
            return Regex.Match(HTML).Groups[1].ToString();
        }

        public static string GetToken(string HTML)
        {
            Regex Regex = new Regex(@"[0-9]{10,12}.[a-z0-9]{7}.[a-z0-9]{32}");
            return Regex.Match(HTML).Groups[0].ToString();
        }

        public static string GetMethod(string data)
        {
            string Method = null;
            if (data.Contains("[GET]"))
                Method = "GET";
            else if (data.Contains("[POST]"))
                Method = "POST";
            return Method;
        }


        public static string GetHTML(string url = "https://instagram.com/")
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            WebHeaderCollection getHeaders = myRequest.Headers;
            myRequest.Method = "GET";
            myRequest.CookieContainer = Cookies;
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();
            return result;
        }
    }
}