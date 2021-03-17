using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Drawing;



namespace blogging.Appp_Classes
{
    public class Setting
    {
        public static Size ImgSmallSize {
            get
            {
                Size result = new Size();
                   result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["sw"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["sh"]);

                return result;



            }
        }



        public static Size ImgMiddleSize {
            get
            {
                Size result = new Size();
                   result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["mw"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["mh"]);

                return result;



            }
        }



        public static Size ImgLargeSize { 
            get
            {
                Size result = new Size();
                   result.Width =Convert.ToInt32(ConfigurationManager.AppSettings["lw"]);
                   result.Height =Convert.ToInt32(ConfigurationManager.AppSettings["lh"]);
 
                   return result;



              }
}


        public static Size AuthorPictureSize
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["Author"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["Author"]);

                return result;



            }
        }

    }
}