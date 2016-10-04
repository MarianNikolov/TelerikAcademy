function firstLargerThanNeighbours(args) {
    var input = args[0].split('\n'),
        arrayLength = input[0],
        array = input[1].split(' ').map(Number);

    return indexFinder(array, arrayLength);

    function indexFinder(sequence, arrLength) {
        var index = 0,
            i;
        for (i = 1; i < arrLength - 1; i++) {
            if (sequence[i] > sequence[i - 1] && sequence[i] > sequence[i + 1]) {
                index = i;
                break;
            } else {
                index = -1;
            }
        }

        return index;
    }
}