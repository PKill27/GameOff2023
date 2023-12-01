using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iInteractablee : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartAnimation()
    {
        anim.SetTrigger("FadeIn");
    }
    public void EndAnimation()
    {
        anim.SetTrigger("FadeOut");
    }
}
