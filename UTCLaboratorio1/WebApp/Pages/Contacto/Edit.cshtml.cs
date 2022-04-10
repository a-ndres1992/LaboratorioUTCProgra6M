using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.Contacto
{
    public class EditModel : PageModel
    {
        private readonly IContactoService contactoService;
        private readonly IProveedorService proveedorService;

        public EditModel(IContactoService contactoService, IProveedorService proveedorService)
        {
            this.contactoService = contactoService;
            this.proveedorService = proveedorService;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public ContactoEntity Entity { get; set; } = new ContactoEntity();

        public IEnumerable<ProveedorEntity> ProveedorLista { get; set; } = new List<ProveedorEntity>();

        public async Task<IActionResult> OnGet()
        { 
            try
            {
                if (id.HasValue)
                {
                    Entity = await contactoService.GetById(new()
                    {
                        IdContacto = id
                    });
                }
                ProveedorLista = await proveedorService.GetLista();// LO ULTIMO
                return Page();

            }
            catch (Exception Ex)
            {

                return Content(Ex.Message);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();
                
                if (Entity.IdContacto.HasValue)
                {
                    result = await contactoService.Update(Entity);
                    
                }
                else
                {
                    //Metedo de insercion 
                    result = await contactoService.Create(Entity);
                     
                }
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });

            }
        }

    }
}
