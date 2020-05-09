using System;
using System.IO;
using System.Reflection;

namespace BuildinChrome
{
    internal static class fn
    {
        public static Config oConfigSetup;
        private static string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string dirplus = directory[directory.Length - 1] != '\\' ? directory + '\\' : directory;
        private static string strConfigFile = "config.cfg";
        private static string strErrorMsg;
        public static string ProgramDir(bool blnBackSlash)
        {
            return blnBackSlash ? dirplus : directory;
        }
        public static bool LoadConfigs()
        {
            string strFile = dirplus + strConfigFile;
            if (File.Exists(strFile))
            {
                try
                {
                    string strContent = File.ReadAllText(strFile);
                    oConfigSetup = b2f.SimpleJson.DeserializeObject<Config>(strContent);
                    return true;
                }
                catch (Exception ex)
                {
                    strErrorMsg = ex.Message;
                    return false;
                }
            }
            return false;
        }
    }
}
