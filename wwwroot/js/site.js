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

// VALIDAÇÃO EDIÇÃO DE ENTRADA

    $('#form-entrada-att').submit(function () {
        let quantidadeEntAtt = $('#quantidade-ent-att').val();
        let diaEntAtt = $('#dia-ent-att').val();
        let mesEntAtt = $('#mes-ent-att').val();
        let anoEntAtt = $('#ano-ent-att').val();
        let horaEntAtt = $('#hora-ent-att').val();
        let localEntAtt = $('#local-ent-att').val();

        if (quantidadeEntAtt.length == 0 || diaEntAtt.length == 0 || mesEntAtt.length == 0
            || anoEntAtt.length == 0 || horaEntAtt.length == 0 || localEntAtt.length == 0) {
            alert('Por favor, preencha todos os campos.');
            return false;
        }
        if (quantidadeEntAtt.trim() == "" || diaEntAtt.trim() == "" || mesEntAtt.trim() == "" || anoEntAtt.trim() == ""
            || horaEntAtt.trim() == "" || localEntAtt.trim() == "") {
            alert("Não pode enviar formulário em branco.");
            return false;
        }
        if (diaEntAtt > 31) {
            alert('Dia inválido.');
            return false;
        }
        if (mesEntAtt > 12) {
            alert('Mês inválido.');
            return false;
        }
        if (anoEntAtt < 2023 || anoEntAtt > 2040) {
            alert('Ano inválido.');
            return false;
        }

        if (localEntAtt.length == 1) {
            alert('Local inválido.');
            return false;
        }

        var horarioStrEntAtt = $("#hora-ent-att").val().trim();

        var horarioRegexAtt = /^([01]\d|2[0-3]):([0-5]\d)$/;

        if (!horarioRegexAtt.test(horarioStrEntAtt)) {
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

// VALIDAÇÃO EDIÇÃO DE SAÍDA

$('#form-saida-att').submit(function () {
    let quantidadeSaidaAtt = $('#quantidade-saida-att').val();
    let diaSaidaAtt = $('#dia-saida-att').val();
    let mesSaidaAtt = $('#mes-saida-att').val();
    let anoSaidaAtt = $('#ano-saida-att').val();
    let horaSaidaAtt = $('#hora-saida-att').val();
    let localSaidaAtt = $('#local-saida-att').val();

    if (quantidadeSaidaAtt.length == 0 || diaSaidaAtt.length == 0 || mesSaidaAtt.length == 0
        || anoSaidaAtt.length == 0 || horaSaidaAtt.length == 0 || localSaidaAtt.length == 0) {
        alert('Por favor, preencha todos os campos.');
        return false;
    }
    if (quantidadeSaidaAtt.trim() == "" || diaSaidaAtt.trim() == "" || mesSaidaAtt.trim() == "" || anoSaidaAtt.trim() == ""
        || horaSaidaAtt.trim() == "" || localSaidaAtt.trim() == "") {
        alert("Não pode enviar formulário em branco.");
        return false;
    }
    if (diaSaidaAtt > 31) {
        alert('Dia inválido.');
        return false;
    }
    if (mesSaidaAtt > 12) {
        alert('Mês inválido.');
        return false;
    }
    if (anoSaidaAtt < 2023 || anoSaidaAtt > 2040) {
        alert('Ano inválido.');
        return false;
    }

    if (localSaidaAtt.length == 1) {
        alert('Local inválido.');
        return false;
    }

    var horarioStrSaidaAtt = $("#hora-saida-att").val().trim();

    var horarioRegexSaidaAtt = /^([01]\d|2[0-3]):([0-5]\d)$/;

    if (!horarioRegexSaidaAtt.test(horarioStrSaidaAtt)) {
        alert("Horário inválido. O formato deve ser HH:MM.");
        return false;
    }
});