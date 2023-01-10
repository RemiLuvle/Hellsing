using HellsingCore.ButtonApi;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HellsingCore.ButtonAPI
{
    internal class Nameplates
    {
        public static GameObject nameplate;
        public static TextMeshProUGUI text;
        public static List<NameplateStructure> userTags = new List<NameplateStructure>();
        private int noUpdateCount;
        public static Dictionary<string, string> tags = new Dictionary<string, string>();

        public static void LoadTags()
        {
            tags.Add("usr_e2322d27-d9b9-4b25-8400-fc8974ae7d6a", "<color=#FF0000>HellsingOwner</color> | <color=#FF0000>Remi</color>");
            tags.Add("usr_1eeee983-4d58-40a4-a285-fd42b1363ef2", "<color=#000000>Spooky Hacker Man</color> | <color=#000000>Egg</color>");
            tags.Add("usr_2ec8bdf5-5209-4f08-881d-6281fcec814a", "<color=#000000>Skid</color> | <color=#000000>Fag</color>");
        }
        
        public static TextMeshProUGUI AddTag(Color color, VRC.Player player)
        {
            PlayerNameplate nameplate2 = player.prop_VRCPlayer_0.field_Public_PlayerNameplate_0;
            Transform transform = Object.Instantiate(nameplate2.gameObject.transform.Find("Contents/Quick Stats"), nameplate2.gameObject.transform.Find("Contents"));
            transform.gameObject.SetActive(true);
            TextMeshProUGUI component = transform.Find("Trust Text").GetComponent<TextMeshProUGUI>();
            component.color = color;
            transform.Find("Trust Text").gameObject.SetActive(false);
            transform.Find("Performance Text").gameObject.SetActive(false);
            transform.Find("Trust Icon").gameObject.SetActive(false);
            transform.Find("Performance Icon").gameObject.SetActive(false);
            transform.Find("Friend Anchor Stats").gameObject.SetActive(false);
            transform.name = "HellsingNamePlate";
            transform.gameObject.transform.localPosition = new Vector3(0, -75.2725f, 0);
            if (tags.ContainsKey(player.field_Private_APIUser_0.id))
            {
                transform.Find("Trust Text").gameObject.SetActive(true);
                component.text = tags[player.field_Private_APIUser_0.id];
            }
            else
            {
                component.text = "";
            }
            return component;
        }


    }
}


