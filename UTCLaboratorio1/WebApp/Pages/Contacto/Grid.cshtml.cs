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
    public class GridModel : PageModel
    {
        private readonly IContactoService contactoService;

        public GridModel(IContactoService contactoService)
        {
            this.contactoService = contactoService;
        }

        public IEnumerable<ContactoEntity> GridList { get; set; } = new List<ContactoEntity>();


        public async Task<IActionResult> OnGet()
        {

            try
            {

                GridList = await contactoService.Get();

                //RETURN PAGE ES COMO PARA DEVOLERSE A LA MISMA PAGINA QUE SE ESTABA
                return Page();

            }
            catch (Exception Ex)
            {

                return Content(Ex.Message);
            }

        }

        public async Task<JsonResult> OnDeleteEliminar(int id)
        {

            try
            {

                var result = await contactoService.Delete(new()
                {
                    IdContacto = id
                }
                );

                //REDIRECT EES PARA CUANDO NECESITAMOS DEVOLVERNOS A OTRA PAGINA QUE NO ES EN LA QUE ESTAMOS Y DEBEMOS PASARLA POR PARAMETRO LA URL 
                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity {CodeError=ex.HResult,MsgError=ex.Message });
            }

        }



    }
}
