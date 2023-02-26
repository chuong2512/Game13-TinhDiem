using System;
using System.Text.RegularExpressions;
using TinhDiem;
using TMPro;
using UnityEngine.UI;

public class TinhDiemManager : Singleton<TinhDiemManager>
{
    public Text soBaoDanh;

    public Diem[] diemChung;
    public Diem[] diemPhu;

    public Diem diemTong;

    public string[] monChung;
    public string[] diemRieng1;
    public string[] diemRieng2;

    public static bool ValidateNumber(string number)
    {
        // Kiểm tra số báo danh có đúng định dạng hay không
        Regex regex = new Regex(@"^\d{8}$");
        if (!regex.IsMatch(number))
        {
            PopupManager.Instance.ShowText("Số báo danh bao gồm 8 chữ số !!");
            return false;
        }

        // Kiểm tra tính hợp lệ của số báo danh
        foreach (char c in number)
        {
            if (!char.IsDigit(c))
            {
                PopupManager.Instance.ShowText("Số báo danh không hợp lệ " +
                                               "\n Vui lòng nhập lại số báo danh của bạn.");
                return false;
            }
        }

        return true;
    }

    public void Caculate()
    {
        //check so bao danh 
        if (ValidateNumber(soBaoDanh.text))
        {
            if (GameDataManager.Instance.playerData.intDiamond >= 10000)
            {
                GameDataManager.Instance.playerData.SubDiamond(10000);
            }
            else
            {
                PopupManager.Instance.ShowText("Không đủ tiền mặt " +
                                               "\n Vui lòng nạp tiền vào tài khoản.");
                return;
            }

            float diemTB = 0;

            bool check = true;

            for (int i = 0; i < diemChung.Length; i++)
            {
                var diem = GetDiem();
                diemTB += diem;

                if (diem < 1)
                {
                    check = false;
                }

                diemChung[i].Init(monChung[i], diem);
            }

            Random random = new Random();

            if (random.Next() == 1)
            {
                for (int i = 0; i < diemPhu.Length; i++)
                {
                    var diem = GetDiem();
                    diemTB += diem;
                    if (diem < 1)
                    {
                        check = false;
                    }

                    diemPhu[i].Init(diemRieng1[i], diem);
                }
            }
            else
            {
                for (int i = 0; i < diemPhu.Length; i++)
                {
                    var diem = GetDiem();
                    diemTB += diem;
                    if (diem < 1)
                    {
                        check = false;
                    }

                    diemPhu[i].Init(diemRieng2[i], diem);
                }
            }

            diemTB /= 6;

            string ketQua = "";

            if (diemTB >= 5 && check)
            {
                ketQua = "Đỗ";
            }
            else
            {
                ketQua = "Trượt";
            }

            diemTong.Init("Điểm Tổng", diemTB, ketQua);
        }
    }

    public float GetDiem()
    {
        Random random = new Random();
        return (float) (random.NextDouble() * 9 + 1);
    }
}