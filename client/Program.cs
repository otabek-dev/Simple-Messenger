using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace Simple_Messenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Message message = new Message("Otabek","Hello",DateTime.Now);
            string output = JsonConvert.SerializeObject(message);
            Console.WriteLine(output);
            Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializedMsg);


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