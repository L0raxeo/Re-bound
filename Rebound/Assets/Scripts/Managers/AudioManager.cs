using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    //public SaveManager saveManager;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name, bool loop)
    {
        //if (!saveManager.state.sfx)
        //    return;

        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        s.source.loop = loop;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

}
