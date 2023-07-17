using System.Collections;
using System.Collections.Generic;
using InstantGamesBridge.Common;
using UnityEngine;
using UnityEngine.Networking;


public class AudioPlayer : Singleton<AudioPlayer>
{

    private AudioSource sourse1, sourse2;

    private AudioClip _audioClip;

    protected override void Awake()
    {
        base.Awake();

        sourse1 = gameObject.AddComponent<AudioSource>();
        sourse2 = gameObject.AddComponent<AudioSource>();


        sourse1.mute = false;        
        sourse1.volume = 0.3f;
        sourse1.loop = false;

        sourse2.mute = false;

        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {

        yield return new WaitForSecondsRealtime(0.4f);
        string path = Application.streamingAssetsPath + "/backClip.mp3";
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                _audioClip = DownloadHandlerAudioClip.GetContent(www);
                sourse1.clip = _audioClip;
                sourse1.time = 0f;
                sourse1.loop = true;
                sourse1.Play();
            }
        }

    }


    public void SetMuteState(bool stateTemp)
    {
        sourse1.mute = stateTemp;
        sourse2.mute = stateTemp;
    }

    public bool GetMuteState()
    {
        return sourse1.mute;
    }

    public void Play(AudioClip clip)
    {
        if(!sourse1.mute)
        {
            sourse2.PlayOneShot(clip, 0.65f);
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if(!pauseStatus)
        {
            StartCoroutine(Load());
        }
        else
        {
            StopAllCoroutines();
            sourse1.time = 0f;
            sourse1.loop = false;
            sourse1.Stop();
        }

        //Debug.Log("pauseStatus " + pauseStatus);
    }
}
