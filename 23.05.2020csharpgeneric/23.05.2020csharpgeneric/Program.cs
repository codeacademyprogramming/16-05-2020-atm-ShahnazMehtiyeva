using System;
using System.Collections.Generic;
using System.Linq;

namespace _23._05._2020csharpgeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyArrayList<int> arraylist = new MyArrayList<int>();
            //arraylist.Add(5);
            //arraylist.Add(6);
            //arraylist.Add(7);
            ////arraylist.Get();

            //arraylist[1] = 2;
            //Console.WriteLine(arraylist[0]);

            //arraylist.Remove(5);
            //arraylist.Get();


            MyDictionary<string, int> dic = new MyDictionary<string, int>();
            dic.Add("one", 1);
            dic.Add("two", 2);
            //dic.Get();

            dic["one"] = 2;

            Console.WriteLine( dic["one"] ); 
        }
    }


    class MyDictionary<T, R>
    {
        T[] keys = new T[0];
        R[] values = new R[0];

        public R this[T key]
        {
            
            get
            {
                for (int i = 0; i < keys.Count(); i++)
                {
                    if (keys[i].Equals(key))
                    {
                        return values[i];
                    }
                }
                throw new Exception("Not Found");
            }
            set
            {
                for (int i = 0; i < keys.Count(); i++)
                {
                    if (keys[i].Equals(key))
                    { 
                        values[i] = value;
                    }
                }
               
            }
        }




        public void Add(T key, R value)
        {
            T[] tempkeys = new T[keys.Length + 1];
            R[] tempvalues = new R[values.Length + 1];
            CopyTo(tempkeys, tempvalues);
            tempkeys[keys.Length] = key;
            tempvalues[values.Length] = value;
            keys = tempkeys;
            values = tempvalues;
        }


        public void CopyTo(T[] newarray, R[] newarray2)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                newarray[i] = keys[i];
                newarray2[i] = values[i];
            }
        }

        public void Get()
        {
            foreach (var values in values)
            {
                Console.WriteLine(values);
            }
        }

    }










    class MyArrayList<T>
    {

        T[] arr = new T[0];

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            set
            {
                arr[index] = value;
            }
        }



        public void Remove(T x)
        {
            T[] temparray = new T[arr.Length - 1];
            int j = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(x))
                {
                    continue;
                }
                else
                {
                    temparray[j] = arr[i];
                    j++;
                }
            }

            arr = temparray;
        }


        public void Add(T x)
        {
            T[] temparray = new T[arr.Length + 1];
            CopyTo(temparray);
            temparray[arr.Length] = x;
            arr = temparray;
        }


        public void Get()
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
        public void CopyTo(T[] newarray)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                newarray[i] = arr[i];
            }
        }
    }
}
