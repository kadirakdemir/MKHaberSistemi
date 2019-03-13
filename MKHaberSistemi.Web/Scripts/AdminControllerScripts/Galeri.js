$(function () {
    $("#kaydet").click(function () {
        var resim = $("#ImageInput").get(0).files;
        var galeriData = new FormData();
        galeriData.append("ProfilRsm", resim[0]);
        galeriData.append("Ad", $("#Adi").val());
        galeriData.append("Aciklama", $("#Aciklama").val());
        galeriData.append("IsActive", $("#Aktif").is(':checked'));       
        $.ajax({
            
            url: "GaleriEkle",
            data: galeriData,
            type: "post",
            datatype: 'json',
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.Success) {
                    swal(
                        response.Message,
                        'Galeriler sayfasına yönlendiriliyorsunuz!',
                        'success'
                    )
                    setTimeout(function () {
                        window.location.href = "/Admin/Galeri/Index";
                    }, 2000);
                }

            }
        });
    })
});

$(function () {
    $("#duzenle").click(function () {
        var resim = $("#ImageInput").get(0).files;
        var galeriData = new FormData();
        galeriData.append("ProfilRsm", resim[0]);
        galeriData.append("Ad", $("#Adi").val());
        galeriData.append("ID", $("#id").val());
        galeriData.append("Aciklama", $("#Aciklama").val());
        galeriData.append("IsActive", $("#Aktif").is(':checked'));
        debugger;
        $.ajax({

            url: "GaleriEkle",
            data: galeriData,
            type: "post",
            datatype: 'json',
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.Success) {
                    swal(
                        response.Message,
                        'Galeriler sayfasına yönlendiriliyorsunuz!',
                        'success'
                    )
                    setTimeout(function () {
                        window.location.href = "/Admin/Galeri/Index";
                    }, 2000);
                }

            }
        });
    })
});


function Delete(kid) {
    swal({
        title: 'Kategoriyi siliniyor. Emin misiniz?',
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
                    url: "GaleriSil",
                    data: { id: kid },
                    type: "POST",
                    dataType: "json",
                }).done(function (response) {
                    if (response.Success) {

                        swal(
                            'Galeri silindi!',
                            'Başarılı',
                            'success'
                        )
                        setTimeout(function () {
                            location.reload();
                        }, 2000);
                    }
                    else {

                        swal(
                            'Galeri silinemedi!',
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
