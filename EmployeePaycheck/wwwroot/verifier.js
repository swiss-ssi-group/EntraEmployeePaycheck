
var qrcode = new QRCode("qrcode", {width: 300, height: 300 });
var respPresentationReq = null;

function displayInit() {
    console.log('displayInit');
    document.getElementById('message-wrapper').style.display = "none";  
}

function displayGenerateQRCode() {
    console.log('displayGenerateQRCode');
    document.getElementById('message-generate-vc-presentation').style.display = "none";
    document.getElementById('message-wrapper').style.display = "block";
    document.getElementById('messageDisplay').innerHTML = 'Scan the QR Code using your wallet to verify';
    document.getElementById('qrText').style.display = "block";
}

function displayRequestRetrieved() {
    console.log('displayRequestRetrieved');
    document.getElementById('message-wrapper').style.display = "block";
    document.getElementById('qrText').style.display = "none";
    document.getElementById('qrcode').style.display = "none";
    console.log('VC API response message: ' + respMsg.message);
    document.getElementById('messageDisplay').innerHTML = 'Please consent and share your data to complete verification';
}

function displayPresentationVerified() {
    console.log('displayPresentationVerified');
    document.getElementById('message-wrapper').style.display = "block";
    document.getElementById('message-wrapper-icon').style.display = "block";
    document.getElementById('subject').innerHTML = "Verified Employee";
    //document.getElementById('payload').innerHTML = "Payload: " + JSON.stringify(respMsg.payload);
    document.getElementById('statePresented').value = respPresentationReq.id;
    document.getElementById('messageDisplay').innerHTML = '';

    // stepper control button
    document.getElementById("buttonVerifyEmployeePaycheck").style.display = 'block';
}

function displayError(error) {
    console.log(error);
    document.getElementById('message-error').style.display = "block";
    document.getElementById('messageError').innerHTML = error;
    document.getElementById('message-wrapper').style.display = "none";
    document.getElementById('qrText').style.display = "none";
    document.getElementById('qrcode').style.display = "none";  
}

window.addEventListener('load', () => {
    
    fetch('/api/verifier/presentation-request')
        .then(function (response) {
            displayInit();
            response.text()
                .catch(error => { displayError(error); })
                .then(function (message) {
                    respPresentationReq = JSON.parse(message);
                    if (/Android/i.test(navigator.userAgent)) {
                        console.log(`Android device! Using deep link (${respPresentationReq.url}).`);
                        window.location.href = respPresentationReq.url; setTimeout(function () {
                            window.location.href = "https://play.google.com/store/apps/details?id=com.azure.authenticator";
                        }, 5000);
                    } else if (/iPhone/i.test(navigator.userAgent)) {
                        console.log(`iOS device! Using deep link (${respPresentationReq.url}).`);
                        window.location.replace(respPresentationReq.url);
                    } else {
                       
                        if (message.includes('error_description')) {
                            displayError(message);
                        }
                        else {
                            console.log(`Not Android or IOS. Generating QR code encoded with ${message}`);
                            displayGenerateQRCode();
                            qrcode.makeCode(respPresentationReq.url);
                        }
                    }
                }).catch(error => { displayError(error);  })
        }).catch(error => { displayError(error); })

    var checkStatus = setInterval(function () {
        if(respPresentationReq){
            fetch('api/verifier/presentation-response?id=' + respPresentationReq.id)
                .then(response => response.text())
                .catch(error => { displayError(error); })
                .then(response => {
                    if (response.length > 0) {
                        console.log(response)
                        respMsg = JSON.parse(response);
                        // QR Code scanned
                        if (respMsg.status == 'request_retrieved') {
                            displayRequestRetrieved();
                        }

                        if (respMsg.status == 'presentation_verified') {
                            displayPresentationVerified();
                            clearInterval(checkStatus);
                        }
                    }
                })
        }
            
    }, 1500); //change this to higher interval if you use ngrok to prevent overloading the free tier service
})
