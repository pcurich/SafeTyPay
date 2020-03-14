using Newtonsoft.Json;
using SafeTyPay.Infrastructure;
using SafeTyPay.Models;
using System;
using System.IO;
using System.Net;

namespace SafeTyPay
{
    public class SafeTyPayPaymentProcessor
    {
        private string CreateQueryParameters()
        { 

            var token = new ExpressTokenRequest();
            token.ApiKey = "bc8882c4f6540769b33f809bcb98a839";
            token.RequestDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:ss");
            token.CurrencyCode = "PEN";
            token.Amount = decimal.Round(12.00M, 2, MidpointRounding.AwayFromZero);
            token.MerchantSalesID = "1";
            token.Language = "ES";
            token.TrackingCode = "22";
            token.ExpirationTime = 1440;
            token.TransactionOkURL = "https://www.website.com/thanks";
            token.TransactionErrorURL = "https://flippingbook.com/404";
            token.CustomMerchantName = "My Store";
            token.ShopperEmail = "CURICHPEDRO@GMAIL.COM";
            token.ProductID = 8;
            //token.FilterBy = "";
            token.ShopperInformation_email = "CURICHPEDRO@GMAIL.COM";
            token.ShopperInformation_first_name = "Pedro";
            token.ShopperInformation_last_name = "Curich";
            token.ShopperInformation_country_code = "+51";//_genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.PhoneAttribute);
            token.ShopperInformation_mobile = "973905013";//_genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.PhoneAttribute);
            token.ResponseFormat = "XML";
            token.Signature = Helper.ComputeSha256Hash(token, "eb4d9032a344ad1b0b8099e484b8519c");

            var root = new
            {
                ExpressTokenRequest = token
            };
            return JsonConvert.SerializeObject(token);
        }

        public void PostProcessPayment()
        {
            try
            { 
                var baseUrl = "https://sandbox-mws2.safetypay.com/express/ws/v.3.0/Post/CreateExpressToken";//safeTyPayPaymentSettings.UseSandbox ?
                                                                                                            //safeTyPayPaymentSettings.TestUrl :
                                                                                                            //safeTyPayPaymentSettings.ProdctionUrl;

                //create common query parameters for the request
                var json = CreateQueryParameters();

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl);
                //httpWebRequest.ContentType = "application/json; charset=utf-8";
                 
                httpWebRequest.Headers.Clear();
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    Console.WriteLine(responseText);

                    //Now you have your response.
                    //or false depending on information in the response     
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
