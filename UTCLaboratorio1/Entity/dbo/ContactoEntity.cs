using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class ContactoEntity : DBEntity
    {
        public ContactoEntity()
        {
            Proveedor = Proveedor ?? new ProveedorEntity();
        }

        public int? IdContacto{ get; set; }
        public int? IdProveedor { get; set; }
        public virtual ProveedorEntity Proveedor { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        

    }
}
