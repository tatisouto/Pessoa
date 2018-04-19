$(document).ready(function () {

    loadDivAddress();

    isNumber($('input[id="Phone"]')); 

    isNumber($('input[id="PostalCode"]')); 

    $('#addAddress').click(function () {
        if ($('#divAddress').hasClass('hide')) {
            $('#divAddress').removeClass('show');
            $('#divAddress').addClass('show');
            $('#addAddress').removeClass('show');
            $('#addAddress').addClass('hide');
            $('#removeAddress').removeClass('hide');
            $('#removeAddress').addClass('show');
        }

    });

    $('#removeAddress').click(function () {

        if ($('#divAddress').hasClass('show')) {
            bootbox.confirm({
                message: "Deseja realmente excluir o endereço?",
                buttons: {
                    confirm: {
                        label: 'Sim',
                        className: 'btn-success'
                    },
                    cancel: {
                        label: 'Não',
                        className: 'btn-danger'
                    }
                },
                callback: function (result) {

                    if (result == true) {
                        $('#divAddress').removeClass('show');
                        $('#divAddress').addClass('hide');
                        $('#removeAddress').removeClass('show')
                        $('#removeAddress').addClass('hide');
                        $('#addAddress').removeClass('hide');
                        $('#addAddress').addClass('show');
                        resetAddress();
                        return true;
                    };
                }
            });
        }

    });

    $('#Save').click(function () {
        if ($('#FirstName').val() != "") {
            if (!validatePhone()) {
                bootbox.alert({
                    message: "É necessário ao menos 1 número de telefone",
                    callback: function () {
                        return true;
                    }
                })
            }            
        }

    });

    $('#addPhone').click(function () {
        if ($('#Phone').val() == "") {
            bootbox.alert({
                message: "Por favor digite telefone!",
                size: 'small'
            });
            return true;
        }

        else {
            addTableRow();
            return false;
        }

    });
        
});



(function ($) {
    removeTableRow = function (handler) {

        bootbox.confirm({
            message: "Deseja realmente excluir telefone?",
            buttons: {
                confirm: {
                    label: 'Sim',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'Não',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result == true) {
                    var tr = $(handler).closest('tr');

                    tr.fadeOut(400, function () {
                        tr.remove();
                    });
                    return true;
                };
            }
        });
    };

    addTableRow = function () {
        var newRow = $("<tr>");
        var cols = "";

        cols += '<td>' + $('#optClassification :selected').text() + '</td>';
        cols += '<td>' + $('#Phone').val() + '</td>';
        cols += '<td class="actions">';
        cols += '<button class="btn btn-sm btn-danger"  data-toggle="tooltip" data-placement="right" title="Remover" onclick="removeTableRow(this)" type="button"><span class="glyphicon glyphicon-trash""></span></button>';
        cols += '</td>'
        cols += '<td style="display:none">' + $('#optClassification').val() + '</td>';

        newRow.append(cols);

        $("#tablePhone").append(newRow);

        $('#Phone').val("");
        return false;
    }

    resetAddress = function () {
        $("#divAddress input").each(function () {
            $(this).val("");
        });

    };

    loadDivAddress = function () {

        $("#divAddress input").each(function () {
            if ($(this).val() != "") {
                $('#divAddress').removeClass('show');
                $('#divAddress').addClass('show');
                $('#addAddress').removeClass('show');
                $('#addAddress').addClass('hide');
                $('#removeAddress').removeClass('hide');
                $('#removeAddress').addClass('show');
                return true;
            }
            else {
                $('#divAddress').addClass('hide');
                $('#addAddress').addClass('show');
                $('#removeAddress').addClass('hide');
                return true;
            }
        });
    }

    contactSaveorUpdate = function () {

        if ($('#FirstName').val() != "") {

            if (!validatePhone()) {
                bootbox.alert({
                    message: "É necessário ao menos 1 número de telefone",
                    callback: function () {
                        return true;
                    }
                })
            }
            else {
                var phone = [];
                $("#tablePhone tbody tr").each(function () {
                    if ($(this).find("td:nth-child(1)").html() != undefined) {

                        phone.push({
                            ClassificationId: $(this).find("td:nth-child(4)").html(),
                            Number: $(this).find("td:nth-child(2)").html()
                        });
                    }
                });

                var _objContact = {
                    Id: $('#Id').val(),
                    FirstName: $('#FirstName').val(),
                    LastName: $('#LastName').val(),
                    Company: $('#LastName').val(),
                    Email: $('#Email').val(),
                    Address: {
                        Id: $('#IdAddress').val(),
                        StreetAddress: $('#StreetAddress').val(),
                        PostalCode: $('#PostalCode').val(),
                        City: $('#City').val(),
                        State: $('#State').val()
                    },
                    Phone: phone
                };

                console.log(_objContact);

                var _url = "";
                if ($('#Id').val() == "") {
                    _url = "/Contact/Create";
                }
                else {
                    _url = "/Contact/Edit";
                }

                $.ajax({
                    type: "POST",
                    url: _url,
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify({ objContact: _objContact }),
                    success: function (response) {
                        console.log(response);
                        bootbox.alert({
                            message: "Dados salvos com sucesso",
                            callback: function () {
                                window.location = "/Contact/List";
                                return true;
                            }
                        })
                    }
                });
            }




        }
        else {
            bootbox.alert({
                message: "Campo nome é obrigatório",
                callback: function () {
                    return true;
                }
            })
        }
    }

    validatePhone = function () {

        var retorno = false;

        $("#tablePhone tbody tr").each(function () {
            if ($(this).find("td:nth-child(1)").html() != undefined) {
                retorno = true;
            }
        });

        return retorno;

    }

    isNumber = function (fields) {
        
        $(fields).unbind('keyup').bind('keyup', function (e) { 

            var thisVal = $(this).val(); 
            var tempVal = "";

            for (var i = 0; i < thisVal.length; i++) {
                if (RegExp(/^[0-9]$/).test(thisVal.charAt(i))) { 
                    tempVal += thisVal.charAt(i); 

                    if (e.keyCode == 8) {
                        tempVal = thisVal.substr(0, i); 
                    }
                }
            }
            $(this).val(tempVal); 
        });
    }
   

})(jQuery);

