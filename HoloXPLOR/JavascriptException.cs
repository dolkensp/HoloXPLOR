using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoloXPLOR
{
    public class JavascriptException : Exception
    {
        public JavascriptException() : base() { }
        public JavascriptException(String message) : base(message) { }

        public override System.Collections.IDictionary Data
        {
            get
            {
                return new Dictionary<String, dynamic>
                {
                    { "Message", this.Message },
                    { "Name", this.Name },
                    { "Stack", this.Stack },
                    { "Args", this.Args },
                    { "Url", this.Url },
                };
            }
        }

        public String Stack { get; set; }
        public String Name { get; set; }
        public dynamic Args { get; set; }
        public String Url { get; set; }

        public override String ToString()
        {
            return String.Format("Url: {1}\r\n\r\n{0}\r\n\r\nName: {2}\r\nStack Trace: {3}\r\n\r\nArgs: {4}", this.Message, this.Url, this.Name, this.Stack, this.Args);
        }
    }
}