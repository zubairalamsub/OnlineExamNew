const tableStyleElementRight = `style='text-align:right;border-right:1px solid black;padding:1px 2px 1px 0px;'`;
const tableStyleElementLeft = `style='text-align:left;border-right:1px solid black;padding:1px 0px 1px 2px;'`;
const tableStyleElementCenter = `style='text-align:center;border-right:1px solid black;padding:1px 0px 1px 2px;'`;
const loaderHtml = `<div class="spiner-example"><div class="sk-spinner sk-spinner-wave"><div class="sk-rect1"></div> <div class="sk-rect2"></div> <div class="sk-rect3"></div> <div class="sk-rect4"></div> <div class="sk-rect5"></div> </div></div>`;
const getfullNameNew = () => {
  var obj = {};
  obj = document.cookie.split(";");
  for (var i = 0; i < obj.length; i++) {
    if (obj[i].includes("dtuserid")) {
      var arr = [];
      arr = obj[i].split("=");
      localStorage.setItem("DtUserId", JSON.stringify(arr[1]));
      //JSON.parse(localStorage.getItem('UserId'))
    }
    if (obj[i].includes("dtfullname")) {
      var arr = [];
      arr = obj[i].split("=");
      return arr[1].replace(/%20/g, " ");
    }
  }
};
const posTwo = dateNumber => {
  return dateNumber < 10 ? "0" + dateNumber : dateNumber;
};
const getFromDateToDate = (FromDateId, ToDateId) => {
  let today = new Date();
  if (FromDateId != null) {
    let firstDate =
      today.getFullYear() + "-" + posTwo(today.getMonth() + 1) + "-01";
    $("#" + FromDateId).val(firstDate);
  }
  if (ToDateId != null) {
    let toDate =
      today.getFullYear() +
      "-" +
      posTwo(today.getMonth() + 1) +
      "-" +
      posTwo(today.getDate());
    $("#" + ToDateId).val(toDate);
  }
};
const getTodayString = () => {
  let today = new Date();
  dateString =
    today.getDate() + "/" + (today.getMonth() + 1) + "/" + today.getFullYear();
  return dateString;
};
const getCurrentTimeString = () => {
  let date = new Date();
  var hours = date.getHours();
  var minutes = date.getMinutes();
  let seconds = date.getSeconds();
  var ampm = hours >= 12 ? "pm" : "am";
  hours = hours % 12;
  hours = hours ? hours : 12; // the hour '0' should be '12'
  minutes = minutes < 10 ? "0" + minutes : minutes;
  var strTime = hours + ":" + minutes + ":" + seconds + " " + ampm;
  return strTime;
};
const LoadLedgerListNew = (selectTagId, selectedValue) => {
  var options = {};
  options.url = "/api/GetLedger/";
  options.type = "GET";
  options.contentType = "application/json";
  options.dataType = "html";
  (options.success = function(data) {
    var strHtml = "<option value='0'>Select Ledger</option>";
    $.each(JSON.parse(data), function(key, value) {
      strHtml += "<option value='" + value.id + "'>" + value.name + "</option>";
    });
    if (strHtml != "")
      $("#" + selectTagId)
        .html(strHtml)
        .show();
    else
      $("#" + selectTagId)
        .html("")
        .hide();
    if (selectedValue != null) {
      $("#" + selectTagId + " option")
        .prop("selected", false)
        .filter("[value='" + selectedValue + "']")
        .prop("selected", true);
    }
  }),
    (options.error = function() {
      alert("Error while calling the Web API!");
    });
  $("#pleaseWaitDialog").show();
  $.ajax(options);
  $("#pleaseWaitDialog").hide();
};
const LoadOnlyLedgerList = (selectTagId, selectedValue) => {
  var options = {};
  options.url = "/api/GetOnlyLedger/";
  options.type = "GET";
  options.contentType = "application/json";
  options.dataType = "html";
  (options.success = function(data) {
    var strHtml = "<option value='0'>Select Ledger</option>";
    strHtml += "<option value='1'>Asset</option>";
    strHtml += "<option value='2'>Capital</option>";
    strHtml += "<option value='3'>Expense</option>";
    strHtml += "<option value='4'>Liability</option>";
    strHtml += "<option value='5'>Revenue</option>";
    $.each(JSON.parse(data), function(key, value) {
      strHtml += "<option value='" + value.id + "'>" + value.name + "</option>";
    });
    if (strHtml != "")
      $("#" + selectTagId)
        .html(strHtml)
        .show();
    else
      $("#" + selectTagId)
        .html("")
        .hide();
    if (selectedValue != null) {
      $("#" + selectTagId + " option")
        .prop("selected", false)
        .filter("[value='" + selectedValue + "']")
        .prop("selected", true);
    }
  }),
    (options.error = function() {
      alert("Error while calling the Web API!");
    });
  $("#pleaseWaitDialog").show();
  $.ajax(options);
  $("#pleaseWaitDialog").hide();
};

