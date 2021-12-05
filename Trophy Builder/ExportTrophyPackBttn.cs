using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using static Trophy_Builder.Manager;

namespace Trophy_Builder
{
    class ExportTrophyPackBttn :Button
    {
        bool onReleaseCheck = false;
        FolderBrowserDialog saveFileDialog = new FolderBrowserDialog();

        List<Vector2> listOfTrophieVectors = new List<Vector2>();

        public ExportTrophyPackBttn()
        {
            
            x = 570;
            y = 0;
            width = 190;
            height = 45;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(0, 143, width, height), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);
            spriteBatch.DrawString(font, exportTrophyPack, new Vector2(x + 25, y + 17), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
        }

        public bool ValidateGameImage()
        {
            bool passCheck = false;

            if(gameImageDirectory != "")
            {
                passCheck = true;
            }
            

            return passCheck;
        }

        public bool ValidateTrophies()
        {
            bool passCheck = true;
            for(int i = 0; i <listOfTrophyItems.Count; i++)
            {
                if (listOfTrophyItems[i].trophyDescription == String.Empty)
                {
                    messagePopUp.UpdateMessage("Export Failed: Trophy #" + i + " No Description");
                    passCheck = false;
                    return passCheck;
                }
                if (listOfTrophyItems[i].trophyName == String.Empty)
                {
                    messagePopUp.UpdateMessage("Export Failed: Trophy #" + i + " No Name");
                    passCheck = false;
                    return passCheck;
                }
                if (listOfTrophyItems[i].fileDirectory == String.Empty)
                {
                    messagePopUp.UpdateMessage("Export Failed: Trophy #" + i + " No Image");
                    passCheck = false;
                    return passCheck;
                }
            }

            return passCheck;
        }

        public bool ValidateGameInformation()
        {
            bool passCheck = false;

            if (gameIDField.fieldText.Length == 9 && gamePasswordField.fieldText.Length > 0 && gameNameField.fieldText.Length > 0)
            {
                passCheck = true;
            }

            if (gameNameField.fieldText.Length <= 0)
            {
                messagePopUp.UpdateMessage("Game Name is Invalid");
                return passCheck;
            }

            if (gameIDField.fieldText.Length != 9)
            {
                messagePopUp.UpdateMessage("Game ID is Invalid");
                return passCheck;
            }

            if(gamePasswordField.fieldText.Length <= 0)
            {
                messagePopUp.UpdateMessage("Password is Invalid");
                return passCheck;
            }

            return passCheck;

        }

        public void ExportFile()
        {
            //  ZipEntry entry = new ZipEntry("MyFile.png");
            //entry.CompressionMethod = CompressionMethod.Stored;

            
            if (ValidateTrophies() == true && ValidateGameInformation() == true && ValidateGameImage() == true)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine(saveFileDialog.SelectedPath);
                    if(!Directory.Exists(saveFileDialog.SelectedPath + @"\trophytmp"))
                    {
                        Directory.CreateDirectory(saveFileDialog.SelectedPath +@"\trophytmp");
                    }
                    else
                    {
                        Directory.Delete(saveFileDialog.SelectedPath + @"\trophytmp", true);
                        Directory.CreateDirectory(saveFileDialog.SelectedPath + @"\trophytmp");
                    }

                    if (File.Exists(saveFileDialog.SelectedPath))
                    {
                        //File.Delete(saveFileDialog.FileName);
                    }

                    Texture2D textureToSave = GenerateTexture();
                     Stream textureDirectory = File.Create(saveFileDialog.SelectedPath + @"\trophytmp\trophy.png");
                    textureToSave.SaveAsPng(textureDirectory, textureToSave.Width, textureToSave.Height);
                    textureDirectory.Close();
                    
                    FileStream gameImageStream = new FileStream(gameImageDirectory, FileMode.Open, FileAccess.Read);
                    Texture2D gameImageTexture = Texture2D.FromStream(graphicsDevice, gameImageStream);
                    Stream gameImageDirectoryStream = File.Create(saveFileDialog.SelectedPath + @"\trophytmp\game.png");
                    gameImageTexture.SaveAsPng(gameImageDirectoryStream, gameImageTexture.Width, gameImageTexture.Height);
                    gameImageDirectoryStream.Close();
                    gameImageTexture.Dispose();
                    gameImageStream.Dispose();

                    string textToOutput = GenerateText();
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.SelectedPath + @"\trophytmp\trophy.msv");
                    streamWriter.Write(textToOutput);
                    streamWriter.Close();

                    FastZip fastZip = new FastZip();
                    fastZip.EntryEncryptionMethod = ZipEncryptionMethod.AES256;
                    fastZip.Password = passwordInput;
                    fastZip.CreateZip(saveFileDialog.SelectedPath + @"\" + gameIDField.fieldText +@".dat", saveFileDialog.SelectedPath + @"\trophytmp", false, "");

                    Directory.Delete(saveFileDialog.SelectedPath + @"\trophytmp", true);

                    messagePopUp.UpdateMessage("Trophy Pack Exported");
                }

