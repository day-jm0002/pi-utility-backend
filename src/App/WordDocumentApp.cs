using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using App.Interface;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlToOpenXml;

namespace App
{
    public class WordDocumentApp : IWordDocumentApp
    {
        public void ReplaceVariables(string templatePath, string outputPath, Dictionary<string, string> variables)
        {
            try
            {
                if (string.IsNullOrEmpty(templatePath))
                    throw new ArgumentException("O caminho do template não pode ser nulo ou vazio", nameof(templatePath));

                if (string.IsNullOrEmpty(outputPath))
                    throw new ArgumentException("O caminho de saída não pode ser nulo ou vazio", nameof(outputPath));

                if (variables == null || variables.Count == 0)
                    throw new ArgumentException("As variáveis não podem ser nulas ou vazias", nameof(variables));

                templatePath = Path.GetFullPath(templatePath);
                outputPath = Path.GetFullPath(outputPath);

                if (!File.Exists(templatePath))
                    throw new FileNotFoundException($"O arquivo template não foi encontrado: {templatePath}");

                var outputDirectory = Path.GetDirectoryName(outputPath);
                if (!Directory.Exists(outputDirectory))
                    Directory.CreateDirectory(outputDirectory);

                File.Copy(templatePath, outputPath, true);

                using (WordprocessingDocument doc = WordprocessingDocument.Open(outputPath, true))
                {
                    var body = doc.MainDocumentPart.Document.Body;
                    bool replacedInRuns = false;

                    // Tenta primeiro só nos nós de texto (<w:t>)
                    foreach (var text in body.Descendants<Text>())
                    {
                        if (string.IsNullOrEmpty(text.Text)) continue;

                        foreach (var variable in variables)
                        {
                            string placeholder = variable.Key;
                            string value = variable.Value ?? string.Empty;

                            if (text.Text.Contains(placeholder))
                            {
                                text.Text = text.Text.Replace(placeholder, value);
                                replacedInRuns = true;
                            }
                        }
                    }

                    // Fallback: se não conseguiu substituir nos runs, tenta no XML bruto
                    if (!replacedInRuns)
                    {
                        string xml = body.InnerXml;

                        foreach (var variable in variables)
                        {
                            string placeholder = variable.Key;
                            string value = variable.Value ?? string.Empty;

                            if (xml.Contains(placeholder))
                            {
                                xml = xml.Replace(placeholder, value);
                            }
                        }

                        body.InnerXml = xml;
                    }

                    doc.MainDocumentPart.Document.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao substituir variáveis no documento: {ex.Message}", ex);
            }
        }

        public  void ConvertAndReplace(string htmlPath, string docxPath, Dictionary<string, string> variables)
        {
            if (!File.Exists(htmlPath)) throw new FileNotFoundException(htmlPath);

            // 1) Lê o HTML
            var html = File.ReadAllText(htmlPath);

            // 2) Substitui variáveis no HTML bruto
            foreach (var kv in variables)
            {
                html = html.Replace(kv.Key, kv.Value ?? string.Empty);
            }

            // 3) Cria DOCX e injeta o HTML
            using (var doc = WordprocessingDocument.Create(docxPath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                var mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new Document(new Body());

                // (opcional) estilos básicos para evitar warning
                var stylePart = mainPart.AddNewPart<StyleDefinitionsPart>();
                stylePart.Styles = new Styles(new DocumentFormat.OpenXml.Wordprocessing.Style() { Type = StyleValues.Paragraph, StyleId = "Normal" });

                var converter = new HtmlConverter(mainPart);
                var paragraphElements = converter.ParseAsync(html);

                var body = mainPart.Document.Body;
                foreach (var el in paragraphElements.Result)
                    body.Append(el);

                mainPart.Document.Save();
            }
        }
    }
} 