using UnityEngine;

public class Set_Diem_Cao : MonoBehaviour
{    
    public static void Set_Diem(int score)
    {
        PlayerPrefs.SetInt("tongDiem", score);
        PlayerPrefs.Save();
    }
    public static int GetDiem()
    {
        if (PlayerPrefs.HasKey("tongDiem"))
        {
            int diemSo = PlayerPrefs.GetInt("tongDiem");
            return diemSo;
        }
        return 0;
    }
    public static int Set_diemCao()
    {
        if (GetDiem() > Get_High_Score())
        {
            PlayerPrefs.SetInt("high_Score", GetDiem());
            return GetDiem();
        }
        else
        {
            PlayerPrefs.SetInt("high_Score", Get_High_Score());
            return Get_High_Score();
        }
    }
    public static int Get_High_Score()
    {
        if (PlayerPrefs.HasKey("high_Score"))
        {
            int diemSoCao = PlayerPrefs.GetInt("high_Score");
            return diemSoCao;
        }
        return 0;
    }
    public static void Set_gameOver(int trang_thai)
    {
        PlayerPrefs.SetInt("trang_thai", trang_thai);
        PlayerPrefs.Save();
    }
    public static int Get_gameOver()
    {
        if (PlayerPrefs.HasKey("trang_thai"))
        {
            int trang_Thai = PlayerPrefs.GetInt("trang_thai");
            return trang_Thai;
        }
        return 0;
    }
}
