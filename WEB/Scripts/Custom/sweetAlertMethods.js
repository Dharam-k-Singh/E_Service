var baseConfig = {
    showClass: {
        popup: 'swal2-show',
        backdrop: 'swal2-noanimation',
        icon: 'swal2-icon-show'
    }
}

function showSweetAlert(title, body, icon, isHTML) {
    let swalConfig = {
        icon: icon,
        title: title,
        allowOutsideClick: false,
        allowEscapeKey: false
    };

    swalConfig = $.extend(swalConfig, baseConfig);

    swalConfig[isHTML ? "html" : "text"] = body;

    swal.fire(swalConfig);
}

function showConfirmSweetAlert(title, body, icon, isHTML, confirmBtnText, cancelBtnText, confirmCallback, cancelCallback) {
    let swalConfig = {
        icon: icon,
        title: title,
        showCancelButton: true,
        confirmButtonColor: '#000080',
        cancelButtonColor: '#d33',
        confirmButtonText: confirmBtnText,
        cancelButtonText: cancelBtnText,
        allowOutsideClick: false,
        allowEscapeKey: false
    };

    swalConfig = $.extend(swalConfig, baseConfig);

    swalConfig[isHTML ? "html" : "text"] = body;

    swal.fire(swalConfig).then((result) => {
        if (result.value) confirmCallback();
        else cancelCallback();
    });
}

function showLoadingSweetAlert(title) {

   // let loaderHtml = '<div class="progress"><div class="progress-bar progress-bar-striped progress-bar-animated bg-primary w-100" role="progressbar"></div></div>';
   let loaderHtml = '<div class="progress"><div class="progress-bar" role = "progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" style = "width:90%"><span class="sr-only">98% Complete</span></div></div>';
   // let loaderHtml = '<div class="progress">< div class="progress-bar progress-bar-striped progress-bar-animated" role = "progressbar" aria - valuenow="75" aria - valuemin="0" aria - valuemax="100" style = "width: 75%" ></div ></div >'
    //let loaderHtml = '<div class="progress"><div class="progress-bar progress-bar-striped progress-bar-animated bg-primary w-100" role="progressbar"></div></div>';
   


    let swalConfig = {
        title: title,
        html: loaderHtml,
        showCancelButton: false,
        showConfirmButton: false,
        allowOutsideClick: false,
        allowEscapeKey: false
    };

    swalConfig = $.extend(swalConfig, baseConfig);

    swal.fire(swalConfig);
}

function closeSweetAlert() {
    swal.close();
}

function showAlert(title, body, icon, isHTML, confirmBtnText, confirmCallback) {
    let swalConfig = {
        icon: icon,
        title: title,
        allowOutsideClick: false,
        allowEscapeKey: false,
        confirmButtonColor: '#000080',
        cancelButtonColor: '#d33',
        confirmButtonText: confirmBtnText
    };

    swalConfig = $.extend(swalConfig, baseConfig);

    swalConfig[isHTML ? "html" : "text"] = body;

    swal.fire(swalConfig).then((result) => {
        if (result.value) confirmCallback();
        else cancelCallback();
    });
}