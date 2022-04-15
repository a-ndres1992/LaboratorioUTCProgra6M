
namespace App.AxiosProvider   {

    export const ContactoEliminar = (id) => axios.delete<DBEntity>("Contacto/Grid?handler=Eliminar&id="+ id).then(({ data }) => data);
    export const ContactoGuardar = (entity) => axios.post<DBEntity>("Contacto/Edit" , entity).then(({ data }) => data);


}




 