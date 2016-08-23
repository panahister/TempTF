using ServiceStack;
using ServiceStack.FluentValidation;
using ServiceStack.Validation;
using ServiceStack.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parsis.Talfigh.Host
{
    public class ValidationFeature : IPlugin
    {

        public static bool Enabled { private set; get; }

        /// <summary>
        /// Activate the validation mechanism, so every request DTO with an existing validator
        /// will be validated.
        /// </summary>
        /// <param name="appHost">The app host</param>
        public void Register(IAppHost appHost)
        {
            Enabled = true;
            var filter = new ValidationFilters();
            appHost.RequestFilters.Add(filter.RequestFilter);
        }
    }


    public class ValidationFilters
    {


        public void RequestFilter(IHttpRequest req, IHttpResponse res, object requestDto)
        {
            var validator = ValidatorCache.GetValidator(req, requestDto.GetType());
            if (validator != null)
            {
                var ruleSet = req.HttpMethod;
                var validationResult = validator.Validate(
                 new ValidationContext(requestDto, null, new MultiRuleSetValidatorSelector(ruleSet)));

                if (validationResult.IsValid) return;

                //var errorResponse = _errorResponseFactory.CreateErrorResponse(requestDto, validationResult.ToErrorResult());

                res.WriteToResponse(req, errorResponse);
            }
        }
    }



    //public override void Execute(IRequest req, IResponse res, object requestDto)
    //{
    //    // Perform you filter actions

    //    if (authorised)
    //        return;

    //    // Not authorised, return some object

    //    var responseDto = new
    //    {
    //        SomeValue = "You are not authorised to do that."
    //    };

    //    // Set the status code
    //    res.StatusCode = (int)HttpStatusCode.Unauthorized;

    //    // You may need to handle other return types based on `req.AcceptTypes`
    //    // This example assumes JSON response.

    //    // Set the content type
    //    res.ContentType = "application/json";

    //    // Write the object
    //    res.Write(responseDto.toJson());

    //    // End the request
    //    req.EndRequest();
    //}
}



