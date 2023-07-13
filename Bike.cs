using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiNH_CSharp2_BaiTap2
{
    [Serializable]
    internal class Bike
    {
        private int ID;
        private string Ten;
        private string HSX;
        public static int IdTuTang = 0;

        public Bike()
        {
            
        }

        public Bike(int iD, string ten, string hSX)
        {
            ID = iD;
            Ten = ten;
            HSX = hSX;
            IdTuTang =++  IdTuTang;
        }

        public int iD{ get => ID; set => ID = value; }
        public string ten { get => Ten; set => Ten = value; }
        public string hSX { get => HSX; set => HSX = value; }

        public void InThongTin()
        {
            Console.WriteLine($"ID: {ID} | Tên: {Ten} | Hãng sản xuất xe: {HSX}");
        }
    }
}
