using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerFade : MonoBehaviour
{
    public Image banner;
    public Text bannerText;
    public AudioSource openningSound;
    public float effectTime = 0.5f;
    void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        for(int i=0; i<2; ++i)
        {
            bannerText.CrossFadeAlpha(0, effectTime, false);
            yield return new WaitForSeconds(effectTime);
            bannerText.CrossFadeAlpha(1, effectTime, false);
            yield return new WaitForSeconds(effectTime);
        }
        openningSound.Play();
        banner.CrossFadeAlpha(0, 1, false);
        bannerText.enabled = false;
        yield return new WaitForSeconds(1);
        banner.enabled = false;
    }
}
