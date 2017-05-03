function solve() {
	let idGenerator = (function () {
		let id = 0;
		return function () {
			return id += 1;
		};
	})();

	class App {
		constructor(name, description, version, rating) {
			this.name = name;
			this.description = description;
			this.version = version;
			this.rating = rating;
			this.id = idGenerator();
		}

		get name() {
			return this._name;
		}
		set name(x) {
			//name - a string with length between 1 and 24 latin letters, numbers and whitespace
			if (typeof x !== 'string' || x.length < 1 || x.length > 24) {
				throw 'name must by string with length between 1 and 24 latin letters';
			}
			if (x.match(/[^a-zA-Z0-9 ]/)) {
				throw 'name must by latin letters, numbers and whitespace';
			}

			this._name = x;
		}

		get description() {
			return this._description;
		}
		set description(x) {
			// description - a string
			if (typeof x !== 'string') {
				throw 'description - a string';
			}
			this._description = x;
		}

		get version() {
			return this._version;
		}
		set version(x) {
			// version - a positive number
			if (typeof x !== 'number' || x < 0 || Number.isNaN(x)) {
				throw 'version - a positive number';
			}
			this._version = x;
		}

		get rating() {
			return this._rating;
		}
		set rating(x) {
			// rating - a number between 1 and 10
			if (typeof x !== 'number' || x < 1 || x > 10 || Number.isNaN(x)) {
				throw 'rating - a number between 1 and 10';
			}

			this._rating = x;
		}

		release(x) {
			if (typeof x === 'number' && x >= 0 || Number.isNaN(x)) {
				if (x <= this.version) {
					throw 'throws if the new version is not above the old one';
				}

				this.id = idGenerator();
				this.version = x;
			}
			if (typeof x === 'object') {
				if (!(x.hasOwnProperty('version'))) {
					throw 'version';
				}
				if (!x.version) {
					throw 'throws if not specified';
				}

				if (x.version <= this.version) {
					throw 'throws if the new version is not above the old one';
				}

				this.id = idGenerator();
				this.version = x.version;
			}

			if (x.hasOwnProperty('description')) {
				if (typeof x !== 'string') {
					throw 'description - a string';
				}
				this.description = x.description;
			}

			if (x.hasOwnProperty('rating')) {
				if (typeof x !== 'number' || x < 1 || x > 10 || Number.isNaN(x)) {
					throw 'rating - a number between 1 and 10';
				}
				this.rating = x.rating;
			}
		}

	}

	class Store extends App {
		constructor(name, description, version, rating) {
			super(name, description, version, rating);

			this.apps = [];
		}

		release(x) {
			return super.release(x);
		}

		uploadApp(app) {
			if (!(app instanceof App)) {
				throw 'app must be a valid instance of the App class';
			}

			app.id = idGenerator();

			let currentAppIndex = this.apps.findIndex(a => a.name === app.name);

			if (currentAppIndex < 0) {
				// TODO???  doesn't exist - creates a new app in the Store
				this.apps.push(app);
			}
			else {
				let currentApp = this.apps[currentAppIndex];

				if (app.version <= currentApp.version) {
					throw 'uploadApp throws if the new version is not above the old one';
				}

				currentApp.version = app.version;
				currentApp.description = app.description;
				currentApp.rating = app.rating;
			}

			return this;
		}

		takedownApp(name) {
			let currentAppIndex = this.apps.findIndex(a => a.name === name);

			if (currentAppIndex < 0) {
				throw 'throw if an app with the given name does not exist in the store';
			}

			this.apps.splice(currentAppIndex, 1);

			return this;
		}

		search(pattern) {
			if (!pattern) {
				throw new Error('invalid pattern');
			}

			let result = this.apps.filter(x => x.name.toLowerCase().includes(pattern.toLowerCase()));

			return result.sort((a, b) => a.name.localeCompare(b.name));
		}

		listMostRecentApps(count) {
			// TODO: ???  sorted by time of upload - descending
			let result = this.apps.sort((a, b) => b.id - a.id);
			if (count) {
				result = result.slice(0, count);
				return result;
			}
			else {
				result = result.slice(0, 10);
				return result;
			}
		}

		listMostPopularApps(count) {
			// apps with equal rating should be sorted by time of upload - descending
			let result = this.apps.sort((a, b) => {
				let res = b.rating - a.rating;
				if (res === 0) {
					res = b.id - a.id;
				}

				return res;
			});
			if (count) {
				result = result.slice(0, count);
				return result;
			}
			else {
				result = result.slice(0, 10);
				return result;
			}
		}
	}

	class Device {
		constructor(hostname, apps) {
			this.hostname = hostname;
			this.apps = apps;
		}
		get hostname() {
			return this._hostname;
		}
		set hostname(x) {
			// hostname: a string with length between 1 and 32 symbols
			if (typeof x !== 'string' || x.length < 1 || x.length > 32) {
				throw 'hostname must by a string with length between 1 and 32 symbols';
			}

			this._hostname = x;
		}
		get apps() {
			return this._apps;
		}
		set apps(x) {
			// an array of installed apps
			if (!Array.isArray(x)) {
				throw 'array of installed apps';
			}
			for (let item of x) {

				if (!(item instanceof App)) {
					throw 'current app is not installed apps';
				}
			}

			this._apps = x;
		}

		search(pattern) {
			// performs case-insensitive search in all stores installed on the device
			let allStoreOnDevice = this.apps.filter(x => x instanceof Store);
			let results = [];
			if (allStoreOnDevice) {
				// returns an array of apps containing pattern in their name
				for (let i = 0; i < allStoreOnDevice.length; i += 1) {
					for (let j = 0; j < allStoreOnDevice[i].apps.length; j += 1) {
						if (allStoreOnDevice[i].apps[j].name.includes(pattern)) {
							results.push(allStoreOnDevice[i].apps[j]);
						}
					}
				}
			}
			// sort apps lexicographically by name
			results.sort((a, b) => a.name.localeCompare(b.name));

			return results;
			// TODO ???????? return only latest versions of apps
		}

		install(name) {
			let currentAppIndex = this.apps.findIndex(a => a.name === name);
			if (currentAppIndex < 0) {
				let allStoreOnDevice = this.apps.filter(x => x instanceof Store);
				if (allStoreOnDevice) {
					for (let i = 0; i < allStoreOnDevice.length; i += 1) {
						for (let j = 0; j < allStoreOnDevice[i].apps.length; j += 1) {
							if (allStoreOnDevice[i].apps[j].name === name) {

								this.apps.push(allStoreOnDevice[i].apps[j]);
								return this;
							}
						}
					}

					throw 'throws if app name is not available in installed stores';
				}
			}

			return this;
		}

		uninstall(name) {
			let currentAppIndex = this.apps.findIndex(a => a.name === name);
			if (currentAppIndex < 0) {
				throw 'throws if no such app is installed';
			}

			this.apps.splice(currentAppIndex, 1);

			return this;
		}

		listInstalled() {
			return this.apps.sort((a, b) => a.name.localeCompare(b.name));
		}

		update() {
			// updates all installed apps to their best version across all stores installed on the device

			return this;
		}
	}

	return {
		createApp(name, description, version, rating) {
			return new App(name, description, version, rating);
		},
		createStore(name, description, version, rating) {
			return new Store(name, description, version, rating);
		},
		createDevice(hostname, apps) {
			return new Device(hostname, apps);
		}
	};
}

let a = solve();

let app1 = a.createApp('app 1', 'ha', 3.2, 4);

// console.log(app1);
// app1.release(4);
// console.log(app1);

let app2 = a.createApp('app2', 'ha', 5.2, 10);
let app3 = a.createApp('app3 ', 'ha', 2.2, 10);
let app4 = a.createApp('app4 ', 'ha', 3.2, 9);
let app5 = a.createApp('app5', 'ha', 4, 5);
let app6 = a.createApp('app6', 'ha', 8.2, 8);
let newApp = a.createApp('new app', 'ha', 8.2, 8);

let store = a.createStore('store1', 'ha', 3.2, 7);
store.uploadApp(app2);
store.uploadApp(app3);
store.uploadApp(app1);
store.uploadApp(app5);
store.uploadApp(app6);
store.uploadApp(app4);
store.uploadApp(newApp);

console.log(store.listMostRecentApps(3));

let device = a.createDevice('device', [app4, store, app3, app5, app6]);
device.uninstall('app6');

// Submit the code above this line in bgcoder.com
module.exports = solve;
