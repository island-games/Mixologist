using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using static Trophy_Builder.Manager;

namespace Trophy_Builder
{
    public class AddTrophyImageButton : Button
    {
        bool onReleaseCheck = false;
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public AddTrophyImageButton()
        {
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "(PNG Format)|*.png";
            x = 860;
            y = 610;
            width = 190;
            height = 45;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(0, 143, width, height), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);
            spriteBatch.DrawString(font, "Add Trophy Image", new Vector2(x + 35, y + 17), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
        }

        public void LoadImage()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                listOfTrophyItems[trophySelected].fileDirectory = openFileDialog.FileName;
                listOfTrophyItems[trophySelected].UpdateImage();
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
