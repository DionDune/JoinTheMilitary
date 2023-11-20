using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinTheMilitary
{
    internal class UIPage
    {
        public string Type { get; set; }

        public List<UIItem> UIItems { get; set; }


        public UIPage()
        {
            Type = "Default";

            UIItems = new List<UIItem>();
        }

        public static List<UIPage> GeneratePages(GraphicsDeviceManager Window)
        {
            List<UIPage> UIPages = new List<UIPage>();


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
                    Elements = TextElement.GetString("QUIT"),
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
                    Elements = TextElement.GetString("HOME"),
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
                            Elements = TextElement.GetString("ENLIST"),
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
                            Elements = TextElement.GetString("QUIT"),
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
                            Elements = TextElement.GetString("WELCOME TO THE MILITARY!!!"),
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
                            Elements = TextElement.GetString("OURS IS NOT TO REASON WHY"),
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
                            Elements = TextElement.GetString("OURS IS BUT TO DO AND DIE"),
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
                            Elements = TextElement.GetString("ARE YOU PREPARED TO DIE FOR YOUR STATE?"),
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
                            Elements = TextElement.GetString("YES!"),
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
                            Elements = TextElement.GetString("NO"),
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
                        Height = Window.PreferredBackBufferHeight * 4,

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
                            Elements = TextElement.GetString("EXAMPLE"),
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
                            Elements = TextElement.GetString("INFORMATION"),
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
                            Elements = TextElement.GetString("MILITARY WIKI"),
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
                            Elements = TextElement.GetString("NUMBER OF WARS RIGHT NOW"),
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
                            Elements = TextElement.GetString("NUMBER OF SOLDIERS RIGHT NOW"),
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
                            Elements = TextElement.GetString("NUMBER OF NUKES RIGHT NOW"),
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
                            Elements = TextElement.GetString("MONEY SPENT ON WAR GLOBALLY"),
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
                            Elements = TextElement.GetString("MONEY SPENT ON WAR IN THE US"),
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
                            Elements = TextElement.GetString("CIVILIAN DEATHS THIS CENTURY"),
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
                    Elements = TextElement.GetString("RETURN TO WIKI"),
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
                            Elements = TextElement.GetString("AS OF 13TH OF NOVEMBER 2023"),
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
                            Elements = TextElement.GetString("THERE ARE 32 ONGOING WARS"),
                            ElementSize = 12,
                            Color = Color.Red,
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
                            Elements = TextElement.GetString("AS RECORDED IN 2020"),
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
                            Elements = TextElement.GetString("THE ARE ROUGHLY  27,406,000  ACTIVE SOLDIERS"),
                            ElementSize = 10,
                            Color = Color.Red,
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
                            Elements = TextElement.GetString("AS OF JANUARY 2023"),
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
                            Elements = TextElement.GetString("THERE ARE APPROXIMATLY  12,500  NUKES IN EXISTENCE"),
                            ElementSize = 10,
                            Color = Color.Red,
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
                            Elements = TextElement.GetString("AS RECORDED IN 2022"),
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
                            Elements = TextElement.GetString("THE APROXIMATE COST OF WAR GLOBALLY"),
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
                            Elements = TextElement.GetString("REACHED  2.24  TRILLION U.S DOLLARS"),
                            ElementSize = 10,
                            Color = Color.Red,
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
                            Elements = TextElement.GetString("AS RECORDED IN 2022"),
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
                            Elements = TextElement.GetString("THE APROXIMATE COST OF WAR IN THE US"),
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
                            Elements = TextElement.GetString("REACHED  844  BILLION U.S DOLLARS"),
                            ElementSize = 10,
                            Color = Color.Red,
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
                            Elements = TextElement.GetString("SINCE THE YEAR 2001"),
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
                            Elements = TextElement.GetString("ATLEAST  432,000  CIVILIANS HAVE DIED IN WARS"),
                            ElementSize = 10,
                            Color = Color.Red,
                        }
                    }
                }
            });

            return UIPages;
        }


        public static Point GetOrientationPosition(int PositionX, int PositionY, string ScreenOrientation, GraphicsDeviceManager Window)
        {
            switch (ScreenOrientation)
            {
                case "Bottom Left":
                    PositionX = 0;
                    PositionY = Window.PreferredBackBufferHeight;
                    break;
                case "Left":
                    PositionX = 0;
                    break;
                case "Top Left":
                    PositionX = 0;
                    PositionY = 0;
                    break;
                case "Top":
                    PositionY = 0;
                    break;
                case "Top Right":
                    PositionX = Window.PreferredBackBufferWidth;
                    PositionY = 0;
                    break;
                case "Right":
                    PositionX = Window.PreferredBackBufferWidth;
                    break;
                case "Bottom Right":
                    PositionX = Window.PreferredBackBufferWidth;
                    PositionY = Window.PreferredBackBufferHeight;
                    break;
                case "Bottom":
                    PositionY = Window.PreferredBackBufferHeight;
                    break;
            }
            return new Point(PositionX, PositionY);
        }
        public List<string> GetElementPressData(Point MousePosition, GraphicsDeviceManager Window)
        {
            foreach (UIItem Item in UIItems)
            {
                int ScreenCentre_X = Window.PreferredBackBufferWidth / 2;
                int ScreenCentre_Y = Window.PreferredBackBufferHeight / 2;
                Point OrientationPosition = GetOrientationPosition(ScreenCentre_X, ScreenCentre_Y, Item.Orientation, Window);

                int X = OrientationPosition.X + Item.X;
                int Y = OrientationPosition.Y + Item.Y;

                if (Item.Type == "Button")
                {
                    if (Mouse.GetState().X > X && Mouse.GetState().X < X + Item.Width &&
                        Mouse.GetState().Y > Y && Mouse.GetState().Y < Y + Item.Height)
                    {
                        return Item.Data;
                    }
                }
            }

            return null;
        }

        public void UpdateHighlightedElements(Point MousePosition, GraphicsDeviceManager Window)
        {
            foreach (UIItem Item in UIItems)
            {
                int ScreenCentre_X = Window.PreferredBackBufferWidth / 2;
                int ScreenCentre_Y = Window.PreferredBackBufferHeight / 2;
                Point OrientationPosition = GetOrientationPosition(ScreenCentre_X, ScreenCentre_Y, Item.Orientation, Window);

                int X = OrientationPosition.X + Item.X;
                int Y = OrientationPosition.Y + Item.Y;

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
}
