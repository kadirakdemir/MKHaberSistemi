$(function () {
    $('#DataTableTr').DataTable({
        "language": {
            "sProcessing": "İşleniyor...",
            "sLengthMenu": "Sayfada _MENU_ Kategori Gösteriliyor ",
            "sZeroRecords": "Hiçbir eşleşen kayıt bulunamadı",
            "sEmptyTable": "Tabloda veri yok",
            "sInfo": " _TOTAL_ Sonuçtan _START_ ile _END_ arası gösteriliyor.",
            "sInfoEmpty": " 0 Sonuçtan 0 ile 0 arası",
            "sInfoFiltered": "(Toplamda _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Ara:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Yükleniyor...",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }

    });
})

$(function ($) {
    var active_class = 'active';
    $('#simple-table > thead > tr > th input[type=checkbox]').eq(0).on('click', function () {
        var th_checked = this.checked;//checkbox inside "TH" table header

        $(this).closest('table').find('tbody > tr').each(function () {
            var row = this;
            if (th_checked) $(row).addClass(active_class).find('input[type=checkbox]').eq(0).prop('checked', true);
            else $(row).removeClass(active_class).find('input[type=checkbox]').eq(0).prop('checked', false);
        });
    });

    /***************/
    $('.show-details-btn').on('click', function (e) {
        e.preventDefault();
        $(this).closest('tr').next().toggleClass('open');
        $(this).find(ace.vars['.icon']).toggleClass('fa-angle-double-down').toggleClass('fa-angle-double-up');
    });
    /***************/

})