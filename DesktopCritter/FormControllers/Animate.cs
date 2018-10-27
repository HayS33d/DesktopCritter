using DesktopCritter.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopCritter.FormControllers
{
    public partial class CritterFormController
    {
        internal void Animate()
        {
            windows = WindowService.RunningWindows.GetOpenedWindows();
            if (IsFalling == false)
                IsFalling = !IsCritterOnWindow(windowCritterIsWalkingOn, this.CritterFrame);


            if (IsFalling)
            {

                windowCritterIsWalkingOn = Fall();
                IsFalling = !IsCritterOnWindow(windowCritterIsWalkingOn, this.CritterFrame);


            }

            if (animationIndex > maxAnimationSteps)
                animationIndex = 1;
            if (!IsFallingFast && IsFalling)
                return;
            switch (animationIndex)
            {
                case 1:
                    Step2();
                    break;

                case 2:
                    Step3();
                    break;

                case 3:
                    Step4();
                    break;

                case 4:
                    Step5();
                    break;

                case 5:
                    //Step6();

                    animationIndex = 0;
                    Step1();
                    break;

                case 6:
                    animationIndex = 0;
                    Step1();
                    break;
            }

            if(!HitAWall(this.CritterFrame, windows))
                MoveCritter();
        }

        internal void FormCritter_Load(object sender, EventArgs e)
        {
        }

        internal void MoveCritter()
        {
            try
            {
                if (Critter.Location.X + movementDistance >= Screen.PrimaryScreen.Bounds.Right)
                {
                    Critter.Location = new Point(
                         (0), (Critter.Location.Y));
                }
                else
                {
                    Critter.Location = new Point(
                             (Critter.Location.X + movementDistance), (Critter.Location.Y));
                }
            }
            catch (Exception e)
            {
                var t = e.Message;
            }

            Critter.Update();
        }

        internal void Step1()
        {
            Critter.PictureBox.Image = DesktopCritter.Properties.Resources.step1;
        }

        internal void Step2()
        {
            Critter.PictureBox.Image = DesktopCritter.Properties.Resources.step2;
        }

        internal void Step3()
        {
            Critter.PictureBox.Image = DesktopCritter.Properties.Resources.step3;
        }

        internal void Step4()
        {
            Critter.PictureBox.Image = DesktopCritter.Properties.Resources.step4;
        }

        internal void Step5()
        {
            Critter.PictureBox.Image = DesktopCritter.Properties.Resources.step5;
        }

        internal void Step6()
        {
            Critter.PictureBox.Image = DesktopCritter.Properties.Resources.step6;
        }
    }
}