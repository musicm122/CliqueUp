namespace Models.Exception
{
    public class InvalidGeocodeException : System.Exception
    {
        public InvalidGeocodeException(){ }
        public InvalidGeocodeException(string message, System.Exception innerException) : base(message, innerException){ }
    }
}
