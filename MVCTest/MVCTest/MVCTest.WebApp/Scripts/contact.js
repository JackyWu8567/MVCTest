$("#btn_call").click(function () {
    var token = sessionStorage.getItem("access_token");
    $.ajax({
        type: 'GET',
        url: "https://localhost:44310/api/values/5",
        headers: {
            "Authorization": "Bearer " + token
        },
    }).done(function (data) {
        alert(data);
    });
});