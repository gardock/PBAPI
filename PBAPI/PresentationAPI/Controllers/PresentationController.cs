using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PresentationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresentationController : ControllerBase
    {
        //private readonly IMultiplyText _multiplyText;

        //public PresentationController(IMultiplyText multiplyText) {
        //    _multiplyText = multiplyText;
        //}

        ////Post wykorzystujący Body
        //[HttpPost("dependency-injection")]
        //public async Task<string> MultipleTextFromBodyUsingClass([FromBody] FromBodyDto requestbody)
        //{
        //    return await _multiplyText.MultiplyText(requestbody);
        //}


        //get
        [HttpGet]
        public async Task<string> HelloWorld()
        {
            return "Hello World";
        }

        //get z wykorzystaniem adresu
        [HttpGet("hello-world")]
        public async Task<string> GetHelloWorldWithRoute()
        {
            return "Hello World z użyciem adresu";
        }

        //get z wykorzystaniem parametru z adresu
        [HttpGet("hello-world/{text}")]
        public async Task<string> GetHelloWorldWithRouteAndParam([FromRoute] string text)
        {
            return "Hello World " + text;
        }

        //get z wykorzystaniem parametru z zapytania url
        [HttpGet("hello-world-from-query")]
        public async Task<string> GetHelloWorldFromQuery([FromQuery] string text)
        {
            return "Hello World " + text;
        }

        //post z parametrem z adresu
        [HttpPost("hello-world/{text}")]
        public async Task<string> PostHelloWorldWithRouteAndParam([FromRoute] string text)
        {
            return "Hello World " + text;
        }

        //Post wykorzystujący Body
        [HttpPost]
        public async Task<string> MultipleTextFromBody([FromBody] FromBodyDto requestbody)
        {
            var returnText = "";
            for(int i = 0; i< requestbody.repeatCount; i++)
            {
                returnText += requestbody.text + System.Environment.NewLine;
            }
            return returnText;
        }
    }
}
