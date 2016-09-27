/*******************************
Programmed by       : Connor McQuade and Dallas Thibodeau
Programmed For      : Ed Barsalou
Date                : Oct/5/2015
********************************/


using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Web.Services.Protocols;
using System.Xml;
namespace SOAAssign2
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //button click that happens after the user click the submit button
        //it takes the action selected in the list above the button and uses that to determine which service to call
        //it also uses the text in the text box beside it to take in as a parameter for the service call
        protected void Button1_Click(object sender, EventArgs e)
        {
            string postUrl = "";
            string DataToSend = "";
            bool required = false;
            try
            {
                if (Operation.SelectedValue == "NTW")
                {
                    required = true;
                    postUrl = "http://www.dataaccess.com/webservicesserver/numberconversion.wso";
                    DataToSend = @"<?xml version=""1.0"" encoding=""UTF-8""?><soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tns=""http://www.dataaccess.com/webservicesserver/"" xmlns:xs=""http://www.w3.org/2001/XMLSchema""><soap:Body><tns:NumberToWords><tns:ubiNum>" + argument.Text + "</tns:ubiNum></tns:NumberToWords></soap:Body></soap:Envelope>";
                }
                else if (Operation.SelectedValue == "NTD")
                {
                    required = true;
                    postUrl = "http://www.dataaccess.com/webservicesserver/numberconversion.wso";
                    DataToSend = @"<?xml version=""1.0"" encoding=""UTF-8""?><soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tns=""http://www.dataaccess.com/webservicesserver/"" xmlns:xs=""http://www.w3.org/2001/XMLSchema""><soap:Body><tns:NumberToDollars><tns:dNum>" + argument.Text + "</tns:dNum></tns:NumberToDollars></soap:Body></soap:Envelope>";
                }
                else if (Operation.SelectedValue == "FIFA")
                {
                    postUrl = "http://footballpool.dataaccess.eu/data/info.wso";
                    DataToSend = @"<?xml version=""1.0"" encoding=""UTF-8""?><soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tns=""http://footballpool.dataaccess.eu"" xmlns:xs=""http://www.w3.org/2001/XMLSchema""><soap:Body><tns:AllPlayerNames><tns:bSelected>" + argument.Text + "</tns:bSelected></tns:AllPlayerNames></soap:Body></soap:Envelope>";
                }
                else if (Operation.SelectedValue == "TOPGOAL")
                {
                    if (Convert.ToInt32(argument.Text) < 0)
                    {
                        Exception ex = new Exception("Number cannot be negative.");
                        throw ex;
                    }
                    postUrl = "http://footballpool.dataaccess.eu/data/info.wso";
                    DataToSend = @"<?xml version=""1.0"" encoding=""UTF-8""?><soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tns=""http://footballpool.dataaccess.eu"" xmlns:xs=""http://www.w3.org/2001/XMLSchema""><soap:Body><tns:TopSelectedGoalScorers><tns:iTopN>" + argument.Text + "</tns:iTopN></tns:TopSelectedGoalScorers></soap:Body></soap:Envelope>";
                }
                else if (Operation.SelectedValue == "STADIUMS")
                {
                    postUrl = "http://footballpool.dataaccess.eu/data/info.wso";
                    DataToSend = @"<?xml version=""1.0"" encoding=""UTF-8""?><soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tns=""http://footballpool.dataaccess.eu"" xmlns:xs=""http://www.w3.org/2001/XMLSchema""><soap:Body><tns:StadiumNames>" + argument.Text + "</tns:StadiumNames></soap:Body></soap:Envelope>";
                }
                else if (Operation.SelectedValue == "STADINFO")
                {
                    required = true;
                    postUrl = "http://footballpool.dataaccess.eu/data/info.wso";
                    DataToSend = @"<?xml version=""1.0"" encoding=""UTF-8""?><soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tns=""http://footballpool.dataaccess.eu"" xmlns:xs=""http://www.w3.org/2001/XMLSchema""><soap:Body><tns:StadiumInfo><tns:sStadiumName>" + argument.Text + "</tns:sStadiumName></tns:StadiumInfo></soap:Body></soap:Envelope>";
                }
                else if (Operation.SelectedValue == "TEAMS")
                {
                    postUrl = "http://footballpool.dataaccess.eu/data/info.wso";
                    DataToSend = @"<?xml version=""1.0"" encoding=""UTF-8""?><soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tns=""http://footballpool.dataaccess.eu"" xmlns:xs=""http://www.w3.org/2001/XMLSchema""><soap:Body><tns:Teams>" + argument.Text + "</tns:Teams></soap:Body></soap:Envelope>";
                }
                else if (Operation.SelectedValue == "COUNTRY")
                {
                    postUrl = "http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso";
                    DataToSend = @"<?xml version=""1.0"" encoding=""UTF-8""?> <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""><soap:Body><ListOfCountryNamesByName xmlns=""http://www.oorsprong.org/websamples.countryinfo""></ListOfCountryNamesByName></soap:Body></soap:Envelope>";
                }
                else if (Operation.SelectedValue == "CAPITAL")
                {
                    required = true;
                    if(Regex.IsMatch(argument.Text, @"\d"))
                    {
                        Exception ex = new Exception("Argument cannot contain a number.");
                        throw ex;
                    }
                    else if (argument.Text.Length > 2)
                    {
                        Exception ex = new Exception("Country code cannot be longer than 2.");
                        throw ex;
                    }
                    postUrl = "http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso";
                    DataToSend = @"<?xml version=""1.0"" encoding=""UTF-8""?> <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""><soap:Body><CapitalCity xmlns=""http://www.oorsprong.org/websamples.countryinfo""><sCountryISOCode>" + argument.Text + "</sCountryISOCode></CapitalCity></soap:Body></soap:Envelope>";
                }
                else if (Operation.SelectedValue == "CURRENCY")
                {
                    postUrl = "http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso";
                    DataToSend = @"<?xml version=""1.0"" encoding=""UTF-8""?> <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""><soap:Body><ListOfCurrenciesByCode xmlns=""http://www.oorsprong.org/websamples.countryinfo""></ListOfCurrenciesByCode></soap:Body></soap:Envelope>";
                }
                else if (Operation.SelectedValue == "ISO")
                {
                    required = true;
                    postUrl = "http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso";
                    DataToSend = @"<?xml version=""1.0"" encoding=""UTF-8""?> <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""><soap:Body><CountryISOCode xmlns=""http://www.oorsprong.org/websamples.countryinfo""><sCountryName>" + argument.Text + "</sCountryName></CountryISOCode></soap:Body></soap:Envelope>";
                }
                else if (Operation.SelectedValue == "CASE")
                {
                    if (Regex.IsMatch(argument.Text, @"\d"))
                    {
                        Exception ex = new Exception("Argument cannot contain a number.");
                        throw ex;
                    }
                    required = true;
                    postUrl = "http://www.dataaccess.com/webservicesserver/textcasing.wso";
                    DataToSend = @"<?xml version=""1.0"" encoding=""utf-8""?> <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""><soap:Body><InvertStringCase xmlns=""http://www.dataaccess.com/webservicesserver/""><sAString>" + argument.Text + "</sAString></InvertStringCase></soap:Body></soap:Envelope>";
                }
                else if (Operation.SelectedValue == "CASEPREV")
                {
                    if (Regex.IsMatch(argument.Text, @"\d"))
                    {
                        Exception ex = new Exception("Argument cannot contain a number.");
                        throw ex;
                    }
                    required = true;
                    postUrl = "http://www.dataaccess.com/webservicesserver/textcasing.wso";
                    DataToSend = @"<?xml version=""1.0"" encoding=""utf-8""?> <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""><soap:Body><InvertCaseFirstAdjustStringToCurrent  xmlns=""http://www.dataaccess.com/webservicesserver/""><sAString>" + argument.Text + "</sAString></InvertCaseFirstAdjustStringToCurrent></soap:Body></soap:Envelope>";
                }

                //make the actual post to the service and pull the result out of the response back from the service
                if (postUrl != "")
                {
                    if (!required || argument.Text != "")
                    {
                    
                            string responseFromServer = "";
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
                            request.Headers.Add("SOAPAction", "\" " + postUrl + "\"");
                            request.ContentType = "text/xml;charset=\"utf-8\"";
                            request.Accept = "text/xml";
                            request.Method = "POST";

                            Stream stm = request.GetRequestStream();

                            //write the data to the stream aquired from request
                            using (StreamWriter stmw = new StreamWriter(stm))
                            {
                                stmw.Write(DataToSend);
                            }

                            //get the response from the web service
                            WebResponse response;
                            response = request.GetResponse();
                        
                            stm.Close();

                            stm = response.GetResponseStream();

                            //parse out any information in the services response
                            using (StreamReader stmr = new StreamReader(stm))
                            {
                                Label1.Text = "";
                                while (stmr.EndOfStream == false)
                                {
                                    responseFromServer = stmr.ReadLine();
                                    //clean up the text for the football based calls so they are not cluttered with a bunch of file links
                                    if (!responseFromServer.Contains("footballpool"))
                                    {
                                        Label1.Text += responseFromServer + "<br/>";
                                    }
                                }
                            }
                        }
                        else
                        {
                            Label1.Text = ("This service requires an argument.");
                        }
                    }
            }
            //happens if a soap based exception occurs : displays the code name and what the message was
            catch (SoapException er)
            {
                Label1.Text = ("SOAP Exception Error Code: " + er.SubCode.Code.Name);
                Label1.Text = ("SOAP Exception Message is: " + er.Message);
            }
            //happens if any other general expection occurs : displays just what the message was
            catch (Exception ex)
            {
                Label1.Text = ("Exception Message: " + ex.Message);

            }
            argument.Text = "";
        }
    }
}