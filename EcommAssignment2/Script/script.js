function updateAccount() {
    var username = document.getElementById("profileUsernameInput").value;
    var password = document.getElementById("profilePassInput").value;

    if (verifyInputs()) {
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.open("GET", "ProfilePageCompletion.aspx?user=" + username + "&pass=" + password, false);
        xmlhttp.send(null);
        document.getElementById("profileUsernameInput").value = "";
        document.getElementById("profilePassInput").value = "";
        document.getElementById("profileConfirmPassInput").value = "";
    }
}