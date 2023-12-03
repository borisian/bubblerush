using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSoundButton : MonoBehaviour
{
    public Button Btn;

    void Start()
    {
        Btn = GetComponent<Button>();
        Btn.onClick.AddListener(() => UI.instance.PlayAudioEffects());
    }
}
