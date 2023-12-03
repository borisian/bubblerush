using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleOptions : MonoBehaviour
{
    public Toggle music;
    public Toggle sound;
        
    public Image imgToggleMusic;
    public Image imgToggleSound;

    public Sprite toggleOn;
    public Sprite toggleOff;

    public TextMeshProUGUI textMusicToggle;
    public TextMeshProUGUI textSoundToggle;

    public void ChangeToggle(int idtoggle)
    {
        if(idtoggle == 0)
        {
            UI.instance.PlayAudioEffects();
            if (music.isOn)
            {
                imgToggleMusic.sprite = toggleOn;
                textMusicToggle.text = "On";
                if (!UI.instance.Music.isPlaying)
                {
                    UI.instance.Music.enabled = true;
                }
            }
            else
            {
                imgToggleMusic.sprite = toggleOff;
                textMusicToggle.text = "Off";
                if (UI.instance.Music.isPlaying)
                {
                    UI.instance.Music.enabled = false;
                }
            }
        }
        else
        {
            UI.instance.PlayAudioEffects();
            if (sound.isOn)
            {
                imgToggleSound.sprite = toggleOn;
                textSoundToggle.text = "On";
                UI.instance.audioEffects.enabled = true;
            }
            else
            {
                imgToggleSound.sprite = toggleOff;
                textSoundToggle.text = "Off";
                UI.instance.audioEffects.enabled = false;
            }
        }
    }
}
