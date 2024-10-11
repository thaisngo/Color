using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Scenes : MonoBehaviour
{
    public void ManChoi()
    {
        SceneManager.LoadScene("ManChoi");
    }
    public void ManChoi_Load_Play()
    {
        MaTran_Luoi.instance.QuyDoi();
        MaTran_Luoi.instance.Set_Matran();
        Set_Diem_Cao.Set_Diem(MaTran_Luoi.instance.tong);
        MaTran_Luoi.instance.Set_KhoiO();

        SceneManager.LoadScene("ManChoi");
    }
    public void BatDau()
    {
        if (Time.timeScale == 1)
        {
            MaTran_Luoi.instance.QuyDoi();
            MaTran_Luoi.instance.Set_Matran();
            Set_Diem_Cao.Set_Diem(MaTran_Luoi.instance.tong);
            MaTran_Luoi.instance.Set_KhoiO();
            SceneManager.LoadScene("batDau");
        }
    }
    public void Back_panel()
    {
        Time.timeScale = 1;
        MaTran_Luoi.instance.panel_endGame.SetActive(false);
        for (int y = 0; y < MaTran_Luoi.instance.list_cell.Count; y++)
        {
            MaTran_Luoi.instance.list_cell[y].GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[0];
            MaTran_Luoi.instance.list_cell[y].GetComponent<cell_oTrong_scrips>().id = 0;
        }
        
        Set_Diem_Cao.Set_Diem(MaTran_Luoi.instance.tong);
        Set_Diem_Cao.Set_diemCao();

        PlayerPrefs.DeleteKey("data_game");
        PlayerPrefs.DeleteKey("data_game1");
        PlayerPrefs.DeleteKey("id_mau");
        MaTran_Luoi.instance.button_xoa_O_mau.GetComponent<Image>().sprite = MaTran_Luoi.instance.image_xoa_O_mau[4];

        for (int m = 0; m < MaTran_Luoi.instance.list_Khoi_O.Count; m++)
        {
            MaTran_Luoi.instance.list_Khoi_O.RemoveAt(m);
        }
        MaTran_Luoi.instance.Sinh_Khoi_123(new Vector2(MaTran_Luoi.instance.sizeScreen.x * (-200f / 640), MaTran_Luoi.instance.sizeScreen.y * (-500f / 1136)));
        MaTran_Luoi.instance.Sinh_Khoi_123(new Vector2(0f, MaTran_Luoi.instance.sizeScreen.y * (-500f / 1136)));
        MaTran_Luoi.instance.Sinh_Khoi_123(new Vector2(MaTran_Luoi.instance.sizeScreen.x * (200f / 640), MaTran_Luoi.instance.sizeScreen.y * (-500f / 1136)));

        MaTran_Luoi.instance.trang_thai = 0;
        Set_Diem_Cao.Set_gameOver(MaTran_Luoi.instance.trang_thai);
        MaTran_Luoi.instance.Bat_Tat_gameOver();

        SceneManager.LoadScene("batDau");
    }
    public void ManChoi_Replay()
    {
        Time.timeScale = 1;
        MaTran_Luoi.instance.panel_endGame.SetActive(false);
        for (int i = 0; i < MaTran_Luoi.instance.list_cell.Count; i++)
        {
            MaTran_Luoi.instance.list_cell[i].GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[0];
            MaTran_Luoi.instance.list_cell[i].GetComponent<cell_oTrong_scrips>().id = 0;
        }        
        MaTran_Luoi.instance.Set_Matran();
        Set_Diem_Cao.Set_Diem(0);

        PlayerPrefs.DeleteKey("data_game");
        PlayerPrefs.DeleteKey("data_game1");
        PlayerPrefs.DeleteKey("id_mau");

        MaTran_Luoi.instance.Matran_Luoi_function();
        MaTran_Luoi.instance.Sinh_Khoi_123(new Vector2(MaTran_Luoi.instance.sizeScreen.x * (-200f / 640), MaTran_Luoi.instance.sizeScreen.y * (-500f / 1136)));
        MaTran_Luoi.instance.Sinh_Khoi_123(new Vector2(0f, MaTran_Luoi.instance.sizeScreen.y * (-500f / 1136)));
        MaTran_Luoi.instance.Sinh_Khoi_123(new Vector2(MaTran_Luoi.instance.sizeScreen.x * (200f / 640), MaTran_Luoi.instance.sizeScreen.y * (-500f / 1136)));

        MaTran_Luoi.instance.button_xoa_O_mau.GetComponent<Image>().sprite = MaTran_Luoi.instance.image_xoa_O_mau[4];

        MaTran_Luoi.instance.trang_thai = 0;
        Set_Diem_Cao.Set_gameOver(MaTran_Luoi.instance.trang_thai);
        MaTran_Luoi.instance.Bat_Tat_gameOver();
        SceneManager.LoadScene("ManChoi");
    }
    public void Panel_pause()
    {
        MaTran_Luoi.instance.panel_pause.SetActive(true);
        MaTran_Luoi.instance.text_andgame.GetComponent<Text>().enabled = false;
    }
}
