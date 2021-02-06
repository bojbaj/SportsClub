(function ($) {
    var _clubSessionRegisterService = abp.services.app.clubSessionRegister,
        l = abp.localization.getSource('HamVarzeshi'),
        _$modal = $('#ClubSessionRegisterCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#ClubSessionRegistersTable');

    var _$clubSessionRegistersTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#ClubSessionRegistersSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _clubSessionRegisterService.getClubSessions(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$clubSessionRegistersTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'club.title',
                sortable: false
            },
            {
                targets: 2,
                data: 'title',
                sortable: false
            },
            {
                targets: 3,
                data: 'duration',
                sortable: false
            },
            {
                targets: 4,
                data: 'club.costPerHour',
                sortable: false
            },
            {
                targets: 5,
                data: 'totalCosts',
                sortable: false
            },
            {
                targets: 6,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    if (row.registered) {
                        return [                        
                            `   <button type="button" class="btn btn-sm bg-danger delete-clubSessionRegister" data-clubSession-id="${row.id}" data-clubSession-name="${row.title}">`,
                            `       <i class="fas fa-trash"></i> ${l('Cancel')}`,
                            '   </button>'
                        ].join('');    
                    } else {
                        return [                        
                            `   <button type="button" class="btn btn-sm bg-success register-clubSessionRegister" data-clubSession-id="${row.id}" data-clubSession-name="${row.title}">`,
                            `       <i class="fas fa-pencil-alt"></i> ${l('Register')}`,
                            '   </button>',
                        ].join('');    
                    }
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var clubSessionRegister = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _clubSessionRegisterService.create(clubSessionRegister).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$clubSessionRegistersTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.register-clubSessionRegister', function () {
        var clubSessionId = $(this).attr("data-clubSession-id");
        var clubSessionName = $(this).attr('data-clubSession-name');

        registerClubSessionRegister(clubSessionId, clubSessionName);
    });

    function registerClubSessionRegister(clubSessionId, clubSessionName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToRegisterClubSession'),
                clubSessionName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _clubSessionRegisterService.register({
                        clubSessionId: clubSessionId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyClubSessionRegistered'), clubSessionName);
                        _$clubSessionRegistersTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.delete-clubSessionRegister', function () {
        var clubSessionId = $(this).attr("data-clubSession-id");
        var clubSessionName = $(this).attr('data-clubSession-name');

        deleteClubSessionRegister(clubSessionId, clubSessionName);
    });
    function deleteClubSessionRegister(clubSessionId, clubSessionName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToCancelClubSessionRegistration'),
                clubSessionName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _clubSessionRegisterService.cancelRegistration({
                        clubSessionId: clubSessionId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyCanceledClubSessionRegistration'), clubSessionName);
                        _$clubSessionRegistersTable.ajax.reload();
                    });
                }
            }
        );
    }

    $('.btn-search').on('click', (e) => {
        _$clubSessionRegistersTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$clubSessionRegistersTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
