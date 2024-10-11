using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Save_Che_Do : MonoBehaviour
{
    public static void Set_id_Sang_Toi()
    {
        if (MaTran_Luoi.instance.che_do.GetComponent<Image>().sprite == MaTran_Luoi.instance.image_che_do_sang_toi[0])
        {
            PlayerPrefs.SetInt("id_che_do", 0);
            PlayerPrefs.Save();
        }

        else if (MaTran_Luoi.instance.che_do.GetComponent<Image>().sprite == MaTran_Luoi.instance.image_che_do_sang_toi[1])
        {
            PlayerPrefs.SetInt("id_che_do", 1);
            PlayerPrefs.Save();
        }
    }

    public static int Get_id_Sang_Toi()
    {
        if (PlayerPrefs.HasKey("id_che_do"))
        {
            int idchedo = PlayerPrefs.GetInt("id_che_do");
            return idchedo;
        }
        return 3;
    }

    public static void Set_id_Audio()
    {
        if (MaTran_Luoi.instance.loa.GetComponent<Image>().sprite == MaTran_Luoi.instance.image_audio[0])
        {
            PlayerPrefs.SetInt("id_audio", 0);
            PlayerPrefs.Save();
        }

        else if (MaTran_Luoi.instance.loa.GetComponent<Image>().sprite == MaTran_Luoi.instance.image_audio[1])
        {
            PlayerPrefs.SetInt("id_audio", 1);
            PlayerPrefs.Save();
        }
    }

    public static int Get_id_Audio()
    {
        if (PlayerPrefs.HasKey("id_audio"))
        {
            int idchedo = PlayerPrefs.GetInt("id_audio");
            return idchedo;
        }
        return 3;
    }

    public static void Set_id_rung()
    {
        if (MaTran_Luoi.instance.che_do_rung.GetComponent<Image>().sprite == MaTran_Luoi.instance.image_rung[0])
        {
            PlayerPrefs.SetInt("id_rung", 0);
            PlayerPrefs.Save();
        }

        else if (MaTran_Luoi.instance.che_do_rung.GetComponent<Image>().sprite == MaTran_Luoi.instance.image_rung[1])
        {
            PlayerPrefs.SetInt("id_rung", 1);
            PlayerPrefs.Save();
        }
    }

    public static int Get_id_rung()
    {
        if (PlayerPrefs.HasKey("id_rung"))
        {
            int id_rung = PlayerPrefs.GetInt("id_rung");
            return id_rung;
        }
        return 3;
    }
}
