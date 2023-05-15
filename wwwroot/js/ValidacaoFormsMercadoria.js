$(document).ready(function () {

    // VALIDAÇÃO CADASTRO MERCADORIA

    $('#form-cadastro').submit(function () {
        let nome = $('#nome').val();
        let fabricante = $('#fabricante').val();
        let tipo = $('#tipo').val();
        let descricao = $('#descricao').val();

        if (nome.length == 0 || fabricante.length == 0 || tipo.length == 0 || descricao.length == 0) {
            alert('Por favor, preencha os campos corretamente.');
            return false;
        }

        if (nome.trim() == "" || fabricante.trim() == "" || tipo.trim() == "" || descricao.trim() == "") {
            alert("Não pode cadastrar formulário em branco.");
            return false;
        }
    });

    // VALIDAÇÃO CADASTRO DE EDIÇÃO


    $('#form-att').submit(function () {
        let nomeAtt = $('#nome-att').val();
        let fabricanteAtt = $('#fabricante-att').val();
        let tipoAtt = $('#tipo-att').val();

        if (nomeAtt.length == 0 || fabricanteAtt.length == 0 || tipoAtt.length == 0) {
            alert('Por favor, preencha os campos corretamente.');
            return false;
        }

        if (nomeAtt.trim() == "" || fabricanteAtt.trim() == "" || tipoAtt.trim() == "") {
            alert("Não pode cadastrar formulário em branco.");
            return false;
        }
    });
});