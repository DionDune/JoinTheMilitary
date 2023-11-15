﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System;
using System.Numerics;
using System.Linq;
using System.Diagnostics;

namespace JoinTheMilitary
{
    public class Game1 : Game
    {
        #region Variable Defenition

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        string GameState;
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
            UI_GenPages();
            GameState = "Start";
            UIPage_Current = UIPages[0];

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Color_White = Content.Load<Texture2D>("Colour_White");
        }

        #endregion

        /////////////////////////////////////////

        #region UI

        private void UI_GenPages()
        {
            UIPages = new List<UIPage>();

            //Universal Quit Button
            UIItem UniQuit = new UIItem()
            {
                Type = "Button",

                Orientation = "Top Left",

                X = 15,
                Y = 15,

                Width = 50,
                Height = 20,

                CentreX = 15 + (50 / 2),
                CentreY = 15 + (20 / 2),

                BorderWidth = 2,
                BorderColor = Color.DarkRed,
                BaseColor = Color.Red,

                Text = new TextElement()
                {
                    Text = "QUIT",
                    Elements = TextCharacter.GetString("QUIT"),
                    ElementSize = 3,
                    Color = Color.Black
                },

                Data = new List<string>() { "Quit" }
            };

            //Universal Home Button
            UIItem UniHome = new UIItem()
            {
                Type = "Button",

                Orientation = "Top Left",

                X = 15,
                Y = 40,

                Width = 50,
                Height = 20,

                CentreX = 15 + (50 / 2),
                CentreY = 40 + (20 / 2),

                BorderWidth = 2,
                BorderColor = Color.DarkBlue,
                BaseColor = Color.Blue,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("HOME"),
                    ElementSize = 3,
                    Color = Color.White
                },

                Data = new List<string>() { "Info Continue" }
            };

            #region Start Page

            //Enlist Button
            UIItem StartButton = new UIItem()
            {
                Type = "Button",

                X = -200,
                Y = -75,

                Width = 400,
                Height = 150,

                CentreX = -200 + (400 / 2),
                CentreY = -75 + (150 / 2),

                BorderWidth = 5,
                BorderColor = Color.Green,
                BaseColor = Color.PaleGreen,

                Text = new TextElement()
                {
                    Text = "ENLIST",
                    Elements = TextCharacter.GetString("ENLIST"),
                    ElementSize = 8,
                    Color = Color.Black
                },

                Data = new List<string>() { "ENLIST" }
            };
            //Start Quit Button
            UIItem StartQuitButton = new UIItem()
            {
                Type = "Button",

                X = -200,
                Y = -75 + 175,

                Width = 400,
                Height = 150,

                CentreX = -200 + (400 / 2),
                CentreY = 100 + (150 / 2),

                BorderWidth = 5,
                BorderColor = Color.DarkRed,
                BaseColor = Color.Red,

                Text = new TextElement()
                {
                    Text = "QUIT",
                    Elements = TextCharacter.GetString("QUIT"),
                    ElementSize = 8,
                    Color = Color.Black
                },

                Data = new List<string>() { "Quit" }
            };
            //Start Message
            UIItem StartMessage = new UIItem()
            {
                Type = "Text",
                X = 0,
                Y = -200,
                CentreX = 0,
                CentreY = -200,

                Text = new TextElement()
                {
                    Text = "WELCOME TO THE MILITARY!!!",
                    Elements = TextCharacter.GetString("WELCOME TO THE MILITARY!!!"),
                    ElementSize = 12,
                    Color = Color.Black
                },
            };

            //Start Page
            UIPages.Add(new UIPage()
            {
                Type = "Start",

                UIItems = new List<UIItem>() { StartButton, StartQuitButton, StartMessage }
            });

            #endregion

            #region Information Page

