using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using static Trophy_Builder.Manager;
using System.IO;

namespace Trophy_Builder
{
    public class SaveTrophyPackBttn :Button
    {
        bool onReleaseCheck = false;
        SaveFileDialog fileDialogBox = new SaveFileDialog();
        public SaveTrophyPackBttn()
        {
            
            fileDialogBox.Filter = "Trophy File|*.trophy";
            fileDialogBox.AddExtension = true;
            fileDialogBox.OverwritePrompt = true;
            fileDialogBox.DefaultExt = "trophy";
           
            x = 190;
            y = 0;
            width = 190;
            height = 45;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(0, 143, width, height), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);
            spriteBatch.DrawString(font, saveTrophyPack, new Vector2(x + 25, y + 17), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
        }

        public void SaveTrophyPack()
        {
            if (saveFileDirectory == "")
            {
                if (fileDialogBox.ShowDialog() == DialogResult.OK)
                {
                    saveFileDirectory = fileDialogBox.FileName;
                    SaveFile();
                    return;

                }
            }
            else
            {
                SaveFile();
            }
        }

        public void SaveFile()
        {
            string fileToSave = "";
            
            fileToSave += "{ \n";
            fileToSave += @"""saveGameNameInput"":";
            fileToSave += "\"";
            fileToSave += gameNameInput;
            fileToSave += "\", \n";
            fileToSave += @"""saveGameIDInput"":";
            fileToSave += "\"";
            fileToSave += gameIDInput;
            fileToSave += "\", \n";
            fileToSave += @"""savePasswordInput"":";
            fileToSave += "\"";
            fileToSave += passwordInput;
            fileToSave += "\", \n";
            fileToSave += @"""isLocked"":";
            fileToSave += JsonConvert.SerializeObject(isLocked);
            fileToSave += ", \n";
            fileToSave += @"""saveGameImageDirectory"":";
            fileToSave += JsonConvert.SerializeObject(gameImageDirectory);
            fileToSave += ", \n";
            fileToSave += @"""saveListOfTrophies"":";
            fileToSave += JsonConvert.SerializeObject(listOfTrophyItems);
            StreamWriter saveFile = new StreamWriter(saveFileDirectory);

            fileToSave += "}";
            saveFile.Write(fileToSave);
            saveFile.Close();

            messagePopUp.UpdateMessage("File Successfully Saved");
        }

        

        public void Update()
        {
            CheckHover();

            if (Mouse.GetState().LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && onReleaseCheck == true)
            {
                SaveTrophyPack();
            }

            onReleaseCheck = false;
            if (CheckClick() == true)
            {
                onReleaseCheck = true;
            }
        }
    }
}
