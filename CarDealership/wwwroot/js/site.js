// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
jQuery.noConflict();
(function ($) {
    $(document).ready(function () {
        $('.tabela-pessoas').DataTable({
            language: {
                url: '//cdn.datatables.net/plug-ins/2.3.0/i18n/pt-BR.json',
            }
        });

        const $CEPInput = $('input#CEP');
        $CEPInput.on('focusout', function () {
            if ($CEPInput.valid() === true) {
                console.log('Deu certo!')
                $.ajax({
                    method: 'GET',
                    url: `https://viacep.com.br/ws/${$CEPInput.val()}/json/`,
                    dataType: 'json',
                    success: function (data) {
                        console.log(data)
                        const endereco = data.logradouro;
                        const cidade = data.localidade;
                        const estado = data.uf;

                        if (endereco) {
                            const $enderecoInput = $('input#Endereco');
                            $enderecoInput.val(endereco);
                            $enderecoInput.attr({ 'background-color': 'yellow' })
                        }
                        if (cidade) {
                            const $cidadeInput = $('input#Cidade');
                            $cidadeInput.val(cidade);
                        }
                        if (estado) {
                            const $estadoInput = $('input#Estado');
                            $estadoInput.val(estado);
                        }

                    },
                    error: function (xhr, status, error) {
                        console.log(`Error: ${status} - ${error}`);
                    }
                })
            }
        });

        const $CriarVendaCPFElem = $('#CriarVenda_CPFCliente');
        $CriarVendaCPFElem.on('focusout', function () {
            console.log($CriarVendaCPFElem.val())
            if ($CriarVendaCPFElem && $CriarVendaCPFElem.val()) {
                const cpf = $CriarVendaCPFElem.val().replace('.', '').replace('-', '');

                if (cpf.length == 11) {
                    $.ajax({
                        method: 'GET',
                        url: `/Cliente/ConsultarClientePorCPF?cpf=${cpf}`,
                        dataType: 'json',
                        success: function (data) {
                            const $elem = $('#info_cpf_consultado');
                            if (!data.id) {
                                $elem.css({ 'color': 'red' });
                                $elem.text('Cliente não encontrado. (Será criado um novo)');
                                $('#CriarVenda_IdCliente').val(undefined);
                                $('#CriarVenda_NomeCliente').val(undefined);
                                $('#CriarVenda_TelefoneCliente').val(undefined);
                            } else {
                                $elem.text(undefined);
                                $('#CriarVenda_IdCliente').val(data.id);
                                $('#CriarVenda_NomeCliente').val(data.nome);
                                $('#CriarVenda_TelefoneCliente').val(data.telefone);
                            }
                        },
                        error: function (xhr, status, error) {
                            console.log(`Error: ${status} - ${error}`);
                        }
                    });
                }
            }
        })

        
    });
})(jQuery);