using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 1.5f;
    [SerializeField] ParticleSystem crashEffect ;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Ground" && !hasCrashed)
        { 
            hasCrashed = true;
            Invoke("ReloadScene", loadDelay);
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
           
        
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
