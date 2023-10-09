using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abbey_Trading_Store.UI.Advanced
{
    static class LayoutFlex
    {
        static System.Drawing.Rectangle workingRectangle =
               Screen.PrimaryScreen.WorkingArea;

        // Creating overall size to be used for the major form.
        public static System.Drawing.Size working_size = new System.Drawing.Size(
            workingRectangle.Width - 10, workingRectangle.Height - 10);

        public static int overall_container_height = working_size.Height - 150;
        public static int overall_container_width = working_size.Width - 200;


        public static int top_panel_height = 150;

        //Overview screen layout variables
        public static int overview_flowlayout_panel1 = 200;
        public static int overview_flowlayout_panel2 = overall_container_height - 200;


        //User screen layout variables
        public static int user_panel_1 = 90;
        public static int user_panel_2 = overall_container_height - 90;

        //Category screen layout variables
        public static int category_panel_1 = 187;
        public static int category_panel_2 = overall_container_height - 200;
        

    }
}
