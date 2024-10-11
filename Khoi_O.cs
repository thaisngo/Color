using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Khoi_O : MonoBehaviour, I_GiaoDienDaManHinh, I_SinhKhoiO, I_CheckKhoiO
{ 
    public List<GameObject> arr_O_Trong_Khoi = new List<GameObject>();
    private void Start()
    {
        GiaoDien_UI();
    }
    public void GiaoDien_UI() // arr_O_Trong_Khoi_UI() và Box_Khoi_O_UI() gộp lại
    {
        for(int i = 0; i < arr_O_Trong_Khoi.Count; i++)
        {
            arr_O_Trong_Khoi[i].GetComponent<RectTransform>().sizeDelta = new Vector2(MaTran_Luoi.instance.sizeScreen.x * (MaTran_Luoi.instance.size_OTrong_Co_Khoang_Cach / MaTran_Luoi.instance.hang), MaTran_Luoi.instance.sizeScreen.x * (MaTran_Luoi.instance.size_OTrong_Co_Khoang_Cach / MaTran_Luoi.instance.cot));
        }
        gameObject.GetComponent<RectTransform>().localScale = new Vector2(0.75f, 0.75f);

        GetComponent<Khoi_O>().GetComponent<BoxCollider2D>().size = new Vector2((int)MaTran_Luoi.instance.sizeScreen.x * (210f / 640), (int)MaTran_Luoi.instance.sizeScreen.y * (300f / 1136));
    }

    public void Sinh_Khoi_1_O()
    {
        int rd = Random.Range(1, 5);
        for (int i = 0; i < MaTran_Luoi.instance.colorCell.Count; i++)
        {
            if (i == rd)
            {
                GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[rd];
                khoi_1231.GetComponent<cell_oTrong_scrips>().id = rd;
                khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
                arr_O_Trong_Khoi.Add(khoi_1231);
            }
        }
    }

    public void Sinh_Khoi_2_O()
    {
        int random_luachon = Random.Range(1, 3);        
        float xxx = 0f;
        float yyy = 0f;
        float delta = MaTran_Luoi.instance.cell_oTrong.GetComponent<RectTransform>().sizeDelta.x;

        switch (random_luachon)
        {
            case 1:
                int[,] matran1 = new int[2, 1];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        matran1[i, j] = Random.Range(1, 5);
                        GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                        khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran1[i, j]];
                        khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran1[i, j];
                        khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx, yyy + ((1f / 2) * delta) * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                        arr_O_Trong_Khoi.Add(khoi_1231);
                    }
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 2:
                int[,] matran2 = new int[1, 2];
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        matran2[i, j] = Random.Range(1, 5);
                        GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                        khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran2[i, j]];
                        khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran2[i, j];
                        khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy);
                        arr_O_Trong_Khoi.Add(khoi_1231);
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                }
                break;
        }
    }

    public void Sinh_Khoi_3_O()
    {
        int random_luachon = Random.Range(1, 7);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        List<Color> list = new List<Color>();
        List<int> soSanh = new List<int>();
        for(int i = 1; i < MaTran_Luoi.instance.colorCell.Count; i++)
        {
            list.Add(MaTran_Luoi.instance.colorCell[i]);
        }     
        float xxx = 0f;
        float yyy = 0f;
        float delta = MaTran_Luoi.instance.cell_oTrong.GetComponent<RectTransform>().sizeDelta.x;

        switch (random_luachon)
        {
            case 1:
                int[,] matran1 = new int[3, 1];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        if(soSanh.Count < 2)
                        {
                            matran1[i, j] = Random.Range(0, 4);
                        }

                        else
                        {
                            if(soSanh[0] == soSanh[1])
                            {
                                list.RemoveAt(soSanh[0]);
                                matran1[i, j] = Random.Range(0, 3);
                                
                            }

                            else
                            {
                                matran1[i, j] = Random.Range(0, 4);
                            }
                        }

                        soSanh.Add(matran1[i, j]);
                        GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                        khoi_1231.GetComponent<Image>().color = list[matran1[i, j]];
                        khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran1[i, j] + 1;
                        khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx, yyy + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                        arr_O_Trong_Khoi.Add(khoi_1231);
                    }
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 2:
                int[,] matran2 = new int[1, 3];
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (soSanh.Count < 2)
                        {
                            matran2[i, j] = Random.Range(0, 4);
                        }

                        else
                        {
                            if (soSanh[0] == soSanh[1])
                            {
                                list.RemoveAt(soSanh[0]);
                                matran2[i, j] = Random.Range(0, 3);

                            }

                            else
                            {
                                matran2[i, j] = Random.Range(0, 4);
                            }
                        }

                        soSanh.Add(matran2[i, j]);
                        GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                        khoi_1231.GetComponent<Image>().color = list[matran2[i, j]];
                        khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran2[i, j] + 1;
                        khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640), yyy);
                        arr_O_Trong_Khoi.Add(khoi_1231);
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                }
                break;

            case 3:
                int[,] matran3 = new int[2, 2];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 0 && j == 1)
                        {
                            continue;
                        }
                        else
                        {
                            if (soSanh.Count < 2)
                            {
                                matran3[i, j] = Random.Range(0, 4);
                            }

                            else
                            {
                                if (soSanh[0] == soSanh[1])
                                {
                                    list.RemoveAt(soSanh[0]);
                                    matran3[i, j] = Random.Range(0, 3);

                                }

                                else
                                {
                                    matran3[i, j] = Random.Range(0, 4);
                                }
                            }

                            soSanh.Add(matran3[i, j]);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = list[matran3[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran3[i, j] + 1;
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }

                break;

            case 4:
                int[,] matran4 = new int[2, 2];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            continue;
                        }
                        else
                        {
                            if (soSanh.Count < 2)
                            {
                                matran4[i, j] = Random.Range(0, 4);
                            }

                            else
                            {
                                if (soSanh[0] == soSanh[1])
                                {
                                    list.RemoveAt(soSanh[0]);
                                    matran4[i, j] = Random.Range(0, 3);
                                }

                                else
                                {
                                    matran4[i, j] = Random.Range(0, 4);
                                }
                            }

                            soSanh.Add(matran4[i, j]);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = list[matran4[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran4[i, j] + 1;
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 5:
                int[,] matran5 = new int[2, 2];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 1 && j == 1)
                        {
                            continue;
                        }
                        else
                        {
                            if (soSanh.Count < 2)
                            {
                                matran5[i, j] = Random.Range(0, 4);
                            }

                            else
                            {
                                if (soSanh[0] == soSanh[1])
                                {
                                    list.RemoveAt(soSanh[0]);
                                    matran5[i, j] = Random.Range(0, 3);
                                }

                                else
                                {
                                    matran5[i, j] = Random.Range(0, 4);
                                }
                            }

                            soSanh.Add(matran5[i, j]);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = list[matran5[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran5[i, j] + 1;
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 6:
                int[,] matran6 = new int[2, 2];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 1 && j == 0)
                        {
                            continue;
                        }
                        else
                        {
                            if (soSanh.Count < 2)
                            {
                                matran6[i, j] = Random.Range(0, 4);
                            }

                            else
                            {
                                if (soSanh[0] == soSanh[1])
                                {
                                    list.RemoveAt(soSanh[0]);
                                    matran6[i, j] = Random.Range(0, 3);
                                }

                                else
                                {
                                    matran6[i, j] = Random.Range(0, 4);
                                }
                            }

                            soSanh.Add(matran6[i, j]);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = list[matran6[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran6[i, j] + 1;
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;
        }
    }

    public void Sinh_Khoi_4_O()
    {
        int random_luachon = Random.Range(1, 10);
        List<Color> list = new List<Color>();
        List<int> soSanh = new List<int>();
        for (int i = 1; i < MaTran_Luoi.instance.colorCell.Count; i++)
        {
            list.Add(MaTran_Luoi.instance.colorCell[i]);
        }        
        float xxx = 0f;
        float yyy = 0f;
        float delta = MaTran_Luoi.instance.cell_oTrong.GetComponent<RectTransform>().sizeDelta.x;

        switch (random_luachon)
        {
            case 1:
                int[,] matran1 = new int[1, 4];
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (soSanh.Count < 2)
                        {
                            matran1[i, j] = Random.Range(0, 4);
                        }
                        else if (soSanh.Count == 2)
                        {
                            if (soSanh[0] == soSanh[1])
                            {
                                list.RemoveAt(soSanh[0]);
                                matran1[i, j] = Random.Range(0, 3);
                            }

                            else
                            {
                                matran1[i, j] = Random.Range(0, 4);
                            }
                        }

                        else
                        {
                            if (soSanh[0] == soSanh[1] && soSanh[1] == soSanh[2])
                            {
                                for (int h = 0; h < list.Count; h++)
                                {
                                    list.RemoveAt(h);
                                }
                                for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                {
                                    list.Add(MaTran_Luoi.instance.colorCell[k]);
                                }

                                list.RemoveAt(soSanh[0]);
                                matran1[i, j] = Random.Range(0, 3);
                            }

                            if (soSanh[0] == soSanh[1] && soSanh[1] != soSanh[2])
                            {
                                for (int h = 0; h < list.Count; h++)
                                {
                                    list.RemoveAt(h);
                                }
                                for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                {
                                    list.Add(MaTran_Luoi.instance.colorCell[k]);
                                }
                                matran1[i, j] = Random.Range(0, 4);
                            }

                            else if (soSanh[0] != soSanh[1] && soSanh[1] == soSanh[2])
                            {
                                list.RemoveAt(soSanh[1]);
                                matran1[i, j] = Random.Range(0, 3);
                            }

                            else
                            {
                                for (int h = 0; h < list.Count; h++)
                                {
                                    list.RemoveAt(h);
                                }
                                for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                {
                                    list.Add(MaTran_Luoi.instance.colorCell[k]);
                                }
                                matran1[i, j] = Random.Range(0, 4);
                            }
                        }

                        soSanh.Add(matran1[i, j]);
                        GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                        khoi_1231.GetComponent<Image>().color = list[matran1[i, j]];
                        khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran1[i, j] + 1;
                        khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - ((3f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy);
                        arr_O_Trong_Khoi.Add(khoi_1231);
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                }
                break;

            case 2:
                int[,] matran2 = new int[4, 1];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {                      
                        if (soSanh.Count < 2)
                        {
                            matran2[i, j] = Random.Range(0, 4);
                        }

                        else if(soSanh.Count == 2)
                        {
                            if (soSanh[0] == soSanh[1])
                            {
                                list.RemoveAt(soSanh[0]);
                                matran2[i, j] = Random.Range(0, 3);
                            }

                            else
                            {
                                matran2[i, j] = Random.Range(0, 4);                                
                            }
                        }

                        else
                        {
                            if (soSanh[0] == soSanh[1] && soSanh[1] == soSanh[2])
                            {
                                for (int h = 0; h < list.Count; h++)
                                {
                                    list.RemoveAt(h);
                                }
                                for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                {
                                    list.Add(MaTran_Luoi.instance.colorCell[k]);
                                }

                                list.RemoveAt(soSanh[0]);
                                matran2[i, j] = Random.Range(0, 3);
                            }
                            else if (soSanh[0] == soSanh[1] && soSanh[1] != soSanh[2])
                            {
                                for(int h = 0; h < list.Count; h++)
                                {
                                    list.RemoveAt(h);
                                }
                                for(int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                {
                                    list.Add(MaTran_Luoi.instance.colorCell[k]);
                                }
                                matran2[i, j] = Random.Range(0, 4);
                            }
                            else if(soSanh[0] != soSanh[1] && soSanh[1] == soSanh[2])
                            {
                                list.RemoveAt(soSanh[1]);
                                matran2[i, j] = Random.Range(0, 3);
                            }
                            else
                            {
                                for (int h = 0; h < list.Count; h++)
                                {
                                    list.RemoveAt(h);
                                }
                                for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                {
                                    list.Add(MaTran_Luoi.instance.colorCell[k]);
                                }
                                matran2[i, j] = Random.Range(0, 4);
                            }
                        }

                        soSanh.Add(matran2[i, j]);
                        GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                        khoi_1231.GetComponent<Image>().color = list[matran2[i, j]];
                        khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran2[i, j] + 1;
                        khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx, yyy + (1.5f * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                        arr_O_Trong_Khoi.Add(khoi_1231);
                        yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);                        
                    }
                }
                break;

            case 3:
                int[,] matran3 = new int[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 1 && j == 1 || i == 2 && j == 1)
                        {
                            continue;
                        }
                        else
                        {
                            if (soSanh.Count < 2)
                            {
                                matran3[i, j] = Random.Range(0, 4);
                            }

                            else if (soSanh.Count == 2)
                            {
                                if (soSanh[0] == soSanh[1])
                                {
                                    list.RemoveAt(soSanh[0]);
                                    matran3[i, j] = Random.Range(0, 3);
                                }

                                else
                                {
                                    matran3[i, j] = Random.Range(0, 4);
                                }
                            }

                            else
                            {
                                if (soSanh[0] == soSanh[1] && soSanh[1] == soSanh[2])
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }

                                    list.RemoveAt(soSanh[0]);
                                    matran3[i, j] = Random.Range(0, 3);
                                }
                                else if (soSanh[0] == soSanh[1] && soSanh[0] != soSanh[2])
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }
                                    matran3[i, j] = Random.Range(0, 4);
                                }
                                else if (soSanh[0] != soSanh[1] && soSanh[0] == soSanh[2])
                                {
                                    list.RemoveAt(soSanh[0]);
                                    matran3[i, j] = Random.Range(0, 3);
                                }
                                else
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }
                                    matran3[i, j] = Random.Range(0, 4);
                                }
                            }

                            soSanh.Add(matran3[i, j]);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = list[matran3[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran3[i, j] + 1;
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - (1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640), yyy + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 4:
                int[,] matran4 = new int[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 0 && j == 1 || i == 2 && j == 1)
                        {
                            continue;
                        }
                        else
                        {
                            if (soSanh.Count < 2)
                            {
                                matran4[i, j] = Random.Range(0, 4);
                            }

                            else if (soSanh.Count == 2)
                            {
                                if (soSanh[0] == soSanh[1])
                                {
                                    list.RemoveAt(soSanh[0]);
                                    matran4[i, j] = Random.Range(0, 3);
                                }

                                else
                                {
                                    matran4[i, j] = Random.Range(0, 4);
                                }
                            }

                            else
                            {
                                if (soSanh[0] == soSanh[1] && soSanh[1] == soSanh[2])
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }

                                    list.RemoveAt(soSanh[0]);

                                    matran4[i, j] = Random.Range(0, 3);
                                }

                                else if (soSanh[0] != soSanh[1] && soSanh[1] == soSanh[2])
                                {
                                    list.RemoveAt(soSanh[1]);
                                    matran4[i, j] = Random.Range(0, 3);
                                }

                                else
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }
                                    matran4[i, j] = Random.Range(0, 4);
                                }
                            }

                            soSanh.Add(matran4[i, j]);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = list[matran4[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran4[i, j] + 1;
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - (1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640), yyy + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 5:
                int[,] matran5 = new int[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 0 && j == 1 || i == 1 && j == 1)
                        {
                            continue;
                        }
                        else
                        {
                            if (soSanh.Count < 2)
                            {
                                matran5[i, j] = Random.Range(0, 4);
                            }

                            else if (soSanh.Count == 2)
                            {
                                if (soSanh[0] == soSanh[1])
                                {
                                    list.RemoveAt(soSanh[0]);
                                    matran5[i, j] = Random.Range(0, 3);
                                }

                                else
                                {
                                    matran5[i, j] = Random.Range(0, 4);
                                }
                            }

                            else if (soSanh.Count == 3)
                            {
                                if (soSanh[0] == soSanh[1] && soSanh[1] == soSanh[2])
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }

                                    list.RemoveAt(soSanh[0]);
                                    matran5[i, j] = Random.Range(0, 3);
                                }

                                else if (soSanh[0] != soSanh[1] && soSanh[1] == soSanh[2])
                                {
                                    list.RemoveAt(soSanh[1]);
                                    matran5[i, j] = Random.Range(0, 3);
                                }

                                else
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }
                                    matran5[i, j] = Random.Range(0, 4);
                                }
                            }

                            soSanh.Add(matran5[i, j]);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = list[matran5[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran5[i, j] + 1;
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - (1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640), yyy + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 6:
                int[,] matran6 = new int[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 1 && j == 0 || i == 2 && j == 0)
                        {
                            continue;
                        }
                        else
                        {
                            if (soSanh.Count < 2)
                            {
                                matran6[i, j] = Random.Range(0, 4);
                            }

                            else if (soSanh.Count == 2)
                            {
                                if (soSanh[0] == soSanh[1])
                                {
                                    list.RemoveAt(soSanh[1]);
                                    matran6[i, j] = Random.Range(0, 3);
                                }

                                else
                                {
                                    matran6[i, j] = Random.Range(0, 4);
                                }
                            }

                            else
                            {
                                if(soSanh[0] == soSanh[1] && soSanh[0] == soSanh[2])
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }

                                    list.RemoveAt(soSanh[0]);
                                    matran6[i, j] = Random.Range(0, 3);
                                }
                                else if (soSanh[0] == soSanh[1] && soSanh[0] != soSanh[2])
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }
                                    matran6[i, j] = Random.Range(0, 4);
                                }
                                else if (soSanh[0] != soSanh[1] && soSanh[0] == soSanh[2])
                                {
                                    list.RemoveAt(soSanh[0]);
                                    matran6[i, j] = Random.Range(0, 3);
                                }
                                else
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }
                                    matran6[i, j] = Random.Range(0, 4);
                                }
                            }

                            soSanh.Add(matran6[i, j]);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = list[matran6[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran6[i, j] + 1;
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 7:
                int[,] matran7 = new int[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 0 && j == 0 || i == 2 && j == 0)
                        {
                            continue;
                        }
                        else
                        { 
                            if (soSanh.Count < 2)
                            {
                                matran7[i, j] = Random.Range(0, 4);
                            }

                            else if (soSanh.Count == 2)
                            {
                                if (soSanh[0] == soSanh[1])
                                {
                                    list.RemoveAt(soSanh[1]);
                                    matran7[i, j] = Random.Range(0, 3);
                                }

                                else
                                {
                                    matran7[i, j] = Random.Range(0, 4);
                                }
                            }

                            else
                            {
                                if (soSanh[0] == soSanh[1] && soSanh[1] == soSanh[2])
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }

                                    list.RemoveAt(soSanh[0]);
                                    matran7[i, j] = Random.Range(0, 3);
                                }

                                else if (soSanh[0] != soSanh[1] && soSanh[1] == soSanh[2])
                                {
                                    list.RemoveAt(soSanh[1]);
                                    matran7[i, j] = Random.Range(0, 3);
                                }

                                else
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }
                                    matran7[i, j] = Random.Range(0, 4);
                                }
                            } 
                            soSanh.Add(matran7[i, j]);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = list[matran7[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran7[i, j] + 1;
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 8:
                int[,] matran8 = new int[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 0 && j == 0 || i == 1 && j == 0)
                        {
                            continue;
                        }
                        else
                        {
                            if (soSanh.Count < 2)
                            {
                                matran8[i, j] = Random.Range(0, 4);
                            }

                            else if (soSanh.Count == 2)
                            {
                                if (soSanh[0] == soSanh[1])
                                {
                                    list.RemoveAt(soSanh[1]);
                                    matran8[i, j] = Random.Range(0, 3);
                                }

                                else
                                {
                                    matran8[i, j] = Random.Range(0, 4);
                                }
                            }

                            else
                            {
                                if (soSanh[0] == soSanh[1] && soSanh[1] == soSanh[2])
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }

                                    list.RemoveAt(soSanh[0]);
                                    matran8[i, j] = Random.Range(0, 3);
                                }

                                else if (soSanh[0] != soSanh[1] && soSanh[1] == soSanh[2])
                                {
                                    list.RemoveAt(soSanh[1]);
                                    matran8[i, j] = Random.Range(0, 3);
                                }

                                else
                                {
                                    for (int h = 0; h < list.Count; h++)
                                    {
                                        list.RemoveAt(h);
                                    }
                                    for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                    {
                                        list.Add(MaTran_Luoi.instance.colorCell[k]);
                                    }
                                    matran8[i, j] = Random.Range(0, 4);
                                }
                            }
                            soSanh.Add(matran8[i, j]);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = list[matran8[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran8[i, j] + 1;
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 9:
                int[,] matran9 = new int[2, 2];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (soSanh.Count < 2)
                        {
                            matran9[i, j] = Random.Range(0, 4);
                        }

                        else if (soSanh.Count == 2)
                        {
                            if (soSanh[0] == soSanh[1])
                            {
                                list.RemoveAt(soSanh[0]);
                                matran9[i, j] = Random.Range(0, 3);
                            }

                            else
                            {
                                matran9[i, j] = Random.Range(0, 4);
                            }
                        }

                        else
                        {                           
                            if (soSanh[0] == soSanh[1] && soSanh[1] == soSanh[2])
                            {
                                for (int h = 0; h < list.Count; h++)
                                {
                                    list.RemoveAt(h);
                                }
                                for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                {
                                    list.Add(MaTran_Luoi.instance.colorCell[k]);
                                }

                                list.RemoveAt(soSanh[0]);
                                matran9[i, j] = Random.Range(0, 3);
                            }
                            else if (soSanh[0] != soSanh[1] && soSanh[1] == soSanh[2])
                            {
                                list.RemoveAt(soSanh[1]);
                                matran9[i, j] = Random.Range(0, 3);
                            }
                            else
                            {
                                for (int h = 0; h < list.Count; h++)
                                {
                                    list.RemoveAt(h);
                                }
                                for (int k = 1; k < MaTran_Luoi.instance.colorCell.Count; k++)
                                {
                                    list.Add(MaTran_Luoi.instance.colorCell[k]);
                                }
                                matran9[i, j] = Random.Range(0, 4);
                            }
                        }

                        soSanh.Add(matran9[i, j]);
                        GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                        khoi_1231.GetComponent<Image>().color = list[matran9[i, j]];
                        khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran9[i, j] + 1;
                        khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - (1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640), yyy + (1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                        arr_O_Trong_Khoi.Add(khoi_1231);
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;
        }
    }

    public void Sinh_Khoi_5_O()
    {
        int random_luachon = Random.Range(0, 22);
        float xxx = 0f;
        float yyy = 0f;
        float delta = MaTran_Luoi.instance.cell_oTrong.GetComponent<RectTransform>().sizeDelta.x;

        switch (random_luachon)
        {
            case 0:
                int[,] matran0 = new int[5, 1];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        matran0[i, j] = Random.Range(1, 5);
                        GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                        khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran0[i, j]];
                        khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran0[i, j];
                        khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - (2f * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy);
                        arr_O_Trong_Khoi.Add(khoi_1231);
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                }
                break;

            case 1:
                int[,] matran1 = new int[5, 1];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        matran1[i, j] = Random.Range(1, 5);
                        GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                        khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran1[i, j]];
                        khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran1[i, j];
                        khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx, yyy + (2f * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                        arr_O_Trong_Khoi.Add(khoi_1231);
                        yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                }
                break;

            case 2:
                int[,] matran2 = new int[4, 2];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if ((i == 1 || i == 2 || i == 3) && j == 1)
                        {
                            continue;
                        }
                        else
                        {
                            matran2[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran2[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran2[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx, yyy + (2f * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 3:
                int[,] matran3 = new int[4, 2];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if ((i == 0 || i == 2 || i == 3) && j == 1)
                        {
                            continue;
                        }
                        else
                        {
                            matran3[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran3[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran3[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx, yyy + (2f * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 4:
                int[,] matran4 = new int[4, 2];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if ((i == 0 || i == 1 || i == 3) && j == 1)
                        {
                            continue;
                        }
                        else
                        {
                            matran4[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran4[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran4[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx, yyy + (2f * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 5:
                int[,] matran5 = new int[4, 2];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if ((i == 0 || i == 1 || i == 2) && j == 1)
                        {
                            continue;
                        }
                        else
                        {
                            matran5[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran5[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran5[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx, yyy + (2f * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 6:
                int[,] matran6 = new int[4, 2];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if ((i == 1 || i == 2 || i == 3) && j == 0)
                        {
                            continue;
                        }
                        else
                        {
                            matran6[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran6[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran6[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + (2f * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 7:
                int[,] matran7 = new int[4, 2];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if ((i == 0 || i == 2 || i == 3) && j == 0)
                        {
                            continue;
                        }
                        else
                        {
                            matran7[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran7[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran7[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + (2f * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 8:
                int[,] matran8 = new int[4, 2];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if ((i == 0 || i == 1 || i == 3) && j == 0)
                        {
                            continue;
                        }
                        else
                        {
                            matran8[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran8[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran8[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + (2f * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 9:
                int[,] matran9 = new int[4, 2];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if ((i == 0 || i == 1 || i == 2) && j == 0)
                        {
                            continue;
                        }
                        else
                        {
                            matran9[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran9[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran9[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + (2f * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 10:
                int[,] matran10 = new int[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 0 && j == 1)
                        {
                            continue;
                        }
                        else
                        {
                            matran10[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran10[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran10[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 11:
                int[,] matran11 = new int[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 2 && j == 1)
                        {
                            continue;
                        }
                        else
                        {
                            matran11[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran11[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran11[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 12:
                int[,] matran12 = new int[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 1 && j == 1)
                        {
                            continue;
                        }
                        else
                        {
                            matran12[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran12[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran12[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 13:
                int[,] matran13 = new int[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            continue;
                        }
                        else
                        {
                            matran13[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran13[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran13[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 14:
                int[,] matran14 = new int[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 2 && j == 0)
                        {
                            continue;
                        }
                        else
                        {
                            matran14[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran14[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran14[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 15:
                int[,] matran15 = new int[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (i == 1 && j == 0)
                        {
                            continue;
                        }
                        else
                        {
                            matran15[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran15[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran15[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = 0f;
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 16:
                int[,] matran16 = new int[4, 2];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if ((i == 0 && j == 0) || (i == 2 && j == 1) || (i == 3 && j == 1))
                        {
                            continue;
                        }
                        else
                        {
                            matran16[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran16[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran16[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + ((3f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = -delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 17:
                int[,] matran17 = new int[4, 2];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if ((i == 0 && j == 1) || (i == 2 && j == 0) || (i == 3 && j == 0))
                        {
                            continue;
                        }
                        else
                        {
                            matran17[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran17[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran17[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - ((1f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + ((3f / 2) * delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx = +delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 18:
                int[,] matran18 = new int[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((i == 0 && j == 1) || (i == 0 && j == 2) || (i == 2 && j == 0) || (i == 2 && j == 1))
                        {
                            continue;
                        }
                        else
                        {
                            matran18[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran18[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran18[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - (delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + (delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 19:
                int[,] matran19 = new int[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((i == 0 && j == 0) || (i == 0 && j == 1) || (i == 2 && j == 1) || (i == 2 && j == 2))
                        {
                            continue;
                        }
                        else
                        {
                            matran19[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran19[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran19[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + (delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + (delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 20:
                int[,] matran20 = new int[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((i == 0 && j == 2) || (i == 1 && j == 0) || (i == 1 && j == 2) || (i == 2 && j == 0))
                        {
                            continue;
                        }
                        else
                        {
                            matran20[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran20[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran20[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx - (delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + (delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;

            case 21:
                int[,] matran21 = new int[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((i == 0 && j == 0) || (i == 1 && j == 0) || (i == 1 && j == 2) || (i == 2 && j == 2))
                        {
                            continue;
                        }
                        else
                        {
                            matran21[i, j] = Random.Range(1, 5);
                            GameObject khoi_1231 = Instantiate(MaTran_Luoi.instance.cell_oTrong, this.transform);
                            khoi_1231.GetComponent<Image>().color = MaTran_Luoi.instance.colorCell[matran21[i, j]];
                            khoi_1231.GetComponent<cell_oTrong_scrips>().id = matran21[i, j];
                            khoi_1231.GetComponent<RectTransform>().anchoredPosition = new Vector2(xxx + (delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)), yyy + (delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640)));
                            arr_O_Trong_Khoi.Add(khoi_1231);
                        }
                        xxx -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    }
                    xxx += delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                    yyy -= delta * MaTran_Luoi.instance.sizeScreen.x * (1f / 640);
                }
                break;
        }
    }

    public void Khoi_ViTri()  
    {
        int rd = Random.Range(1, 6);
        switch (rd)
        {
            case 1:
                Sinh_Khoi_1_O();
                break;

            case 2:
                Sinh_Khoi_2_O();
                break;

            case 3:
                Sinh_Khoi_3_O();
                break;

            case 4:
                Sinh_Khoi_4_O();
                break;

            case 5:
                Sinh_Khoi_5_O();
                break;
        }
    }

    public bool Check_Khoi_1_O()
    {
        bool check = false;
        for (int i = 0; i < MaTran_Luoi.instance.list_cell.Count; i++)
        {
            if (MaTran_Luoi.instance.list_cell[i].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
            {
                check = true;
                break;
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

    public bool Check_Khoi_2_O()
    {
        bool check = false;
        float delta_x = arr_O_Trong_Khoi[0].GetComponent<RectTransform>().anchoredPosition.x - arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.x;
        float delta_y = arr_O_Trong_Khoi[0].GetComponent<RectTransform>().anchoredPosition.y - arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.y;

        MaTran_Luoi.instance.Lam_Tron(ref delta_x, ref delta_y);

        for (int i = 0; i < MaTran_Luoi.instance.list_cell.Count; i++)
        {
            if (MaTran_Luoi.instance.list_cell[i].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
            {
                Vector2 dem = new Vector2(MaTran_Luoi.instance.list_cell[i].GetComponent<RectTransform>().anchoredPosition.x - delta_x, MaTran_Luoi.instance.list_cell[i].GetComponent<RectTransform>().anchoredPosition.y - delta_y);

                for (int j = 0; j < MaTran_Luoi.instance.list_cell.Count; j++)
                {
                    if ((Mathf.Abs(dem.x - MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(dem.y - MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f))
                    {
                        if (MaTran_Luoi.instance.list_cell[j].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
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

                    if(check == true)
                    {
                        break;
                    }
                }
            }

            else
            {
                check = false;
            }

            if(check == true)
            {
                break;
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

    public bool Check_Khoi_3_O()
    {
        bool check = false;
        float delta_x1 = arr_O_Trong_Khoi[0].GetComponent<RectTransform>().anchoredPosition.x - arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.x;
        float delta_y1 = arr_O_Trong_Khoi[0].GetComponent<RectTransform>().anchoredPosition.y - arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.y;

        float delta_x2 = arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.x - arr_O_Trong_Khoi[2].GetComponent<RectTransform>().anchoredPosition.x;
        float delta_y2 = arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.y - arr_O_Trong_Khoi[2].GetComponent<RectTransform>().anchoredPosition.y;

        MaTran_Luoi.instance.Lam_Tron(ref delta_x1, ref delta_y1);
        MaTran_Luoi.instance.Lam_Tron(ref delta_x2, ref delta_y2);

        for (int i = 0; i < MaTran_Luoi.instance.list_cell.Count; i++)
        {
            if (MaTran_Luoi.instance.list_cell[i].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
            {
                Vector2 dem1 = new Vector2(MaTran_Luoi.instance.list_cell[i].GetComponent<RectTransform>().anchoredPosition.x - delta_x1, MaTran_Luoi.instance.list_cell[i].GetComponent<RectTransform>().anchoredPosition.y - delta_y1);

                for (int j = 0; j < MaTran_Luoi.instance.list_cell.Count; j++)
                {
                    if ((Mathf.Abs(dem1.x - MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(dem1.y - MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f))
                    {
                        if (MaTran_Luoi.instance.list_cell[j].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
                        {
                            Vector2 dem2 = new Vector2(MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.x - delta_x2, MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.y - delta_y2);

                            for (int k = 0; k < MaTran_Luoi.instance.list_cell.Count; k++)
                            {
                                if ((Mathf.Abs(dem2.x - MaTran_Luoi.instance.list_cell[k].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(dem2.y - MaTran_Luoi.instance.list_cell[k].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f))
                                {
                                    if (MaTran_Luoi.instance.list_cell[k].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
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

                                if(check == true)
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
                            break;
                        }
                    }

                    else
                    {
                        check = false;
                    }

                    if (check == true)
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
                break;
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

    public bool Check_Khoi_4_O()
    {
        bool check = false;
        float delta_x1 = arr_O_Trong_Khoi[0].GetComponent<RectTransform>().anchoredPosition.x - arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.x;
        float delta_y1 = arr_O_Trong_Khoi[0].GetComponent<RectTransform>().anchoredPosition.y - arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.y;

        float delta_x2 = arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.x - arr_O_Trong_Khoi[2].GetComponent<RectTransform>().anchoredPosition.x;
        float delta_y2 = arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.y - arr_O_Trong_Khoi[2].GetComponent<RectTransform>().anchoredPosition.y;

        float delta_x3 = arr_O_Trong_Khoi[2].GetComponent<RectTransform>().anchoredPosition.x - arr_O_Trong_Khoi[3].GetComponent<RectTransform>().anchoredPosition.x;
        float delta_y3 = arr_O_Trong_Khoi[2].GetComponent<RectTransform>().anchoredPosition.y - arr_O_Trong_Khoi[3].GetComponent<RectTransform>().anchoredPosition.y;

        MaTran_Luoi.instance.Lam_Tron(ref delta_x1, ref delta_y1);
        MaTran_Luoi.instance.Lam_Tron(ref delta_x2, ref delta_y2);
        MaTran_Luoi.instance.Lam_Tron(ref delta_x3, ref delta_y3);

        for (int i = 0; i < MaTran_Luoi.instance.list_cell.Count; i++)
        {
            if (MaTran_Luoi.instance.list_cell[i].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
            {
                Vector2 dem1 = new Vector2(MaTran_Luoi.instance.list_cell[i].GetComponent<RectTransform>().anchoredPosition.x - delta_x1, MaTran_Luoi.instance.list_cell[i].GetComponent<RectTransform>().anchoredPosition.y - delta_y1);

                for (int j = 0; j < MaTran_Luoi.instance.list_cell.Count; j++)
                {
                    if ((Mathf.Abs(dem1.x - MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(dem1.y - MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f))
                    {
                        if (MaTran_Luoi.instance.list_cell[j].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
                        {
                            Vector2 dem2 = new Vector2(MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.x - delta_x2, MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.y - delta_y2);

                            for (int k = 0; k < MaTran_Luoi.instance.list_cell.Count; k++)
                            {
                                if ((Mathf.Abs(dem2.x - MaTran_Luoi.instance.list_cell[k].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(dem2.y - MaTran_Luoi.instance.list_cell[k].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f))
                                {
                                    if (MaTran_Luoi.instance.list_cell[k].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
                                    {
                                        Vector2 dem3 = new Vector2(MaTran_Luoi.instance.list_cell[k].GetComponent<RectTransform>().anchoredPosition.x - delta_x3, MaTran_Luoi.instance.list_cell[k].GetComponent<RectTransform>().anchoredPosition.y - delta_y3);

                                        for (int h = 0; h < MaTran_Luoi.instance.list_cell.Count; h++)
                                        {
                                            if ((Mathf.Abs(dem3.x - MaTran_Luoi.instance.list_cell[h].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(dem3.y - MaTran_Luoi.instance.list_cell[h].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f))
                                            {
                                                if (MaTran_Luoi.instance.list_cell[h].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
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

                                            if(check == true)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        check = false;
                                    }

                                    if(check == true)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    check = false;
                                }

                                if (check == true)
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
                            break;
                        }
                    }

                    else
                    {
                        check = false;
                    }

                    if (check == true)
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
                break;
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

    public bool Check_Khoi_5_O()
    {
        bool check = false;
        float delta_x1 = arr_O_Trong_Khoi[0].GetComponent<RectTransform>().anchoredPosition.x - arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.x;
        float delta_y1 = arr_O_Trong_Khoi[0].GetComponent<RectTransform>().anchoredPosition.y - arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.y;

        float delta_x2 = arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.x - arr_O_Trong_Khoi[2].GetComponent<RectTransform>().anchoredPosition.x;
        float delta_y2 = arr_O_Trong_Khoi[1].GetComponent<RectTransform>().anchoredPosition.y - arr_O_Trong_Khoi[2].GetComponent<RectTransform>().anchoredPosition.y;

        float delta_x3 = arr_O_Trong_Khoi[2].GetComponent<RectTransform>().anchoredPosition.x - arr_O_Trong_Khoi[3].GetComponent<RectTransform>().anchoredPosition.x;
        float delta_y3 = arr_O_Trong_Khoi[2].GetComponent<RectTransform>().anchoredPosition.y - arr_O_Trong_Khoi[3].GetComponent<RectTransform>().anchoredPosition.y;

        float delta_x4 = arr_O_Trong_Khoi[3].GetComponent<RectTransform>().anchoredPosition.x - arr_O_Trong_Khoi[4].GetComponent<RectTransform>().anchoredPosition.x;
        float delta_y4 = arr_O_Trong_Khoi[3].GetComponent<RectTransform>().anchoredPosition.y - arr_O_Trong_Khoi[4].GetComponent<RectTransform>().anchoredPosition.y;

        MaTran_Luoi.instance.Lam_Tron(ref delta_x1, ref delta_y1);
        MaTran_Luoi.instance.Lam_Tron(ref delta_x2, ref delta_y2);
        MaTran_Luoi.instance.Lam_Tron(ref delta_x3, ref delta_y3);
        MaTran_Luoi.instance.Lam_Tron(ref delta_x4, ref delta_y4);

        for (int i = 0; i < MaTran_Luoi.instance.list_cell.Count; i++)
        {
            if (MaTran_Luoi.instance.list_cell[i].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
            {
                Vector2 dem1 = new Vector2(MaTran_Luoi.instance.list_cell[i].GetComponent<RectTransform>().anchoredPosition.x - delta_x1, MaTran_Luoi.instance.list_cell[i].GetComponent<RectTransform>().anchoredPosition.y - delta_y1);

                for (int j = 0; j < MaTran_Luoi.instance.list_cell.Count; j++)
                {
                    if ((Mathf.Abs(dem1.x - MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(dem1.y - MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f))
                    {
                        if (MaTran_Luoi.instance.list_cell[j].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
                        {
                            Vector2 dem2 = new Vector2(MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.x - delta_x2, MaTran_Luoi.instance.list_cell[j].GetComponent<RectTransform>().anchoredPosition.y - delta_y2);

                            for (int k = 0; k < MaTran_Luoi.instance.list_cell.Count; k++)
                            {
                                if ((Mathf.Abs(dem2.x - MaTran_Luoi.instance.list_cell[k].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(dem2.y - MaTran_Luoi.instance.list_cell[k].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f))
                                {
                                    if (MaTran_Luoi.instance.list_cell[k].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
                                    {
                                        Vector2 dem3 = new Vector2(MaTran_Luoi.instance.list_cell[k].GetComponent<RectTransform>().anchoredPosition.x - delta_x3, MaTran_Luoi.instance.list_cell[k].GetComponent<RectTransform>().anchoredPosition.y - delta_y3);

                                        for (int h = 0; h < MaTran_Luoi.instance.list_cell.Count; h++)
                                        {
                                            if ((Mathf.Abs(dem3.x - MaTran_Luoi.instance.list_cell[h].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(dem3.y - MaTran_Luoi.instance.list_cell[h].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f))
                                            {
                                                if (MaTran_Luoi.instance.list_cell[h].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
                                                {
                                                    Vector2 dem4 = new Vector2(MaTran_Luoi.instance.list_cell[h].GetComponent<RectTransform>().anchoredPosition.x - delta_x4, MaTran_Luoi.instance.list_cell[h].GetComponent<RectTransform>().anchoredPosition.y - delta_y4);

                                                    for (int f = 0; f < MaTran_Luoi.instance.list_cell.Count; f++)
                                                    {
                                                        if ((Mathf.Abs(dem4.x - MaTran_Luoi.instance.list_cell[f].GetComponent<RectTransform>().anchoredPosition.x) < 0.1f && Mathf.Abs(dem4.y - MaTran_Luoi.instance.list_cell[f].GetComponent<RectTransform>().anchoredPosition.y) < 0.1f))
                                                        {
                                                            if (MaTran_Luoi.instance.list_cell[f].GetComponent<Image>().color == MaTran_Luoi.instance.colorCell[0])
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
                                                }

                                                else
                                                {
                                                    check = false;
                                                }

                                                if(check == true)
                                                {
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                check = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        check = false;
                                    }
                                    if (check == true)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    check = false;
                                }
                            }
                        }
                        else
                        {
                            check = false;
                        }
                        if (check == true)
                        {
                            break;
                        }
                    }

                    else
                    {
                        check = false;
                    }
                }
            }

            else
            {
                check = false;
            }

            if (check == true)
            {
                break;
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
}
