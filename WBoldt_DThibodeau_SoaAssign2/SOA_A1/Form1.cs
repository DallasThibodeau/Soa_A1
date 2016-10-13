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
using System.Xml;
using System.Text.RegularExpressions;

namespace SOA_A1
{
    public partial class Form1 : Form
    {
        private MultipleWebServices AvailibleWebServices;
        private string MyErrorMessage = "";
        private bool InvalidParameterWasEntered = false;

        //Form1()
        //
        //Initialization function.
        //Initializes a nummber of UI and backend features such as the method and service lists.
        public Form1()
        {
            InitializeComponent();

            AvailibleWebServices = GetWebServices();

            // check if there was an error
            if (MyErrorMessage != "")
            {
                DisplayErrorMessage(MyErrorMessage);
            }
            else
            {
                //we have the services, so populate the 'Services' drop down                
                foreach (var service in AvailibleWebServices.WebServicesList)
                {
                    ddlWebService.Items.Add(service.WebServiceName);
                }

                //set the default for the selected web service
                if (ddlWebService.Items.Count > 0)
                {
                    ddlWebService.SelectedIndex = 0;
                }

            }

        }

        private void DisplayErrorMessage(string message)
        {
            if (message.Length > MyConstants.MaxErrorMessageCharacters)
            {
                message = message.Substring(0, MyConstants.MaxErrorMessageCharacters);
            }

            MessageBox.Show(message, "An Error Has Occurred");
        }



        //GetWebServices()
        //
        //Initialization function.
        //Reads the config file and returns a class containing relevant information on
        //the webservices and methods documented in the config file.
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


        //btnSendRequest_Click()
        //
        //Event driven function driven by the send request button.
        //Builds and sends a webrequest to a selected web service, 
        //then receives, parses and displays a web response.

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            if (InvalidParameterWasEntered)
            {
                InvalidParameterWasEntered = false;
                //and skip execution of method
            }
            else
            {
                string postUrl = AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServicePostUrl;
                string baseUrl = AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceBaseUrl;
                string webMethodUrl = AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceMethods[ddlWebMethod.SelectedIndex].MethodUrl;
                string methodName = AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceMethods[ddlWebMethod.SelectedIndex].MethodName;
                bool methodReturnsDataSet = AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceMethods[ddlWebMethod.SelectedIndex].ReturnsDataSet;
                string responseFromServer = "";
                bool argsOkay = true;

                bool useTns = false;
                string tnsString = "";

                if (AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].UseTns)
                {
                    useTns = true;

                    //the method uses tns so we will need to append the text "tns:" to some of the tags
                    tnsString = "tns:";
                }

                //create the beginning of the web request text
                string webRequestText = @"<?xml version='1.0' encoding='UTF-8'?><soap:Envelope xmlns:soap='" + MyConstants.SoapEnvelopeUrl;

                if (useTns)
                {
                    webRequestText += "' xmlns:tns='" + webMethodUrl;
                }

                webRequestText += "' xmlns:xsi='" + MyConstants.XmlSchemaInstanceUrl +
                    "' xmlns:xsd='" + MyConstants.XmlSchemaUrl +
                    "'><soap:Body><" + tnsString + methodName + " xmlns='" + baseUrl + "'>";

                // check if the method we're calling has parameters
                if (AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceMethods[ddlWebMethod.SelectedIndex].ParameterInfo != null && AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceMethods[ddlWebMethod.SelectedIndex].ParameterInfo.ToString() != "")
                {
                    //add parameters to the web request text
                    foreach (var parameter in AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceMethods[ddlWebMethod.SelectedIndex].ParameterInfo)
                    {
                        if (AvailibleWebServices.WebServicesList[ddlWebService.SelectedIndex].WebServiceMethods[ddlWebMethod.SelectedIndex].ParameterInfo[0].Required == true && (parameter.ParamValue == "" || parameter.ParamValue == null))
                        {
                            argsOkay = false;
                            break;
                        }
                        webRequestText += "<" + tnsString + parameter.ParamName +
                        ">" + parameter.ParamValue +
                        "</" + tnsString + parameter.ParamName +
                        ">";
                    }
                }

