

$(document).ready(function () {
    window.InferfazPreinscripcion = new InferfazPreinscripcion()
    window.InferfazPreinscripcion.cargarTablaPendientes()
})




class InferfazPreinscripcion {
    constructor() {

        this._initConstants()
        this._initHtmlIds()
        this.cargarTablaPendientes = this.cargarTablaPendientes.bind(this)
        this.cargarTablaPagos = this.cargarTablaPagos.bind(this)
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
        this.$tabPendiente = $('#tab_pendiente')
        this.$tabPagos = $('#tab_pagos')
    }

    _initConstants() {
        //this.API_GET_LISTADO_PREINSCRIPTOS = '/Preinscripcion/GetPreinscriptos'
        this.API_GET_LISTADO_PREINSCRIPTOS_PENDIENTES = SetUrlForQuery('/Preinscripcion/ListPreinscritosPendientes')
        this.API_GET_LISTADO_PREINSCRIPTOS_PAGOS = SetUrlForQuery('/Preinscripcion/ListPreinscritosPagos')
        this.TABLE = 'table_preinscripcion'
    }

    _initEventBindings() {
        this.$btnGenerarRecibo.on('click', this.clickHandlerGuardarPreinscritos)
        this.$tabPendiente.on('click', this.cargarTablaPendientes )
        this.$tabPagos.on('click', this.cargarTablaPagos)
    }


    _init() {
        this.tablaPreinscritos = $(`#${this.TABLE}`).DataTable();

    }

    getListadoPreinscritosPend() {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: this.API_GET_LISTADO_PREINSCRIPTOS_PENDIENTES,
                type: 'GET',
                dataType: "json",
                success: function (data) {
                    resolve(data)
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    reject(new Error(`${errorThrown} - ${this.API_GET_LISTADO_PREINSCRIPTOS_PENDIENTES}`))
                }
            })
        })
    }

    getListadoPreinscritosPagos() {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: this.API_GET_LISTADO_PREINSCRIPTOS_PAGOS,
                type: 'GET',
                dataType: "json",
                success: function (data) {
                    resolve(data)
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    reject(new Error(`${errorThrown} - ${this.API_GET_LISTADO_PREINSCRIPTOS_PAGOS}`))
                }
            })
        })
    }

    async cargarTablaPendientes()
    {
       const result = await this.getListadoPreinscritosPend();
       let listPreinscritos = []
       if (!result.is_Error) {
            listPreinscritos = result.objeto
            for (var i = 0; i < listPreinscritos.length; i++) {
                const item = listPreinscritos[i];
                this.tablaPreinscritos.row.add([
                    item.nombres,
                    item.apeliidos,
                    item.tipodeIdentificacion,
                    item.cedula,
                    item.correo,
                    item.ciudad,
                    item.telefono,            
                ]).draw(false)
            }
        }
    }

    async cargarTablaPagos() {
        const result = await this.getListadoPreinscritosPagos();
        let listPreinscritos = []
        if (!result.is_Error) {
            listPreinscritos = result.objeto
            for (var i = 0; i < listPreinscritos.length; i++) {
                const item = listPreinscritos[i];
                this.tablaPreinscritos.row.add([
                    item.nombres,
                    item.apeliidos,
                    item.tipodeIdentificacion,
                    item.cedula,
                    item.correo,
                    item.ciudad,
                    item.telefono,
                ]).draw(false)
            }
        }
    }

}