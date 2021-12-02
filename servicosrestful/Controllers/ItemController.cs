using servicosrestful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace servicosrestful.Controllers
{
    public class ItemController : ApiController
    {
        static readonly IItemRepositorio repositorio = new ItemRepositorio();

        public IEnumerable<Item> GetAllItems()
        {
            return repositorio.GetAll();
        }

        public Item GetItem(int id)
        {
            Item item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }


        public HttpResponseMessage PostItem(Item item)
        {
           
                item = repositorio.Add(item);
            var response = Request.CreateResponse<Item>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }


        [HttpPost]
        [ActionName("Update")]
        public void Update(int id, String nome)
        {
            Item item = new Item() { Id = id, Nome = nome };
            if (!repositorio.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteItem(int id)
        {
            Item item = repositorio.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repositorio.Remove(id);
        }

    }
}
