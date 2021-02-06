(function ($) {
    var _clubSessionService = abp.services.app.clubSession,
        l = abp.localization.getSource('HamVarzeshi'),
        _$modal = $('#ClubSessionCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#ClubSessionsTable');

    var _$clubSessionsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#ClubSessionsSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;
 
            abp.ui.setBusy(_$table);
            _clubSessionService.getAll(filter).done(function (result) {
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
                action: () => _$clubSessionsTable.draw(false)
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
                data: 'isActive',
                sortable: false,
                render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
            },
            {
                targets: 7,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-clubSession" data-clubSession-id="${row.id}" data-toggle="modal" data-target="#ClubSessionEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-clubSession" data-clubSession-id="${row.id}" data-clubSession-name="${row.title}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var clubSession = _$form.serializeFormToObject();
    
        abp.ui.setBusy(_$modal);
        _clubSessionService.create(clubSession).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$clubSessionsTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-clubSession', function () {
        var clubSessionId = $(this).attr("data-clubSession-id");
        var clubSessionName = $(this).attr('data-clubSession-name');

        deleteClubSession(clubSessionId, clubSessionName);
    });

    function deleteClubSession(clubSessionId, clubSessionName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                clubSessionName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _clubSessionService.delete({
                        id: clubSessionId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$clubSessionsTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-clubSession', function (e) {
        var clubSessionId = $(this).attr("data-clubSession-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'ClubSessions/EditModal?clubSessionId=' + clubSessionId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ClubSessionEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    $(document).on('click', 'a[data-target="#ClubSessionCreateModal"]', (e) => {
        $('.nav-tabs a[href="#clubSession-details"]').tab('show')
    });

    abp.event.on('clubSession.edited', (data) => {
        _$clubSessionsTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$clubSessionsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$clubSessionsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
