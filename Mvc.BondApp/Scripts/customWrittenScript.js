
$(document).ready(function () {
    //===================interest rate configuration ===============================================================================

    $("#ENTRYDATE").datepicker();

    $("#INTRATEENTRYDATE").datepicker();
    //==============================================================================================================================

    //=============================================datepicker for new application view===============================================
    $('#AppDate').datepicker();
    $('#reInvestmentDate').datepicker();
    $('#respondingDate').datepicker();
    $('#dateOfBirthDate').datepicker();
    $('#NewApplication_IssueDate').datepicker();
    $('#NewApplication_ValueDate').datepicker();
    $('#NewApplication_DateOfBirthOfBeneficiary').datepicker();
    //==================================================================================================================================

    //========================================USING ENTER KEY INSTEAD OF TAB TO NAVIGATION==============================================
    var focusables = $(":input").not('[type="image"]').not('[type="submit"]');

    focusables.keydown(function (e) {
        if (e.keyCode === 13) {
            e.preventDefault();
            var current = focusables.index(this),
                    next = focusables.eq(current + 1).length ? focusables.eq(current + 1) : focusables.eq(0);
            next.focus();
        }
    });

    //=================================================================================================================================




});


