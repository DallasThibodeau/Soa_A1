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
using System.Web.Script.Serialization;

namespace SOA_A1
{
    public partial class Form1 : Form
    {
        private MultipleWebServices AvailibleWebServices;
        private string MyErrorMessage = "";

        public Form1()
        {
            InitializeComponent();

            AvailibleWebServices = GetWebServices();
            
            // check if there was an error
            if(MyErrorMessage != "")
            {
                DispalyErrorMessage(MyErrorMessage);
            }
            else
            {
                //we have the services, so populate the 'Services' drop down                
                foreach(var service in AvailibleWebServices.WebServicesList)
                {
                    ddlWebService.Items.Add(service.WebServiceName);
                }
            }
            
        }


        private void DispalyErrorMessage(string message)
        {
            MessageBox.Show(message);
        }


        private MultipleWebServices GetWebServices()
        {
            string myConfigFileData = "";
            MyErrorMessage = ""; // reset error message
            MultipleWebServices theServices = new MultipleWebServices();

            // read config file
            try
            {
                myConfigFileData = System.IO.File.ReadAllText(MyConstants.ConfigFileRelativePath);
            }
            catch (Exception ex)
            {
                MyErrorMessage = "There was a problem reading the config file. Exception message: " + ex.Message;
            }

            //parse config file into an object
            try
            {
                theServices = new JavaScriptSerializer().Deserialize<MultipleWebServices>(myConfigFileData);

                //check if we actually have some objects
                if (MyErrorMessage == "" && (theServices == null || theServices.WebServicesList == null || theServices.WebServicesList.Count <= 0))
                {
                    MyErrorMessage = "No objects/services were read from the config file.";
                }
            }
            catch (Exception ex)
            {
                MyErrorMessage = "There was a problem de-serializing the JSON object in the config file. Exception message: " + ex.Message;
            }

            
            return theServices;
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


        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            string postUrl = AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServicePostUrl;
            string responseFromServer = "";
            string webRequestText = @"<?xml version=""1.0"" encoding=""UTF-8""?><soap:Envelope xmlns:soap='" + MyConstants.SoapEnvelopeUrl +
                "' xmlns:tns='" + AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceTnsUrl +
                "' xmlns:xs='" + MyConstants.XmlSchemaUrl + "'><soap:Body><tns:" + AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceMethods[ddlWebMethod.SelectedIndex].MethodName +
                "><tns:ubiNum>" + argumentBox.Text + "</tns:ubiNum></tns:" + AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceMethods[ddlWebMethod.SelectedIndex].MethodName +
                "></soap:Body></soap:Envelope>";
            //NumberToWords

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


        private void ddlWebService_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ddlWebService.SelectedIndex;

            ddlWebMethod.Items.Clear();

            try
            {
                //need to populate the 'methods' drop down
                foreach (var method in AvailibleWebServices.WebServicesList[index].WebServiceMethods)
                {
                    ddlWebMethod.Items.Add(method.MethodDisplayName);
                }
            }
            catch
            {
                ddlWebMethod.Items.Add("No Methods Found");
            }

        }
    }
}
