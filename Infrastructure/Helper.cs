using SafeTyPay.Models;
using System.Security.Cryptography;
using System.Text;

namespace SafeTyPay.Infrastructure
{
    public static class Helper
    {
        public static string ComputeSha256Hash(ExpressTokenRequest token, string signatureKey)
        {
            var rawData = token.RequestDateTime
                            + token.CurrencyCode
                            + token.Amount
                            + token.MerchantSalesID
                            + token.Language
                            + token.TrackingCode
                            + token.ExpirationTime
                            + token.TransactionOkURL
                            + token.TransactionErrorURL
                            + signatureKey;
            // Create a SHA256   
            using (var sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                var builder = new StringBuilder();
                for (var i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
