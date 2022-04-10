"use strict";
var ContactoGrid;
(function (ContactoGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("Desea Eliminar el registro seleccionado?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando");
                App.AxiosProvider.ContactoEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "El Registro se elimino correctamente", icon: "success" }).then(function () {
                            return window.location.reload();
                        });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    ContactoGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(ContactoGrid || (ContactoGrid = {}));
//# sourceMappingURL=Grid.js.map