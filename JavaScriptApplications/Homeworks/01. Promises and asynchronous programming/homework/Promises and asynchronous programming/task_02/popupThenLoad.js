/* globals $ */
let url = 'https://www.youtube.com/watch?v=3rYWoV4Eu_U';
let redirectButton = $('#button-redirect');
redirectButton.on('click', function () {
	showPopup();
	redirectToDifferentSitePromise(url).then(redirect);
});

function redirectToDifferentSitePromise(url) {
	return new Promise(function (resolve, reject) {
		setTimeout(function () {
			resolve(url);
		}, 2000);
	});
}

function redirect(url) {
	$(location).attr('href', url);
}

function showPopup() {
	let $body = $('body')
		.append($('<div>').attr('id', 'myModal').attr('role', 'dialog').addClass('modal fade')
			.append($('<div>').addClass('modal-dialog')
				.append($('<div>').addClass('modal-content')
					.append($('<div>').addClass('modal-body')
						.append($('<h3>').text('You will be redirect after 2 second!').addClass('text-center'))))));
}