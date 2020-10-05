namespace HB.ApiSDK.helpers
{
    public class RoomDetail
    {
        public enum GuestType
        {
            ADULT,
            CHILD
        }

        private readonly int age;
        private readonly string name;
        private readonly int roomId;
        private readonly string surname;

        private readonly GuestType type;

        public RoomDetail(int age)
        {
            type = GuestType.CHILD;
            name = null;
            surname = null;
            roomId = 1;
            this.age = age;
        }

        public RoomDetail(GuestType type, int age, string name, string surname, int roomId)
        {
            this.type = type;
            this.age = age;
            this.name = name;
            this.surname = surname;
            this.roomId = roomId;
        }

        public GuestType getType()
        {
            return type;
        }

        public int getAge()
        {
            return age;
        }

        public string getName()
        {
            return name;
        }

        public string getSurname()
        {
            return surname;
        }

        public int getRoomId()
        {
            return roomId;
        }
    }
}