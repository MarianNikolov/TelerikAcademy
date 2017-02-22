function solve() {
	'use strict';

	let getNextId = (function () {
		let id = 0;

		return function () {
			id += 1;
			return id;
		};
	})();

	const ERROR_MESSAGES = {
		INVALID_NAME_TYPE: 'Name must be string!',
		INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
		INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
		INVALID_MANA: 'Mana must be a positive integer number!',
		INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
		INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
		INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
		INVALID_COUNT: 'Count must be a positive integer number!',
		INVALID_SPEED: 'Speed must be a positive number that is at most 100!',
		INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
		NOT_ENOUGH_MANA: 'Not enough mana!',
		TARGET_NOT_FOUND: 'Target not found!',
		INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!'
	};

	let VALIDATOR = {
		nameLength2_20(name) {
			if (name.length < 2 || name.length > 20) {
				throw new Error(ERROR_MESSAGES.INVALID_NAME_LENGTH);
			}
		},
		nameType(name) {
			if (typeof name !== "string") {
				throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
			}
		},
		nameSymbols(name) {
			if (name.match(/[^a-zA-Z ]/)) {
				throw new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
			}
		},
		manaCostIsNumberOrBelowThanZero(manaCost) {
			if (typeof manaCost !== 'number' || manaCost <= 0) {
				throw new Error(ERROR_MESSAGES.INVALID_MANA);
			}
		},
		effectIsAFunctionWhitOneParameter(effect) {
			if (typeof effect !== 'function' || effect.length !== 1) {
				throw new Error(ERROR_MESSAGES.INVALID_EFFECT);
			}
		},
		alignmentIsValid(alignment) {
			let alignments = ['good', 'neutral', 'evil'];

			if (alignments.indexOf(alignment) < 0) {
				throw new Error('Alignment must be good, neutral or evil!');
			}
		}
	};

	class Spell {
		constructor(name, manaCost, effect) {
			this.name = name;
			this.manaCost = manaCost;
			this.effect = effect;
		}

		get name() {
			return this._name;
		}
		set name(v) {
			VALIDATOR.nameLength2_20(v);
			VALIDATOR.nameType(v);
			VALIDATOR.nameSymbols(v);

			this._name = v;
		}

		get manaCost() {
			return this._manaCost;
		}
		set manaCost(v) {
			VALIDATOR.manaCostIsNumberOrBelowThanZero(v);

			this._manaCost = v;
		}

		get effect() {
			return this._effect;
		}
		set effect(v) {
			VALIDATOR.effectIsAFunctionWhitOneParameter(v);

			this._effect = v;
		}
	}

	class Unit {
		constructor(name, alignment) {
			this.name = name;
			this.alignment = alignment;
		}

		get name() {
			return this._name;
		}
		set name(v) {
			VALIDATOR.nameLength2_20(v);
			VALIDATOR.nameType(v);
			VALIDATOR.nameSymbols(v);

			this._name = v;
		}

		get alignment() {
			return this._alignment;
		}
		set alignment(v) {
			VALIDATOR.alignmentIsValid(v);

			this._alignment = v;
		}
	}

	class ArmyUnit extends Unit {
		constructor(name, alignment, damage, health, count, speed) {
			super(name, alignment);
			this.id = getNextId();
			this.damage = damage;
			this.health = health;
			this.count = count;
			this.speed = speed;
		}

		get damage() {
			return this._damage;
		}
		set damage(v) {
			if (typeof v !== 'number' || v > 100 || v < 0 || Number.isNaN(v)) {
				throw new Error(ERROR_MESSAGES.INVALID_DAMAGE);
			}

			this._damage = +v;
		}

		get health() {
			return this._health;
		}
		set health(v) {
			if (typeof v !== 'number' || v > 200 || v < 0 || Number.isNaN(v)) {
				throw new Error(ERROR_MESSAGES.INVALID_HEALTH);
			}

			this._health = v;
		}

		get count() {
			return this._count;
		}
		set count(v) {
			// check is not integer (v | 0) !== v
			if (typeof v !== 'number' || v < 0 || Number.isNaN(v) || (v | 0) !== v) {
				throw new Error(ERROR_MESSAGES.INVALID_COUNT);
			}

			this._count = v;
		}

		get speed() {
			return this._speed;
		}
		set speed(v) {
			if (typeof v !== 'number' || v > 100 || v < 0 || Number.isNaN(v)) {
				throw new Error(ERROR_MESSAGES.INVALID_SPEED);
			}

			this._speed = v;
		}
	}

	class Commander extends Unit {
		constructor(name, alignment, mana) {
			super(name, alignment);
			this.mana = mana;
			this.spellbook = [];
			this.army = [];
		}

		get mana() {
			return this._mana;
		}
		set mana(v) {
			if (typeof v !== 'number' || v > 100 || v < 0 || Number.isNaN(v)) {
				throw new Error(ERROR_MESSAGES.INVALID_MANA);
			}

			this._mana = v;
		}
	}

	const battlemanager = {
		commanders: [],
		armyUnits: [],

		getCommander: function (name, alignment, mana) {
			return new Commander(name, alignment, mana);
		},
		getArmyUnit: function (options) {
			return new ArmyUnit(options.name, options.alignment, options.damage, options.health, options.count, options.speed);
		},
		getSpell: function (name, manaCost, effect) {
			return new Spell(name, manaCost, effect);
		},
		addCommanders: function (...commanders) {
			this.commanders.push(...commanders);

			return this;
		},
		addArmyUnitTo: function (commanderName, armyUnit) {
			this.armyUnits.push(armyUnit);
			let currentCommander = this.commanders.find(c => c.name === commanderName);
			currentCommander.army.push(armyUnit);

			return this;
		},
		addSpellsTo: function (commanderName, ...spells) {
			let currentCommanderIndex = this.commanders.findIndex(c => c.name === commanderName);
			let spellsToAdd = [];

			try {
				for (let spell of spells) {
					spellsToAdd.push(new Spell(spell.name, spell.manaCost, spell.effect));
				}
			}
			catch (ex) {
				throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
			}

			this.commanders[currentCommanderIndex].spellbook.push(...spellsToAdd);

			return this;

		},
		findCommanders: function (query) {
			let result = [];

			if (query.name && query.alignment) {
				result = this.commanders.filter(c => c.name === query.name && c.alignment === query.alignment);
			}
			else if (query.name) {
				result = this.commanders.filter(c => c.name === query.name);
			}
			else if (query.alignment) {
				result = this.commanders.filter(c => c.alignment === query.alignment);
			}

			return result.sort(function (a, b) {
				return a.name < b.name ? -1 : a.name > b.name ? 1 : 0;
			});
		},
		findArmyUnitById: function (id) {
			let currentIndex = this.armyUnits.findIndex(u => u.id === id);
			if (currentIndex > -1) {
				return this.armyUnits[currentIndex];
			}

			return undefined;
		},
		findArmyUnits: function (query) {
			if (Object.keys(query).length === 0) {
				return this.armyUnits.sort((x, y) => {
					let result = y.speed - x.speed;
					if (result === 0) {
						result = x.name.localeCompare(y.name);
					}

					return result;
				});
			}

			let armyUnitsToReturn = [];

			// TODO: fix this shit
			if (!query.id && !query.name && !query.alignment) {
				armyUnitsToReturn = this.armyUnits;
			}
			else if (query.id && query.name && query.alignment) {
				armyUnitsToReturn = this.armyUnits.filter(u => u.id == query.id && u.name == query.name && u.alignment == query.alignment);
			}
			else if (query.id && query.name) {
				armyUnitsToReturn = this.armyUnits.filter(u => u.id == query.id && u.name == query.name);
			}
			else if (query.name && query.alignment) {
				armyUnitsToReturn = this.armyUnits.filter(u => u.name == query.name && u.alignment == query.alignment);
			}
			else if (query.id && query.alignment) {
				armyUnitsToReturn = this.armyUnits.filter(u => u.id == query.id && u.alignment == query.alignment);
			}
			else if (query.id) {
				armyUnitsToReturn = this.armyUnits.filter(u => u.id == query.id);
			}
			else if (query.name) {
				armyUnitsToReturn = this.armyUnits.filter(u => u.name == query.name);
			}
			else if (query.alignment) {
				armyUnitsToReturn = this.armyUnits.filter(u => u.alignment == query.alignment);
			}

			let result = armyUnitsToReturn.sort((a, b) => {
				let compare = b.speed - a.speed;
				if (compare === 0) {
					compare = a.name.localeCompare(b.name);
				}

				return compare;
			});

			return result;
		},
		spellcast: function (casterName, spellName, targetUnitId) {
			let currentCommanderIndex = this.commanders.findIndex(c => c.name === casterName);
			if (currentCommanderIndex < 0) {
				throw new Error("Can\'t cast with non-existant commander " + casterName + '!');
				// throw new Error(`Can\'t cast with non-existant commander ${casterName}!`);
				// throw new Error("Cannot cast with non-existant commander " + casterName);
			}

			let currentCommander = this.commanders[currentCommanderIndex];
			let currentSpellIndex = currentCommander.spellbook.findIndex(s => s.name === spellName);
			if (currentSpellIndex < 0) {
				throw new Error(casterName + " doesn\'t know " + spellName);
				// throw new Error(casterName + " does not know " + spellName);
				// throw new Error(`${currentCommander.name} doesn\'t know ${spellName}!`);
			}

			let currentSpell = currentCommander.spellbook[currentSpellIndex];

			if (currentCommander.mana < currentSpell.manaCost) {
				throw new Error(ERROR_MESSAGES.NOT_ENOUGH_MANA);
			}

			let currentTargetUnitIndex = this.armyUnits.findIndex(u => u.id === targetUnitId);

			if (currentTargetUnitIndex < 0) {
				throw new Error(ERROR_MESSAGES.TARGET_NOT_FOUND);
			}

			let currentTargetUnit = this.armyUnits[currentTargetUnitIndex];

			currentSpell.effect(currentTargetUnit);
			currentCommander.mana -= currentSpell.manaCost;

			return this;
		},
		battle: function (attacker, defender) {
			if (!attacker.health || !attacker.damage || !attacker.count) {
				throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
			}

			if (!defender.health || !defender.damage || !defender.count) {
				throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
			}

			let attackerTotalDamage = attacker.damage * attacker.count;
			let defenderTotalHealth = defender.health * defender.count;
			let defenderTotalHealthAfterAttack = defenderTotalHealth - attackerTotalDamage;
			let newCount = Math.ceil(defenderTotalHealthAfterAttack / defender.health);

			if (newCount < 0) {
				defender.count = 0;
			}
			else {
				defender.count = newCount;
			}

			return this;
		}
	};

	return battlemanager;
}


