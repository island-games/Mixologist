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
    public class DeleteTrophyButton : Button
    {
        bool onReleaseCheck = false;

        public DeleteTrophyButton()
        {
            x = 650;
            y = 610;
            width = 190;
            height = 45;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(0, 143, width, height), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);
            spriteBatch.DrawString(font, "Delete Trophy", new Vector2(x + 43, y + 17), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
        }

        public void DeleteTrophy()
        {
            if(listOfTrophyItems.Count >1)
            {
                listOfTrophyItems.RemoveAt(trophySelected);
                messagePopUp.UpdateMessage("Trophy Deleted");
                RecalculateTotalTrophyScore();
            }
        }

        public void SetGraphicsDevice(GraphicsDevice temp)
        {
            graphicsDevice = temp;
        }

        public void Update()
        {
            CheckHover();

            if (Mouse.GetState().LeftButton == ButtonState.Released && onReleaseCheck == true)
            {
                if (isLocked == false)
                {
                    DeleteTrophy();

                    trophySelected--;
                    if (trophySelected < 0)
                    {
                        trophySelected = 0;
                    }

                    InsertNewTrophyDetails(trophySelected);
                }
            }

            onReleaseCheck = false;
            if (CheckClick() == true)
            {
                onReleaseCheck = true;
            }
        }
    }
}