const GetMerchantListNew = strkey => {
  var options = {};
  options.url = "/api/GetMerchantListByKey/" + strkey;
  options.type = "GET";
  options.contentType = "application/json";
  options.dataType = "html";
  (options.success = function(data) {
    var strHtml = "";
    $.each(JSON.parse(data), function(key, value) {
      strHtml += "<option value='" + value.id + "'>" + value.name + "</option>";
    });
    if (strHtml != "")
      $("#merchantList")
        .html(strHtml)
        .show();
    else
      $("#merchantList")
        .html("")
        .hide();
  }),
    (options.error = function() {
      alert("Error while calling the Web API!");
    });
  $("#pleaseWaitDialog").show();
  $.ajax(options);
  $("#pleaseWaitDialog").hide();
};

const GetBankList = (strkey, b) => {
  var options = {};
  options.url = "/api/GetBankListByKey/" + strkey + "/" + b;
  options.type = "GET";
  options.contentType = "application/json";
  options.dataType = "html";
  (options.success = function(data) {
    var strHtml = "";
    $.each(JSON.parse(data), function(key, value) {
      strHtml +=
        "<option value='" +
        value.bankName +
        "'>" +
        value.bankName +
        "</option>";
    });
    if (strHtml != "")
      $("#bankNameList")
        .html(strHtml)
        .show();
    else
      $("#bankNameList")
        .html("")
        .hide();
  }),
    (options.error = function() {
      alert("Error while calling the Web API!");
    });
  $("#pleaseWaitDialog").show();
  $.ajax(options);
  $("#pleaseWaitDialog").hide();
};
const GetBranchList = (strkey, bankName) => {
  var options = {};
  options.url = "/api/GetBankListByKey/" + strkey + "/" + bankName;
  options.type = "GET";
  options.contentType = "application/json";
  options.dataType = "html";
  (options.success = function(data) {
    var strHtml = "";
    $.each(JSON.parse(data), function(key, value) {
      strHtml +=
        "<option value='" +
        value.routingNo +
        "'>" +
        value.branchName +
        "</option>";
    });
    if (strHtml != "")
      $("#branchNameList")
        .html(strHtml)
        .show();
    else
      $("#branchNameList")
        .html("")
        .hide();
  }),
    (options.error = function() {
      alert("Error while calling the Web API!");
    });
  $("#pleaseWaitDialog").show();
  $.ajax(options);
  $("#pleaseWaitDialog").hide();
};

const GetDeliveryUsersList = strkey => {
  var options = {};
  options.url = "/api/LoadAllDeliveryUsers/" + strkey;
  options.type = "GET";
  options.contentType = "application/json";
  options.dataType = "html";
  (options.success = function(data) {
    var strHtml = "";
    $.each(JSON.parse(data), function(key, value) {
      strHtml +=
        "<option value='" +
        value.id +
        "'>" +
        value.name +
        "(" +
        value.id +
        ")" +
        "</option>";
    });
    if (strHtml != "")
      $("#merchantList")
        .html(strHtml)
        .show();
    else
      $("#merchantList")
        .html("")
        .hide();
  }),
    (options.error = function() {
      alert("Error while calling the Web API!");
    });
  $("#pleaseWaitDialog").show();
  $.ajax(options);
  $("#pleaseWaitDialog").hide();
};

