using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateClouds : MonoBehaviour
{
    public GameObject[] clouds;

    void OnEnable()
    {
        StopCoroutine("CreateCloud");
        StartCoroutine(CreateCloud(1));
    }

    void Start()
    {
        StartCoroutine(CreateCloud(1));
    }

    IEnumerator CreateCloud(int time)
    {
        yield return new WaitForSeconds(time);
        GameObject cloud = Instantiate(clouds[Random.Range(0, clouds.Length)]);
        cloud.transform.SetParent(this.transform);
        cloud.transform.localScale = Vector3.one;
        cloud.transform.localPosition = new Vector3(-400f, Random.Range(-70f, 275f), 0f);
        cloud.GetComponent<moveCloud>().speed = Random.Range(0.01f, 0.1f);
        StopCoroutine("CreateCloud");
        StartCoroutine(CreateCloud(Random.Range(0, 5)));
    }
}
