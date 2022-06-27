using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlParseApp.Models
{
    public class UrlPage
    {
        public string UrlValue { get; set; }
        public int CountTagA { get; set; }
        private string colorRecord;
        public string ColorRecord
        {
            get 
            {
                if (colorRecord == "Green")
                {
                    return "Green";
                }
                else return "White";
            }  
            set { colorRecord = value; }
        }
    }
}
