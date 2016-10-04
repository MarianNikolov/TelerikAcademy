function solve(args) {
    var a = +args[0];
    var b = +args[1];
    var c = +args[2];
    var d = 0;

    d = (Math.pow(b, 2)) - (4 * a * c);

    if (d < 0)
    {
        console.log("no real roots");
    }
    if (d == 0)
    {
        var x = -b / (2 * a);
        console.log('x1=x2=' + x.toFixed(2));
    }
    if (d > 0)
    {
        var x1 = (-b + Math.sqrt(d)) / (2 * a);
        var x2 = (-b - Math.sqrt(d)) / (2 * a);
        if (x1 < x2)
        {
            console.log('x1=' + x1.toFixed(2) + '; x2=' + x2.toFixed(2));
        }
        else
        {
            console.log('x1=' + x2.toFixed(2) + '; x2=' + x1.toFixed(2));

        }

    }
}

solve([1, 1, 1]);
//solve(['11', '4']);
//solve(['17', '17']);