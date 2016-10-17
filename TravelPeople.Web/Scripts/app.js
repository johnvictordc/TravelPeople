$(document).ready(function () {
    var x = 0;

    $('.editor-ckeditor').each(function () {
        var id = 'ckeditor' + x;
        $(this).attr('id', id);

        var editor = CKEDITOR.instances['editor1'];
        if (editor) { editor.destroy(true); }
        CKEDITOR.replace(id, {
            enterMode: CKEDITOR.ENTER_BR,
        });
        CKFinder.setupCKEditor(null, '@Url.Content("~/Scripts/ckfinder/")');
        x++;
    });

    $(document).on('change', '#check-all', function () {
        // DETERMINE IF CHECK ALL
        var value = $('#check-all').prop('checked');

        $('.multi-check').each(function () {
            $(this).prop('checked', value);
        });
    });

    function dateInit() {
        // INITIALIZE DATEPICKER
        var d = new Date();
        $('.datepicker').each(function() {
            $(this).datepicker({
                format: 'yyyy-mm-dd'
            });
        });
    }


    dateInit();

});