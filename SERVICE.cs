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
                bike.iD = ++Bike.IdTuTang; // ID tự tăng
                Console.WriteLine("Mời nhập vào tên: ");
                bike.ten = Console.ReadLine();
                Console.WriteLine("Mời nhập vào hãng sản xuất: ");
                bike.hSX = Console.ReadLine();
                // Kiểm tra trùng lặp theo thuộc tính iD
                if (_lstBike.Any(b => b.iD == bike.iD))// Dùng Any kiếm tra trong _lstBike có trùng hay không
                {
                    Console.WriteLine($"Xe đạp với iD đã nhập đã tồn tại trong danh sách!"); // Nếu có thì thông báo trùng
                }
                else
                {
                    _lstBike.Add(bike); // Nếu không thì thêm vào 
                }
                Console.WriteLine("Bạn có muốn nhập tiếp không? N:Không   Phím còn lại: Có");
                tiepTuc = Console.ReadLine();
            } while (tiepTuc.ToLower() != "n");
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
                    _fs = new FileStream(filepath, FileMode.OpenOrCreate); // Dùng đối tượng FileStream để mở hoặc tạo file
                    _bf.Serialize(_fs, _lstBike); // Dùng BinaryFomatter để chuyển đối tượng thành chuỗi byte và lưu trữ _lstBike
                    _fs.Close();
                    Console.WriteLine("Lưu file thành công!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public List<Bike> DocFile() // Generic kiểu dữ liệu List<Bike>
        {
            if (!File.Exists(filepath))
            {
                Console.WriteLine($"{filepath} không tồn tại!"); // Nếu rỗng thì sẽ thông báo   
                return new List<Bike>();   // Và trả về danh sách rỗng
            }
            else
            {
                try
                {
                    _fs = new FileStream(filepath, FileMode.Open, FileAccess.Read); // Nếu tồn tại file thì sẽ mở và đọc file bằng FileStream
                    var doc = _bf.Deserialize(_fs) as List<Bike>; // bằng Deserialize của BinaryFomater 
                    _fs.Close();
                    return doc; // trả về danh sách vừa đọc được
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return null; // Khi lỗi đọc file sẽ trả về null
            }
        }

        public void XoaID()
        {
            // Biến tiepTuc được sử dụng để kiểm soát việc lặp lại hỏi người dùng có muốn xóa thêm hay không
            bool tiepTuc = true;

            while (tiepTuc)
            {
                // Yêu cầu người dùng nhập giá trị ID của đối tượng Bike muốn xóa
                Console.WriteLine("Nhập ID bạn muốn xóa: ");
                int id = Convert.ToInt32(Console.ReadLine());

                // Tìm kiếm đối tượng Bike trong danh sách có ID tương ứng với giá trị được nhập
                var bike = _lstBike.FirstOrDefault(x => x.iD == id);
                if (bike != null)
                {
                    // Nếu tìm thấy đối tượng Bike, xóa nó khỏi danh sách
                    _lstBike.Remove(bike);
                    Console.WriteLine("Xóa thành công!");
                }
                else
                {
                    // Nếu không tìm thấy đối tượng Bike, in ra thông báo lỗi
                    Console.WriteLine($"Không tìm thấy đối tượng có ID = {id}");
                }

                // Hỏi người dùng có muốn xóa thêm đối tượng Bike hay không
                Console.WriteLine("Bạn có muốn xóa thêm không? (Y/N)");
                string tiepTucChuoi = Console.ReadLine();

                // Nếu người dùng nhập Y hoặc y, tiếp tục vòng lặp để hỏi tiếp
                if (tiepTucChuoi.ToLower() == "Y")
                {
                    tiepTuc = true;
                }
                else
                {
                    // Nếu người dùng nhập bất kỳ giá trị khác, dừng vòng lặp
                    tiepTuc = false;
                }
            }
        }
    }
}
