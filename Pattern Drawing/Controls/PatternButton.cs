﻿using cAlgo.Patterns;

namespace cAlgo.Controls
{
    public class PatternButton : ToggleButton
    {
        private readonly IPattern _pattern;

        public PatternButton(IPattern pattern)
        {
            Click += args =>
            {
                if (IsOn)
                {
                    TurnOff();
                }
                else
                {
                    TurnOn();
                }
            };

            _pattern = pattern;

            _pattern.DrawingStarted += Pattern_DrawingStarted;
            _pattern.DrawingStopped += Pattern_DrawingStopped;

            Text = pattern.Name;
        }

        protected override void OnTurnedOn()
        {
            _pattern.StartDrawing();
        }

        protected override void OnTurnedOff()
        {
            _pattern.StopDrawing();
        }

        private void Pattern_DrawingStopped(IPattern obj)
        {
            if (IsOn)
            {
                TurnOff();
            }
        }

        private void Pattern_DrawingStarted(IPattern obj)
        {
            if (!IsOn)
            {
                TurnOn();
            }
        }
    }
}