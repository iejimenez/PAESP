class GrupoProfesorView {
    constructor() {
        this.getCursos = this.getCursos.bind(this);
        this.renderTableCursos = this.renderTableCursos.bind(this);
        this.clickEditarNotas = this.clickEditarNotas.bind(this);
        this._initHtml()
        this._initConstants()
        this._initEventBindings();
        this._init();

    }

    _initHtml() {
        this.$tableGrupos = null;
    }

    _initConstants() {
        this.TABLE_CURSOS = 'datatable-Cursos';
        this.API_GET_CURSOS = SetUrlForQuery('/GrupoProfesor/GruposByProfesor');
    }

    _initEventBindings() {

    }

    _init() {
        this.grupos = {};
        this.getCursos();
    }

    getValidationConfig() {
        const validationConfig = {
            user: {
                required: true
            },
            pass: {
                required: true
            }
        }
        return validationConfig;
    }

    async getCursos() {
        const result = await fetchGet(this.API_GET_CURSOS);
        this.grupos = result;
        this.renderTableCursos();
    }

    async clickEditarNotas(event) {
        const idx = $(event.target).data("idx") * 1;
        const id = this.grupos[idx].idGrupo;
        window.location.href = '/Nota/Index?idgrupo=' + id;
    }

    renderTableCursos() {

        this.$tableGrupos = $("#" + this.TABLE_CURSOS).dataTable();
        if (this.$tableGrupos.api != null) {
            this.$tableGrupos.fnDestroy();
        }
        else if (this.$tableGrupos != undefined && this.$tableGrupos != null) {
            this.$tableGrupos.clear().draw();
            this.$tableGrupos.destroy();
        }

        RenderTable(this.TABLE_CURSOS, [0, 1, 2, 3], [
            { data: 'materia.codigo', className: "dt-center", },
            { data: 'materia.nombre', className: "dt-center", },
            { data: 'nombre', className: "dt-center" },
            {
                data: 'idGrupo', className: "dt-center", render: (data, type, row, meta) => {
                  
                    return "<div class='list-icons'>" +
                        "<a class='showEditNotas' id='showEditNotas" + meta.row + "' data-idx='" + meta.row + "' data-popup='tooltip' title='Ver detalle'><i  data-idx='" + meta.row + "'class='text-link-primary icon-certificate'></i></a>" +
                        "</div>"
                }
            }
        ], {
            data: this.grupos,
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
            ]
        });

        this.$tableGrupos = $("#" + this.TABLE_CURSOS).dataTable();
        $(`#${this.TABLE_CURSOS} .showEditNotas`).off("click").on("click", this.clickEditarNotas);
    }

}

export default GrupoProfesorView;