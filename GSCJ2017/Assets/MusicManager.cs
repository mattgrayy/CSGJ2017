using UnityEngine;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour {

    [SerializeField] List<AudioClip> music = new List<AudioClip>();

    AudioSource mySource;

    void Start()
    {
        mySource = GetComponent<AudioSource>();
    }


	void Update ()
    {
        if (mySource != null)
        {
            if (!mySource.isPlaying)
            {
                int randClip = Random.Range(0, music.Count);
                mySource.clip = music[randClip];
                mySource.Play();
            }
            mySource.pitch = 1 + ((-50 + GameManager.m_instance.globalStress) / 500);
        }
	}
}
