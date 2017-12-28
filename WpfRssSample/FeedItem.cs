using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfRssSample
{
    public class FeedItem
    {
        public string Title { get; set; }
        private string _summary;
        public string Summary
        {
            get
            {
                //return "<html><body>" + _summary + "</body></html>";
                return _summary;
            }
            set
            {
                _summary = value;
            }
        }
    }
}