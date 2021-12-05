using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Trophy_Builder.Manager;

namespace Trophy_Builder
{
    class ScrollDownBttn : Button
    {
        int buttonTimer = 0;
        public ScrollDownBttn()
        {
            x = 390;
            y = 610;
            width = 28;
            height = 42;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(190, 234, width, height), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);
        }

        public void Click()
        {
            if (buttonTimer == 0 || buttonTimer == 30)
            {
                trophyListPosition++;
                if (trophyListPosition > 90)
                {
                    trophyListPosition = 90;
                }
            }

            buttonTimer++;
            if(buttonTimer > 30)
            {
                buttonTimer = 20;
            }
        }

        public void Update()
        {
            CheckHover();
            
            if(CheckClick() == true)
            {
                Click();
            }
            else
            {
                buttonTimer = 0;
            }
        }
    }
}
