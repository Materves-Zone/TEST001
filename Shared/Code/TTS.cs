using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip[] Clips;
    private AudioSource audioSource;

    private void Init()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void TTSRePlay(int ClipID)
    {
        StartCoroutine(Replay(ClipID));
    }
    IEnumerator Replay(int ClipsID)
    {
        audioSource.PlayOneShot(Clips[ClipsID]);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(Clips[ClipsID]);
        yield return new WaitForSeconds(2f);

        StopCoroutine(Replay(ClipsID));
    }

    public void TTSExiPlay()
    {
        StartCoroutine(ExiReplay());
    }
    IEnumerator ExiReplay()
    {

        audioSource.PlayOneShot(Clips[4]);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(Clips[4]);
        yield return new WaitForSeconds(4f);
        audioSource.PlayOneShot(Clips[5]);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(Clips[5]);

    }

    public void TTSStop()
    {
        audioSource.Stop();
    }
}
