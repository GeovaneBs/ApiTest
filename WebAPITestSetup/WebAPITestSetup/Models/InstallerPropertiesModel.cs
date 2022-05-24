namespace WebAPITestSetup.Models
{
    public class InstallerPropertiesModel
    {
        public InstallerPropertiesModel(string guid, string user, int install)
        {
            GUID = guid;
            User = user;
            Install = install;
        }

        public string GUID { get; set; }
        public string User { get; set; }
        public int Install { get; set; }
    }
}
