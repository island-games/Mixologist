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
    class NewTrophyPackBttn : Button
    {
        bool hasBeenClicked = false;
        bool isHoveredOver = false;
        public NewTrophyPackBttn()
        {
            x = 0;
            y = 0;
            width = 190;
            height = 45;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(uiElements,new Vector2(x,y),new Rectangle(0,143,width,height),Color.White,0f,new Vector2(0,0),1f,SpriteEffects.None,bttnLevel);
            spriteBatch.DrawString(font, createTrophyPack, new Vector2(x + 25, y + 17), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
        }

        public void ButtonClicked()
        {
            if(hasBeenClicked == true)
            {
                NewTrophyPack();
                messagePopUp.UpdateMessage("Created New Trophy Pack");
            }
        }

        public void Update()
        {
            hasBeenClicked = false;
            isHoveredOver = false;

            hasBeenClicked = CheckClick();
            isHoveredOver = CheckHover();
            ButtonClicked();
        }
    }
}
