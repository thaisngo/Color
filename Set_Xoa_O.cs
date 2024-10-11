using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Set_Xoa_O : MonoBehaviour
{
    public static void Set_id_Image()
    {
        if (MaTran_Luoi.instance.button_xoa_O_mau.GetComponent<Image>().sprite == MaTran_Luoi.instance.image_xoa_O_mau[0])
        {
            PlayerPrefs.SetInt("id_mau", 0);
            PlayerPrefs.Save();
        }

        else if (MaTran_Luoi.instance.button_xoa_O_mau.GetComponent<Image>().sprite == MaTran_Luoi.instance.image_xoa_O_mau[1])
        {
            PlayerPrefs.SetInt("id_mau", 1);
            PlayerPrefs.Save();
        }

        else if (MaTran_Luoi.instance.button_xoa_O_mau.GetComponent<Image>().sprite == MaTran_Luoi.instance.image_xoa_O_mau[2])
        {
            PlayerPrefs.SetInt("id_mau", 2);
            PlayerPrefs.Save();
        }

        else if (MaTran_Luoi.instance.button_xoa_O_mau.GetComponent<Image>().sprite == MaTran_Luoi.instance.image_xoa_O_mau[3])
        {
            PlayerPrefs.SetInt("id_mau", 3);
            PlayerPrefs.Save();
        }

        else
        {
            PlayerPrefs.SetInt("id_mau", 4);
            PlayerPrefs.Save();
        }
    }
    public static int Get_id_Image()
    {
        if (PlayerPrefs.HasKey("id_mau"))
        {
            int idmau = PlayerPrefs.GetInt("id_mau");
            return idmau;
        }
        return 4;
    }
}
