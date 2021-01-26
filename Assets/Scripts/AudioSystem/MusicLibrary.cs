using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrunchTools.AudioSystem
{
    [RequireComponent(typeof(CrunchTools.AudioSystem.AudioManager))]
    public class MusicLibrary : MonoBehaviour
    {
        [Tooltip("Holds every background music in the game")]
        [Header("Music References")]
        public MusicGroup[] musicGroups;

        public Dictionary<string, AudioClip> musicGroupDictionary = new Dictionary<string, AudioClip>();
        public static Dictionary<AudioClip, string> reversedMusicDict = new Dictionary<AudioClip, string>();

        private void Awake()
        {
            foreach (MusicGroup musicGroup in musicGroups)
            {
                musicGroupDictionary.Add(musicGroup.MusicID, musicGroup.MusicClip);
                reversedMusicDict.Add(musicGroup.MusicClip, musicGroup.MusicID);
            }
        }

        public AudioClip GetClipFromName(string name)
        {
            if (musicGroupDictionary.ContainsKey(name))
            {
                return musicGroupDictionary[name];
            }

            Debug.Log("No clip found by: " + name.ToString() + " in MusicLibrary");
            return null;
        }

        [System.Serializable]
        public class MusicGroup
        {
            [Tooltip("Insert the desired music name")]
            public string MusicID;
            [Tooltip("Insert the music clip assosiated with the name given")]
            public AudioClip MusicClip;
        }
    }
}
