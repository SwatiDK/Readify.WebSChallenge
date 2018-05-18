using System;
using System.Reflection;

namespace Readify.WebSChallenge.FrontEnd.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}