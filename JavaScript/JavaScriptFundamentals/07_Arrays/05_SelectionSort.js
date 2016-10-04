function solve(numbers) {
    var arr = (numbers + '').split('\n').map(Number),
      //  .split('\n')
      //  .map(Number),
    exchangePosition = 0,
    numberForSwitch = 0,
    exchange = false;

   // console.log(arr);
   // console.log(numbers);

    for (var i = 0; i < arr.length; i++) {
        numberForSwitch = arr[i];
        for (var j = i + 1; j < arr.length; j++) {

            if (numberForSwitch > arr[j]) {
                exchangePosition = j;
                numberForSwitch = arr[j];
                exchange = true;
            };
        }
        if (exchange) {
            arr[exchangePosition] = arr[i]
            arr[i] = numberForSwitch;
            exchange = false;
        }
    }
    arr = arr.filter(function (item, index, inputArray) {
        return inputArray.indexOf(item) == index;
    });

    console.log(arr.join('\n'));
}
solve(['10', '10', '10', '5', '5', '5', '11', '11', '11', '11', '1']);

