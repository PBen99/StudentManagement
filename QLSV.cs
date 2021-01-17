using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp
{
    public class QLSV<T>
    {
        private static QLSV<T> _instance;

        public static QLSV<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new QLSV<T>();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private static T[] _listSV;

        public static int length { get; set; }

        private QLSV()
        {
            _listSV = null;
            length = 0;
        }

        public bool AddLast(T newSV)
        {
            T[] tempList = new T[length + 1];
            for (int i = 0; i < length; i++)
            {
                tempList[i] = _listSV[i];
            }
            tempList[length] = newSV;
            length += 1;
            _listSV = new T[length];
            for (int i = 0; i < length; i++)
            {
                _listSV[i] = tempList[i];
            }
            return true;
        }

        public bool Insert(T newSV, int index)
        {
            if (index - 1 == length)
            {
                AddLast (newSV);
            }
            else
            {
                T[] tempList = new T[length + 1];
                int step = 0;
                for (int i = 0; i < length; i++)
                {
                    if (i == index - 1)
                    {
                        tempList[step++] = newSV;
                    }
                    tempList[step++] = _listSV[i];
                }
                length += 1;
                _listSV = new T[length];
                for (int i = 0; i < length; i++)
                {
                    _listSV[i] = tempList[i];
                }
            }
            return true;
        }

        public bool Remove(T newSV)
        {
            if (newSV == null || _listSV == null || !IsContain(newSV))
            {
                return false;
            }
            T[] tempList = new T[length - 1];
            int step = 0;
            for (int i = 0; i < length; i++)
            {
                if (_listSV[i].Equals(newSV))
                {
                    continue;
                }
                tempList[step++] = _listSV[i];
            }
            length -= 1;
            _listSV = new T[length];
            for (int i = 0; i < length; i++)
            {
                _listSV[i] = tempList[i];
            }

            return true;
        }

        public bool RemoveAt(int index)
        {
            if (index - 1 > length || _listSV == null)
            {
                return false;
            }
            T[] tempList = new T[length];
            int step = 0;
            for (int i = 0; i < length; i++)
            {
                if (i == index - 1)
                {
                    continue;
                }
                tempList[step++] = _listSV[i];
            }
            length -= 1;
            _listSV = new T[length];
            for (int i = 0; i < length; i++)
            {
                _listSV[i] = tempList[i];
            }

            return true;
        }

        /* public bool Update(T sv)
        {
            if (sv == null || _listSV == null || !IsContain(sv))
            {
                return false;
            }
            for (int i = 0; i < length; i++)
            {
                if (_listSV[i].Equals(sv))
                {
                    _listSV[i].Name = sv.Name;
                    _listSV[i].DTB = sv.DTB;
                    return true;
                }
            }
            return false;
        }*/
        public bool IsContain(T sv)
        {
            if (sv == null || _listSV == null)
            {
                return false;
            }
            foreach (T sinhvien in _listSV)
            {
                if (sinhvien.Equals(sv))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T sv)
        {
            int index = -1;
            for (int i = 0; i < length; i++)
            {
                if (sv.Equals(_listSV[i]))
                {
                    index = i + 1;
                }
            }
            return index;
        }

        /*public bool SelectionSort()
        {
            int minimum = _listSV[0].MSSV;
            for (int i = 0; i < length - 1; i++)
            {
                int index = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (_listSV[j].MSSV < _listSV[index].MSSV)
                    {
                        index = j;
                    }
                }
                Swap(ref _listSV[index], ref _listSV[i]);
            }
            return true;
        }*/
        public void Swap(ref T s1, ref T s2)
        {
            T tempSV = s1;
            s1 = s2;
            s2 = tempSV;
        }

        public override string ToString()
        {
            String s = "";
            for (int i = 0; i < length; i++)
            {
                s += _listSV[i].ToString() + "\n";
            }
            return s;
        }
    }
}
