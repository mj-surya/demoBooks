using System.Runtime.Serialization;

namespace HotelBookingApplication.Exceptions
{
    [Serializable]
    internal class AlreadyAvailableException : Exception
    {
        string message;
        public AlreadyAvailableException()
        {
            message = "An book already exists with this name";
        }
        public override string Message => message;


    }
}