﻿using System;
using System.Windows.Forms;
using Sledge.DataStructures.Geometric;

namespace Sledge.Editor.Rendering
{
    public class ViewportEvent : EventArgs
    {
        public MapViewport Sender { get; set; }
        public bool Handled { get; set; }

        // Key
        public Keys Modifiers { get; set; }
        public bool Control { get; set; }
        public bool Shift { get; set; }
        public bool Alt { get; set; }
        public Keys KeyCode { get; set; }
        public int KeyValue { get; set; }
        public char KeyChar { get; set; }

        // Mouse
        public MouseButtons Button { get; set; }
        public int Clicks { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Delta { get; set; }

        public Coordinate Location
        {
            get { return new Coordinate(X, Y, 0); }
        }

        // Mouse movement
        public int LastX { get; set; }
        public int LastY { get; set; }

        public int DeltaX
        {
            get { return X - LastX; }
        }

        public int DeltaY
        {
            get { return Y - LastY; }
        }

        // Click and drag
        public bool Dragging { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }

        // 2D Camera
        public Coordinate CameraPosition { get; set; }
        public decimal CameraZoom { get; set; }

        public ViewportEvent(MapViewport sender, EventArgs e = null)
        {
            Sender = sender;
        }

        public ViewportEvent(MapViewport sender, KeyEventArgs e)
        {
            Sender = sender;
            Modifiers = e.Modifiers;
            Control = e.Control;
            Shift = e.Shift;
            Alt = e.Alt;
            KeyCode = e.KeyCode;
            KeyValue = e.KeyValue;
        }

        public ViewportEvent(MapViewport sender, KeyPressEventArgs e)
        {
            Sender = sender;
            KeyChar = e.KeyChar;
        }

        public ViewportEvent(MapViewport sender, MouseEventArgs e)
        {
            Sender = sender;
            Button = e.Button;
            Clicks = e.Clicks;
            X = e.X;
            Y = e.Y;
            Delta = e.Delta;
        }
    }
}