﻿using System;
using System.Net;
using System.Threading.Tasks;
using MelonLoader;
using HellsingPc.Menu;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.DataModel;
using Wrappers;
using HellsingPc.Patches;

namespace HellsingPc.Menu
{
    internal class SelfShit
    {
        public static void FlipHead()
        {
            SelfShit.orgin = PlayerWrapper.LocalPlayer.GetComponent<GamelikeInputController>().field_Protected_NeckMouseRotator_0.field_Public_NeckRange_0;
            PlayerWrapper.LocalPlayer.GetComponent<GamelikeInputController>().field_Protected_NeckMouseRotator_0.field_Public_NeckRange_0 = new NeckRange(float.MinValue, float.MaxValue, 0f);
        }

        public static void ResetHead()
        {
            PlayerWrapper.LocalPlayer.GetComponent<GamelikeInputController>().field_Protected_NeckMouseRotator_0.field_Public_NeckRange_0 = SelfShit.orgin;
        }

        public static void HideSelfOn()
        {
            SelfShit.backupID = PlayerWrapper.LocalVRCPlayer().GetAPIAvatar().id;
            PlayerWrapper.LocalPlayer.SetHide(true);
        }

        public static void HideSelfOff()
        {
            PlayerWrapper.ChangeAvatar(SelfShit.backupID);
            PlayerWrapper.LocalPlayer.SetHide(false);
        }

        public static void AVIID()
        {
            MelonLogger.Msg("[NOTICE] Make sure to have an avatar ID copied to your clipboard!");
            if (SendToClip.GetClipboard().StartsWith("avtr"))
            {
                PlayerWrapper.ChangeAvatar(SendToClip.GetClipboard());
                MelonLogger.Msg("Changed Avatar By ID");
                return;
            }
            MelonLogger.Msg("[ERROR] Failed to send ID");
        }

        public static void DefaultAVI()
        {
            PlayerWrapper.ChangeAvatar("avtr_090e5162-4fe2-4105-8b52-f6f7b7bc68c3");
        }

        public static void AssetKill()
        {
            SelfShit.backupID = APIUser.CurrentUser.avatarId;
            PlayerWrapper.LocalVRCPlayer().SetHide(true);
            PlayerWrapper.ChangeAvatar("avtr_513ada25-c3dc-46a2-b8ec-91f94dc6ce1b");
        }

        public static void AssetKillOff()
        {
            PlayerWrapper.ChangeAvatar(SelfShit.backupID);
            PlayerWrapper.LocalVRCPlayer().SetHide(false);
        }

        public static void StopQuestAssetKill()
        {
            PlayerWrapper.ChangeAvatar(SelfShit.backupID);
            PlayerWrapper.LocalVRCPlayer().SetHide(false);
        }

        public static void StartQuestAssetKill()
        {
            SelfShit.backupID = APIUser.CurrentUser.avatarId;
            PlayerWrapper.LocalVRCPlayer().SetHide(true);
            PlayerWrapper.ChangeAvatar("avtr_c8c463ab-2421-41b0-aa99-f12c821eb0b1");
        }

        public static void TPOSE()
        {
            Animator field_Internal_Animator_ = Player.Method_Internal_Static_Player_0()._vrcplayer.field_Internal_Animator_0;
            field_Internal_Animator_.enabled = !field_Internal_Animator_.enabled;
        }

        private static NeckRange orgin;

        private static string backupID;
    }
}
