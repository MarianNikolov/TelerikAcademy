/* globals document, window, console */

// DO NOT USE innerText -> replace whit innerHTML

function solve() {
    return function (selector, initialSuggestions) {

        var root = document.querySelector(selector);
        var suggestions = initialSuggestions || [];
        var ul = document.getElementsByClassName('suggestions-list')[0];
        var input = document.getElementsByClassName('tb-pattern')[0];
        var button = document.getElementsByClassName('btn-add')[0];

        var li = document.createElement('li');
        li.className = 'suggestion';
        li.style.display = 'none';
        var a = document.createElement('a');
        a.setAttribute('href', '#');
        a.className = 'suggestion-link';
        li.appendChild(a);

        var addedSuggestions = {};

        for (var item of suggestions) {
            if (!addedSuggestions[item.toLowerCase()]) {
                addedSuggestions[item.toLowerCase()] = true;
                var cloneLi = li.cloneNode(true);
                cloneLi.firstChild.innerHTML = item;
                ul.appendChild(cloneLi);
            }
        }

        input.addEventListener('input', function (ev) {
            var value = ev.target.value.toLowerCase();
            var allSuggestionLinks = document.getElementsByClassName('suggestion-link');

            for (var i = 0; i < allSuggestionLinks.length; i += 1) {
                var currentLink = allSuggestionLinks[i];
                if (value.length === 0) {
                    currentLink.parentElement.style.display = 'none';
                    continue;
                }
                if (currentLink.innerHTML.toLocaleLowerCase().indexOf(value) >= 0) {
                    currentLink.parentElement.style.display = 'block';
                }
                else {
                    currentLink.parentElement.style.display = 'none';
                }
            }
        });

        button.addEventListener('click', function () {
            var inputValue = input.value;

            if (!addedSuggestions[inputValue.toLocaleLowerCase()]) {
                addedSuggestions[inputValue.toLocaleLowerCase()] = true;
                var cloneLi = li.cloneNode(true);
                cloneLi.firstChild.innerHTML = inputValue;
                ul.appendChild(cloneLi);
            }
        });

        ul.addEventListener('click', function(ev){
            var target = ev.target;
            if(target.tagName === 'A') {
                input.value = target.innerHTML;
            }
            if(target.tagName === 'LI') {
                input.value = target.firstChild.innerHTML;
            }
        });
    };
}

module.exports = solve;