using UnityEngine;

public  class AudioCaller : MonoBehaviour
{
    private AudioSource MainChannel;

    [SerializeField] private AudioClip ClickSound;
    [SerializeField] private AudioClip PaperSound;
    [SerializeField] private AudioClip BellSound;
    [SerializeField] private AudioClip RockSound;

    private void Awake()
    {
        MainChannel = GetComponent<AudioSource>();
    }

    public void PlayClick()
    {
        MainChannel.PlayOneShot(ClickSound);
    }

    public void PlayPaper()
    {
        MainChannel.PlayOneShot(PaperSound);
    }

    public void PlayBell()
    {
        MainChannel.PlayOneShot(BellSound);
    }

    public void PlayRock()
    {
        MainChannel.PlayOneShot(RockSound);
    }
}
