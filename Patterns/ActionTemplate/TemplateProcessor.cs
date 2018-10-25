namespace ActionTemplate
{
    internal abstract class TemplateProcessor
    {
        public void ProcessTemplate()
        {
            CheckAccess();
            VerifyEmailNames();
            VerifyEmailDomains();
            CheckEmailContent();
            VerifyTemplateVariables();
            SaveTemplate();
        }

        protected abstract void SaveTemplate();
        protected abstract void VerifyTemplateVariables();
        protected abstract void CheckEmailContent();
        protected abstract void VerifyEmailDomains();
        protected abstract void VerifyEmailNames();
        protected abstract void CheckAccess();

        protected string TemplateString
        {
            get;
        }
    }
}