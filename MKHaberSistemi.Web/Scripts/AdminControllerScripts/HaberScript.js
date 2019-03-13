


function Create() {
   
   
    for (ck_editor_textarea in CKEDITOR.instances)
        var icerik = CKEDITOR.instances['ck_editor_textarea'].updateElement(); 
    
    //alert($("#ck_editor_textarea").val() + $("#kategoriid").val() + $("#secilenetiketid").serialize());
    //var dataString = new FormData($("#ajaxform").get(0));
    //var resim = $("#ImageInput").get(0).files;
    //dataString.append("ProfilRsm", resim[0]);
   
    var dataString = new FormData();

    //var sel = document.getElementById("secilenetiketid");
    //for (var i = 0; i < sel.options.length; i++) {
    //    dataString.append("SecilenEtiketId", sel[i].value);
    //}

    //var secResimGaleri = document.getElementById("secilenresimlerid");
    //for (var j = 0; j < secResimGaleri.options.length; j++) {
    //    dataString.append("SecilenResimlerId", secResimGaleri[j].value);
    //}

    var etiketler = $("#secilenetiketid").val() || [];
    for (var i = 0; i < etiketler.length; i++) {
        dataString.append("SecilenEtiketId", etiketler[i]);
    }

    var resimler = $("#secilenresimlerid").val() || [];
    for (var j = 0; j < resimler.length; j++) {
        dataString.append("SecilenResimlerId", resimler[j]);
    }



    var resim = $("#ImageInput").get(0).files;
    dataString.append("ProfilRsm", resim[0]);
    dataString.append("Baslik", $("#baslik").val());
    dataString.append("Aciklama", $("#aciklama").val());
    dataString.append("IsActive", $("#Aktif").is(':checked'));
    dataString.append("Kaynak", $("#kaynak").val());
    dataString.append("HaberPozisyonuID", $("#haberpozisyonid").val());
    dataString.append("HaberTipiID", $("#habertipid").val());
    dataString.append("KategoriID", $("#kategoriid").val());
    dataString.append("IsYayinlandiMi", $("#IsYayinlandiMi").is(':checked'));
    dataString.append("Icerik", $("#ck_editor_textarea").val());
   


    $.ajax({
        url: 'Create',
        data: dataString,
        type: "POST",
        dataType: 'json',
        processData: false,
        contentType: false,
        success: function (response) {           
            if (response.Success) {
                swal(
                    response.Message,
                    'Haberler sayfasına yönlendiriliyorsunuz!',
                    'success'
                )
                setTimeout(function () {
                    window.location.href = "/Admin/Haber/Index";
                }, 2500);
            }
            else {
                swal(
                    response.Message,
                    'Tekrar Deneyin!',
                    'error'
                )
                setTimeout(function () {
                    "T";
                }, 2500);
            }
        }
    });
}

//$(function () {
//    $("ajaxform").submit(function () {
//        alert(1)
//        for (ck_editor_textarea in CKEDITOR.instances)
//            var icerik = CKEDITOR.instances['ck_editor_textarea'].updateElement();

//        var dataString = new FormData();
//        dataString = $(this).serialize();
//        var resim = $("#ImageInput").get(0).files;
//        dataString.append("ProfilRsm", resim[0]);
//        $.ajax({
//            url: 'Edit',
//            data: dataString,
//            type: "POST",
//            dataType: 'json',
//            processData: false,
//            contentType: false,
//            success: function (response) {
//                if (response.Success) {
//                    swal(
//                        response.Message,
//                        'Haberler sayfasına yönlendiriliyorsunuz!',
//                        'success'
//                    )
//                    setTimeout(function () {
//                        window.location.href = "/Admin/Haber/Index";
//                    }, 2500);
//                }
//                else {
//                    swal(
//                        response.Message,
//                        'Tekrar deneyin.',
//                        'error'
//                    )
//                    setTimeout(function () {

//                    }, 2500);
//                }
//            }
//        });
//    })
//});

