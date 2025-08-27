using System.Collections.Generic;

namespace App.Interface
{
    public interface IWordDocumentApp
    {
        void ReplaceVariables(string templatePath, string outputPath, Dictionary<string, string> variables);

        void ConvertAndReplace(string htmlPath, string docxPath, Dictionary<string, string> variables);

    }
} 