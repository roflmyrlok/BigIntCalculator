﻿using System;
using System.Collections.Generic;
using ConsoleApp1;
using System.Linq;

var go = true;
while (go)
{
  Console.WriteLine("Write an equation:");
  var input = Console.ReadLine();
  input += " ";
  var tokens = Tokenized(input);
  for (var i = 0; i != tokens.Count; i++)
  {
    var element = tokens[i];
    if (element == "^")
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
    if (element == "*" || element == "/")
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
  go = false;
}

List<string> Tokenized(string expression)
{
  string[] numbersList = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", ".", ","};
  string[] mathChars = {"+", "*", "/", "(", ")", "^"};
  var numbers = new RawFifo();
  var localTocensFilo = new RawFifo();

  for (var index = 0; index != expression.Length; index++)
  {
    var element = expression[index].ToString();
    if (element == "-")
    {
      if (expression[index + 1].ToString() == " ")
      {
        localTocensFilo.Push(element);
        index++;
        continue;
      }
    }
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
  var nOfTokens = expression.Count;
  var currentElement = 0;
  while (currentElement != nOfTokens)
  {
    var element = expression[currentElement];
    if (float.TryParse(element, out _))
    {
      postfixList.Add(element);
    }
    if (!numbersList.Contains(element))
    {
      if (element == "(" || element == "+" || element == "*" || element == "/" || element == "^")
        operatorStuck.Push(element);
      if (element == "-")
      {
        operatorStuck.Push((element));
        currentElement++;
        continue;
      }

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


float Calculate(List<string> expression)
{
  var stackToWorkWith = new ConsoleApp1.Stack<string>();
  var turn = 0;
  while (turn != expression.Count)
  {
    var element = expression[turn];
    if (float.TryParse(element, out _))
    {
      stackToWorkWith.Push(element);
    }

    if (element == "+")
    {
      var a = float.Parse(stackToWorkWith.Pop());
      var b = float.Parse(stackToWorkWith.Pop());
      var c = a + b;
      stackToWorkWith.Push(c.ToString());
    }
    if (element == "-")
    {
      var a = float.Parse(stackToWorkWith.Pop());
      var b = float.Parse(stackToWorkWith.Pop());
      var c = b - a;
      stackToWorkWith.Push(c.ToString());
    }
    if (element == "/")
    {
      var a = float.Parse(stackToWorkWith.Pop());
      var b = float.Parse(stackToWorkWith.Pop());
      var c = b / a;
      stackToWorkWith.Push(c.ToString());
    }
    if (element == "*")
    {
      var a = float.Parse(stackToWorkWith.Pop());
      var b = float.Parse(stackToWorkWith.Pop());
      var c = a * b;
      stackToWorkWith.Push(c.ToString());
    }
    if (element == "^")
    {
      var a = float.Parse(stackToWorkWith.Pop());
      var b = float.Parse(stackToWorkWith.Pop());
      var c = Math.Pow(b, a).ToString();
      stackToWorkWith.Push(c);
    }
    turn++;
  }

  return float.Parse(stackToWorkWith.Pop());
}