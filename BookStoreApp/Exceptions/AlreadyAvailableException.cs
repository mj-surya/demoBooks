using System.Runtime.Serialization;

namespace HotelBookingApplication.Exceptions
{
    [Serializable]
    internal class AlreadyAvailableException : Exception
    {
        string message;
        public AlreadyAvailableException()
        {
            message = "An hotel already exists with this user";
        }
        public override string Message => message;


    }
}