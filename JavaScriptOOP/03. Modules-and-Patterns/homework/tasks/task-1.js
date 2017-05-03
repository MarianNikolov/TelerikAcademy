/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
	let validator = (function () {
		function titleValidator(title) {
			let minTitleLength = 1;
			if (!title || title.length < minTitleLength) {
				throw Error('Titles have at least one character!');
			}

			if (title[0] === ' ' || title[title.length - 1] === ' ') {
				throw Error('Titles do not start or end with spaces');
			}

			for (let i = 0; i < title.length - 1; i += 1) {
				if (title[i] === ' ' && title[i + 1] === ' ') {
					throw Error('Titles do not have consecutive spaces!');
				}
			}
		}

		function presentationsValidator(presentations) {
			if (!presentations || presentations.length === 0) {
				throw Error('Not submitted presentations!');
			}

			for (let i = 0; i < presentations.length; i += 1) {

				if (!presentations[i]) {
					throw Error('Current presentation is invalid!');
				}

				for (let j = 0; j < presentations[i].length - 1; j += 1) {
					if (presentations[i][j] === ' ' && presentations[i][j + 1] === ' ') {
						throw Error('Presentation do not have consecutive spaces!');
					}
				}
			}
		}

		function studentNamesValidator(names) {
			let regex = /^[A-Z][a-z]*/;
			for (let i = 0; i < names.length; i += 1) {
				if (!regex.test(names[i])) {
					throw Error(`Name of student must be start with an upper case letter and other symbols in the name (if any) must be lowercase letters!`);
				}
			}
		}

		function studentNumberOfNamesValidator(names) {
			if (names.length !== 2) {
				throw Error('Names of student must be two!');
			}
		}

		function studentIdValidator(studentID, studentsInCourse) {
			if (studentID < 1 || studentID > studentsInCourse.length || studentID % 1 !== 0) {
				throw Error("Student ID is invalid!");
			}
		}

		function homeworkIdValidator(homeworkId, coursePresentations) {
			if (homeworkId < 1 || homeworkId > coursePresentations.length || homeworkId % 1 !== 0) {
				throw Error("Homework ID is invalid!");
			}
		}

		function examResultsValidator(results, studentsInCourse) {
			if (!Array.isArray(results)) {
				throw Error("Results should be a array!");
			}

			if (!results) {
				throw Error("Result are empty!");
			}

			for (let i = 0; i < results.length; i += 1) {
				if (!isNumeric(results[i].score)) {
					throw Error("Score is not a number!");
				}

				if (results[i].StudentID < 1 || results[i].StudentID > studentsInCourse.length || results[i].StudentID % 1 !== 0) {
					throw Error("Result is invalid!");
				}
			}
		}

		function isNumeric(n) {
			return !isNaN(parseFloat(n)) && isFinite(n);
		}

		return {
			checkTitle: titleValidator,
			checkPresentations: presentationsValidator,
			checkStudentNames: studentNamesValidator,
			checkNumberOfStudentNames: studentNumberOfNamesValidator,
			checkStudentId: studentIdValidator,
			checkHomeworkId: homeworkIdValidator,
			checkExamResults: examResultsValidator
		};
	})();

	let idGenerator = function () {
		let id = 0;

		function getUniqueId() {
			return id += 1;
		}

		return {
			getNextId: getUniqueId
		};
	};

	var Course = {
		init: function (title, presentations) {
			validator.checkTitle(title);
			validator.checkPresentations(presentations);

			this.courseTitle = title;
			this.coursePresentations = presentations;
			this.studentsInCourse = [];
			this.studentIdGenerator = idGenerator();
			this.homeworkIdGenerator = idGenerator();

			return this;
		},
		addStudent: function (name) {
			let names = name.split(' ');
			validator.checkNumberOfStudentNames(names);
			validator.checkStudentNames(names);

			let currentStudent = {
				firstName: names[0],
				lastName: names[1],
				studentID: this.studentIdGenerator.getNextId(),
				submitedHomeworks: [],
				examResult: 0
			};

			this.studentsInCourse.push(currentStudent);

			return currentStudent.studentID;
		},
		getAllStudents: function () {
			let studentsListDeepCopy = [];

			for (let i = 0; i < this.studentsInCourse.length; i += 1) {
				let currentStudentDeepCopy = {
					firstname: this.studentsInCourse[i].firstName,
					lastname: this.studentsInCourse[i].lastName,
					id: this.studentsInCourse[i].studentID
				};

				studentsListDeepCopy.push(currentStudentDeepCopy);
			}

			return studentsListDeepCopy;
		},
		submitHomework: function (studentID, homeworkID) {
			validator.checkStudentId(studentID, this.studentsInCourse);
			validator.checkHomeworkId(homeworkID, this.coursePresentations);

			for (let i = 0; i < this.studentsInCourse.length; i += 1) {
				if (this.studentsInCourse[i].studentID === studentID) {
					this.studentsInCourse[i].submitedHomeworks.push(homeworkID);
				}
			}
		},
		pushExamResults: function (results) {
			validator.checkExamResults(results, this.studentsInCourse);

			for (let i = 0; i < results.length; i += 1) {
				for (let j = 0; j < this.studentsInCourse.length; j += 1) {

					if (results[i].StudentID === this.studentsInCourse[j].studentID) {
						if (this.studentsInCourse[j].examResult === 0) {
							this.studentsInCourse[j].examResult = results[i].score;

						}
						else {
							throw Error("Student tried to cheat!");
						}
					}
				}
			}
		},
		getTopStudents: function () {

		// Create method getTopStudents() which returns an array of the top 10 performing students
			// Array must be sorted from best to worst
			// If there are less than 10, return them all
			// The final score that is used to calculate the top performing students is done as follows:
				// 75% of the exam result
				// 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course


		}
	};

	return Course;
}


module.exports = solve;
