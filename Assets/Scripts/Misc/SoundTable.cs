using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SoundTable", menuName = "ScriptableObjects/SoundTable", order = 1)]
public class SoundTable : ScriptableObject
{
    public List<AudioClip> sounds = new List<AudioClip>();
}