// IntToAlphaNumericStr.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"





int _tmain(int argc, _TCHAR* argv[])
{
	int test = -1234; 

	char * output = new char[100]; 

	convertIntToString(test, output); 

	if(test>0)
		reverse(output, countStr(output), 0);
	else
		reverse(output, countStr(output), 1); 

	printf("output is %s\n",output);

	return 0;
}

bool convertIntToString(int n, char * str)
{
	if(n<0)
	{
		str[0]='-';
		convertPositiveIntToStringUtil(-1*n, &str[1]);
		return; 
	}
	convertPositiveIntToStringUtil(n, &str[0]);

	return true;
}

// assume n is non-negative interger
// the convert string is reversed, so need to call a functiont to reverse a string
bool convertPositiveIntToStringUtil(int n, char* str)
{
	// base case
	if(n==0)
	{
		if(&str[0] !=NULL && &str[1]!=NULL)
		{
		str[0] = '0';
		str[1]='\n';  /*terminate the string using null terminated string */
		return true;
		}
		else
			return false; 
	}
	
	str[0] = myGetChar(n%10); 
	convertPositiveIntToStringUtil(n/10, &str[1]); 
}

// convert the digit to a char
// input is one digit integer, positive number
char myGetChar(int n)
{
	switch(n)
	{
		case 0:
			return '0';
		case 1:
			return '1';
		case 2: 
			return '2';
		case 3:
			return '3';
		case 4:
			return '4';
		case 5:
			return '5';
		case 6:
			return '6';
		case 7:
			return '7';
		case 8:
			return '8';
		case 9:
			return '9';
		default: 
			return '0';
	}
}

// return the length of the str with null terminated str
int countStr(char * str)
{
	int count =0;
	while(str[count]!='\0')
	{
		count++; 
	}
	return count; 
}

// reverse the string, no extra space needed, reverse in place
// positive number:  start = 0
// negative number: start = 1
void reverse(char * inputAndOutput, int count, int start)
{
	int  end; 
	for( end=count-1; start<end; start++, end--)
	{
		char temp = inputAndOutput[start];
		inputAndOutput[start] = inputAndOutput[end]; 
		inputAndOutput[end] = temp; 
	}
}

