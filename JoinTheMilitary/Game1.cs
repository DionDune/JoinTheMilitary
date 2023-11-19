using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System;
//using System.Numerics;
using System.Linq;
using System.Diagnostics;

namespace JoinTheMilitary
{
    public class Game1 : Game
    {
        #region Variable Defenition

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        List<UIPage> UIPages;
        UIPage UIPage_Current;

        List<Keys> Keys_BeingPressed = new List<Keys>();
        bool MouseClicking_Left;

        Texture2D Color_White;

        #endregion

        #region Initialize

        public Game1()
        {
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

        #region UI

        private void UI_RenderElements(List<UIItem> UIItems)
        {
            foreach (UIItem Item in UIItems)
            {
                int ScreenCentre_X = _graphics.PreferredBackBufferWidth / 2;
                int ScreenCentre_Y = _graphics.PreferredBackBufferHeight / 2;
                Point OrientationPosition = UIPage.GetOrientationPosition(ScreenCentre_X, ScreenCentre_Y, Item.Orientation, _graphics);

                int X = OrientationPosition.X + Item.X;
                int Y = OrientationPosition.Y + Item.Y;
                int CentreX = OrientationPosition.X + Item.CentreX;
                int CentreY = OrientationPosition.Y + Item.CentreY;


                if (Item.Type == "Square Shape")
                {
                    UI_RenderOutline(Item.BorderColor, X, Y, Item.Width, Item.Height, Item.BorderWidth, Item.BorderTransparency);
                    _spriteBatch.Draw(Color_White, new Rectangle(X + Item.BorderWidth, Y + Item.BorderWidth, Item.Width - Item.BorderWidth * 2, Item.Height - Item.BorderWidth * 2), Item.BaseColor);
                }
                if (Item.Type == "Text")
                {
                    if (Item.Text != null)
                    {
                        UI_RenderTextElements(Item.Text.Elements, CentreX, CentreY, Item.Text.ElementSize, Item.Text.Color);
                    }
                }
                if (Item.Type == "Button")
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
        }
        private void UI_RenderTextElements(List<List<bool>> Elements, int CentreX, int CentreY, int elementSize, Color elementColor)
        {
            int StartX = CentreX - ((Elements[0].Count * elementSize) / 2);
            int StartY = CentreY - ((Elements.Count * elementSize) / 2);

            for (int y = 0; y < Elements.Count; y++)
            {
                for (int x = 0; x < Elements[0].Count; x++)
                {
                    if (Elements[y][x])
                    {
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
                if (!MouseClicking_Left && UIPage_Current != null)
                {
                    List<string> Data = UIPage_Current.GetElementPressData(Mouse.GetState().Position, _graphics);
                    if (Data != null)
                    {
                        UserControl_ButtonPress(Data);
                    }
                }

                MouseClicking_Left = true;
            }
            else
            {
                MouseClicking_Left = false;
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
            if (Data != null)
            {
                if (Data.Count > 0)
                {
                    if (Data[0] == "Page Change")
                    {
                        UI_ChangePage(Data[1]);
                    }
                    else if (Data[0] == "Quit")
                    {
                        System.Environment.Exit(0);
                    }
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


            UI_RenderElements(UIPage_Current.UIItems);


            _spriteBatch.End();
            // END Draw ------

            base.Draw(gameTime);
        }

        #endregion
    }
}