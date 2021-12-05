using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Trophy_Builder
{ 
    public class Manager
    {
        public static MessagePopUp messagePopUp;

        public static bool isLocked = false;

        public static Texture2D uiElements;
        public static Texture2D textboxImage;
        public static Texture2D popupImage;
        public static Texture2D drinkImage;
        public static Texture2D gameImage;
        public static SpriteFont font;
        public static SpriteFont font2;
        public static Game1 gameObject;

        public static int currentTotalScore = 5;
        public static int scoreLimit = 800;

        public static GraphicsDevice graphicsDevice;

        public static int trophyListPosition = 0;
        public static int trophySelected = 0;

        static public string gameNameInput;
        static public string gameIDInput;
        public static string passwordInput;
        public static string saveFileDirectory = "";
        public static string gameImageDirectory = "";

        public static string isPlatinum = "Is Platinum?";
        public static string createTrophyPack = "Create Trophy Pack";
        public static string saveTrophyPack = "Save Trophy Pack";
        public static string loadTrophyPack = "Load Trophy Pack";
        public static string exportTrophyPack = "Export Trophy Pack";
        public static string isHidden = "Is Hidden?";
        public static string addImage = "Add Image";
        public static string trophyName = "Trophy Name:";
        public static string trophyDescription = "Trophy Description:";
        public static string gameName = "Game Name:";
        public static string gameIDString = "Game ID:";
        public static string passwordString = "Password:";
        public static string generatePassword = "Generate Password";
        public static string uploadTrophyPack = "Upload Trophy Pack";

        public static float bttnLevel = .10f;
        public static float bttnTestLevel = .12f;

        public static Texture2D trophyImageTexture;

        NewTrophyPackBttn newTrophyPackBttn;
        public static SaveTrophyPackBttn saveTrophyPackBttn;
        LoadTrophyPackBttn loadTrophyPackBttn;
        ExportTrophyPackBttn exportTrophyPackBttn;
        UploadTrophyPackBttn uploadTrophyPackBttn;
        ScrollDownBttn scrollDownBttn;
        ScrollUpBttn scrollUpBttn;
        AddGameImageBttn addGameImageBttn;
        public static TrophyName trophyNameField;
        public static TrophyDescription trophyDescriptionField;
        static HiddenCheckbox hiddenCheckbox;
        public static GamePasswordField gamePasswordField;
        public static GameIDField gameIDField;
        public static GameNameField gameNameField;
        static RumAndCokeButton rumAndCokeButton;
        static Mojito mojitoButton;
        static PinaColada pinaColadaButton;
        static VitaIslandIceTea vitaIslandIceTeaButton;
        static AddTrophyButton addTrophyButton;
        static DeleteTrophyButton deleteTrophyButton;
        static AddTrophyImageButton addTrophyImageButton;

        

        List<TrophyList> listOfTrophiesList = new List<TrophyList>();
       public static List<TrophyItem> listOfTrophyItems = new List<TrophyItem>();

        public Manager(Game1 tempGame)
        {
            gameObject = tempGame;
            LoadGraphics();
            AddButtons();
            listOfTrophyItems.Add(new TrophyItem());
            
        }

        public void AddButtons()
        {
            
            // New Trophy Pack
            newTrophyPackBttn = new NewTrophyPackBttn();

            // Load Trophy Pack
            loadTrophyPackBttn = new LoadTrophyPackBttn();
            // Save Trophy Pack
            saveTrophyPackBttn = new SaveTrophyPackBttn();

            // Add Game Image Button
            addGameImageBttn = new AddGameImageBttn();

            // Add New Trophy
            addTrophyButton = new AddTrophyButton();

            // Delete Trophy
            deleteTrophyButton = new DeleteTrophyButton();

            // Export Trophy Pack
            exportTrophyPackBttn = new ExportTrophyPackBttn();

            // Upload Trophy Pack to the Server
            uploadTrophyPackBttn = new UploadTrophyPackBttn();

            // Scroll Up Button
            scrollUpBttn = new ScrollUpBttn();

            // Scroll Down Button
            scrollDownBttn = new ScrollDownBttn();


            // Add Trophy Image Button
            addTrophyImageButton= new AddTrophyImageButton();

            // Trophy List Items
            for(int i = 0; i < 10; i++)
            {
                listOfTrophiesList.Add(new TrophyList(i));
            }

            // Trophy Name Field

            trophyNameField = new TrophyName();

            // Trophy Description Field
            trophyDescriptionField = new TrophyDescription();

            // Is Hidden Checkbox
            hiddenCheckbox = new HiddenCheckbox();

            // Game Name Field
            gameNameField = new GameNameField();

            // Game ID Field
            gameIDField = new GameIDField();

            // Game Password Field
            gamePasswordField = new GamePasswordField();

            rumAndCokeButton = new RumAndCokeButton();
            pinaColadaButton = new PinaColada();
            mojitoButton = new Mojito();
            vitaIslandIceTeaButton = new VitaIslandIceTea();

            // Message Pop Up
            messagePopUp = new MessagePopUp();

        }

        public void SetGraphicsDevice(GraphicsDevice temp)
        {
            graphicsDevice = temp;
        }

        public void LoadGraphics()
        {
            uiElements = gameObject.Content.Load<Texture2D>("greySheet");
            textboxImage = gameObject.Content.Load<Texture2D>("textbox");
            popupImage = gameObject.Content.Load<Texture2D>("PopupBox");
            drinkImage = gameObject.Content.Load<Texture2D>("DrinkTypes");
            font = gameObject.Content.Load<SpriteFont>("Font");
            font2 = gameObject.Content.Load<SpriteFont>("Font2");
        }

        public string GeneratePassword()
        {
            string tempPassword = "";


            return tempPassword;

        }

        static public void InsertNewTrophyDetails(int trophyNumberSelected)
        {
            if(trophyNumberSelected < listOfTrophyItems.Count)
            {
                trophySelected = trophyNumberSelected;
                trophyNameField.fieldText = listOfTrophyItems[trophyNumberSelected].trophyName;
                trophyDescriptionField.fieldText = listOfTrophyItems[trophyNumberSelected].trophyDescription;
                listOfTrophyItems[trophyNumberSelected].UpdateImage();
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            newTrophyPackBttn.Draw(spriteBatch);
            saveTrophyPackBttn.Draw(spriteBatch);
            loadTrophyPackBttn.Draw(spriteBatch);
            exportTrophyPackBttn.Draw(spriteBatch);
            uploadTrophyPackBttn.Draw(spriteBatch);
            scrollUpBttn.Draw(spriteBatch);
            scrollDownBttn.Draw(spriteBatch);
            addGameImageBttn.Draw(spriteBatch);
            trophyNameField.Draw(spriteBatch);
            trophyDescriptionField.Draw(spriteBatch);
            hiddenCheckbox.Draw(spriteBatch);
            gameIDField.Draw(spriteBatch);
            gameNameField.Draw(spriteBatch);
            gamePasswordField.Draw(spriteBatch);
            rumAndCokeButton.Draw(spriteBatch);
            pinaColadaButton.Draw(spriteBatch);
            mojitoButton.Draw(spriteBatch);
            vitaIslandIceTeaButton.Draw(spriteBatch);
            addTrophyButton.Draw(spriteBatch);
            addTrophyImageButton.Draw(spriteBatch);
            deleteTrophyButton.Draw(spriteBatch);

            if(listOfTrophyItems[trophySelected].fileDirectory != String.Empty && trophyImageTexture != null)
            {
                if(trophyImageTexture.Width < 48 || trophyImageTexture.Height < 48 || trophyImageTexture.Width > 48 || trophyImageTexture.Height > 48)
                {
                    string textToDisplay = "Your image needs to be exactly 48x48 pixels.";
                    spriteBatch.DrawString(font, textToDisplay, new Vector2(850, 540), Color.Red, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
                }
                else
                {
                    spriteBatch.Draw(trophyImageTexture,new Vector2(926,503),Color.White);
                }
            }

            if(gameImageDirectory != String.Empty && gameImage != null)
            {
                
                spriteBatch.Draw(gameImage, new Vector2(1095, 503), Color.White);
            }

            // Bounding Box around Trophy Pack Score
            spriteBatch.DrawString(font, "Trophy Pack Score", new Vector2(697, 450), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
            float stringLength = font2.MeasureString(currentTotalScore.ToString() + "/" + scoreLimit.ToString()).X;
            spriteBatch.DrawString(font2, currentTotalScore.ToString() + "/" + scoreLimit.ToString(), new Vector2(765 - (stringLength/2), 510), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
            spriteBatch.Draw(uiElements, new Vector2(690, 475), new Rectangle(252, 216, 100, 2), Color.White, 0f, new Vector2(0, 0), new Vector2(1.5f, 1), SpriteEffects.None, bttnLevel);
            spriteBatch.Draw(uiElements, new Vector2(690, 575), new Rectangle(252, 216, 100, 2), Color.White, 0f, new Vector2(0, 0), new Vector2(1.5f, 1), SpriteEffects.None, bttnLevel);
            spriteBatch.Draw(uiElements, new Vector2(690, 475), new Rectangle(252, 216, 2, 100), Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1f), SpriteEffects.None, bttnLevel);
            spriteBatch.Draw(uiElements, new Vector2(840, 475), new Rectangle(252, 216, 2, 100), Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1f), SpriteEffects.None, bttnLevel);

            // Bounding Box around trophy image
            spriteBatch.DrawString(font, "Trophy Image", new Vector2(902, 450), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
            spriteBatch.Draw(uiElements, new Vector2(900, 475), new Rectangle(252, 216, 100, 100), Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, bttnLevel);


            // Bounding Box around Game Image
            spriteBatch.DrawString(font, "Game Image", new Vector2(1125, 450), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
            spriteBatch.Draw(uiElements, new Vector2(1070, 475), new Rectangle(252, 216, 100, 2), Color.White, 0f, new Vector2(0, 0), new Vector2(2, 1), SpriteEffects.None, bttnLevel);
            spriteBatch.Draw(uiElements, new Vector2(1070, 625), new Rectangle(252, 216, 100, 2), Color.White, 0f, new Vector2(0, 0), new Vector2(2, 1), SpriteEffects.None, bttnLevel);
            spriteBatch.Draw(uiElements, new Vector2(1070, 475), new Rectangle(252, 216, 2, 100), Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1.5f), SpriteEffects.None, bttnLevel);
            spriteBatch.Draw(uiElements, new Vector2(1270, 475), new Rectangle(252, 216, 2, 100), Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1.5f), SpriteEffects.None, bttnLevel);
            //Trophy Level Text
            spriteBatch.DrawString(font, "Trophy Level (Select One)", new Vector2(440, 275), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);


            // Under top row of buttons rule
            spriteBatch.Draw(uiElements, new Vector2(0, 48), new Rectangle(0, 380, 190, 4), Color.White, 0f, new Vector2(0, 0), new Vector2(8, 1), SpriteEffects.None, bttnLevel);

            // Lower Horizontal Rule
            spriteBatch.Draw(uiElements, new Vector2(0, 660), new Rectangle(0, 380, 190, 4), Color.White, 0f, new Vector2(0, 0), new Vector2(8, 1), SpriteEffects.None, bttnLevel);

            // Vertical Rule
            spriteBatch.Draw(uiElements, new Vector2(430, 52), new Rectangle(208, 318, 4, 100), Color.White, 0f, new Vector2(0, 0), new Vector2(1, 6.1f), SpriteEffects.None, bttnLevel);


            // Game Name
            spriteBatch.DrawString(font, gameName, new Vector2(10, 695), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
            spriteBatch.Draw(uiElements, new Vector2(120, 710), new Rectangle(0, 380, 100, 4), Color.White, 0f, new Vector2(0, 0), new Vector2(4, 1), SpriteEffects.None, bttnLevel);


            // Game ID
            spriteBatch.DrawString(font, gameIDString, new Vector2(610, 695), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
            spriteBatch.Draw(uiElements, new Vector2(685, 710), new Rectangle(0, 380, 100, 4), Color.White, 0f, new Vector2(0, 0), new Vector2(1.5f, 1), SpriteEffects.None, bttnLevel);


            // Game Password

            spriteBatch.DrawString(font, passwordString, new Vector2(925, 695), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);
            spriteBatch.Draw(uiElements, new Vector2(1010, 710), new Rectangle(0, 380, 100, 4), Color.White, 0f, new Vector2(0, 0), new Vector2(2.3f, 1), SpriteEffects.None, bttnLevel);


            // List of Trophies
            for(int i = 0; i < listOfTrophiesList.Count(); i++)
            {
                listOfTrophiesList[i].Draw(spriteBatch);
            }

            // Trophy Number
            spriteBatch.DrawString(font, "Trophy # " + trophySelected, new Vector2(1165, 15), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, bttnTestLevel);

            // Message Pop-Up Draw
            messagePopUp.Draw(spriteBatch);

        }

        public static void RecalculateTotalTrophyScore()
        {
            currentTotalScore = 0;
            for(int i = 0; i < listOfTrophyItems.Count; i++)
            {
                switch(listOfTrophyItems[i].trophyLevel)
                {

                    case 1:
                        currentTotalScore += 5;
                     break;

                    case 2:
                        currentTotalScore += 10;
                        break;

                    case 3:
                        currentTotalScore += 20;
                        break;

                    case 4:
                        currentTotalScore += 50;
                        break;

                }
            }
        }

        public static void NewTrophyPack()
        {
            Console.WriteLine("New Trophy Pack");
            listOfTrophyItems.Clear();
            listOfTrophyItems.Add(new TrophyItem());
            trophyListPosition = 0;
            trophySelected = 0;
            gameNameInput = "";
            gameIDInput = "";
            passwordInput = "";
            isLocked = false;
            gameIDField.fieldText = "";
            gamePasswordField.fieldText = "";
            gameNameField.fieldText = "";
            trophyNameField.fieldText = "";
            trophyDescriptionField.fieldText = "";
            gameImageDirectory = "";
            saveFileDirectory = "";
            RecalculateTotalTrophyScore();

        }


        public void Update()
        {
            if (gameObject.IsActive == true)
            {
                Mouse.SetCursor(MouseCursor.Arrow);
                newTrophyPackBttn.Update();
                saveTrophyPackBttn.Update();
                loadTrophyPackBttn.Update();
                exportTrophyPackBttn.Update();
                uploadTrophyPackBttn.Update();
                scrollUpBttn.Update();
                scrollDownBttn.Update();
                addGameImageBttn.Update();
                trophyNameField.Update();
                trophyDescriptionField.Update();
                hiddenCheckbox.Update();
                gameIDField.Update();
                gameNameField.Update();
                gamePasswordField.Update();
                rumAndCokeButton.Update();
                pinaColadaButton.Update();
                mojitoButton.Update();
                vitaIslandIceTeaButton.Update();
                addTrophyButton.Update();
                addTrophyImageButton.Update();
                deleteTrophyButton.Update();
                messagePopUp.Update();
                // List of Trophies
                for (int i = 0; i < listOfTrophiesList.Count(); i++)
                {
                    listOfTrophiesList[i].Update();
                }
            }

        }
    }

    
}
