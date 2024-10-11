using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheDo_SangToi_scenesBatDau : MonoBehaviour
{
    public List<Sprite> image_che_do_sang_toi = new List<Sprite>();
    public GameObject che_do;
    private void Start()
    {
        che_do_sang_toi();
    }

    public void che_do_sang_toi()  // Xu ly su kien button click !
    {
        if (Save_Che_Do.Get_id_Sang_Toi() == 0)
        {
            che_do.GetComponent<Image>().sprite = image_che_do_sang_toi[0];
        }

        else if (Save_Che_Do.Get_id_Sang_Toi() == 1)
        {
            che_do.GetComponent<Image>().sprite = image_che_do_sang_toi[1];
        }
    }

    public void click_button_che_do()
    {
        if (che_do.GetComponent<Image>().sprite == image_che_do_sang_toi[0])
        {
            che_do.GetComponent<Image>().sprite = image_che_do_sang_toi[1];
        }

        else if (che_do.GetComponent<Image>().sprite == image_che_do_sang_toi[1])
        {
            che_do.GetComponent<Image>().sprite = image_che_do_sang_toi[0];
        }
        Set_id_Che_Do();
    }

    private void Set_id_Che_Do()
    {
        if (che_do.GetComponent<Image>().sprite == image_che_do_sang_toi[0])
        {
            PlayerPrefs.SetInt("id_che_do", 0);
            PlayerPrefs.Save();
        }

        else if (che_do.GetComponent<Image>().sprite == image_che_do_sang_toi[1])
        {
            PlayerPrefs.SetInt("id_che_do", 1);
            PlayerPrefs.Save();
        }
    }

    public void Button_Ads()
    {

    }
}
