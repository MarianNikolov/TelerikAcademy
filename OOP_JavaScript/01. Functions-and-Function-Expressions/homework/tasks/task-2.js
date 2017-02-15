/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function solve() {

	return function findPrimes(firstNumber, secondNumber) {

		if (!firstNumber && +firstNumber !== 0 || !secondNumber && !+secondNumber !== 0) {
				throw Error;
		}

		let results = [];
		let isPrime = false;

		for (let i = +firstNumber; i <= +secondNumber; i += 1) {
			for (let k = 2; k <= i; k += 1) {

				isPrime = true;

				if (i === k) {
					break;
				}

				if (i % k === 0) {
					isPrime = false;
					break;
				}
			}

			if (isPrime) {
				results.push(i);
			}
		}

		return results;
	};
}

console.log(solve()(0, 5));
module.exports = solve;
