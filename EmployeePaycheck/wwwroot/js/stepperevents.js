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

    let showContinueToPackcheckData = document.getElementById('subject');

    if (showContinueToPackcheckData) {
        if (showContinueToPackcheckData.value == 'Verified Employee') {
            document.getElementById("buttonVerifyEmployeePaycheck").style.display = 'block';
        } else {
            document.getElementById("buttonVerifyEmployeePaycheck").style.display = 'none';
        }
    }
});
