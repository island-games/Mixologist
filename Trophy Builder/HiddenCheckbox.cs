using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using static Trophy_Builder.Manager;

namespace Trophy_Builder
{
    public class HiddenCheckbox :Button
    {
        bool isActive = false;
        bool clickHasBeenPressed = false;
        public HiddenCheckbox()
        {
            x = 545;
            y = 210;
            width = 38;
            height = 36;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Is Hidden?: ", new Vector2(x - 100, y + 15), Color.White);

            if (listOfTrophyItems.Count > trophySelected)
            {
                if (listOfTrophyItems[trophySelected].isHidden == true)
                {
                    spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(147, 469, width, height), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);
                }
                else
                {
                    spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(147, 433, width, height), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);
                }
            }
        }

        public void Activate()
        {
            if (listOfTrophyItems.Count > trophySelected)
            {
                if (listOfTrophyItems[trophySelected].isHidden == true)
                {
                    listOfTrophyItems[trophySelected].isHidden = false;
                    return;
                }
                else
                {
                    listOfTrophyItems[trophySelected].isHidden = true;
                    return;
                }
            }
        }

        public void Update()
        {
            if(Mouse.GetState().LeftButton == ButtonState.Released)
            {
                if (clickHasBeenPressed == true)
                {
                    Activate();
                    
                }
            }

            clickHasBeenPressed = false;
            clickHasBeenPressed = CheckClick();
        }
    }
}
