$(document).ready(function () {
    getEmployee();
})

function getEmployee() {
    
    let dataSize;
    let page;
    let size;
    $.get("api/employee/FindAllEmployeePageAndSize?page=0&size=10", function (data) {
        dataSize = data.dataSize;
        page = data.page;
        size = data.size;        
        $('#page-selection').bootpag({
            total: dataSize,
            page: page + 1,
            maxVisible: size,
        }).on('page', function (event, num) {            
            $.get("api/employee/FindAllEmployeePageAndSize?page=" + (num - 1) + "&size=" + data.size, function (data) {                
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
            });
            //$(this).bootpag({ total: dataSize, maxVisible: size });
        });
    });   
}