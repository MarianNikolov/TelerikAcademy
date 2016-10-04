function solve(args) {
    //function decimalAdjust(type, value, exp) {
    //    // If the exp is undefined or zero...
    //    if (typeof exp === 'undefined' || +exp === 0) {
    //        return Math[type](value);
    //    }
    //    value = +value;
    //    exp = +exp;
    //    // If the value is not a number or the exp is not an integer...
    //    if (isNaN(value) || !(typeof exp === 'number' && exp % 1 === 0)) {
    //        return NaN;
    //    }
    //    // Shift
    //    value = value.toString().split('e');
    //    value = Math[type](+(value[0] + 'e' + (value[1] ? (+value[1] - exp) : -exp)));
    //    // Shift back
    //    value = value.toString().split('e');
    //    return +(value[0] + 'e' + (value[1] ? (+value[1] + exp) : exp));
    //}

    //// Decimal round
    //if (!Math.round10) {
    //    Math.round10 = function(value, exp) {
    //        return decimalAdjust('round', value, exp);
    //    };
    //}

    var min = 10000;
    var max = -10000;
    var sum = 0.0;
    var avg = 0.0;

    for (var i = 0; i < args.length; i++) {
        var ReadingNumber = +args[i];

        sum += ReadingNumber;

        if (min > ReadingNumber) {
            min = ReadingNumber;
        }

        if (max < ReadingNumber) {
            max = ReadingNumber;
        }

    }
    avg = sum / args.length;
   
    console.log("min=" + min.toFixed(2));
    console.log("max=" + max.toFixed(2));
    console.log("sum=" + sum.toFixed(2));
    console.log('avg=' + avg.toFixed(2));
    //console.log("avg=" +(Math.round(rnum * Math.pow(10, avg)) / Math.pow(10, avg).toFixed(2));
}

//solve(5);

solve([2.152574562, -1352341.13234, 4142.0000000200]);
//solve([10000,
//10000,
//10000]);
//solve(['17', '17']);

