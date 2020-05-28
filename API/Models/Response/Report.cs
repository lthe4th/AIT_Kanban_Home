using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Response
{
    public class Report<T>
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public T Data { get; set; }
        public static Report<T> GetResult(int code,string msg, T Data = default(T)){
            return new Report<T>{
                Code = code,
                Msg = msg,
                Data = Data
            };
        }
    }
}