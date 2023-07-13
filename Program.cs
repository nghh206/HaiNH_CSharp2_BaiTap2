using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiNH_CSharp2_BaiTap2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Menu();
            Console.ReadKey();
        }
        static void Menu()
        {
            SERVICE SERVICES = new SERVICE();
            int choice;

            do
            {
                Console.WriteLine("                             Menu                             ");
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("1. Nhập thông tin ");
                Console.WriteLine("2. Xuất thông tin ");
                Console.WriteLine("3. Lưu file ");
                Console.WriteLine("4. Đọc file ");;
                Console.WriteLine("5. Xóa đối tượng theo ID sử dụng LinQ ");
                Console.WriteLine("0. Thoát ");
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Mời chọn 1 chức năng.");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        SERVICES.NhapThongTin();
                        break;
                    case 2:
                        SERVICES.XuatThongTin();
                        break;
                    case 3:
                        SERVICES.LuuFile();
                        break;
                    case 4:
                        foreach (var item in SERVICES.DocFile())
                        {
                            item.InThongTin();
                        }
                        break;
                    case 5:
                        SERVICES.XoaID();
                        break;
                    case 0:
                        Console.WriteLine("Cảm ơn đã sử dụng chương trình");
                        break;
                    default:
                        Console.WriteLine("Mời chọn chức năng có trong chương trình");
                        break;
                }
            } while (choice != 0);
        }
    }
}
