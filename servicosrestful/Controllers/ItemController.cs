using Newtonsoft.Json;
using servicosrestful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace servicosrestful.Controllers
{
    [RoutePrefix("api/item")]
    public class ItemController : ApiController
    {
        static readonly IItemRepositorio repositorio = new ItemRepositorio();

        [Route("obterTodos")]
        [HttpGet]
        public IEnumerable<Item> ObterTodos()
        {
            return repositorio.GetAll();
        }

        [Route("obter/{id:int}")]
        [HttpGet]
        public Item ObterTodos(int id)
        {
            Item item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        [HttpPost]
        [ActionName("adicionar")]
        public HttpResponseMessage Adicionar(Item item)
        {
           
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Item>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        [HttpPost]
        [ActionName("adicionarLista")]
        public IEnumerable<Item> AdicionarLista(HttpRequestMessage request)
        {
            var re = request.Content.ReadAsStringAsync().Result;

            if(re != null)
            {
                List<Item> lista =JsonConvert.DeserializeObject<List<Item>>(re);
                repositorio.AddRange(lista);
                return repositorio.GetAll();
            }
            return null;


        }




        [HttpPut]
        [ActionName("atualizar")]
        public void Atualizar(Item item)
        {
            //Item item = new Item() { Id = id, Nome = nome };
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
