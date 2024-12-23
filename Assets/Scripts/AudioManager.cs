using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    private AudioSource audioSource;

    public List<AudioClip> clipList;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = this;
            instance.Init();
        }
        else
            Destroy(gameObject);
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }

    public void Init()
    {
        Debug.Log("Init AudioManager");
    }

    public void Play(string name)
    {
        AudioClip clip = GetClip(name);
        if (clip != null)
        {
            audioSource.clip = clip;    
        }
        audioSource.Play();
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public AudioClip GetClip(string name)
    {
        foreach (AudioClip clip in clipList)
        {
            if (clip.name == name)
            {
                return clip;
            }
        }
        return null;
    }
}
