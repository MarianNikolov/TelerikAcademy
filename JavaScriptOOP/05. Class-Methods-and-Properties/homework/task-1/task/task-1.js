'use strict';

class ListNode {
    constructor(value) {
        this._value = value;
        this._prev = null;
        this._next = null;
    }

    get prev() {
        return this._prev;
    }

    set prev(val) {
        this._prev = val;
    }

    get next() {
        return this._next;
    }

    set next(val) {
        this._next = val;
    }

    get value(){
        return this._value;
    }

    set value (val){
        this._value = val;
    }

    toString() {
        return this._value;
    }
}

class LinkedList {
    constructor() {
        this._first = null;
        this._last = null;
        this._length = 0;
    }

    get first() {
        return this._first.toString();
    }

    get last() {
        return this._last.toString();
    }

    get length() {
        return this._length;
    }

    append(...args) {
        for (let i = 0; i < args.length; i += 1) {
            let currentNode = new ListNode(args[i]);

            if (this._length === 0) {
                this._first = currentNode;
                this._last = currentNode;
                this._length += 1;
            }
            else {
                this._last.next = currentNode;
                currentNode.prev = this._last;
                this._last = currentNode;
                this._length += 1;
            }
        }

        return this;
    }

    prepend(...args) {
        for (let i = args.length - 1; i >= 0; i -= 1) {
            let currentNode = new ListNode(args[i]);

            if (this._length === 0) {
                this._first = currentNode;
                this._last = currentNode;
                this._length += 1;
            }
            else {
                this._first.prev = currentNode;
                currentNode.next = this._first;
                this._first = currentNode;
                this._length += 1;
            }
        }

        return this;
    }

    insert(index, ...args) {
        if (index === 0) {
            for (let i = args.length - 1; i >= 0; i -= 1) {
                this.prepend(args[i]);
            }

            return this;
        }

        let currentIndex = 0;

        let currentNode = this._first;

        while (currentNode) {
            if (currentIndex === index) {
                for (let i = 0; i < args.length; i += 1) {
                    let newNode = new ListNode(args[i]);

                    newNode.next = currentNode;

                    if (currentNode.prev) {
                        newNode.prev = currentNode.prev;
                    }
                    if (currentNode.prev.next) {
                        currentNode.prev.next = newNode;
                    }
                    if (currentNode.prev) {
                        currentNode.prev = newNode;
                    }

                    this._length += 1;
                }

                break;
            }

            currentNode = currentNode.next;

            currentIndex += 1;
        }

        return this;
    }

    removeAt(index) {
        if (index === 0) {
            let oldFirst = this._first;

            this._first.next.prev = null;
            this._first = this._first.next;
            oldFirst.next = null;

            this._length -= 1;

            return oldFirst.toString();
        }

        if (index === this.length - 1) {
            let oldLast = this._last;

            this._last.prev.next = null;
            this._last = this._last.prev;
            oldLast.prev = null;

            this._length -= 1;

            return oldLast.toString();
        }

        let currentIndex = 0;
        let currentNode = this._first;

        while (currentNode) {

            if (currentIndex === index) {
                let prev = currentNode.prev;
                currentNode.prev.next = currentNode.next;
                currentNode.next.prev = prev;
                currentNode.next = null;
                currentNode.prev = null;

                this._length -= 1;

                return currentNode.toString();
            }

            currentNode = currentNode.next;

            currentIndex += 1;
        }
    }

    at(index, ...args) {
        let currentIndex = 0;
        let currentNode = this._first;

        while (currentNode || currentIndex < this.length) {

            if (currentIndex === index) {
                if(args.length > 0) {
                    currentNode.value = args[0];
                }
                
                return currentNode.toString();
            }

            currentNode = currentNode.next;

            currentIndex += 1;
        }
    }

    toString() {
        let arr = [];
        let result = '';
        let currentNode = this._first;

        while (currentNode) {
            arr.push(currentNode.toString());
            currentNode = currentNode.next;
        }

        result = arr.join(" -> ");

        return result;
    }

    toArray() {
        let result = [];

        for (let node of this) {
            result.push(node);
        }

        return result;
    }

}

LinkedList.prototype[Symbol.iterator] = function* () {
    let currentNode = this._first;
    for (let i = 0; i < this._length; i += 1) {
        if (currentNode) {
            yield currentNode.toString();
        }

        currentNode = currentNode.next;
    }
};

let list = new LinkedList();

// list.append(1, 2);
// console.log("list - " + list.toString());
// list.insert(0, 3, 4);
// console.log("1 insert - " + list.toString());
// list.insert(list.length - 1, 'kremikovci');

// 3, 4, 1, 'kremikovci', 2

// list.append(1, 2, false, 3, 4);

// console.log(list.first);
// console.log(list.first.toString());
// console.log(list.length);
// console.log(list);
// console.log(list.toString());
// for (let item of list) {
//     console.log(item);
// }

module.exports = LinkedList;