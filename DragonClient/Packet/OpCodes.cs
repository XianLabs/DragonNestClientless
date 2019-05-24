namespace DragonClient.Packet
{
    public static class SendOps
    {
        public const short Validate = 0x0101;
        public const short Login = 0x2C01;
        public const short LoginThailand = 0x2401;
        public const short RequestWorldList = 0x0301;
        public const short SelectWorld = 0x0401;
        public const short SelectCharacter = 0x0501;
        public const short SelectChannel = 0x0801;
        public const short TownMigrate = 0x0102;
        public const short EnterMap = 0x0202;
        public const short ChangeState = 0x0220;
        public const short SendMapReady = 0x0103;
        public const short MapSpawn_1 = 0x5029;
        public const short MapSpawn_2 = 0x0526;
        public const short EnterPortal = 0x0506;
        public const short SendStartStage = 0x0606;
        public const short FieldMigrate = 0x0402;
        public const short FieldMigrate_UDP = 0x0502;
        public const short NPCDialog = 0x0109;
        public const short Speak = 0x010B;

        public const short LandInField1 = 0x070F;
        public const short LandInField2 = 0x0014;
        public const short LandInField3 = 0x0803;
        public const short LandInField4 = 0x080D;

        

        public const short OpenMailBox = 0x060E;
        public const short SendMail = 0x070E;
        public const short OpenMailItem = 0x080E;
        public const short DeleteMail = 0x090E;
        public const short CollectMailItemContents = 0x0A0E;
        public const short BatchCollectMail = 0x0B0E;

        public const short OpenCashPouch = 0x0708;
        public const short FinishOpenCashPouch = 0x0808;

        public const short StartCharacterMovement = 0x0104;
        public const short StopCharacterMovement = 0x0204;
        public const short EscapeCurrentLocation = 0x3604;
        public const short CrashNearbyActors = 0x2A04;
    }
    public static class RecvOps
    {
        public const short Validate = 0x0101;
        public const short LoginResponse = 0x0201;
        public const short WorldInfo = 0x0301;
        public const short FieldInfo = 0x0302;
        public const short CharacterList = 0x0401;
        public const short ChannelList = 0x0501;
        public const short ServerIP = 0x0102;
        public const short EnterMap = 0x0202;
        public const short GetMapInfo = 0x0103;
        public const short EnterPortal = 0x0606;
        public const short PlayerChat = 0x010B;
        public const short HackShieldRequest = 0x0F02;
        public const short LoadActorList = 0x0303;
        public const short UpdateGoldCount = 0x1904;
        public const short NPCDialog = 0x0109;
        public const short GetQuestNPC = 0x0C03; //sketchy
        public const short SpawnNPC = 0x0503;
        public const short StartMovement = 0x0104;
        public const short StopMovement = 0x0204;
        public const short GetCashInventory = 0x0207;
        public const short BeginTownThreading = 0x0703;
        public const short MailList = 0x080E;
    }
}
