function solve(args) {
    var a = +args[0];
    var b = +args[1];

    //var mask = 1 << 3;
    if (a > b) {
        console.log(b + ' ' + a);
    } else {
        console.log(a + ' ' + b);
    }
}

solve([1024]);
//solve(['11', '4']);
//solve(['17', '17']);