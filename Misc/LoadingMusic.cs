using System;
using MelonLoader;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using System.Collections;

namespace HellsingPc.Misc
{
   class LoadingMusic { 
        
        
        static System.Random random = new System.Random();
        static string RandomMusicFile()
        {
        RandomMusicFile:
            string[] musicfiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "/Hellsing/Resources/Music");
            bool filesdeleted = false;
            foreach (string musicfile in musicfiles)
            {
                if (!musicfile.EndsWith(".ogg") && !musicfile.EndsWith(".mp3"))
                {
                   
                    File.Delete(musicfile);
                    filesdeleted = true;
                }
            }
            if (filesdeleted)
            {
                goto RandomMusicFile;
            }
            if (musicfiles.Length == 0)
            {
                throw new Exception("No Audio file Found!");
            }
            if (musicfiles.Length == 1)
            {
                return musicfiles[0];
            }
            int index = random.Next(musicfiles.Length);
            return musicfiles[index - 1];
        }
        public static IEnumerator ChangeLoadingScreen()
        {
            UnityWebRequest www = UnityWebRequest.Get("file://" + RandomMusicFile());
            www.SendWebRequest();
            while (!www.isDone)
            {
                yield return null;
            }
            AudioClip audioClip = WebRequestWWW.InternalCreateAudioClipUsingDH(www.downloadHandler, www.url, false, false, AudioType.UNKNOWN);
            while (!www.isDone || audioClip.loadState == AudioDataLoadState.Loading)
            {
                yield return null;
            }
            if (audioClip != null)
            {
                if (loadingscreenAudio != null)
                {
                    loadingscreenAudio.clip = audioClip;
                    loadingscreenAudio.Play();
                }
            }
        }
        static AudioSource loadingscreenAudio;
        public static IEnumerator LoadingScreen()
        {
            GameObject authentication = GameObject.Find("LoadingBackground_TealGradient_Music/LoadingSound");
            GameObject loadingscreen = GameObject.Find("MenuContent/Popups/LoadingPopup/LoadingSound");
            if (authentication != null)
            {
                authentication.GetComponent<AudioSource>().Stop();
            }
            if (loadingscreen != null)
            {
                loadingscreenAudio = loadingscreen.GetComponent<AudioSource>();
                loadingscreenAudio.Stop();
            }
            UnityWebRequest www = UnityWebRequest.Get("file://" + RandomMusicFile());
            www.SendWebRequest();
            while (!www.isDone)
            {
                yield return null;
            }
            AudioClip audioClip = WebRequestWWW.InternalCreateAudioClipUsingDH(www.downloadHandler, www.url, false, false, AudioType.UNKNOWN);
            while (!www.isDone || audioClip.loadState == AudioDataLoadState.Loading)
            {
                yield return null;
            }
            if (audioClip != null)
            {
                if (authentication != null)
                {
                    authentication.GetComponent<AudioSource>().clip = audioClip;
                    authentication.GetComponent<AudioSource>().Play();
                }
                if (loadingscreenAudio != null)
                {
                    loadingscreenAudio.clip = audioClip;
                    loadingscreenAudio.Play();
                }
            }
        }
    }
}