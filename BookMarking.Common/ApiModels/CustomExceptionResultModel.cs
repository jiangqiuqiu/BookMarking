using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Common.ApiModels
{
    public class CustomExceptionResultModel: BaseResultModel
    {
        public CustomExceptionResultModel(int? code, Exception exception)
        {
            Code = code;
            Message = exception.InnerException != null ?
                exception.InnerException.Message :
                exception.Message;
            Result = exception.Message;
            ReturnStatus = ReturnStatus.Error;
        }
    }
}
