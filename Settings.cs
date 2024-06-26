using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Nucs.JsonSettings;

namespace EN2NGui
{
    internal class Settings : JsonSettings
    {
        public override string FileName { get; set; } = StringRes.conf;

        public Settings() { }
        public Settings(string fileName) : base(fileName)
        {
            if (TAPInterface == null) TAPInterface = "";
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public ConfigEnum.Compression UseCompression = ConfigEnum.Compression.Lzo1x;
        [JsonConverter(typeof(StringEnumConverter))]
        public ConfigEnum.Encryption UseEncryption = ConfigEnum.Encryption.Chacha20;
        public string Server = "";
        public string Community = "";
        public int Port = 6969;
        public string Password = "";
        public int MTU = 1280;
        public bool MTUDiscovery = false;
        public bool AllowBroadcast = true;
        public bool SetMetric = true;
        public bool EncryptHeader = false;
        public bool AllowRouting = false;
        public string NickName = "";
        public string TAPInterface = "";

    }
    internal static class ConfigEnum
    {
        internal enum Encryption
        {
            None,
            TwoFish,
            Aes,
            Chacha20,
            Speck
        }

        internal enum Compression
        {
            None,
            Lzo1x,
            Zstd
        }
    }
}
