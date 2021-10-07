


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
        this.$selectConcepto = $('#txtConcepto')
        this.$inputNroDocumento = $('#txtNroDocumento')
        this.$inputEmail = $('#Email')
        this.$inputTelefono = $('#Telefono')
        this.$inputNombres = $('#txtNombres')
        this.$inputApellidos = $('#txtApellidos')
        this.$btnGenerarRecibo = $('#btnGenerarRecibo')
    }

    _initConstants() {       
        this.API_POST_GUARDAR_PREINSCRIPTOS = SetUrlForQuery('/Preinscripcion/InsertarPreinscripcion')
        this.API_GET_LISTAR_CONCEPTOS = SetUrlForQuery('/Concepto/ListConceptos')
        this.API_GET_LISTAR_TIPOS_IDENTI = SetUrlForQuery('/Configuracion/GetTiposIdentificacion')
        this.FORM_PREINSCRIPCION = 'form_preinscripcion'
    }

    _initEventBindings() {
        this.$btnGenerarRecibo.on('click', this.clickHandlerGuardarPreinscritos)
    }


    async _init() {
        await this.setConceptos()
        await this.setTiposIdentificacion();
    }

    async setConceptos() {
        const result = await fetchGet(this.API_GET_LISTAR_CONCEPTOS);
        let items_html = `<option value="">Seleccionar concepto</option>`

        if (!result.is_Error)
            this.conceptos = result.objeto        
        else       
            this.conceptos = []
        
        $.each(this.conceptos, (index, item) => {
            if (item.tipoConcepto !== 'MAT') {
                items_html += `<option value="${item.idConcepto}">${item.descripcion}</option>`;
            }
        });

        this.$selectConcepto.html(items_html);
        this.$selectConcepto.select2();
    }

    async setTiposIdentificacion() {
        const result = await fetchGet(this.API_GET_LISTAR_TIPOS_IDENTI);
        let items_html = `<option value="">Seleccionar entidad</option>`
        if (!result.is_Error)
            this.tiposIdenti = result.objeto
        else
            this.tiposIdenti = []
        $.each(this.tiposIdenti, (index, item) => {
            items_html += `<option value="${item.idTipo}">${item.descripcion}</option>`;
        });

        this.$inputTipoDocumento.html(items_html);
        this.$inputTipoDocumento.select2();
    }
 
    postSavePreinscripto()
    {
        let params = $(`#${this.FORM_PREINSCRIPCION}`).serialize()

        return new Promise((resolve, reject) => {
            $.ajax({
                url: this.API_POST_GUARDAR_PREINSCRIPTOS,
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

    async clickHandlerGuardarPreinscritos()
    {
        const result = await this.postSavePreinscripto()

        if (!result.isError) {
            swal.fire({
                title: "¡Success!",
                text: result.msj,
                confirmButtonClass: "btn btn-success",
                type: "success"
            });
        }
        else
        {
            swal.fire({
                title: "¡Error!",
                text: result.msj,
                confirmButtonClass: "btn-primary",
                type: "Error"
            });
        }
    }

}
