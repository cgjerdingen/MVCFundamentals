$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };
        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-rmt-target"));
            //add an effect to show what changed, assign data result to a jquery var, so you can do stuff to it
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight", {}, 2000);

        });
        return false;
    };

    // ui is the autocomlete ui element. Lots of properties and functions on this thing
    var submitAutocompleteForm = function (event, ui) {
        var $input = $(this);
        //this automatically happens, but sometimes setting it explicitly can avoid any old values being held onto.
        $input.val(ui.item.label);

        var $form = $input.parent("form:first");
        $form.submit();
    };

    var createAutocomplete = function () {
        var $input = $(this);
        var options = {
            source: $input.attr("data-rmt-autocomplete"),
            select: submitAutocompleteForm
        };
        $input.autocomplete(options);
    }

    var getPage = function () {
        var $a = $(this);
        var options = {
            url: $a.attr("href"),
            //include all the form data with this post, in our case just the search term
            data: $("form").serialize(),
            type: "get"
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pageList").attr("data-rmt-target");
            $(target).replaceWith(data);
        });

        return false;

    };

    $("form[data-rmt-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-rmt-autocomplete]").each(createAutocomplete);
    $(".main-content").on("click", ".pagedList a", getPage);
})