using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCloud : MonoBehaviour
{
    public float speed;

    void Update()
    {
        GetComponent<RectTransform>().localPosition = Vector3.Lerp(transform.localPosition, new Vector3(800f, GetComponent<RectTransform>().localPosition.y, GetComponent<RectTransform>().localPosition.z), Time.deltaTime * speed);
        if(GetComponent<RectTransform>().localPosition.x >= 600f)
        {
            Destroy(this.gameObject);
        }
    }
}
