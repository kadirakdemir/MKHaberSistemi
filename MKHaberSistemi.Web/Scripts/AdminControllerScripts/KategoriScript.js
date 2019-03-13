// Kategori Ekle
function KategoriEkle() {   
    var resim = $("#ImageInput").get(0).files;
    Kategori = new FormData();
    Kategori.append("ProfilRsm", resim[0]);
    Kategori.append("Ad", $("#Adi").val());
    Kategori.append("AltID", $("#AltKategoriID").val());
    Kategori.append("Aciklama", $("#Aciklama").val());
    Kategori.append("Diger", $("#Diger").val());
    Kategori.append("IsActive", $("#Aktif").is(':checked'));
    $.ajax({
        url: "Ekle",
        data: Kategori,
        type: "POST",
        dataType: 'json',
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.Success) {
                alert("Oldu");
                swal(
                    response.Message,
                    'Kategoriler sayfasına yönlendiriliyorsunuz!',
                    'success'
                );
                setTimeout(function () {
                    window.location.href = "/Admin/Kategori/Index";
                }, 2000);
            }
            else {
                alert("Hayır");
                swal(
                    response.Message,                   
                    'Tekrar deneyin!',
                    'error'
                );
                setTimeout(function () {
                  
                }, 2000);
            }
        }

    });
}



//Kategori Düzenle
function Duzenle() {
    var resim = $("#ImageInput").get(0).files;
    Kategori = new FormData();
    Kategori.append("ProfilRsm", resim[0]);
    Kategori.append("ID", $("#id").val());
    Kategori.append("Ad", $("#Adi").val());
    Kategori.append("AltID", $("#AltKategoriID").val());
    Kategori.append("Aciklama", $("#Aciklama").val());
    Kategori.append("Diger", $("#Diger").val());
    Kategori.append("IsActive", $("#Aktif").is(':checked'));
    $.ajax({
        url: "Duzenle",
        data: Kategori,
        type: "POST",
        dataType: 'json',
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
                    window.location.href = "/Admin/Kategori/Index";
                }, 2000);
            }
            else {
                swal(
                    response.Message,
                    'Tekrar deneyin.',
                    'error'
                )
                setTimeout(function () {

                }, 2000);
            }
        }

    });
}


function Sil(kid) {
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
                    url: "Sil",
                    data: { id: kid },
                    type: "POST",
                    dataType: "json",
                }).done(function (response) {
                        if (response.Success) {

                            swal(
                                'Kategori silindi!',
                                'Başarılı',
                                'success'
                            )
                            setTimeout(function () {
                                location.reload();
                            }, 2000);
                        }
                        else {

                            swal(
                                'Kategori silinemedi!',
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



//dropdownlitfor castcading(iç içe bağımlı)
//$(function () {
//    $("#AltKategoriID").change(function () {
//        var id = $(this).val();
//        //alert(id)
//        $.ajax({
//            url: "/Kategori/GetKategoriList",
//            type: "Post",
//            data: { 'AltID': id },
//            dataType: 'json',
//            success: function (result) {
//                var altkategori = $("#AltID");
//                altkategori.empty();
//                $.each(result, function (i, item) {
//                    altkategori.append($("<option></option>").attr("value", item).html(item.Ad))
//                });
//            }
//        });
//    });
//})
