/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/
'use strict';
function solve() {
	return function sum(numbers) {
		for (let item of numbers) {
			if (isNaN(item)) {
				throw Error;
			}
		}

		if (numbers.length <= 0) {
			return null;
		}
		
		return numbers.reduce((x, y) => (+x) + (+y));
	};
}

module.exports = solve;
