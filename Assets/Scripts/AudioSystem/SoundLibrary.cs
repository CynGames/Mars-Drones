using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrunchTools.AudioSystem
{
    [RequireComponent(typeof(CrunchTools.AudioSystem.AudioManager))]
    public class SoundLibrary : MonoBehaviour
    {
        [Tooltip("Insert the amount of type of sounds")]
        [Header("Sound References")]
        public SoundGroup[] soundGroups;

        Dictionary<string, AudioClip[]> soundGroupDictionary = new Dictionary<string, AudioClip[]>();

        void Awake()
        {
            foreach (SoundGroup soundGroup in soundGroups)
            {
                soundGroupDictionary.Add(soundGroup.groupID, soundGroup.group);
            }
        }

        //Metodo que devuelve un AudioClip en base a un nombre
        public AudioClip GetClipFromName(string name)
        {
            if (soundGroupDictionary.ContainsKey(name))
            {
                AudioClip[] sounds = soundGroupDictionary[name];
                return sounds[Random.Range(0, sounds.Length)];
            }

            Debug.Log("No clip found by: " + name.ToString() + " in SoundLibrary");
            return null;
        }

        //Clase para guardar todos los sonidos individuales bajo un grupo
        [System.Serializable]
        public class SoundGroup
        {
            [Tooltip("Insert the desired sound name")]
            public string groupID;

            [Tooltip("Insert the sound clips. One of them will be played at random when the PlaySound method is called.")]
            public AudioClip[] group;
        }
    }
}
