using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class VolumeValue : MonoBehaviour
{
    public GameObject BGMusic;  
    private AudioSource audioSrc;
    public static float musicVolume; 
    public Slider VolValue; 
    public GameObject[] objs1;
    private static int randomMusic = 0;
    
    void Awake() {
        objs1 = GameObject.FindGameObjectsWithTag("Sound"); 
        if (objs1.Length == 0)
        {
            BGMusic = Instantiate(BGMusic); 
            BGMusic.name = "BGMusic";  
            DontDestroyOnLoad(BGMusic.gameObject); 
        } else {
            BGMusic = GameObject.Find("BGMusic"); 
        }
        if (!PlayerPrefs.HasKey("MusicVol")) {
            musicVolume = 0.1f;  
        } else {
            musicVolume = PlayerPrefs.GetFloat("MusicVol"); 
            VolValue.value = PlayerPrefs.GetFloat("MusicVol"); 
        }
        
    }
    void Start()
    {
        audioSrc = BGMusic.GetComponent<AudioSource>();
        if (randomMusic < 1)
        {
            audioSrc.time = Random.Range(0f, 2000f);
            randomMusic++;
        }
    }
 
    
    void Update()
    {
        audioSrc.volume = musicVolume; 
    }
 
    public void SetVolume(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("MusicVol", vol); 
    }
}