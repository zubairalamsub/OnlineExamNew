const loadAllLedgerCategories = (selectTagId, selectedValue) => {
    $.ajax({
        type: "GET",
        url: "/api/GetAllLedgerCategories/",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data != null) {
                AllCurrentLedgerSubCategoryList = data;
                $("#GroupName").html('');
                var strHtml = "";
                //console.log(data);
                //strHtml += "<option value='-1'>Select Category</option>";
                //$.each(data, function (i, category) {
                //    strHtml += "<option value='" + category.id + "'>" + category.name + "</option>";
                //});
                $("#" + selectTagId + "").empty();
                //$("#" + selectTagId + "").append('<option value="-1" selected>Select Category</option>');
                $.each(data, function (i, category) {
                    $("#" + selectTagId + "").append('<option value="' + category.id + '">' + category.name + '</option>');
                });
                if (selectedValue != null) {
                    $("#" + selectTagId + " option").prop('selected', false)
                        .filter("[value='" + selectedValue + "']")
                        .prop('selected', true);
                    if (window.location.href.includes("Edit")) {
                        let categoryName = $("#Category option:selected").text().trim();
                        loadAllLedgerSubGroups(categoryName, 'SubGroups', 'SubSubGroups', '', parseInt(SelectedLedgerCategory.under.split(',')[1]), parseInt(SelectedLedgerCategory.under.split(',')[2]));
                        //set Category
                        let subCategoryId = $("#SubGroups option:selected").val();
                        for (let i = 0; i < AllCurrentLedgerSubCategoryList.length; i++) {
                            if (AllCurrentLedgerSubCategoryList[i].id == subCategoryId) {
                                SelectedNewLedgerCategory = AllCurrentLedgerSubCategoryList[i];
                            }
                        }
                    }
                }
                //$("#GroupName").html(strHtml);
            }
            else {
                alert("Server Error.")
            }
        }
    });
}
const loadAllLedgerSubGroups = (categoryName, selectTagId, selectTagIdTwo, selectTagIdThree, selectedValue,selectedValueTwo) => {
    //let categoryName = $("#GroupName option:selected").text().trim();
    $.ajax({
        type: "GET",
        url: "/api/GetAllLedgerSubCategories/" + categoryName,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data != null) {
                AllCurrentLedgerSubCategoryList = data;
                $("#" + selectTagId + "").empty();
                $("#" + selectTagIdTwo + "").empty();
                $("#" + selectTagIdThree + "").empty();
                
                $.each(data, function (i, category) {
                    if (category.levelNo == 1) {
                        $("#" + selectTagId + "").append('<option value="' + category.id + '">' + category.name + '</option>');
                    }
                    else if (category.levelNo == 2) {
                        $("#" + selectTagIdTwo + "").append('<option value="' + category.id + '">' + category.name + '</option>');
                    }
                    else if (category.levelNo == 3) {
                        if (selectTagIdThree != '') {
                            $("#" + selectTagIdThree + "").append('<option value="' + category.id + '">' + category.name + '</option>');
                        }
                    }
                });
                if (selectedValue != null) {
                    try {
                        $("#" + selectTagId + " option").prop('selected', false)
                            .filter("[value='" + selectedValue + "']")
                            .prop('selected', true);
                    }
                    catch (e) {
                        throw e;
                    }
                    try {
                        $("#" + selectTagIdTwo + " option").prop('selected', false)
                            .filter("[value='" + selectedValueTwo + "']")
                            .prop('selected', true);
                    }
                    catch (e) {
                        throw e;
                    }
                    //try {
                    //    if (selectTagIdThree != '') {
                    //        $("#" + selectTagIdThree + " option").prop('selected', false)
                    //            .filter("[value='" + selectedValue + "']")
                    //            .prop('selected', true);
                    //    }

                    //}
                    //catch (e) {
                    //    throw e;
                    //}
                }
                //set Sub Category
                let subCategoryId = $("#SubSubGroups option:selected").val();
                for (let i = 0; i < AllCurrentLedgerSubCategoryList.length; i++) {
                    if (AllCurrentLedgerSubCategoryList[i].id == subCategoryId) {
                        SelectedNewLedgerCategory = AllCurrentLedgerSubCategoryList[i];
                    }
                }
            }
            else {
                alert("Server Error.");
            }
        }
    });
}