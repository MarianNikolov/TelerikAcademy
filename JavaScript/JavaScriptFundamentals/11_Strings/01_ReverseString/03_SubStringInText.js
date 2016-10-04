function solve(args) {
    var word = args[0],
        sentence = args[1],
        counter = 0,
        curentIndex = 0;
        word = word.toUpperCase();
        sentence = sentence.toUpperCase();
    // substring(start, end)
    while (sentence.indexOf(word) !== -1) {

        curentIndex = sentence.indexOf(word);

        counter += 1;

        sentence = sentence.slice(curentIndex + word.length);
    }
    console.log(counter)
}

solve(['in',
    'We are living in an yellow submarine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.']);
//console.log('9');

//solve([')(a+b))']);
//console.log('Incorrect');

