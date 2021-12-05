using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Trophy_Builder
{
    public class Button
    {
        public int x;
        public int y;
        public int width;
        public int height;


        public bool CheckClick()
        {
            bool hasClicked = false;

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (Mouse.GetState().X <= x + width && Mouse.GetState().X >= x)
                {
                    if (Mouse.GetState().Y <= y + height && Mouse.GetState().Y >= y)
                    {
                        hasClicked = true;
                    }
                }
            }


                return hasClicked;
        }

        public bool CheckHover()
        {
            bool isHovering = false;

            if (Mouse.GetState().X <= x + width && Mouse.GetState().X >= x)
            {
                if (Mouse.GetState().Y <= y + height && Mouse.GetState().Y >= y)
                {
                    isHovering = true;
                    Mouse.SetCursor(MouseCursor.Hand);
                }
            }

             return isHovering;
        }

    }
}
