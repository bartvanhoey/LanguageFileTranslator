namespace GrawPortal.BlazorWasm.Components.Confirm;

public class ConfirmResult
{
    public bool IsConfirmed { get; set; }
    public bool IsCanceled => !IsConfirmed;

    public string? Reason { get; set; }
}