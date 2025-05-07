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
    });
})(jQuery);