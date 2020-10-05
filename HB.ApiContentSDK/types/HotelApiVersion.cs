namespace HB.ApiContentSDK.types
{
    public class HotelApiVersion
    {
        public enum versions
        {
            V0_2,
            V1
        }

        public HotelApiVersion(versions version)
        {
            this.version = version;
        }

        public versions version { get; }
    }
}