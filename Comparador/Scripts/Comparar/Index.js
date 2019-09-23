$(document).ready(function () {
    $('#Comparar').click(function () {
        $('#produto1').load("/Produto/Detalhe/" + $('#SelectedProduto1').children("option:selected").val());
        $('#produto2').load("/Produto/Detalhe/" + $('#SelectedProduto2').children("option:selected").val());
    });
});