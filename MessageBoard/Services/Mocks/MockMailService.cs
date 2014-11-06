using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBoard.Services;

namespace MessageBoard.Tests.Mocks
{
    public class MockMailService : IMailService
    {
        public bool SendMail(string @from, string to, string subject, string message)
        {
            Debug.WriteLine(String.Concat("SendMail: ", subject));
            
            return true;
        }
    }
}
