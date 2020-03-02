using BookMarking.Common.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarking.Common.Filters
{
    public class ApiResultFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var objectResult = context.Result as ObjectResult;
            if (context.ModelState.ValidationState == ModelValidationState.Invalid)
            {
                context.Result = new OkObjectResult(objectResult.Value);
            }
            else
            {                
                context.Result = new OkObjectResult(new BaseResultModel(Code: 200, Result: objectResult.Value));
            }

        }
    }
}