const battlemanager = solve();

const cyki = battlemanager.getCommander('Cyki', 'good', 15),
    koce = battlemanager.getCommander('Koce', 'good', 20);

battlemanager.addCommanders(cyki, koce);

const penguins = battlemanager.getArmyUnit({
        name: 'Penguin Warriors',
        alignment: 'neutral',
        damage: 15,
        health: 40,
        speed: 10,
        count: 120
    }),
    cavalry = battlemanager.getArmyUnit({
        name: 'Horsemen',
        alignment: 'good',
        damage: 40,
        health: 60,
        speed: 50,
        count: 50
    });

const openVim = battlemanager.getSpell('Open vim', 10, target => target.damage -= 5),
    haste = battlemanager.getSpell('Haste', 5, target => target.speed += 5),
    callReinforcements = battlemanager.getSpell('Reinforcements', 10, target => target.count += 5)

battlemanager
        .addArmyUnitTo('Cyki', penguins)
        .addSpellsTo('Cyki', openVim, haste)
        .addArmyUnitTo('Koce', cavalry)
        .addSpellsTo('Koce', haste, callReinforcements)
        .spellcast('Koce', 'Haste', cavalry.id)
        .spellcast('Cyki', 'Open vim', cavalry.id)
        .battle(penguins, cavalry)
        .spellcast('Koce', 'Reinforcements', cavalry.id);

		console.log(battlemanager.commanders[0].spellbook);
		console.log(battlemanager.commanders[1].spellbook);

module.exports = solve;