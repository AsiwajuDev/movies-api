using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Validation
{
    public class ContentTypeValidator
    {
        private readonly string[] _validContentTypes;

        public ContentTypeValidator( string[] validContentTypes)
        {
            _validContentTypes = validContentTypes;
        }


    }
}
