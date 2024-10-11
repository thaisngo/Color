using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score_manChoi : MonoBehaviour, I_GiaoDienDaManHinh
{
    public Text diemText_endGame;
    public Text diemText_HighScore;
    void Start()
    {
        GiaoDien_UI();        
        bool check = false;
        for (int i = 0; i < MaTran_Luoi.instance.list_cell.Count; i++)
        {
            if (MaTran_Luoi.instance.list_cell[i].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0] && MaTran_Luoi.instance.list_cell[i].GetComponent<cell_oTrong_scrips>().id == 0)
            {
                check = false;
            }

            else
            {
                check = true;
                break;
            }
        }

        if (check == false)
        {
            Set_Diem_Cao.Set_Diem(0);
            MaTran_Luoi.instance.tong = 0;
        }
        else
        {
            MaTran_Luoi.instance.tong = Set_Diem_Cao.GetDiem();
        }
        diemText_endGame.text = "" + Set_Diem_Cao.GetDiem();
    }

    private void Update()
    {
        diemText_HighScore.text = "" + Set_Diem_Cao.Get_High_Score();
    }

    public void GiaoDien_UI()
    {
        diemText_endGame.GetComponent<RectTransform>().sizeDelta = new Vector2(MaTran_Luoi.instance.sizeScreen.x * (200f / 640), MaTran_Luoi.instance.sizeScreen.y * (50f / 1136));
        diemText_endGame.GetComponent<RectTransform>().anchoredPosition = new Vector2(MaTran_Luoi.instance.sizeScreen.x * (-70f / 640), MaTran_Luoi.instance.sizeScreen.y * (500f / 1136));
        diemText_endGame.GetComponent<Text>().fontSize = (int)(MaTran_Luoi.instance.sizeScreen.x * (40f / 640));

        diemText_HighScore.GetComponent<RectTransform>().sizeDelta = new Vector2(MaTran_Luoi.instance.sizeScreen.x * (200f / 640), MaTran_Luoi.instance.sizeScreen.y * (50f / 1136));
        diemText_HighScore.GetComponent<RectTransform>().anchoredPosition = new Vector2(MaTran_Luoi.instance.sizeScreen.x * (70f / 640), MaTran_Luoi.instance.sizeScreen.y * (500f / 1136));
        diemText_HighScore.GetComponent<Text>().fontSize = (int)(MaTran_Luoi.instance.sizeScreen.x * (40f / 640));
    }
}
