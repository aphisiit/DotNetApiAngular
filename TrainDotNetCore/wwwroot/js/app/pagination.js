var totalRecords = 0,
    records = [],
    displayRecords = [],
    recPerPage = 10,
    pageButton = 1,
    totalPages = 0;

$(document).ready(function () {
    getEmployee();
    apply_pagination();
})

function getEmployee() {
    $.ajax({
        url: "api/employee/FindAllEmployeePageAndSize?page=" + (pageButton - 1) + "&size=" + recPerPage,
        async: false,
        dataType: 'json',
        success: function (data) {
            records = data.content;
            totalRecords = data.dataSize;
            totalPages = totalRecords / recPerPage;            
        }
    });
}

function generate_table() {  
    $.ajax({
        url: "api/employee/FindAllEmployeePageAndSize?page=" + (pageButton - 1) + "&size=" + recPerPage,
        async: false,
        dataType: 'json',
        success: function (data) {
            $('#tbody').empty();
            for (let x of data.content) {
                $('#tbody').append('' +
                    '<tr>' +
                    '<td>' + x.id + '</td>' +
                    '<td>' + x.firstName + '</td>' +
                    '<td>' + x.lastName + '</td>' +
                    '<td>' + x.email + '</td>' +
                    '<td>' + x.gender + '</td>' +
                    '<td>' + x.ipAddress + '</td>' +
                    '</tr>' +

                    '')
            }
        }
    });    
}

function apply_pagination() {
    $('#pagination').twbsPagination({
        totalPages: totalPages,
        visiblePages: recPerPage,
        onPageClick: function (event, page) {                
            pageButton = page;
            displayRecordsIndex = Math.max(page - 1, 0) * recPerPage;
            endRec = (displayRecordsIndex) + recPerPage;

            displayRecords = records.slice(displayRecordsIndex, endRec);
            generate_table();
        }
    });
}