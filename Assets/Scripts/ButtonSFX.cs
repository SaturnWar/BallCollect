using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    [Header("Источник звука")]
    [SerializeField] private AudioSource _sfxSource;
    [Header("Звук нажатия")]
    [SerializeField] private AudioClip _audioClip_1;
    [Header("Звук наведения")]
    [SerializeField] private AudioClip _audioClip_2;
    public void ClickSound()
    {
        _sfxSource.PlayOneShot(_audioClip_1);
    }
    public void EnterSound()
    {
        _sfxSource.PlayOneShot(_audioClip_2);
    }
}
