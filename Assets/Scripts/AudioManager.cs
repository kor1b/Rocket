using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    static AudioManager instance;

    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < sounds.Length; i++)
        {
            Sound s = sounds[i];
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("MainTheme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)//если нет указанного аудиофайла, сообщаем об ошибке
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)//если нет указанного аудиофайла, сообщаем об ошибке
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
    }

    public void CheckPlaying(string name, string name_1)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        Sound s_1 = Array.Find(sounds, sound_1 => sound_1.name == name_1);
        while (s.source.isPlaying && s_1.source.isPlaying)
        {
            return;
        }
        if (!s.source.isPlaying && !s_1.source.isPlaying)
            Play("MainTheme");


    }
}
