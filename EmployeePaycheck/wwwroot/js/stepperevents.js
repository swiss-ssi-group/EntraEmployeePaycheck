$(document).ready(function () {
    function paycheckEnterIdSubmit(e) {
        e.preventDefault();
        let form = document.getElementById("paycheckEnterId");

        if (form) form.submit();

        return false;
    }

    let buttonPaycheckEnterIdSubmit = document.getElementById("buttonPaycheckEnterId");
    if (buttonPaycheckEnterIdSubmit) {
        buttonPaycheckEnterIdSubmit.onclick = paycheckEnterIdSubmit;
    }

    function verifyEmployeePaycheckSubmit(e) {
        e.preventDefault();

        let form = document.getElementById("verifyEmployeePaycheck");

        if (form) form.submit();

        return false;
    }

    let buttonVerifyEmployeePaycheckSubmit = document.getElementById("buttonVerifyEmployeePaycheck");
    if (buttonVerifyEmployeePaycheckSubmit) {
        buttonVerifyEmployeePaycheckSubmit.onclick = verifyEmployeePaycheckSubmit;
    }

});
