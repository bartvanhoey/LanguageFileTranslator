using Microsoft.AspNetCore.Components;

namespace LanguageFileTranslatorApp.Pages;

public class PageComponentBase : ComponentBase
{
    protected bool ShowSpinner { get; set; }
    protected string ShowToast { get; set; } = "hide";
    protected string? ToastTitle { get; set; }
    protected string? ToastBody { get; set; }

    protected async Task DisplayToast(string title, string body)
    {
        ToastTitle = title;
        ToastBody = body;
        ShowToast = "show";
        StateHasChanged();
        await Task.Delay(3000);
        ShowToast = "hide";
        StateHasChanged();
    }
}