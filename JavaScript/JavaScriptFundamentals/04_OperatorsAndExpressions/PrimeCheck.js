function solve(args) {
    var n = +args[0];

    if (n > 0) {
        for (var i = 2; i < n; i++) {
            if (n % i == 0) {
                console.log("false");
                return;
            }
        }
        console.log("true");
    }
    else {
        console.log("false");
    }
}
for (var i = 0; i < length; i++) {
    solve([1]);
}
