
using System;
using ConsoleApp1;
using System.Linq;

var inpout = "66 + (123 - 33 * 23) * 123 ";//Console.ReadLine();
inpout += " ";
var tokens = Tokenized(inpout);
var nOfTokens = tokens.lenOf();
/*for (var stackElement = 0; stackElement != nOfTokens ; stackElement++)
{
  Console.WriteLine(tokens.Pop());
}*/
var postfixTokens = InfixToPostfix(tokens);
var nOfTokens2 = postfixTokens.lenOf();
for (var stackElement = 0; stackElement != nOfTokens2; stackElement++)
{
  Console.WriteLine(postfixTokens.Pop());
}

var result = Calculate((postfixTokens));
Console.WriteLine(result);

RawFifo Tokenized(string expression)
{
  string[] numbersList = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
  string[] mathChars = {"+", "-", "*", "/", "(", ")", "^"};
  var numbers = new RawFifo();
  var localTocensFilo = new RawFifo();

  for (var index = 0; index != expression.Length; index++)
  {
    var element = expression[index].ToString();
    if (numbersList.Contains(element))
    {
      numbers.Push(element);
    }
    if (!numbersList.Contains(element) && numbers.lenOf() != 0)
    {
      var pressedNumberToTocen = "";
      var lenOfNumbersPastMoment = numbers.lenOf();
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

RawFifo InfixToPostfix(RawFifo expression)
{
  var postfixRaw = new RawFifo();
  var operatorStuck = new Stack();
  string[] numbersList = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
  //string[] mathHighChars = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "*", "/", "(", ")", "^"};
  while (expression.lenOf() != 0)
  {
    var element = expression.Pop();
    if (numbersList.Contains(element))
    {
      postfixRaw.Push(element);
    }
    if (!numbersList.Contains(element))
    {
      if (element == "(" || element == "*" || element == "/" || element == "^")
        operatorStuck.Push(element);
      if (element == "+" || element == "-")
      {
        operatorStuck.Push((element));
      }
      /*
      {
        var checkerIsWorking = true;
        var index = 1;
        while (checkerIsWorking)
        {
          if (mathHighChars.Contains(element + index) && index != expression.lenOf())
          {
            checkerIsWorking = false;
            elementHighValue = 
          }
          index++;*/
      if (element == ")")
      {
        while (operatorStuck.lenOf() != 0)
        {
          var firstStep = operatorStuck.Pop();
          if(firstStep == "(")
          {
            break;
          }
          postfixRaw.Push(firstStep);
        }
      }
    }
  }

  while (operatorStuck.lenOf() != 0)
  {
    var lastOPer = operatorStuck.Pop();
    if (lastOPer != "(")
    {
      postfixRaw.Push(lastOPer);
    }
  }
  return postfixRaw;
}


int Calculate(RawFifo expression)
{
  return 42;
}


Console.WriteLine(777);

