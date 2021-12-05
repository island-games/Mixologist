using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using static Trophy_Builder.Manager;
using System.IO;

namespace Trophy_Builder
{
    class LoadTrophyPackBttn : Button
    {
        bool onReleaseCheck = false;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public LoadTrophyPackBttn()
        {
            x = 380;
            y = 0;
            width = 190;
            height = 45;

            openFileDialog.Filter = "Trophy File|*.trophy";
            openFileDialog.Multiselect = false;
            openFileDialog.DefaultExt = "Trophy";

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(0, 143, width, height), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);
            spriteBatch.DrawString(font, loadTrophyPack, new Vector2(x + 25, y + 17), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
        }


        public void LoadTrophyPack()
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                NewTrophyPack();
                saveFileDirectory = openFileDialog.FileName;
                StreamReader fileStream = new StreamReader(saveFileDirectory);
                string fileLoaded = fileStream.ReadToEnd();
                //LoadObject tempLoadObject = new LoadObject();
                gameNameInput = JsonConvert.DeserializeObject<LoadObject>(fileLoaded).saveGameNameInput;
                gameIDInput = JsonConvert.DeserializeObject<LoadObject>(fileLoaded).saveGameIDInput;
                passwordInput = JsonConvert.DeserializeObject<LoadObject>(fileLoaded).savePasswordInput;
                gameNameField.fieldText = JsonConvert.DeserializeObject<LoadObject>(fileLoaded).saveGameNameInput;
                gameIDField.fieldText = JsonConvert.DeserializeObject<LoadObject>(fileLoaded).saveGameIDInput;
                gamePasswordField.fieldText = JsonConvert.DeserializeObject<LoadObject>(fileLoaded).savePasswordInput;
                isLocked = JsonConvert.DeserializeObject<LoadObject>(fileLoaded).isLocked;
                gameImageDirectory = JsonConvert.DeserializeObject<LoadObject>(fileLoaded).saveGameImageDirectory;

                listOfTrophyItems = JsonConvert.DeserializeObject<LoadObject>(fileLoaded).saveListOfTrophies;
                trophyNameField.fieldText = listOfTrophyItems[0].trophyName;
                trophyDescriptionField.fieldText = listOfTrophyItems[0].trophyDescription;
                listOfTrophyItems[trophySelected].UpdateImage();

                Console.WriteLine(saveFileDirectory);
                fileStream.Close();
                RecalculateTotalTrophyScore();

                if(gameImageDirectory != String.Empty)
                {
                    FileStream fileStreamTemp = new FileStream(gameImageDirectory, FileMode.Open, FileAccess.Read);

                    // Texture2D tempTexture 
                    gameImage = Texture2D.FromStream(graphicsDevice, fileStreamTemp);
                    if (gameImage.Width != 150 || gameImage.Height != 80)
                    {
                        gameImageDirectory = "";
                        gameImage.Dispose();
                        
                    }
                }

                messagePopUp.UpdateMessage("File Loaded");
            }

            openFileDialog.Dispose();
        }

        

        public void Update()
        {
            CheckHover();

            if (Mouse.GetState().LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && onReleaseCheck == true)
            {
                LoadTrophyPack();
            }
            
            onReleaseCheck = false;
            if (CheckClick() == true)
            {
                onReleaseCheck = true;
            }
        }
    }
}
