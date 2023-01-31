using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Application.Services
{
    public class ResultService
    {
        public bool isSuccess { get; set; }
        public string? Menssage { get; set; }
        public ICollection<ErrorValidation> Erros { get; set; }

        #region Tratamento de requisicoes
        public static ResultService RequestError(string menssage, ValidationResult validationResult)
        {
            return new ResultService
            {
                isSuccess = false,
                Menssage = menssage,
                Erros = validationResult.Errors.
                Select(x => new ErrorValidation { Field = x.PropertyName, Menssage = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService<T> RequestError<T>(string menssage, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                isSuccess = false,
                Menssage = menssage,
                Erros = validationResult.Errors.
                Select(x => new ErrorValidation { Field = x.PropertyName, Menssage = x.ErrorMessage }).ToList()
            };
        }

        #endregion

        public static ResultService Fail(string menssage) => new ResultService { isSuccess = false, Menssage = menssage };
        public static ResultService<T> Fail<T>(string menssage) => new ResultService<T> { isSuccess = false, Menssage = menssage };
        public static ResultService Ok(string menssage) => new ResultService { isSuccess = true, Menssage = menssage };
        public static ResultService<T> Ok<T>(T data) => new ResultService<T> { isSuccess = true, Data = data };


    }
    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
