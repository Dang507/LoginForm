namespace Api.Helpers
{
    public class ExceptionType : Exception
    {
        public ExceptionType(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; set; }
        public  string Message { get; set; }
    }

    public class UnauthorizedException
    {
        public static readonly ExceptionType Unauthorized = new ExceptionType("401", "Username or password is incorrect"); 
    }
}
