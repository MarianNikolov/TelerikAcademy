function solve(args) {
    var rowsAndCols = args[0].split(' ').map(Number),
        numberRows = rowsAndCols[0],
        numberCols = rowsAndCols[1],

        field = new Array(numberRows),
        empty = -1,
        debris = -2,
        allDebri = args[1].split(';'),
        curentDebri,

        numbersOfMoves = +args[2],
        curentMove,
        curentRow,
        curentCow,
        curentDir,
        cukiLives = 4,
        koceLives = 4,

        KoceTank0 = 0,
        KoceTank1 = 1,
        KoceTank2 = 2,
        KoceTank3 = 3,
        CukiTank4 = 4,
        CukiTank5 = 5,
        CukiTank6 = 6,
        CukiTank7 = 7;



    for (let i = 0; i < field.length; i++) {
        field[i] = new Array(numberCols);
        // Each row has 10 columns
    }
    // Initialize the array
    for (let r = 0; r < field.length; r++) {
        for (let c = 0; c < field[r].length; c++) {
            field[r][c] = empty;
        }
    }

    // draw players
    field[0][0] = KoceTank0;
    field[0][1] = KoceTank1;
    field[0][2] = KoceTank2;
    field[0][3] = KoceTank3;
    field[numberRows - 1][numberCols - 1] = CukiTank4;
    field[numberRows - 1][numberCols - 2] = CukiTank5;
    field[numberRows - 1][numberCols - 3] = CukiTank6;
    field[numberRows - 1][numberCols - 4] = CukiTank7;



    // draw debris

    for (let k = 0; k < allDebri.length; k++) {
        curentDebri = allDebri[k];

        field[+curentDebri[0]][+curentDebri[2]] = debris;
    }


    // START

    for (let j = 0; j < numbersOfMoves; j++) {

        curentMove = args[j + 3];

        // shoot
        if (curentMove[0] === 'x') {

            for (var row = 0; row < numberRows; row++) {
                for (var col = 0; col < numberCols; col++) {

                    if (field[row][col] === (+curentMove[2])) {
                        curentRow = row;
                        curentCow = col;

                        //direction
                        if (curentMove[4] === 'l') {
                            for (var e = curentCow - 1; e <= 0; e -= 1) {
                                switch (field[curentRow][e]) {
                                    case 0: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 1: koceLives -= 1; console.log('Tank 1 is gg'); break;
                                    case 2: koceLives -= 1; console.log('Tank 2 is gg'); break;
                                    case 3: koceLives -= 1; console.log('Tank 3 is gg'); break;
                                    case 4: cukiLives -= 1; console.log('Tank 4 is gg'); break;
                                    case 5: cukiLives -= 1; console.log('Tank 5 is gg'); break;
                                    case 6: cukiLives -= 1; console.log('Tank 6 is gg'); break;
                                    case 7: cukiLives -= 1; console.log('Tank 7 is gg'); break;
                                }
                                if (cukiLives == 0) {
                                    console.log('Cuki is gg')
                                }
                                if (koceLives == 0) {
                                    console.log('Koceto is gg')
                                }
                                field[curentRow][e] = empty;
                            }
                        }

                        if (curentMove[4] === 'r') {
                            for (var q = curentCow + 1; q < numberCols; q += 1) {
                                switch (field[curentRow][q]) {
                                    case 0: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 1: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 2: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 3: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 4: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 5: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 6: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 7: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                }
                                if (cukiLives == 0) {
                                    console.log('Cuki is gg')
                                }
                                if (koceLives == 0) {
                                    console.log('Koceto is gg')
                                }
                                field[curentRow][e] = empty;
                            }
                        }

                        if (curentMove[4] === 'u') {
                            for (var s = curentRow + 1; s <= 0; s -= 1) {
                                switch (field[s][curentCow]) {
                                    case 0: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 1: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 2: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 3: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 4: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 5: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 6: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 7: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                }
                                if (cukiLives == 0) {
                                    console.log('Cuki is gg')
                                }
                                if (koceLives == 0) {
                                    console.log('Koceto is gg')
                                }
                                field[curentRow][e] = empty;
                            }
                        }

                        if (curentMove[4] === 'd') {
                            for (var s = curentRow + 1; s < numberRows; s += 1) {
                                switch (field[s][curentCow]) {
                                    case 0: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 1: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 2: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 3: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 4: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 5: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 6: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 7: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                }
                                if (cukiLives == 0) {
                                    console.log('Cuki is gg')
                                }
                                if (koceLives == 0) {
                                    console.log('Koceto is gg')
                                }
                                field[curentRow][e] = empty;
                            }
                        }
                    }
                }
            }
        }



        // move
        if (curentMove[0] === 'm') {
            for (var rowMove = 0; rowMove < numberRows; rowMove++) {
                for (var colMove = 0; colMove < numberCols; colMove++) {

                    if (field[rowMove][colMove] === (+curentMove[3])) {
                        curentRow = row;
                        curentCow = col;

                        //direction
                        if (curentMove[7] === 'l') {
                            for (var e = curentCow - 1; e <= 0; e -= 1) {
                                switch (field[curentRow][e]) {
                                    case 0: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 1: koceLives -= 1; console.log('Tank 1 is gg'); break;
                                    case 2: koceLives -= 1; console.log('Tank 2 is gg'); break;
                                    case 3: koceLives -= 1; console.log('Tank 3 is gg'); break;
                                    case 4: cukiLives -= 1; console.log('Tank 4 is gg'); break;
                                    case 5: cukiLives -= 1; console.log('Tank 5 is gg'); break;
                                    case 6: cukiLives -= 1; console.log('Tank 6 is gg'); break;
                                    case 7: cukiLives -= 1; console.log('Tank 7 is gg'); break;
                                }
                                if (cukiLives == 0) {
                                    console.log('Cuki is gg')
                                }
                                if (koceLives == 0) {
                                    console.log('Koceto is gg')
                                }
                                field[curentRow][e] = empty;
                            }
                        }

                        if (curentMove[4] === 'r') {
                            for (var q = curentCow + 1; q < numberCols; q += 1) {
                                switch (field[curentRow][q]) {
                                    case 0: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 1: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 2: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 3: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 4: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 5: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 6: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 7: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                }
                                if (cukiLives == 0) {
                                    console.log('Cuki is gg')
                                }
                                if (koceLives == 0) {
                                    console.log('Koceto is gg')
                                }
                                field[curentRow][e] = empty;
                            }
                        }

                        if (curentMove[4] === 'u') {
                            for (var s = curentRow + 1; s <= 0; s -= 1) {
                                switch (field[s][curentCow]) {
                                    case 0: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 1: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 2: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 3: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 4: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 5: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 6: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 7: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                }
                                if (cukiLives == 0) {
                                    console.log('Cuki is gg')
                                }
                                if (koceLives == 0) {
                                    console.log('Koceto is gg')
                                }
                                field[curentRow][e] = empty;
                            }
                        }

                        if (curentMove[4] === 'd') {
                            for (var s = curentRow + 1; s < numberRows; s += 1) {
                                switch (field[s][curentCow]) {
                                    case 0: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 1: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 2: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 3: koceLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 4: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 5: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 6: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                    case 7: cukiLives -= 1; console.log('Tank 0 is gg'); break;
                                }
                                if (cukiLives == 0) {
                                    console.log('Cuki is gg')
                                }
                                if (koceLives == 0) {
                                    console.log('Koceto is gg')
                                }
                                field[curentRow][e] = empty;
                            }
                        }



                    }
                }
            }
        }

    }

}









solve([
    '5 5',
    '2 0;2 1;2 2;2 3;2 4',
    '13',
    'mv 7 2 l',
    'x 7 u',
    'x 0 d',
    'x 6 u',
    'x 5 u',
    'x 2 d',
    'x 3 d',
    'mv 4 1 u',
    'mv 4 4 l',
    'mv 1 1 l',
    'x 4 u',
    'mv 4 2 r',
    'x 2 d'
]);
//solve(['5', '3', '7 7 8 9 10']);
//solve(['8', '4', '1 8 8 4 2 9 8 11']);


// posKoceTank0Row = 0,
// posKoceTank0Col = 0,
// posKoceTank1Row = 0,
// posKoceTank1Col = 1,
// posKoceTank2Row = 0,
// posKoceTank2Col = 2,
// posKoceTank3Row = 0,
// posKoceTank3Col = 3,
// posCukiTank4Row = numberRows - 1,
// posCukiTank4Col = numberCols - 1,
// posCukiTank5Row = numberRows - 1,
// posCukiTank5Col = numberCols - 2,
// posCukiTank6Row = numberRows - 1,
// posCukiTank6Col = numberCols - 3,
// posCukiTank7Row = numberRows - 1,
// posCukiTank7Col = numberCols - 4;