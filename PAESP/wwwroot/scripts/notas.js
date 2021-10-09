class NotasView {
    constructor() {
        this.idGrupo = getParameterByName("idgrupo") * 1;
        this.getNotas = this.getNotas.bind(this);
        this.renderTableNotas = this.renderTableNotas.bind(this);
        this.changueInputNotaHandler = this.changueInputNotaHandler.bind(this);
        this.postNota = this.postNota.bind(this);
        this._initHtml()
        this._initConstants()
        this._initEventBindings();
        this._init();

    }

    _initHtml() {
        this.$tableNotas = null;
    }

    _initConstants() {
        this.TABLE_NOTAS = 'datatable-notas';
        this.API_GET_NOTAS = SetUrlForQuery('/Nota/GetNotas?idgrupo=' + this.idGrupo);
        this.API_POST_UPADTE_NOTAS = SetUrlForQuery('/Nota/UpdateNota');
    }

    _initEventBindings() {

    }

    _init() {
        this.notas = {};
        this.getNotas();
    }

    async getNotas() {
        const result = await fetchGet(this.API_GET_NOTAS);
        this.notas = result;
        this.renderTableNotas();
    }


    renderTableNotas() {

        this.$tableNotas = $("#" + this.TABLE_NOTAS).dataTable();
        if (this.$tableNotas.api != null) {
            this.$tableNotas.fnDestroy();
        }
        else if (this.$tableNotas != undefined && this.$tableNotas != null) {
            this.$tableNotas.clear().draw();
            this.$tableNotas.destroy();
        }

        RenderTable(this.TABLE_NOTAS, [0, 1, 2, 3, 4, 5, 6], [
            { data: 'estudiante.usuario.cedula', className: "dt-center", },
            {
                data: 'idGrupoEstudiante', className: "dt-center", width:"40%", render: (data, type, row, meta) => {

                    return row.estudiante.usuario.nombres + " " + row.estudiante.usuario.apeliidos;
                }},
            {
                data: 'idGrupoEstudiante', className: "dt-center", render: (data, type, row, meta) => {

                    return "<input onkeypress='return soloNumerosYDecimal(event)' data-corte='1' data-idx='" + meta.row + "' id='estPc_" + data + "' class='form-control EditNotas border-0' type='text' value='" + row.primerCorte + "' /> "
                }
            },
            {
                data: 'idGrupoEstudiante', className: "dt-center", render: (data, type, row, meta) => {

                    return "<input onkeypress='return soloNumerosYDecimal(event)' data-corte='2' data-idx='" + meta.row + "' id='estSc_" + data + "' class='form-control EditNotas border-0' type='text' value='" + row.segundoCorte + "' /> "
                }
            },
            {
                data: 'idGrupoEstudiante', className: "dt-center", render: (data, type, row, meta) => {

                    return "<input onkeypress='return soloNumerosYDecimal(event)' data-corte='3' data-idx='" + meta.row + "' id='estTc_" + data + "' class='form-control EditNotas border-0' type='text' value='" + row.tercerCorte + "' /> "
                }
            },
            {
                data: 'idGrupoEstudiante', className: "dt-center", render: (data, type, row, meta) => {

                    return "<input onkeypress='return soloNumerosYDecimal(event)' data-corte='4' data-idx='"+meta.row+"' id='estPonderado" + meta.row + "' readonly class='form-control border-0' type='text' value='" + row.ponderado + "' /> "
                }
            },
            {
                data: 'idGrupoEstudiante', className: "dt-center", render: (data, type, row, meta) => {

                    return ""
                }
            }
        ], {
            data: this.notas,
            "paging": true,
            "ordering": false,
            "order": [],
            "info": true,
            "searching": true,
            "aaSorting": [],
            "columnDefs": [
                {
                    "targets": [], //first column / numbering column
                    "orderable": false, //set not orderable
                }],
            "targets": [],
            "dom": '<"top"flB>rt<"bottom"ip><"clear">',
            buttons: [
                {
                    extend: 'excelHtml5',
                    text: "Descargar en excel",
                    className: "btn btn-xs btn-outline bg-slate-600 text-slate-600 border-slate-600 border-2 save legitRipple",
                }
            ]
        });

        this.$tableNotas = $("#" + this.TABLE_NOTAS).dataTable();
        $(`#${this.TABLE_NOTAS} .EditNotas`).off("chenge").on("change", this.changueInputNotaHandler);
    }

    changueInputNotaHandler(event) {
        const input = $(event.target);
        const val = parseFloat(input.val());
        if (val < 0)
            return;
        if (val > 5)
            return;

        const corte = input.data('corte');
        const index = input.data('idx');
        if (corte == 1) 
            this.notas[index].primerCorte = val;
        else if (corte == 2)
            this.notas[index].segundoCorte = val;
        else if (corte == 3)
            this.notas[index].tercerCorte = val;


        this.notas[index].ponderado = this.notas[index].primerCorte * 0.3 + this.notas[index].segundoCorte * 0.3 + this.notas[index].tercerCorte * 0.4
        $("#estPonderado" + index).val(this.notas[index].ponderado);

        this.postNota(this.notas[index]);
    }

    async postNota(nota) {
        //let formData = new FormData();
        //formData.append('login', JSON.stringify));

        const notaASubir = JSON.parse(JSON.stringify(nota));
        notaASubir.primerCorte = FormatoConPuntosSinRed(notaASubir.primerCorte, 2);
        notaASubir.segundoCorte = FormatoConPuntosSinRed(notaASubir.segundoCorte, 2);
        notaASubir.tercerCorte = FormatoConPuntosSinRed(notaASubir.tercerCorte, 2);

        return new Promise((resolve, reject) => {
            $.ajax({
                url: this.API_POST_UPADTE_NOTAS,
                content: "application/json; charset=utf-8",
                type: "POST",
                dataType: "json",
                data: { "nota": notaASubir },
                success: function (data) {
                    resolve(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    reject(new Error(`${errorThrown} - ${this.API_SAVE_Distributor}`));
                }
            });
        });
    }
}

export default NotasView;