namespace BookStoreApp.Exceptions
{
    [Serializable]
    internal class NoBooksAvailableException : Exception
    {
        string message;
        public NoBooksAvailableException()
        {
            message = "No Books Available";
        }
        public override string Message => message;


    }
}
