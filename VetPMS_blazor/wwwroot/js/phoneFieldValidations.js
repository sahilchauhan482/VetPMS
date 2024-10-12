function AllowOnlyNumbers(event) {
    const keyCode = event.keyCode || event.which;
    const input = event.target;

    // Allow backspace, delete, tab, escape, enter, and .
    if ([8, 46, 9, 27, 13, 110, 190].indexOf(keyCode) !== -1 ||
        // Allow: Ctrl+A, Ctrl+C, Ctrl+V, Ctrl+X
        (keyCode === 65 && event.ctrlKey === true) ||
        (keyCode === 67 && event.ctrlKey === true) ||
        (keyCode === 86 && event.ctrlKey === true) ||
        (keyCode === 88 && event.ctrlKey === true) ||
        // Allow: home, end, left, right, down, up
        (keyCode >= 35 && keyCode <= 40)) {
        // Let it happen, don't do anything
        return;
    }

    // Ensure that it is a number and stop the keypress if not
    if ((event.shiftKey || (keyCode < 48 || keyCode > 57)) && (keyCode < 96 || keyCode > 105)) {
        event.preventDefault();
    }

    // Prevent input if length is greater than or equal to 10
    if (input.value.length >= 10) {
        event.preventDefault();
    }
}

function PreventNonNumericPaste(event) {
    const pasteData = (event.clipboardData || window.clipboardData).getData('text');

    if (!/^\d+$/.test(pasteData) || (event.target.value.length + pasteData.length > 10)) {
        event.preventDefault();
    }
}

function PreventNonNumericDrop(event) {
    const data = event.dataTransfer.getData('text');

    if (!/^\d+$/.test(data) || (event.target.value.length + data.length > 10)) {
        event.preventDefault();
    }
}



document.addEventListener('DOMContentLoaded', (event) => {
    addEventListenersToPhoneInput();
});
function addEventListenersToPhoneInput() {
    const input = document.getElementById('phone');
    if (input) {
        input.addEventListener('paste', PreventNonNumericPaste);
        input.addEventListener('drop', PreventNonNumericDrop);
        input.addEventListener('dragover', function (event) {
            event.preventDefault();
        });
    }
}


