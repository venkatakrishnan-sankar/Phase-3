using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public partial class CustomList<Type>
    {
         private int _count;
        private int _capacity;
        public int Count { get{return _count;} }
        public int Capacity { get{return _capacity;} }
        
        private Type [] _array;
        public Type this[int index]
        {
            get{return _array[index];}
            set{_array[index]=value;}
        }
        
        
        public CustomList()
        {
            _count=0;
            _capacity=4;
            _array=new Type[_capacity];
        }
        public CustomList(int size)
        {
             _count=0;
            _capacity=size;
            _array= new Type[_capacity];

        }
        public void Add(Type element)
        {
            if(_count==_capacity)
            {
              GrowSize();
            }
             _array[_count]=element;
             _count++;

        }
        void GrowSize()
        {
            _capacity=_capacity*2;
            Type[] temp= new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
            
        }
        public void AddRange(CustomList<Type> elements)
        {
             _capacity=_count+elements.Count+4;
             Type [] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            int k=0;
            for(int i=_count;i<_count+elements.Count;i++)
            {
                temp[i]=elements[k];
                k++;
            }
            _array=temp;
            _count=_count+elements.Count;
        }
        public  int IndexOf(Type element)
        {
            int index=-1;
             for (int i=0;i<_count;i++)
             {
                if(element.Equals(_array[i]))
                {
                    index=i;
                    break;
                }
             }
             return index;
        }
        public bool Contains(Type element)
        {
            bool temp=false;
            foreach(Type data in _array)
            {
                if(data.Equals(element))
                {
                    temp=true;
                }
            }
            return temp;
        }
        public void RemoveAt(int position)
        {
            for(int i=0;i<_count-1;i++)
            {
                if(i>=position)
                {
                    _array[i]=_array[i+1];
                }
            }
            _count--;
        }
        public bool Remove(Type element)
        {
            int position=IndexOf(element);
            if(position>=0)
            {
                RemoveAt(position);
                return true;

            }
            return false;
        }
        public void Insert(int position,Type element)
        {        
           _capacity=_capacity+1+4;
           Type[] temp= new Type[_capacity];
           for(int i=0;i<_count+1;i++)
           {
            if(i<position)
            {
                temp[i]=_array[i];
            }
            else if(i==position)
            {
                temp[i]=element;
            }
            else{
                temp[i]=_array[i-1];
            }
           }
           _count++; 
           _array=temp;
        }

        public void InsertRange(int position,CustomList<Type> element)
        {
            _capacity=_count+element.Count+4;
            Type [] temp=new Type[_capacity];
            for(int i=0;i<position;i++)
            {
               temp[i]=_array[i]; 
            }
            int j=0;
            for(int i=position;i<position+element.Count;i++)
            {
                temp[i]=element[j];
                j++;
            }
            int k=position;
            for(int i=position+element.Count;i<_count+element.Count;i++)
            {
                temp[i]=_array[k];
                k++;
            }
            _array=temp;
            _count=_count+element.Count;
        }
        public void Reverse()
        {
            Type [] temp=new Type[_capacity];
            int j=0;
            for(int i=_count-1;i>=0;i--)
            {
                temp[j]=_array[i];
                j++;
            }
            _array=temp;
        }
        public void Sort()
        {
            for(int i=0;i<_count-1;i++)
            {
                for(int j=0;j<_count-1;j++)
                {
                    if(IsGreater(_array[j],_array[j+1]))
                    {
                        Type temp=_array[j];
                        _array[j]=_array[j+1];
                        _array[j+1]=temp;
                    }
                }
            }
        }
        public bool IsGreater(Type value,Type value1)
        {
            int result=Comparer<Type>.Default.Compare(value,value1);
            if(result>=0)
            {
                return true;
            }
            return false;
        }
    }
}