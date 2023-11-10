using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] AudioSource m_dashSound;
    [SerializeField] AudioSource m_stepSound;

    public void PlayStepSound()
    {
        if (m_stepSound.isPlaying) return;
        m_stepSound.Play();
    }

    public void PlayDashSound()
    {
        m_dashSound.Play();
    }
}
