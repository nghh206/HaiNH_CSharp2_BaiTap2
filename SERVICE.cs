using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HaiNH_CSharp2_BaiTap2
{
    internal class SERVICE
    {
        List<Bike> _lstBike = new List<Bike>();
        BinaryFormatter _bf = new BinaryFormatter();
        FileStream _fs;
        string filepath = @"C:\Users\Acer\Desktop\Training\HaiNH_CSharp1_BaiTap2\docghi.bin";

        public void NhapThongTin()
        {
            string tiepTuc;
            do
            {
                Bike bike = new Bike();
                bike.iD = ++Bike.IdTuTang; 
                Console.WriteLine("Mời nhập vào tên: ");
                bike.ten = Console.ReadLine();
                Console.WriteLine("Mời nhập vào hãng sản xuất: ");
                bike.hSX = Console.ReadLine();
                
                if (_lstBike.Any(b => b.iD == bike.iD))
                {
                    Console.WriteLine($"Xe đạp với iD đã nhập đã tồn tại trong danh sách!"); 
                }
                else
                {
                    _lstBike.Add(bike); 
                }
                Console.WriteLine("Bạn có muốn nhập tiếp không? N:Không   Phím còn lại: Có");
                tiepTuc = Console.ReadLine();
            } while (tiepTuc.ToLower() != "N");
        }
        public void XuatThongTin()
        {
            Console.WriteLine("Thông tin của sinh viên: ");
            foreach (var item in _lstBike)
            {
                item.InThongTin();
            }
        }
        public void LuuFile()
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            else
            {
                try
                {
                    _fs = new FileStream(filepath, FileMode.OpenOrCreate); 
                    _bf.Serialize(_fs, _lstBike); 
                    _fs.Close();
                    Console.WriteLine("Lưu file thành công!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public List<Bike> DocFile() 
        {
            if (!File.Exists(filepath))
            {
                Console.WriteLine($"{filepath} không tồn tại!"); 
                return new List<Bike>();  
            }
            else
            {
                try
                {
                    _fs = new FileStream(filepath, FileMode.Open, FileAccess.Read); 
                    var doc = _bf.Deserialize(_fs) as List<Bike>; 
                    _fs.Close();
                    return doc; 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return null; 
            }
        }

        public void XoaID()
        {
            bool tiepTuc = true;
            while (tiepTuc)
            {
                Console.WriteLine("Nhập ID bạn muốn xóa: ");
                int id = Convert.ToInt32(Console.ReadLine());

                var bike = _lstBike.FirstOrDefault(x => x.iD == id);
                if (bike != null)
                {
                    _lstBike.Remove(bike);
                    Console.WriteLine("Xóa thành công!");
                }
                else
                {
                    Console.WriteLine($"Không tìm thấy đối tượng có ID = {id}");
                }

                Console.WriteLine("Bạn có muốn xóa thêm không? (Y/N)");
                string tiepTucChuoi = Console.ReadLine();

                if (tiepTucChuoi.ToLower() == "Y")
                {
                    tiepTuc = true;
                }
                else if(tiepTucChuoi.ToLower() == "N")
                {
                    tiepTuc = false;
                }
            }
        }
    }
}
