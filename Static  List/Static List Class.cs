using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static__List
{
    class Static_List_Class<T>
    {
        private T[] arr;
        private int count;// tiene doble funciona como el indice del ultimo elemento guarado
        private const int INITIAL_CAPACITY = 4;


        /// <summary>
        /// Devuelve la cantidad de elementos guardados dentro de la lista
        /// </summary>
        public int Count { get { return count; } }

        public Static_List_Class(int capacity = INITIAL_CAPACITY)
        {
            arr = new T[capacity];
            count = 0;
        }


        public void Add(T item)
        {
            GrowIfArrIsFull();
            arr[count] = item;
            count++;

        }

        public void Insert(int index, T element)
        {
            // index >=count
            if (index < 0 || index > count)//Quiero insertar un elemento entre el primer elemento guardado y el ultimo elemento guardado
                throw new IndexOutOfRangeException("El indice no es valido");

            GrowIfArrIsFull();
            Array.Copy(arr, index, arr, index + 1, count - index);// en el libro aparece count - index
            arr[index] = element;
            count++;
        }

        private void GrowIfArrIsFull()
        {
            if (count + 1 > arr.Length)
            {
                T[] extendedArr = new T[arr.Length * 2];
                Array.Copy(arr, extendedArr, count);
                arr = extendedArr;
            }
        }

        public void Clear()
        {
            arr = new T[INITIAL_CAPACITY];
            count = 0;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (object.Equals(item, arr[i]))
                    return i;

            }

            return -1; // devuelve -1 si el elemento no existe
        }

        public bool Contains(T item)
        {
            int index = IndexOf(item);
            bool exist = (index != -1);
            return exist;
        }


        //Indexer
        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                    throw new IndexOutOfRangeException("Indice no valido");

                return arr[index];
            }
            set
            {
                if (index >= count || index < 0)
                    throw new IndexOutOfRangeException("indice no valido");
                arr[index] = value;
            }
        }
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= count)//se asegura que el elemento a remover se encuentre entre los indices 0 y el ultimo indice del ultimo elemento
                throw new IndexOutOfRangeException("Indice invalido");

            T item = arr[index];
            Array.Copy(arr, index + 1, arr, index, count - index);
            arr[index] = default;
            count--;

            return item;
        }

        public int Remove(T item)
        {
            int index = IndexOf(item);

            if (index != -1)
                RemoveAt(index);

            return index;
        }
    }
}
