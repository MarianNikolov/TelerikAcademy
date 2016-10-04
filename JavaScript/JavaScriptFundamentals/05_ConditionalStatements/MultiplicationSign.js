function solve(args) {
    var a = +args[0];
    var b = +args[1];
    var c = +args[2];

    if (a == 0 || b == 0 || c == 0) {
        console.log(0);
        return;
    }

    if (a < 0 && b < 0 && c < 0) {
        console.log('-');
        return;
    }

    if (a < 0 && b > 0 && c > 0 || 
        b < 0 && a > 0 && c > 0 ||
        c < 0 && a > 0 && b > 0 ) {
        console.log('-');
        return;
    }

    else {
        console.log('+');
    }
}

solve([1024]);
//solve(['11', '4']);
//solve(['17', '17']);