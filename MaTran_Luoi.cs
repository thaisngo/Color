using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MaTran_Luoi : MonoBehaviour, I_GiaoDienDaManHinh, I_CacCheDo
{
    public static MaTran_Luoi instance;
    public int hang;
    public int cot;
    public GameObject cell_oTrong;
    public Canvas cv;
    public Vector2 sizeScreen;
    public float size_OTrong_Co_Khoang_Cach;
    public Khoi_O khoi_prefabs;
    public GameObject background;

    public List<GameObject> list_cell = new List<GameObject>();
    public List<Color> colorCell = new List<Color>();
    public Color do_o_trong;
    public List<Vector2> arr_ToaDo_o_Da_Dien = new List<Vector2>();

    public List<Vector2> arr_o_Do = new List<Vector2>();
    public List<Vector2> arr_o_Vang = new List<Vector2>();
    public List<Vector2> arr_o_Xanh_La = new List<Vector2>();
    public List<Vector2> arr_o_Xanh_Duong = new List<Vector2>();

    public List<Khoi_O> list_Khoi_O = new List<Khoi_O>();
    public GameObject matranluoi;
    public GameObject panel_endGame;
    public GameObject button_home;
    public GameObject button_choi_lai;
    public GameObject text_color1010;
    public GameObject button_pause;
    public GameObject cup;

    public GameObject panel_pause;
    public GameObject home;
    public GameObject replay;
    public GameObject play_load;
    public GameObject che_do;
    public GameObject loa;
    public GameObject che_do_rung;

    public GameObject text_andgame;

    public Text diemText;
    public GameObject diemCaoText;

    public GameObject button_xoa_O_mau;
    public List<Sprite> image_xoa_O_mau = new List<Sprite>();

    public List<Sprite> image_che_do_sang_toi = new List<Sprite>();
    public List<Sprite> image_audio = new List<Sprite>();
    public List<Sprite> image_rung = new List<Sprite>();

    public int tong = 0;
    public int trang_thai = 0;
    public int dem = 0;

    private DataGame dataGame;
    private DataShape dataShape;

    public AudioSource audio_nhac_nen_man_choi;
    public AudioSource audio_chon_nham;
    public AudioSource audio_chon_dung;
    public AudioSource audio_an;
    public AudioSource audio_thua;
    public AudioSource audio_thang;
    public AudioSource audio_xoa_cac_o_mau;

    public static MaTran_Luoi Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<MaTran_Luoi>();
            }

            return instance;
        }
    }

    public void matranluoi_UI()
    {
        matranluoi.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, sizeScreen.y * (120f / 1136));
    }

    public void GiaoDien_UI()
    {
        // panel_ket_thuc_Game_UI()
        UI_MotObject_xy(panel_endGame, 1f, 1f, 0f, 0f);
        UI_MotObject_xx(button_home, (200f / 640), (200f / 640), (-110f / 640), 0f);
        UI_MotObject_xx(button_choi_lai, (200f / 640), (200f / 640), (110f / 640), 0f);

        // text_color1010_UI()
        UI_MotObject_yy(text_color1010, 1f, (35f / 1136), 0f, (-530f / 1136));
        text_color1010.GetComponent<Text>().fontSize = (int)(sizeScreen.y * (30f / 1136));

        // Button_Pause_Cup_UI()
        UI_MotObject_xy(button_pause, (70f / 640), (70f / 640), (250f / 640), (500f / 1136));
        UI_MotObject_xy(cup, (50f / 640), (50f / 640), 0f, (500f / 1136));

        // Panel_pause_UI()
        UI_MotObject_yy(panel_pause, 1f, 1f, 0f, 0f);
        UI_MotObject_xx(home, (150f / 640), (150f / 640), (-80f / 640), (80f / 640));
        UI_MotObject_xx(replay, (150f / 640), (150f / 640), (80f / 640), (80f / 640));
        UI_MotObject_xx(play_load, (150f / 640), (150f / 640), (-80f / 640), (-80f / 640));
        UI_MotObject_xx(che_do, (150f / 640), (150f / 640), (80f / 640), (-80f / 640));
        UI_MotObject_xy(loa, (120f / 640), (120f / 640), (250f / 640), (-400f / 1136));
        UI_MotObject_xy(che_do_rung, (120f / 640), (120f / 640), (-250f / 640), (-400f / 1136));

        // button_xoa_O_mau_UI()
        UI_MotObject_xy(button_xoa_O_mau, (70f / 640), (70f / 640), (-250f / 640), (500f / 1136));

        // text_endGame_UI()
        UI_MotObject_yy(text_andgame, 1f, (200f / 1136), 0f, (-400f / 1136));
        text_andgame.GetComponent<Text>().fontSize = (int)(sizeScreen.y * (100f / 1136));
    }

    public void UI_MotObject_xx(GameObject obj, float a, float b, float c, float d)
    {
        obj.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * a, sizeScreen.x * b);
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(sizeScreen.x * c, sizeScreen.x * d);
    }

    public void UI_MotObject_yy(GameObject obj, float a, float b, float c, float d)
    {
        obj.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * a, sizeScreen.y * b);
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(sizeScreen.x * c, sizeScreen.y * d);
    }

    public void UI_MotObject_xy(GameObject obj, float a, float b, float c, float d)
    {
        obj.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * a, sizeScreen.x * b);
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(sizeScreen.x * c, sizeScreen.y * d);
    }

    public void CheDo_SangToi()
    {
        if (Save_Che_Do.Get_id_Sang_Toi() == 0)  // Set che do sang-toi !
        {
            if (button_xoa_O_mau.GetComponent<Image>().sprite == image_xoa_O_mau[5])
            {
                button_xoa_O_mau.GetComponent<Image>().sprite = image_xoa_O_mau[4];
            }
            che_do.GetComponent<Image>().sprite = image_che_do_sang_toi[0];
            background.GetComponent<Image>().color = Color.white;
            panel_pause.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

        else if (Save_Che_Do.Get_id_Sang_Toi() == 1)
        {
            if (button_xoa_O_mau.GetComponent<Image>().sprite == image_xoa_O_mau[4])
            {
                button_xoa_O_mau.GetComponent<Image>().sprite = image_xoa_O_mau[5];
            }
            che_do.GetComponent<Image>().sprite = image_che_do_sang_toi[1];
            background.GetComponent<Image>().color = Color.black;

            colorCell[0] = new Color32(33, 34, 34, 255);
            do_o_trong = Color.gray;
            panel_pause.GetComponent<Image>().color = new Color32(115, 115, 115, 255);
        }
    }

    public void CheDo_AmThanh()
    {
        if (Save_Che_Do.Get_id_Audio() == 0)
        {
            loa.GetComponent<Image>().sprite = image_audio[0];
        }

        else if (Save_Che_Do.Get_id_Audio() == 1)
        {
            audio_nhac_nen_man_choi.Stop();
            audio_chon_nham.Stop();
            audio_chon_dung.Stop();
            audio_an.Stop();
            audio_thua.Stop();
            audio_thang.Stop();
            loa.GetComponent<Image>().sprite = image_audio[1];
        }
    }

    public void CheDo_Rung()
    {
        if (Save_Che_Do.Get_id_rung() == 0)
        {
            che_do_rung.GetComponent<Image>().sprite = image_rung[0];
        }

        else if (Save_Che_Do.Get_id_rung() == 1)
        {
            che_do_rung.GetComponent<Image>().sprite = image_rung[1];
        }
    }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sizeScreen = cv.GetComponent<RectTransform>().sizeDelta;
        audio_nhac_nen_man_choi.Play();
        matranluoi_UI();
        GiaoDien_UI();

        button_xoa_O_mau.GetComponent<Image>().sprite = image_xoa_O_mau[Set_Xoa_O.Get_id_Image()];

        CheDo_SangToi();
        CheDo_AmThanh();
        CheDo_Rung();

        Get_Matran();
        Matran_Luoi_function();
        Phan_Loai_List();

        tong = Set_Diem_Cao.GetDiem();
        Set_Diem_Cao.GetDiem();

        Get_KhoiO();
        Sinh_Lai_Khoi();

        Bat_Tat_gameOver();
        AdsController.InterstitialAdsClosed += InterClose;
        AdsController.RewardedVideoAdsRewardedUser += Rewarded;
    }

    private void OnDestroy()
    {
        AdsController.InterstitialAdsClosed -= InterClose;
        AdsController.RewardedVideoAdsRewardedUser -= Rewarded;
    }

    private void Update()
    {
        Set_Xoa_O.Set_id_Image();
    }

    public void Random_Sinh_TroGiup_Xoa_Cac_O_Mau() // button trợ giúp góc trái bên trên. random màu nào được sinh trợ giúp
    {
        int rd = Random.Range(0, 4);
        button_xoa_O_mau.GetComponent<Image>().sprite = image_xoa_O_mau[rd];
    }

    public void Lam_Tron_Toa_Do(ref float x, ref float y)
    {
        int phanNguyen_x = (int)(x / (sizeScreen.x * (1f / hang)));
        int phanNguyen_y = (int)(y / (sizeScreen.x * (1f / hang)));

        float phanThuc_x = (float)(x / (sizeScreen.x * (1f / hang)));
        float phanThuc_y = (float)(y / (sizeScreen.x * (1f / hang)));

        LamTronToaDo(ref x, phanNguyen_x, phanThuc_x);
        LamTronToaDo(ref y, phanNguyen_y, phanThuc_y);
    }

    private void LamTronToaDo(ref float x, int phannguyen, float phanthuc)
    {
        if (phannguyen > 0f)
        {
            x = (phannguyen + 0.5f) * (sizeScreen.x * (1f / hang));
        }

        else if (phannguyen < 0f)
        {
            x = (phannguyen - 0.5f) * (sizeScreen.x * (1f / hang));
        }

        else if (phannguyen == 0f)
        {
            if (phanthuc >= 0)
            {
                x = (phannguyen + 0.5f) * (sizeScreen.x * (1f / hang));
            }

            else if (phanthuc < 0)
            {
                x = (phannguyen - 0.5f) * (sizeScreen.x * (1f / hang));
            }
        }
    }

    public void Lam_Tron(ref float x, ref float y)
    {
        LamTron(ref x);
        LamTron(ref y);
    }

    private void LamTron(ref float x)
    {
        if (x > 1.5f * (sizeScreen.x * (1f / hang)) && x < 2f * (sizeScreen.x * (1f / hang)))
        {
            x = 2f * (sizeScreen.x * (1f / hang));
        }

        else if (x > -2f * (sizeScreen.x * (1f / hang)) && x < -1.5f * (sizeScreen.x * (1f / hang)))
        {
            x = -2f * (sizeScreen.x * (1f / hang));
        }

        else if (x >= 0.5f * (sizeScreen.x * (1f / hang)) && x <= 1.5f * (sizeScreen.x * (1f / hang)))
        {
            x = sizeScreen.x * (1f / hang);
        }

        else if (x >= -1.5f * (sizeScreen.x * (1f / hang)) && x <= -0.5f * (sizeScreen.x * (1f / hang)))
        {
            x = -(sizeScreen.x * (1f / hang));
        }

        else if (x > -0.5f * (sizeScreen.x * (1f / hang)) && x < 0.5f * (sizeScreen.x * (1f / hang)))
        {
            x = 0f;
        }
    }

    public void Matran_Luoi_function()
    {
        float a = -(hang - 1) * 1f / (2 * hang);
        float b = (hang - 1) * 1f / (2 * hang);

        int k = 0;
        for (int i = 0; i < hang; i++)
        {
            for (int j = 0; j < cot; j++)
            {
                GameObject oTrong_0 = Instantiate(cell_oTrong, this.transform);

                if (dataGame != null)
                {
                    oTrong_0.GetComponent<Image>().color = colorCell[dataGame.idColor[k]];
                }

                else if (dataGame == null)
                {
                    oTrong_0.GetComponent<Image>().color = colorCell[0];
                }

                oTrong_0.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * (size_OTrong_Co_Khoang_Cach / hang), sizeScreen.x * (size_OTrong_Co_Khoang_Cach / cot));
                oTrong_0.GetComponent<RectTransform>().anchoredPosition = new Vector2(sizeScreen.x * a, sizeScreen.x * b);
                list_cell.Add(oTrong_0);
                k++;

                a = a + (1f / hang);
            }
            a = -(hang - 1) * 1f / (2 * hang);
            b = b - (1f / hang);
        }
    }

    private void SinhLaiMotKhoiO(Khoi_O khoi_clone1, int a, int b,List<Vector2> c, List<int> d)
    {
            khoi_clone1 = Instantiate(khoi_prefabs, transform);
            khoi_clone1.GetComponent<RectTransform>().anchoredPosition = dataShape.Toa_Do_Khoi_O[a];
            list_Khoi_O.Add(khoi_clone1);

            for (int j = 0; j < b; j++)
            {
                GameObject khoi_1231 = Instantiate(cell_oTrong, khoi_clone1.GetComponent<RectTransform>().transform);
                khoi_1231.GetComponent<RectTransform>().anchoredPosition = c[j];
                khoi_1231.GetComponent<Image>().color = colorCell[d[j]];
                khoi_1231.GetComponent<cell_oTrong_scrips>().id = d[j];
                khoi_clone1.GetComponent<Khoi_O>().arr_O_Trong_Khoi.Add(khoi_1231);
            }
    }
    public void Sinh_Lai_Khoi()
    {
        if (dataShape != null)
        {
            if (dataShape.Toa_Do_Khoi_O.Count == 1)
            {
                Khoi_O khoi_clone1 = GetComponent<Khoi_O>();
                SinhLaiMotKhoiO(khoi_clone1, 0, dataShape.Toa_Do_O_Trong_Khoi1.Count, dataShape.Toa_Do_O_Trong_Khoi1, dataShape.id_mau_O_1);
            }

            else if (dataShape.Toa_Do_Khoi_O.Count == 2)
            {
                Khoi_O khoi_clone1 = GetComponent<Khoi_O>();
                SinhLaiMotKhoiO(khoi_clone1, 0, dataShape.Toa_Do_O_Trong_Khoi1.Count, dataShape.Toa_Do_O_Trong_Khoi1, dataShape.id_mau_O_1);

                Khoi_O khoi_clone2 = GetComponent<Khoi_O>();
                SinhLaiMotKhoiO(khoi_clone2, 1, dataShape.Toa_Do_O_Trong_Khoi2.Count, dataShape.Toa_Do_O_Trong_Khoi2, dataShape.id_mau_O_2);
            }

            else if (dataShape.Toa_Do_Khoi_O.Count == 3)
            {
                Khoi_O khoi_clone1 = GetComponent<Khoi_O>();
                SinhLaiMotKhoiO(khoi_clone1, 0, dataShape.Toa_Do_O_Trong_Khoi1.Count, dataShape.Toa_Do_O_Trong_Khoi1, dataShape.id_mau_O_1);

                Khoi_O khoi_clone2 = GetComponent<Khoi_O>();
                SinhLaiMotKhoiO(khoi_clone2, 1, dataShape.Toa_Do_O_Trong_Khoi2.Count, dataShape.Toa_Do_O_Trong_Khoi2, dataShape.id_mau_O_2);

                Khoi_O khoi_clone3 = GetComponent<Khoi_O>();
                SinhLaiMotKhoiO(khoi_clone3, 2, dataShape.Toa_Do_O_Trong_Khoi3.Count, dataShape.Toa_Do_O_Trong_Khoi3, dataShape.id_mau_O_3);
            }
        }

        else
        {
            Sinh_Khoi_123(new Vector2(sizeScreen.x * (-200f / 640), sizeScreen.y * (-500f / 1136)));
            Sinh_Khoi_123(new Vector2(0f, sizeScreen.y * (-500f / 1136)));
            Sinh_Khoi_123(new Vector2(sizeScreen.x * (200f / 640), sizeScreen.y * (-500f / 1136)));
        }
    }

    public void Sinh_Khoi_123(Vector2 vitri_khoi) 
    {
        Khoi_O khoi_clone = Instantiate(khoi_prefabs, this.transform);
        khoi_clone.GetComponent<RectTransform>().anchoredPosition = vitri_khoi;

        if (khoi_clone.name == "Khoi(Clone)")
        {
            khoi_clone.GetComponent<Khoi_O>().Khoi_ViTri();
        }
        list_Khoi_O.Add(khoi_clone);
    }

    public void TinhDiem(int diem)
    {
        tong = tong + diem;
        diemText.text = "" + tong;
    }

    public bool Check_O_canh_Nhau(Vector2 vt1, Vector2 vt2)
    {
        bool check = false;
        if (Mathf.Abs(vt1.x - vt2.x) < 0.1f)
        {
            if ((Mathf.Abs(vt1.y - vt2.y) < (sizeScreen.x * (1f / hang)) + 0.1f && Mathf.Abs(vt1.y - vt2.y) > (sizeScreen.x * (1f / hang)) - 0.1f) && (Mathf.Abs(vt1.y - vt2.y) > (sizeScreen.x * (1f / hang)) - 0.1f && Mathf.Abs(vt1.y - vt2.y) < (sizeScreen.x * (1f / hang)) + 0.1f))
            {
                check = true;
            }

            else
            {
                check = false;
            }
        }

        else if (Mathf.Abs(vt1.y - vt2.y) < 0.1f)
        {
            if ((Mathf.Abs(vt1.x - vt2.x) < (sizeScreen.x * (1f / hang)) + 0.1f && Mathf.Abs(vt1.x - vt2.x) > (sizeScreen.x * (1f / hang)) - 0.1f) && (Mathf.Abs(vt1.x - vt2.x) > (sizeScreen.x * (1f / hang)) - 0.1f && Mathf.Abs(vt1.x - vt2.x) < (sizeScreen.x * (1f / hang)) + 0.1f))
            {
                check = true;
            }

            else
            {
                check = false;
            }
        }

        if (check == true)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void Tim_List_O_Cung_Mau_Canh_Nhau_Va_Xoa(List<Vector2> vt)
    {
        int a = list_cell.Count - arr_ToaDo_o_Da_Dien.Count;

        List<Vector2> o_lien_nhau_list = new List<Vector2>();
        for (int i = 0; i < vt.Count; i++)
        {
            List<Vector2> o_lien_nhau_arr = new List<Vector2>();
            for (int j = 0; j < vt.Count; j++)
            {
                if (Check_O_canh_Nhau(vt[i], vt[j]) == false)
                {
                    continue;
                }
                else
                {
                    o_lien_nhau_arr.Add(vt[i]);
                    o_lien_nhau_arr.Add(vt[j]);

                    for (int h = 0; h < vt.Count; h++)
                    {
                        if (Check_O_canh_Nhau(vt[j], vt[h]) == true)
                        {
                            o_lien_nhau_arr.Add(vt[h]);

                        }

                        else
                        {
                            continue;
                        }
                    }
                }
            }

            for (int m = 0; m < o_lien_nhau_arr.Count - 1; m++)
            {
                for (int n = m + 1; n < o_lien_nhau_arr.Count; n++)
                {
                    if (o_lien_nhau_arr[m] == o_lien_nhau_arr[n])
                    {
                        o_lien_nhau_arr.Remove(o_lien_nhau_arr[n]);
                    }
                }
            }

            if (o_lien_nhau_arr.Count >= 3)
            {
                for (int s = 0; s < o_lien_nhau_arr.Count; s++)
                {
                    o_lien_nhau_list.Add(o_lien_nhau_arr[s]);
                }
            }
        }

        for (int z = 0; z < o_lien_nhau_list.Count - 1; z++)
        {
            for (int t = z + 1; t < o_lien_nhau_list.Count; t++)
            {
                if (o_lien_nhau_list[z] == o_lien_nhau_list[t])
                {
                    o_lien_nhau_list.Remove(o_lien_nhau_list[t]);
                }
            }
        }

        if (o_lien_nhau_list.Count >= 3)
        {
            audio_chon_dung.Stop();

            if (Save_Che_Do.Get_id_Audio() == 0 || Save_Che_Do.Get_id_Audio() == 3)
            {
                audio_an.Play();
            }

            else if (Save_Che_Do.Get_id_Audio() == 1)
            {
                audio_an.Stop();
            }

            if (Save_Che_Do.Get_id_rung() == 0 || Save_Che_Do.Get_id_rung() == 3)
            {
                iOSHapticFeedback.Instance.UseHaptic();
            }

            for (int m = 0; m < o_lien_nhau_list.Count; m++)
            {
                for (int k = 0; k < list_cell.Count; k++)
                {
                    if (Mathf.Abs(o_lien_nhau_list[m].x - list_cell[k].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(o_lien_nhau_list[m].y - list_cell[k].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f)
                    {
                        list_cell[k].GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[0];
                        arr_ToaDo_o_Da_Dien.Remove(o_lien_nhau_list[m]);
                        vt.Remove(o_lien_nhau_list[m]);
                    }
                }
            }
            Set_Diem_Cao.Set_Diem(tong);
            Set_Diem_Cao.Set_diemCao();
        }

        int b = list_cell.Count - arr_ToaDo_o_Da_Dien.Count;
        TinhDiem(b - a);
    }

    public bool Check_LoseWin(int gia_tri, int index)
    {
        bool check = false;
        if (gia_tri == 1)
        {
            if (list_Khoi_O[index].GetComponent<Khoi_O>().Check_Khoi_1_O() == true)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }


        else if (gia_tri == 2)
        {
            if (list_Khoi_O[index].GetComponent<Khoi_O>().Check_Khoi_2_O() == true)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }

        else if (gia_tri == 3)
        {
            if (list_Khoi_O[index].GetComponent<Khoi_O>().Check_Khoi_3_O() == true)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }

        else if (gia_tri == 4)
        {
            if (list_Khoi_O[index].GetComponent<Khoi_O>().Check_Khoi_4_O() == true)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }

        else
        {
            if (list_Khoi_O[index].GetComponent<Khoi_O>().Check_Khoi_5_O() == true)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }


        if (check == false)
        {
            return false;
        }

        else
        {
            return true;
        }
    }

    public void QuyDoi()
    {
        for (int i = 0; i < list_cell.Count; i++)
        {
            if (list_cell[i].GetComponent<Image>().color == colorCell[0])
            {
                list_cell[i].GetComponent<cell_oTrong_scrips>().id = 0;
            }

            else if (list_cell[i].GetComponent<Image>().color == colorCell[1])
            {
                list_cell[i].GetComponent<cell_oTrong_scrips>().id = 1;
            }

            else if (list_cell[i].GetComponent<Image>().color == colorCell[2])
            {
                list_cell[i].GetComponent<cell_oTrong_scrips>().id = 2;
            }

            else if (list_cell[i].GetComponent<Image>().color == colorCell[3])
            {
                list_cell[i].GetComponent<cell_oTrong_scrips>().id = 3;
            }

            else if (list_cell[i].GetComponent<Image>().color == colorCell[4])
            {
                list_cell[i].GetComponent<cell_oTrong_scrips>().id = 4;
            }
        }
    }

    public void Set_Matran()
    {
        dataGame = new DataGame();
        dataGame.idColor = new List<int>();
        for (int i = 0; i < hang * cot; i++)
        {
            dataGame.idColor.Add(list_cell[i].GetComponent<cell_oTrong_scrips>().id);
        }
        string data = JsonUtility.ToJson(dataGame);
        PlayerPrefs.SetString("data_game", data);
    }

    public void Get_Matran()
    {
        if (PlayerPrefs.HasKey("data_game"))
        {
            string dataString = PlayerPrefs.GetString("data_game");
            dataGame = JsonUtility.FromJson<DataGame>(dataString);
        }
    }

    public void Phan_Loai_List()
    {
        for (int i = 0; i < list_cell.Count; i++)
        {
            if (list_cell[i].GetComponent<Image>().color != colorCell[0])
            {
                arr_ToaDo_o_Da_Dien.Add(list_cell[i].GetComponent<RectTransform>().anchoredPosition);
            }

            if (list_cell[i].GetComponent<Image>().color == colorCell[1])
            {
                arr_o_Do.Add(list_cell[i].GetComponent<RectTransform>().anchoredPosition);
            }

            else if (list_cell[i].GetComponent<Image>().color == colorCell[2])
            {
                arr_o_Vang.Add(list_cell[i].GetComponent<RectTransform>().anchoredPosition);
            }

            else if (list_cell[i].GetComponent<Image>().color == colorCell[3])
            {
                arr_o_Xanh_La.Add(list_cell[i].GetComponent<RectTransform>().anchoredPosition);
            }

            else if (list_cell[i].GetComponent<Image>().color == colorCell[4])
            {
                arr_o_Xanh_Duong.Add(list_cell[i].GetComponent<RectTransform>().anchoredPosition);
            }
        }
    }

    public void Set_KhoiO()
    {
        dataShape = new DataShape();
        for (int i = 0; i < list_Khoi_O.Count; i++)
        {
            float x0 = list_Khoi_O[i].GetComponent<RectTransform>().anchoredPosition.x;
            float y0 = list_Khoi_O[i].GetComponent<RectTransform>().anchoredPosition.y;

            dataShape.Toa_Do_Khoi_O.Add(new Vector2(x0, y0));
            if (list_Khoi_O.Count == 1)
            {
                for (int j = 0; j < list_Khoi_O[i].arr_O_Trong_Khoi.Count; j++)
                {
                    float x1 = list_Khoi_O[i].arr_O_Trong_Khoi[j].GetComponent<RectTransform>().anchoredPosition.x;
                    float y1 = list_Khoi_O[i].arr_O_Trong_Khoi[j].GetComponent<RectTransform>().anchoredPosition.y;

                    dataShape.id_mau_O_1.Add(list_Khoi_O[i].arr_O_Trong_Khoi[j].GetComponent<cell_oTrong_scrips>().id);
                    dataShape.Toa_Do_O_Trong_Khoi1.Add(new Vector2(x1, y1));
                }
            }

            else if (list_Khoi_O.Count == 2)
            {
                for (int j = 0; j < list_Khoi_O[i].arr_O_Trong_Khoi.Count; j++)
                {
                    float x1 = list_Khoi_O[i].arr_O_Trong_Khoi[j].GetComponent<RectTransform>().anchoredPosition.x;
                    float y1 = list_Khoi_O[i].arr_O_Trong_Khoi[j].GetComponent<RectTransform>().anchoredPosition.y;

                    if (i == 0)
                    {
                        dataShape.id_mau_O_1.Add(list_Khoi_O[i].arr_O_Trong_Khoi[j].GetComponent<cell_oTrong_scrips>().id);
                        dataShape.Toa_Do_O_Trong_Khoi1.Add(new Vector2(x1, y1));
                    }

                    else if (i == 1)
                    {
                        dataShape.id_mau_O_2.Add(list_Khoi_O[i].arr_O_Trong_Khoi[j].GetComponent<cell_oTrong_scrips>().id);
                        dataShape.Toa_Do_O_Trong_Khoi2.Add(new Vector2(x1, y1));
                    }
                }
            }

            else if (list_Khoi_O.Count == 3)
            {
                for (int j = 0; j < list_Khoi_O[i].arr_O_Trong_Khoi.Count; j++)
                {
                    float x1 = list_Khoi_O[i].arr_O_Trong_Khoi[j].GetComponent<RectTransform>().anchoredPosition.x;
                    float y1 = list_Khoi_O[i].arr_O_Trong_Khoi[j].GetComponent<RectTransform>().anchoredPosition.y;

                    if (i == 0)
                    {
                        dataShape.id_mau_O_1.Add(list_Khoi_O[i].arr_O_Trong_Khoi[j].GetComponent<cell_oTrong_scrips>().id);
                        dataShape.Toa_Do_O_Trong_Khoi1.Add(new Vector2(x1, y1));
                    }

                    else if (i == 1)
                    {
                        dataShape.id_mau_O_2.Add(list_Khoi_O[i].arr_O_Trong_Khoi[j].GetComponent<cell_oTrong_scrips>().id);
                        dataShape.Toa_Do_O_Trong_Khoi2.Add(new Vector2(x1, y1));
                    }

                    else if (i == 2)
                    {
                        dataShape.id_mau_O_3.Add(list_Khoi_O[i].arr_O_Trong_Khoi[j].GetComponent<cell_oTrong_scrips>().id);
                        dataShape.Toa_Do_O_Trong_Khoi3.Add(new Vector2(x1, y1));
                    }
                }
            }
        }

        string data1 = JsonUtility.ToJson(dataShape);
        PlayerPrefs.SetString("data_game1", data1);
    }

    public void Get_KhoiO()
    {
        if (PlayerPrefs.HasKey("data_game1"))
        {
            string dataString = PlayerPrefs.GetString("data_game1");
            dataShape = JsonUtility.FromJson<DataShape>(dataString);
        }
    }

    public void ShowInter()
    {
        bool showed = AdsController.instance.ShowInterstitial("");
        Debug.Log("ShowInter: " + showed);
        if (!showed)
        {
            call_panel_endgame();
        }
    }

    public void InterClose()
    {
        Debug.Log("InterClose");
        call_panel_endgame();
    }

    public void Rewarded()
    {
        Debug.Log("Rewarded");
        call_Click_Xoa_O_Mau();
    }

    public bool ShowVideo()
    {
        if (AdsController.instance.IsVideoRewaredReady())
        {
            AdsController.instance.ShowRewardBasedVideo("");
            Debug.Log("ShowRewardBasedVideo");
            return true;
        }
        else
        {
            Toast.instance.ShowMessage("Not Ready");
            Debug.Log("Ads Not Ready");
            return false;
        }
    }

    public void Bat_Tat_gameOver()
    {
        if (Set_Diem_Cao.Get_gameOver() == 1)
        {
            text_andgame.GetComponent<Text>().enabled = true;
        }
        else
        {
            text_andgame.GetComponent<Text>().enabled = false;
        }
    }

    private void call_panel_endgame()
    {
        panel_endGame.SetActive(true);
        text_andgame.GetComponent<Text>().enabled = false;
    }

    private void call_Click_Xoa_O_Mau()
    {
        if (button_xoa_O_mau.GetComponent<Image>().sprite == image_xoa_O_mau[0])
        {
            for (int i = 0; i < list_cell.Count; i++)
            {
                if (list_cell[i].GetComponent<Image>().color == colorCell[1])
                {
                    list_cell[i].GetComponent<Image>().color = colorCell[0];
                }

                for (int j = 0; j < arr_o_Do.Count; j++)
                {
                    arr_o_Do.RemoveAt(j);
                }
            }
            Set_Matran();
        }

        else if (button_xoa_O_mau.GetComponent<Image>().sprite == image_xoa_O_mau[1])
        {
            for (int i = 0; i < list_cell.Count; i++)
            {
                if (list_cell[i].GetComponent<Image>().color == colorCell[2])
                {
                    list_cell[i].GetComponent<Image>().color = colorCell[0];
                }

                for (int j = 0; j < arr_o_Vang.Count; j++)
                {
                    arr_o_Vang.RemoveAt(j);
                }
            }
            Set_Matran();
        }

        else if (button_xoa_O_mau.GetComponent<Image>().sprite == image_xoa_O_mau[2])
        {
            for (int i = 0; i < list_cell.Count; i++)
            {
                if (list_cell[i].GetComponent<Image>().color == colorCell[3])
                {
                    list_cell[i].GetComponent<Image>().color = colorCell[0];
                }

                for (int j = 0; j < arr_o_Xanh_La.Count; j++)
                {
                    arr_o_Xanh_La.RemoveAt(j);
                }
            }
            Set_Matran();
        }

        else if (button_xoa_O_mau.GetComponent<Image>().sprite == image_xoa_O_mau[3])
        {
            for (int i = 0; i < list_cell.Count; i++)
            {
                if (list_cell[i].GetComponent<Image>().color == colorCell[4])
                {
                    list_cell[i].GetComponent<Image>().color = colorCell[0];
                }

                for (int j = 0; j < arr_o_Xanh_Duong.Count; j++)
                {
                    arr_o_Xanh_Duong.RemoveAt(j);
                }
            }
            Set_Matran();
        }

        if (Save_Che_Do.Get_id_Audio() == 0 || Save_Che_Do.Get_id_Audio() == 3)
        {
            audio_xoa_cac_o_mau.Play();
        }

        else if (Save_Che_Do.Get_id_Audio() == 1)
        {
            audio_xoa_cac_o_mau.Stop();
        }

        if (tong >= 100)
        {
            tong -= 100;
        }

        Set_Diem_Cao.Set_Diem(tong);
        TinhDiem(0);
    }
}

[System.Serializable]
public class DataGame
{
    public List<int> idColor = new List<int>();
}

[System.Serializable]
public class DataShape
{
    public List<Vector2> Toa_Do_Khoi_O = new List<Vector2>();

    public List<int> id_mau_O_1 = new List<int>();
    public List<int> id_mau_O_2 = new List<int>();
    public List<int> id_mau_O_3 = new List<int>();

    public List<Vector2> Toa_Do_O_Trong_Khoi1 = new List<Vector2>();
    public List<Vector2> Toa_Do_O_Trong_Khoi2 = new List<Vector2>();
    public List<Vector2> Toa_Do_O_Trong_Khoi3 = new List<Vector2>();
}

