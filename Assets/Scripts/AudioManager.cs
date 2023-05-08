using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] public AudioClip EnShootHit;
    [SerializeField] public AudioClip ShootHit;
    [SerializeField] public AudioClip HealHit;
    [SerializeField] public AudioClip TimeHit;
    [SerializeField] public AudioClip JumpHit;
    [SerializeField] public AudioClip DeathHit;
    [SerializeField] public AudioSource Soundtrack;
    [SerializeField] public AudioClip Coin;
    [SerializeField] public AudioClip Pizza;
    [SerializeField] public AudioClip Win;





    private AudioSource Source;

    private void Awake()
    {
        Soundtrack.loop = true;
        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;

        Source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip, float volume = 1.0f)
    {
        Source.PlayOneShot(clip, volume);
    }
}

