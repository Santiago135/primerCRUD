$(window).bind('beforeunload', function () {
    ShowModalCarga();
});

function ShowModalCarga() {
    $('#Modal').hide();
    $('#Cargando').show();
}
