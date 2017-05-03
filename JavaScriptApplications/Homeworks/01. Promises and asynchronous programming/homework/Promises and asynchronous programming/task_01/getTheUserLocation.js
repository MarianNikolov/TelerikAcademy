/* globals $, alert */

let buttonGeolocation = $('#button-geolocation');
buttonGeolocation.on('click', function () {
	let $this = $(this);

	let promise = new Promise(function (resolve, reject) {

		if ("geolocation" in navigator) {
			navigator.geolocation.getCurrentPosition(function (position) {
				let coordinates = {
					latitude: position.coords.latitude,
					longitude: position.coords.longitude
				};

				resolve(coordinates);
			});
		} else {
			alert('Your browser do not support get geolocation!');
		}
	});

	promise
	.then(function (coordinates) {
		createGeolocationInfo(coordinates);
	})
	.catch(function(err){
		console.log('Get coordinates does not work correctly. ' + err);
	});
});

function createGeolocationInfo(coordinates) {
	let $imgElement = $('<img>'),
		$mapContainer = $('<div>').addClass('container well'),
		imgSrc = `http://maps.googleapis.com/maps/api/staticmap?center=${coordinates.latitude}, ${coordinates.longitude}&zoom=17&size=900x900&sensor=false`;

	$imgElement.attr('src', imgSrc).addClass('img-responsive center-block');
	$mapContainer.append($imgElement);

	$.getJSON(`http://maps.googleapis.com/maps/api/geocode/json?latlng=${coordinates.latitude}, ${coordinates.longitude}`,
		function (data) {
			$mapContainer.prepend($('<h3>').addClass('text-center').html(`<strong>Your location is:</strong> ${data.results[0].formatted_address}`));
		});

	$('body').append($mapContainer);
}