            //Information Message
            UIItem InfoMessage1 = new UIItem()
            {
                Type = "Text",

                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = -400,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("OURS IS NOT TO REASON WHY"),
                    ElementSize = 12,
                    Color = Color.Black
                },
            };
            UIItem InfoMessage2 = new UIItem()
            {
                Type = "Text",

                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = -300,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("OURS IS BUT TO DO AND DIE"),
                    ElementSize = 12,
                    Color = Color.Black
                },
            };
            UIItem InfoMessage3 = new UIItem()
            {
                Type = "Text",

                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = -150,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("ARE YOU PREPARED TO DIE FOR YOUR STATE?"),
                    ElementSize = 9,
                    Color = Color.Red
                },
            };

            UIItem InfoContinue = new UIItem()
            {
                Type = "Button",

                X = -200,
                Y = 0,

                Width = 300,
                Height = 100,

                CentreX = -200 + (300 / 2),
                CentreY = 0 + (100 / 2),

                BorderWidth = 5,
                BorderColor = Color.DarkGreen,
                BaseColor = Color.Green,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("YES!"),
                    ElementSize = 8,
                    Color = Color.Black
                },

                Data = new List<string>() { "Info Continue" }
            };
            UIItem InfoQuitButton = new UIItem()
            {
                Type = "Button",

                X = -200,
                Y = 120,

                Width = 300,
                Height = 100,

                CentreX = -200 + (300 / 2),
                CentreY = 120 + (100 / 2),

                BorderWidth = 5,
                BorderColor = Color.DarkRed,
                BaseColor = Color.Red,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("NO"),
                    ElementSize = 8,
                    Color = Color.Black
                },

                Data = new List<string>() { "Quit" }
            };

            //Information Page
            UIPages.Add(new UIPage()
            {
                Type = "Information",

                UIItems = new List<UIItem>() { UniQuit, UniHome, InfoMessage1, InfoMessage2, InfoMessage3, InfoContinue, InfoQuitButton }
            });

            #endregion

            #region Game Select Page

            UIItem GameSelectDivider = new UIItem()
            {
                Type = "Square Shape",

                Orientation = "Top",
                X = -10,
                Y = 0,
                Width = 20,
                Height = _graphics.PreferredBackBufferHeight * 4,

                BorderWidth = 4,
                BorderColor = Color.Black,
                BaseColor = Color.Wheat
            };
            UIItem QuizSelect = new UIItem()
            {
                Type = "Button",

                Orientation = "Top Left",
                X = 250,
                Y = 100,

                Width = 400,
                Height = 100,

                CentreX = 250 + (400 / 2),
                CentreY = 100 + (100 / 2),

                BorderWidth = 5,
                BorderColor = Color.Black,
                BaseColor = Color.Wheat,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("KNOWLEDGE TEST"),
                    ElementSize = 6,
                    Color = Color.Black
                },

                Data = new List<string>() { "Knowledge Test" }
            };
            UIItem WikiSelect = new UIItem()
            {
                Type = "Button",

                Orientation = "Top Right",
                X = -650,
                Y = 100,

                Width = 400,
                Height = 100,

                CentreX = -650 + (400 / 2),
                CentreY = 100 + (100 / 2),

                BorderWidth = 5,
                BorderColor = Color.Black,
                BaseColor = Color.Wheat,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("INFORMATION"),
                    ElementSize = 7,
                    Color = Color.Black
                },

                Data = new List<string>() { "Wiki" }
            };

            UIPages.Add(new UIPage()
            {
                Type = "Game Select",

                UIItems = new List<UIItem>() { UniQuit, UniHome, QuizSelect, WikiSelect, GameSelectDivider }
            });

            #endregion

            #region Wiki Page

            UIItem WikiMessage = new UIItem()
            {
                Type = "Text",

                Orientation = "Top",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 80,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("MILITARY WIKI"),
                    ElementSize = 14,
                    Color = Color.Black
                }
            };
            UIItem WikiWarsFaught = new UIItem()
            {
                Type = "Button",

                Orientation = "Left",
                X = 100,
                Y = -250,
                Width = 570,
                Height = 100,
                CentreX = 100 + (570 / 2),
                CentreY = -250 + (100 / 2),

                BorderWidth = 5,
                BorderColor = Color.Black,
                BaseColor = Color.Wheat,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("NUMBER OF WARS RIGHT NOW"),
                    ElementSize = 5,
                    Color = Color.Black
                },

                Data = new List<string>() { "Wars" }
            };
            UIItem WikiSoldiers = new UIItem()
            {
                Type = "Button",

                Orientation = "Left",
                X = 100,
                Y = 0,
                Width = 570,
                Height = 100,
                CentreX = 100 + (570 / 2),
                CentreY = 0 + (100 / 2),

                BorderWidth = 5,
                BorderColor = Color.Black,
                BaseColor = Color.Wheat,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("NUMBER OF SOLDIERS RIGHT NOW"),
                    ElementSize = 5,
                    Color = Color.Black
                },

                Data = new List<string>() { "Soldiers" }
            };
            UIItem WikiNukes = new UIItem()
            {
                Type = "Button",

                Orientation = "Left",
                X = 100,
                Y = 250,
                Width = 570,
                Height = 100,
                CentreX = 100 + (570 / 2),
                CentreY = 250 + (100 / 2),

                BorderWidth = 5,
                BorderColor = Color.Black,
                BaseColor = Color.Wheat,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("NUMBER OF NUKES RIGHT NOW"),
                    ElementSize = 5,
                    Color = Color.Black
                },

                Data = new List<string>() { "Nukes" }
            };
            UIItem WikiMoneyOnWarGlobal = new UIItem()
            {
                Type = "Button",

                Orientation = "Right",
                X = -650,
                Y = -250,
                Width = 570,
                Height = 100,
                CentreX = -650 + (570 / 2),
                CentreY = -250 + (100 / 2),

                BorderWidth = 5,
                BorderColor = Color.Black,
                BaseColor = Color.Wheat,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("MONEY SPENT ON WAR GLOBALLY"),
                    ElementSize = 5,
                    Color = Color.Black
                },

                Data = new List<string>() { "Money Global" }
            };
            UIItem WikiMoneyOnWarUS = new UIItem()
            {
                Type = "Button",

                Orientation = "Right",
                X = -650,
                Y = 0,
                Width = 570,
                Height = 100,
                CentreX = -650 + (570 / 2),
                CentreY = 0 + (100 / 2),

                BorderWidth = 5,
                BorderColor = Color.Black,
                BaseColor = Color.Wheat,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("MONEY SPENT ON WAR IN THE US"),
                    ElementSize = 5,
                    Color = Color.Black
                },

                Data = new List<string>() { "Money US" }
            };
            UIItem WikiDeathsPerYear = new UIItem()
            {
                Type = "Button",

                Orientation = "Right",
                X = -650,
                Y = 250,
                Width = 570,
                Height = 100,
                CentreX = -650 + (570 / 2),
                CentreY = 250 + (100 / 2),

                BorderWidth = 5,
                BorderColor = Color.Black,
                BaseColor = Color.Wheat,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("CIVILIAN DEATHS THIS CENTURY"),
                    ElementSize = 5,                                        
                    Color = Color.Black
                },

                Data = new List<string>() { "Deaths" }
            };

            UIPages.Add(new UIPage()
            {
                Type = "Wiki",

                UIItems = new List<UIItem>() { UniQuit, UniHome, WikiMessage, WikiWarsFaught, WikiSoldiers, WikiNukes, WikiMoneyOnWarGlobal, WikiMoneyOnWarUS, WikiDeathsPerYear }
            });

            #endregion

            #region Wiki SubPages

            UIItem WikiReturn = new UIItem()
            {
                Type = "Button",

                Orientation = "Top",
                X = -200,
                Y = 50,
                Width = 400,
                Height = 100,
                CentreX = -200 + (400 / 2),
                CentreY = 50 + (100 / 2),

                BorderWidth = 5,
                BorderColor = Color.Black,
                BaseColor = Color.Turquoise,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("RETURN TO WIKI"),
                    ElementSize = 5,
                    Color = Color.White
                },

                Data = new List<string>() { "Wiki" }
            };

            UIItem WarsMessage1 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 0,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("AS OF 13TH OF NOVEMBER 2023"),
                    ElementSize = 10,
                    Color = Color.Black,
                }
            };
            UIItem WarsMessage2 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 100,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("THERE ARE 32 ONGOING WARS"),
                    ElementSize = 12,
                    Color = Color.Black,
                }
            };
            UIPages.Add(new UIPage()
            {
                Type = "Wars",

                UIItems = new List<UIItem>() { UniQuit, UniHome, WikiReturn, WarsMessage1, WarsMessage2 }
            });

            UIItem SoldiersMessage1 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 0,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("AS RECORDED IN 2020"),
                    ElementSize = 10,
                    Color = Color.Black,
                }
            };
            UIItem SoldiersMessage2 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 100,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("THE ARE ROUGHLY  27,406,000  ACTIVE SOLDIERS"),
                    ElementSize = 10,
                    Color = Color.Black,
                }
            };
            UIPages.Add(new UIPage()
            {
                Type = "Soldiers",

                UIItems = new List<UIItem>() { UniQuit, UniHome, WikiReturn, SoldiersMessage1, SoldiersMessage2 }
            });

            UIItem NukesMessage1 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 0,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("AS OF JANUARY 2023"),
                    ElementSize = 10,
                    Color = Color.Black,
                }
            };
            UIItem NukesMessage2 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 100,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("THERE ARE APPROXIMATLY  12,500  NUKES IN EXISTENCE"),
                    ElementSize = 10,
                    Color = Color.Black,
                }
            };
            UIPages.Add(new UIPage()
            {
                Type = "Nukes",

                UIItems = new List<UIItem>() { UniQuit, UniHome, WikiReturn, NukesMessage1, NukesMessage2 }
            });

            UIItem MoneyGlobalMessage1 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 0,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("AS RECORDED IN 2022"),
                    ElementSize = 10,
                    Color = Color.Black,
                }
            };
            UIItem MoneyGlobalMessage2 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 100,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("THE APROXIMATE NUMBER OF US DOLLARS SPENT ON WAR GLOBALLY"),
                    ElementSize = 10,
                    Color = Color.Black,
                }
            };
            UIItem MoneyGlobalMessage3 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 200,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("REACHED  2.24  TRILLION"),
                    ElementSize = 10,
                    Color = Color.Black,
                }
            };
            UIPages.Add(new UIPage()
            {
                Type = "Money Global",

                UIItems = new List<UIItem>() { UniQuit, UniHome, WikiReturn, MoneyGlobalMessage1, MoneyGlobalMessage2, MoneyGlobalMessage3 }
            });

            UIItem MoneyUSMessage1 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 0,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("AS RECORDED IN 2022"),
                    ElementSize = 10,
                    Color = Color.Black,
                }
            };
            UIItem MoneyUSMessage2 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 100,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("THE APROXIMATE NUMBER OF DOLLARS SPENT ON WAR IN THE US"),
                    ElementSize = 10,
                    Color = Color.Black,
                }
            };
            UIItem MoneyUSMessage3 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 200,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("REACHED  844  BILLION"),
                    ElementSize = 10,
                    Color = Color.Black,
                }
            };
            UIPages.Add(new UIPage()
            {
                Type = "Money US",

                UIItems = new List<UIItem>() { UniQuit, UniHome, WikiReturn, MoneyUSMessage1, MoneyUSMessage2, MoneyUSMessage3 }
            });

            UIItem DeathsMessage1 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 0,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("SINCE THE YEAR 2001"),
                    ElementSize = 10,
                    Color = Color.Black,
                }
            };
            UIItem DeathsMessage2 = new UIItem()
            {
                Type = "Text",

                Orientation = "Centre",
                X = 0,
                Y = 0,
                CentreX = 0,
                CentreY = 100,

                Text = new TextElement()
                {
                    Elements = TextCharacter.GetString("ATLEAST  432,000  CIVILIANS HAVE DIED IN WARS"),
                    ElementSize = 10,
                    Color = Color.Black,
                }
            };
            UIPages.Add(new UIPage()
            {
                Type = "Deaths",

                UIItems = new List<UIItem>() { UniQuit, UniHome, WikiReturn, DeathsMessage1, DeathsMessage2 }
            });

            #endregion
        }

        private void UI_RenderElements(List<UIItem> UIItems)
        {
            foreach (UIItem Item in UIItems)
            {
                int OrientatePosX = _graphics.PreferredBackBufferWidth / 2;
                int OrientatePosY = _graphics.PreferredBackBufferHeight / 2;
                switch (Item.Orientation)
                {
                    case "Bottom Left":
                        OrientatePosX = 0;
                        OrientatePosY = _graphics.PreferredBackBufferHeight;
                        break;
                    case "Left":
                        OrientatePosX = 0;
                        break;
                    case "Top Left":
                        OrientatePosX = 0;
                        OrientatePosY = 0;
                        break;
                    case "Top":
                        OrientatePosY = 0;
                        break;
                    case "Top Right":
                        OrientatePosX = _graphics.PreferredBackBufferWidth;
                        OrientatePosY = 0;
                        break;
                    case "Right":
                        OrientatePosX = _graphics.PreferredBackBufferWidth;
                        break;
                    case "Bottom Right":
                        OrientatePosX = _graphics.PreferredBackBufferWidth;
                        OrientatePosY = _graphics.PreferredBackBufferHeight;
                        break;
                    case "Bottom":
                        OrientatePosY = _graphics.PreferredBackBufferHeight;
                        break;
                }

                int X = OrientatePosX + Item.X;
                int Y = OrientatePosY + Item.Y;
                int CentreX = OrientatePosX + Item.CentreX;
                int CentreY = OrientatePosY + Item.CentreY;

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
                if (Item.Type == "Fillbar")
                {
                    //Border
                    UI_RenderOutline(Item.BorderColor, X, Y, Item.Width, Item.Height, Item.BorderWidth, Item.BorderTransparency);
                    //Inner
                    _spriteBatch.Draw(Color_White, new Rectangle(X + Item.BorderWidth, Y + Item.BorderWidth,
                                                                   Item.Width - Item.BorderWidth * 2, Item.Height - Item.BorderWidth * 2),
                                                                   Item.SubBorderColor * Item.SubBorderTransparency);
                    //Bar
                    _spriteBatch.Draw(Color_White, new Rectangle(X + Item.BorderWidth, Y + Item.BorderWidth,
                                                                   (int)((Item.Value - Item.MinValue) / (float)Item.MaxValue * (Item.Width - Item.BorderWidth * 2)),
                                                                   Item.Height - Item.BorderWidth * 2), Item.BaseColor * Item.BaseTransparency);
                }
                if (Item.Type == "Container")
                {
                    //Border
                    UI_RenderOutline(Item.BorderColor, X, Y, Item.Width, Item.Height, Item.BorderWidth, Item.BorderTransparency);
                    //Inner
                    _spriteBatch.Draw(Color_White, new Rectangle(X + Item.BorderWidth, Y + Item.BorderWidth,
                                                                   Item.Width - Item.BorderWidth * 2, Item.Height - Item.BorderWidth * 2),
                                                                   Item.SubBorderColor * Item.SubBorderTransparency);
                    if (Item.uIItems.Count > 0)
                    {
                        foreach (UIItem InnerItem in Item.uIItems)
                        {
                            switch (InnerItem.Orientation)
                            {
                                case "Bottom Left":
                                    OrientatePosX = 0;
                                    OrientatePosY = _graphics.PreferredBackBufferHeight;
                                    break;
                                case "Left":
                                    OrientatePosX = 0;
                                    break;
                                case "Top Left":
                                    OrientatePosX = 0;
                                    OrientatePosY = 0;
                                    break;
                                case "Top":
                                    OrientatePosY = 0;
                                    break;
                                case "Top Right":
                                    OrientatePosX = _graphics.PreferredBackBufferWidth;
                                    OrientatePosY = 0;
                                    break;
                                case "Right":
                                    OrientatePosX = _graphics.PreferredBackBufferWidth;
                                    break;
                                case "Bottom Right":
                                    OrientatePosX = _graphics.PreferredBackBufferWidth;
                                    OrientatePosY = _graphics.PreferredBackBufferHeight;
                                    break;
                                case "Bottom":
                                    OrientatePosY = _graphics.PreferredBackBufferHeight;
                                    break;
                            }
                            X = OrientatePosX + InnerItem.X;
                            Y = OrientatePosY + InnerItem.Y;
                            CentreX = OrientatePosX + InnerItem.CentreX;
                            CentreY = OrientatePosY + InnerItem.CentreY;

                            if (InnerItem.Type == "Container Slot")
                            {
                                float BorderTransparency = InnerItem.BorderTransparency;
                                float SubBorderTransparency = InnerItem.SubBorderTransparency;
                                Color BorderColor = InnerItem.BorderColor;
                                Color SubBorderColor = InnerItem.SubBorderColor;
                                if (InnerItem.Highlighted)
                                {
                                    BorderTransparency = InnerItem.BorderHighlightedTransparency;
                                    SubBorderTransparency = InnerItem.SubBorderHighlightedTransparency;
                                    BorderColor = InnerItem.HighlightedBorderColor;
                                    SubBorderColor = InnerItem.HighlightedColor;
                                }


                                //Border
                                UI_RenderOutline(BorderColor, X, Y, InnerItem.Width, InnerItem.Height, InnerItem.BorderWidth, BorderTransparency);
                                //Inner
                                _spriteBatch.Draw(Color_White, new Rectangle(X + InnerItem.BorderWidth, Y + InnerItem.BorderWidth,
                                                                               InnerItem.Width - InnerItem.BorderWidth * 2, InnerItem.Height - InnerItem.BorderWidth * 2),
                                                                               SubBorderColor * SubBorderTransparency);
                            }
                        }
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
            GameState = PageType;

            if (UIPage_Current != null)
            {
                foreach (UIPage page in UIPages)
                {
                    if (page.Type == GameState)
                    {
                        UIPage_Current = page;
                    }
                    else
                    {
                        Debug.WriteLine(page.Type);
                        Debug.WriteLine(PageType);
                        Debug.WriteLine("\n");
                    }
                }
            }
        }

        #endregion

        #region Keybinds

        private void KeyBind_Handler()
        {
            Keys[] Keys_NewlyPressed = Keyboard.GetState().GetPressedKeys();


            //Toggle Pause
            if (Keys_NewlyPressed.Contains(Keys.Escape) && !Keys_BeingPressed.Contains(Keys.Escape))
            {
                UserControl_TogglePause();
            }

            // Toggling FullScreen
            if (Keys_NewlyPressed.Contains(Keys.F) && !Keys_BeingPressed.Contains(Keys.F))
            {
                Window_ToggleFullScreen();
            }

            Keys_BeingPressed = new List<Keys>(Keys_NewlyPressed);
        }

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
        private void UserControl_TogglePause()
        {
            if (GameState == "Play")
            {
                UI_ChangePage("Pause");
            }
            else if (GameState == "Pause")
            {
                UI_ChangePage("Play");
            }
        }

        #endregion

        #region Mouse

        private void MouseClick_Handler()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (!MouseClicking_Left)
                {
                    if (UIPage_Current != null)
                    {
                        foreach (UIItem Item in UIPage_Current.UIItems)
                        {
                            int OrientatePosX = _graphics.PreferredBackBufferWidth / 2;
                            int OrientatePosY = _graphics.PreferredBackBufferHeight / 2;
                            switch (Item.Orientation)
                            {
                                case "Bottom Left":
                                    OrientatePosX = 0;
                                    OrientatePosY = _graphics.PreferredBackBufferHeight;
                                    break;
                                case "Left":
                                    OrientatePosX = 0;
                                    break;
                                case "Top Left":
                                    OrientatePosX = 0;
                                    OrientatePosY = 0;
                                    break;
                                case "Top":
                                    OrientatePosY = 0;
                                    break;
                                case "Top Right":
                                    OrientatePosX = _graphics.PreferredBackBufferWidth;
                                    OrientatePosY = 0;
                                    break;
                                case "Right":
                                    OrientatePosX = _graphics.PreferredBackBufferWidth;
                                    break;
                                case "Bottom Right":
                                    OrientatePosX = _graphics.PreferredBackBufferWidth;
                                    OrientatePosY = _graphics.PreferredBackBufferHeight;
                                    break;
                                case "Bottom":
                                    OrientatePosY = _graphics.PreferredBackBufferHeight;
                                    break;
                            }

                            int X = OrientatePosX + Item.X;
                            int Y = OrientatePosY + Item.Y;

                            if (Item.Type == "Button")
                            {
                                if (Mouse.GetState().X > X && Mouse.GetState().X < X + Item.Width &&
                                    Mouse.GetState().Y > Y && Mouse.GetState().Y < Y + Item.Height)
                                {
                                    UserControl_ButtonPress(Item.Data);
                                }
                            }
                        }
                    }
                }

                MouseClicking_Left = true;
            }
            else
            {
                MouseClicking_Left = false;
            }
        }
        private void MouseMove_Handler()
        {
            if (UIPage_Current != null)
            {
                foreach (UIItem Item in UIPage_Current.UIItems)
                {
                    int OrientatePosX = _graphics.PreferredBackBufferWidth / 2;
                    int OrientatePosY = _graphics.PreferredBackBufferHeight / 2;
                    switch (Item.Orientation)
                    {
                        case "Bottom Left":
                            OrientatePosX = 0;
                            OrientatePosY = _graphics.PreferredBackBufferHeight;
                            break;
                        case "Left":
                            OrientatePosX = 0;
                            break;
                        case "Top Left":
                            OrientatePosX = 0;
                            OrientatePosY = 0;
                            break;
                        case "Top":
                            OrientatePosY = 0;
                            break;
                        case "Top Right":
                            OrientatePosX = _graphics.PreferredBackBufferWidth;
                            OrientatePosY = 0;
                            break;
                        case "Right":
                            OrientatePosX = _graphics.PreferredBackBufferWidth;
                            break;
                        case "Bottom Right":
                            OrientatePosX = _graphics.PreferredBackBufferWidth;
                            OrientatePosY = _graphics.PreferredBackBufferHeight;
                            break;
                        case "Bottom":
                            OrientatePosY = _graphics.PreferredBackBufferHeight;
                            break;
                    }

                    int X = OrientatePosX + Item.X;
                    int Y = OrientatePosY + Item.Y;

                    if (Item.Type == "Button")
                    {
                        if (Mouse.GetState().X > X && Mouse.GetState().X < X + Item.Width &&
                                    Mouse.GetState().Y > Y && Mouse.GetState().Y < Y + Item.Height)
                        {
                            if (!Item.Highlighted)
                            {
                                Item.ToggleHighlight();
                            }
                        }
                        else if (Item.Highlighted)
                        {
                            Item.ToggleHighlight();
                        }
                    }
                }
            }
        }

        private void UserControl_ButtonPress(List<string> Data)
        {
            if (Data.Count == 1)
            {
                switch (Data[0])
                {
                    case "Home":
                        UI_ChangePage("Start");
                        break;
                    case "Resume":
                        UI_ChangePage("Play");
                        break;
                    case "Quit":
                        System.Environment.Exit(0);
                        break;
                    case "ENLIST":
                        UI_ChangePage("Information");
                        break;
                    case "Info Continue":
                        UI_ChangePage("Game Select");
                        break;
                    case "Wiki":
                        UI_ChangePage("Wiki");
                        break;
                    case "Wars":
                        UI_ChangePage("Wars");
                        break;
                    case "Soldiers":
                        UI_ChangePage("Soldiers");
                        break;
                    case "Money Global":
                        UI_ChangePage("Money Global");
                        break;
                    case "Money US":
                        UI_ChangePage("Money US");
                        break;
                    case "Deaths":
                        UI_ChangePage("Deaths");
                        break;
                    case "Nukes":
                        UI_ChangePage("Nukes");
                        break;
                }
            }
        }

        #endregion

        /////////////////////////////////////////

        #region Fundamentals

        protected override void Update(GameTime gameTime)
        {
            KeyBind_Handler();
            MouseClick_Handler();
            MouseMove_Handler();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // BEGIN Draw ----
            _spriteBatch.Begin();

            foreach (UIPage page in UIPages)
            {
                if (page.Type == GameState)
                {
                    UI_RenderElements(page.UIItems);
                }
            }

            _spriteBatch.End();
            // END Draw ------

            base.Draw(gameTime);
        }

        #endregion
    }
}