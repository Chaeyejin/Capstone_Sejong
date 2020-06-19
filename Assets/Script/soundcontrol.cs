using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundcontrol : MonoBehaviour
{
    AudioSource source;
    public AudioClip[] sound;

    public void angry()
    {
       GetComponent<AudioSource>().clip = sound[0];
       GetComponent<AudioSource>().Play();
       GetComponent<AudioSource>().loop = false;
    }

    public void aversion()
    {
        GetComponent<AudioSource>().clip = sound[1];
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = false;
    }

    public void aversion2()
    {
        GetComponent<AudioSource>().clip = sound[2];
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = false;
    }

    public void cold1()
    {
        GetComponent<AudioSource>().clip = sound[3];
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = false;
    }

    public void cold2()
    {
        GetComponent<AudioSource>().clip = sound[4];
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = false;
    }

    public void expect()
    {
        GetComponent<AudioSource>().clip = sound[Random.Range(5, 7)];
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = false;
    }

    public void fear()
    {
        GetComponent<AudioSource>().clip = sound[7];
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = false;
    }

    public void happy()
    {
        GetComponent<AudioSource>().clip = sound[8];
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = false;
    }

    public void hot()
    {
        GetComponent<AudioSource>().clip = sound[9];
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = false;
    }

    public void omg1()
    {
        GetComponent<AudioSource>().clip = sound[10];
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = false;
    }

    public void omg2()
    {
        GetComponent<AudioSource>().clip = sound[11];
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = false;
    }

    public void sad()
    {
        GetComponent<AudioSource>().clip = sound[12];
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
