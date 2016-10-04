function solve(args) {
    var x = +args[0];
    var y = +args[1];

    var distance = (x * x) + (y * y);
    var newDistance = Math.sqrt(distance);

    if ((x * x) + (y * y) <= 4) {
        console.log("yes " + newDistance.toFixed(2));
    }
    else {
        console.log("no " + newDistance.toFixed(2));
    }
}