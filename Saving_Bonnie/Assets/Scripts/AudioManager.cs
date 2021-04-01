/**
* AUTHOR NAME: Eric Goulet
* PROJECT: Save Bonnie (Zombie Tower Defense Game)
* 
*/

using UnityEngine.Audio;
using System;
using UnityEngine;

/*
 * This class allows the game to call and use sounds
 */
public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    // Awake is called as soon as the game is launched
    void Awake()
    {
        //for each sound in the list add their components
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //This method plays on start up (Use for background music)
    void Start()
    {
        //play("theme");
    }

    //this method plays a sound
    public void play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
