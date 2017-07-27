namespace WebApiTestModel.News
{
    /// <summary>
    /// 新闻
    /// </summary>
    public class NewsInfo
    {
        private string _id;
        private string _title;
        private string _source;
        private string _firstImg;
        private string _mark;
        private string _url;
        private string _wid;
        private string _host;


        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        public string FirstImg
        {
            get { return _firstImg; }
            set { _firstImg = value; }
        }

        public string Mark
        {
            get { return _mark; }
            set { _mark = value; }
        }

        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                if (Url.Contains("?"))
                {
                    var list = Url.Split('?');
                    _wid = list[1];
                    _host = list[0];
                }
                else
                {
                    _wid = string.Empty;
                }
            }
        }

        public string wid
        {
            get { return _wid; }
            set { _wid = value; }
        }

        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }
    }
}