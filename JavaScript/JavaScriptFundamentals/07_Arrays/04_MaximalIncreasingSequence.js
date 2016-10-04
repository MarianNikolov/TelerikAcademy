function solve(args) {
    var arr = args[0]
        .split("\n")
        .map(Number),
    maxSequence = 1,
    curentSequence = 1;

    for (var i = 0; i < arr.length - 1; i++) {
        if (arr[i] < arr[i + 1]) {
            curentSequence++;
            if (curentSequence > maxSequence) {
                maxSequence = curentSequence;
            }
        }
        else {
            curentSequence = 1;
        }
    }
    console.log(maxSequence);
}
solve(['10', '2', '1', '2', '3', '4', '5', '1'])