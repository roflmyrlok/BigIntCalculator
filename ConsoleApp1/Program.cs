
using System;
using System.Collections.Generic;
using ConsoleApp1;
using System.Linq;

var go = true;
while (go)
{
  var inpout = Console.ReadLine();
  inpout += " ";
  var tokens = Tokenized(inpout);
  for (var i = 0; i != tokens.Count; i++)
  {
    var element = tokens[i];
    if (element == "*" || element == "/" || element == "^")
    {
      var w8 = new List<string>();
      for (int j = 0; j < i - 1; j++)
      {
        w8.Add(tokens[j]);
      }

      if (tokens[i - 1] == "(" || tokens[i + 1] == "(" || tokens[i + 1] == ")" || tokens[i - 1] == ")")
      {
        break;
      }
      w8.Add("(");
      w8.Add(tokens[i - 1]);
      w8.Add(tokens[i]);
      w8.Add(tokens[i + 1]);
      w8.Add(")");
      for (int j = i + 2; j < tokens.Count; j++)
      {
        w8.Add(tokens[j]);
      }

      tokens = w8;
      i += 2;
    }
  }
  var postfixTokens = InfixToPostfix(tokens);
  var result = Calculate((postfixTokens));
  Console.WriteLine(result);
}

List<string> Tokenized(string expression)
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
  //fifo to list revriter
  var answearShit = new List<string>();
  while (localTocensFilo.lenOf() != 0)
  {
    var a = localTocensFilo.Pop();
    answearShit.Add(a);
  }
  return answearShit;
  
}


List<string> InfixToPostfix(List<string> expression)
{
  var postfixList = new List<string>();
  var operatorStuck = new ConsoleApp1.Stack<string>();
  string[] numbersList = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
  string[] mathHighChars = {"*", "/", "^"};
  var nOfTokens = expression.Count;
  var currentElement = 0;
  while (currentElement != nOfTokens)
  {
    var element = expression[currentElement];
    if (int.TryParse(element, out _))
    {
      postfixList.Add(element);
    }
    if (!numbersList.Contains(element))
    {
      if (element == "(" || element == "*" || element == "/" || element == "^")
        operatorStuck.Push(element);
      if (element == "+" || element == "-")
      {
        /*var niceAction = true;
        for (var i = currentElement; niceAction; i++)
        {
          if (i == expression.Count || expression[i] == "(" || expression[i] == ")")
          {
            break;
          }
          if (mathHighChars.Contains(expression[i]))
          {
            
            niceAction = false;
          }
        }*/
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
          index++;
          */
      if (element == ")")
      {
        while (operatorStuck.lenOf() != 0)
        {
          var firstStep = operatorStuck.Pop();
          if(firstStep == "(")
          {
            break;
          }
          postfixList.Add(firstStep);
        }
      }
    }

    currentElement++;
  }

  while (operatorStuck.lenOf() != 0)
  {
    
    var lastOPer = operatorStuck.Pop();
    if (lastOPer != "(")
    {
      postfixList.Add(lastOPer);
    }
  }
  return postfixList;
}


int Calculate(List<string> expression)
{
  var stackToWorkWith = new ConsoleApp1.Stack<string>();
  var turn = 0;
  while (turn != expression.Count)
  {
    var element = expression[turn];
    if (int.TryParse(element, out _))
    {
      stackToWorkWith.Push(element);
    }

    if (element == "+")
    {
      var a = int.Parse(stackToWorkWith.Pop());
      var b = int.Parse(stackToWorkWith.Pop());
      var c = a + b;
      stackToWorkWith.Push(c.ToString());
    }
    if (element == "-")
    {
      var a = int.Parse(stackToWorkWith.Pop());
      var b = int.Parse(stackToWorkWith.Pop());
      var c = a - b;
      stackToWorkWith.Push(c.ToString());
    }
    if (element == "/")
    {
      var a = int.Parse(stackToWorkWith.Pop());
      var b = int.Parse(stackToWorkWith.Pop());
      var c = a / b;
      stackToWorkWith.Push(c.ToString());
    }
    if (element == "*")
    {
      var a = int.Parse(stackToWorkWith.Pop());
      var b = int.Parse(stackToWorkWith.Pop());
      var c = a * b;
      stackToWorkWith.Push(c.ToString());
    }
    if (element == "^")
    {
      var a = int.Parse(stackToWorkWith.Pop());
      var b = int.Parse(stackToWorkWith.Pop());
      var c = Math.Pow(a, b).ToString();
      stackToWorkWith.Push(c);
    }
    turn++;
  }

  return int.Parse(stackToWorkWith.Pop());
}


