function solve() {
	class Product {
		constructor(productType, name, price) {
			this.productType = productType;
			this.name = name;
			this.price = +price;
		}

		get productType() {
			return this._productType;
		}
		set productType(x) {
			this._productType = x;
		}
		get name() {
			return this._name;
		}
		set name(x) {
			this._name = x;
		}
		get price() {
			return this._price;
		}
		set price(x) {
			this._price = x;
		}
	}

	class ShoppingCart {
		constructor() {
			this.products = [];
		}

		add(product) {
			this.products.push(product);

			return this;
		}
		remove(product) {
			let currentIndex = this.products.findIndex(p => p.productType === product.productType && p.name === product.name && p.price === product.price);
			if (currentIndex < 0) {
				throw new Error('The ShoppingCart does not contain this product');
			}
			else {
				this.products.splice(currentIndex, 1);
			}

			return this;
		}
		showCost() {
			let result = this.products.reduce((sum, nextEl) => sum += nextEl.price, 0);
			return result;
		}
		showProductTypes() {
			let uniqueTypes = {};

			this.products.map(p => uniqueTypes[p.productType] = true);

			let result = Object.keys(uniqueTypes);

			return result.sort((x, y) => x.localeCompare(y));
		}
		getInfo() {
			let productsResult = [];
			let uniqueNames = {};
			this.products.map(p => uniqueNames[p.name] = true);
			let productsByNames = Object.keys(uniqueNames);

			for (let i = 0; i < productsByNames.length; i += 1) {

				let currentTotalPrice = 0;
				let currentQuantity = 0;
				for (let j = 0; j < this.products.length; j += 1) {
					if (productsByNames[i] === this.products[j].name) {
						currentTotalPrice += this.products[j].price;
						currentQuantity += 1;
					}
				}

				let currentObject = {
					name: productsByNames[i],
					totalPrice: currentTotalPrice,
					quantity: currentQuantity
				};

				productsResult.push(currentObject);
			}

			let result = {
				totalPrice: this.showCost(),
				products: productsResult
			};

			return result;
		}
	}
	return {
		Product, ShoppingCart
	};
}

module.exports = solve;

// let { Product, ShoppingCart } = solve();

// let prod0 = new Product("sacco", 'prod0', 5);
// let prod1 = new Product("sacco", 'prod1', 5);
// let prod2 = new Product("bmw", 'prod2', 22);
// let prod3 = new Product("adidas", 'prod3', 1);
// let prod4 = new Product("audi", 'prod4', 6);

// let cart = new ShoppingCart();

// cart.add(prod0);
// cart.add(prod1);
// cart.add(prod2);
// cart.add(prod3);
// cart.remove(prod2);

// console.log(cart.getInfo());


let {Product, ShoppingCart} = solve();

let cart = new ShoppingCart();

let pr1 = new Product("Sweets", "Shokolad Milka", 2);
cart.add(pr1);
console.log(cart.showCost());
	//prints `2`

let pr2 = new Product("Groceries", "Salad", 0.5);
cart.add(pr2);
cart.add(pr2);
console.log(cart.showCost());
	//prints `3`

console.log(cart.showProductTypes());
	//prints ["Sweets", "Groceries"]

console.log(cart.getInfo());
/* prints
{
    totalPrice: 3
    products: [{
        name: "Salad",
        totalPrice: 1,
        quantity: 2
    }, {
       name: "Shokolad Milka",
       totalPrice: 2,
       quantity: 1 
    }]
}
*/

// cart.remove({ name: "salad", productType: "Groceries", price: 0.5 });
// //throws: "salad" is not equal to "Salad"

cart.remove({ name: "Salad", productType: "Groceries", price: 0.5 });
console.log(cart.getInfo());
