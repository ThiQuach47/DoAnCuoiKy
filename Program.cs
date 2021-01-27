using DoAn;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Application application = new Application();
            application.ShowMenu();

            //Console.ReadKey();

        }
    }


    class Application
    {
        List<Work> Lists;

        public Application()
        {
            Lists = new List<Work>();
        }
        public void ShowMenu()
        {
            do
            {
                Console.WriteLine("============= MENU ===========");
                Console.WriteLine("1. Thêm công việc.");
                Console.WriteLine("2. Xem danh sách công việc.");
                Console.WriteLine("3. Đánh dấu đã hoàn thành công việc.");
                Console.WriteLine("4. Xoá công việc.");
                Console.WriteLine("0. Thoát chương trình.");
                Console.Write("Mời nhập lựa chọn : ");
                int luachon = getChoses();

                switch (luachon)
                {
                    case 1:
                        {
                            TaoCV();
                            break;
                        }
                    case 2:
                        {
                            HienThiDS();
                            break;
                        }
                    case 3:
                        {
                            HoanThanhCV();
                            break;
                        }
                    case 4:
                        {
                            XoaCV();
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Hẹn gặp lại lần sau.");
                            return;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                            break;
                        }
                }
            } while (true);
        }

        private void XoaCV()
        {
        }

        public void HoanThanhCV()
        {
        }

        private void SapXep()
        {
          
            Lists.Sort(delegate (Work x, Work y)
            {
                if (x.GetIsSuccess() == y.GetIsSuccess())
                {
                    return x.GetTimeDue().CompareTo(y.GetTimeDue());
                }
                else
                {
                    if (x.GetIsSuccess() == false)
                    {
                        return -1;
                    }
                    return 1;
                }
            }
            );
        }



        public void TaoCV()
        {
            Console.Clear();
            Work work = new Work();
            work.Input();

            Console.Clear();
            work.Ouput();
            Console.Write("(Ấn 1 phím bất kỳ để quay lại Menu)");

            Lists.Add(work);
            SapXep();

            Console.ReadKey();
            Console.Clear();
            
        }

        public void HienThiDS()
        {
            Console.Clear();
            Console.WriteLine("========== Danh sách công việc ========");
            Console.WriteLine("{0, -20}|{1, -35}|{2, -15}|{3, -15}|{4, -17}", "Tên công việc", "Nội dung", "Ngày tạo", "Ngày hết hạn", "Hoàn thành");
            Console.WriteLine(new String('=', 102));
            for (int i = 0; i < Lists.Count; i++)
            {
                Console.WriteLine(Lists[i].ToString());
            }
            Console.Write("(Ấn 1 phím bất kỳ để quay lại Menu)");

            Console.ReadKey();
            Console.Clear();

        }

        public int getChoses()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}


   