$("#btn_call").click(function () {
    var token = sessionStorage.getItem("access_token");
    
    var headers = {};
    if (token) {
        headers.Authorization = 'Bearer ' + token;
    }

    alert(headers);

    $.ajax({
        method: 'GET',
        url: "https://localhost:44310/api/values/5",
        headers: headers
    }).done(function (data) {
        alert(data);
    });

    //$.ajax({
    //    url: "https://localhost:44310/api/values/5",
    //    type: "GET",
    //    headers: headers,
    //    success: function (data) {
    //        alert(data.value);
    //    },
    //    error: function (jqXHR, textStatus, errorThrown) {
    //        alert(errorThrown);
    //    }
    //});
});