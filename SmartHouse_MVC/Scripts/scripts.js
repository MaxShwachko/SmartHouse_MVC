$(document).ready(function () {
    $(".my-switch").click(function () {
        var isChecked = $(this).is(':checked');
        var item = $(this).prev();
        $.post('/api/Value', { "": item.next().data('id'), }, function (result) {
            item.attr('src', isChecked ? item.data('on') : item.data('off'));
        });
    });
});


$(document).ready(function () {
    $("p.btn").click(function () {
        var results = $(this).attr('id') + " ";
        var result2 = $(this).prevAll(".my-switch").last().data('id');
        result2 += " " + results.split(' ')[0];
        results += result2;
        $.get('/api/Value', { value: results }, function (data) {
            $('input[id="' + result2 + '"]').val(data);
        })
    })
})

$(document).ready(function () {

    var targetValue;

    var sel = document.getElementById("first_select");
    sel.onchange = function () {
        if (sel.value == "Lamp") {
            document.getElementById("second_select").hidden = false;
        }
        else
        {
            document.getElementById("second_select").hidden = true;
        }
    };
})