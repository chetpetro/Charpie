// Script Written By: Andrew

using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound

{

    public string name;

    // Makes it so the audio you choose can be accessed anywhere
    public AudioClip clip;

    // Creates a range for volume and pitch in the audiomanager
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    // Makes a variable not show up but be serilized.
    [HideInInspector]
    public AudioSource source;

}
