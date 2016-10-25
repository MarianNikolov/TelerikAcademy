--01 What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
	--   ** SQL is Declarative language for query and manipulation of relational data **
	--   ** DML (Data Manipulation Language) is piece of SQL and represent SELECT, INSERT, UPDATE, DELETE commands **
	--   ** DML (Data Definition Language) is piece of SQL and represent CREATE, DROP, ALTER, GRANT, REVOKE commands **

--02 What is Transact-SQL (T-SQL)?
	--   ** T-SQL is an extension to the standard SQL language. T-SQL is the standard language used in MS SQL Server. **
	--   ** Supports if statements, loops, exceptions. **
	--   ** T-SQL is used for writing stored procedures, functions, triggers, etc. **

--03 Start SQL Management Studio and connect to the database TelerikAcademy. 
--   Examine the major tables in the "TelerikAcademy" database.
	--   ** see picture in zip ** 

--04 Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
USE TelerikAcademy
SELECT *
FROM Departments

--05 Write a SQL query to find all department names.
USE TelerikAcademy
SELECT Name
FROM Departments

--06 Write a SQL query to find the salary of each employee.
USE TelerikAcademy
SELECT Salary
FROM Employees

--07 Write a SQL to find the full name of each employee.
USE TelerikAcademy
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS FullName
FROM Employees

--08 Write a SQL query to find the email addresses of each employee 
--   (by his first and last name). Consider that the mail domain is telerik.com. 
--   Emails should look like “John.Doe@telerik.com". 
--   The produced column should be named "Full Email Addresses".
USE TelerikAcademy
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
FROM Employees

--09 Write a SQL query to find all different employee salaries.
USE TelerikAcademy
SELECT Distinct Salary 
FROM Employees

--10 Write a SQL query to find all information about the 
--   employees whose job title is “Sales Representative“.
USE TelerikAcademy
SELECT * 
FROM Employees
WHERE JobTitle = 'Sales Representative'

--11 Write a SQL query to find the names of all employees 
--   whose first name starts with "SA".
USE TelerikAcademy
SELECT FirstName
FROM Employees
WHERE FirstName LIKE 'SA%'

--12 Write a SQL query to find the names of all employees 
--   whose last name contains "ei".
USE TelerikAcademy
SELECT LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--13 Write a SQL query to find the salary of all employees 
--   whose salary is in the range [20000…30000].
USE TelerikAcademy
SELECT Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

--14 Write a SQL query to find the names of all employees 
--   whose salary is 25000, 14000, 12500 or 23600.
USE TelerikAcademy
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS FullName, Salary
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

--15 Write a SQL query to find all employees that do not have manager.
USE TelerikAcademy
SELECT * 
FROM Employees
WHERE ManagerID IS NULL

--16 Write a SQL query to find all employees that have salary 
--   more than 50000. Order them in decreasing order by salary.
USE TelerikAcademy
SELECT * 
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--17 Write a SQL query to find the top 5 best paid employees.
USE TelerikAcademy
SELECT TOP 5 * 
FROM Employees
ORDER BY Salary DESC

--18 Write a SQL query to find all employees along with their address. 
--   Use inner join with ON clause.
USE TelerikAcademy
SELECT e.FirstName, e.LastName AS Names, a.AddressText
FROM Employees e	
	INNER JOIN Addresses a
	ON a.AddressID = e.AddressID

--19 Write a SQL query to find all employees and their address. 
--   Use equijoins (conditions in the WHERE clause).
USE TelerikAcademy
SELECT e.FirstName, e.LastName, a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

--20 Write a SQL query to find all employees along with their manager.
USE TelerikAcademy
SELECT e.FirstName, e.LastName, m.FirstName AS ManagerName
FROM Employees e 
	INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID

--21 Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.
USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName AS Employee, m.FirstName + ' ' + m.LastName AS Manager, a.AddressText as [Address]
FROM Employees e 
	INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
	INNER JOIN Addresses a
	ON a.AddressID = e.AddressID

--22 Write a SQL query to find all departments and all town names 
--   as a single list. Use UNION.
USE TelerikAcademy
SELECT d.Name AS DepartmentsAndTowns
FROM Departments d
UNION
SELECT t.Name
FROM Towns t

--23 Write a SQL query to find all the employees and the manager 
--   for each of them along with the employees that do not have manager. 
--   Use right outer join. 
USE TelerikAcademy
SELECT e.FirstName AS Employe, m.FirstName AS Manager
FROM Employees m
	RIGHT OUTER JOIN Employees e
	ON m.EmployeeID = e.ManagerID

--   Rewrite the query to use left outer join.
USE TelerikAcademy
SELECT e.FirstName AS Employee, m.FirstName AS Manager
FROM Employees e
	LEFT OUTER JOIN Employees m
	ON m.EmployeeID = e.ManagerID

--24 Write a SQL query to find the names of all employees 
--   from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName AS Employee, d.Name, YEAR(e.HireDate)
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Finance' 
		OR d.Name = 'Sales'
		AND YEAR(e.HireDate) BETWEEN 1995 AND 2005