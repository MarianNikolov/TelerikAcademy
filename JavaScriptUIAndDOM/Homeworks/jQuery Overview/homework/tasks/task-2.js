/* globals $, jQuery */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 

*/
function solve() {
  return function (selector) {
    if (!selector || typeof selector !== 'string') { // || !(selector instanceof jQuery)
      throw new Error('invalid selector');
    }

    var root = $(selector);

    if (!root) {
      throw new Error('selector');
    }

    var buttons = root.find('.button').html('hide');

    root.on('click', '.button', function () {
      var currentButton = $(this);
      currentButton.siblings('.content').each(function () {

        var currentContent = $(this);

        console.log(currentContent.next().attr('class'));

        if (currentContent.next()) {
          if (currentContent.next().attr('class').indexOf('.button') >= 0) {

            currentContent.toggle();

            if (currentButton.html() === 'show') {
              currentButton.html('hide');
            }
            else {
              currentButton.html('show');
            }

            return;
          }
        }

      });
    });

  };
}

module.exports = solve;