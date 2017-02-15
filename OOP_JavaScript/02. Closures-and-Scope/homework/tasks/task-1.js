/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
	var library = (function () {

		var books = [];
		var categories = [];

		function listBooks(book) {

			if (books.length < 1) {
				return [];
			}

			// Books are sorted by ID
			if (!!book) {
				// This can be done by author, by category or all
				if (!!book.author) {
					let booksWhitCurrentCategory = books.filter((b) => b.author === book.author);
					let booksForReturn = booksWhitCurrentCategory.map((b) => {
						return {
							ID: b.ID,
							author: b.author,
							category: b.category,
							isbn: b.isbn,
							title: b.title
						};
					});
					return booksForReturn.sort((x, y) => x.ID - y.ID);
				}
				else if (!!book.category) {
					if (categories.indexOf(book.category) > -1) {
						let booksWhitCurrentCategory = books.filter((b) => b.category === book.category);
						let booksForReturn = booksWhitCurrentCategory.map((b) => {
							return {
								ID: b.ID,
								author: b.author,
								category: b.category,
								isbn: b.isbn,
								title: b.title
							};
						});

						return booksForReturn.sort((x, y) => x.ID - y.ID);
					}
					else {
						return [];
					}
				}
			}
			else {
				let booksForReturn = books.map((b) => {
					return {
						ID: b.ID,
						author: b.author,
						category: b.category,
						isbn: b.isbn,
						title: b.title
					};
				});

				return booksForReturn.sort((x, y) => x.ID - y.ID);
			}
		}

		function addBook(book) {
			// Book title and category name must be between 2 and 100 characters, 
			// including letters, digits and special characters ('!', ',', '.', etc)
			let isInvalidTitleName = book.title.length < 2 || book.title.length > 100;
			let isInvalidCategoryName = book.category.length < 2 || book.category.length > 100;

			if (isInvalidTitleName || isInvalidCategoryName) {
				throw Error("The title and category length must be between 2 and 100!");
			}

			// Author is any non-empty string
			if (!book.author) {
				throw Error("The author name is invalid!");
			}

			// Book ISBN is an unique code that contains either 10 or 13 digits
			if (book.isbn.length !== 10 && book.isbn.length !== 13) {
				throw Error("The ISBN length must be contains either 10 or 13 digits!");
			}

			// Unique params are Book title and Book ISBN

			// Each book has unique title, author and ISBN
			for (let i = 0; i < books.length; i += 1) {
				let isNotUniqueAuthor = books[i].title === book.title;
				let isNotUniqueISBN = books[i].isbn === book.isbn;
				// let isNotUniqueTitle = books[i].author === book.author;

				if (isNotUniqueAuthor || isNotUniqueISBN) {
					throw Error("The book is not unique!");
				}
			}

			// It must return the newly created book with assigned ID
			book.ID = books.length + 1;

			// If the category is missing, it must be automatically created
			let isCategoryMissing = true;
			for (let i = 0; i < categories.length; i += 1) {
				if (categories[i] === book.category) {
					isCategoryMissing = false;
					break;
				}
			}

			if (isCategoryMissing) {
				categories.push(book.category);
			}

			books.push(book);
			return book;
		}

		function listCategories() {
			let categoriesForReturn = categories.map(x => { return x; });

			return categoriesForReturn;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());

	return library;
}

module.exports = solve;
