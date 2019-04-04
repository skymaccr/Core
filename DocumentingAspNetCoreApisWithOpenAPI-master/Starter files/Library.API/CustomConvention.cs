using Library.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Library.API
{
    public static class CustomConvention
    {
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //esto es para que el nombre pegue con algo 
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Insert(
            [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object model) { }
    }
}
