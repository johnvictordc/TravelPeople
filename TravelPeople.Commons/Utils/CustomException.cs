using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Utils
{
    public enum MESSAGE_TYPE
    {
        ERROR,
        INFO,
        SUCCESS,
        WARNING
    }

    public class CustomException : Exception
    {
        public MESSAGE_TYPE type { get; set; }
        public object data { get; set; }
        public string AdditionalMessage { get; set; }
        public string icon { get; set; }

        public CustomException() { }

        public CustomException(string message)
            : base(message)
        {
            this.type = MESSAGE_TYPE.ERROR;
        }

        public CustomException(SerializationInfo info, StreamingContext context)
            : base(info.GetString("Message"))
        {
            this.type = MESSAGE_TYPE.ERROR;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue("ErrorMessage", this.AdditionalMessage);
            }
        }

        public CustomException(string message, MESSAGE_TYPE type)
            : base(message)
        {
            this.type = type;
        }

        public CustomException(string message, MESSAGE_TYPE type, object data)
            : base(message)
        {
            this.type = type;
            this.data = data;
        }

        public CustomException(Exception ex, MESSAGE_TYPE type)
            : base(ex.Message)
        {
            if (ex.InnerException != null)
            {
                this.AdditionalMessage = ex.InnerException.Message;
            }
        }

        public string CssClass
        {
            get
            {
                switch (type)
                {
                    case MESSAGE_TYPE.ERROR:
                        return "alert alert-danger";

                    case MESSAGE_TYPE.SUCCESS:
                        return "alert alert-success";

                    case MESSAGE_TYPE.WARNING:
                        return "alert alert-warning";

                    case MESSAGE_TYPE.INFO:
                    default:
                        return "alert alert-info";
                }
            }

            set
            {
                this.CssClass = value;
            }

        }

        public string Header()
        {
            switch (type)
            {
                case MESSAGE_TYPE.ERROR:
                    return "Something Went Wrong!";

                case MESSAGE_TYPE.SUCCESS:
                    return "Success!";

                case MESSAGE_TYPE.INFO:
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Wrap Message in Bootstrap Alert
        /// </summary>
        /// <returns></returns>
        public string RenderAlert()
        {
            return "<div class='" + CssClass + "'>" + Message + "</div>";
        }

        public string Icon(string size = "")
        {
            switch (type)
            {
                case MESSAGE_TYPE.ERROR:
                    return "<span class='fa fa-remove " + size + "'></span> ";

                case MESSAGE_TYPE.SUCCESS:
                    return "<span class='fa fa-check " + size + "'></span> ";

                case MESSAGE_TYPE.INFO:
                default:
                    return "<span class='fa fa-bell " + size + "'></span> ";
            }
        }
    }
}
