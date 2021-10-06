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