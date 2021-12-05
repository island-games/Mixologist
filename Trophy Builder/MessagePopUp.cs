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
    public class MessagePopUp
    {
        string messageToDisplay = "";
        int x = 900;
        int y = 0;
        int width = 380;
        int height = 50;
        int lifeTime = 200;

        public MessagePopUp()
        {
            
        }

        public void UpdateMessage(string tempMessageToDisplay)
        {
            messageToDisplay = tempMessageToDisplay;
            lifeTime = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(lifeTime < 180)
            {
                spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(226, 374, 1, 1), Color.White, 0f, new Vector2(0, 0), new Vector2(width, height), SpriteEffects.None, .9f);
                spriteBatch.DrawString(font, messageToDisplay, new Vector2(x+ 10, y + 20), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, .92f);
            }
        }

        public void Update()
        {
            if(lifeTime < 180)
            {
                lifeTime++;
            }
        }
    }
}
