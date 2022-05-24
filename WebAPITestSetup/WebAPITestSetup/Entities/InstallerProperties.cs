namespace WebAPITestSetup.Entities
{
    public class InstallerProperties
    {
        public InstallerProperties()
        {

        }

        public InstallerProperties(string? gUID, string? user, int install)
        {
            GUID = gUID;
            User = user;
            Install = install;
        }

        public string? GUID { get; set; }
        public string? User { get; set; }
        public int Install { get; set; }
    }
}
