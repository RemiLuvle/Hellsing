using MelonLoader;
using System;
using System.IO;
using System.Linq;
using UnhollowerRuntimeLib;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using System.Reflection;
using UnhollowerBaseLib.Attributes;
using Utils;
using HellsingPc.Misc;

namespace HellsingResources
{
    public class Resources
    {
        private static string resourcePath = Path.Combine(Environment.CurrentDirectory, "Hellsing/Resources/Icons");  

        public static Sprite LoadSprite(string sprite)
        {
            return $"{resourcePath}/{sprite}".LoadSpriteFromDisk();
        }
    }
}
