using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using static Trophy_Builder.Manager;

namespace Trophy_Builder
{
    public class AddGameImageBttn : Button
    {
        bool onReleaseCheck = false;
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public AddGameImageBttn()
        {
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "(PNG Format)|*.png";
            x = 950;
            y = 0;
            width = 190;
            height = 45;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(0, 143, width, height), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);
            spriteBatch.DrawString(font, "Add Game Image", new Vector2(x + 33, y + 17), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
        }

        public void LoadImage()
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                gameImageDirectory = openFileDialog.FileName;

                messagePopUp.UpdateMessage("Game Image Added");

                FileStream fileStream = new FileStream(gameImageDirectory, FileMode.Open, FileAccess.Read);
              
               // Texture2D tempTexture 
               gameImage = Texture2D.FromStream(graphicsDevice, fileStream);
                if(gameImage.Width != 150 || gameImage.Height != 80)
                {
                    gameImageDirectory = "";
                    gameImage.Dispose();
                    messagePopUp.UpdateMessage("Game Image must be 150 x 80 pixels.");
                }
                else
                {
                    //gameImage = tempTexture;
                    messagePopUp.UpdateMessage("Game Image loaded succesfully.");
                    
                }

               // tempTexture.Dispose();

            }
        }

        public void Update()
        {
            CheckHover();

            if (Mouse.GetState().LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && onReleaseCheck == true)
            {
                LoadImage();
            }

            onReleaseCheck = false;
            if (CheckClick() == true)
            {
                onReleaseCheck = true;
            }
        }
    }
}
