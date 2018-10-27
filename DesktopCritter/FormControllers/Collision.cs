using DesktopCritter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopCritter.FormControllers
{
    public partial class CritterFormController
    {
        internal WindowFrame LandedOnWindow(WindowFrame critter, List<WindowFrame> openWindows)
        {
            var fallingCritter = openWindows.FirstOrDefault(openWindow => openWindow.Left <= critter.Left
           && openWindow.Right > critter.Right
           && openWindow.Top >= critter.Bottom
           && openWindow.Top - animatitonMovement < critter.Bottom
           && openWindow.Title != string.Empty);
          

            if (fallingCritter == null)
                return critter;

            IsFalling = false;
            IsFallingFast = false;
            timer.Interval = walkSpeed;
            movementDistance = animatitonMovement;
            animationIndex = 0;
            return fallingCritter;
        }
    }
}
