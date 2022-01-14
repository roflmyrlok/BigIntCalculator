﻿using System;

namespace ConsoleApp1
{
    public class Stack
    {
        private string[] _array = new String[50];

        private int _pointer = 0;

        public int lenOf()
        {
            return _pointer;
        }
        public string Pop()
        {
            var lastElement = _array[_pointer - 1];
            _pointer -= 1;
            return lastElement;
        }
        
        public void Push(string element)
        {
            if (_pointer == _array.Length)
            {
                throw new Exception("stack overflow");
            }
            _array[_pointer] = element;
            _pointer += 1;
        }
        
        public object Seek()
        {
            return _array[_pointer - 1];
        }
    }
}
