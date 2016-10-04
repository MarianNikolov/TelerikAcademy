function solve(numbers) {
    var array = (numbers + '').split('\n').map(Number),
      //  .split('\n')
      //  .map(Number),
    counter = 1,
    number = 0,
    countFinds = 0;

    console.log(numbers);
    console.log(array);

    for (var i = 0; i < array.Length; i++) {
        counter = 1;
        for (var j = 0; j < array.Length; j++) {
            if (i == j) {
                continue;
            }
            else {
                if (array[i] == array[j]) {
                    counter++;

                    if (counter > countFinds) {
                        countFinds = counter;
                        number = array[i];
                    }
                }
            }
        }
    }

    console.log(number + ' (' + countFinds + ' times)');
}
solve(['13', '4', '1', '1', '4', '2', '3', '4', '4', '1', '2', '4', '9', '3']);

