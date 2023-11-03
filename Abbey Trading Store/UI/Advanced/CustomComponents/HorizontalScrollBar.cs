using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace Abbey_Trading_Store.UI.Advanced.CustomComponents
{
    public class HorizontalScrollBar : HScrollBar
    {

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Set your desired custom colors for the scrollbar background and thumb
            Color backgroundColor = Color.Gray;  // Change to your preferred color
            Color thumbColor = Color.Blue;       // Change to your preferred color

            using (Brush backgroundBrush = new SolidBrush(backgroundColor))
            using (Brush thumbBrush = new SolidBrush(thumbColor))
            {
                // Draw the scrollbar background
                e.Graphics.FillRectangle(backgroundBrush, ClientRectangle);

                // Calculate the thumb's dimensions and position
                int thumbLength = (int)((ClientRectangle.Width - 6) * ((float)(Maximum - LargeChange + 1)));
                int thumbPosition = (int)((ClientRectangle.Width - thumbLength) * (Value - Minimum) / (Maximum - LargeChange));

                // Draw the thumb
                e.Graphics.FillRectangle(thumbBrush, thumbPosition, 0, thumbLength, ClientRectangle.Height);
            }
        }
    }
}
