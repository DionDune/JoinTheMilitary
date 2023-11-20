using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Diagnostics;

namespace JoinTheMilitary
{
    public class Game1 : Game
    {
        #region Variable Defenition

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Storing all created Pages
        List<UIPage> UIPages;
        // Saving currently selected Page
        UIPage UIPage_Current;

        // Saving previous user inputs
        List<Keys> Keys_BeingPressed = new List<Keys>();
        bool Mouse_IsClickingLeft;

        // Used for rendering as a default Colour
        Texture2D Color_White;

        #endregion

        #region Initialization

        public Game1()
        {
            //Chaging the default size of the window
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1800;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            UIPages = UIPage.GeneratePages(_graphics);
            UIPage_Current = UIPages[0];

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Procedurally Creating and Assigning a 1x1 white texture to Color_White
            Color_White = new Texture2D(GraphicsDevice, 1, 1);
            Color_White.SetData(new Color[1] { Color.White });
        }

        #endregion

        /////////////////////////////////////////

        #region UI Rendering/Interaction

        private void UI_RenderTextElements(List<List<bool>> Elements, int CentreX, int CentreY, int elementSize, Color elementColor)
        {
            int StartX = CentreX - ((Elements[0].Count * elementSize) / 2);
            int StartY = CentreY - ((Elements.Count * elementSize) / 2);

            // The value of y determins how far down the Y axis an element is rendered
            for (int y = 0; y < Elements.Count; y++)
            {
                // The value of x determins how far along the X axis an element is rendered
                for (int x = 0; x < Elements[0].Count; x++)
                {
                    //Checking if the a Pixel should be rendered
                    if (Elements[y][x])
                    {
                        //Rendering a square at the position based on x,y, with its given elementSize and elementColor
                        _spriteBatch.Draw(Color_White, new Rectangle(StartX + (x * elementSize), StartY + (y * elementSize), elementSize, elementSize), elementColor);
                    }
                }
            }
        }
        private void UI_RenderOutline(Color color, int X, int Y, int Width, int Height, int BorderWidth, float BorderTransparency)
        {
            _spriteBatch.Draw(Color_White, new Rectangle(X, Y, Width, BorderWidth), color * BorderTransparency);
            _spriteBatch.Draw(Color_White, new Rectangle(X + Width - BorderWidth, Y + BorderWidth, BorderWidth, Height - BorderWidth), color * BorderTransparency);
            _spriteBatch.Draw(Color_White, new Rectangle(X, Y + Height - BorderWidth, Width - BorderWidth, BorderWidth), color * BorderTransparency);
            _spriteBatch.Draw(Color_White, new Rectangle(X, Y + BorderWidth, BorderWidth, Height - (BorderWidth * 2)), color * BorderTransparency);
        }

        private void UI_ChangePage(string PageType)
        {
            foreach (UIPage page in UIPages)
            {
                //If the Page Type matches the given Page Type,
                //the Current Page is updated
                if (page.Type == PageType)
                {
                    UIPage_Current = page;
                }
            }
        }

        #endregion

        #region User Input Handling

        private void UserInput_KeyPressHandler()
        {
            Keys[] Keys_NewlyPressed = Keyboard.GetState().GetPressedKeys();


            // Toggling FullScreen
            if (Keys_NewlyPressed.Contains(Keys.F) && !Keys_BeingPressed.Contains(Keys.F))
            {
                Window_ToggleFullScreen();
            }


            Keys_BeingPressed = new List<Keys>(Keys_NewlyPressed);
        }

        private void UserInput_MouseClickHandler()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                //Checking that the current detected click is a new click,
                //and an error catch, ensuring there is a current page to compare the click to.
                if (!Mouse_IsClickingLeft && UIPage_Current != null)
                {
                    //Checking if any data was received based on the MouseClick
                    List<string> Data = UIPage_Current.GetElementPressData(Mouse.GetState().Position, _graphics);

                    //Checking if any data was received following the MouseClick
                    if (Data != null)
                    {
                        UserControl_ButtonPress(Data);
                    }
                }

