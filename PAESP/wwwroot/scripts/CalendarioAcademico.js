

$(document).ready(function () {
    window.InterfazCalendarios = new InterfazCalendarios()
   /* window.InterfazCalendarios.cargarTabla()*/
})



let modalAddCalendar = {}
class InterfazCalendarios {
    constructor() {
        this._initConstants()
        this._initHtmlIds()
        this._initEventBindings();
        this._init()

        modalAddCalendar = new ModalAddCalendario();
    }

    _initHtmlIds() {
        this.$btnNewCalendar = $('#btnNewCalendar')
        
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


class ModalAddCalendario {
    constructor() {
        this._initConstants()
        this._initHtmlIds()
        this._initEventBindings();
        this._init()
    }

    _initHtmlIds() {
        this.$btnGuardarCalendario = $('#btnSaveCalendar')
        this.$inputFechaInicio = ("#txtFechaInicio")
        this.$inputFechaFin = ("#txtFechaFin")
  
    }

    _initConstants() {

        this.MODAL = 'modalAddCalendar'
    }

    _initEventBindings() {
    }


    async _initDatePickers() {
        this.$inputFechaInicio.pickadate(seleccionFecha);
        this.$inputFechaFin.pickadate(seleccionFecha);
      
    }

    _init() {
       
        this._initDatePickers()
    }
    
}

