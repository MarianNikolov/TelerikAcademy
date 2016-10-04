function solve(args) {
    var a = +args[0];
    var multiplyNumber = 5;
    var array = new Array(a);

    for (var i = 0; i < array.length; i++) {
        array[i] = i * multiplyNumber;
        console.log(array[i]);
    }
}
solve(['0'])