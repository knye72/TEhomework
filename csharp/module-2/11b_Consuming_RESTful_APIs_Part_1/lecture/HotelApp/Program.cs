namespace HotelApp
{
    class Program
    {
        private const string ApiUrl = "http://localhost:3000/"; //URL of the API we wanna get data from.
        static void Main()
        {
            HotelApp app = new HotelApp(ApiUrl);
            app.Run();
        }
    }
}
