namespace WinFormsClient
{
    [Serializable]
    class Message
    {
        public string UserName { get; set; }
        public string MessageText { get; set; }
        public DateTime TimeStamp { get; set; }

        public Message(string userName, string messageText, DateTime timeStamp)
        {
            UserName = userName;
            MessageText = messageText;
            TimeStamp = timeStamp;
        }
        public Message()
        {
            UserName = "Server";
            MessageText = "Server is running!";
            TimeStamp = DateTime.Now;
        }

        public override string? ToString()
        {
            string output = $"{UserName}: {MessageText} / <{TimeStamp}>";
            return output;
        }
    }
}
