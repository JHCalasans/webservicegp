using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servicosrestful.Models
{
    interface IItemRepositorio
    {

        IEnumerable<Item> GetAll();
        Item Get(int id);
        Item Add(Item item);
        void AddRange(List<Item> itens);
        void Remove(int id);
        bool Update(Item item);
    }
}
