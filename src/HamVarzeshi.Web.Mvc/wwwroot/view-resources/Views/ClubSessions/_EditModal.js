(function ($) {
    var _clubSessionService = abp.services.app.clubSession,
        l = abp.localization.getSource('HamVarzeshi'),
        _$modal = $('#ClubSessionEditModal'),
        _$form = _$modal.find('form');

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var clubSession = _$form.serializeFormToObject();
       
        abp.ui.setBusy(_$form);
        _clubSessionService.update(clubSession).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('clubSession.edited', clubSession);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
