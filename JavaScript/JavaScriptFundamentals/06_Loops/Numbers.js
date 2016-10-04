function solve(args) {
    var n = +args[0];
    var result = '1';
    for (var i = 1; i <= n; i++) {

        if (i === 1) {
            continue;
        }

        else {
            result += ' ' + i;
        }
    }
    console.log(result);
}

solve(5);
//solve(['11', '4']);
//solve(['17', '17']);