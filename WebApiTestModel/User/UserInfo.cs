namespace WebApiTestModel.User
{
    public class UserInfo
    {
        private int _id;
        private string _name;
        private string _password;
        private string _ticket;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string PassWord
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }
    }
}
