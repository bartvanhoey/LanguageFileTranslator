using GrawPortal.BlazorWasm.Components.Confirm;
using Microsoft.AspNetCore.Components;

namespace LanguageFileTranslatorApp.Components.Confirm
{
    public class ConfirmBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }
        [Parameter] public string ModalTitle { get; set; } = "ConfirmText Delete";
        [Parameter] public string ModalText { get; set; } = "Are you sure you want to delete";
        [Parameter] public string CancelText { get; set; } = "Cancel";
        [Parameter] public string ConfirmText { get; set; } = "Confirm";
        [Parameter] public bool HasReason { get; set; }

        [Parameter] public bool MustHaveReason { get; set; }
        [Parameter] public string? ReasonPlaceHolder { get; set; } = "Reason?";  
        protected bool IsDisabled { get; set; }
        public string? Reason { get; set; } 
        
        
        
        
        protected override void OnParametersSet()
        {
            if (MustHaveReason) IsDisabled = true;
            StateHasChanged();
        }

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        [Parameter] public EventCallback<ConfirmResult> ConfirmChanged { get; set; }

        protected async Task OnConfirmationChange(bool value)
        {
            ShowConfirmation = false;
            await ConfirmChanged.InvokeAsync(new ConfirmResult { IsConfirmed = value, Reason = Reason });
        }

        protected void ReasonChanged(ChangeEventArgs eventArgs)
        {
            var value =  eventArgs.Value as string ?? string.Empty;
            IsDisabled = value.Length <= 0;
            Reason = value;
            StateHasChanged();
        }
    }
}