using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EseLista
{
    internal class AbiList
    {

        /* Base */
        private int Count { get; set; }
        private int Capacity { get; set; }

        public int Length = 0;

        public AbiList()
        {
            Count = 0;
            Capacity = 4;
        }

        private int?[] BaseArray = new int?[4];

        /*********************************************************************************/



        /* Funzionamento */
        private void CheckCapacity()
        {
            if(Count >= Capacity)
            {
                Capacity *= 2;
                int?[] tempArray = new int?[Capacity];
                BaseArray.CopyTo(tempArray, 0);
                BaseArray = tempArray;
            }
        }

        private void CheckCapacity(int Value)
        {
            if (Value > Capacity)
            {
                do
                {
                    Capacity *= 2;
                }
                while(Value >= Capacity);
                
                int?[] tempArray = new int?[Capacity];
                Count = Value;
                BaseArray.CopyTo(tempArray, 0);
                BaseArray = tempArray;
            }
        }

        public void MoveNullsToEnd()
        {
            int lastIndex = Count - 1;
            int nullCount = 0;

            for (int i = 0; i < Count; i++)
            {
                if(BaseArray[i] == null && i != lastIndex)
                {
                    nullCount++;
                    int j = i;
                    do
                    {
                        BaseArray[j] = BaseArray[j+1];
                        BaseArray[j+1] = null;
                        j++;
                    }
                    while (j < lastIndex );
                }
            }

            Count -= nullCount;
            UpdateLength();

        }

        private void UpdateLength()
        {
            Length = Count;
        }

        /*********************************************************************************/



        /* Funzioni di accesso */

        public int? this[int i]
        {
            get => BaseArray[i];
            set => BaseArray[i] = value;
        }

        public int IndexOf(int ToFind)
        {
            for(int i = 0; i < Count; i++)
            {
                if (BaseArray[i] == ToFind) { return i; }
            }

            return -1;
        }

        public bool Contains(int Valore)
        {
            int Index = IndexOf(Valore);
            if (Index >= 0)
            {
                return true;
            }

            return false;
        }

        public int? Find(int Position)
        {
            if(Position < Count)
            {
                return BaseArray[Position];
            }

            return null;
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                BaseArray[i] = null;
                Count = 0;
                UpdateLength();
            }
        }

        /* Add */
        public void Add(int Valore)
        {
            Count++;
            UpdateLength();
            CheckCapacity();

            BaseArray[Count-1] = Valore;
        }

        public void Add(int Index, int Valore)
        {
            CheckCapacity(Index);
            if(Index < Count) {
                BaseArray[Index] = Valore;
            }
        }

        /*********************************************************************************/




        /* Remove */
        public int? Remove()
        {
            int? ToReturn = BaseArray[Count - 1];
            BaseArray[Count - 1] = null;
            MoveNullsToEnd();

            return ToReturn;
        }

        public int? Remove(int Valore)
        {
            int Index = IndexOf(Valore);
            int? ToReturn = 0;
            if(Index != -1)
            {
                ToReturn = BaseArray[Index];
                BaseArray[Index] = null;
            }
            MoveNullsToEnd();

            return ToReturn;
        }

        public void RemoveAll(int Valore)
        {
            int Index = IndexOf(Valore);
            do
            {
                Index = IndexOf(Valore);
                if (Index != -1)
                {
                    BaseArray[IndexOf(Valore)] = null;
                }
            }
            while (Index != -1);
            MoveNullsToEnd();
        }

        /*********************************************************************************/



        /* Sort */
        public void Sort()
        {
            MoveNullsToEnd();

            int n = BaseArray.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int? temp = BaseArray[i];
                    int j = i;

                    while (j >= gap && BaseArray[j - gap] > temp)
                    {
                        BaseArray[j] = BaseArray[j - gap];
                        j -= gap;
                    }

                    BaseArray[j] = temp;
                }
            }
        }

    }
}