                saveFileDialog.Dispose();
            }
            
        }


        public string GenerateText()
        {
            string temp = "";

            for (int i = 0; i < listOfTrophyItems.Count; i++)
            {
                temp += listOfTrophyItems[i].trophyName;
                temp += "|";
                temp += listOfTrophyItems[i].trophyDescription;
                temp += "|";
                temp += listOfTrophyItems[i].trophyLevel;
                temp += "|";
                temp += listOfTrophyItems[i].isHidden;
                temp += "|";
                temp += listOfTrophieVectors[i].X;
                temp += "|";
                temp += listOfTrophieVectors[i].Y;
                temp += "|";
                temp += "0";
                temp += "|";
                temp += "0";
                if (i != listOfTrophyItems.Count - 1)
                {
                    temp += "\n";
                }
            }
                return temp;
        }

        public Texture2D GenerateTexture()
        {
            Texture2D myTexture = new Texture2D(graphicsDevice, 512, 512);
            Color[] colorData = new Color[512 *512];
            int currentPosition = 0;
            int drawingToX = 0;
            int drawingToY = 0;
            for(int i = 0; i < listOfTrophyItems.Count; i++)
            {
                listOfTrophieVectors.Add(new Vector2(drawingToX,drawingToY));

                if (File.Exists(listOfTrophyItems[i].fileDirectory) == true)
                {
                    FileStream stream = new FileStream(listOfTrophyItems[i].fileDirectory, FileMode.Open, FileAccess.Read);
                    Texture2D tempTexture = Texture2D.FromStream(graphicsDevice, stream);
                    Color[] currentTextureColor = new Color[tempTexture.Width * tempTexture.Height];
                    tempTexture.GetData<Color>(currentTextureColor);
                    currentPosition = 0;

                    for(int y2 = drawingToY; y2 < drawingToY + 48; y2++)
                    {
                        for(int x2 = drawingToX; x2 < drawingToX + 48; x2++)
                        {
                            colorData[(y2 *512) + x2] = currentTextureColor[currentPosition];

                            currentPosition++;
                        }
                    }

                    drawingToX += 48;
                    Console.WriteLine(drawingToX);
                    if(drawingToX > 464)
                    {
                        Console.WriteLine("New");
                        drawingToX = 0;
                        drawingToY += 48;
                    }

                    
                }

            }

            Color[] currentTextureColor3 = new Color[drinkImage.Width * drinkImage.Height];
            drinkImage.GetData<Color>(currentTextureColor3);
            currentPosition = 0;

            // Trophy 1
            drawingToX = 488;
            drawingToY = 0;

            for(int y2 = drawingToY; y2 < drawingToY + 24; y2++)
            {
                for(int x2 = drawingToX; x2 < drawingToX + 24; x2++)
                {
                    colorData[(y2 * 512) + x2] = currentTextureColor3[currentPosition];
                    currentPosition++;
                }

                currentPosition -= 24;
                currentPosition += drinkImage.Width;
            }

            //Trophy 2
            drawingToX = 488;
            drawingToY = 24;
            currentPosition = 24;

            for (int y2 = drawingToY; y2 < drawingToY + 24; y2++)
            {
                for (int x2 = drawingToX; x2 < drawingToX + 24; x2++)
                {
                    colorData[(y2 * 512) + x2] = currentTextureColor3[currentPosition];
                    currentPosition++;
                }

                currentPosition -= 24;
                currentPosition += drinkImage.Width;
            }


            //Trophy 3 
            drawingToX = 488;
            drawingToY = 48;
            currentPosition = 48;

            for (int y2 = drawingToY; y2 < drawingToY + 24; y2++)
            {
                for (int x2 = drawingToX; x2 < drawingToX + 24; x2++)
                {
                    colorData[(y2 * 512) + x2] = currentTextureColor3[currentPosition];
                    currentPosition++;
                }

                currentPosition -= 24;
                currentPosition += drinkImage.Width;
            }

            //Trophy 4
            drawingToX = 488;
            drawingToY = 72;
            currentPosition = 72;

            for (int y2 = drawingToY; y2 < drawingToY + 24; y2++)
            {
                for (int x2 = drawingToX; x2 < drawingToX + 24; x2++)
                {
                    colorData[(y2 * 512) + x2] = currentTextureColor3[currentPosition];
                    currentPosition++;
                }

                currentPosition -= 24;
                currentPosition += drinkImage.Width;
            }


            // Add the Pop-Up Texture to the Sprite Atlas
            drawingToX = 0;
            drawingToY = 480;
            

            Color[] currentTextureColor2 = new Color[popupImage.Width * popupImage.Height];
            popupImage.GetData<Color>(currentTextureColor2);
            currentPosition = 0;

            for (int y2 = drawingToY; y2 < drawingToY + popupImage.Height; y2++)
            {
                for (int x2 = drawingToX; x2 < drawingToX + popupImage.Width; x2++)
                {
                    colorData[(y2 * 512) + x2] = currentTextureColor2[currentPosition];

                    currentPosition++;
                }
            }


            myTexture.SetData(colorData);

            return myTexture;
        }

        public void Update()
        {
            CheckHover();

            if (Mouse.GetState().LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && onReleaseCheck == true)
            {
                ExportFile();
            }

            onReleaseCheck = false;
            if (CheckClick() == true)
            {
                onReleaseCheck = true;
            }
        }
    }
}
