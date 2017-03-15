
$(document).ready(function () {
    //==========================CLEAR THE FORM======================================================================================






    //===================interest rate configuration ===============================================================================

    $("#ENTRYDATE").datepicker();

    $("#INTRATEENTRYDATE").datepicker();
    //==============================================================================================================================

    //=============================================datepicker for new application view===============================================
    $('#AppDate').datepicker();
    $('#reInvestmentDate').datepicker();
    $('#respondingDate').datepicker();
    $('#dateOfBirthDate').datepicker();
    $('#ISSUEDATE').datepicker();
    $('#VALUEDATE').datepicker();
    $('#BENEFICIARY_BENDOB').datepicker();
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

    //=============================Dropdownlist Selectedchange FOR THANA event====================================

        $("#LOCALDIST").change(function () {

            $("#LOCALTHANA").empty();
            var url = '/Application/GetCascadeThana';
            $.ajax({
                type: 'GET',
                //url: '@Url.Action("GetCascadeThana","Application")',
                url:url,
                dataType: "json",
                data: { district: $("#LOCALDIST").val() },
                success: function (thanas) {

                    // states contains the JSON formatted list

                    // of states passed from the controller

                    $.each(thanas, function (i, thana) {

                        $("#LOCALTHANA").append("<option value=\"" + thana.ThanaCode + "\">" + thana.ThanaName + "</option>");

                    });

                },

                error: function (ex) {

                    alert("Failed to retrieve thana." + ex);

                }

            });

            return false;

        });
        //==================================================================================================================================

        //==========================================DROPDOWNLIST FOR PAYMENT MODE========================================

        //$("#NewApplication_PaymentMode").register(function() {

        //    $("#NewApplication_PaymentMode").empty();

        //    $.ajax({
        //        type: "GET",
        //        url: '@Url.Action("GetPaymentMode")',
        //        dataType: "json",
        //        success: function(paymentModes) {

        //            // states contains the JSON formatted list

        //            // of states passed from the controller

        //            $.each(paymentModes, function(i, mode) {

        //                $("#NewApplication_PayemntMode").append("<option value=\"" + mode.PAYCODE + "\">" + mode.PAYDESC + "</option>");

        //            });
        //        },
        //        error: function(ex) {
        //            alert("Failed to retrieve states." + ex);
        //        }
        //    });
        //    return false;
        //});


        //=====================================GETTING THE BRANCH INFO IN FIELD FCBRANCH============================================
        //$.ajax({
        //    type: "GET",
        //    url: '@Url.Action("GetFcBranch")',
        //    dataType: "json",
        //    success: function (branches) {

        //        // states contains the JSON formatted list

        //        // of states passed from the controller

        //        $.each(branches, function (i, branch) {

        //            $("#NewApplication_FcAccountBranch").append("<option value=\"" + branch.BRCODE + "\">" + branch.BRNAME + "</option>");

        //        });
        //    },
        //    error: function (ex) {
        //        alert("Failed to retrieve states." + ex);
        //    }

        //});
        //=======================================================================================================================


        //========================================GETTING THE CURRENCY INFO IN FIELD CURRENCY====================================
        //$.ajax({
        //    type: "GET",
        //    url: '@Url.Action("GetCurrencyCode")',
        //    dataType: 'json',
        //    success: function (currencies) {

        //        // states contains the JSON formatted list

        //        // of states passed from the controller

        //        $.each(currencies, function (i, currency) {

        //            $("#NewApplication_Currency").append("<option value=\"" + currency.CURRCODE + "\">" + currency.CURRNAME + "</option>");

        //        });
        //    },
        //    error: function (ex) {
        //        alert("Failed to retrieve states." + ex);
        //    }
        //});

        //========================================================================================================================
        //===============================GETTING THE CURRENCY INFO IN FIELD CURRENCYRATE============================================
        $("#NewApplication_ValueDate").change(function () {

            if (!$("#NewApplication_Currency").isEmpty) {
                $.ajax({
                    type: "GET",
                    url: '@Url.Action("GetCurrencyRateOnSpecificDate")',
                    dataType: "json",
                    data: { currencyCode: $("#NewApplication_Currency").val(), date: $("#NewApplication_ValueDate").val() },
                    success: function (currencyRateThisDay) {

                        $("#NewApplication_CurrencyRate").val(currencyRateThisDay);
                    },
                    error: function (ex) {
                        alert("Failed to retrieve states." + ex);
                    }
                });
            }
        });
        $("#NewApplication_Currency").change(function () {

            if (!$("#NewApplication_ValueDate").isEmpty) {
                $.ajax({
                    type: "GET",
                    url: '@Url.Action("GetCurrencyRateOnSpecificDate")',
                    dataType: "json",
                    data: { currencyCode: $("#NewApplication_Currency").val(), date: $("#NewApplication_ValueDate").val() },
                    success: function (currencyRateThisDay) {

                        $("#NewApplication_CurrencyRate").val(currencyRateThisDay);
                    },
                    error: function (ex) {
                        alert("Failed to retrieve states." + ex);
                    }
                });
            }
        });
        //=======================================================================================================================

        //===========================GETTING THE EXHOUSE INFO IN FIELD EXHOUSE AUTOCOMPLETE==========================================
        $("#NewApplication_ExHouseOrBank").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "GET",
                    url: '@Url.Action("GetExchangeHouseInfo")',
                    dataType: "json",
                    data: { searchText: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.EXNAME,
                                value: item.EXNAME
                            }
                        })
                        );
                    }
                });
            }
        });
        //========================================================================================================================
        //==================================GETTING THE DENOMINATION INFO IN FIELD PREFIX BASED ON BONDTYPE SELECTION VALUE===========
        $("#BONDCODE").change(function () {

            $("#Denomination").empty();
            $("#Prefix").empty();

            $.ajax({
                type: "GET",
                //url: '@Url.Action("GetBondScriptDenoInfo")',
                url:"/Application/GetBondScriptDenoInfo",
                dataType: "json",
                data: { bondTypeIndex: $("#BONDCODE").val() },
                success: function (scriptDenos) {
                    $.each(scriptDenos, function (i, item) {
                        $("#Denomination").append("<option value=\"" + item.BONDVALUE + "\">" + item.BONDVALUE + "</option>");
                        //$("#NewApplication_Prefix").append("<option value=\"" + item.BONDPREFIX + "\">" + item.BONDPREFIX + "</option>");

                    });
                },
                error: function (ex) {
                    alert("Failed to retrieve states." + ex);
                }
            });

        });

        $("#Denomination").change(function () {

            $("#Prefix").empty();

            $.ajax({
                type: "GET",
                //url: '@Url.Action("GetBondScriptPrefixInfo")',
                url:'/Application/GetBondScriptPrefixInfo',
                dataType: "json",
                data: { denominationValue: $("#Denomination").val(), bondTypeIndex: $("#BONDCODE").val() },
                success: function (scriptDenos) {
                    $.each(scriptDenos, function (i, item) {
                        $("#Prefix").val(item.BONDPREFIX);
                        $("#Prefix").text(item.BONDPREFIX);
                    });
                },
                error: function (ex) {
                    alert("Failed to retrieve states." + ex);
                }
            });

        });

        //========================================================================================================================


        //$.ajax({
        //    type: "GET",
        //    url: '@Url.Action("GetExchangeHouseInfo")',
        //    dataType: "json",
        //    success: function (exhouses) {

        //        $("#NewApplication_ExHouseOrBank").autocomplete({
        //            source: exhouses
        //        });
        //    },
        //    error: function (ex) {
        //        alert("Failed to retrieve states." + ex);
        //    }
        //});

        //========================copy value of NewApplication_TotalScript to NewApplication_TotalNoOfScript============================
        $("#TOTALSCRIPT").keyup(function () {
            $("#TotalNoOfScript").val($(this).val());
        });
        //==============================================================================================================================
        //======================copy value of NewApplication_AmountForCredit to NewApplication_TotalAmount==============================
        $("#AMOUNTCR").keyup(function () {
            $("#Total_Amount").val($(this).val());

        });
        //==============================================================================================================================
        //==========================================generateScript Button Click ========================================================

        $("#generateScript").on("click", function (e) {

            e.preventDefault();
            var prefix = $("#Prefix").val();
            var scriptForNominee = $("#TotalNoOfScrrptForThisNominee").val();
            var bondStartNo = $("#StartNo").val();
            var nomineeName = $("#NomineeName").val();
            var relation = $("#Relation").val();
            var totalNoOfScript = $("#TotalNoOfScript").val();
            var denomination = $("#Denomination").val();
            var bondScn = $("#BONDSCN").val();
            var bondCode = $("#BONDCODE").val();
            //var rowCount = $('table#scriptTable tr:last').index() + 1;
            var rowCount = $("#scriptTable > tbody").children().length;

            $.ajax({
                type: "GET",
                url:"/Application/GetBondScriptInfo",
                //url: '@Url.Action("GetBondScriptInfo")',
                dataType: "json",
                data: {
                    prefix: prefix, totalNoOfScriptForThisNominee: scriptForNominee,
                    bondStartNo: bondStartNo, nomineeName: nomineeName, relation: relation,
                    totalNoOfScript: totalNoOfScript, denomination: denomination, rowCount: rowCount, bondScn: bondScn, bondCode: bondCode
                },
                success: function (scriptDenos) {
                    $.each(scriptDenos, function (i, item) {
                        var date = moment(item.MaturityDate);
                        var tr = (
                                  '<tr>' +
                                    '<td>' + item.SerialNo + '</td>' +
                                    '<td>' + item.Prefix + '</td>' +
                                    '<td>' + item.BondNo + '</td>' +
                                    '<td>' + item.Value + '</td>' +
                                    '<td>' + date.format("DD/MM/YYYY") + '</td>' +
                                    '<td>' + item.NomineeName + '</td>' +
                                    '<td>' + item.Relation + '</td>' +
                                    '<td>' + item.AmountPaid + '</td>' +
                                  '</tr>'
                                );
                        $("#scriptTable").append(tr);
                    });

                },
                error: function (ex) {
                    alert("Select Denomination, Nominee Name, Relation, Total No Of Script, Bond Start No.");
                }
            });

        });
    //==============================================================================================================================
    //============================================CLEAR BLOCK BUTTON CLICK =========================================================

        $("#clearBlock").on("click", function (e) {

            e.preventDefault();
            //var prefix = $("#Prefix").val();
            //var scriptForNominee = $("#TotalNoOfScrrptForThisNominee").val();
            $.ajax({
                type: "GET",
                url:"/Application/ClearBlock",
                //url: '@Url.Action("GetBondScriptInfo")',
                dataType: "json",
                success: function (message) {
                    $("#scriptTable").find("tr:gt(0)").remove();
                
                },
                error: function (ex) {
                    alert("failed to clear block.");
                }
            });

        });
        //==============================================================================================================================
        //==========================================DROPDOWNLIST FOR ISSUING BRANCH=====================================================

        $("#NewApplication_IssueingBranch").focus(function () {

            $("#NewApplication_IssueingBranch").empty();

            $.ajax({
                type: "GET",
                url: '@Url.Action("GetIssuingBranch")',
                dataType: "json",
                success: function (branches) {

                    $.each(branches, function (i, item) {

                        $("#NewApplication_IssueingBranch").append("<option value=\"" + item.BRCODE + "\">" + item.BRNAME + "</option>");

                    });
                },
                error: function (ex) {
                    alert("Please Try Again." + ex);
                }
            });

        });
    //===============================================================================================================================+
    //========================================VALIDATION STYLING=====================================================================
        (function ($) {
        var defaultOptions = {
            validClass: 'has-success',
            errorClass: 'has-error',
            highlight: function (element, errorClass, validClass) {
                $(element).closest(".form-group")
                    .removeClass(validClass)
                    .addClass('has-error');
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).closest(".form-group")
                .removeClass('has-error')
                .addClass(validClass);
            }
        };
     
        $.validator.setDefaults(defaultOptions);
     
        $.validator.unobtrusive.options = {
            errorClass: defaultOptions.errorClass,
            validClass: defaultOptions.validClass,
        };
        })(jQuery);
    //=====================================================================================================================================
 







});


