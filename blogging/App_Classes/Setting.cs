using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace blogging.App_Classes
{
    public class Setting
    {

        public static Size PictureSmallSize
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["sw"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["sh"]);
                return result;
            }
        }

        public static Size PictureMiddleSize
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["sw"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["sh"]);
                return result;
            }
        }
    }
}