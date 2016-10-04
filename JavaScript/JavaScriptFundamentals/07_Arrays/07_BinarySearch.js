function binarySearch(numbers) {
    var array = (numbers + '').split('\n').map(Number);
    var n = +array[0];
    var wantedNum = +array[array.length - 1];
    array.shift();
    array.pop();
    var low = 0;
    var high = n - 1;
    var mid = ((high + low) / 2) | 0;
    var wantedNumberIsFound = false;
    while (low <= high) {
        if (wantedNum === +array[mid]) {
            wantedNumberIsFound = true;
            console.log(mid);
            return;
        } else if (wantedNum < +array[mid]) {
            high = mid - 1;
            mid = ((high + low) / 2) | 0;
        } else if (wantedNum > +array[mid]) {
            low = mid + 1;
            mid = ((high + low) / 2) | 0;
        }
    }
    console.log('-1');
}