

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
        modalAddCalendar.parent = this
    }

    _initHtmlIds() {
        this.$btnNewCalendar = $('#btnNewCalendar')
        
    }

    _initConstants() {
        this.API_GET_LIST_CALENDARS = SetUrlForQuery("/CalendarioAcademico/ListCalendarios")
        this.TABLE = 'datatable_calendario'
    }

    _initEventBindings() {
    }


    async _init() {
        this.tablaCalendario = $(`#${this.TABLE}`).DataTable();
        await this.listCalendarios();
    }

    async getCalendars()
    {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: this.API_GET_LIST_CALENDARS,
                type: 'GET',
                dataType: "json",
                success: function (data) {
                    resolve(data)
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    reject(new Error(`${errorThrown} - ${this.API_GET_LIST_CALENDARS}`))
                }
            })
        })
    }

    async cargarTabla(calendarios)
    {           
        for (var i = 0; i < calendarios.length; i++) {           
            this.tablaCalendario.row.add([
                item.descripcion,
                item.periodo.descripcion,
                item.tipodeIdentificacion,
                item.fechaInicio,
                item.fechaFinal,
                item.semestre,
                item.academicYear,
            ]).draw(false)
        }        
    }

    async listCalendarios()
    {
        const result = await this.getCalendars()
        if (!result.is_Error) {
            this.cargarTabla(result.objeto)
        }

    }
  
}


class ModalAddCalendario {
    constructor() {
        this._initConstants()
        this._initHtmlIds()
        this.clickSaveCalendarHandler = this.clickSaveCalendarHandler.bind(this)
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

    _initStyles()
    {
        $('.form-control-uniform').uniform();
    }

    _init() {
        this.__initStyles();
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
                    reject(new Error(`${errorThrown} - ${this.API_POST_CALENDARIO}`))
                }
            })
        })
       
    }

    async clickSaveCalendarHandler() {
        const result = await this.postSaveCalendario()
        if (!result.isError) {
            swal.fire({
                title: "¡Success!",
                text: result.msj,
                confirmButtonClass: "btn btn-success",
                type: "success"
            });
            await this.parent.listCalendarios();
        }
        else {
            swal.fire({
                title: "¡Error!",
                text: result.msj,
                confirmButtonClass: "btn-primary",
                type: "Error"
            });
        }
    }
}