function Edit() {

    for (ck_editor_textarea in CKEDITOR.instances)
        var icerik = CKEDITOR.instances['ck_editor_textarea'].updateElement(); 
   
    var dataString = new FormData();
  
    var etiketler = $("#secilenetiketid").val() || [];    
    for (var i = 0; i < etiketler.length; i++) {
        dataString.append("SecilenEtiketId", etiketler[i]);      
    }
       
    var resimler = $("#secilenresimlerid").val() || [];   
    for (var j = 0; j < resimler.length; j++) {
        dataString.append("SecilenResimlerId", resimler[j]);
    }
            
    var resim = $("#ImageInput").get(0).files;
    dataString.append("ProfilRsm", resim[0]);
    dataString.append("Id", $("#id").val());
    dataString.append("Baslik", $("#baslik").val());
    dataString.append("Aciklama", $("#aciklama").val());
    dataString.append("IsActive", $("#Aktif").is(':checked'));
    dataString.append("Kaynak", $("#kaynak").val());
    dataString.append("HaberPozisyonuID", $("#haberpozisyonid").val());
    dataString.append("HaberTipiID", $("#habertipid").val());
    dataString.append("KategoriID", $("#kategoriid").val());
    dataString.append("IsYayinlandiMi", $("#IsYayinlandiMi").is(':checked'));    
    dataString.append("Icerik", $("#ck_editor_textarea").val());
   
    $.ajax({
        url: 'Edit',
        data: dataString,
        type: "POST",
        dataType: 'json',
        processData: false,
        contentType: false,
        success: function (response) {
            //debugger;
            if (response.Success) {
               
                swal(
                   response.Message,
                    'Haberler sayfasına yönlendiriliyorsunuz!',
                    'success'
                )
                setTimeout(function () {
                    window.location.href = "/Admin/Haber/Index";
                }, 1500);
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
        title: 'Haber siliniyor. Emin misiniz?',
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
                            'Haber silindi!',
                            'Başarılı',
                            'success'
                        )
                        setTimeout(function () {
                            location.reload();
                        }, 2000);
                    }
                    else {

                        swal(
                            'Haber silinemedi!',
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
}


//function Ekle(){
//    alert(1)
//    event.stopImmediatePropagation();
//    var action = $("#ajaxform").attr("action");
//    var dataString = new FormData($("#AjaxformId").get(0));
//    var resim = $("#ImageInput").get(0).files;
//    dataString.append("ProfilRsm", resim[0])
//    $.ajax({
//        url: 'Create',
//        data: dataString,
//        dataType: "json",
//        contentType: false,
//        processData: false,
//        success: function (result) {
//            alert(12255)
//            onAjaxRequestSuccess(result);
//        }
//    })
//}


//$(document).ready(function () {
//    $("#ajaxform").submit(function (event) {
        
//        alert(1)
//        event.stopImmediatePropagation();  
//        var action = $("#ajaxform").attr("action");
//        var dataString = new FormData($("#AjaxformId").get(0));
//        var resim = $("#ImageInput").get(0).files;
//        dataString.append("ProfilRsm", resim[0])
//        $.ajax({
//            url: action,
//            data: dataString,
//            dataType: "json",
//            contentType: false,
//            processData: false,
//            success: function (result) {
//                alert(12255)
//                onAjaxRequestSuccess(result);
//            }
//        })
//    })
//})

//var onAjaxRequestSuccess = function (result) {
//    if (result.Success) {
//        // Setting.  
//        swal(
//            response.Message,
//            'Kategoriler sayfasına yönlendiriliyorsunuz!',
//            'success'
//        )
//        setTimeout(function () {
//            window.location.href = "/Admin/Haber/Index";
//        }, 2500);
//    } else  {
//        // Setting.  
//        swal(
//            response.Message,
//            'Sayfa yenileniyor!',
//            'error'
//        )
//        setTimeout(function () {
//            location.reload();
//        }, 2500);
//        // Resetting form.  
//        //$('#AjaxformId').get(0).reset();
//    }
//}  
//function OnSuccess(response) {
//    swal(
//                    response.Message,
//                    'Kategoriler sayfasına yönlendiriliyorsunuz!',
//                    'success'
//                )
//                setTimeout(function () {
//                    window.location.href = "/Admin/Haber/Index";
//                }, 2500);
//}

//function OnFailure(response) {
//    swal(
//                    response.Message,
//                    'Sayfa yenileniyor!',
//                    'error'
//                )
//                setTimeout(function () {
//                    location.reload();
//                }, 2500);
//}