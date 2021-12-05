using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static AudioClip explosion, hit, shoot, playerDead, bg, death;

    public static AudioSource audioSrc;

    private void Start() {

        explosion = Resources.Load<AudioClip> ("explosion");
        hit = Resources.Load<AudioClip> ("hit");
        shoot = Resources.Load<AudioClip> ("shoot");
        playerDead = Resources.Load<AudioClip> ("playerDead");
        bg = Resources.Load<AudioClip> ("Rasputin Remix");
        death = Resources.Load<AudioClip> ("Game Over");

        audioSrc = GetComponent<AudioSource> ();

        PlaySound("bg");
    }

    public static void PlaySound(string clip) {

        switch (clip) {
            case "explosion":
                audioSrc.PlayOneShot(explosion);
                break;
            case "hit":
                audioSrc.PlayOneShot(hit);
                break;
            case "shoot":
                audioSrc.PlayOneShot(shoot);
                break;
            case "playerDead":
                audioSrc.PlayOneShot(playerDead);
                break;
            case "bg":
                audioSrc.PlayOneShot(bg);
                break;
            case "death":
                audioSrc.PlayOneShot(death);
                break;
        }
    }
}
