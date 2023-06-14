var isBalanced = false;

function selectVariant() {
    var selectElement = document.getElementById("variantSelect");
    var selectedIndex = selectElement.selectedIndex;
    var selectedOption = selectElement.options[selectedIndex];
    var R0x = selectedOption.getAttribute("data-r0x");

    document.getElementById("R0x").value = R0x;

    document.getElementById("Ra").value = "0.1";
    document.getElementById("Rm").value = "0.1";
    document.getElementById("Rn").value = "0.1";
    document.getElementById("RM").value = "0.1";
    document.getElementById("RN").value = "0.1";
    document.getElementById("U").value = "";
    document.getElementById("Rx").value = "";

    checkUValue();
}

function calculateU(Rx, R0x) {
    $.ajax({
        url: '/Home/CalculateVoltage',
        type: 'POST',
        data: { Rx: Rx, R0x: R0x },
        success: function (response) {
            document.getElementById("U").value = parseFloat(response).toFixed(3);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function calculateK(Rx, R0x) {
    $.ajax({
        url: '/Home/CalculateK',
        type: 'POST',
        data: { Rx: Rx, R0x: R0x },
        success: function (response) {
            isBalanced = response;
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function check() {
    if (document.getElementById("R0x").value != "") {
        calculateK(document.getElementById("Rx").value, document.getElementById("R0x").value);
        setTimeout(function () {
            if (isBalanced) {
                $('#finishModal').modal('show');
            }
            else {
                $('#kModal').modal('show');
            }
        }, 100);
    }
    else {
        $('#variantSelectModal').modal('show');
    }
}

function changeFields() {
    calculateResult();
    calculateU(document.getElementById("Rx").value, document.getElementById("R0x").value);
    checkUValue();
}

function calculateResult() {
    var Ra = parseFloat(document.getElementById("Ra").value);
    var RM = parseFloat(document.getElementById("RM").value);
    var RN = parseFloat(document.getElementById("RN").value);

    if (isNaN(Ra) || isNaN(RM) || isNaN(RN)) {
        $('#myModal').modal('show');
    } else {
        $.ajax({
            url: '/Home/CalculateResult',
            type: 'POST',
            data: { Ra: Ra, RM: RM, RN: RN },
            success: function (response) {
                document.getElementById("Rx").value = parseFloat(response).toFixed(3);
                calculateU(document.getElementById("Rx").value, document.getElementById("R0x").value);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
}

function resetFields() {
    document.getElementById("variantSelect").selectedIndex = 0;
    document.getElementById("Ra").value = "0.1";
    document.getElementById("Rm").value = "0.1";
    document.getElementById("Rn").value = "0.1";
    document.getElementById("RM").value = "0.1";
    document.getElementById("RN").value = "0.1";
    document.getElementById("U").value = "";
    document.getElementById("Rx").value = "";
    document.getElementById("R0x").value = "";
    document.getElementById("buttonResult").disabled = false;
}

function closeModal(name) {
    $('#' + name).modal('hide');
}

function checkUValue() {
    setTimeout(function () {
        var vInput = document.getElementById("U");
        var calculateButton = document.getElementById("buttonResult");

        if (vInput.value === '' || isNaN(parseFloat(vInput.value))) {
            calculateButton.disabled = true;
        } else {
            if (parseFloat(vInput.value) <= 0.005) {
                calculateButton.disabled = false;
            } else {
                calculateButton.disabled = true;
            }
        }
    }, 100);
}

function validateInput(input) {
    var value = parseFloat(input.value);

    if (isNaN(value) || value < 0.1) {
        input.value = "0.1";
    } else if (value > 500) {
        input.value = "500";
    }
}