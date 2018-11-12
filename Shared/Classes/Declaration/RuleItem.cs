using System;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;

namespace Difi.Sjalvdeklaration.Shared.Classes.Declaration
{
    public class RuleItem
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Instruction { get; set; }

        public String Illustration { get; set; }

        public String HelpText { get; set; }

        public String ToolsNeed { get; set; }

        public String Standard { get; set; }

        public String ChapterNumber { get; set; }

        public String ChapterHeading { get; set; }

        public ValueListTypeOfAnswer TypeOfAnswer { get; set; }
    }
}