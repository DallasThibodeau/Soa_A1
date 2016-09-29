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
            MultipleWebServices webServices = new MultipleWebServices();

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
                webServices = new JavaScriptSerializer().Deserialize<MultipleWebServices>(myConfigFileData);

                //check if we actually have some objects
                if (MyErrorMessage == "" && (webServices == null || webServices.WebServicesList == null || webServices.WebServicesList.Count <= 0))
                {
                    MyErrorMessage = "No objects/services were read from the config file.";
                }
            }
            catch (Exception ex)
            {
                MyErrorMessage = "There was a problem de-serializing the JSON object in the config file. Exception message: " + ex.Message;
            }
                        
            return webServices;
        }

        //private void GoButton_Click(object sender, EventArgs e)
        //{
        //    string postUrl = "http://www.dataaccess.com/webservicesserver/numberconversion.wso";
        //    string webRequestText = @"<?xml version=""1.0"" encoding=""UTF-8""?><soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tns=""http://www.dataaccess.com/webservicesserver/"" xmlns:xs=""http://www.w3.org/2001/XMLSchema""><soap:Body><tns:NumberToWords><tns:ubiNum>" + argumentBox.Text + "</tns:ubiNum></tns:NumberToWords></soap:Body></soap:Envelope>";
        //    string responseFromServer = "";

        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
        //    request.Headers.Add("SOAPAction", "\" " + postUrl + "\"");
        //    request.ContentType = "text/xml;charset=\"utf-8\"";
        //    request.Accept = "text/xml";
        //    request.Method = "POST";

        //    Stream stm = request.GetRequestStream();

        //    //write the data to the stream acquired from request
        //    using (StreamWriter stmw = new StreamWriter(stm))
        //    {
        //        stmw.Write(webRequestText);
        //    }

        //    //get the response from the web service
        //    WebResponse response = request.GetResponse();

        //    stm.Close();

        //    stm = response.GetResponseStream();

        //    //parse out any information in the services response
        //    using (StreamReader stmr = new StreamReader(stm))
        //    {
        //        ReturnLabel.Text = "";
        //        while (stmr.EndOfStream == false)
        //        {
        //            responseFromServer = stmr.ReadLine();
        //            ReturnLabel.Text += responseFromServer + "\n";
        //        }
        //    }
        //}


        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            string postUrl = AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServicePostUrl;
            string webServiceTnsUrl = AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceTnsUrl;
            string methodName = AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceMethods[ddlWebMethod.SelectedIndex].MethodName;
            
            string responseFromServer = "";
            
            //create the beginning of the web request text
            string webRequestText = @"<?xml version=""1.0"" encoding=""UTF-8""?><soap:Envelope xmlns:soap='" + MyConstants.SoapEnvelopeUrl +
                "' xmlns:tns='" + webServiceTnsUrl +
                "' xmlns:xs='" + MyConstants.XmlSchemaUrl + "'><soap:Body><tns:" + methodName + ">";

            if (AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceMethods[ddlWebMethod.SelectedIndex].ParameterInfo != null)
            {
                //add parameters to the web request text
                foreach (var parameter in AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceMethods[ddlWebMethod.SelectedIndex].ParameterInfo)
                {
                    webRequestText += "<tns:" + parameter.ParamName +
                    ">" + parameter.ParamValue +
                    "</tns:" + parameter.ParamName +
                    ">";
                }
            }

            //finish the web request text
            webRequestText += "</tns:" + methodName + "></soap:Body></soap:Envelope>";
            

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

            dgvParameters.Rows.Clear();
            ddlWebMethod.Items.Clear();

            try
            {
                //need to populate the 'methods' drop down
                foreach (var method in AvailibleWebServices.WebServicesList[index].WebServiceMethods)
                {
                    ddlWebMethod.Items.Add(method.MethodDisplayName);
                }

                if(ddlWebMethod.Items.Count > 0)
                {
                    //make the first method the default
                    ddlWebMethod.SelectedIndex = 0;
                }
            }
            catch
            {
                ddlWebMethod.Items.Add("No Methods Found");
            }

        }


        private void ddlWebMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            int webServiceIndex = ddlWebService.SelectedIndex;
            int methodIndex = ddlWebMethod.SelectedIndex;
            MyErrorMessage = "";

            dgvParameters.Rows.Clear();

            try
            {
                if (AvailibleWebServices.WebServicesList[webServiceIndex].WebServiceMethods[methodIndex].ParameterInfo == null ||
                    AvailibleWebServices.WebServicesList[webServiceIndex].WebServiceMethods[methodIndex].ParameterInfo.Count <= 0)
                {
                    //method has no parameters
                }
                else
                {
                    //need to create a row for each parameter
                    foreach (var parameter in AvailibleWebServices.WebServicesList[webServiceIndex].WebServiceMethods[methodIndex].ParameterInfo)
                    {
                        if (parameter.ParamName != "")
                        {
                            dgvParameters.Rows.Add(new string[] { parameter.ParamName, parameter.ParamValue });
                        }
                    }
                }
            }
            catch
            {
                MyErrorMessage = "No Parameters Found";
            }

        }


        private void dgvParameters_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            int webServiceIndex = ddlWebService.SelectedIndex;
            int methodIndex = ddlWebMethod.SelectedIndex;

            if (columnIndex >= 0 && rowIndex >= 0)
            {
                var newValue = dgvParameters.Rows[rowIndex].Cells[columnIndex].Value.ToString();

                AvailibleWebServices.WebServicesList[webServiceIndex].WebServiceMethods[methodIndex].ParameterInfo[rowIndex].ParamValue = newValue;
            }
            
        }

    }

}
