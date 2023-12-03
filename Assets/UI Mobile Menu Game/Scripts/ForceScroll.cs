using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ForceScroll : MonoBehaviour
{

    public ScrollRect scrollview;

    void OnEnable()
    {
        scrollview.verticalNormalizedPosition = 1f;
    }
}
