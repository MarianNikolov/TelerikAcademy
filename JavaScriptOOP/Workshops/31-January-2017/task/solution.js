function solve() {

	function getProduct(productType, name, price) {
		let product = {
			productType: productType,
			name: name,
			price: price
		};

		return product;
	}

	function getShoppingCart() {

		function add(product) {

			let productToAdd = {
				productType: product.productType,
				name: product.name,
				price: product.price
			};

			this.products.push(productToAdd);

			return this;
		}

		function remove(productForRemove) {
			let productToRemove = {
				productType: productForRemove.productType,
				name: productForRemove.name,
				price: productForRemove.price
			};

			if (this.products.length === 0) {
				throw Error("There are not products in the ShoppingCart instance");
			}

			let isFoundProduct = false;

			for (let i = 0; i < this.products.length; i += 1) {
				let currentProductName = this.products[i].name;
				let currentProductProductType = this.products[i].productType;
				let currentProductPrice = this.products[i].price;

				if (currentProductName === productToRemove.name &&
					currentProductProductType === productToRemove.productType &&
					currentProductPrice === productToRemove.price) {

					this.products.splice(i, 1);

					isFoundProduct = !isFoundProduct;

					break;
				}
			}

			if (!isFoundProduct) {
				throw Error("The ShoppingCart instance does not contain the product");
			}

			return this;
		}

		function showCost() {
			let sum = 0;

			for (let i = 0; i < this.products.length; i += 1) {
				sum += this.products[i].price;
			}

			return sum;
		}

		function showProductTypes() {
			let uniqueProductTypes = [];

			if (this.products.length === 0) {
				return [];
			}

			uniqueProductTypes.push(this.products[0].productType);

			for (let i = 1; i < this.products.length; i += 1) {
				let isUniqueType = true;

				for (let j = 0; j < uniqueProductTypes.length; j += 1) {
					let currentProductProductType = this.products[i].productType;

					if (currentProductProductType === uniqueProductTypes[j]) {
						isUniqueType = !isUniqueType;
						break;
					}
				}

				if (isUniqueType) {
					uniqueProductTypes.push(this.products[i].productType);
				}
			}

			uniqueProductTypes.sort();

			return uniqueProductTypes;
		}

		function getInfo() {
			if (this.products.length === 0) {
				return {
					totalPrice: 0,
					products: []
				};
			}

			let productsName = [];

			productsName.push(this.products[0]);

			for (let i = 1; i < this.products.length; i += 1) {
				let isUniqueType = true;

				for (let j = 0; j < productsName.length; j += 1) {
					let currentProductProductName = this.products[i].name;

					if (currentProductProductName === productsName[j].name) {
						isUniqueType = !isUniqueType;
						break;
					}
				}

				if (isUniqueType) {
					productsName.push(this.products[i]);
				}
			}

			let counter = 0;
			let currentPrice = 0;

			let productsInfo = {
				totalPrice: 0,
				products: []
			};

			for (let i = 0; i < productsName.length; i += 1) {
				for (let j = 0; j < this.products.length; j += 1) {
					if (productsName[i].name === this.products[j].name) {
						counter += 1;
						currentPrice += this.products[j].price;
					}
				}

				let currentProduct = {
					name: productsName[i].name,
					totalPrice: currentPrice,
					quantity: counter
				};

				currentPrice = 0;
				counter = 0;

				productsInfo.products.push(currentProduct);
			}

			let totalPrice = 0;
			for (let i = 0; i < productsInfo.products.length; i += 1) {
				totalPrice += productsInfo.products[i].totalPrice;
			}

			productsInfo.totalPrice = totalPrice;

			return productsInfo;
		}

		let products = [];

		let shoppingCart = {
			products: products,
			add: add,
			remove: remove,
			showCost: showCost,
			showProductTypes: showProductTypes,
			getInfo: getInfo
		};

		return shoppingCart;
	}

	return {
		getProduct: getProduct,
		getShoppingCart: getShoppingCart
	};
}

module.exports = solve();
