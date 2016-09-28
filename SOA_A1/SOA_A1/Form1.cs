using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SOA_A1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            string postUrl = "http://www.dataaccess.com/webservicesserver/numberconversion.wso";
            string webRequestText = @"<?xml version=""1.0"" encoding=""UTF-8""?><soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tns=""http://www.dataaccess.com/webservicesserver/"" xmlns:xs=""http://www.w3.org/2001/XMLSchema""><soap:Body><tns:NumberToWords><tns:ubiNum>" + argumentBox.Text + "</tns:ubiNum></tns:NumberToWords></soap:Body></soap:Envelope>";
            string responseFromServer = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
            request.Headers.Add("SOAPAction", "\" " + postUrl + "\"");
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";

            Stream stm = request.GetRequestStream();

            //write the data to the stream acquired from request
            using (StreamWriter stmw = new StreamWriter(stm))
            {
                stmw.Write(webRequestText);
            }

            //get the response from the web service
            WebResponse response = request.GetResponse();

            stm.Close();

            stm = response.GetResponseStream();

            //parse out any information in the services response
            using (StreamReader stmr = new StreamReader(stm))
            {
                ReturnLabel.Text = "";
                while (stmr.EndOfStream == false)
                {
                    responseFromServer = stmr.ReadLine();
                    ReturnLabel.Text += responseFromServer + "\n";
                }
            }
        }
    }
}
