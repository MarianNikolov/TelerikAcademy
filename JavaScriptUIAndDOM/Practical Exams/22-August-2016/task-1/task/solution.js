function solve() {
    return function (selector, tabs) {
        var root = document.querySelector(selector);
        var fragment = document.createDocumentFragment();

        var ulNav = document.createElement('ul');
        ulNav.className = 'tabs-nav';
        var ulContent = document.createElement('ul');
        ulContent.className = 'tabs-content';

        var counter = 1;

        for (var tab of tabs) {
            var liNav = document.createElement('li');
            var aNav = document.createElement('a');
            aNav.className = 'tab-link';
            aNav.innerHTML = tab.title;
            aNav.setAttribute("title", tab.content);

            liNav.appendChild(aNav);
            ulNav.appendChild(liNav);

            var liContent = document.createElement('li');
            var pContent = document.createElement('p');
            var buttonContent = document.createElement('button');
            liContent.className = 'tab-content';
            if (counter === 1) {
                liContent.className += ' visible';
            }
            pContent.innerHTML = tab.content;
            pContent.setAttribute("title", tab.title);
            buttonContent.className = 'btn-edit';
            buttonContent.innerHTML = 'Edit';

            liContent.appendChild(pContent);
            liContent.appendChild(buttonContent);
            ulContent.appendChild(liContent);

            counter += 1;
        }

        HTMLElement.prototype.removeClass = function (remove) {
            var newClassName = "";
            var i;
            var classes = this.className.split(" ");
            for (i = 0; i < classes.length; i++) {
                if (classes[i] !== remove) {
                    newClassName += classes[i] + " ";
                }
            }
            this.className = newClassName;
        };

        ulNav.addEventListener('click', function (ev) {
            var target = ev.target;

            if (target.tagName === 'A') {
                for (var i = 0; i < ulContent.children.length; i += 1) {
                    var currentButtonName = target.innerHTML;
                    var currentLiContentName = ulContent.children[i].firstChild.title;

                    if (currentButtonName === currentLiContentName) {
                        ulContent.children[i].className += ' visible';
                    }
                    else {
                        ulContent.children[i].removeClass('visible');
                    }
                }
            }
        });

        ulContent.addEventListener('click', function (ev) {
            var target = ev.target;

            if (target.tagName === 'BUTTON') {
                if (target.innerHTML === 'Save') {
                    target.innerHTML = 'Edit';
                    var textareaForRemove = ulContent.getElementsByClassName('edit-content')[0];
                    var textareaValue = textareaForRemove.value;
                    target.previousSibling.innerHTML = textareaValue;
                    textareaForRemove.parentNode.removeChild(textareaForRemove);
                }
                else if (target.innerHTML === 'Edit') {
                    target.innerHTML = 'Save';
                    var textArea = document.createElement('TEXTAREA');
                    textArea.className = 'edit-content';
                    textArea.value = target.previousSibling.innerHTML;
                    target.parentNode.appendChild(textArea);
                }
            }

        });

        fragment.appendChild(ulNav);
        fragment.appendChild(ulContent);
        root.appendChild(fragment);
    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}