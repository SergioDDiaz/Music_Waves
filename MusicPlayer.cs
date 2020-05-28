using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] clips;
    private int ind = 0;
    private AudioSource player;
    public Text title;
    public Text timer;



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioSource>();
        player.clip = clips[ind];
        title.text = player.clip.name;
    }
    public void Play()
    {
        if (CheckNullSong()) return;
        if (!player.isPlaying)
        {
            player.Play();
        } else
        {
            player.Pause();
        }
         
    }
    public void Stop()
    {
        player.Stop();
    }
    public void Next()
    {
        player.clip = clips[++ind % clips.Length];
        if (CheckNullSong()) return;
        player.Play();
    }
    public void Prev()
    {
        if (--ind < 0) ind = clips.Length - 1;
        player.clip = clips[ind % clips.Length];
        if (CheckNullSong()) return;
        player.Play();
    }
    // Update is called once per frame
    void Update()
    {
        int minutes = (int)player.time / 60;
        int seconds = (int)player.time % 60;
        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        title.text = player.clip.name;
    }
    bool CheckNullSong()
    {
        if (player.clip == null)
        {
            Debug.Log("Null Song");
            return true;
        }
        return false;
    }
}
