function solve(args) {
    var array = (args + '').split(' ').map(Number);
       //  .split('\n')
    //  .map(Number),

   // console.log(array);

    if (array[0] > array[1] && array[0] > array[2]) {
        console.log(array[0]);
    }
    else if (array[1] > array[0] && array[1] > array[2]) {
        console.log(array[1]);
    }
    else {
        console.log(array[2]);
    }
}
solve(['4', '5', '8']);