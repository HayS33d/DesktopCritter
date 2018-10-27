using DesktopCritter.Models;
using DesktopCritter.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopCritter.FormControllers
{
    public partial class CritterFormController
    {
        protected const int animatitonMovement = 6;
        protected int animationIndex = 0;

        protected int currentSpeed;
        protected int fallSpeedIncrement = 5;
        protected IntPtr id;
        protected Point lastLocation;
        protected int maxAnimationSteps = 6;
        protected int maxFallSpeed = 10;
        protected bool mouseDown;
        protected int movementDistance = 6;
        protected Timer timer;
        protected int walkSpeed = 80;
        protected List<WindowFrame> windows;
        public FormCritter Critter { get; set; }
        protected bool IsFalling { get; set; } = true;
        protected bool IsFallingFast { get; set; } = false;
        internal WindowFrame windowCritterIsWalkingOn;

        public void Load()
        {
            Critter = new FormCritter();
            Critter.TopMost = true;
            Critter.BackColor = Color.DimGray;
            Critter.TransparencyKey = Color.DimGray;
            Critter.PictureBox.MouseDown += FormCritter_MouseDown;
            Critter.PictureBox.MouseMove += FormCritter_MouseMove;
            Critter.PictureBox.MouseUp += FormCritter_MouseUp;
            //windowCritterIsWalkingOn = new WindowFrame();
            currentSpeed = walkSpeed;
            timer = new Timer();
            timer.Interval = walkSpeed;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            timer.Start();
             windows = WindowService.RunningWindows.GetOpenedWindows();
        }

        internal WindowFrame CritterFrame
        {
            get
            {
                return new WindowFrame()
                {
                    Top = Critter.Top,
                    Bottom = Critter.Bottom,
                    Left = Critter.Left,
                    Right = Critter.Right
                };
            }
        }
    }
}