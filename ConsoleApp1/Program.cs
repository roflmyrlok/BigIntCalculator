using System;
using ConsoleApp1;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

var inpout = "32 + 123";//Console.ReadLine();
var tokens = Tokenized(inpout);
Console.WriteLine(tokens);
/*
var postfixTokens = InfixToPostfix(tokens);
var result = Calculate((postfixTokens));
*/

Stack Tokenized(string expression)
{
  /*var _numbersStr = "1234567890";
  string[] numbersList = new String[10];
  for (var i = 0; i != 10; i++)
  {
    var _localstr = _numbersStr[i];
    numbersList[i] =  ToString(_localstr);
  }
  Console.WriteLine(numbersList[5]);
  */
  string[] numbersList = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
  var numbers = new arrayList();
  var _tokens = new Stack();

  for (var i = 0; i != expression.Length; i++)
  {
    var element = expression[i].ToString();
    if (numbersList.Contains(element) == true)
    {
      numbers.Push(element);
    }
    if (element == " " && numbers.lenOf() != 0)
    {
      var _pressedNumber = "";
      for (var b = 0; b != numbers.lenOf() - 1; b++)
      {
        _pressedNumber += numbers.Pop();
      }
      _tokens.Push(_pressedNumber); 
  }
  }

  for (var i = 0; i != _tokens.lenOf(); i++)
  {
    Console.WriteLine(_tokens);
  }
  return _tokens;
}
/*
List<string> InfixToPostfix(int[] expression)
{
  return "f";
}

List<string> Calculate(int[] expression)
{
  return "d";
}
Console.WriteLine(777);*/

