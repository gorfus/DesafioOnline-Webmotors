$('#MarcasDDL').select2({
    placeholder: "Selecione a Marca",
    ajax:
    {
        url: '/WebMotorsApi/MarcasData',
        dataType: 'json',
        data: function (params) { return { search: params.term, type: 'public' } }
    }
});

$('#MarcasDDL').on("select2:selecting", function (e) {

    $('#ModelosDLL').select2({

        placeholder: "Selecione o Modelo",
        ajax:
        {
            url: '/WebMotorsApi/ModelosPorMarcaData?marcaId=' + e.params.args.data.id,
            dataType: 'json',
            data: function (params) { return { search: params.term, type: 'public' }; }
        }
    });
});

$('#ModelosDLL').on("select2:selecting", function (e) {
    $('#VersoesDLL').select2({
        placeholder: "Selecione a Versão",
        ajax:
        {
            url: '/WebMotorsApi/VersoesPorModeloData?modeloId=' + e.params.args.data.id,
            dataType: 'json',
            data: function (params) { return { search: params.term, type: 'public' }; }
        }
    });
});

$("#frm-cadastrar-anuncio").submit(function (event) {
    $("select#VersoesDLL option:selected").val($("select#VersoesDLL option:selected").text());
    $("select#ModelosDLL option:selected").val($("select#ModelosDLL option:selected").text());
    $("select#MarcasDDL option:selected").val($("select#MarcasDDL option:selected").text());
});

$("#frm-pesquisar-anuncios").submit(function (event) {
    debugger;
    $("select#VersoesDLL option:selected").val($("select#VersoesDLL option:selected").text());
    $("select#ModelosDLL option:selected").val($("select#ModelosDLL option:selected").text());
    $("select#MarcasDDL option:selected").val($("select#MarcasDDL option:selected").text());
});