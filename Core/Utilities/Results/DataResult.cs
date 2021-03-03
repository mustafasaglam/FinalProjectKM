using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success,string messages):base(success,messages) //ctor tab tab
        {
            Data = data; // datayı set edelim
        }
        public DataResult(T data,bool success):base(success)
        {
            Data = data; // datayı set edelim
        }
        public T Data { get; }
    }
}
