using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Common.ApiModels
{
    public class BaseResultModel
    {
        public BaseResultModel(int? Code = null, string Message = null,
        object Result = null, ReturnStatus ReturnStatus = ReturnStatus.Success)
        {
            this.Code = Code;
            this.Result = Result;
            this.Message = Message;
            this.ReturnStatus = ReturnStatus;
        }
        public int? Code { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public ReturnStatus ReturnStatus { get; set; }
    }

    public enum ReturnStatus
    {
        Success = 0,
        Fail = 1,
        Error = 2
    }
}
