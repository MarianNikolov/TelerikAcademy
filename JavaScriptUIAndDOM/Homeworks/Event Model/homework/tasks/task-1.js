/* globals $ */

/* 
Create a function that takes an id or DOM element and:
    If an id is provided, select the element
    Finds all elements with class button or content within the provided element
        Change the content of all .button elements with "hide"
    When a .button is clicked:
        Find the topmost .content element, that is before another .button and:
            If the .content is visible:
                Hide the .content
                Change the content of the .button to "show"
            If the .content is hidden:
                Show the .content
                Change the content of the .button to "hide"
            If there isn't a .content element after the clicked .button and before other .button, do nothing
    Throws if:
        The provided DOM element is non-existant
        The id is neither a string nor a DOM element
*/


function solve() {
  return function (selector) {
    var selectedElement;
    if (typeof selector === 'string' || typeof selector === 'number') {
      selectedElement = document.getElementById(selector);
      if (!selectedElement) {
        throw 'dwarf';
      }
    }
    else if (selector.tagName) {
      selectedElement = selector;
    }
    else {
      throw 'dwarf';
    }

    var buttonsClass = selectedElement.getElementsByClassName('button');

    if (!buttonsClass) {
      throw 'dwarf';
    }

    for (var i = 0; i < buttonsClass.length; i += 1) {
      buttonsClass[i].innerHTML = 'hide';
      buttonsClass[i].addEventListener('click', eventForButtons);
    }

    function eventForButtons(ev) {
      var target = ev.target;
      var sibling = target.nextElementSibling;
      
      // if(sibling.classList.contains('content')) {  
      while ((' ' + sibling.className + ' ').indexOf(' button ') === -1) {
        if ((' ' + sibling.className + ' ').indexOf(' content ') === -1) {
          sibling = sibling.nextElementSibling;
        }
        else {
          if (sibling.style.display === '') {
            sibling.style.display = 'none';
            target.innerHTML = 'show';
          }
          else {
            sibling.style.display = '';
            target.innerHTML = 'hide';
          }

          break;
        }
      }
    }
  };
}

module.exports = solve;