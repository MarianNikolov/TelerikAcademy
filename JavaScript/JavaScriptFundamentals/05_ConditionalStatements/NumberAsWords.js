function solve(args) {

    var number = args;
    var result;
    var aaa = +number;

    if (aaa >= 0 && aaa < 20) {

        switch (aaa) {
            case 0: return console.log('Zero'); 
            case 1: return console.log('One'); 
            case 2: return console.log('Two'); 
            case 3: return console.log('Three');
            case 4: return console.log('Four'); 
            case 5: return console.log('Five'); 
            case 6: return console.log('Six'); 
            case 7: return console.log('Seven');
            case 8: return console.log('Eight');
            case 9: return console.log('Nine'); 
            case 10: return console.log('Ten'); 
            case 11: return console.log('Eleven'); 
            case 12: return console.log('Twelve');
            case 13: return console.log('Thirteen');
            case 14: return console.log('Fourteen');
            case 15: return console.log('Fiveteen');
            case 16: return console.log('Sixteen'); 
            case 17: return console.log('Seventeen');
            case 18: return console.log('Eighteen'); 
            case 19: return console.log('Nineteen');

                //default: console.log('not a digit');
        }
    }

    if (number === 0) {
        result = "Zero";
    }
    else if (number < 20) {
        result = zeroTwenty(number);
        result = result.charAt(0).toUpperCase() + result.substring(1); // to make first letter uppercase.

        //console.log(result);
    }
    else if (number > 19 && number < 100) {
        result = takebefore99(number);
        result = result.charAt(0).toUpperCase() + result.substring(1);
        //console.log(result);
    }
    else if (number > 99 && number < 1000) {
        var hun = number.toString().substring(0, 1);
        result = hundreds(hun - 0);
        var others = number.toString().substring(1);
        if (takebefore99(others - 0) !== "") {
            result += " and " + takebefore99(others - 0);
        }


        result = result.charAt(0).toUpperCase() + result.substring(1);
        //console.log(result);
    }
    function takebefore99(number) {
        if (number < 20) {
            return zeroTwenty(number);
        }
        var decimals = number.toString().substring(0, 1);
        decimals = tens(decimals - 0);
        var digit = number.toString().substring(1);
        digit = zeroTwenty(digit - 0);
        var final = decimals + " " + digit;
        //final = final.charAt(0).toUpperCase() + final.substring(1);
        return final;
        /*write(result);
         console.log(result);*/
    }

    function zeroTwenty(number) {
        switch (number) {
            case 0:
                return "";
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            case 9:
                return "nine";
            case 10:
                return "ten";
            case 11:
                return "eleven";
            case 12:
                return "twelve";
            case 13:
                return "thirteen";
            case 14:
                return "fourteen";
            case 15:
                return "fifteen";
            case 16:
                return "sixteen";
            case 17:
                return "seventeen";
            case 18:
                return "eighteen";
            case 19:
                return "nineteen";


        }
    }

    function tens(number) {
        switch (number) {
            case 2:
                return "twenty";
            case 3:
                return "thirty";
            case 4:
                return "forty";
            case 5:
                return "fifty";
            case 6:
                return "sixty";
            case 7:
                return "seventy";
            case 8:
                return "eighty";
            case 9:
                return "ninety";


        }
    }

    function hundreds(number) {
        switch (number) {
            case 1:
                return "one hundred";
            case 2:
                return "two hundred";
            case 3:
                return "three hundred";
            case 4:
                return "four hundred";
            case 5:
                return "five hundred";
            case 6:
                return "six hundred";
            case 7:
                return "seven hundred";
            case 8:
                return "eight hundred";
            case 9:
                return "nine hundred";
        }
    }

    console.log(result);
}

solve([666]);
//solve(['11', '4']);
//solve(['17', '17']);