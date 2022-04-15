"use strict";
var App;
(function (App) {
    var AxiosProvider;
    (function (AxiosProvider) {
        AxiosProvider.ContactoEliminar = function (id) { return axios.delete("Contacto/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ContactoGuardar = function (entity) { return axios.post("Contacto/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
    })(AxiosProvider = App.AxiosProvider || (App.AxiosProvider = {}));
})(App || (App = {}));
//# sourceMappingURL=AxiosProvider.js.map