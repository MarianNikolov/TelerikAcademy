/* globals $ */

/* 
Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

module.exports = function () {

  return function (element, contents) {
    var givenElement;

    if (typeof element === 'string') {
      givenElement = document.getElementById(element);
      if (!givenElement) {
        throw 'here is no element that has such an id';
      }
    }
    else if (typeof element === 'object' && element.tagName) {
      givenElement = element;
    }
    else {
      throw 'dwarf';
    }

    var fragment = document.createDocumentFragment();

    for (var content of contents) {
      console.log(typeof content);
      if (typeof content !== 'string' && typeof content !== 'number') {
        throw 'dwarf';
      }

      var currentDiv = document.createElement('div');
      currentDiv.innerHTML = content;
      fragment.appendChild(currentDiv);
    }

    givenElement.innerHTML = '';
    givenElement.appendChild(fragment);
  };
};