function solve() {
	let getItemId = (function () {
		let id = 0;

		return function () {
			return id += 1;
		};
	})();


	let getCatalogId = (function () {
		let id = 0;

		return function () {
			return id += 1;
		};
	})();

	class Item {
		constructor(name, description) {
			this.id = getItemId();
			this.name = name;
			this.description = description;
		}

		get name() {
			return this._name;
		}
		set name(x) {
			if (x.length < 2 || x.length > 40) {
				throw new Error('x.length < 2 || x.length > 40');
			}
			this._name = x;
		}

		get description() {
			return this._description;
		}
		set description(x) {
			if (!x || 0 === x.length) {
				throw new Error('!x || 0 === x.length');
			}
			this._description = x;
		}
	}

	class Book extends Item {
		constructor(name, isbn, genre, description) {
			super(name, description);
			this.isbn = isbn;
			this.genre = genre;
		}

		get isbn() {
			return this._isbn;
		}
		set isbn(x) {
			if (x.length !== 10 && x.length !== 13) {
				throw new Error('x.length !== 10 && x.length !== 13');
			}
			if (!(/^[0-9]+$/.test(x))) {
				throw new Error('!(/^[0-9]+$/.test(x))');
			}
			this._isbn = x;
		}

		get genre() {
			return this._genre;
		}
		set genre(x) {
			if (x.length < 2 || x.length > 20) {
				throw new Error('x.length < 2 || x.length > 20');
			}
			this._genre = x;
		}
	}

	class Media extends Item {
		constructor(name, rating, duration, description) {
			super(name, description);
			this.rating = rating;
			this.duration = duration;
		}

		get rating() {
			return this._rating;
		}
		set rating(x) {
			if (typeof x !== 'number' || x < 1 || x > 5) {
				throw new Error('typeof x !== number || x < 1 || x > 5');
			}
			this._rating = x;
		}

		get duration() {
			return this._duration;
		}
		set duration(x) {
			if (typeof x !== 'number' || x <= 0) {
				throw new Error('typeof x !== number || x <= 0');
			}
			this._duration = x;
		}
	}


	class Catalog {
		constructor(name) {
			this.id = getCatalogId();
			this.name = name;
			this.items = [];
		}

		get name() {
			return this._name;
		}
		set name(x) {
			if (x.length < 2 || x.length > 40) {
				throw new Error('x.length < 2 || x.length > 40');
			}
			this._name = x;
		}



		add(...items) {
			if (Array.isArray(items[0])) {
				items = items[0];
			}
			if (items.length === 0) {
				throw new Error('items.length === 0');
			}

			let result = [];
			for (let item of items) {
				// Any of the items is not an Item instance or not an Item-like object
				if (!item.name || !item.description) {
					throw new Error('Any of the items is not an Item instance or not an Item-like object');
				}

				result.push(item);
			}

			this.items.push(...result);

			return this;
		}


		find(parameter) {
			if (typeof parameter !== 'object' && typeof parameter !== 'number') {
				throw new Error('find parameter is incorrect1');
			}

			if (Number.isNaN(parameter)) {
				throw new Error('find parameter is nan');
			}

			if (typeof parameter === 'number') {
				let currentItemIndex = this.items.findIndex(x => x.id === parameter);
				if (currentItemIndex < 0) {
					return null;
				}

				return this.items[currentItemIndex];
			}
			else if (typeof parameter === 'object') {
				if (parameter.hasOwnProperty('id') && parameter.hasOwnProperty('name')) {
					return this.items.filter(x => x.id === parameter.id && x.name === parameter.name);
				}
				else if (parameter.hasOwnProperty('id')) {
					return this.items.filter(x => x.id === parameter.id);
				}
				else if (parameter.hasOwnProperty('name')) {
					return this.items.filter(x => x.name === parameter.name);
				}
				else { 
					return this.items;
				}
			}
		}

		search(pattern) {
			if (!pattern) {
				throw new Error('invalid pattern');
			}

			return this.items.filter(x => x.name.includes(pattern) || x.description.includes(pattern));
		}
	}

	let sortByProp = function (arr, obj, propName) {
		let result = [];
		if (Object.hasOwnProperty(propName)) {
			return arr.filter(x => x[propName]);
		}
		else {
			return arr;
		}
	};

	class BookCatalog extends Catalog {
		constructor(name) {
			super(name);
		}

		add(...items) {
			if (Array.isArray(items[0])) {
				items = items[0];
			}

			for (let item of items) {
				if (!(item instanceof Book)) {
					throw new Error("is not book instance");
				}
			}

			return super.add(...items);
		}
		getGenres() {
			let obj = {};
			let result = [];

			for (let item of this.items) {
				obj[item.genre.toLowerCase()] = true;
			}

			for (var prop in obj) {
				result.push(prop);
			}

			return result;
		}

		find(options) {
			if (typeof options === 'object') {
				let result = super.find(options);

				if (options.hasOwnProperty('genre')) {
					return result.filter(x => x.genre === options.genre);
				}

				return result;
			}

			return super.find(options);
		}
	}

	class MediaCatalog extends Catalog {
		constructor(name) {
			super(name);
		}

		add(...items) {
			if (Array.isArray(items[0])) {
				items = items[0];
			}

			for (let item of items) {
				if (!(item instanceof Media)) {
					throw new Error('is not Media instance');
				}
			}

			return super.add(...items);
		}

		getTop(count) {
			if (typeof count !== 'number' || count < 1) {
				throw new Error('count is not a number or less than one');
			}

			let res = this.items.slice().sort((a, b) => b.rating - a.rating);
			let result = [];
			if (count > res.length) {
				for (let i = 0; i < res.length; i += 1) {
					result.push({ id: res[i].id, name: res[i].name });
				}

				return result;
			}
			else {
				for (let i = 0; i < count; i += 1) {
					result.push({ id: res[i].id, name: res[i].name });
				}

				return result;
			}
		}

		getSortedByDuration() {
			return this.items.sort((a, b) => {
				let res = b.duration - a.duration;
				if (res === 0) {
					res = a.id - b.id;
				}
				return res;
			});
		}

		find(options) {
			if (typeof options === 'object') {
				let result = super.find(options);

				if (options.hasOwnProperty('rating')) {
					return result.filter(x => x.rating === options.rating);
				}

				return result;
			}

			return super.find(options);
		}
	}

	return {
		getBook: function (name, isbn, genre, description) {
			return new Book(name, isbn, genre, description);
		},
		getMedia: function (name, rating, duration, description) {
			return new Media(name, rating, duration, description);
		},
		getBookCatalog: function (name) {
			return new BookCatalog(name);
		},
		getMediaCatalog: function (name) {
			return new MediaCatalog(name);
		}
	};
}

// let obj = solve();
// let book = obj.getBook("daas", "1111111111", 'ssdsd', 'sdsdasddasd');
// console.log(book);

module.exports = solve;
