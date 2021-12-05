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
   public  class GameIDField : TextField
    {
        int displayTime = 0;

        public GameIDField()
        {
            x = 685;
            y = 680;
            height = 30;
            width = 150;
            textLimit = 9;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            


            spriteBatch.DrawString(font, fieldText, new Vector2(x + 4, y + 15), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
            if (isActive == true)
            {
                Vector2 cursorPositionTemp = font.MeasureString(fieldText.Substring(0, cursorPosition));
                displayTime++;
                if (displayTime <= 20)
                {
                    if (cursorPosition == 0)
                    {
                        spriteBatch.Draw(textboxImage, new Vector2(x + cursorPositionTemp.X + 4, y + +cursorPositionTemp.Y + 14), new Rectangle(0, 0, 2, 18), Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, bttnTestLevel);

                    }
                    else
                    {
                        spriteBatch.Draw(textboxImage, new Vector2(x + cursorPositionTemp.X + 4, y + cursorPositionTemp.Y - 4), new Rectangle(0, 0, 2, 18), Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, bttnTestLevel);
                    }
                }

                if(displayTime >= 30)
                {
                    displayTime = 0;
                }
            }

        }

        public void CheckIfActive(bool tempClick)
        {
            if (isActive == true)
            {
                if (tempClick == true)
                {
                    isActive = true;
                    SetCursorPositionClick(x);
                }
                else
                {
                    isActive = false;
                }
            }
            else
            {
                if (tempClick == true)
                {
                    isActive = true;
                }
                else
                {
                    isActive = false;
                }
            }
        }

        public void Update()
        {
           
            if (isActive == true)
            {
                if (isLocked == false)
                {
                    TextButtonInput();
                }
            }


            
                gameIDInput = fieldText;
            

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                bool tempCheckClick = CheckClick();
                CheckIfActive(tempCheckClick);
            }
        }
    }
}
