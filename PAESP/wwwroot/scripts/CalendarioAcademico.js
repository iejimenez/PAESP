

$(document).ready(function () {
    window.InterfazCalendarios = new InterfazCalendarios()
    window.InterfazCalendarios.cargarTabla()
})




class InterfazCalendarios {
    constructor() {
        this._initConstants()
        this._initHtmlIds()
        this._initEventBindings();
        this._init()
    }

    _initHtmlIds() {
        
    }

    _initConstants() {
       
        this.TABLE = 'datatable_calendario'
    }

    _initEventBindings() {
       
    }


    _init() {
        this.tablaCalendario = $(`#${this.TABLE}`).DataTable();

    }

   

}