// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $("#myForm").submit(function (event) {
        console.log(event)
        $("#myGif").css("display", "block");
    });

    $("#button-addon2").click(function () {
        var data = $("#nPosition").val();
        if (data.length <3) {
            $("#errorEmptyPos").css("display", "block")
            return
        }
        $("#errorEmptyPos").css("display", "none")
        $("#positionCreatingGif").css("display", "block");
        $.ajax({
            type: "POST",
            url: "Positions/Add",
            data: { "positionName": data },
            success: function (data) {
                console.log(data)
                $("#positionCreatingGif").css("display", "none");
            },
            complete: function (a, b) {
                $("#positionCreatingGif").css("display", "none");
            },
            dataType: 'json'
        });
    });

    $(function () {
        $("#nPosition").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "/Search",
                    data: { term: request.term },
                    success: function (data) {
                        var newData = [];
                        for (var a of data) {
                            newData.push(a["name"])
                        }
                        response(newData);
                    },
                    dataType: 'json'
                });
            },
        });
    })
})