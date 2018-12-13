using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;

namespace Difi.Sjalvdeklaration.wwwroot.Business.Interface
{
    public interface IExcelGenerator
    {
        byte[] GenerateExcel(IEnumerable<DeclarationItem> declarationList);
    }
}