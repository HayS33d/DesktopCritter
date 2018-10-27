using DesktopCritter.Models;
using DesktopCritter.Services;
using System.Drawing;

namespace DesktopCritter.FormControllers
{
    public partial class CritterFormController
    {
        internal WindowFrame Fall()
        {
            var windows = WindowService.RunningWindows.GetOpenedWindows();
            var critterWindow = FallCritter();

            return LandedOnWindow(critterWindow, windows);
        }

        internal WindowFrame FallCritter()
        {
            if (currentSpeed >= maxFallSpeed)
                currentSpeed -= fallSpeedIncrement;
            if (currentSpeed < maxFallSpeed) currentSpeed = maxFallSpeed;
            timer.Interval = currentSpeed;
            Critter.Location = new Point(
                     (Critter.Location.X), (Critter.Location.Y + animatitonMovement));
            if (currentSpeed == maxFallSpeed)
            {
                movementDistance = 0;
                IsFallingFast = true;
            }
            else
            {
                Critter.Update();
            }
            return new WindowFrame()
            {
                Left = Critter.Location.X,
                Bottom = Critter.Location.Y + Critter.Height,
                Right = Critter.Right
            };
        }
        public bool IsCritterOnWindow(WindowFrame window, WindowFrame critter)
        {
            if (window == null)
                return false;
            if (window.Top == 0) return false;
            if (critter.Bottom < window.Top - animatitonMovement) return false;
            if (critter.Left > window.Right) return false;
            if (critter.Right < window.Left) return false;
            return true;
        }
    }
}