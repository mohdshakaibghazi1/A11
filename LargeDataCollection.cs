
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ConAppAssignment11
{
    public class LargeDataCollection : IDisposable
    {
        bool disposed = false;
        object[] data;
        public LargeDataCollection(object[] initialData)
        {
            data = new object[initialData.Length];
            Array.Copy(initialData, data, initialData.Length);
        }
        public void Add(object item)
        {
            // Check if collection is full
            if (data.All(x => x != null))
            {
                // Resize the data array to accommodate more elements (in this case, doubling the size)
                int newSize = data.Length * 2;
                object[] newData = new object[newSize];
                Array.Copy(data, newData, data.Length);
                data = newData;
            }

            // Adding item to an empty spot in the collection
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == null)
                {
                    data[i] = item;
                    return;
                }
            }
        }
        public void Remove(object item)
        {
            //search for item and remove it
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != null && data[i].Equals(item))
                {
                    data[i] = null;
                    return;
                }
            }
        }
        public object GetElement(int index)
        {
            if (index >= 0 && index < data.Length)
            {
                return data[index];
            }
            return null;
        }
        public List<object> GetList()
        {
            return new List<object>(data);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //release managed resource
                }
                //releae unmanaged resource
                //set large collection data to null to free up memory
                data = null;
                disposed = true;
            }
        }
    }
}