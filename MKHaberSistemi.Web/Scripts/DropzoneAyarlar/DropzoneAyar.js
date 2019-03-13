
$(document).ready(function () {
   
    Dropzone.options.dropzoneForm = {

        maxFilesize: 5,
        maxFiles: 30,
        uploadMultiple: true,
        autoProcessQueue: false,
        addRemoveLinks: "true",
        paramName: "file",
        parallelUploads: 30,
        dictDefaultMessage: "Resim eklemek için tıklayın <br/> veya sürükleyip bırakın.  <i class='glyphicon glyphicon-import'><i/>",
        clickable: true,
        autoProcessQueue: false,
        init: function () {
            this.on("maxfilesexceeded", function (data) {
                var res = eval('(' + data.xhr.responseText + ')');

            });
            var yukleButton = document.querySelector("#yukle");
            var iptalButton = document.querySelector("#iptal");
            var myDropzone = this;

            yukleButton.addEventListener("click", function () {
                myDropzone.processQueue();
            });

            iptalButton.addEventListener("click", function () {
                myDropzone.removeAllFiles(true);
            });

            this.on("addedfile", function (file) {
                //var submitButton = document.querySelector("#yukle");
                //var wrapperThis = this;

                //submitButton.addEventListener("click", function () {
                //    wrapperThis.processQueue();
                // Create the remove button
                var removeButton = Dropzone.createElement("<button class='form-control btn btn-danger btntrash glyphicon glyphicon-trash'></button>");


                // Capture the Dropzone instance as closure.
                var _this = this;

                // Listen to the click event
                removeButton.addEventListener("click", function (e) {
                    // Make sure the button click doesn't submit the form:
                    e.preventDefault();
                    e.stopPropagation();
                    // Remove the file preview.
                    _this.removeFile(file);
                    // If you want to the delete the file on the server as well,
                    // you can do the AJAX request here.
                });

                // Add the button to the file preview element.
                file.previewElement.appendChild(removeButton);
            });
        },
        success: function (response) {

            Command: toastr["success"]("My name is Inigo Montoya. You killed my father. Prepare to die!")

            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-bottom-center",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            setTimeout(function () {
                location.reload();
            }, 1500);
        }

    };
})

//var mydropzone = new Dropzone('#dropzoneForm',



$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: 'GaleriResimlerGetir',
        dataType: "JSON",
        success: function (data) {
            $('#tablo').html("");
            $(data.Result).each(function (item) {
                var makale = '<tr><td>' + data.Result[item].Ad + '</td><td>' + data.Result[item].IcerikUzunlugu + '</td></tr>';
                $('#tablo').append(makale);
            })
        }
    });
});