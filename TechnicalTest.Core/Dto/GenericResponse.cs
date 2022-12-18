using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTest.Core.Dto
{
    public class GenericResponseDto
    {
        public bool Success { get; set; }
        public object Result { get; set; }
        public Exception Error { get; set; }
        public string Message { get; set; }
    }
}
