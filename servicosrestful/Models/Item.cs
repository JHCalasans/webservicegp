using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace servicosrestful.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Quantidade { get; set; }
    }
}