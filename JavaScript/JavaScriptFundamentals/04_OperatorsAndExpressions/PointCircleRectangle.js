function solve(args) {
    var x = +args[0];
    var y = +args[1];

    var xCircle = x - 1;
    var yCircle = y - 1;
    var print;
    if ((xCircle * xCircle) + (yCircle * yCircle) <= Math.pow(1.5, 2))
    {
        print = "inside circle ";
        if (x >= -1 && x <= 5 && y <= 1 && y >= -1)
        {
            print += "inside rectangle";
            console.log(print);
        }
        else
        {
            print += "outside rectangle";
            console.log(print);
        }
    }
    else
    {
        print = "outside circle ";
        if (x >= -1 && x <= 5 && y <= 1 && y >= -1)
        {
            print += "inside rectangle";
            console.log(print);
        }
        else
        {
            print += "outside rectangle";
            console.log(print);
        }
    }
}

solve([2.5,
2]);
