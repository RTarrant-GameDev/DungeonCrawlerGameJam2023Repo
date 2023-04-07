using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioClip[] audioClips;

    // Update is called once per frame
    void Update() {
        CheckGameState();
        this.gameObject.GetComponent<AudioSource>().loop = true;

        if(!this.gameObject.GetComponent<AudioSource>().isPlaying) {
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    void CheckGameState() {
        switch(StateManager.InstanceRef.GameState) {
            case gameState.MainMenu:
                this.gameObject.GetComponent<AudioSource>().clip = audioClips[0];
                break;

            case gameState.Cinematic:
                this.gameObject.GetComponent<AudioSource>().clip = audioClips[1];
                break;

            case gameState.GameOver:
                this.gameObject.GetComponent<AudioSource>().clip = audioClips[2];
                break;
            
            case gameState.Play:
                this.gameObject.GetComponent<AudioSource>().clip = audioClips[3];
                break;

            default:
                break;
        }     
    }
}