const topRowBuilder = (merchantName, contactNo, reportName, dateString) => {
  let topRow = `<table style='width:100%;margin:10px 0px 0px 0px;'>
                        <tr>
                            <td style='width:250px;text-align:left;'>
                                <img src='/images/logo_1.png' alt='Logo Image' width='100px'/>
                            </td>
                            <td style='width:auto;text-align:right;'>
                                <span>${
                                  merchantName == ""
                                    ? ``
                                    : `Merchant Name: ${merchantName}`
                                }</span></br>
                                ${
                                  contactNo != ""
                                    ? `<span>Contact No.: ${contactNo}</span>`
                                    : ``
                                }
                            </td>
                        </tr>
                        <tr>
                            <td colspan='2' style='width:100%;text-align:center;'>
                                <h3 style='margin:2px 0px 2px 0px;'>${merchantName}</h3>
                                <span>${reportName}</span></br>
                                <span>${dateString}</span>
                            </td>
                        </tr>
                       </table>`;
  return topRow;
};
const viewingDateBuidler = date => {
  let viewingDate = `<label style='margin: 5px 0px 5px 2px;text-align: left;font-weight:400;font-size:10px;'>Date: ${date}</label>`;
  return viewingDate;
};
const bottomRowBuilder = () => {
  let bottomRow = `<table style='width:100%;margin:10px 0px 10px 0px;'>
                            <tr>
                                <td style='width:33.3%'>Prepared By</br>Executive, Accounts & Finance</br>Delivery Tiger</td>
                                <td style='width:33.3%'>Checked By</br>Head of Accounts</br>Delivery Tiger</td>
                                <td style='width:33.3%'>Approved By</br>Director</br>Delivery Tiger</td>
                            </tr>
                         </table>`;
  return bottomRow;
};
const footerRowBuilder = () => {
  let footerRow = `<table style='width:100%;border:1px solid black;margin:20px 0px 10px 0px;'>
                            <tr>
                                <td style='width:100%;text-align:center;'>Delivery Tiger Address: Sumona Goni Trade Center, Plot no. 2, Level-5, Panthapath, Karwan Bazar, Dhaka-1215</td>
                            </tr>
                         </table>`;
  return footerRow;
};
const amountInWordBuilder = amount => {
  let amountInWordRow = `<table style='width:100%;border:1px solid black;margin:10px 0px 10px 0px;'>
                                <tr>
                                    <td style='width:100%;text-align:left;'><b>Amount In Word : </b> ${convertNumberToWords(
                                      amount
                                    )} Taka Only</td>
                                </tr>
                               </table>`;
  return amountInWordRow;
};
const convertNumberToWords = amount => {
  var words = new Array();
  words[0] = "";
  words[1] = "One";
  words[2] = "Two";
  words[3] = "Three";
  words[4] = "Four";
  words[5] = "Five";
  words[6] = "Six";
  words[7] = "Seven";
  words[8] = "Eight";
  words[9] = "Nine";
  words[10] = "Ten";
  words[11] = "Eleven";
  words[12] = "Twelve";
  words[13] = "Thirteen";
  words[14] = "Fourteen";
  words[15] = "Fifteen";
  words[16] = "Sixteen";
  words[17] = "Seventeen";
  words[18] = "Eighteen";
  words[19] = "Nineteen";
  words[20] = "Twenty";
  words[30] = "Thirty";
  words[40] = "Forty";
  words[50] = "Fifty";
  words[60] = "Sixty";
  words[70] = "Seventy";
  words[80] = "Eighty";
  words[90] = "Ninety";
  amount = amount.toString();
  var atemp = amount.split(".");
  var number = atemp[0].split(",").join("");
  var n_length = number.length;
  var words_string = "";
  if (n_length <= 9) {
    var n_array = new Array(0, 0, 0, 0, 0, 0, 0, 0, 0);
    var received_n_array = new Array();
    for (var i = 0; i < n_length; i++) {
      received_n_array[i] = number.substr(i, 1);
    }
    for (var i = 9 - n_length, j = 0; i < 9; i++, j++) {
      n_array[i] = received_n_array[j];
    }
    for (var i = 0, j = 1; i < 9; i++, j++) {
      if (i == 0 || i == 2 || i == 4 || i == 7) {
        if (n_array[i] == 1) {
          n_array[j] = 10 + parseInt(n_array[j]);
          n_array[i] = 0;
        }
      }
    }
    value = "";
    for (var i = 0; i < 9; i++) {
      if (i == 0 || i == 2 || i == 4 || i == 7) {
        value = n_array[i] * 10;
      } else {
        value = n_array[i];
      }
      if (value != 0) {
        words_string += words[value] + " ";
      }
      if (
        (i == 1 && value != 0) ||
        (i == 0 && value != 0 && n_array[i + 1] == 0)
      ) {
        words_string += "Crores ";
      }
      if (
        (i == 3 && value != 0) ||
        (i == 2 && value != 0 && n_array[i + 1] == 0)
      ) {
        words_string += "Lakhs ";
      }
      if (
        (i == 5 && value != 0) ||
        (i == 4 && value != 0 && n_array[i + 1] == 0)
      ) {
        words_string += "Thousand ";
      }
      if (
        i == 6 &&
        value != 0 &&
        (n_array[i + 1] != 0 && n_array[i + 2] != 0)
      ) {
        words_string += "Hundred and ";
      } else if (i == 6 && value != 0) {
        words_string += "Hundred ";
      }
    }
    words_string = words_string.split("  ").join(" ");
  }
  return words_string;
};
const CreateExcelSheet = divName => {
  window.open(
    "data:application/vnd.ms-excel," + escape($("#" + divName).html())
  );
  e.preventDefault();
};
const CreatePDF = divName => {
  var options = {};
  var pdf = new jsPDF("p", "pt", "a4");
  pdf.addHTML($("#" + divName + ""), 15, 15, options, function() {
    options = { format: "PNG", background: "#fff" };
    pdf.save("ReceivableStatement.pdf");
  });
};
const numberToAmount = num => {
  let amountConvertar = new Intl.NumberFormat("en-In", {}).format(num);
  return amountConvertar;
};
const PopUp = data => {
  let mywindow = window.open("", "myDiv", "height=500,width=600");
  mywindow.document.write("<html><head><title></title>");
  mywindow.document.write("</head><body >");
  mywindow.document.write(data);
  mywindow.document.write("</body></html>");

  mywindow.document.close();
  mywindow.focus();

  mywindow.print();
  mywindow.close();
  return true;
};
const fixString = input => {
  let output = input.replace(/(\r\n|\n|\r)/gm, ""); //remove line breaks
  output = output.replace(/ +(?= )/g, ""); // remove multiple spaces
  return output;
};
const getPaymentMethods = element => {
  $.ajax({
    beforesend: () => {
      //$("#showLoader").show();
    },
    type: "Get",
    url: "/Report/GetPaymentMethods".toLowerCase(),
    contentType: "application/json; charset=utf-8",
    datatype: "json",
    success: function(paymentMethodObj) {
      //$("#showLoader").hide();
      if (paymentMethodObj) {
        drawPaymentMethod(element, paymentMethodObj);
      } else {
        alert("Failed To Load Payments Methods");
      }
    },
    error: function(a, b) {
      alert("Something went wrong when loading Payments Methods Api");
    }
  });
};
const drawPaymentMethod = (element, data) => {
  let html = '<option value="0">--Payment Method--</option>';

  for (let i = 0; i < data.length; i++) {
    html += `<option value="${data[i].PayMethodID}">${
      data[i].MethodName
    }</option>`;
  }
  element.html(html);
};
