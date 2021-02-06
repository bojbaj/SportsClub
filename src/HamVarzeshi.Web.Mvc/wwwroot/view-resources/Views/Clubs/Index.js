(function ($) {
    var _clubService = abp.services.app.club,
        l = abp.localization.getSource('HamVarzeshi'),
        _$modal = $('#ClubCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#ClubsTable');

    var _$clubsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#ClubsSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;
 
            abp.ui.setBusy(_$table);
            _clubService.getAll(filter).done(function (result) {
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
                action: () => _$clubsTable.draw(false)
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
                data: 'title',
                sortable: false
            },
            {
                targets: 2,
                data: 'isActive',
                sortable: false,
                render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
            },
            {
                targets: 3,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-club" data-club-id="${row.id}" data-toggle="modal" data-target="#ClubEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-club" data-club-id="${row.id}" data-club-name="${row.name}">`,
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

        var club = _$form.serializeFormToObject();
    
        abp.ui.setBusy(_$modal);
        _clubService.create(club).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$clubsTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-club', function () {
        var clubId = $(this).attr("data-club-id");
        var clubName = $(this).attr('data-club-name');

        deleteClub(clubId, clubName);
    });

    function deleteClub(clubId, clubName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                clubName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _clubService.delete({
                        id: clubId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$clubsTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-club', function (e) {
        var clubId = $(this).attr("data-club-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Clubs/EditModal?clubId=' + clubId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ClubEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    $(document).on('click', 'a[data-target="#ClubCreateModal"]', (e) => {
        $('.nav-tabs a[href="#club-details"]').tab('show')
    });

    abp.event.on('club.edited', (data) => {
        _$clubsTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$clubsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$clubsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
