function solve(params) {
   var s = +params[0],
   count = 0;
    
   for (var car = 0; car < 200; car += 1) {

       for (var trucks = 0; trucks < 200; trucks += 1) {

           for (var trikes = 0; trikes < 200; trikes += 1) {

               if ((car * 4) + (trucks * 10) + (trikes * 3) === s) {  // car / s === 0 && trucks / s === 0 && trikes / s === 0
                   count += 1;
               }
           }
       }
   }

   console.log(count);
}

solve(['7']); // 1  
solve(['10']); // 2
solve(['40']); // 11

// Cars with 4 wheels
// Trucks with 10 wheels
// Trikes with 3 wheels