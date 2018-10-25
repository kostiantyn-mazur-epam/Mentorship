using System;
using System.Xml;

namespace ActionTemplate
{
    internal sealed class CurrentTemplateProcessor : TemplateProcessor
    {
        protected override void CheckAccess()
        {
            Console.WriteLine("Current tenplate access is granted.");
        }

        protected override void CheckEmailContent()
        {
            Console.WriteLine("Current tenplate email content is checked.");
        }

        protected override void SaveTemplate()
        {
            Console.WriteLine("Current template content saved");
        }

        protected override void VerifyEmailDomains()
        {
            Console.WriteLine("Current template email domains verification");
        }

        protected override void VerifyEmailNames()
        {
            Console.WriteLine("Current template email names verification");
        }

        protected override void VerifyTemplateVariables()
        {
            var doc = new XmlDocument();
            doc.LoadXml(TemplateString);
            var nodes = doc.SelectNodes("//CustomerName");

            if (nodes.Count == 0)
            {
                throw new InvalidOperationException("<CustomerName> element wasn't found");
            }
        }
    }
}