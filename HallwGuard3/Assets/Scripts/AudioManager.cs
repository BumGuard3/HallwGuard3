using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXSource;

    public AudioClip FirstPhase;
    public AudioClip SecondPhase;
    public AudioClip Fuze;
    public AudioClip Keys;

    private void Start()
    {
        musicSource.clip = FirstPhase;
        musicSource.Play();
    }

    public void FuzeSFX()
    {
        SFXSource.PlayOneShot(Fuze);
        musicSource.clip = SecondPhase;
        musicSource.Play();
    }

    public void KeysSFX()
    {
        SFXSource.PlayOneShot(Keys);
    }
}
