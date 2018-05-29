$(document).ready(function () {

    $('#divError').addClass('hide');

    $('#Save').click(function () {

        $('#divError').html('');

        if ($('#Nome').val() == "" || $('#Cpf').val() == "" || $('#Email').val() == "" || $('#DataNascimento').val() == "") {

            $("#divError").append("<strong> Erro: </strong> Todos os campos devem ser preenchidos. '  </br>");
        }

        else {

            var _objPessoa = {
                Id: $('#Id').val(),
                Nome: $('#Nome').val(),
                Cpf: $('#Cpf').val(),
                Email: $('#Email').val(),
                DtNascimento: $('#DataNascimento').val()
            }
            $.ajax({
                type: "POST",
                url: "/Pessoa/Create",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify({ objPessoa: _objPessoa }),
                success: function (response) {
                    if (response.success == true) {

                        alert("Dados Salvo com sucesso.");
                        window.location = "/Pessoa/Index";
                        return true;
                    }
                    else {
                        $('#divError').removeClass('hide');
                        $('#divError').addClass('show');
                        var msg = "";
                        for (var i = 0; i < response.responseText.length; i++) {

                            msg = "< strong > Erro: </strong > " + response.responseText[i] + " </br >"
                            $("#divError").append("<strong> Erro: </strong>" + response.responseText[i] + " </br>");
                            return false;
                        }

                    }
                }, error: function () {

                }
            });
        }

    });

    $('#Edit').click(function () {
        var _objPessoa = {
            Id: $('#Id').val(),
            Nome: $('#Nome').val(),
            Cpf: $('#Cpf').val(),
            Email: $('#Email').val(),
            DtNascimento: $('#DataNascimento').val()
        }
        $.ajax({
            type: "POST",
            url: "/Pessoa/Edit",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify({ objPessoa: _objPessoa }),
            success: function (response) {
                if (response.success == true) {
                    window.location = "/Pessoa/Index";
                    alert("Dados Salvo com sucesso.");
                    return true;
                }
                else {
                    $('#divError').removeClass('hide');
                    $('#divError').addClass('show');
                    var msg = "";
                    for (var i = 0; i < response.responseText.length; i++) {
                        $("#divError").append("<strong> Erro: </strong>" + response.responseText[i] + " </br>");

                    }
                    return false;
                }
            }, error: function () {

            }
        });

    });

    $('#Cpf').blur(function () {


        cpf = $('#Cpf').val();

        cpf = cpf.replace(/[^\d]+/g, '');
        if (cpf == '') {
            alert("Cpf Obrigatório");
            return false;
        }

        // Elimina CPFs invalidos conhecidos    
        if (cpf.length != 11 ||
            cpf == "00000000000" ||
            cpf == "11111111111" ||
            cpf == "22222222222" ||
            cpf == "33333333333" ||
            cpf == "44444444444" ||
            cpf == "55555555555" ||
            cpf == "66666666666" ||
            cpf == "77777777777" ||
            cpf == "88888888888" ||
            cpf == "99999999999") {
            // alert("Cpf inválido.");
            $("#divError").append("<strong> Erro: </strong> Cpf inválido.'  </br>");
            return false;
        }

        // Valida 1o digito 
        add = 0;
        for (i = 0; i < 9; i++)
            add += parseInt(cpf.charAt(i)) * (10 - i);
        rev = 11 - (add % 11);
        if (rev == 10 || rev == 11)
            rev = 0;
        if (rev != parseInt(cpf.charAt(9))) {
            alert("CPF Inválido.");
            return false;
        }
        // Valida 2o digito 
        add = 0;
        for (i = 0; i < 10; i++)
            add += parseInt(cpf.charAt(i)) * (11 - i);
        rev = 11 - (add % 11);
        if (rev == 10 || rev == 11)
            rev = 0;
        if (rev != parseInt(cpf.charAt(10))) {
            alert("CPF Inválido.");
            return false;

        }

        return true;


    });

    $('#DataNascimento').blur(function () {

        //Para não dar erro na máscara, validar email aqui.
        email = $('#Email').val();

        if (email == '') {
            alert("Email Obrigatório");
            return false;
        }

        if (validarIdade($('#DataNascimento').val()) == false) {
            return false;
        }

    });

  

});

(function ($) {

    $("#Cpf").mask("990.999.999-99");

    $("#DataNascimento").mask("99-99-9999");

    validarIdade = function (dtnascimento) {

        var dataNascimento = dtnascimento;
        var arrayData = dataNascimento.split("-");

        var d = new Date,
            ano_atual = d.getFullYear(),
            mes_atual = d.getMonth() + 1,
            dia_atual = d.getDate(),

            dia_aniversario = arrayData[0],
            mes_aniversario = arrayData[1],
            ano_aniversario = arrayData[2],

            idade = ano_atual - ano_aniversario;

        if (mes_atual < mes_aniversario || mes_atual == mes_aniversario && dia_atual < dia_aniversario) {
            idade--;
        }

        if (idade >= 18) {
            return true;
        }
        else {
            alert("É permitido somente maior de 18 anos.");
            return false;
        }
    };




})(jQuery);

