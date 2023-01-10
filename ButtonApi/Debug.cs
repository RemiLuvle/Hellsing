using HellsingCore.ButtonAPI;
using MelonLoader;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using static HellsingPc.Misc.Config;
using Cysharp.Threading.Tasks.Triggers;
using UIWidgets;
using VRC.UI.Core.Styles;
using System.Collections.Generic;
using System.Collections;
using Object = UnityEngine.Object;

namespace HellsingCore.ButtonAPI 
{
    internal class Debug
    {
        public int maxLines = 50;
        private int numLines;
        public static GameObject lable;
        public static GameObject background;
        public static TextMeshProUGUI text;
        public Text shownText;
        private string wholeText;
        private string datum;

        public Int32 m_MaxLines = 4;
        private Queue m_Inputs;

        public static void DebugMenu()
        {
            lable = UnityEngine.Object.Instantiate<GameObject>(UserInterface.transform.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickLinks").gameObject, tabMenu.GetMenuObject().transform);
            lable.transform.localPosition = new Vector3(0, -218.8705f, 0);
            text = lable.GetComponentInChildren<TextMeshProUGUI>();
            text.alignment = TextAlignmentOptions.BottomLeft;
            text.fontSize = 20;
            text.fontSizeMax = 25;
            text.fontSizeMax = 18;
            lable.SetActive(true);
            background = lable.transform.Find("HeaderBackground").gameObject;
            background.GetComponent<Image>().overrideSprite = HellsingResources.Resources.LoadSprite("Debug.png");
            UnityEngine.Object.Destroy(background.GetComponent<StyleElement>());
            background.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            background.transform.localPosition = new Vector3(0, 299.7452f, 0);
            background.transform.localScale = new Vector3(1, 7.0909f, 1);
            background.SetActive(true);
        }

        public static List<string> list = new List<string>();

        public static void Message(string message)
        {
            if (list.Count >=24)
            {
                list.RemoveAt(0);
            }
            list.Add(message + "\n");
            updatelist();
        }
        
        public static void updatelist()
        {
            text.text = "";
            foreach(var strng in list)
            {
                text.text = text.text + strng;
            }
        }
    }
}