                if (argsOkay == true)
                {
                    //finish the web request text
                    webRequestText += "</" + tnsString + methodName + "></soap:Body></soap:Envelope>";


                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
                    request.Headers.Add("SOAPAction", webMethodUrl);
                    request.ContentType = "text/xml;charset=\"utf-8\"";
                    request.Accept = "text/xml";
                    request.Method = "POST";


                    try
                    {
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
                            txtRequestResponse.Text = "";
                            StringBuilder sb = new StringBuilder();

                            while (stmr.EndOfStream == false)
                            {
                                responseFromServer = stmr.ReadLine();
                                sb.Append(responseFromServer);
                                sb.Append(MyConstants.NewLine);
                            }

                            txtRequestResponse.Text = sb.ToString();
                            DataSet set = new DataSet();

                            if (methodReturnsDataSet)
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(sb.ToString());
                                StringReader sr = new StringReader(WebUtility.HtmlDecode(doc.InnerXml));
                                set.ReadXml(sr);
                                XMLGridView.DataSource = set.Tables[set.Tables.Count - 1];
                            }
                            else
                            {
                                StringReader sr = new StringReader(sb.ToString());
                                set.ReadXml(sr);
                                XMLGridView.DataSource = set.Tables[set.Tables.Count - 1];
                            }

                        }
                    }
                    catch (WebException ex)
                    {
                        txtRequestResponse.Text = "Unableto connect to webservice. Remote name could not be resolved.";
                    }
                }
                else
                {
                    txtRequestResponse.Text = "Required arguments not filled.";
                }

            }

        }

        //ddlWebService_SelectedIndexChanged
        //
        //Populates the datagridview used for user input for arguments.
        //Automatically populates said datagridview with relevent data
        //whenever the webservice is changed.

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

                if (ddlWebMethod.Items.Count > 0)
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


        //ddlWebMethod_SelectedIndexChanged
        //
        //Populates the datagridview used for user input for arguments.
        //Automatically populates said datagridview with relevent data
        //whenever the webmethod is changed.
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
                            dgvParameters.Rows.Add(new string[] { parameter.ParamName, parameter.ParamValue, parameter.DataType, parameter.Required.ToString() });
                        }
                    }
                }
            }
            catch
            {
                MyErrorMessage = "No Parameters Found";
            }

        }


        //dgvParameters_CellValueChanged
        //
        //Event driven function that retreives and assigns argument values after
        //they are changed.


        private void dgvParameters_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            int webServiceIndex = ddlWebService.SelectedIndex;
            int methodIndex = ddlWebMethod.SelectedIndex;

            if (columnIndex >= 0 && rowIndex >= 0)
            {
                if (dgvParameters.Rows[rowIndex].Cells[columnIndex].Value != null)
                {
                    string newParameterValue = dgvParameters.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                    string parameterName = AvailibleWebServices.WebServicesList[webServiceIndex].WebServiceMethods[methodIndex].ParameterInfo[rowIndex].ParamName;
                    string regexStr = AvailibleWebServices.WebServicesList[webServiceIndex].WebServiceMethods[methodIndex].ParameterInfo[rowIndex].RegularExp;

                    Regex r = new Regex(regexStr);

                    if (r.IsMatch(newParameterValue))
                    {
                        //the value is OK; save it
                        AvailibleWebServices.WebServicesList[webServiceIndex].WebServiceMethods[methodIndex].ParameterInfo[rowIndex].ParamValue = newParameterValue;
                        InvalidParameterWasEntered = false;
                    }
                    else
                    {
                        //new value did not meet the requirements
                        string errorMessage = "The new value for '" + parameterName +
                            "' did not meet the Regular Expression: \n\r\n\r'" + regexStr + "'";

                        DisplayErrorMessage(errorMessage);

                        AvailibleWebServices.WebServicesList[webServiceIndex].WebServiceMethods[methodIndex].ParameterInfo[rowIndex].ParamValue = "";
                        InvalidParameterWasEntered = true;
                    }

                }
                else
                {
                    AvailibleWebServices.WebServicesList[webServiceIndex].WebServiceMethods[methodIndex].ParameterInfo[rowIndex].ParamValue = "";
                }

            }

        }

    }

}