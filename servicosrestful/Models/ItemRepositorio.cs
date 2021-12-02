using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace servicosrestful.Models
{
    public class ItemRepositorio : IItemRepositorio
    {

        private List<Item> itens = new List<Item>();
        private int _nextId = 1;


        public ItemRepositorio()
        {
            Add(new Item { Nome = "Refrigerante"});
            Add(new Item { Nome = "Pão"});
        }

        public Item Add(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            itens.Add(item);
            return item;
        }

        public Item Get(int id)
        {
            return itens.Find(p => p.Id == id);
        }

        public IEnumerable<Item> GetAll()
        {
            return itens;
        }

        public void Remove(int id)
        {
            itens.RemoveAll(p => p.Id == id);
        }

        public bool Update(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = itens.FindIndex(p => p.Id == item.Id);

            if (index == -1)
            {
                return false;
            }
            itens.RemoveAt(index);
            itens.Add(item);
            return true;
        }
    }
}