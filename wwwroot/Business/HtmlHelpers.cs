//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.ModelBinding;

//namespace Difi.Sjalvdeklaration.Business
//{
//    public static class HtmlHelpers
//    {
//        public static MvcHtmlString Required(this MvcHtmlString helper, ModelMetadata modelMetadata)
//        {
//            if (helper == null)
//            {
//                throw new ArgumentNullException();
//            }

//            if (!modelMetadata.IsRequired)
//            {
//                return helper;
//            }

//            var html = helper.ToString();
//            var startIndex = html.LastIndexOf("/>", StringComparison.Ordinal) - 1;

//            if (startIndex <= 0)
//            {
//                startIndex = html.IndexOf('>');
//            }

//            html = html.Insert(startIndex, " required=\"required\"");
//            var dataTypeName = !string.IsNullOrWhiteSpace(modelMetadata.DataTypeName) ? modelMetadata.DataTypeName : string.Empty;

//            if (dataTypeName.ToLower().Equals("multilinetext"))
//            {
//                html = html.Replace("/", "");
//            }

//            return MvcHtmlString.Create(html);
//        }
//    }
//}
