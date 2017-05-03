function solve() {

	return function (selector, defaultLeft, defaultRight) {
		var fragment = document.createDocumentFragment();
		var root = document.querySelector(selector);
		var leftColumn = defaultLeft || [];
		var rightColumn = defaultRight || [];

		var columnContainer = document.createElement('div');
		columnContainer.className = 'column-container';

		function isEmptyOrSpaces(str) {
			return str === null || str.match(/^ *$/) !== null;
		}

		//input and button 
		var input = document.createElement('input');
		// TODO delete
		input.size = "40";
		input.autofocus = true;
		var button = document.createElement('button');
		button.innerHTML = 'Add';

		//LEFT 
		var columnLeft = document.createElement('div');
		columnLeft.className = 'column';
		var leftContainerSelect = document.createElement('div');
		leftContainerSelect.className = 'select';
		var leftContainerList = document.createElement('ol');
		var inputRadioLeft = document.createElement('input');
		inputRadioLeft.type = 'radio';
		inputRadioLeft.checked = true;
		inputRadioLeft.name = 'column-select';
		inputRadioLeft.id = 'select-left-column';
		// label
		var labelLeft = document.createElement('label');
		labelLeft.setAttribute('for', 'select-left-column');
		labelLeft.innerHTML = 'Add here';
		leftContainerSelect.appendChild(inputRadioLeft);
		leftContainerSelect.appendChild(labelLeft);
		columnLeft.appendChild(leftContainerSelect);
		columnLeft.appendChild(leftContainerList);

		var imgDelete = document.createElement('img');
		imgDelete.className = 'delete';
		imgDelete.src = 'imgs/Remove-icon.png';

		//RIGHT 
		var columnRight = document.createElement('div');
		columnRight.className = 'column';
		var rightContainerSelect = document.createElement('div');
		rightContainerSelect.className = 'select';
		var rightContainerList = document.createElement('ol');
		var inputRadioRight = document.createElement('input');
		inputRadioRight.type = 'radio';
		inputRadioRight.name = 'column-select';
		inputRadioRight.id = 'select-right-column';
		// label
		var labelRight = document.createElement('label');
		labelRight.setAttribute('for', 'select-right-column');
		labelRight.innerHTML = 'Add here';
		rightContainerSelect.appendChild(inputRadioRight);
		rightContainerSelect.appendChild(labelRight);
		columnRight.appendChild(rightContainerSelect);
		columnRight.appendChild(rightContainerList);

		// add left initial items
		for (var i = 0; i < leftColumn.length; i += 1) {
			if (leftColumn[i] === null || leftColumn[i] === undefined || leftColumn[i].trim() === '') {
				continue;
			}
			var currentLi = document.createElement('li');
			currentLi.className = 'entry';
			// TODO ? innerText
			var currentImgLeft = imgDelete.cloneNode(true);
			currentLi.appendChild(currentImgLeft);
			currentLi.innerHTML += leftColumn[i].trim();
			currentLi.setAttribute('title', leftColumn[i].trim());
			leftContainerList.appendChild(currentLi);
		}

		// add right initial items
		for (var j = 0; j < rightColumn.length; j += 1) {
			if (rightColumn[j] === null || rightColumn[j] === undefined || rightColumn[j].trim() === '') {
				continue;
			}
			var currentLiRight = document.createElement('li');
			currentLiRight.className = 'entry';
			var currentImgRight = imgDelete.cloneNode(true);
			currentLiRight.appendChild(currentImgRight);
			currentLiRight.innerHTML += rightColumn[j].trim();
			currentLiRight.setAttribute('title', rightColumn[j].trim());
			rightContainerList.appendChild(currentLiRight);
		}

		button.addEventListener('click', function (ev) {
			var target = ev.target;
			var value = input.value;

			if (value === null || value === undefined || value.trim() === '') {
				return;
			}

			input.value = '';
			var currentLi = document.createElement('li');
			currentLi.className = 'entry';
			currentLi.setAttribute('title', value.trim());
			// TODO ? innerText
			var currentImg = imgDelete.cloneNode(true);
			currentLi.innerHTML += value.trim();
			currentLi.appendChild(currentImg);

			if (inputRadioLeft.checked) {
				leftContainerList.appendChild(currentLi);
			}
			else {
				rightContainerList.appendChild(currentLi);
			}
		});

		leftContainerList.addEventListener('click', function (ev) {
			var target = ev.target;
			if (target.tagName === 'IMG') {
				var liForRemoveLeft = target.parentNode;
				input.value = liForRemoveLeft.title;
				liForRemoveLeft.parentNode.removeChild(liForRemoveLeft);
			}
		});

		rightContainerList.addEventListener('click', function (ev) {
			var target = ev.target;
			if (target.tagName === 'IMG') {
				var liForRemoveRight = target.parentNode;
				input.value = liForRemoveRight.title;
				liForRemoveRight.parentNode.removeChild(liForRemoveRight);
			}
		});

		columnContainer.appendChild(columnLeft);
		columnContainer.appendChild(columnRight);

		fragment.appendChild(columnContainer);
		fragment.appendChild(input);
		fragment.appendChild(button);

		root.appendChild(fragment);
	};
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
	module.exports = solve;
}
