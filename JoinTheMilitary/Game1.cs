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

                Data = new List<string>() { "Page Change", "Game Select" }
            };


            //      Main Pages
            //Start Page
            UIPages.Add(new UIPage()
            {
                Type = "Start",

                UIItems = new List<UIItem>()
                {
                    //Start Button
                    new UIItem()
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

                        Data = new List<string>() { "Page Change", "Information" }
                    },
                    //Quit Button
                    new UIItem()
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
                    },
                    //Start Message
                    new UIItem()
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
                        }
                    }
                }
            });
            //Information Page
            UIPages.Add(new UIPage()
            {
                Type = "Information",

                UIItems = new List<UIItem>()
                {
                    UniQuit, UniHome,

                    //Messages
                    new UIItem()
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
                        }
                    },
                    new UIItem()
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
                        }
                    },
                    new UIItem()
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
                        }
                    },

                    //Continue
                    new UIItem()
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

                        Data = new List<string>() { "Page Change", "Game Select" }
                    },
                    //Quit
                    new UIItem()
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
                    }
                }
            });
            //Game Select Page
            UIPages.Add(new UIPage()
            {
                Type = "Game Select",

                UIItems = new List<UIItem>()
                {
                    UniQuit, UniHome,

                    //Divider
                    new UIItem()
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
                    },
                    //Example Select
                    new UIItem()
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
                            Elements = TextCharacter.GetString("EXAMPLE"),
                            ElementSize = 6,
                            Color = Color.Black
                        },

                        Data = new List<string>() { "Page Change", "null" }
                    },
                    //Wiki Select
                    new UIItem()
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

                        Data = new List<string>() { "Page Change", "Wiki" }
                    }
                }
            });
            //Wiki Main Page
            UIPages.Add(new UIPage()
            {
                Type = "Wiki",

                UIItems = new List<UIItem>()
                {
                    UniQuit, UniHome,

                    //Message
                    new UIItem()
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
                    },
                    //Wars Fought Button
                    new UIItem()
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

                        Data = new List<string>() { "Page Change", "Wars" }
                    },
                    //Soldiers Button
                    new UIItem()
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

                        Data = new List<string>() { "Page Change", "Soldiers" }
                    },
                    //Nukes Button
                    new UIItem()
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

                        Data = new List<string>() { "Page Change", "Nukes" }
                    },
                    //Global Expenditure Button
                    new UIItem()
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

                        Data = new List<string>() { "Page Change", "Money Global" }
                    },
                    //U.S. Expenditure Button
                    new UIItem()
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

                        Data = new List<string>() { "Page Change", "Money US" }
                    },
                    //Civilian Deaths Button
                    new UIItem()
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

                        Data = new List<string>() { "Page Change", "Deaths" }
                    }
                }
            });


            //      Wiki Sub Pages
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

                Data = new List<string>() { "Page Change", "Wiki" }
            };
            //Wars Page
            UIPages.Add(new UIPage()
            {
                Type = "Wars",

                UIItems = new List<UIItem>()
                {
                    UniQuit, UniHome, WikiReturn,

                    //Messages
                    new UIItem()
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
                    },
                    new UIItem()
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
                    }
                }
            });
            //Soldiers Page
            UIPages.Add(new UIPage()
            {
                Type = "Soldiers",

                UIItems = new List<UIItem>()
                {
                    UniQuit, UniHome, WikiReturn,

                    //Messages
                    new UIItem()
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
                    },
                    new UIItem()
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
                    }
                }
            });
            //Nukes Page
            UIPages.Add(new UIPage()
            {
                Type = "Nukes",

                UIItems = new List<UIItem>()
                {
                    UniQuit, UniHome, WikiReturn,

                    //Messages
                    new UIItem()
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
                    },
                    new UIItem()
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
                    }
                } 
            });
            //Global Expenditure Page
            UIPages.Add(new UIPage()
            {
                Type = "Money Global",

                UIItems = new List<UIItem>()
                {
                    UniQuit, UniHome, WikiReturn,

                    //Messages
                    new UIItem()
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
                    },
                    new UIItem()
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
                    },
                    new UIItem()
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
                    }
                }
            });
            //U.S. Expenditure Page
            UIPages.Add(new UIPage()
            {
                Type = "Money US",

                UIItems = new List<UIItem>()
                {
                    UniQuit, UniHome, WikiReturn,

                    //Messages
                    new UIItem()
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
                    },
                    new UIItem()
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
                    },
                    new UIItem()
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
                    }
                }
            });
            //Civilian Deaths Page
            UIPages.Add(new UIPage()
            {
                Type = "Deaths",

                UIItems = new List<UIItem>()
                {
                    UniQuit, UniHome, WikiReturn,

                    //Message
                    new UIItem()
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
                    },
                    new UIItem()
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
                    }
                }
            });
        }

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