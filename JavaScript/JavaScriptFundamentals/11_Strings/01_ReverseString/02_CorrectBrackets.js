function solve(args) {
    var word = args[0],
    openBr = 0,
    closeBr = 0,
    br = true;

    for (var i = 0; i < word.length; i += 1) {
        if (word[i] === '(') {
            openBr += 1; 
        }
        if (word[i] === ')') {
            closeBr += 1;
            if (openBr < closeBr) {
                console.log('Incorrect');
                br = false;
                break;
            }
        }
    }
    if (br) {
        if (openBr === closeBr) {
            console.log('Correct');
        }
        else {
            console.log('Incorrect');
        }
    }
}

solve(['((a+b)/5-d)']);
//console.log('Correct');

solve([')(a+b))']);
//console.log('Incorrect');

