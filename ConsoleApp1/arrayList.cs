using System;

namespace ConsoleApp1
{
    public class arrayList
    {
        private string[] _array = new String[10];

        private int _tailPointer = 0;

        public int lenOf()
        {
            return _tailPointer;
        }
        
        public void Insert(int index, string element)
        {
            if (_tailPointer >= _array.Length)
            {
                var extendetArray = new String[_array.Length * 2];
                for (var i = 0; i < _array.Length; i++)
                {
                    extendetArray[i] = _array[i];
                }

                _array = extendetArray;
            }
            for (var i = _tailPointer; i != index; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[index] = element;
            _tailPointer += 1;
        }
        
        public void Remove(string element)
        {
            var index = indexOf(element);
            
            if (index == -1)
            {
                return;
            }

            _array[index] = 'o'.ToString();
            for (var i = index; i < _array.Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _tailPointer -= 1;
        }
        
        public string Pop()
        {
            var lastElement = _array[0];
            _array[_tailPointer - 1] = "o";
            _tailPointer -= 1;
            return lastElement;
        }
        public void Push(string element)
        {
            Insert(_tailPointer, element);
        }

        public int indexOf(string element)
        {
            var index = -1;
            for (var i = 0; i < _array.Length; i++)
            {
                if (element == _array[i])
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
