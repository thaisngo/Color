using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Get_Diem_Cao : MonoBehaviour, I_GiaoDienDaManHinh
{
    public Text diemText_HighScore;
    public GameObject button_play;
    public GameObject button_cheDo;
    public GameObject button_ad;
    public GameObject cup;

    public Canvas cv;
    private Vector2 sizeScreen;
    void Start()
    {
        sizeScreen = cv.GetComponent<RectTransform>().sizeDelta;
        GiaoDien_UI();
        diemText_HighScore.text = "" + Set_Diem_Cao.Get_High_Score();
    }
    public void GiaoDien_UI()
    {
        diemText_HighScore.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * (500f / 640), sizeScreen.y * (100f / 1136));
        diemText_HighScore.GetComponent<Text>().fontSize = (int)(sizeScreen.x * (80f / 640));
        diemText_HighScore.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, sizeScreen.y * (200f / 1136));

        button_play.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * (380f / 640), sizeScreen.y * (150f / 1136));
        button_play.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);

        button_cheDo.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * (180f / 640), sizeScreen.y * (100f / 1136));
        button_cheDo.GetComponent<RectTransform>().anchoredPosition = new Vector2(sizeScreen.x * (-100f / 640), sizeScreen.y * (-150f / 1136));

        button_ad.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * (180f / 640), sizeScreen.y * (100f / 1136));
        button_ad.GetComponent<RectTransform>().anchoredPosition = new Vector2(sizeScreen.x * (100f / 640), sizeScreen.y * (-150f / 1136));

        cup.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * (100f / 640), sizeScreen.y * (100f / 1136));
        cup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, sizeScreen.y * (300f / 1136));
    }
}
