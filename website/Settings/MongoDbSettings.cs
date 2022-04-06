namespace website.Settings
{
    public class MongoDbSettings
    {
        public string Host {get; set;}
        public int Port{get; set;}
        public string username{get; set;}
        public string password {get; set;}
        public string ConnectionString
        {
            get 
            {
                return $"mongodb://{username}:{password}@{Host}:{Port}";
            }
        }
    }
}