

$(document).ready(function () {
    window.InferfazPreinscripcion = new InferfazPreinscripcion()
})




class InferfazPreinscripcion {
    constructor() {
        this._initConstants()
        this._initHtmlIds()
        this._initEventBindings();
        this._init()
    }

    _initHtmlIds() {
        this.$inputTipoDocumento = $('#txtTipoIdentificacion')
        this.$inputNroDocumento = $('#txtNroDocumento')
        this.$inputEmail = $('#Email')
        this.$inputTelefono = $('#Telefono')
        this.$inputNombres = $('#txtNombres')
        this.$inputApellidos = $('#txtApellidos')
        this.$btnGenerarRecibo = $('#btnGenerarRecibo')
    }

    _initConstants() {
        this.API_GET_LISTADO_PREINSCRIPTOS = '/Preinscripcion/GetPreinscriptos'
        this.TABLE = 'table_preinscripcion'
    }

    _initEventBindings() {
        this.$btnGenerarRecibo.on('click', this.clickHandlerGuardarPreinscritos)
    }


    _init() {


    }

    getListadoPreinscritos() {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: this.API_GET_LISTADO_PREINSCRIPTOS,
                type: 'GET',
                dataType: "json",
                success: function (data) {
                    resolve(data)
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    reject(new Error(`${errorThrown} - ${this.API_GET_LISTADO_PREINSCRIPTOS}`))
                }
            })
        })
    }

   

}