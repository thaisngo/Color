using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheDo_button_ScenesManChoi : Save_Che_Do, I_CacCheDo  // xử lý click vào các button chế độ: sáng tối, audio và rung.
{
    public void CheDo_SangToi()  // Xu ly su kien button click !
    {
        if (Get_id_Sang_Toi() == 0)
        {
            MaTran_Luoi.instance.che_do.GetComponent<Image>().sprite = MaTran_Luoi.instance.image_che_do_sang_toi[1];
            MaTran_Luoi.instance.background.GetComponent<Image>().color = Color.black;
            MaTran_Luoi.instance.panel_pause.GetComponent<Image>().color = new Color32(115, 115, 115, 255);
        }

        else if (Get_id_Sang_Toi() == 1)
        {
            MaTran_Luoi.instance.che_do.GetComponent<Image>().sprite = MaTran_Luoi.instance.image_che_do_sang_toi[0];
            MaTran_Luoi.instance.background.GetComponent<Image>().color = Color.white;
            MaTran_Luoi.instance.panel_pause.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        Set_id_Sang_Toi();
    }

    public void CheDo_AmThanh()
    {
        if (Get_id_Audio() == 0)
        {
            MaTran_Luoi.instance.loa.GetComponent<Image>().sprite = MaTran_Luoi.instance.image_audio[1];
            MaTran_Luoi.instance.audio_nhac_nen_man_choi.Stop();
        }

        else if (Get_id_Audio() == 1)
        {
            MaTran_Luoi.instance.loa.GetComponent<Image>().sprite = MaTran_Luoi.instance.image_audio[0];
            MaTran_Luoi.instance.audio_nhac_nen_man_choi.Play();
        }
        Set_id_Audio();
    }

    public void CheDo_Rung()
    {
        if (Get_id_rung() == 0)
        {
            MaTran_Luoi.instance.che_do_rung.GetComponent<Image>().sprite = MaTran_Luoi.instance.image_rung[1];
        }

        else if (Get_id_rung() == 1)
        {
            MaTran_Luoi.instance.che_do_rung.GetComponent<Image>().sprite = MaTran_Luoi.instance.image_rung[0];
        }
        Set_id_rung();
    }
}
