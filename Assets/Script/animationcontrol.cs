using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationcontrol : MonoBehaviour
{
    public Animation Ani;
    List<string> animArray;
    Renderer cat;

    public void AnimationArray() // 애니메이션 컴포넌트의 Animations를 리스트로 저장합니다.
    {
        foreach (AnimationState state in Ani)
        {
            animArray.Add(state.name);
            Ani[state.name].speed = 0.25f;
        }
    }

    public void basic()//각 감정마다 감정리스트를 분할해 랜덤으로 취할 수 있도록합니다.
    {
        Ani.Play(animArray[Random.Range(0, 1)]);
        cat.sharedMaterial.mainTexture = Resources.Load("texture/basic") as Texture;
    }
    public void angry()
    {
        Ani.Play(animArray[Random.Range(1, 3)]);
        cat.sharedMaterial.mainTexture = Resources.Load("texture/angry") as Texture;
    }
    public void aversion()
    {
        Ani.Play(animArray[Random.Range(3, 5)]);
        cat.sharedMaterial.mainTexture = Resources.Load("texture/fear_aversion") as Texture;
    }
    public void cold()
    {
        Ani.Play(animArray[Random.Range(5, 7)]);
        cat.sharedMaterial.mainTexture = Resources.Load("texture/cold") as Texture;
    }
    public void fear()
    {
        Ani.Play(animArray[Random.Range(7, 9)]);
        cat.sharedMaterial.mainTexture = Resources.Load("texture/fear_aversion") as Texture;
    }
    public void happy()
    {
        Ani.Play(animArray[Random.Range(9, 12)]);
        cat.sharedMaterial.mainTexture = Resources.Load("texture/happy") as Texture;
    }
    public void hot()
    {
        Ani.Play(animArray[Random.Range(12, 13)]);
        cat.sharedMaterial.mainTexture = Resources.Load("texture/hot") as Texture;
    }
    public void omg()
    {
        Ani.Play(animArray[Random.Range(13, 15)]);
        cat.sharedMaterial.mainTexture = Resources.Load("texture/omg") as Texture;
    }
    public void sad()
    {
        Ani.Play(animArray[Random.Range(15, 17)]);
        cat.sharedMaterial.mainTexture = Resources.Load("texture/sad") as Texture;
    }
    public void trust()
    {
        Ani.Play(animArray[17]);
        cat.sharedMaterial.mainTexture = Resources.Load("texture/epect_trust") as Texture;
    }
    public void epect()
    {
        Ani.Play(animArray[18]);
        cat.sharedMaterial.mainTexture = Resources.Load("texture/epect_trust") as Texture;
    }

    //public void aaa()
    //{
    //    if (!Ani.IsPlaying("basic"))
    //    {
    //        Ani.CrossFade("basic");
    //    }
    // }

    void Start()
    {
        animArray = new List<string>();
        AnimationArray();
        cat = GetComponent<Renderer>();
        StartCoroutine(idlemotion()); //n초마다 최상위감정 모션 실행
    }

    IEnumerator idlemotion()
    {
        while (true)
        {
            if (Chat.temp == 0) happy();
            if (Chat.temp == 1) trust();
            if (Chat.temp == 2) fear();
            if (Chat.temp == 3) epect();
            if (Chat.temp == 4) omg();
            if (Chat.temp == 5) sad();
            if (Chat.temp == 6) aversion();
            if (Chat.temp == 7) angry();
            yield return new WaitForSeconds(30);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Chat.yn1 == true)
        {
            happy();
            Chat.yn1 = false;
        }
        if (Chat.yn2 == true)
        {
            trust();
            Chat.yn2 = false;
        }
        if (Chat.yn3 == true)
        {
            fear();
            Chat.yn3 = false;
        }
        if (Chat.yn4 == true)
        {
            epect();
            Chat.yn4 = false;
        }
        if (Chat.yn5 == true)
        {
            omg();
            Chat.yn5 = false;
        }
        if (Chat.yn6 == true)
        {
            sad();
            Chat.yn6 = false;
        }
        if (Chat.yn7 == true)
        {
            aversion();
            Chat.yn7 = false;
        }
        if (Chat.yn8 == true)
        {
            angry();
            Chat.yn8 = false;
        }
        if (Chat.hot == true)
        {
            hot();
            Chat.hot = false;
        }
        if (Chat.cold == true)
        {
            cold();
            Chat.cold = false;
        }
        if (Chat.snow == true)
        {
            happy();
            Chat.snow = false;
        }
        if (Chat.rain == true)
        {
            fear();
            Chat.rain = false;
        }
        if (Chat.good == true)
        {
            happy();
            Chat.good = false;
        }
        if (Chat.bad == true)
        {
            fear();
            Chat.bad = false;
        }

        if (Input.GetKey(KeyCode.Alpha1)) basic();
        if (Input.GetKey(KeyCode.Alpha2)) angry();
        if (Input.GetKey(KeyCode.Alpha3)) aversion();
        if (Input.GetKey(KeyCode.Alpha4)) cold();
        if (Input.GetKey(KeyCode.Alpha5)) fear();
        if (Input.GetKey(KeyCode.Alpha6)) happy();
        if (Input.GetKey(KeyCode.Alpha7)) hot();
        if (Input.GetKey(KeyCode.Alpha8)) omg();
        if (Input.GetKey(KeyCode.Alpha9)) sad();
        if (Input.GetKey(KeyCode.Alpha0)) epect();
    }
}
