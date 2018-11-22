﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Timers;
using System.Text;
using System.Globalization;

using SOA.Interface;
using SOA.Extension;
using SOA.WindowAPI;
using SOA.Helper;
using SOA.Input;
using SOA.Util;

namespace SOA
{
    public sealed class SOAApp
    {
        #region Inputs
        public IKeyboard Keyboard { get; } = new Keyboard();
        public IMouse Mouse { get; } = new Mouse();
        #endregion

        #region Utils
        public ICamera Camera { get; } = new Camera();
        public ICommand Command { get; } = new Command();
        #endregion


        public SOAApp()
        {
           
        }

        public void Run()
        {
            Keyboard.Init();
            Mouse.Init();

            Camera.Init();
            Command.Init();

            Application.Run();
        }
    }

        
}