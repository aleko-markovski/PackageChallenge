# Packing Challenge 
Implementation of Mobiquity Packaging Challenge.

## Algorithms
Implemented Recursion by Brute-Force algorithm.
Time complexity for this algorithm is O(2^n)which is considered to be not an optimal solution hoever it offers great flexibility and efficiency when there are decimals involved. 

### Approach
Consider all subsets of items and calculate the total weight and value of all subsets. 
Consider the only subsets whose total weight is smaller than W. 
From all such subsets, pick the maximum value subset.
To consider all subsets of items, there can be two cases for every item: 

Case 1: The item is included in the optimal subset.
Case 2: The item is not included in the optimal set.

Therefore, the maximum value that can be obtained from ‘n’ items is the max of the following two values: 

1. Maximum value obtained by n-1 items and W weight (excluding nth item).
2. Value of nth item plus maximum value obtained by n-1 items and W minus the weight of the nth item (including nth item).
If the weight of ‘nth’ item is greater than ‘W’, then the nth item cannot be included and Case 1 is the only possibility.

### Time & Space Complexities
Time complexity for this algorithm is `O(2^n)`which is considered to be not an optimal solution hoever it offers great flexibility and efficiency when there are decimals involved. 

## Design Patterns
### Template Pattern
The aplication is inspired by ETL systems where Template design pattern is commonly used.
In this application there is a process defined by the following steps:
**Extract** - Another sub template proccess where content is read from file and transformed to data object
**Validate** - Validate extracted data
**Solve** - solve each data object (representing a packaging problem)
**Publish** - Publish data to desired output format 

### Strategy Patterns
Strategy pattern is used in the template class where we decide which strategy (service) we use.

### TDD Mindset
This project is developed using the TDD process.

## Framework and libraries
The project is developed in .NET Standard 2.1 to achieve full cross-platform compatibility.

### Unit test
- xUnit
- FluentAssertion
- FakeItEasy  