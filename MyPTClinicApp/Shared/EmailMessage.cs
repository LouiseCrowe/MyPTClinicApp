using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPTClinicApp.Shared
{
    public class EmailMessage
    {
        public string SenderAddress { get; set; }
        public string RecipientAddress { get; set; }
        public string SenderName { get; set; }
        public string RecipientName { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
