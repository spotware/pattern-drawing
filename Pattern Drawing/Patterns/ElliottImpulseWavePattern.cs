﻿using cAlgo.API;
using System;
using System.Linq;

namespace cAlgo.Patterns
{
    public class ElliottImpulseWavePattern : ElliottWavePatternBase
    {
        public ElliottImpulseWavePattern(PatternConfig config) : base("EW 12345", config, 5)
        {
        }

        protected override void DrawLabels()
        {
            if (FirstLine == null || SecondLine == null || ThirdLine == null || FourthLine == null || FifthLine == null) return;

            DrawLabels(FirstLine, SecondLine, ThirdLine, FourthLine, FifthLine, Id);
        }

        private void DrawLabels(ChartTrendLine firstLine, ChartTrendLine secondLine, ChartTrendLine thirdLine, ChartTrendLine fourthLine, ChartTrendLine fifthLine, long id)
        {
            DrawLabelText("(0)", firstLine.Time1, firstLine.Y1, id);
            DrawLabelText("(1)", secondLine.Time1, secondLine.Y1, id);
            DrawLabelText("(2)", thirdLine.Time1, thirdLine.Y1, id);
            DrawLabelText("(3)", fourthLine.Time1, fourthLine.Y1, id);
            DrawLabelText("(4)", fifthLine.Time1, fifthLine.Y1, id);
            DrawLabelText("(5)", fifthLine.Time2, fifthLine.Y2, id);
        }

        protected override void UpdateLabels(long id, ChartObject chartObject, ChartText[] labels, ChartObject[] patternObjects)
        {
            var firstLine = patternObjects.FirstOrDefault(iObject => iObject.Name.EndsWith("FirstLine",
                StringComparison.OrdinalIgnoreCase)) as ChartTrendLine;

            var secondLine = patternObjects.FirstOrDefault(iObject => iObject.Name.EndsWith("SecondLine",
                StringComparison.OrdinalIgnoreCase)) as ChartTrendLine;

            var thirdLine = patternObjects.FirstOrDefault(iObject => iObject.Name.EndsWith("ThirdLine",
                StringComparison.OrdinalIgnoreCase)) as ChartTrendLine;

            var fourthLine = patternObjects.FirstOrDefault(iObject => iObject.Name.EndsWith("FourthLine",
                StringComparison.OrdinalIgnoreCase)) as ChartTrendLine;

            var fifthLine = patternObjects.FirstOrDefault(iObject => iObject.Name.EndsWith("FifthLine",
                StringComparison.OrdinalIgnoreCase)) as ChartTrendLine;

            if (firstLine == null || secondLine == null || thirdLine == null || fourthLine == null || fifthLine == null) return;

            if (labels.Length == 0)
            {
                DrawLabels(firstLine, secondLine, thirdLine, fourthLine, fifthLine, id);

                return;
            }

            foreach (var label in labels)
            {
                switch (label.Text)
                {
                    case "(0)":
                        label.Time = firstLine.Time1;
                        label.Y = firstLine.Y1;
                        break;

                    case "(1)":
                        label.Time = secondLine.Time1;
                        label.Y = secondLine.Y1;
                        break;

                    case "(2)":
                        label.Time = thirdLine.Time1;
                        label.Y = thirdLine.Y1;
                        break;

                    case "(3)":
                        label.Time = fourthLine.Time1;
                        label.Y = fourthLine.Y1;
                        break;

                    case "(4)":
                        label.Time = fifthLine.Time1;
                        label.Y = fifthLine.Y1;
                        break;

                    case "(5)":
                        label.Time = fifthLine.Time2;
                        label.Y = fifthLine.Y2;
                        break;
                }
            }
        }
    }
}