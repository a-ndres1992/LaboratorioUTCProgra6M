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
    public class GridModel : PageModel
    {
        private readonly IProveedorService proveedorService;

        public GridModel(IProveedorService proveedorService)
        {
            this.proveedorService = proveedorService;
        }

        public IEnumerable<ProveedorEntity> GridList { get; set; } = new List<ProveedorEntity>();

        //VARIABLE PARA RETORNAR UN MENSAJE DE ERROR O CONFIRMACIN POR EJEMPLO AL ELIMINAR UN CAMPO
        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {

            try
            {

                GridList = await proveedorService.Get();

                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }

                TempData.Clear();

                //RETURN PAGE ES COMO PARA DEVOLERSE A LA MISMA PAGINA QUE SE ESTABA
                return Page();

            }
            catch (Exception Ex)
            {

                return Content(Ex.Message);
            }

        }


        public async Task<IActionResult> OnGetEliminar(int id)
        {

            try
            {

                var result = await proveedorService.Delete(new()
                {
                    IdProveedor = id
                }
                );


                if (result.CodeError!=0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData["Msg"] = "El Registro de elimino correctamente";

                //REDIRECT EES PARA CUANDO NECESITAMOS DEVOLVERNOS A OTRA PAGINA QUE NO ES EN LA QUE ESTAMOS Y DEBEMOS PASARLA POR PARAMETRO LA URL 
                return Redirect("Grid");

            }
            catch (Exception Ex)
            {

                return Content(Ex.Message);
            }

        }
    }
}
