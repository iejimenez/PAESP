

$(document).ready(function () {
    window.InferfazPreinscripcion = new InferfazPreinscripcion()
    window.InferfazPreinscripcion.cargarTabla()
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
        //this.API_GET_LISTADO_PREINSCRIPTOS = '/Preinscripcion/GetPreinscriptos'
        this.API_GET_LISTADO_PREINSCRIPTOS = SetUrlForQuery('/Preinscripcion/ListPreinscritos')
        this.TABLE = 'table_preinscripcion'
    }

    _initEventBindings() {
        this.$btnGenerarRecibo.on('click', this.clickHandlerGuardarPreinscritos)
    }


    _init() {
        this.tablaPreinscritos = $(`#${this.TABLE}`).DataTable();

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

    async cargarTabla()
    {
        let listPreinscritos = await this.getListadoPreinscritos();

        for (var i = 0; i < listPreinscritos.length; i++) {
            const item = listPreinscritos[i];
            this.tablaPreinscritos.row.add([
                item.nombres,
                item.apeliidos,
                item.tipodeIdentificacion,
                item.cedula,
                '',
                item.ciudad,
                '',
                '',
                ''
            ]).draw(false)
        }
    }

}