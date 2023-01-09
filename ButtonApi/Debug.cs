using HellsingCore.ButtonAPI;
using MelonLoader;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace HellsingCore.ButtonAPI 
{
    internal class Debug
    {
        public static GameObject lable;
        public static TextMeshProUGUI text;
        public static void DebugMenu()
        {
            lable = UnityEngine.Object.Instantiate<GameObject>(HellsingPc.Main.UserInterface.transform.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickLinks").gameObject, APIUtils.GetQMMenuTemplate().transform);
            lable.transform.localPosition = new Vector3(-0.0005f, 11.2451f, 12.6858f);
            text = lable.GetComponentInChildren<TextMeshProUGUI>();
            text.alignment = TextAlignmentOptions.TopLeft;
            text.color = new Color(1, 0, 0, 1);
            text.enableAutoSizing = true;
            lable.SetActive(true);
            text.text = "";
        }
        public static void Message(string message)
        {
            text.text = DateTime.Now.ToString("(HH.mm.ss)") + message + "\n" + text.text;

        }
    }
}
