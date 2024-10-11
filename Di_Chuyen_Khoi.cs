using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Di_Chuyen_Khoi : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    public Khoi_O k;
    Vector3 vitri_truoc_Move = new Vector3();
    public List<GameObject> O_Di_Qua = new List<GameObject>();

    void OnMouseDown()
    {
        if (k != null)
        {
            if (Time.timeScale == 1)
            {

                vitri_truoc_Move = k.GetComponent<RectTransform>().anchoredPosition;
                screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y - MaTran_Luoi.instance.sizeScreen.y * (200f / 1136), screenPoint.z));
            }
            k.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
        }
    }
    void OnMouseDrag()
    {
        if (k != null)
        {
            if (Time.timeScale == 1)
            {
                bool check = true;
                Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                transform.position = curPosition;

                for (int i = 0; i < k.GetComponent<Khoi_O>().arr_O_Trong_Khoi.Count; i++)
                {
                    float x1 = k.GetComponent<RectTransform>().anchoredPosition.x + k.GetComponent<Khoi_O>().arr_O_Trong_Khoi[i].GetComponent<RectTransform>().anchoredPosition.x;
                    float y1 = k.GetComponent<RectTransform>().anchoredPosition.y + k.GetComponent<Khoi_O>().arr_O_Trong_Khoi[i].GetComponent<RectTransform>().anchoredPosition.y;
                    MaTran_Luoi.instance.Lam_Tron_Toa_Do(ref x1, ref y1);

                    for (int j = 0; j < MaTran_Luoi.instance.list_cell.Count; j++)
                    {
                        if (Mathf.Abs(x1 - MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(y1 - MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f)
                        {
                            O_Di_Qua.Add(MaTran_Luoi.instance.list_cell[j]);
                        }
                    }
                }

                if (k.GetComponent<RectTransform>().anchoredPosition.y >= MaTran_Luoi.instance.sizeScreen.x * (-5f / MaTran_Luoi.instance.hang) && k.GetComponent<RectTransform>().anchoredPosition.y <= MaTran_Luoi.instance.sizeScreen.x * (5f / MaTran_Luoi.instance.hang))
                {
                    if (O_Di_Qua.Count >= k.GetComponent<Khoi_O>().arr_O_Trong_Khoi.Count)
                    {
                        for (int g = 0; g < O_Di_Qua.Count - k.GetComponent<Khoi_O>().arr_O_Trong_Khoi.Count; g++)
                        {
                            for (int p = 0; p < MaTran_Luoi.instance.list_cell.Count; p++)
                            {
                                if (O_Di_Qua[g].GetComponent<RectTransform>().anchoredPosition == MaTran_Luoi.instance.list_cell[p].GetComponent<RectTransform>().anchoredPosition)
                                {
                                    if (MaTran_Luoi.instance.list_cell[p].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[1] && MaTran_Luoi.instance.list_cell[p].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[2] && MaTran_Luoi.instance.list_cell[p].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[3] && MaTran_Luoi.instance.list_cell[p].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[4])
                                    {
                                        MaTran_Luoi.instance.list_cell[p].GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[0];
                                    }
                                }
                            }
                        }
                        //-----------------------
                        bool check0 = true;
                        for (int g = O_Di_Qua.Count - k.GetComponent<Khoi_O>().arr_O_Trong_Khoi.Count; g < O_Di_Qua.Count - 1; g++)
                        {
                            for (int z = g + 1; z < O_Di_Qua.Count; z++)
                            {
                                if (O_Di_Qua[g].GetComponent<RectTransform>().anchoredPosition == O_Di_Qua[z].GetComponent<RectTransform>().anchoredPosition)
                                {
                                    check0 = false;
                                    break;
                                }

                                else
                                {
                                    check0 = true;
                                }
                            }

                            if (check0 == false)
                            {
                                break;
                            }
                        }

                        //-----------------------

                        if (check0 == true)
                        {
                            for (int g = O_Di_Qua.Count - k.GetComponent<Khoi_O>().arr_O_Trong_Khoi.Count; g < O_Di_Qua.Count; g++)
                            {
                                for (int p = 0; p < MaTran_Luoi.instance.list_cell.Count; p++)
                                {
                                    if (O_Di_Qua[g].GetComponent<RectTransform>().anchoredPosition == MaTran_Luoi.instance.list_cell[p].GetComponent<RectTransform>().anchoredPosition)
                                    {
                                        if (MaTran_Luoi.instance.list_cell[p].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[1] && MaTran_Luoi.instance.list_cell[p].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[2] && MaTran_Luoi.instance.list_cell[p].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[3] && MaTran_Luoi.instance.list_cell[p].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[4])
                                        {
                                            check = true;
                                        }

                                        else
                                        {
                                            check = false;
                                            break;
                                        }
                                    }

                                    if (check == false)
                                    {
                                        break;
                                    }
                                }
                                if (check == false)
                                {
                                    break;
                                }
                            }
                        }

                        else
                        {
                            check = false;
                        }

                        if (check == true)
                        {
                            for (int i = O_Di_Qua.Count - k.GetComponent<Khoi_O>().arr_O_Trong_Khoi.Count; i < O_Di_Qua.Count; i++)
                            {
                                for (int j = 0; j < MaTran_Luoi.instance.list_cell.Count; j++)
                                {
                                    if (O_Di_Qua[i].GetComponent<RectTransform>().anchoredPosition == MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition)
                                    {
                                        if (MaTran_Luoi.instance.list_cell[j].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[1] && MaTran_Luoi.instance.list_cell[j].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[2] && MaTran_Luoi.instance.list_cell[j].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[3] && MaTran_Luoi.instance.list_cell[j].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[4])
                                        {
                                            MaTran_Luoi.instance.list_cell[j].GetComponent<Image>().color = MaTran_Luoi.instance.do_o_trong;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                else
                {
                    for (int h = 0; h < O_Di_Qua.Count; h++)
                    {
                        O_Di_Qua.RemoveAt(h);
                    }

                    for (int h = 0; h < MaTran_Luoi.instance.list_cell.Count; h++)
                    {
                        if (MaTran_Luoi.instance.list_cell[h].GetComponent<Image>().color == MaTran_Luoi.instance.do_o_trong)
                        {
                            MaTran_Luoi.instance.list_cell[h].GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[0];
                        }
                    }
                }
            }
        }
    }
    void OnMouseUp()
    {
        if (k != null)
        {
            if (Time.timeScale == 1)
            {
                bool check0 = true;
                List<Vector2> check_trung_nhau_O_trong_khoi = new List<Vector2>();
                for (int i = 0; i < k.GetComponent<Khoi_O>().arr_O_Trong_Khoi.Count; i++)
                {
                    float x1 = k.GetComponent<RectTransform>().anchoredPosition.x + k.GetComponent<Khoi_O>().arr_O_Trong_Khoi[i].GetComponent<RectTransform>().anchoredPosition.x;
                    float y1 = k.GetComponent<RectTransform>().anchoredPosition.y + k.GetComponent<Khoi_O>().arr_O_Trong_Khoi[i].GetComponent<RectTransform>().anchoredPosition.y;
                    MaTran_Luoi.instance.Lam_Tron_Toa_Do(ref x1, ref y1);
                    check_trung_nhau_O_trong_khoi.Add(new Vector2(x1, y1));
                }

                for (int i = 0; i < check_trung_nhau_O_trong_khoi.Count - 1; i++)
                {
                    for (int j = i + 1; j < check_trung_nhau_O_trong_khoi.Count; j++)
                    {
                        if (check_trung_nhau_O_trong_khoi[i] == check_trung_nhau_O_trong_khoi[j])
                        {
                            check0 = false;
                            break;
                        }

                        else
                        {
                            check0 = true;
                        }
                    }
                    if (check0 == false)
                    {
                        break;
                    }
                }



                bool check = true;

                if (check0 == true)
                {
                    for (int i = 0; i < k.GetComponent<Khoi_O>().arr_O_Trong_Khoi.Count; i++)
                    {
                        float x1 = k.GetComponent<RectTransform>().anchoredPosition.x + k.GetComponent<Khoi_O>().arr_O_Trong_Khoi[i].GetComponent<RectTransform>().anchoredPosition.x;
                        float y1 = k.GetComponent<RectTransform>().anchoredPosition.y + k.GetComponent<Khoi_O>().arr_O_Trong_Khoi[i].GetComponent<RectTransform>().anchoredPosition.y;
                        MaTran_Luoi.instance.Lam_Tron_Toa_Do(ref x1, ref y1);

                        if (k.GetComponent<RectTransform>().anchoredPosition.y < MaTran_Luoi.instance.sizeScreen.x * (-5f / MaTran_Luoi.instance.hang) || k.GetComponent<RectTransform>().anchoredPosition.y > MaTran_Luoi.instance.sizeScreen.x * (5f / MaTran_Luoi.instance.hang))
                        {
                            check = false;
                        }

                        else if (k.GetComponent<RectTransform>().anchoredPosition.y >= MaTran_Luoi.instance.sizeScreen.x * (-5f / MaTran_Luoi.instance.hang) && k.GetComponent<RectTransform>().anchoredPosition.y <= MaTran_Luoi.instance.sizeScreen.x * (5f / MaTran_Luoi.instance.hang))
                        {
                            for (int j = 0; j < MaTran_Luoi.instance.list_cell.Count; j++)
                            {
                                if (Mathf.Abs(x1 - MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(y1 - MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f)
                                {
                                    if (MaTran_Luoi.instance.list_cell[j].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[1] && MaTran_Luoi.instance.list_cell[j].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[2] && MaTran_Luoi.instance.list_cell[j].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[3] && MaTran_Luoi.instance.list_cell[j].GetComponent<Image>().color != MaTran_Luoi.instance.colorCell[4])
                                    {
                                        check = true;
                                        break;
                                    }
                                    else
                                    {
                                        check = false;
                                    }
                                }

                                else
                                {
                                    check = false;
                                }
                            }

                            if (check == false)
                            {
                                break;
                            }
                        }
                    }
                }

                else
                {
                    check = false;
                }

                if (check == false)
                {
                    k.GetComponent<RectTransform>().anchoredPosition = vitri_truoc_Move;
                    k.GetComponent<RectTransform>().localScale = new Vector2(0.75f, 0.75f);

                    if (Save_Che_Do.Get_id_Audio() == 0 || Save_Che_Do.Get_id_Audio() == 3)
                    {
                        MaTran_Luoi.instance.audio_chon_nham.Play();
                    }

                    else if (Save_Che_Do.Get_id_Audio() == 1)
                    {
                        MaTran_Luoi.instance.audio_chon_nham.Stop();
                    }


                    if (Save_Che_Do.Get_id_rung() == 0 || Save_Che_Do.Get_id_rung() == 3)
                    {
                        iOSHapticFeedback.Instance.UseHaptic();
                    }

                    //---------------------------
                    for (int i = 0; i < MaTran_Luoi.instance.list_cell.Count; i++)
                    {
                        if (MaTran_Luoi.instance.list_cell[i].GetComponent<Image>().color == MaTran_Luoi.instance.do_o_trong)
                        {
                            MaTran_Luoi.instance.list_cell[i].GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[0];
                        }
                    }
                }

                else if (check == true)
                {

                    if (Save_Che_Do.Get_id_Audio() == 0 || Save_Che_Do.Get_id_Audio() == 3)
                    {
                        MaTran_Luoi.instance.audio_chon_dung.Play();
                    }

                    else if (Save_Che_Do.Get_id_Audio() == 1)
                    {
                        MaTran_Luoi.instance.audio_chon_dung.Stop();
                    }

                    if (Save_Che_Do.Get_id_rung() == 0 || Save_Che_Do.Get_id_rung() == 3)
                    {
                        iOSHapticFeedback.Instance.UseHaptic();
                    }

                    //----------------------------------------
                    for (int i = 0; i < k.GetComponent<Khoi_O>().arr_O_Trong_Khoi.Count; i++)
                    {
                        float x1 = k.GetComponent<RectTransform>().anchoredPosition.x + k.GetComponent<Khoi_O>().arr_O_Trong_Khoi[i].GetComponent<RectTransform>().anchoredPosition.x;
                        float y1 = k.GetComponent<RectTransform>().anchoredPosition.y + k.GetComponent<Khoi_O>().arr_O_Trong_Khoi[i].GetComponent<RectTransform>().anchoredPosition.y;
                        MaTran_Luoi.instance.Lam_Tron_Toa_Do(ref x1, ref y1);

                        MaTran_Luoi.instance.arr_ToaDo_o_Da_Dien.Add(new Vector2(x1, y1));

                        for (int m = 0; m < MaTran_Luoi.instance.list_cell.Count; m++)
                        {
                            if ((Mathf.Abs(x1 - MaTran_Luoi.instance.list_cell[m].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(y1 - MaTran_Luoi.instance.list_cell[m].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f))
                            {
                                if (k.GetComponent<Khoi_O>().arr_O_Trong_Khoi[i].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[1])
                                {
                                    MaTran_Luoi.instance.list_cell[m].GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[1];
                                    MaTran_Luoi.instance.arr_o_Do.Add(new Vector2(x1, y1));
                                }

                                else if (k.GetComponent<Khoi_O>().arr_O_Trong_Khoi[i].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[2])
                                {
                                    MaTran_Luoi.instance.list_cell[m].GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[2];
                                    MaTran_Luoi.instance.arr_o_Vang.Add(new Vector2(x1, y1));
                                }

                                else if (k.GetComponent<Khoi_O>().arr_O_Trong_Khoi[i].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[3])
                                {
                                    MaTran_Luoi.instance.list_cell[m].GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[3];
                                    MaTran_Luoi.instance.arr_o_Xanh_La.Add(new Vector2(x1, y1));
                                }

                                else if (k.GetComponent<Khoi_O>().arr_O_Trong_Khoi[i].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[4])
                                {
                                    MaTran_Luoi.instance.list_cell[m].GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[4];
                                    MaTran_Luoi.instance.arr_o_Xanh_Duong.Add(new Vector2(x1, y1));
                                }
                            }
                        }

                        Destroy(k.GetComponent<Khoi_O>().arr_O_Trong_Khoi[i]);
                    }

                    MaTran_Luoi.instance.Tim_List_O_Cung_Mau_Canh_Nhau_Va_Xoa(MaTran_Luoi.instance.arr_o_Do);
                    MaTran_Luoi.instance.Tim_List_O_Cung_Mau_Canh_Nhau_Va_Xoa(MaTran_Luoi.instance.arr_o_Vang);
                    MaTran_Luoi.instance.Tim_List_O_Cung_Mau_Canh_Nhau_Va_Xoa(MaTran_Luoi.instance.arr_o_Xanh_La);
                    MaTran_Luoi.instance.Tim_List_O_Cung_Mau_Canh_Nhau_Va_Xoa(MaTran_Luoi.instance.arr_o_Xanh_Duong);

                    MaTran_Luoi.instance.list_Khoi_O.Remove(k);
                    Destroy(k);

                    if (MaTran_Luoi.instance.list_Khoi_O.Count == 0)
                    {
                        MaTran_Luoi.instance.Sinh_Khoi_123(new Vector2(MaTran_Luoi.instance.sizeScreen.x * (-200f / 640), MaTran_Luoi.instance.sizeScreen.y * (-500f / 1136)));
                        MaTran_Luoi.instance.Sinh_Khoi_123(new Vector2(0f, MaTran_Luoi.instance.sizeScreen.y * (-500f / 1136)));
                        MaTran_Luoi.instance.Sinh_Khoi_123(new Vector2(MaTran_Luoi.instance.sizeScreen.x * (200f / 640), MaTran_Luoi.instance.sizeScreen.y * (-500f / 1136)));
                    }

                    for (int i = 0; i < MaTran_Luoi.instance.list_cell.Count; i++)
                    {
                        if (MaTran_Luoi.instance.list_cell[i].GetComponent<Image>().color == MaTran_Luoi.instance.do_o_trong)
                        {
                            MaTran_Luoi.instance.list_cell[i].GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[0];
                        }
                    }

                    bool kiem_tra = false;
                    for (int i = 0; i < MaTran_Luoi.instance.list_Khoi_O.Count; i++)
                    {
                        if (MaTran_Luoi.instance.Check_LoseWin(MaTran_Luoi.instance.list_Khoi_O[i].GetComponent<Khoi_O>().arr_O_Trong_Khoi.Count, i))
                        {
                            kiem_tra = true;
                            break;
                        }

                        else
                        {
                            kiem_tra = false;
                        }
                    }

                    if (kiem_tra == false)
                    {
                        Set_Diem_Cao.Set_Diem(MaTran_Luoi.instance.tong);
                        Set_Diem_Cao.Set_diemCao();
                        MaTran_Luoi.instance.Set_Matran();
                        MaTran_Luoi.instance.Set_KhoiO();

                        MaTran_Luoi.instance.text_andgame.GetComponent<Text>().enabled = true;
                        MaTran_Luoi.instance.trang_thai = 1;
                        Set_Diem_Cao.Set_gameOver(MaTran_Luoi.instance.trang_thai);
                        MaTran_Luoi.instance.Bat_Tat_gameOver();

                        //--------------------------
                        if (Save_Che_Do.Get_id_Sang_Toi() == 0)  // Set che do sang-toi !
                        {

                            MaTran_Luoi.instance.button_xoa_O_mau.GetComponent<Image>().sprite = MaTran_Luoi.instance.image_xoa_O_mau[4];
                        }

                        else if (Save_Che_Do.Get_id_Sang_Toi() == 1)
                        {
                            MaTran_Luoi.instance.button_xoa_O_mau.GetComponent<Image>().sprite = MaTran_Luoi.instance.image_xoa_O_mau[5];
                        }
                        //---------------------------  

                        Invoke("call_Show_Inter", 2f);

                        MaTran_Luoi.instance.audio_nhac_nen_man_choi.Stop();

                        if (Set_Diem_Cao.GetDiem() >= Set_Diem_Cao.Get_High_Score())
                        {
                            if (Save_Che_Do.Get_id_Audio() == 0 || Save_Che_Do.Get_id_Audio() == 3)
                            {
                                MaTran_Luoi.instance.audio_thang.Play();
                            }

                            else if (Save_Che_Do.Get_id_Audio() == 1)
                            {
                                MaTran_Luoi.instance.audio_thang.Stop();
                            }
                        }

                        else
                        {
                            if (Save_Che_Do.Get_id_Audio() == 0 || Save_Che_Do.Get_id_Audio() == 3)
                            {
                                MaTran_Luoi.instance.audio_thua.Play();
                            }

                            else if (Save_Che_Do.Get_id_Audio() == 1)
                            {
                                MaTran_Luoi.instance.audio_thua.Stop();
                            }
                        }
                    }

                    else if (kiem_tra == true)
                    {
                        MaTran_Luoi.instance.QuyDoi();
                        MaTran_Luoi.instance.Set_Matran();
                        Set_Diem_Cao.Set_Diem(MaTran_Luoi.instance.tong);
                        MaTran_Luoi.instance.Set_KhoiO();

                        MaTran_Luoi.instance.dem++;
                        if (MaTran_Luoi.instance.dem == 1 || MaTran_Luoi.instance.dem % 4 == 0)
                        {
                            MaTran_Luoi.instance.Random_Sinh_TroGiup_Xoa_Cac_O_Mau();
                        }
                        Set_Diem_Cao.Set_diemCao();
                    }
                }
            }
        }
    }
    private void call_Show_Inter()
    {
        MaTran_Luoi.instance.ShowInter();
    }
}