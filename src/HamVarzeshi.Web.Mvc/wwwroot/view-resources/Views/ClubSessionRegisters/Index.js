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
            _clubSessionRegisterService.getAll(filter).done(function (result) {
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
                        `   <button type="button" class="btn btn-sm bg-secondary edit-clubSessionRegister" data-clubSessionRegister-id="${row.id}" data-toggle="modal" data-target="#ClubSessionRegisterEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-clubSessionRegister" data-clubSessionRegister-id="${row.id}" data-clubSessionRegister-name="${row.name}">`,
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

    $(document).on('click', '.delete-clubSessionRegister', function () {
        var clubSessionRegisterId = $(this).attr("data-clubSessionRegister-id");
        var clubSessionRegisterName = $(this).attr('data-clubSessionRegister-name');

        deleteClubSessionRegister(clubSessionRegisterId, clubSessionRegisterName);
    });

    function deleteClubSessionRegister(clubSessionRegisterId, clubSessionRegisterName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                clubSessionRegisterName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _clubSessionRegisterService.delete({
                        id: clubSessionRegisterId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$clubSessionRegistersTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-clubSessionRegister', function (e) {
        var clubSessionRegisterId = $(this).attr("data-clubSessionRegister-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'ClubSessionRegisters/EditModal?clubSessionRegisterId=' + clubSessionRegisterId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ClubSessionRegisterEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    $(document).on('click', 'a[data-target="#ClubSessionRegisterCreateModal"]', (e) => {
        $('.nav-tabs a[href="#clubSessionRegister-details"]').tab('show')
    });

    abp.event.on('clubSessionRegister.edited', (data) => {
        _$clubSessionRegistersTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

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
