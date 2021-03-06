﻿// Copyright (c) 2016 robosoup
// www.robosoup.com

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Boids
{
    public class Boids : Form
    {
        private Timer timer;
        private Swarm swarm;
        private Image iconRegular;
        private Image iconZombie;

        [STAThread]
        private static void Main()
        {
            Application.Run(new Boids());
        }

        public Boids()
        {
            var boundary = 640;
            Text = "Flocking Boids";
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(boundary, boundary);
            iconRegular = CreateIcon(Brushes.Blue);
            iconZombie = CreateIcon(Brushes.Red);
            swarm = new Swarm(boundary);
            timer = new Timer();
            timer.Tick += new EventHandler(this.timer_Tick);
            timer.Interval = 75;
            timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (Boid boid in swarm.Boids)
            {
                float angle;
                if (boid.dX == 0) angle = 90f;
                else angle = (float)(Math.Atan(boid.dY / boid.dX) * 57.3);
                if (boid.dX < 0f) angle += 180f;
                var matrix = new Matrix();
                matrix.RotateAt(angle, boid.Position);
                e.Graphics.Transform = matrix;
                if (boid.Zombie) e.Graphics.DrawImage(iconZombie, boid.Position);
                else e.Graphics.DrawImage(iconRegular, boid.Position);
            }
        }

        private static Image CreateIcon(Brush brush)
        {
            var icon = new Bitmap(16, 16);
            var g = Graphics.FromImage(icon);
            var p1 = new Point(0, 16);
            var p2 = new Point(16, 8);
            var p3 = new Point(0, 0);
            var p4 = new Point(5, 8);
            var points = new Point[] { p1, p2, p3, p4 };
            g.FillPolygon(brush, points);
            return icon;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            swarm.MoveBoids();
            Invalidate();
        }
    }
}