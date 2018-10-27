using System;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopCritter.FormControllers
{
    public partial class CritterFormController
    {
        internal void FormCritter_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        internal void FormCritter_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Critter.Location = new Point(
                    (Critter.Location.X - lastLocation.X) + e.X, (Critter.Location.Y - lastLocation.Y) + e.Y);

                Critter.Update();
            }
        }

        internal void FormCritter_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            IsFalling = true;
        }

        internal void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
        }

        internal void Timer_Tick(object sender, EventArgs e)
        {
            animationIndex++;
            Animate();
        }
    }
}