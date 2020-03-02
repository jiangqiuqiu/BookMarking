using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Common.ApiModels
{
    public class ValidationResultModel : BaseResultModel
    {
        public ValidationResultModel(int? code, string message,string result)
        {
            Code = code;
            Message = message;
            Result = result;
            ReturnStatus = ReturnStatus.Fail;
        }
    }
}
