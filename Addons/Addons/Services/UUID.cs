namespace Addons.Services
{
    public static class UUID
    {
        public static string Generate()
        {
            byte[] uuidBytes = new byte[16];
            Random rnd = new Random();

            rnd.NextBytes(uuidBytes);

            uuidBytes[6] = (byte)((uuidBytes[6] & 0x0F) | 0x40);
            uuidBytes[8] = (byte)((uuidBytes[8] & 0x3F) | 0x80); 

            return new Guid(uuidBytes).ToString();
        }
    }
}
