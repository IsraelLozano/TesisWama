$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };
        ajaxindicatorstart('Procesando...por favor espere...');
        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-otf-target"));
            var $newData = $(data);
            $target.replaceWith($newData);
            $newData.effect("highlight");
            
        }).always(function () {
            ajaxindicatorstop();
        });
        return false;
    };

    var createAutocomplete = function () {
        $input = $(this);
        var options = {
            source: $input.attr("data-otf-autocomplete"),
            select: submitAutoCompleteForm
        };

        $input.autocomplete(options);

    };

    var submitAutoCompleteForm = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    };

    var getPage = function () {
        var $a = $(this);
        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };
        ajaxindicatorstart('Procesando...por favor espere...');

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-otf-target");
            var $newData = $(data);
            $(target).replaceWith($newData);
            $newData.effect("highlight");
        }).always(function () {
            ajaxindicatorstop();
        });

        return false;
    };

    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-otf-autocomplete]").each(createAutocomplete);
    $(".main-content").on("click", ".pagedList a", getPage);

});