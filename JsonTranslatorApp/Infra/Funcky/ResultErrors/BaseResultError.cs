using JsonTranslatorApp.Infra.Extensions;

namespace JsonTranslatorApp.Infra.Funcky.ResultErrors;

public abstract class BaseResultError
{
    protected BaseResultError(string message)
    {
        Message = message;
    }

    protected BaseResultError()
    {
        Message
            = GetType().Name.Replace("ResultError", "").ToSentenceCase();
    }

    public string Message { get; }
}