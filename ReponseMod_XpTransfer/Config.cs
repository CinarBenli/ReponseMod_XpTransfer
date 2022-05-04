using Rocket.API;

namespace ReponseMod_XpTransfer
{
    public class Config : IRocketPluginConfiguration
    {
        public string ServerLogo;
        public void LoadDefaults()
        {
            ServerLogo = "http";
        }
    }
}