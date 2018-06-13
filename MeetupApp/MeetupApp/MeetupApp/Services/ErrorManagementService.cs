using System;
namespace MeetupApp.Services
{
    public class ErrorManagementService : IErrorManagementService
    {
        public ErrorManagementService()
        {
        }

        public void HandleError(string message)
        {
            throw new NotImplementedException();
        }

        public void HandleError(string message, Exception ex)
        {
            throw new NotImplementedException();
        }

        public void HandleError(Exception ex)
        {
            throw new NotImplementedException();
        }
    }

    public interface IErrorManagementService
    {
        void HandleError(string message);
        void HandleError(string message, Exception ex);
        void HandleError(Exception ex);
    }
}
