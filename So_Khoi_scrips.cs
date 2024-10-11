using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class So_Khoi_scrips : MonoBehaviour
{
    public static void Set_So_Khoi()
    {
        PlayerPrefs.SetInt("so_KhoiO", MaTran_Luoi.instance.list_Khoi_O.Count);
        PlayerPrefs.Save();
    }
    public static int Get_So_Khoi()
    {
        if (PlayerPrefs.HasKey("so_KhoiO"))
        {
            int So_Khoi = PlayerPrefs.GetInt("so_KhoiO");
            return So_Khoi;
        }
        return 0;
    }
}
