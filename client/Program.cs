using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace Simple_Messenger
{
    internal class Program
    {
        private static int MessageID;
        private static string? UserName;
        private static MessangerClientAPI API = new MessangerClientAPI();

        private static void GetNewMessages()
        {
            Message msg = API.GetMessage(MessageID);
            while (msg != null)
            {
                Console.WriteLine(msg);
                MessageID++;
                msg = API.GetMessage(MessageID);
            }
        }

        static void Main(string[] args)
        {
            MessageID = 0;
            Console.WriteLine("Введите Ваше имя:");
            
            UserName = Console.ReadLine();

            string MessageText = "";
            

            while (MessageText != "exit")
            {
                GetNewMessages();
                MessageText = Console.ReadLine();
                if (MessageText.Length > 1)
                {
                    Message Sendmsg = new Message(UserName, MessageText, DateTime.Now);
                    API.SendMessage(Sendmsg);
                }
                
            }

            //Message msg = new Message("Otabek", "Privet", DateTime.UtcNow);
            //string output = JsonConvert.SerializeObject(msg);
            //Console.WriteLine(output);
            //Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            //Console.WriteLine(deserializedMsg);
            //{ "UserName":"Otabek","MessageText":"Privet","TimeStamp":"2021-03-24T18:04:47.8846682Z"}
            //Otabek < 24.03.2021 18:04:47 >: Privet

            //Стандартный инструмент для сериализации.
            //BinaryFormatter binaryFormat = new BinaryFormatter();
            //try
            //{
            //    // 3. Сохранить в файле books.bin данные экземпляра структуры message
            //    using (Stream fOut = File.Create("Message.bin"))
            //    {
            //        binaryFormat.Serialize(fOut, message);
            //    }
            //    Console.WriteLine("Binary serialize is done.");

            //    // 4. Прочитать данные из файла books.bin в другую структуру b2
            //    //    и вывести прочитанную информацию на экран.
            //    using (Stream fIn = File.OpenRead("Message.bin"))
            //    {
            //        Message message2;
            //        message2 = (Message)binaryFormat.Deserialize(fIn);
            //        Console.WriteLine(message2);
            //        Console.WriteLine("Binary deserialize is done.");
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

        }
    }
}