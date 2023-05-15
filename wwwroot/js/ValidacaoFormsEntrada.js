
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

