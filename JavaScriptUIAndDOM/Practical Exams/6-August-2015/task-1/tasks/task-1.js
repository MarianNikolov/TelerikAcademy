function solve() {
  return function (selector, isCaseSensitive) {
    var fragment = document.createDocumentFragment();
    var root = document.querySelector(selector);
    var isCaseSens = isCaseSensitive || false;
    root.className = 'items-control';

    //add items container
    var addContainer = document.createElement('div');
    addContainer.className = 'add-controls';
    var span = document.createElement('label');
    span.innerHTML = 'Enter text';
    var input = document.createElement('input');
    var addButton = document.createElement('button');
    addButton.className = 'button';
    addButton.innerHTML = 'Add';
    addContainer.appendChild(span);
    addContainer.appendChild(input);
    addContainer.appendChild(addButton);

    //search items container
    var searchContainer = document.createElement('div');
    searchContainer.className = 'search-controls';
    var spanForSearch = document.createElement('label');
    spanForSearch.innerHTML = 'Search:';
    var inputForSearch = document.createElement('input');
    searchContainer.appendChild(spanForSearch);
    searchContainer.appendChild(inputForSearch);

    //result items container
    var resultContainer = document.createElement('div');
    resultContainer.className = 'result-controls';
    var itemsList = document.createElement('ul');
    itemsList.className = 'items-list';
    resultContainer.appendChild(itemsList);

    addButton.addEventListener('click', function (ev) {
      var target = ev.target;

      if (target.className.indexOf('button') !== -1) {
        var currentLi = document.createElement('li');
        var button = document.createElement('button');
        var spanText = document.createElement('label');
        button.className = 'button';
        button.innerHTML = 'X';
        currentLi.className = 'list-item';
        spanText.innerHTML = input.value;
        input.value = '';
        currentLi.appendChild(button);
        currentLi.appendChild(spanText);
        itemsList.appendChild(currentLi);
      }
    });

    inputForSearch.addEventListener('keyup', function (ev) {
      var target = ev.target;
      var value = target.value;
      var allLis = resultContainer.getElementsByClassName('list-item');

      for (var li of allLis) {
        var liInnerHTML = li.firstChild.nextSibling.innerHTML;
        if (isCaseSens) {
          if (liInnerHTML.indexOf(value) !== -1) {
            li.style.display = '';
          }
          else {
            li.style.display = 'none';
          }
        }
        else {
          if (liInnerHTML.toLowerCase().indexOf(value.toLowerCase()) !== -1) {
            li.style.display = '';
          }
          else {
            li.style.display = 'none';
          }
        }
      }
    });

    itemsList.addEventListener('click', function (ev) {
      var target = ev.target;

      if (target.tagName === 'BUTTON') {
        target.parentNode.parentNode.removeChild(target.parentNode);
      }
    });

    fragment.appendChild(addContainer);
    fragment.appendChild(searchContainer);
    fragment.appendChild(resultContainer);
    root.appendChild(fragment);
  };
}