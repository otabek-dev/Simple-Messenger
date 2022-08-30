namespace WinFormsClient
{
    public partial class Form1 : Form
    {
        private static int MessageID = 0;
        private static string UserName;
        private static MessangerClientAPI API = new MessangerClientAPI();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            var getMessage = new Func<Task>(async () =>
            {
                Message msg = await API.GetMessageHTTPAsync(MessageID);
                while (msg != null)
                {
                    MessagesLB.Items.Add(msg);
                    MessageID++;
                    msg = await API.GetMessageHTTPAsync(MessageID);
                }
            });
            getMessage.Invoke();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = UserNameTB.Text;
            string message = MessageTB.Text;

            if ((userName.Length > 0) && (message.Length > 0))
            {
                Message msg = new Message(userName, message, DateTime.Now);
                API.SendMessageRestSharp(msg);
            }
        }
    }
}