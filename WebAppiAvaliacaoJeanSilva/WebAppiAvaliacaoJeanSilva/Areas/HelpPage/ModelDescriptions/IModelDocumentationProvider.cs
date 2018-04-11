using System;
using System.Reflection;

namespace WebAppiAvaliacaoJeanSilva.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}