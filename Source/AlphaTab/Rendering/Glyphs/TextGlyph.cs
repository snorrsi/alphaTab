﻿/*
 * This file is part of alphaTab.
 * Copyright © 2017, Daniel Kuschny and Contributors, All rights reserved.
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or at your option any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library.
 */
using AlphaTab.Platform;
using AlphaTab.Platform.Model;

namespace AlphaTab.Rendering.Glyphs
{
    public class TextGlyph : EffectGlyph
    {
        private readonly string _text;

        public Font Font { get; set; }
        public TextAlign TextAlign { get; set; }

        public TextGlyph(float x, float y, string text, Font font, TextAlign textAlign = TextAlign.Left)
            : base(x, y)
        {
            _text = text;
            Font = font;
            TextAlign = textAlign;
        }
        
        public override void DoLayout()
        {
            base.DoLayout();
            Height = Font.Size;
        }

        public override void Paint(float cx, float cy, ICanvas canvas)
        {
            canvas.Font = Font;
            var old = canvas.TextAlign;
            canvas.TextAlign = TextAlign;
            canvas.FillText(_text, cx + X, cy + Y);
            canvas.TextAlign = old;
        }
    }
}
