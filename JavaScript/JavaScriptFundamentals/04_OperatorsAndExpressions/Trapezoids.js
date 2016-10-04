function solve(args) {
    var sideA = +args[0];
    var sideB = +args[1];
    var height = +args[2];
    
    var area = ((sideA + sideB) / 2) * height;
    console.log(area.toFixed(7));
}
solve([5,
7,
12]);
