using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldAPI.Parameters
{
    public class NewsParameter
    {
        public string? title {get; set;}
        public string? content {get; set;}
        public DateTime? UpdateTime {get; set;}
    }
}