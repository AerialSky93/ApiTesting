using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Web.Api.Models
{
    public class PageModel
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public string Term { get; set; }
        public string ColumnSort { get; set; }

        public PageModel()
        {
            this.Page = 0;
            this.Limit = 0;
        }

        public object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, this.GetType());
        }
    }
}
