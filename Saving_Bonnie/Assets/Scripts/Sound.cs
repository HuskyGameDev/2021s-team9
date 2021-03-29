/**
* AUTHOR NAME: Eric Goulet
* PROJECT: Save Bonnie (Zombie Tower Defense Game)
* 
*/

using UnityEngine.Audio;
using UnityEngine;

/*
 * This class allows the creation of sound objects
 */
[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;

    //sliders for volume and pitch
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
