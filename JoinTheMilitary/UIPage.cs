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
