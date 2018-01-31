using fiap_azure_appService.DataObjects;
using fiap_azure_appService.Models;
using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

namespace fiap_azure_appService.Controllers
{
    public class AtividadeController : TableController<Atividade>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var context = new fiap_azure_appContext();
            DomainManager = new EntityDomainManager<Atividade>(context, Request);
        }

        // GET tables/Atividades
        public IQueryable<Atividade> GetAllAtividade()
        {
            return Query();
        }

        // GET tables/Atividades/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Atividade> GetAtividade(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Atividades/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Atividade> PatchAtividade(string id, Delta<Atividade> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Atividades
        public async Task<IHttpActionResult> PostAtividade(Atividade item)
        {
            Atividade current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Atividades/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAtividade(string id)
        {
            return DeleteAsync(id);
        }
    }
}