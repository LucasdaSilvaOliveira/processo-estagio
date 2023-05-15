
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


