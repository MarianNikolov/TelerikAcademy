function solve(args) {
    var a = +args[0];
    var mask = 1 << 3;
    if ((a & mask) != 0) {
        console.log('1');
    } else {
        console.log('0');
    }
}

solve([1024]);
//solve(['11', '4']);
//solve(['17', '17']);