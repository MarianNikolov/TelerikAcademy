function ClickOnTheButton(ev, args) {
    var myWindow = window,
        browser = myWindow.navigator.appCodeName,
        IsMozillaBrowser = browser === "Mozilla";

    if (IsMozillaBrowser) {
        alert("Yes");
    } else {
        alert("No");
    }
}