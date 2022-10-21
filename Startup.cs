namespace PracticeAPI
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration )
        {
            this.configuration = configuration;
        }
    }
}
