using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.JsonHelper 
{
    public class JsonHandler
    {
        public static JsonMessage CreateMessage(int type, string message, string value)
        {
            JsonMessage json = new JsonMessage()
            {
                type = type,
                message = message,
                value = value
            };
            return json;
        }
        public static JsonMessage CreateMessage(int type, string message)
        {
            JsonMessage json = new JsonMessage()
            {
                type = type,
                message = message,
               
            };
            return json;
        }
 
        public class JsonMessage
        {
            public int type { get; set; }
            public string message { get; set; }
            public string value { get; set; }
        }
       
    }
}
