function solve(args) {
    var n = +args[0],
    k = +args[1],
    numbersArray = args[2].split(' ').map(Number),
    curentMin = 1000000001,
    curentMax = -1000000001,
    result = [];
        
    for (var i = 0; i < n - k + 1; i++) {

        for (var j = i; j < i + k; j++) {

            if (numbersArray[j] <= curentMin) {
                curentMin = numbersArray[j];
            }
            if (numbersArray[j] >= curentMax) {
                curentMax = numbersArray[j];
            }
        }
        result.push(curentMax + curentMin)
        curentMin = 1000000001;
        curentMax = -1000000001;
    }

    console.log(result.join(','));
}

solve(['4', '2', '1 3 1 8']);
solve(['5', '3', '7 7 8 9 10']);
solve(['8', '4', '1 8 8 4 2 9 8 11']);


