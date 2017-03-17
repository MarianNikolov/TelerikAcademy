let button = document.getElementsByTagName("button")[0];
let input = document.getElementsByTagName("input")[0];
let ul = document.getElementsByTagName("ul")[0];
let title = document.getElementsByTagName("div")[0];
let size = 22;
title.style.fontSize = size + 'px';

button.addEventListener('click', function (ev) {
	let text = input.value;
	let newLi = document.createElement('li');
	console.log(ev);
	newLi.innerHTML = text;
	ul.appendChild(newLi);
});


title.addEventListener('wheel', function (e) {
	if (e.deltaY < 0) {
		let size = e.target.style.fontSize += 5;
		size + 'px';
		console.log(size);
	}
	else {
		e.target.style.fontSize = (size - 1) + 'px';
	}
});