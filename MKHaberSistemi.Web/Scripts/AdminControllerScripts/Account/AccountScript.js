function Login() {
    Giris = new FormData();
    Giris.append("Email", $("#Email").val());
    Giris.append("Sifre", $("#Sifre").val());
    var a = $("#Email").val();
   
    $.ajax({
        url: "Acoount/Log",
        data: Giris,
        type: "post",
        dataType: "json",
        processData: false,
        contentType: false,
        success: function (response) {
            alert("save");
            if (response.Success) {
                swal(
                    response.Message,
                    'Kategoriler sayfasına yönlendiriliyorsunuz!',
                    'success'
                );
                setTimeout(function () {
                    window.location.href = "/Admin/Etiket/Index";
                }, 2500);
            }
            else {
                swal(
                    response.Message,
                    'Tekrar deneyin.',
                    'error'
                );
                setTimeout(function () {
                }, 2500);
            }
        }
    });
}