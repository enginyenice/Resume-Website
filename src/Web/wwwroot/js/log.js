$(document).ready(function () {


    function AddLog(message) {

        $.ajax({
            url: "/api/log/",
            type: 'POST',
            data: message,
            contentType: "application/json; charset=utf-8",
            dataType: 'json', // added data type
            success: function (res) {


            }
        });
    }


    $.ajax({
        url: "https://ipapi.co/json/",
        type: 'GET',
        dataType: 'json', // added data type
        success: function (res) {
            console.log();
            AddLog(JSON.stringify(res));

        }
    });

});