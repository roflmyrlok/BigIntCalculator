using System;
using Microsoft.VisualBasic;

namespace ConsoleApp1
{
    public class Stack<T>
    {
        private T[] _array = new T[50];

        private int _pointer = 0;

        public int lenOf()
        {
            return _pointer;
        }
        public T Pop()
        {
            var lastElement = _array[_pointer - 1];
            _pointer -= 1;
            return lastElement;
        }
        
        public void Push(T element)
        {
            if (_pointer == _array.Length)
            {
                //throw new Exception("stack overflow");
                int n = _pointer * 2;
                T[] _arrayToReplace = new T[n];
                for (int i = 0; i < _pointer; i++)
                {
                    _arrayToReplace[i] = _array[i];
                }

                _array = _arrayToReplace;
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
