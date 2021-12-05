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
    public class TextField :Button
    {
        public bool isActive = false;
        public string fieldText = "";
        List<Keys> keysPressedLastFrame = new List<Keys>();
        public int cursorPosition;
        public int textLimit = 0;

       

        public TextField()
        {
            cursorPosition = 0;
        }

        public void TextButtonInput()
        {
            EnterText();
            CheckCursorPosition();
            DeleteText();
            ArrowPress();
            GetKeysPressedLastFrame();
            LimitText();
        }

        public void LimitText()
        {
            if(fieldText.Length >textLimit)
            {
                fieldText = fieldText.Substring(0, textLimit);
                cursorPosition = textLimit;
            }
        }

        public void GetKeysPressedLastFrame()
        {
            Keys[] listOfKeys = Keyboard.GetState().GetPressedKeys();
            keysPressedLastFrame.Clear();
            for (int i = 0; i < listOfKeys.Length; i++)
            {
                if(listOfKeys[i] != Keys.LeftShift && listOfKeys[i] != Keys.RightShift)
                {
                    keysPressedLastFrame.Add(listOfKeys[i]);
                }
            }

        }

        public void CheckCursorPosition()
        {
            if(cursorPosition > fieldText.Length)
            {
                cursorPosition = fieldText.Length;
            }
        }

        public void SetCursorPositionClick(int tempX)
        {
            int currentX = tempX;
            int mouseX = Mouse.GetState().Position.X;

            for(int i = 0; i <= fieldText.Length; i++)
            {
                int endOFString = tempX + (int)font.MeasureString(fieldText.Substring(0,i)).X;

                if(mouseX >= currentX && mouseX <= endOFString)
                {
                    int leftDistance = mouseX - currentX;
                    int rightDistance = endOFString - mouseX;

                    if(leftDistance < rightDistance)
                    {
                        cursorPosition = i - 1;
                    }
                    else
                    {
                        cursorPosition = i;
                    }
                    
                    return;
                }
                currentX = endOFString;
            }

            cursorPosition = fieldText.Length;
        }

        public bool CheckAgainstPreviousFrame(Keys tempKey)
        {
            for(int i = 0; i < keysPressedLastFrame.Count; i++)
            {
                if(tempKey == keysPressedLastFrame[i])
                {
                    return false;
                }
            }

            return true;
        }

        public void EnterText()
        {
            if(Keyboard.GetState().CapsLock == true)
            {
                if(Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                {
                    Keys[] listOfKeys = Keyboard.GetState().GetPressedKeys();

                    for (int i = 0; i < listOfKeys.Length; i++)
                    {
                        if (CheckAgainstPreviousFrame(listOfKeys[i]) == true)
                        {
                            switch (listOfKeys[i])
                            {
                                case Keys.A:
                                    fieldText = fieldText.Insert(cursorPosition, "a");
                                    cursorPosition++;
                                    break;
                                case Keys.B:
                                    fieldText = fieldText.Insert(cursorPosition, "b");
                                    cursorPosition++;
                                    break;
                                case Keys.C:
                                    fieldText = fieldText.Insert(cursorPosition, "c");
                                    cursorPosition++;
                                    break;
                                case Keys.D:
                                    fieldText = fieldText.Insert(cursorPosition, "d");
                                    cursorPosition++;
                                    break;
                                case Keys.E:
                                    fieldText = fieldText.Insert(cursorPosition, "e");
                                    cursorPosition++;
                                    break;
                                case Keys.F:
                                    fieldText = fieldText.Insert(cursorPosition, "f");
                                    cursorPosition++;
                                    break;
                                case Keys.G:
                                    fieldText = fieldText.Insert(cursorPosition, "g");
                                    cursorPosition++;
                                    break;
                                case Keys.H:
                                    fieldText = fieldText.Insert(cursorPosition, "h");
                                    cursorPosition++;
                                    break;
                                case Keys.I:
                                    fieldText = fieldText.Insert(cursorPosition, "i");
                                    cursorPosition++;
                                    break;
                                case Keys.J:
                                    fieldText = fieldText.Insert(cursorPosition, "j");
                                    cursorPosition++;
                                    break;
                                case Keys.K:
                                    fieldText = fieldText.Insert(cursorPosition, "k");
                                    cursorPosition++;
                                    break;
                                case Keys.L:
                                    fieldText = fieldText.Insert(cursorPosition, "l");
                                    cursorPosition++;
                                    break;
                                case Keys.M:
                                    fieldText = fieldText.Insert(cursorPosition, "m");
                                    cursorPosition++;
                                    break;
                                case Keys.N:
                                    fieldText = fieldText.Insert(cursorPosition, "n");
                                    cursorPosition++;
                                    break;
                                case Keys.O:
                                    fieldText = fieldText.Insert(cursorPosition, "o");
                                    cursorPosition++;
                                    break;
                                case Keys.P:
                                    fieldText = fieldText.Insert(cursorPosition, "p");
                                    cursorPosition++;
                                    break;
                                case Keys.Q:
                                    fieldText = fieldText.Insert(cursorPosition, "q");
                                    cursorPosition++;
                                    break;
                                case Keys.R:
                                    fieldText = fieldText.Insert(cursorPosition, "r");
                                    cursorPosition++;
                                    break;
                                case Keys.S:
                                    fieldText = fieldText.Insert(cursorPosition, "s");
                                    cursorPosition++;
                                    break;
                                case Keys.T:
                                    fieldText = fieldText.Insert(cursorPosition, "t");
                                    cursorPosition++;
                                    break;
                                case Keys.U:
                                    fieldText = fieldText.Insert(cursorPosition, "u");
                                    cursorPosition++;
                                    break;
                                case Keys.V:
                                    fieldText = fieldText.Insert(cursorPosition, "v");
                                    cursorPosition++;
                                    break;
                                case Keys.W:
                                    fieldText = fieldText.Insert(cursorPosition, "w");
                                    cursorPosition++;
                                    break;
                                case Keys.X:
                                    fieldText = fieldText.Insert(cursorPosition, "x");
                                    cursorPosition++;
                                    break;
                                case Keys.Y:
                                    fieldText = fieldText.Insert(cursorPosition, "y");
                                    cursorPosition++;
                                    break;
                                case Keys.Z:
                                    fieldText = fieldText.Insert(cursorPosition, "z");
                                    cursorPosition++;
                                    break;
                                case Keys.D0:
                                    fieldText = fieldText.Insert(cursorPosition, ")");
                                    cursorPosition++;
                                    break;
                                case Keys.D1:
                                    fieldText = fieldText.Insert(cursorPosition, "!");
                                    cursorPosition++;
                                    break;
                                case Keys.D2:
                                    fieldText = fieldText.Insert(cursorPosition, "@");
                                    cursorPosition++;
                                    break;
                                case Keys.D3:
                                    fieldText = fieldText.Insert(cursorPosition, "#");
                                    cursorPosition++;
                                    break;
                                case Keys.D4:
                                    fieldText = fieldText.Insert(cursorPosition, "$");
                                    cursorPosition++;
                                    break;
                                case Keys.D5:
                                    fieldText = fieldText.Insert(cursorPosition, "%");
                                    cursorPosition++;
                                    break;
                                case Keys.D6:
                                    fieldText = fieldText.Insert(cursorPosition, "^");
                                    cursorPosition++;
                                    break;
                                case Keys.D7:
                                    fieldText = fieldText.Insert(cursorPosition, "&");
                                    cursorPosition++;
                                    break;
                                case Keys.D8:
                                    fieldText = fieldText.Insert(cursorPosition, "*");
                                    cursorPosition++;
                                    break;
                                case Keys.D9:
                                    fieldText = fieldText.Insert(cursorPosition, "(");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad0:
                                    fieldText = fieldText.Insert(cursorPosition, "0");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad1:
                                    fieldText = fieldText.Insert(cursorPosition, "1");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad2:
                                    fieldText = fieldText.Insert(cursorPosition, "2");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad3:
                                    fieldText = fieldText.Insert(cursorPosition, "3");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad4:
                                    fieldText = fieldText.Insert(cursorPosition, "4");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad5:
                                    fieldText = fieldText.Insert(cursorPosition, "5");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad6:
                                    fieldText = fieldText.Insert(cursorPosition, "6");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad7:
                                    fieldText = fieldText.Insert(cursorPosition, "7");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad8:
                                    fieldText = fieldText.Insert(cursorPosition, "8");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad9:
                                    fieldText = fieldText.Insert(cursorPosition, "9");
                                    cursorPosition++;
                                    break;
                                case Keys.OemPeriod:
                                    fieldText = fieldText.Insert(cursorPosition, ".");
                                    cursorPosition++;
                                    break;
                                case Keys.OemComma:
                                    fieldText = fieldText.Insert(cursorPosition, ",");
                                    cursorPosition++;
                                    break;
                                case Keys.OemQuestion:
                                    fieldText = fieldText.Insert(cursorPosition, "?");
                                    cursorPosition++;
                                    break;
                                case Keys.OemQuotes:
                                    fieldText = fieldText.Insert(cursorPosition, "\"");
                                    cursorPosition++;
                                    break;
                                case Keys.OemSemicolon:
                                    fieldText = fieldText.Insert(cursorPosition, ":");
                                    cursorPosition++;
                                    break;
                                case Keys.Space:
                                    fieldText = fieldText.Insert(cursorPosition, " ");
                                    cursorPosition++;
                                    break;
                                
                            }
                        }
                    }
                }
                else
                {
                    Keys[] listOfKeys = Keyboard.GetState().GetPressedKeys();

                    for (int i = 0; i < listOfKeys.Length; i++)
                    {
                        if (CheckAgainstPreviousFrame(listOfKeys[i]) == true)
                        {
                            switch (listOfKeys[i])
                            {
                                case Keys.A:
                                    fieldText = fieldText.Insert(cursorPosition, "A");
                                    cursorPosition++;
                                    break;
                                case Keys.B:
                                    fieldText = fieldText.Insert(cursorPosition, "B");
                                    cursorPosition++;
                                    break;
                                case Keys.C:
                                    fieldText = fieldText.Insert(cursorPosition, "C");
                                    cursorPosition++;
                                    break;
                                case Keys.D:
                                    fieldText = fieldText.Insert(cursorPosition, "D");
                                    cursorPosition++;
                                    break;
                                case Keys.E:
                                    fieldText = fieldText.Insert(cursorPosition, "E");
                                    cursorPosition++;
                                    break;
                                case Keys.F:
                                    fieldText = fieldText.Insert(cursorPosition, "F");
                                    cursorPosition++;
                                    break;
                                case Keys.G:
                                    fieldText = fieldText.Insert(cursorPosition, "G");
                                    cursorPosition++;
                                    break;
                                case Keys.H:
                                    fieldText = fieldText.Insert(cursorPosition, "H");
                                    cursorPosition++;
                                    break;
                                case Keys.I:
                                    fieldText = fieldText.Insert(cursorPosition, "I");
                                    cursorPosition++;
                                    break;
                                case Keys.J:
                                    fieldText = fieldText.Insert(cursorPosition, "J");
                                    cursorPosition++;
                                    break;
                                case Keys.K:
                                    fieldText = fieldText.Insert(cursorPosition, "K");
                                    cursorPosition++;
                                    break;
                                case Keys.L:
                                    fieldText = fieldText.Insert(cursorPosition, "L");
                                    cursorPosition++;
                                    break;
                                case Keys.M:
                                    fieldText = fieldText.Insert(cursorPosition, "M");
                                    cursorPosition++;
                                    break;
                                case Keys.N:
                                    fieldText = fieldText.Insert(cursorPosition, "N");
                                    cursorPosition++;
                                    break;
                                case Keys.O:
                                    fieldText = fieldText.Insert(cursorPosition, "O");
                                    cursorPosition++;
                                    break;
                                case Keys.P:
                                    fieldText = fieldText.Insert(cursorPosition, "P");
                                    cursorPosition++;
                                    break;
                                case Keys.Q:
                                    fieldText = fieldText.Insert(cursorPosition, "Q");
                                    cursorPosition++;
                                    break;
                                case Keys.R:
                                    fieldText = fieldText.Insert(cursorPosition, "R");
                                    cursorPosition++;
                                    break;
                                case Keys.S:
                                    fieldText = fieldText.Insert(cursorPosition, "S");
                                    cursorPosition++;
                                    break;
                                case Keys.T:
                                    fieldText = fieldText.Insert(cursorPosition, "T");
                                    cursorPosition++;
                                    break;
                                case Keys.U:
                                    fieldText = fieldText.Insert(cursorPosition, "U");
                                    cursorPosition++;
                                    break;
                                case Keys.V:
                                    fieldText = fieldText.Insert(cursorPosition, "V");
                                    cursorPosition++;
                                    break;
                                case Keys.W:
                                    fieldText = fieldText.Insert(cursorPosition, "W");
                                    cursorPosition++;
                                    break;
                                case Keys.X:
                                    fieldText = fieldText.Insert(cursorPosition, "X");
                                    cursorPosition++;
                                    break;
                                case Keys.Y:
                                    fieldText = fieldText.Insert(cursorPosition, "Y");
                                    cursorPosition++;
                                    break;
                                case Keys.Z:
                                    fieldText = fieldText.Insert(cursorPosition, "Z");
                                    cursorPosition++;
                                    break;
                                case Keys.D0:
                                    fieldText = fieldText.Insert(cursorPosition, "0");
                                    cursorPosition++;
                                    break;
                                case Keys.D1:
                                    fieldText = fieldText.Insert(cursorPosition, "1");
                                    cursorPosition++;
                                    break;
                                case Keys.D2:
                                    fieldText = fieldText.Insert(cursorPosition, "2");
                                    cursorPosition++;
                                    break;
                                case Keys.D3:
                                    fieldText = fieldText.Insert(cursorPosition, "3");
                                    cursorPosition++;
                                    break;
                                case Keys.D4:
                                    fieldText = fieldText.Insert(cursorPosition, "4");
                                    cursorPosition++;
                                    break;
                                case Keys.D5:
                                    fieldText = fieldText.Insert(cursorPosition, "5");
                                    cursorPosition++;
                                    break;
                                case Keys.D6:
                                    fieldText = fieldText.Insert(cursorPosition, "6");
                                    cursorPosition++;
                                    break;
                                case Keys.D7:
                                    fieldText = fieldText.Insert(cursorPosition, "7");
                                    cursorPosition++;
                                    break;
                                case Keys.D8:
                                    fieldText = fieldText.Insert(cursorPosition, "8");
                                    cursorPosition++;
                                    break;
                                case Keys.D9:
                                    fieldText = fieldText.Insert(cursorPosition, "9");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad0:
                                    fieldText = fieldText.Insert(cursorPosition, "0");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad1:
                                    fieldText = fieldText.Insert(cursorPosition, "1");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad2:
                                    fieldText = fieldText.Insert(cursorPosition, "2");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad3:
                                    fieldText = fieldText.Insert(cursorPosition, "3");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad4:
                                    fieldText = fieldText.Insert(cursorPosition, "4");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad5:
                                    fieldText = fieldText.Insert(cursorPosition, "5");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad6:
                                    fieldText = fieldText.Insert(cursorPosition, "6");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad7:
                                    fieldText = fieldText.Insert(cursorPosition, "7");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad8:
                                    fieldText = fieldText.Insert(cursorPosition, "8");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad9:
                                    fieldText = fieldText.Insert(cursorPosition, "9");
                                    cursorPosition++;
                                    break;
                                case Keys.OemPeriod:
                                    fieldText = fieldText.Insert(cursorPosition, ".");
                                    cursorPosition++;
                                    break;
                                case Keys.OemComma:
                                    fieldText = fieldText.Insert(cursorPosition, ",");
                                    cursorPosition++;
                                    break;
                                case Keys.OemQuestion:
                                    fieldText = fieldText.Insert(cursorPosition, "?");
                                    cursorPosition++;
                                    break;
                                case Keys.OemQuotes:
                                    fieldText = fieldText.Insert(cursorPosition, "'");
                                    cursorPosition++;
                                    break;
                                case Keys.OemSemicolon:
                                    fieldText = fieldText.Insert(cursorPosition, ";");
                                    cursorPosition++;
                                    break;
                                case Keys.Space:
                                    fieldText = fieldText.Insert(cursorPosition, " ");
                                    cursorPosition++;
                                    break;

                            }
                        }
                    }
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                {
                    Keys[] listOfKeys = Keyboard.GetState().GetPressedKeys();

                    for (int i = 0; i < listOfKeys.Length; i++)
                    {
                        if (CheckAgainstPreviousFrame(listOfKeys[i]) == true)
                        {
                            switch (listOfKeys[i])
                            {

                                case Keys.A:
                                    fieldText = fieldText.Insert(cursorPosition, "A");
                                    cursorPosition++;
                                    break;
                                case Keys.B:
                                    fieldText = fieldText.Insert(cursorPosition, "B");
                                    cursorPosition++;
                                    break;
                                case Keys.C:
                                    fieldText = fieldText.Insert(cursorPosition, "C");
                                    cursorPosition++;
                                    break;
                                case Keys.D:
                                    fieldText = fieldText.Insert(cursorPosition, "D");
                                    cursorPosition++;
                                    break;
                                case Keys.E:
                                    fieldText = fieldText.Insert(cursorPosition, "E");
                                    cursorPosition++;
                                    break;
                                case Keys.F:
                                    fieldText = fieldText.Insert(cursorPosition, "F");
                                    cursorPosition++;
                                    break;
                                case Keys.G:
                                    fieldText = fieldText.Insert(cursorPosition, "G");
                                    cursorPosition++;
                                    break;
                                case Keys.H:
                                    fieldText = fieldText.Insert(cursorPosition, "H");
                                    cursorPosition++;
                                    break;
                                case Keys.I:
                                    fieldText = fieldText.Insert(cursorPosition, "I");
                                    cursorPosition++;
                                    break;
                                case Keys.J:
                                    fieldText = fieldText.Insert(cursorPosition, "J");
                                    cursorPosition++;
                                    break;
                                case Keys.K:
                                    fieldText = fieldText.Insert(cursorPosition, "K");
                                    cursorPosition++;
                                    break;
                                case Keys.L:
                                    fieldText = fieldText.Insert(cursorPosition, "L");
                                    cursorPosition++;
                                    break;
                                case Keys.M:
                                    fieldText = fieldText.Insert(cursorPosition, "M");
                                    cursorPosition++;
                                    break;
                                case Keys.N:
                                    fieldText = fieldText.Insert(cursorPosition, "N");
                                    cursorPosition++;
                                    break;
                                case Keys.O:
                                    fieldText = fieldText.Insert(cursorPosition, "O");
                                    cursorPosition++;
                                    break;
                                case Keys.P:
                                    fieldText = fieldText.Insert(cursorPosition, "P");
                                    cursorPosition++;
                                    break;
                                case Keys.Q:
                                    fieldText = fieldText.Insert(cursorPosition, "Q");
                                    cursorPosition++;
                                    break;
                                case Keys.R:
                                    fieldText = fieldText.Insert(cursorPosition, "R");
                                    cursorPosition++;
                                    break;
                                case Keys.S:
                                    fieldText = fieldText.Insert(cursorPosition, "S");
                                    cursorPosition++;
                                    break;
                                case Keys.T:
                                    fieldText = fieldText.Insert(cursorPosition, "T");
                                    cursorPosition++;
                                    break;
                                case Keys.U:
                                    fieldText = fieldText.Insert(cursorPosition, "U");
                                    cursorPosition++;
                                    break;
                                case Keys.V:
                                    fieldText = fieldText.Insert(cursorPosition, "V");
                                    cursorPosition++;
                                    break;
                                case Keys.W:
                                    fieldText = fieldText.Insert(cursorPosition, "W");
                                    cursorPosition++;
                                    break;
                                case Keys.X:
                                    fieldText = fieldText.Insert(cursorPosition, "X");
                                    cursorPosition++;
                                    break;
                                case Keys.Y:
                                    fieldText = fieldText.Insert(cursorPosition, "Y");
                                    cursorPosition++;
                                    break;
                                case Keys.Z:
                                    fieldText = fieldText.Insert(cursorPosition, "Z");
                                    cursorPosition++;
                                    break;
                                case Keys.D0:
                                    fieldText = fieldText.Insert(cursorPosition, ")");
                                    cursorPosition++;
                                    break;
                                case Keys.D1:
                                    fieldText = fieldText.Insert(cursorPosition, "!");
                                    cursorPosition++;
                                    break;
                                case Keys.D2:
                                    fieldText = fieldText.Insert(cursorPosition, "@");
                                    cursorPosition++;
                                    break;
                                case Keys.D3:
                                    fieldText = fieldText.Insert(cursorPosition, "#");
                                    cursorPosition++;
                                    break;
                                case Keys.D4:
                                    fieldText = fieldText.Insert(cursorPosition, "$");
                                    cursorPosition++;
                                    break;
                                case Keys.D5:
                                    fieldText = fieldText.Insert(cursorPosition, "%");
                                    cursorPosition++;
                                    break;
                                case Keys.D6:
                                    fieldText = fieldText.Insert(cursorPosition, "^");
                                    cursorPosition++;
                                    break;
                                case Keys.D7:
                                    fieldText = fieldText.Insert(cursorPosition, "&");
                                    cursorPosition++;
                                    break;
                                case Keys.D8:
                                    fieldText = fieldText.Insert(cursorPosition, "*");
                                    cursorPosition++;
                                    break;
                                case Keys.D9:
                                    fieldText = fieldText.Insert(cursorPosition, "(");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad0:
                                    fieldText = fieldText.Insert(cursorPosition, "0");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad1:
                                    fieldText = fieldText.Insert(cursorPosition, "1");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad2:
                                    fieldText = fieldText.Insert(cursorPosition, "2");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad3:
                                    fieldText = fieldText.Insert(cursorPosition, "3");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad4:
                                    fieldText = fieldText.Insert(cursorPosition, "4");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad5:
                                    fieldText = fieldText.Insert(cursorPosition, "5");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad6:
                                    fieldText = fieldText.Insert(cursorPosition, "6");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad7:
                                    fieldText = fieldText.Insert(cursorPosition, "7");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad8:
                                    fieldText = fieldText.Insert(cursorPosition, "8");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad9:
                                    fieldText = fieldText.Insert(cursorPosition, "9");
                                    cursorPosition++;
                                    break;
                                case Keys.OemPeriod:
                                    fieldText = fieldText.Insert(cursorPosition, ".");
                                    cursorPosition++;
                                    break;
                                case Keys.OemComma:
                                    fieldText = fieldText.Insert(cursorPosition, ",");
                                    cursorPosition++;
                                    break;
                                case Keys.OemQuestion:
                                    fieldText = fieldText.Insert(cursorPosition, "?");
                                    cursorPosition++;
                                    break;
                                case Keys.OemQuotes:
                                    fieldText = fieldText.Insert(cursorPosition, "\"");
                                    cursorPosition++;
                                    break;
                                case Keys.OemSemicolon:
                                    fieldText = fieldText.Insert(cursorPosition, ":");
                                    cursorPosition++;
                                    break;
                                case Keys.Space:
                                    fieldText = fieldText.Insert(cursorPosition, " ");
                                    cursorPosition++;
                                    break;
                            }
                        }
                    }
                }


                else
                {
                    Keys[] listOfKeys = Keyboard.GetState().GetPressedKeys();

                    for (int i = 0; i < listOfKeys.Length; i++)
                    {
                        if (CheckAgainstPreviousFrame(listOfKeys[i]) == true)
                        {
                            switch (listOfKeys[i])
                            {
                                case Keys.A:
                                   fieldText = fieldText.Insert(cursorPosition, "a");
                                    cursorPosition++;
                                    break;
                                case Keys.B:
                                    fieldText = fieldText.Insert(cursorPosition, "b");
                                    cursorPosition++;
                                    break;
                                case Keys.C:
                                    fieldText = fieldText.Insert(cursorPosition, "c");
                                    cursorPosition++;
                                    break;
                                case Keys.D:
                                    fieldText = fieldText.Insert(cursorPosition, "d");
                                    cursorPosition++;
                                    break;
                                case Keys.E:
                                    fieldText = fieldText.Insert(cursorPosition, "e");
                                    cursorPosition++;
                                    break;
                                case Keys.F:
                                    fieldText = fieldText.Insert(cursorPosition, "f");
                                    cursorPosition++;
                                    break;
                                case Keys.G:
                                    fieldText = fieldText.Insert(cursorPosition, "g");
                                    cursorPosition++;
                                    break;
                                case Keys.H:
                                    fieldText = fieldText.Insert(cursorPosition, "h");
                                    cursorPosition++;
                                    break;
                                case Keys.I:
                                    fieldText = fieldText.Insert(cursorPosition, "i");
                                    cursorPosition++;
                                    break;
                                case Keys.J:
                                    fieldText = fieldText.Insert(cursorPosition, "j");
                                    cursorPosition++;
                                    break;
                                case Keys.K:
                                    fieldText = fieldText.Insert(cursorPosition, "k");
                                    cursorPosition++;
                                    break;
                                case Keys.L:
                                    fieldText = fieldText.Insert(cursorPosition, "l");
                                    cursorPosition++;
                                    break;
                                case Keys.M:
                                    fieldText = fieldText.Insert(cursorPosition, "m");
                                    cursorPosition++;
                                    break;
                                case Keys.N:
                                    fieldText = fieldText.Insert(cursorPosition, "n");
                                    cursorPosition++;
                                    break;
                                case Keys.O:
                                    fieldText = fieldText.Insert(cursorPosition, "o");
                                    cursorPosition++;
                                    break;
                                case Keys.P:
                                    fieldText = fieldText.Insert(cursorPosition, "p");
                                    cursorPosition++;
                                    break;
                                case Keys.Q:
                                    fieldText = fieldText.Insert(cursorPosition, "q");
                                    cursorPosition++;
                                    break;
                                case Keys.R:
                                    fieldText = fieldText.Insert(cursorPosition, "r");
                                    cursorPosition++;
                                    break;
                                case Keys.S:
                                    fieldText = fieldText.Insert(cursorPosition, "s");
                                    cursorPosition++;
                                    break;
                                case Keys.T:
                                    fieldText = fieldText.Insert(cursorPosition, "t");
                                    cursorPosition++;
                                    break;
                                case Keys.U:
                                    fieldText = fieldText.Insert(cursorPosition, "u");
                                    cursorPosition++;
                                    break;
                                case Keys.V:
                                    fieldText = fieldText.Insert(cursorPosition, "v");
                                    cursorPosition++;
                                    break;
                                case Keys.W:
                                    fieldText = fieldText.Insert(cursorPosition, "w");
                                    cursorPosition++;
                                    break;
                                case Keys.X:
                                    fieldText = fieldText.Insert(cursorPosition, "x");
                                    cursorPosition++;
                                    break;
                                case Keys.Y:
                                    fieldText = fieldText.Insert(cursorPosition, "y");
                                    cursorPosition++;
                                    break;
                                case Keys.Z:
                                    fieldText = fieldText.Insert(cursorPosition, "z");
                                    cursorPosition++;
                                    break;
                                case Keys.D0:
                                    fieldText = fieldText.Insert(cursorPosition, "0");
                                    cursorPosition++;
                                    break;
                                case Keys.D1:
                                    fieldText = fieldText.Insert(cursorPosition, "1");
                                    cursorPosition++;
                                    break;
                                case Keys.D2:
                                    fieldText = fieldText.Insert(cursorPosition, "2");
                                    cursorPosition++;
                                    break;
                                case Keys.D3:
                                    fieldText = fieldText.Insert(cursorPosition, "3");
                                    cursorPosition++;
                                    break;
                                case Keys.D4:
                                    fieldText = fieldText.Insert(cursorPosition, "4");
                                    cursorPosition++;
                                    break;
                                case Keys.D5:
                                    fieldText = fieldText.Insert(cursorPosition, "5");
                                    cursorPosition++;
                                    break;
                                case Keys.D6:
                                    fieldText = fieldText.Insert(cursorPosition, "6");
                                    cursorPosition++;
                                    break;
                                case Keys.D7:
                                    fieldText = fieldText.Insert(cursorPosition, "7");
                                    cursorPosition++;

                                    break;
                                case Keys.D8:
                                    fieldText = fieldText.Insert(cursorPosition, "8");
                                    cursorPosition++;
                                    break;
                                case Keys.D9:
                                    fieldText = fieldText.Insert(cursorPosition, "9");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad0:
                                    fieldText = fieldText.Insert(cursorPosition, "0");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad1:
                                    fieldText = fieldText.Insert(cursorPosition, "1");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad2:
                                    fieldText = fieldText.Insert(cursorPosition, "2");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad3:
                                    fieldText = fieldText.Insert(cursorPosition, "3");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad4:
                                    fieldText = fieldText.Insert(cursorPosition, "4");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad5:
                                    fieldText = fieldText.Insert(cursorPosition, "5");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad6:
                                    fieldText = fieldText.Insert(cursorPosition, "6");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad7:
                                    fieldText = fieldText.Insert(cursorPosition, "7");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad8:
                                    fieldText = fieldText.Insert(cursorPosition, "8");
                                    cursorPosition++;
                                    break;
                                case Keys.NumPad9:
                                    fieldText = fieldText.Insert(cursorPosition, "9");
                                    cursorPosition++;
                                    break;
                                case Keys.OemPeriod:
                                    fieldText = fieldText.Insert(cursorPosition, ".");
                                    cursorPosition++;
                                    break;
                                case Keys.OemComma:
                                    fieldText = fieldText.Insert(cursorPosition, ",");
                                    cursorPosition++;
                                    break;
                                case Keys.OemQuestion:
                                    fieldText = fieldText.Insert(cursorPosition, "?");
                                    cursorPosition++;
                                    break;
                                case Keys.OemQuotes:
                                    fieldText = fieldText.Insert(cursorPosition, "'");
                                    cursorPosition++;
                                    break;
                                case Keys.OemSemicolon:
                                    fieldText = fieldText.Insert(cursorPosition, ";");
                                    cursorPosition++;
                                    break;
                                case Keys.Space:
                                    fieldText = fieldText.Insert(cursorPosition, " ");
                                    cursorPosition++;
                                    break;
                            }
                        }
                    }
                }
            }
        }



        public void DeleteText()
        {
            Keys[] listOfKeys = Keyboard.GetState().GetPressedKeys();

            for (int i = 0; i < listOfKeys.Length; i++)
            {
                if (CheckAgainstPreviousFrame(listOfKeys[i]) == true)
                {
                    switch (listOfKeys[i])
                    {
                        case Keys.Back:
                            if(cursorPosition > 0)
                            {
                                fieldText = fieldText.Remove(cursorPosition - 1, 1);
                                cursorPosition--;
                            }
                            break;

                        case Keys.Delete:
                            if(cursorPosition < fieldText.Length)
                            {
                               fieldText =  fieldText.Remove(cursorPosition, 1);
                            }
                            break;
                    }
                }
            }
        }

        public void ArrowPress()
        {
            Keys[] listOfKeys = Keyboard.GetState().GetPressedKeys();

            for (int i = 0; i < listOfKeys.Length; i++)
            {
                if (CheckAgainstPreviousFrame(listOfKeys[i]) == true)
                {
                    switch (listOfKeys[i])
                    {
                        case Keys.Left:
                            cursorPosition--;
                            if(cursorPosition < 0)
                            {
                                cursorPosition = 0;
                            }
                            break;

                        case Keys.Right:
                            cursorPosition++;
                            if(cursorPosition > fieldText.Length)
                            {
                                cursorPosition = fieldText.Length;
                            }
                            break;
                    }
                }
            }
        }


        

    }
}
