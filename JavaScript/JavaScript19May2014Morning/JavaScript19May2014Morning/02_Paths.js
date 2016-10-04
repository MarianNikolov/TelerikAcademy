function solve(args) {
    var rowsAndCols = args[0].split(' ').map(Number),
        row = rowsAndCols[0],
        col = rowsAndCols[1],
        a = args.shift(),
        curentRow = 0,
        curentCol = 0,
        countSum = 0,
        boolArray = boolArray = new Array(row),
        directionsArray = args.map(function (line) {
            return line.split(' ');
        });

    // 10 rows of the table
    for (var i = 0; i < boolArray.length; i++)
        boolArray[i] = new Array(col);            // Each row has 10 columns

    // Initialize the array
    for (var r = 0; r < boolArray.length; r++) {
        for (c = 0; c < boolArray[r].length; c++) {
            boolArray[r][c] = false;
        }
    }

    while (curentRow >= 0 && curentRow < row && curentCol >= 0 && curentCol < col) {

        countSum += Math.pow(2, curentRow) + curentCol;

        if (boolArray[curentRow][curentCol] === true) {
            return 'failed at (' + curentRow + ', ' + curentCol + ')';
        }

        else {
            boolArray[curentRow][curentCol] = true;

            if (directionsArray[curentRow][curentCol] === 'dr') {
                curentRow += 1;
                curentCol += 1;
            }

            else if (directionsArray[curentRow][curentCol] === 'ur') {
                curentRow -= 1;
                curentCol += 1;
            }

            else if (directionsArray[curentRow][curentCol] === 'ul') {
                curentRow -= 1;
                curentCol -= 1;
            }

            else if (directionsArray[curentRow][curentCol] === 'dl') {
                curentRow += 1;
                curentCol -= 1;
            }
        }
    }

    console.log('successed with ' + countSum);
}

solve(['3 5', 'dr ur dr ul dr', 'dr ur dr dl dr', 'dr ur dr ul dr']); // successed with 18 
solve(['3 5', 'dr ur dr ul dr', 'dr ur dr dl dr', 'dr ur ur ul dr']); // failed at (1, 3)
// asdadasd

// Wrong submission type!
// math.pow(2, row) + col;

// "dr" stands for "down-right" direction
// "ur" stands for "up-right" direction
// "ul" stands for "up-left" direction
// "dl" stands for "down-left" direction