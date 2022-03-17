using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Proveedor
{
    public class EditModel : PageModel
    {
        private readonly IProveedorService proveedor;

        public EditModel(IProveedorService proveedor)
        {
            this.proveedor = proveedor;

        }
        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public ProveedorEntity Entity { get; set; } = new ProveedorEntity();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await proveedor.GetById(new()
                    {
                        IdProveedor = id
                    });
                }
                return Page();

            }
            catch (Exception Ex)
            {

                return Content(Ex.Message);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                //Metodo de actualizacion
                if (Entity.IdProveedor.HasValue)
                {
                    var result = await proveedor.Update(Entity);
                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se actualizo correctamente";

                }
                else
                {
                    //Metedo de insercion 
                    var result = await proveedor.Create(Entity);
                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se agrego correctamente";

                }
                return RedirectToPage("Grid");
            }
            catch (Exception Ex)
            {

                return Content(Ex.Message);
            }
        }

    }
}
