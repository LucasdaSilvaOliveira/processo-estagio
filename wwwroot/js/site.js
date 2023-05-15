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

// VALIDAÇÃO ENTRADA MERCADORIA

    $('#form-entrada').submit(function () {
        let quantidadeEnt = $('#quantidade-ent').val();
        let diaEnt = $('#dia-ent').val();
        let mesEnt = $('#mes-ent').val();
        let anoEnt = $('#ano-ent').val();
        let horaEnt = $('#hora-ent').val();
        let localEnt = $('#local-ent').val();

        if (quantidadeEnt.length == 0 || diaEnt.length == 0 || mesEnt.length == 0
            || anoEnt.length == 0 || horaEnt.length == 0 || localEnt.length == 0) {
            alert('Por favor, preencha todos os campos.');
            return false;
        }
        if (quantidadeEnt.trim() == "" || diaEnt.trim() == "" || mesEnt.trim() == "" || anoEnt.trim() == ""
            || horaEnt.trim() == "" || localEnt.trim() == "") {
            alert("Não pode enviar formulário em branco.");
            return false;
            }
        if (diaEnt > 31) {
            alert('Dia inválido.');
            return false;
        }
        if (mesEnt > 12) {
            alert('Mês inválido.');
            return false;
        }
        if (anoEnt < 2023 || anoEnt > 2040) {
            alert('Ano inválido.');
            return false;
        }

        if (localEnt.length == 1) {
            alert('Local inválido.');
            return false;
        }

        var horarioStrEnt = $("#hora-ent").val().trim();

        var horarioRegex = /^([01]\d|2[0-3]):([0-5]\d)$/;

        if (!horarioRegex.test(horarioStrEnt)) {
            alert("Horário inválido. O formato deve ser HH:MM.");
            return false;
        }
    });

// VALIDAÇÃO SAÍDA MERCADORIA

    $('#form-saida').submit(function () {
        let quantidadeSaida = $('#quantidade-saida').val();
        let diaSaida = $('#dia-saida').val();
        let mesSaida = $('#mes-saida').val();
        let anoSaida = $('#ano-saida').val();
        let horaSaida = $('#hora-saida').val();
        let localSaida = $('#local-saida').val();

        if (quantidadeSaida.length == 0 || diaSaida.length == 0 || mesSaida.length == 0
            || anoSaida.length == 0 || horaSaida.length == 0 || localSaida.length == 0) {
            alert('Por favor, preencha todos os campos.');
            return false;
        }
        if (quantidadeSaida.trim() == "" || diaSaida.trim() == "" || mesSaida.trim() == "" || anoSaida.trim() == ""
            || horaSaida.trim() == "" || localSaida.trim() == "") {
            alert("Não pode enviar formulário em branco.");
            return false;
        }
        if (diaSaida > 31) {
            alert('Dia inválido.');
            return false;
        }
        if (mesSaida > 12) {
            alert('Mês inválido.');
            return false;
        }
        if (anoSaida < 2023 || anoSaida > 2040) {
            alert('Ano inválido.');
            return false;
        }

        if (localSaida.length == 1) {
            alert('Local inválido.');
            return false;
        }

        var horarioStrSaida = $("#hora-saida").val().trim();

        var horarioRegex = /^([01]\d|2[0-3]):([0-5]\d)$/;

        if (!horarioRegex.test(horarioStrSaida)) {
            alert("Horário inválido. O formato deve ser HH:MM.");
            return false;
        }
    });
});
