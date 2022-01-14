using System;
using ConsoleApp1;
using System.Linq;


var inpout = "66 + 123";//Console.ReadLine();
var tokens = Tokenized(inpout);
Console.WriteLine(tokens);
var nOfTokens = tokens.lenOf();
for (var stackElement = 0; stackElement != nOfTokens; stackElement++)
{
  Console.WriteLine(tokens.Pop());
}
/*
var postfixTokens = InfixToPostfix(tokens);
var result = Calculate((postfixTokens));
*/

Stack Tokenized(string expression)
{
  string[] numbersList = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
  string[] mathChars = {"+", "-", "*", "/"};
  var numbers = new Fifo();
  var localTocensFilo = new Stack();

  for (var index = 0; index != expression.Length; index++)
  {
    var element = expression[index].ToString();
    if (numbersList.Contains(element))
    {
      numbers.Push(element);
    }
    if (element == " " && numbers.lenOf() != 0)
    {
      var pressedNumberToTocen = "";
      var lenOfNumbersPastMoment = numbers.lenOf();
      Console.WriteLine(lenOfNumbersPastMoment);
      for (var b = 0; b != lenOfNumbersPastMoment; b++)
      {
        pressedNumberToTocen += numbers.Pop();
      }
      localTocensFilo.Push(pressedNumberToTocen);
    }
    if (mathChars.Contains(element))
    {
      localTocensFilo.Push(element);
    }
  }
  return localTocensFilo;
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

