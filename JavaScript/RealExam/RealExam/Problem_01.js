function solve(args) {
    var heights = args[0].split(' ').map(Number),
        curentNumber = heights[0],
        curentSum = 0,
        change = true,
        index = 1,
        max,
        result = [];

    while (true) {
        change = true;

        while (change) {

            if (curentNumber > heights[index]) {  // or >=
                curentSum += curentNumber;
                curentNumber = heights[index];
                index += 1;
                continue;
            }
            else if (curentNumber < heights[index]) {
                curentSum += curentNumber;
                curentNumber = heights[index];
               

                if (index < heights.length - 1) {
                    if (heights[index] < heights[index + 1]) {
                        change = true;
                    }
                    else {
                        curentSum += heights[index];
                        change = false;
                    }
                }

                else {
                    curentSum += heights[index];
                    change = false;
                }
               

                index += 1;

                continue;
            }
        }


        result.push(curentSum);
        curentSum = 0;
        if (!(index < heights.length - 1)) {
            break;
        }
    }
    max = result[0];
    for (var i = 1; i < result.length; i++) {
        if (max < result[i]) {
            max = result[i];
        }
    }

    console.log(max);

}



//solve(["5 1 7 4 8"]);
solve(["5 1 7 6 5 6 4 2 3 8"]);
