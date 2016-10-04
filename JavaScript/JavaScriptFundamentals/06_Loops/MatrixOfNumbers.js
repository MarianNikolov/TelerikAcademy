function solve(args) {
    var n = +args[0];
    var result = '';

    for (var i = 1; i <= n; i++) {
        result = (i + ' ');

        for (var j = 1; j < n; j++) {
            result += ((i + j) + ' ');
        }

        console.log(result);
        result = '';
    }
}
//  avg = sum / 3;

//  console.log("min=" + min.toFixed(2));
//  console.log("max=" + max.toFixed(2));
//  console.log("sum=" + sum.toFixed(2));
//  console.log("avg=" + avg.toFixed(2));