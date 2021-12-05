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
    class TrophyList : Button
    {
        int itemNumber;

        public TrophyList(int tempItemNumber)
        {
            itemNumber = tempItemNumber;
            x = 5;
            y = 58 + (itemNumber * 60);
            width = 365;
            height = 78;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(0, 0, 180, 49), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);
            spriteBatch.Draw(uiElements, new Vector2(x, y + 31), new Rectangle(0, 20, 180, 29), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel + .01f);
            spriteBatch.Draw(uiElements, new Vector2(x + 180, y), new Rectangle(10, 0, 185, 49), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);
            spriteBatch.Draw(uiElements, new Vector2(x + 180, y+ 31), new Rectangle(10, 20, 185, 29), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel + .01f);
            spriteBatch.DrawString(font, "#" + (trophyListPosition + itemNumber), new Vector2(x + 5, y + 5), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);

            if (listOfTrophyItems.Count < itemNumber + trophyListPosition + 1)
            {
                spriteBatch.DrawString(font, "Trophy Slot Is Empty", new Vector2(x + 50, y + 15), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
            }
            else
            {
                string tempTrophyName = listOfTrophyItems[itemNumber + trophyListPosition].trophyName;
                if(tempTrophyName.Length > 37)
                {
                    tempTrophyName = tempTrophyName.Substring(0, 37);
                    tempTrophyName += "...";
                }
                else if(tempTrophyName.Length == 0)
                {
                    tempTrophyName = "Unnamed Trophy";
                }
                spriteBatch.DrawString(font, tempTrophyName, new Vector2(x + 50, y + 15), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
            }


        }

        public void SwapTrophyDetails(bool tempClick)
        {
            if(tempClick == true)
            {
                InsertNewTrophyDetails(itemNumber + trophyListPosition);
                
            }
        }

        public void Update()
        {
            CheckHover();
            bool checkClick = CheckClick();
            SwapTrophyDetails(checkClick);
        }
    }
}
