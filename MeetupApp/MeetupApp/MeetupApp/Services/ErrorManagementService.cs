using System;
using Prism.Services;
namespace MeetupApp.Services
{
    public class ErrorManagementService : IErrorManagementService
    {
        private readonly IPageDialogService _dialogService;

        public ErrorManagementService(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public void HandleError(string message)
        {
            DisplayErrorAlert(message);
        }

        public void HandleError(string message, Exception ex)
        {
            DisplayErrorAlert($"{message}{Environment.NewLine}{ex}");
            LogError(ex);
        }

        public void HandleError(Exception ex)
        {
            DisplayErrorAlert(ex.ToString());
            LogError(ex);
        }

        private void LogError(Exception ex) => Console.WriteLine(ex);

        private void DisplayErrorAlert(string errorMessage) => 
            _dialogService.DisplayAlertAsync("An opportunity for open source contribution!",
                                             $"It looks like something went wrong, help us out by submitting a PR on our github!{Environment.NewLine}{errorMessage}",
                                            "Ok!");
    }

    public interface IErrorManagementService
    {
        void HandleError(string message);
        void HandleError(string message, Exception ex);
        void HandleError(Exception ex);
    }
}
