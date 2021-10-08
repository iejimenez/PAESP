var seleccionFecha = {
    labelMonthNext: 'Ir al siguiente mes',
    labelMonthPrev: 'Ir al mes anterior',
    labelMonthSelect: 'Seleccionar mes',
    labelYearSelect: 'Seleccionar año',
    labelDaySelect: 'aqui',
    klass: {
        navPrev: '',
        navNext: ''
    },

    selectMonths: true,
    selectYears: 100,
    //min: new Date(1800, 1, 1),
    today: 'Hoy',
    close: 'Cerrar',
    clear: '',
    format: 'yyyy-mm-dd',
    onSet: function (context) {

        adjustStyling({ target: this.$node[0] });
    }
}

function fetchGet(url, data) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: `${url}`,
            type: "GET",
            dataType: "json",
            data: data,
            success: function (data) {
                resolve(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                reject(new Error(`${errorThrown} - ${url}`));
            }
        });
    });
}

function SetUrlForQuery(stringrelativeserver) {
    return window.location.origin + stringrelativeserver;
}

function Get_Meses(Num, Id) {

    var ListaMesesString = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
    var html_rol = '';
    $.each(ListaMesesString, function (key, value) {
        if (key <= Num)
            html_rol += '<option value="' + value + '">' + value + '</option>';
    });

    $('#' + Id).html(html_rol);
    $('#' + Id).val("");
    $('#' + Id).select2();
}


function DescargarPDF(tipo, id) {
    var formURL = '/report/generate?tipo=' + tipo + "&Id=" + id;
    window.open(formURL, "_black");
}