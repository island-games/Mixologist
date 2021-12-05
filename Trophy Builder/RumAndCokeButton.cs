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
   public  class RumAndCokeButton : Button
    {
        

        public RumAndCokeButton()
        {
            x = 587;
            y = 330;
            width = 36;
            height = 36;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Rum and Coke: ", new Vector2(x - 144, y + 10), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);

            if (listOfTrophyItems.Count > trophySelected)
            {
                if (listOfTrophyItems[trophySelected].trophyLevel == 1)
                {
                    spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(190, 198, width, height), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);
                    return;
                }
              
            }
            spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(185, 469, width, height), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);

        }

        public void ActivateTrophyLevel()
        {
            if (listOfTrophyItems.Count > trophySelected)
            {
                listOfTrophyItems[trophySelected].trophyLevel = 1;
                RecalculateTotalTrophyScore();
            }
        }

        public void Update()
        {
            CheckHover();
            if (CheckClick() == true)
            {
                if (isLocked == false)
                {
                    ActivateTrophyLevel();
                }
            }

        }
    }

}
