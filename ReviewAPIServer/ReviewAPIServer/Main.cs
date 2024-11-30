using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.IO;

namespace ReviewAPIServer
{
    public partial class Main : Form
    {
        private HttpListener httpListener = null;
        private DBManager dbMng = new DBManager();

        public Main()
        {
            InitializeComponent();

            if (httpListener == null)
            {
                httpListener = new HttpListener();
                httpListener.Prefixes.Clear();
                httpListener.Prefixes.Add(string.Format("http://+:8686/"));

                ServerStart();
            }
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            if (httpListener == null)
            {
                httpListener = new HttpListener();
                httpListener.Prefixes.Clear();
                httpListener.Prefixes.Add(string.Format("http://+:8686/"));

                ServerStart();
            }
        }

        private void ServerStart()
        {
            if (!httpListener.IsListening)
            {
                httpListener.Start();
                textBox_log.Text = "Server is started";

                Task.Factory.StartNew(() =>
                {
                    while (httpListener != null)
                    {
                        HttpListenerContext context = httpListener.GetContext();

                        string rawurl = context.Request.RawUrl;
                        string httpmethod = context.Request.HttpMethod;

                        string result = "";

                        result += string.Format("httpmethod = {0}\r\n", httpmethod);
                        result += string.Format("rawurl = {0}\r\n", rawurl);

                        ClassificateRequest(context, httpmethod, rawurl);

                        //if (context.Request.HttpMethod == HttpMethod.Post.Method)
                        //{
                        //    // body 데이터를 json 으로 받아서 Parsing 
                        //    using (var reader = new StreamReader(context.Request.InputStream,
                        //             context.Request.ContentEncoding))
                        //    {
                        //        result += reader.ReadToEnd();
                        //    }
                        //    // The action is a post 
                        //}
                        //else if (context.Request.HttpMethod == HttpMethod.Put.Method)
                        //{
                        //    // The action is a put
                        //}
                        //else if (context.Request.HttpMethod == HttpMethod.Delete.Method)
                        //{
                        //    // The action is a DELETE
                        //}
                        //else if (context.Request.HttpMethod == HttpMethod.Get.Method)
                        //{
                        //    // The action is a Get
                        //}

                        if (textBox_log.InvokeRequired)
                            textBox_log.Invoke(new MethodInvoker(delegate { textBox_log.Text = result; }));
                        else
                            textBox_log.Text = result;

                        context.Response.Close();
                    }
                });

            }
        }

        private void ClassificateRequest(HttpListenerContext context, string method, string rawurl)
        {
            string[] prams = rawurl.Split('/').Skip(1).ToArray();

            switch (prams[0])
            {
                case "user":
                    if (method == HttpMethod.Get.Method)
                    {
                        string json = dbMng.ExecuteSelectCommand(QueryMethods.SelectUser(prams[1], prams[2]));
                        byte[] data = Encoding.UTF8.GetBytes(json);

                        context.Response.OutputStream.Write(data, 0, data.Length);
                        context.Response.StatusCode = 200;
                    }
                    break;
                case "store":
                    if (method == HttpMethod.Get.Method)
                    {
                        string json = dbMng.ExecuteSelectCommand(QueryMethods.SelectStoreByCategoryNo(prams[1]));
                        byte[] data = Encoding.UTF8.GetBytes(json);

                        context.Response.OutputStream.Write(data, 0, data.Length);
                        context.Response.StatusCode = 200;
                    }
                    break;
                case "review":
                    if (method == HttpMethod.Get.Method)
                    {
                        string json = dbMng.ExecuteSelectCommand(QueryMethods.Select(prams[0], "storeno", prams[1]));
                        byte[] data = Encoding.UTF8.GetBytes(json);

                        context.Response.OutputStream.Write(data, 0, data.Length);
                        context.Response.StatusCode = 200;
                    }
                    if (method == HttpMethod.Post.Method)
                    {
                        dbMng.ExecuteCommand(QueryMethods.InsertReview(prams[1], prams[2], prams[3], prams[4]));
                    }
                    break;
                case "bookmark":
                    if (method == HttpMethod.Get.Method)
                    {
                        string json = dbMng.ExecuteSelectCommand(QueryMethods.SelectBookmarkByUserNo(prams[1]));
                        byte[] data = Encoding.UTF8.GetBytes(json);

                        context.Response.OutputStream.Write(data, 0, data.Length);
                        context.Response.StatusCode = 200;
                    }
                    if (method == HttpMethod.Post.Method)
                    {
                        dbMng.ExecuteCommand(QueryMethods.InsertBookmark(prams[0], prams[1]));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
