using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _damageSound;
    private AudioSource SFXPlayer;

    public void PlayDamageSound(AudioClip damageSound)
    {
        if(SFXPlayer != null && !SFXPlayer.isPlaying)
        {
            SFXPlayer.PlayOneShot(damageSound);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
