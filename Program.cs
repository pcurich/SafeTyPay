using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeTyPay
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new SafeTyPayPaymentProcessor();
            test.PostProcessPayment();
        }
    }
}
