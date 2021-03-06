﻿using System;

namespace SafeTyPay.Models
{
    [Newtonsoft.Json.JsonObject(Title = "ExpressTokenRequest")]
    public class ExpressTokenRequest
    {
        //String (Required, lenght = 32) Merchant Api Key generated by using the MMS
        public string ApiKey { get; set; } //bc8882c4f6540769b33f809bcb98a839

        //String (Required, ISO 8601: yyyy-MM-ddThh:mm:ss) Merchant Date and Time used to compose signature
        public string RequestDateTime { get; set; }  //2007-01-31T14:24:59

        //String (Required, ISO-4217) Currency of the transaction
        public string CurrencyCode { get; set; } //USD, EUR, MXN, etc.

        //Decimal (Required) The amount of the transaction.Use 2 decimals.
        public decimal Amount { get; set; } //100.00

        //String (Required, max-lenght = 20) Reference number of the sale.This value is used to notify Merchants about a payment.
        public string MerchantSalesID { get; set; } //ORD-10001,RXW-P03-V01,001-012312220, etc

        //String (Required, ISO 639-1 Example: EN, ES, PT, DE, etc.) Specifies the language for the Express Application
        public string Language { get; set; }  //EN, ES, PT, DE, etc.

        //Only for PSPs: Field used to send Submerchant ID (Optional)
        public string TrackingCode { get; set; } //TX-0001 Merchant - 01

        //Integer (Required, min = 11)  Time in minutes to expire the token.Value given in minutes.
        //Minimum Suggested: Online: 30 minutes Cash: 2 hours  For Brazil:Online: 2 hours Cash 24 hrs
        public int ExpirationTime { get; set; }//90, 60, 1440, 30, etc

        //String (Optional)  Allows filtering channels(Online/Cash), countries, banks and currency.
        //public string FilterBy { get; set; } //CHANNEL(OL) CHANNEL(WP) COUNTRY(PER) BANK(1001,1005) CURRENCY(PEN, USD)

        //String(Required) URL where shopper will be redirected from the online banking if payment was successful(Must be Https)
        public string TransactionOkURL { get; set; } //https://www.website.com/thanks

        //String(Required) URL where shopper will be redirected from the online banking if payment was wrong.(Must be Https)
        public string TransactionErrorURL { get; set; } //https://flippingbook.com/404

        //String Only for PSPs
        public string CustomMerchantName { get; set; } //Avianca Taca, Adidas, etc

        //String (Optional) Contains the shopper's email
        public string ShopperEmail { get; set; }//example@safetypay.com

        //Integer SafetyPay product identifier
        public int ProductID { get; set; } //1: SafetyPay Online Payment Button
                                           //2: SafetyPay Cash Payment Button
                                           //8: SafetyPay Dual Button(Online & Cash channels in one button)

        //String(Optional) Contains the shopper's email
        public string ShopperInformation_email { get; set; } // example@safetypay.com

        //String (Optional) Contains the shopper's first name
        public string ShopperInformation_first_name { get; set; } //Pedro

        //String (Optional) Contains the shopper's last name
        public string ShopperInformation_last_name { get; set; } //Curich

        //String(Optional) contains the shopper's country code 
        public string ShopperInformation_country_code { get; set; } //+51

        //String(Optional)Contains the shopper's mobile numbe
        public string ShopperInformation_mobile { get; set; } //987654321

        //String (Optional) Format of response, DEFAULT CSV
        public string ResponseFormat { get; set; } //CSV, XML

        //String(Required) Refer to https://developers.safetypay.com/docs/express-signature-calculator
        public string Signature { get; set; } //HASH SHA256 of:
                                              //RequestDateTime
                                              //+CurrencyCode
                                              //+Amount
                                              //+MerchantSalesID
                                              //+Language
                                              //+TrackingCode
                                              //+ExpirationTime
                                              //+TransacionOkURL
                                              //+TransactionErrorURL
                                              //+SignatureKey
                                              //[JsonIgnore]
                                              //public Dictionary<string, object> ToParameter(string signatureKey)
                                              //{
                                              //    return new Dictionary<string, object>
                                              //    {
                                              //        ["ApiKey"] = ApiKey,
                                              //        ["RequestDateTime"] = RequestDateTime,
                                              //        ["CurrencyCode"] = CurrencyCode,
                                              //        ["Amount"] = Amount,
                                              //        ["MerchantSalesID"] = MerchantSalesID,
                                              //        ["Language"] = Language,
                                              //        ["TrackingCode"] = TrackingCode,
                                              //        ["ExpirationTime"] = ExpirationTime,
                                              //        ["TransactionOkURL"] = TransactionOkURL,
                                              //        ["TransactionErrorURL"] = TransactionErrorURL,
                                              //        ["CustomMerchantName"] = CustomMerchantName,
                                              //        ["ShopperEmail"] = ShopperEmail,
                                              //        ["ProductID"] = ProductID,
                                              //        ["ShopperInformation_email"] = ShopperInformation_email,
                                              //        ["ShopperInformation_first_name"] = ShopperInformation_first_name,
                                              //        ["ShopperInformation_last_name"] = ShopperInformation_last_name,
                                              //        ["ShopperInformation_country_code"] = ShopperInformation_country_code,
                                              //        ["ShopperInformation_mobile"] = ShopperInformation_mobile,
                                              //        ["ResponseFormat"] = ResponseFormat,
                                              //        ["Signature"] = ComputeSha256Hash(signatureKey)
                                              //    };
                                              //}
                                              //[JsonIgnore] 
                                              //private string ComputeSha256Hash(string signatureKey)
                                              //{
                                              //    var rawData = RequestDateTime
                                              //                    + CurrencyCode
                                              //                    + Amount
                                              //                    + MerchantSalesID
                                              //                    + Language
                                              //                    + TrackingCode
                                              //                    + ExpirationTime
                                              //                    + TransactionOkURL 
                                              //                    + TransactionErrorURL
                                              //                    + signatureKey;
                                              //    // Create a SHA256   
                                              //    using (var sha256Hash = SHA256.Create())
                                              //    {
                                              //        // ComputeHash - returns byte array  
                                              //        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

        //        // Convert byte array to a string   
        //        var builder = new StringBuilder();
        //        for (var i = 0; i < bytes.Length; i++)
        //        {
        //            builder.Append(bytes[i].ToString("x2"));
        //        }
        //        return builder.ToString();
        //    }
        //}
    }
}
