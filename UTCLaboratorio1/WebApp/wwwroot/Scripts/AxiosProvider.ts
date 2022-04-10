
namespace App.AxiosProvider   {

    export const ContactoEliminar = (id) => axios.delete<DBEntity>("Contacto/Grid?handler=Eliminar&id="+ id).then(({ data }) => data);


}




