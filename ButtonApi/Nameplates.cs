using HellsingCore.ButtonApi;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HellsingCore.ButtonAPI
{
    internal class Nameplates
    {
        public static GameObject nameplate;
        public static TextMeshProUGUI text;
        public static List<NameplateStructure> userTags = new List<NameplateStructure>();
        private int noUpdateCount;


        public static TextMeshProUGUI AddTag(string CustomTag, Color color, VRC.Player player)
        {
            PlayerNameplate nameplate2 = player.prop_VRCPlayer_0.field_Public_PlayerNameplate_0;
            Transform transform = UnityEngine.Object.Instantiate<Transform>(nameplate2.gameObject.transform.Find("Contents/Quick Stats"), nameplate2.gameObject.transform.Find("Contents"));
            transform.parent = nameplate2.gameObject.transform.Find("Contents");
            transform.gameObject.SetActive(true);
            TextMeshProUGUI component = transform.Find("Trust Text").GetComponent<TextMeshProUGUI>();
            component.color = color;
            transform.Find("Trust Icon").gameObject.SetActive(false);
            transform.Find("Performance Icon").gameObject.SetActive(false);
            transform.Find("Performance Text").gameObject.SetActive(false);
            transform.Find("Friend Anchor Stats").gameObject.SetActive(false);
            transform.name = "HellsingNamePlate";
            transform.gameObject.transform.localPosition = new Vector3(0, -75.2725f, 0);
            transform.GetComponent<ImageThreeSlice>().color = Color.white;
            component.text = CustomTag;
            return component;
        }


    }
}


