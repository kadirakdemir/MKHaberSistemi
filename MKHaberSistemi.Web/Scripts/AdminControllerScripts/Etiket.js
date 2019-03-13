function Kaydet() {
    Etiket = new FormData();
    Etiket.append("Ad", $("#Adi").val());
    Etiket.append("Aciklama", $("#Aciklama").val());
    Etiket.append("IsActive", $("#Aktif").is(':checked'));
    $.ajax({
        url:"/Admin/Etiket/Create",
        data: Etiket,
        type:"post",
        datatype: "json",
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.Success) {
                swal(
                    response.Message,
                    'Kategoriler sayfasına yönlendiriliyorsunuz!',
                    'success'
                )
                setTimeout(function () {
                    window.location.href = "/Admin/Etiket/Index";
                }, 2500);
            }
            else {
                swal(
                    response.Message,
                    'Tekrar deneyin.',
                    'error'
                )
                setTimeout(function () {                    
                }, 2500);
            }
        }
    });
}

function Duzenle() {
    Etiket = new FormData();
    Etiket.append("ID", $("#id").val())
    Etiket.append("Ad", $("#Adi").val());
    Etiket.append("Aciklama", $("#Aciklama").val());
    Etiket.append("IsActive", $("#Aktif").is(':checked'));
    $.ajax({
        url: "Edit",
        data: Etiket,
        type: "post",
        datatype: "json",
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.Success) {
                swal(
                    response.Message,
                    'Kategoriler sayfasına yönlendiriliyorsunuz!',
                    'success'
                )
                setTimeout(function () {
                    window.location.href = "/Admin/Etiket/Index";
                }, 2500);
            }
            else {
                swal(
                    response.Message,
                    'Tekrar deneyin.',
                    'error'
                )
                setTimeout(function () {
                   
                }, 2500);
            }
        }
    });
}

function Delete(kid) {
    swal({
        title: 'Etiket siliniyor. Emin misiniz?',
        text: "Bu işlemi geri alınamaz!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonText: 'İptal',
        confirmButtonText: ' Sil ',
        showLoaderOnConfirm: true,
        preConfirm: function () {
            return new Promise(function (resolve) {
                $.ajax({
                    url: "Delete",
                    data: { id: kid },
                    type: "POST",
                    dataType: "json",
                }).done(function (response) {
                    if (response.Success) {

                        swal(
                            'Etiket silindi!',
                            'Başarılı',
                            'success'
                        )
                        setTimeout(function () {
                            location.reload();
                        }, 2000);
                    }
                    else {

                        swal(
                            'Etiket silinemedi!',
                            'Oops, başarısız!',
                            'error'
                        )
                        setTimeout(function () {
                            location.reload();
                        }, 2000);
                    }
                })
            })
        }
    })
};
