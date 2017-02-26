//(function() {


//    function bondTypeFn() {
//         $.ajax({
//            url: "Application/GetBondInfo",
//            datatype: "JSON",
//            type: "Get",
//            success: function (data) {
//                debugger;
//                for (var i = 0; i < data.length; i++) {
//                    var opt = new Option(data[i].BONDCODE);
//                    $("#bondType").append(opt);
//                }
//            }
//        });
//    }


//});


$(document).ready(function () {
    //interest rate configuration 
    $("#ENTRYDATE").datepicker();

    $("#INTRATEENTRYDATE").datepicker();
    
    //datepicker for new application view
    $('#AppDate').datepicker();
    $('#reInvestmentDate').datepicker();
    $('#respondingDate').datepicker();
    $('#dateOfBirthDate').datepicker();
    $('#NewApplication_IssueDate').datepicker();
    $('#NewApplication_ValueDate').datepicker();
    $('#NewApplication_DateOfBirthOfBeneficiary').datepicker();

    
    

    
    //$('#').datepicker();
    //$('#').datepicker();
});


