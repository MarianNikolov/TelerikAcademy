function solve(args) {
    var a = +args[0];
    var b = +args[1];
    var c = +args[2];

    if (a > b && a > c) {
        console.log(a);
    }

    else if (b > a && b > c) {
        console.log(b);
    }
  
    else {
        console.log(c);
    }
}

solve([1024]);
//solve(['11', '4']);
//solve(['17', '17']);