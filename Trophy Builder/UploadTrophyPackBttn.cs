using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Trophy_Builder.Manager;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Trophy_Builder
{
    class UploadTrophyPackBttn :Button
    {
        bool onReleaseCheck = false;
        public UploadTrophyPackBttn()
        {
            x = 760;
            y = 0;
            width = 190;
            height = 45;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(uiElements, new Vector2(x, y), new Rectangle(0, 143, width, height), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, bttnLevel);
            spriteBatch.DrawString(font, uploadTrophyPack, new Vector2(x + 25, y + 17), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
        }


        public bool ValidateGameImage()
        {
            bool passCheck = false;

            if (gameImageDirectory != "")
            {
                passCheck = true;
               
            }
            else
            {
                messagePopUp.UpdateMessage("You need to add a Game Image before uploading.");
            }


            return passCheck;
        }

        public bool ValidateTrophies()
        {
            bool passCheck = true;
            for (int i = 0; i < listOfTrophyItems.Count; i++)
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

            if (gameIDField.fieldText.Length == 9 && gamePasswordField.fieldText.Length > 0 && gameNameField.fieldText.Length > 0 && currentTotalScore <= scoreLimit && listOfTrophyItems.Count >= 10)
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

            if (gamePasswordField.fieldText.Length <= 0)
            {
                messagePopUp.UpdateMessage("Password is Invalid");
                return passCheck;
            }

            if(currentTotalScore > scoreLimit)
            {
                messagePopUp.UpdateMessage("The packs score exceeds the limit.");
                return false;
            }

            if(listOfTrophyItems.Count < 10)
            {
                messagePopUp.UpdateMessage("Packs require at least 10 trophies.");
                return false;
            }

            if (listOfTrophyItems[0].trophyLevel == 4 && currentTotalScore < 140)
            {
                messagePopUp.UpdateMessage("Vita Island Ice Tea requires min 140 pts.");
                return false;
            }

            if(saveFileDirectory == String.Empty)
            {
                messagePopUp.UpdateMessage("Please save your trophy pack before uploading.");
                return false;
            }

            return passCheck;

        }

        public string EncryptTrophy(string stringToConvert)
        {
            Byte[] textBytes = System.Text.Encoding.Default.GetBytes(stringToConvert);
            //Private Method
            return tempString;
        }

        public string GetTrophies()
        {
            string sendBack = "";
            for(int i = 0; i < listOfTrophyItems.Count; i++)
            {
              
                string tempText = "" //Private Method;
                tempText = EncryptTrophy(tempText);
                tempText = tempText.ToLower();
                tempText += " INT NOT NULL";

                if (i != listOfTrophyItems.Count()-1)
                {
                    tempText += ",";
                }

                sendBack += tempText;
            }

            sendBack += ")";
            return sendBack;
        }

        public async void UploadToDatabase()
        {
            if(ValidateGameImage() == true && ValidateGameInformation() == true && ValidateTrophies() == true)
            {
                HttpClient client = new HttpClient();
            
            string dataToPost = "query=";
			//Private information for posting to the server goes here.
            requestMessage.Content = new StringContent(dataToPost, Encoding.UTF8, "application/x-www-form-urlencoded");

           var response =  await client.SendAsync(requestMessage);
           string contents = await response.Content.ReadAsStringAsync();

            if (contents.Length > 0)
            {
                contents = contents.Replace("\n", "");
                messagePopUp.UpdateMessage(contents);

                if(contents.Contains("Success"))
                {
                        isLocked = true;
                        saveTrophyPackBttn.SaveTrophyPack();
                }
                        
            }


             }
        }

        public void Update()
        {
            CheckHover();

            if (Mouse.GetState().LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && onReleaseCheck == true)
            {
                if (isLocked == false)
                {
                    UploadToDatabase();
                }

                else
                {
                    messagePopUp.UpdateMessage("This trophy pack is locked.");
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
