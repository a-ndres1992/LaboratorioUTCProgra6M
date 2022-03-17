"use strict";
var ProveedorEdit;
(function (ProveedorEdit) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("AppEdit");
})(ProveedorEdit || (ProveedorEdit = {}));
//# sourceMappingURL=Edit.js.map