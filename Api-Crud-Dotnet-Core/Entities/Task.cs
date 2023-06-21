namespace Api_Crud_Dotnet_Core.Entities
{
    public class Task
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public bool Finished { get; set; }
    }
}
