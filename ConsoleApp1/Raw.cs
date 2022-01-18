using System;
using Microsoft.VisualBasic;

namespace ConsoleApp1
{
    public class RawFifo
    {
        private string[] _array = new String[50];

        private int _pointer = 0;

        public int lenOf()
        {
            return _pointer;
        }
        public string Pop()
        {
            var lastElement = _array[0];
            for (var i = 0; i != _pointer; i++)
            {
                _array[i] = _array[i + 1];
            }
            _pointer -= 1;
            return lastElement;
        }
        
        public void Push(string element)
        {
            if (_pointer == _array.Length) 
            {
                //throw new Exception("stack overflow");
                int n = _pointer * 2;
                string[] _arrayToReplace = new String[n];
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
