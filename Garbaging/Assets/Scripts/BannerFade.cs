using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerFade : MonoBehaviour
{
    public Image banner;
    public Text banner_text;
    public float effect_time;
    void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        for(int i=0; i<2; ++i)
        {
            banner_text.CrossFadeAlpha(0, 1, false);
            yield return new WaitForSeconds(effect_time);
            banner_text.CrossFadeAlpha(1, 1, false);
            yield return new WaitForSeconds(effect_time);
        }
        banner.CrossFadeAlpha(0, 1, false);
        banner_text.enabled = false;
    }
}
