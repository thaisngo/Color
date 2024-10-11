using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class main_scenes_Start : MonoBehaviour, I_GiaoDienDaManHinh
{
    public Canvas cv;
    public Vector2 sizeScreen;
    public AudioSource audio_nhac_nen_start;
    public GameObject panel_ads;
    public GameObject button_home;
    public GameObject button_remove_ads;
    public GameObject thong_bao;
    public GameObject text;
    void Start()
    {
        sizeScreen = cv.GetComponent<RectTransform>().sizeDelta;
        audio_nhac_nen_start.Play();
        if (Save_Che_Do.Get_id_Audio() == 1)
        {
            audio_nhac_nen_start.Stop();
        }
        GiaoDien_UI();
    }

    public void GiaoDien_UI()
    {
        panel_ads.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x, sizeScreen.y);
        panel_ads.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);

        button_home.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * (150f / 640), sizeScreen.x * (150f / 640));
        button_home.GetComponent<RectTransform>().anchoredPosition = new Vector2(sizeScreen.x * (-100f / 640), sizeScreen.y * (-50f / 1136));

        button_remove_ads.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * (150f / 640), sizeScreen.x * (150f / 640));
        button_remove_ads.GetComponent<RectTransform>().anchoredPosition = new Vector2(sizeScreen.x * (100f / 640), sizeScreen.y * (-50f / 1136));

        thong_bao.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x, sizeScreen.y * (150f / 1136));
        thong_bao.GetComponent<RectTransform>().anchoredPosition = new Vector2(sizeScreen.x * (0f / 640), sizeScreen.y * (120f / 1136));

        text.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x, sizeScreen.y * (150f / 1136));
        text.GetComponent<Text>().fontSize = (int)(sizeScreen.y * (30f / 1136));
    }
}
