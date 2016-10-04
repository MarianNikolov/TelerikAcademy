function solve(args) {
    var word = args[0],
    result = '';

    for (var i = word.length - 1; i >= 0 ; i -= 1) {
        result += word[i];
    }

    console.log(result);
   // return result;
}

solve(['sample']);
console.log('elpmas');

solve(['qwertytrewq']);
console.log('qwertytrewq');

