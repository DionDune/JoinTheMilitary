﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinTheMilitary
{
    internal class UIItem
    {
        public string Type { get; set; }
        public bool Highlighted { get; set; }

        public string Orientation { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int CentreX { get; set; }
        public int CentreY { get; set; }

        public int BorderWidth { get; set; }

        public Color BaseColor { get; set; }
        public Color BorderColor { get; set; }
        public Color HighlightedColor { get; set; }


        public List<string> Data { get; set; }


        public TextElement Text { get; set; }

        public List<UIItem> uIItems { get; set; }

        public UIItem()
        {
            Type = "Button";
            Highlighted = false;

            Orientation = "Centre";

            X = 0;
            Y = 0;

            Width = 10;
            Height = 10;

            CentreX = 5;
            CentreY = 5;

            BorderWidth = 0;

            BaseColor = Color.Purple;
            BorderColor = Color.Black;
            HighlightedColor = Color.Gold;

            Data = null;
            Text = null;

            uIItems = new List<UIItem>();
        }

        public void ToggleHighlight()
        {
            Highlighted = !Highlighted;
        }
    }
}
