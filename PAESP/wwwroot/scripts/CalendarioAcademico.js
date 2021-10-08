

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

    _initConstants()
    {
        this.API_POST_CALENDARIO = SetUrlForQuery("/CalendarioAcademico/SaveCalendario")
        this.MODAL = 'modalAddCalendar'
        this.FORM_CALENDARIO = 'form_add_calendar'
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

    postSaveCalendario() {
        let params = $(`#${this.FORM_CALENDARIO}`).serialize()

        return new Promise((resolve, reject) => {
            $.ajax({
                url: this.API_POST_CALENDARIO,
                content: "application/json; charset=utf-8",
                type: 'POST',
                dataType: "json",
                data: params,
                success: function (data) {
                    resolve(data)
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    reject(new Error(`${errorThrown} - ${this.API_POST_GUARDAR_PREINSCRIPTOS}`))
                }
            })
        })
    }
}

