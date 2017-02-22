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
					totalPrice : currentTotalPrice,
					quantity : currentQuantity
				};

				productsResult.push(currentObject);
			}

			let result = {
				products: productsResult,
				totalPrice: this.showCost()
			};

			return result;
		}
	}
	return {
		Product, ShoppingCart
	};
}

module.exports = solve;
