using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Application.Model
{
    public class ResultViewModel
    {
        public ResultViewModel(bool isSucess = true, string message = "")
        {
            IsSucess = isSucess;
            Message = message;
        }

        public bool IsSucess { get; set; }
        public string Message { get; set; }

        public static ResultViewModel Success(string message="")
            => new(true,message);
        public static ResultViewModel Error(string message)
            => new(false, message);
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public ResultViewModel(T? data, bool isSucess = true, string message = "") : base(isSucess, message)
        {
            Data = data;


        }
        public T? Data { get; set; }

        public static ResultViewModel<T> Success(T data, string message = "")
            => new(data, true, message);

        public static ResultViewModel<T> Error(string message)
            => new(default, false, message);

    }


}
