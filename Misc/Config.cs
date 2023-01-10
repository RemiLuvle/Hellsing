using HellsingCore.API.QM;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;

namespace HellsingPc.Misc
{
    internal class Config
    {
        public static Player LocalPlayer => Player.prop_Player_0;
        public static bool E6Enabled = false;
        public static bool Earrape = false;
        public static bool yeet;
        public static bool Fly;
        public static bool Force_Pickups;
        public static bool toggledebug;
        public static bool toggleesp;
        public static bool light = false;
        public static bool orbit = false;
        public static bool Ui;
        public static bool Murder4ExplodeLoop;
        public static GameObject UserInterface;
        public static QMTabMenu tabMenu;

    }
}
