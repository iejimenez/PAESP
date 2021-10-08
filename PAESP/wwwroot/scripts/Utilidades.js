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



function Validador(idform, rules, mensajes, onlyOnSubmit = false) {

    if (mensajes == undefined)
        mensajes = []
    var validator = $("#" + idform).validate({
        lang: "ES",


        ignore: ':hidden:not(.do-not-ignore), input[type=hidden], .select2-search__field .ignore', // ignore hidden fields
        errorClass: 'validation-invalid-label',
        successClass: 'validation-valid-label',
        highlight: function (element, errorClass) {
            $(element).removeClass(errorClass);
        },
        unhighlight: function (element, errorClass) {
            $(element).removeClass(errorClass);
        },
        //ignore: '',
        // Different components require proper error label placement
        errorPlacement: function (error, element) {

            // Styled checkboxes, radios, bootstrap switch
            if (element.parents('div').hasClass("checker") || element.parents('div').hasClass("choice") || element.parent().hasClass('bootstrap-switch-container')) {
                if (element.parents('label').hasClass('checkbox-inline') || element.parents('label').hasClass('radio-inline')) {
                    error.appendTo(element.parent().parent().parent().parent());
                }
                else {
                    error.appendTo(element.parent().parent().parent().parent().parent());
                }
            }
            else if (element.hasClass('form-check-input-styled-danger') || element.hasClass('form-check-input-styled-success') || element.hasClass('form-check-input-styled-primary') || element.hasClass('form-check-input-styled-warning')) {
                error.appendTo(element.parent().parent().parent().parent().parent());
            }

            else if (element.hasClass('form-check-input-styled-danger') || element.hasClass('form-check-input-styled-success') || element.hasClass('form-check-input-styled-primary') || element.hasClass('form-check-input-styled-warning')) {
                error.appendTo(element.parent().parent().parent().parent().parent());
            }


            // Unstyled checkboxes, radios
            else if (element.parents('div').hasClass('checkbox') || element.parents('div').hasClass('radio')) {
                error.appendTo(element.parent().parent().parent());
            }

            // Input with icons and Select2
            else if (element.parents('div').hasClass('has-feedback') || element.hasClass('select2-hidden-accessible')) {
                error.appendTo(element.parent());
            }

            // Inline checkboxes, radios
            else if (element.parents('label').hasClass('checkbox-inline') || element.parents('label').hasClass('radio-inline')) {
                error.appendTo(element.parent().parent());
            }

            // Input group, styled file input
            else if (element.parent().hasClass('uploader') || element.parents().hasClass('input-group')) {
                error.appendTo(element.parent().parent().parent().parent());
            }

            else if (element.parent().hasClass('multiselect-native-select')) {
                error.appendTo(element.parent().parent());
            }

            else {
                error.insertAfter(element);
            }
        },
        rules: rules,
        messages: mensajes
    });
    return validator;
}


function createValidation(formName, validationConfig) {
    //const validationConfig = this.getValidationConfig();
    this.formValidator = this.formValidator === null || this.formValidator === undefined ? {} : this.formValidator;
    this.formValidator[formName] = Validador(formName, validationConfig);
    this.formValidator[formName].resetForm();
}

function inputChangeHandlerFunction(event) {
    const input = $(event.target);
    const type = input.data('type');
    const model = input.data("model");
    if (type == "money") {
        this[model][event.target.name] = input.val() ? formatMoneyToNumber(input.val().toUpperCase()) : 0;
        format(event.target, 1);
    }
    else if (type == 'moneyDecla') {
        const decimals = input.data('decimals');

        this[model][event.target.name] = input.val() ? formatMoneyToNumber(input.val().toUpperCase(), decimals) : 0;

        this[model][event.target.name]

        event.target.value = FormatoConPuntosSinRed(this[model][event.target.name], decimals);
    }
    else
        this[model][event.target.name] = input.val() ? input.val().trim().toUpperCase() : "";

}



var LoadingPetition = 0;
function ShowLoading(reset) {
    if (reset)
        LoadingPetition = 0;
    if (!Swal.isVisible()) {
        LoadingPetition++;
        Swal.fire({
            allowOutsideClick: false,
            allowEscapeKey: false,
            background: 'transparent ',

            onBeforeOpen: () => {
                Swal.showLoading();
            }
        });
    } else {
        if (!Swal.isLoading()) {
            LoadingPetition++;
            Swal.fire({
                allowOutsideClick: false,
                allowEscapeKey: false,
                background: 'transparent ',

                onBeforeOpen: () => {
                    Swal.showLoading();
                }
            });
        } else
            LoadingPetition++;
    }
}

function CloseLoading(onlypetition) {
    LoadingPetition--;
    if (Swal.isVisible()) {
        if (LoadingPetition <= 0 && onlypetition !== true && Swal.isLoading())
            Swal.close();
    }
}
