using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrunchTools.AudioSystem
{
    [RequireComponent(typeof(CrunchTools.AudioSystem.SoundLibrary))]
    [RequireComponent(typeof(CrunchTools.AudioSystem.MusicLibrary))]
    public class AudioManager : MonoBehaviour
    {
        //Esta linea crea un "Singleton" el se utiliza para poder acceder a variables y metodos presentes en este script desde otros scripts
        public static AudioManager Instance;

        public enum AudioChannel { Master, Music, Sfx };

        //Variables porcentuales para controlar los distintos tipos de volumen
        //Ademas, aunque son publicas, solo se les puede hacer Get. Si se desea modificar la informacion de la variable, se debe hacer desde este mismo script
        public float MasterVolumePercent { get; private set; }
        public float MusicVolumePercent { get; private set; }
        public float SfxVolumePercent { get; private set; }

        //AudioSource usado exclusivamente para sonidos 2D
        AudioSource sfx2DSource;

        //Se usa un array de AudioSources para que, si queremos empesar a hacer sonar una musica antes de que termine la anterior (para dar un efecto de "fade out"),
        //podemos utilizar el segundo AudioSource
        AudioSource[] musicSources;
        int activeMusicSourceIndex;
        Transform audioListenerTransform;

        SoundLibrary soundLibrary;
        MusicLibrary musicLibrary;
        AudioClip currentMusic;

        [Tooltip("The AudioListener follows the assigned player")]
        public Transform Player;

        void Awake()
        {
            // Esta condición destruira el objeto si es que ya existe uno presente actualmente.
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                //Previene que se destruya el objeto al cambiar de escena
                DontDestroyOnLoad(gameObject);

                //Necesario para poder utilizar el Singleton
                Instance = this;

                //Destruye todos los listeners extras
                for (int i = 0; i < FindObjectsOfType<AudioListener>().Length; i++)
                {
                    Destroy(FindObjectsOfType<AudioListener>()[i]);
                }

                //Crea un listener
                GameObject listenerGO = new GameObject("AudioListener").AddComponent<AudioListener>().gameObject;
                listenerGO.transform.SetParent(transform);

                //Durante el bucle se crean 2 gameObjects vacios y se les añade el componente de AudioSource (el cual se añade al array "musicSources" en el momento de la creación)
                musicSources = new AudioSource[2];

                for (int i = 0; i < 2; i++)
                {
                    GameObject newMusicSource = new GameObject("Music Source " + (i + 1));
                    musicSources[i] = newMusicSource.AddComponent<AudioSource>();
                    newMusicSource.transform.parent = transform;
                }

                //Crea un nuevo gameobject, le pone un componente de audiosource y, por ultimo, asigna dicho componente a la referencia declarada anteriormente (sfx2DSource)
                GameObject newSoundSource = new GameObject("2D Sound Source ");
                sfx2DSource = newSoundSource.AddComponent<AudioSource>();
                sfx2DSource.transform.parent = transform;

                //Asignacion de Referencias
                audioListenerTransform = FindObjectOfType<AudioListener>().transform;

                soundLibrary = GetComponent<SoundLibrary>();
                musicLibrary = GetComponent<MusicLibrary>();

                //Obtiene los valores almancenados en los playerprefs con un valor default, si es que no existe el key todavia
                MasterVolumePercent = PlayerPrefs.GetFloat("master vol", 1);
                MusicVolumePercent = PlayerPrefs.GetFloat("music vol", 1);
                SfxVolumePercent = PlayerPrefs.GetFloat("sfx vol", 1);
            }
        }

        void Update()
        {
            //Para mover el listener a la misma posicion que el jugador.
            if (Player != null)
                audioListenerTransform.position = Player.position;
        }

        /// <summary>
        /// This is the method used on all the volume sliders.
        /// </summary>
        /// <param name="volumePercent">
        /// Insert the slider.value here
        /// </param>
        /// <param name="channel">
        /// Clarify which channel is the slider modifying
        /// </param>
        public void SetVolume(float volumePercent, AudioChannel channel)
        {
            switch (channel)
            {
                case AudioChannel.Master:
                    MasterVolumePercent = volumePercent;
                    break;
                case AudioChannel.Music:
                    MusicVolumePercent = volumePercent;
                    break;
                case AudioChannel.Sfx:
                    SfxVolumePercent = volumePercent;
                    break;
            }

            //Cambia el volumen de los audiosources
            musicSources[0].volume = MusicVolumePercent * MasterVolumePercent;
            musicSources[1].volume = MusicVolumePercent * MasterVolumePercent;

            //Almacena valores en los playerprefs
            PlayerPrefs.SetFloat("master vol", MasterVolumePercent);
            PlayerPrefs.SetFloat("sfx vol", SfxVolumePercent);
            PlayerPrefs.SetFloat("music vol", MusicVolumePercent);
            PlayerPrefs.Save();
        }

        
        /// <summary>
        /// Plays a music clip with a fade-in effect based on fadeDuration.
        /// </summary>
        /// <param name="clip">
        /// New BGM to play
        /// </param>
        /// <param name="fadeDuration">
        /// Cross-fade between both the previous and the new clip
        /// </param>
        public void PlayMusic(string musicName, float fadeDuration = 1)
        {
            StopAllCoroutines();
            currentMusic = musicLibrary.GetClipFromName(musicName);

            PlayMusic(currentMusic, fadeDuration);
            StartCoroutine(HomemadeInvoke(musicName, fadeDuration));
        }

        /// <summary>
        /// Fetches and plays sounds in a 3D enviroment from the "SoundLibrary" class.
        /// </summary>
        /// <param name="soundName">
        /// Name of the "groupID" sound in the "SoundGroup" class.
        /// </param>
        /// <param name="pos">
        /// Position from where you want to play the sound.
        /// </param>
        public void PlaySound(string soundName, Vector3 pos)
        {
            PlaySound(soundLibrary.GetClipFromName(soundName), pos);
        }

        /// <summary>
        /// Fetches and plays sounds in a 2D enviroment from the "SoundLibrary" class.
        /// </summary>
        /// <param name="soundName">
        /// Name of the "groupID" sound in the "SoundGroup" class.
        /// </param>
        public void PlaySound2D(string soundName)
        {
            sfx2DSource.PlayOneShot(soundLibrary.GetClipFromName(soundName), SfxVolumePercent * MasterVolumePercent);
        }

        #region Private methods
        IEnumerator HomemadeInvoke(string name, float fade)
        {
            yield return new WaitForSeconds(currentMusic.length);

            PlayMusic(name, fade);
        }

        void PlaySound(AudioClip clip, Vector3 pos)
        {
            AudioSource.PlayClipAtPoint(clip, pos, MasterVolumePercent * SfxVolumePercent);
        }

        void PlayMusic(AudioClip clip, float fadeDuration = 1)
        {
            //Una forma de alternar entre 1 y 0
            activeMusicSourceIndex = 1 - activeMusicSourceIndex;

            //Asigna y corre el clip proporcionado en los parametros al AudioSource correcto.
            musicSources[activeMusicSourceIndex].clip = clip;
            musicSources[activeMusicSourceIndex].Play();

            //Necesitamos que el fade ocurra gradualmente, por ende hay que llamar una corutina.
            StartCoroutine(StartMusicFadeInAndOut(fadeDuration));
        }

        //Esta corutina realiza el efecto de bajar el volumen de la musica actual mientras incrementa de forma paulatina la nueva musica que esta a punto de correr.
        IEnumerator StartMusicFadeInAndOut(float duration)
        {
            float percent = 0;

            while (percent < 1)
            {
                //Al dividir la duracion, se acorta o agranda el tiempo que demora "percent" en llegar a 1.
                percent += Time.deltaTime / duration;

                //Esta linea es la que "arranca" el nuevo clip de musica desde volumen "0" y lo incrementa gradualmente hasta el volumen especificado.
                musicSources[activeMusicSourceIndex].volume = Mathf.Lerp(0, MusicVolumePercent * MasterVolumePercent, percent);
                //Esta linea baja el volumen gradualmente de la musica "vieja" a 0.
                musicSources[1 - activeMusicSourceIndex].volume = Mathf.Lerp(MusicVolumePercent * MasterVolumePercent, 0, percent);

                yield return null;
            }
        }
        #endregion
    }
}
