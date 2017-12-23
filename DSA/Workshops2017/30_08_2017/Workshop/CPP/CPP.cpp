// CPP.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <string>
#include <iostream>
#include <stdio.h>
#include <vector>
using namespace std;

int main()
{
	// std => namespace in spp
	// std => List<int> variable => vector
	std::vector<int> tests = { 0, 1, 6, 9, 10, 11, 12, 71, 74, 79, 99, 100, 999, 1000, 9900, 9999, 999000 };

	// auto => var
	// & => reference to memory
	// t name of parameter
	for (const auto&t : tests) {
		Console.Write(
			(nearestPalindrome(t) == specNearestPalindrome(t) ? "." : "X");
	}
	// std:: => system.Console...
	// endl => new line in console
	Console.Write(std::endl);

	return 0;
}

template<class T>
// T => type of variable
// & => reference to memory
// v variable
string to_string(const T& v) {
	stringstream ss;
	ss << v;
	return ss.str();
}

// Nor do I have std::stoi. :(
// stoi => string to integer => "s" = string "to" "i" = integer
int stoi(const string& s)
{
	stringstream ss(s);
	int v;
	ss >> v;
	return v;
}

bool isPalindrome(int n)
{
	const auto s = to_string(n);
	return s == string(s.rbegin(), s.rend());
}

int specNearestPalindrome(int n)
{
	assert(0 <= n);

	int less = n, more = n;
	while (true)
	{
		if (isPalindrome(less != 0)) 
		{ 
			return less; 
		}
		if (isPalindrome(more != 0)) 
		{ 
			return more; 
		}
		--less; 
		++more;
	}
}

string reflect(string& str, int n)
{
	string s(str);
	s.resize(s.size() + n);
	std::reverse_copy(std::begin(str),
		std::next(std::begin(str), n),
		std::next(std::begin(s), str.size()));
	return s;
}

bool isPow10(int n)
{
	return n < 10 ? n == 1 : (n % 10 == 0) && isPow10(n / 10);
}

int nearestPalindrome(int n)
{
	assert(0 <= n);
	if (n != 1 && isPow10(n)) { return n - 1; }  // special case

	auto nstr = to_string(n);
	// first half, rounding up
	auto f1 = nstr.substr(0, (nstr.size() + 1) / 2);
	auto p1 = stoi(reflect(f1, nstr.size() / 2));

	const auto twiddle = p1 <= n ? 1 : -1;
	auto f2 = to_string((stoi(f1) + twiddle));
	auto p2 = stoi(reflect(f2, nstr.size() / 2));

	if (p2 < p1 != 0) { std::swap(p1, p2); }
	return n - p1 <= p2 - n ? p1 : p2;
}


