/*globals $*/

function solve() {

	return function (selector, rows, columns) {
		var ALPHABET = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'V', 'X', 'Y', 'Z'];
		var root = $(selector);
		var currentCell;
		var currentRow;

		// TODO check rows and columns - positive integer number

		var table = $('<table>').addClass('spreadsheet-table');

		for (var row = 0; row < rows + 1; row += 1) {
			currentRow = $('<tr>');

			for (var col = 0; col < columns + 1; col += 1) {
				currentCell = $('<th>').addClass('spreadsheet-header spreadsheet-item');
				if (row === 0 && col === 0) {
					currentCell.attr('id', 'centerHead');
				}
				else if (row === 0) {
					currentCell.html(ALPHABET[col - 1]);
				}
				else if (col === 0) {
					currentCell.html(row);
				}
				else {
					currentCell = $('<td>').addClass('spreadsheet-cell spreadsheet-item');
					currentCell.append($('<input>')).append($('<span>'));
				}

				currentRow.append(currentCell);
			}

			table.append(currentRow);
		}

		root.append(table);
		return this;
	};
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
	module.exports = solve;
}
