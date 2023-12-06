using Microsoft.AspNetCore.Mvc;
using System;
using Utils;

namespace API2.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AddressHelper _addressHelper;
        private readonly FileHelper _fileHelper;

        public TestController(AddressHelper addressHelper, FileHelper fileHelper)
        {
            _addressHelper = addressHelper;
            _fileHelper = fileHelper;
        }

        [HttpGet("ServerAddress")]
        public string GetServerAddress(bool isHtml = true) => _addressHelper.GetLocalAddress(this.getNewLine(isHtml));

        [HttpGet("ServerFiles")]
        public string GetServerFiles(bool isHtml = true) => string.Join(this.getNewLine(isHtml), this._fileHelper.GetLocalFileNames());

        private string getNewLine(bool isHtml = true) => isHtml ? "<br/>" : Environment.NewLine;
    }
}
