using HellsingCore.ButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC;
using VRC.Core;
using VRC.UI.Elements.Menus;

namespace HellsingPc.Misc
{
        public static class IUserExtension
        {
        public static Player SelectedVRCPlayer() => APIUtils._userInterface.transform.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Local").GetComponentInChildren<SelectedUserMenuQM>().field_Private_IUser_0.prop_String_0.ReturnUserID();
        public static Player ReturnUserID(this string User)
        {
            foreach (Player player in PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0)
            {
                if (player.field_Private_APIUser_0.id == User)
                {
                    return player;
                }
            }
            return null;
            //fix iuser exstensions
        }
    }
}