                //Updating the Mouse Click bool if a click is detected
                Mouse_IsClickingLeft = true;
            }
            else
            {
                //Reseting the Mouse Click bool if a click is not detected
                Mouse_IsClickingLeft = false;
            }
        }
        private void UserInput_MouseMoveHandler()
        {
            if (UIPage_Current != null)
            {
                UIPage_Current.UpdateHighlightedElements(Mouse.GetState().Position, _graphics);
            }
        }

        private void UserControl_ButtonPress(List<string> Data)
        {
            //Ensures Data is not empty
            if (Data.Count > 0)
            {
                //Initiates a Page Change
                if (Data[0] == "Page Change")
                {
                    UI_ChangePage(Data[1]);
                }
                //Kills the program
                else if (Data[0] == "Quit")
                {
                    System.Environment.Exit(0);
                }
            }
        }

        #endregion

        /////////////////////////////////////////

        #region Fundamental Features

        private void Window_ToggleFullScreen()
        {
            if (!_graphics.IsFullScreen)
            {
                _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
                _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
                _graphics.ApplyChanges();
            }
            else
            {
                _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width / 3 * 2;
                _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height / 3 * 2;
                _graphics.ApplyChanges();
            }

            _graphics.ToggleFullScreen();
        }

        protected override void Update(GameTime gameTime)
        {
            UserInput_KeyPressHandler();
            UserInput_MouseClickHandler();
            UserInput_MouseMoveHandler();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // BEGIN Draw ----
            _spriteBatch.Begin();


            //Looping through each UI Element in the Current Page object
            foreach (UIItem Item in UIPage_Current.UIItems)
            {
                //Getting the reletive position from the Items screen Orientation
                int ScreenCentre_X = _graphics.PreferredBackBufferWidth / 2;
                int ScreenCentre_Y = _graphics.PreferredBackBufferHeight / 2;
                Point OrientationPosition = UIPage.GetOrientationPosition(ScreenCentre_X, ScreenCentre_Y, Item.Orientation, _graphics);

                //Calculating the items true screen position
                int X = OrientationPosition.X + Item.X;
                int Y = OrientationPosition.Y + Item.Y;
                int CentreX = OrientationPosition.X + Item.CentreX;
                int CentreY = OrientationPosition.Y + Item.CentreY;

                if (Item.Type == "Square Shape")
                {
                    UI_RenderOutline(Item.BorderColor, X, Y, Item.Width, Item.Height, Item.BorderWidth, 1F);
                    _spriteBatch.Draw(Color_White, new Rectangle(X + Item.BorderWidth, Y + Item.BorderWidth, Item.Width - Item.BorderWidth * 2, Item.Height - Item.BorderWidth * 2), Item.BaseColor);
                }
                else if (Item.Type == "Text")
                {
                    if (Item.Text != null)
                    {
                        UI_RenderTextElements(Item.Text.Elements, CentreX, CentreY, Item.Text.ElementSize, Item.Text.Color);
                    }
                }
                else if (Item.Type == "Button")
                {
                    _spriteBatch.Draw(Color_White, new Rectangle(X, Y, Item.Width, Item.Height), Item.BorderColor);
                    if (!Item.Highlighted)
                    {
                        _spriteBatch.Draw(Color_White, new Rectangle(X + Item.BorderWidth, Y + Item.BorderWidth,
                                                                   Item.Width - Item.BorderWidth * 2, Item.Height - Item.BorderWidth * 2), Item.BaseColor);
                    }
                    else
                    {
                        _spriteBatch.Draw(Color_White, new Rectangle(X + Item.BorderWidth, Y + Item.BorderWidth,
                                                                   Item.Width - Item.BorderWidth * 2, Item.Height - Item.BorderWidth * 2), Item.HighlightedColor);
                    }

                    if (Item.Text != null)
                    {
                        UI_RenderTextElements(Item.Text.Elements, CentreX, CentreY, Item.Text.ElementSize, Item.Text.Color);
                    }
                }
            }


            _spriteBatch.End();
            // END Draw ------

            base.Draw(gameTime);
        }

        #endregion
    }
}