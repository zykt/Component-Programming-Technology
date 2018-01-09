﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Task2._2
{
    public partial class Form11 : Form
    {
        private double _widthFromDouble;
        private double _heightFromDouble;

        public double WidthFromDouble
        {
            get { return _widthFromDouble; }
            set {
                _widthFromDouble = value;
                Console.WriteLine($"Setting {value}");
                this.Width = WithHorizontalBorder(Convert.ToInt32(_widthFromDouble));
            }
        }

        public double HeightFromDouble
        {
            get { return _heightFromDouble; }
            set
            {
                _heightFromDouble = value;
                this.Height = WithVerticalBorder(Convert.ToInt32(_heightFromDouble));
            }
        }

        public Form11()
        {
            InitializeComponent();
            this.MdiParent = Global.form1;
            this.Location = new Point(0, 0);
            var rc = this.MdiParent.ClientRectangle; 
            // this.MdiParent.RectangleToScreen(this.MdiParent.ClientRectangle);
            //int titlebarSize = this.MdiParent.Height - rc.Height;
            //int magicNumber = 2; // magic number: substract this from width so that no scrolling bars appear
            //this.Width = rc.Width - SystemInformation.BorderSize.Width * 2;// - magicNumber;
            //this.Height = rc.Height - SystemInformation.BorderSize.Height * 2 - titlebarSize;
            //this.Width = WithHorizontalBorder(rc.Width);
            //this.Height = WithVerticalBorder(rc.Height);
            this.WidthFromDouble = Convert.ToDouble(rc.Width);
            this.HeightFromDouble = Convert.ToDouble(rc.Height);
        }

        public void Scale(Double xScale, Double yScale)
        {
            this.WidthFromDouble = xScale * this.WidthFromDouble;
            this.HeightFromDouble = yScale * this.HeightFromDouble;
        }

        public int WithHorizontalBorder(int width)
        {
            // Rectangle rc = this.MdiParent.RectangleToScreen(this.MdiParent.ClientRectangle);
            int magicNumber = 2; // magic number: substract this from width so that no scrolling bars appear
            return width;// - SystemInformation.BorderSize.Width * 2 - magicNumber;
        }

        public int WithVerticalBorder(int height)
        {
            Rectangle rc = this.MdiParent.RectangleToScreen(this.MdiParent.ClientRectangle);
            int titlebarSize = this.MdiParent.Height - rc.Height;
            return height - SystemInformation.BorderSize.Height * 2 - titlebarSize;
        }

        private void Form11_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.form11 = null;
        }
    }
}
