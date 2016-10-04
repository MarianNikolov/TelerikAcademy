function solve(args) {
    //var input = args[0].split('\n'),
    var arrayLength = +args[0],
        array = +args[1],
        number = +args[2],
        counter = 0;


    number = +number[0];
    arrayLength = +arrayLength[0];

    

    for (var i = 0; i < arrayLength; i++) {
        if (array[i] === number) {
            counter += 1;
        }
    }
    console.log(args);
    console.log(arrayLength);
    console.log(array);
    console.log(number);
    console.log(counter);
}
solve([['8'],
['28', '6', '21', '6', '-7856', '73', '73', '-56'],
['73']]);