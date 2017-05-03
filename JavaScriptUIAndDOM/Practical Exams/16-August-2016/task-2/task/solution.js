/*globals $*/

function solve() {
    return function (filesMap) {
        'use strict';

        var contentContainer = $('.file-content');
        var allFiles = $('.items');
        var allDeleteButtons = $('.del-btn');
        var addNewItemPlus = $('.add-btn');
        var dirFirstA = $('.dir-item > .item-name');

        allFiles.on('click', 'a.item-name', function () {
            console.log(5);
            var $this = $(this);
            var nameOfItem = $this.text();
            var contentOfFile;
            contentOfFile = filesMap[nameOfItem] || '';
            contentContainer.text(contentOfFile);
        });

        dirFirstA.on('click', function () {
            var $this = $(this);
            $this.parent().toggleClass('collapsed');
        });

        allFiles.on('click', '.del-btn', function () {
            var $this = $(this);
            $this.parent().remove();
        });

        addNewItemPlus.on('click', function (ev) {
            var $this = $(this);
            $this.toggleClass('visible');
            $('input').toggleClass('visible');
        });

        $('input').on('keydown', function (ev) {
            var $this = $(this);
            var enterKeyCode = 13;
            if (ev.keyCode === enterKeyCode) {
                $this.toggleClass('visible');
                addNewItemPlus.toggleClass('visible');

                var value = $this.val();
                $this.val('');

                var inputValues = value.split('/');

                if (inputValues.length === 1) {
                    var fileName = inputValues[0];

                    $(allFiles)
                        .append($('<li>').addClass('file-item item')
                            .append($('<a>').addClass('item-name').html(fileName))
                            .append($('<a>').addClass('del-btn')));
                }
                else {
                    var dirName = inputValues[0];
                    var fileToAddName = inputValues[1];

                    dirFirstA.each(function (index, element) {
                        var $el = $(element);
                        if ($el.html() === dirName) {
                            $el.parent().find('ul')
                                .append($('<li>').addClass('file-item item')
                                    .append($('<a>').addClass('item-name').html(fileToAddName))
                                    .append($('<a>').addClass('del-btn')));
                        }
                    });
                }
            }
        });
    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}