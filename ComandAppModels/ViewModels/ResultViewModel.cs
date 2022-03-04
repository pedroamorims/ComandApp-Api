using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandApp.Domain.ViewModels
{
    public class ResultViewModel<T>
    {
        public ResultViewModel(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ResultViewModel(T data)
        {
            Data = data;
        }

        public ResultViewModel(string errors)
        {
            Errors.Add(errors);
        }

        public ResultViewModel(List<string> errors)
        {
            Errors = errors;
        }


        public T Data { get; private set; }

        public List<string> Errors { get; private set; } = new();
    }
}
