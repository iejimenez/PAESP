


$(document).ready(function () {
    window.InferfazPreinscripcion = new InferfazPreinscripcion()
})




class InferfazPreinscripcion {
    constructor() {

        this.clickHandlerGuardarPreinscritos = this.clickHandlerGuardarPreinscritos.bind(this)
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
        this.API_POST_GUARDAR_PREINSCRIPTOS = '/Preinscripcion/InsertarPreinscripcion'
        this.FORM_PREINSCRIPCION = 'form_preinscripcion'
    }

    _initEventBindings() {
        this.$btnGenerarRecibo.on('click', this.clickHandlerGuardarPreinscritos)
    }


    _init() {
       

    }
 
    postSavePreinscripto()
    {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: this.API_POST_GUARDAR_PREINSCRIPTOS,
                content: "application/json; charset=utf-8",
                type: 'POST',
                dataType: "json",
                success: function (data) {
                    resolve(data)
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    reject(new Error(`${errorThrown} - ${this.API_POST_GUARDAR_PREINSCRIPTOS}`))
                }
            })
        })
    }

    async clickHandlerGuardarPreinscritos()
    {
        await this.postSavePreinscripto()
    }

}
