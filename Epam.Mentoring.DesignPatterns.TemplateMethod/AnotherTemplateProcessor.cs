using System;
using System.Xml;

namespace Epam.Mentoring.DesignPatterns.TemplateMethod
{
    internal sealed class AnotherTemplateProcessor : TemplateProcessor
    {
        protected override void CheckAccess()
        {
            Console.WriteLine("Another tenplate access is granted.");
        }

        protected override void CheckEmailContent()
        {
            Console.WriteLine("Another tenplate email content is checked.");
        }

        protected override void SaveTemplate()
        {
            Console.WriteLine("Another template content saved");
        }

        protected override void VerifyEmailDomains()
        {
            Console.WriteLine("Another template email domains verification");
        }

        protected override void VerifyEmailNames()
        {
            Console.WriteLine("Another template email names verification");
        }

        protected override void VerifyTemplateVariables()
        {
            var doc = new XmlDocument();
            doc.LoadXml(TemplateString);
            var nodes = doc.SelectNodes("//PhoneNumber");

            if (nodes.Count == 0)
            {
                throw new InvalidOperationException("<PhoneNumber> element wasn't found");
            }
        }
    }
}