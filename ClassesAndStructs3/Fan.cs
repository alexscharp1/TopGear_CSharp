using System;
using System.Text;

namespace ClassesAndStructs3
{
    class Fan
    {
        private const int SLOW = 1;
        private const int MEDIUM = 2;
        private const int FAST = 3;
        private static string[] colors;

        private int speed;
        private bool on;
        private double radius;
        private string color;

        public Fan()
        {
            // Initialize list of colors
            colors = new string[]
            {
                "red", "orange", "blue", "green", "pink", "purple", "yellow",
                "white", "gray", "black"
            };

            // Set object's default values
            speed = SLOW;
            on = false;
            radius = 5;
            color = "red";
        }

        public int GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(int value)
        {
            switch (value)
            {
                case 1:
                    speed = SLOW;
                    return;
                case 2:
                    speed = MEDIUM;
                    return;
                case 3:
                    speed = FAST;
                    return;
                default:
                    string errMsg = string.Format("Invalid speed value. " +
                        "Expected 1, 2, or 3. Instead got {0}.", value);
                    throw new InvalidSpeedException(errMsg);
            }
        }

        public bool GetOn()
        {
            return on;
        }

        public void SetOn(bool value)
        {
            on = value;
        }

        public double GetRadius()
        {
            return radius;
        }

        public void SetRadius(double value)
        {
            if (value > 0)
            {
                radius = value;
            }
            else
            {
                string errMsg = string.Format("Invalid radius value. " +
                    "Excpected positive number. Instead got {0}.", value);
                throw new InvalidRadiusException(errMsg);
            }
        }

        public string GetColor()
        {
            return color;
        }

        public void SetColor(string value)
        {
            foreach (string validColor in colors)
            {
                if (value == validColor)
                {
                    color = value;
                    return;
                }
            }
            // No matching color
            string errMsg = string.Format("Invalid color. Expected a color " +
                "from the list of available colors. Instead got {0}.", value);
            throw new InvalidColorException(errMsg);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Speed:\t");
            switch (speed)
            {
                case 1:
                    sb.AppendLine("Slow (1)");
                    break;
                case 2:
                    sb.AppendLine("Medium (2)");
                    break;
                case 3:
                    sb.AppendLine("Fast (3)");
                    break;
                default:
                    throw new InvalidSpeedException();
            }
            sb.AppendLine(string.Format("On:\t{0}", on));
            sb.AppendLine(string.Format("Radius:\t{0} units", radius));
            sb.AppendLine(string.Format("Color:\t{0}", color));
            return sb.ToString();
        }
    }
}
