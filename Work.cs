using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    class Work
    {
        private string name;

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            name = value;
        }

        private string content;

        public string GetContent()
        {
            return content;
        }

        public void SetContent(string value)
        {
            content = value;
        }

        private DateTime timeCreate;

        public DateTime GetTimeCreate()
        {
            return timeCreate;
        }

        public void SetTimeCreate(DateTime value)
        {
            timeCreate = value;
        }

        private DateTime timeDue;

        public DateTime GetTimeDue()
        {
            return timeDue;
        }

        public void SetTimeDue(DateTime value)
        {
            timeDue = value;
        }

        private bool isSuccess;

        public bool GetIsSuccess()
        {
            return isSuccess;
        }

        public void SetIsSuccess(bool value)
        {
            isSuccess = value;
        }

        public Work() { }

        public Work(string name, string content, DateTime timeCreate)
        {
            SetName(name);
            SetContent(content);
            SetTimeCreate(timeCreate);
            this.SetIsSuccess(false);
        }

        public void Input()
        {
            Console.Write("Nhập vào tên công việc : ");
            SetName(Console.ReadLine());

            Console.Write("Nhập vào nội dung công việc : ");
            SetContent(Console.ReadLine());

            do
            {
                Console.Write("Nhập vào ngày hết hạn (d/M/YYYY): ");
                string strTemp = Console.ReadLine();

                try
                {
                    SetTimeDue(DateTime.ParseExact(strTemp, "d/M/yyyy", CultureInfo.CurrentCulture));
                    if (GetTimeDue().Date.CompareTo(DateTime.Today) < 0)
                    {
                        Console.WriteLine("Ngày đã nhập không hợp lệ, vui lòng nhập lại.");
                        continue;
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ngày đã nhập không hợp lệ, vui lòng nhập lại.");
                }

            } while (true);

            SetTimeCreate(DateTime.Now);
        }

        public void Ouput()
        {
            Console.WriteLine("========= Công việc đã nhập ===========");
            Console.WriteLine($"Tên công việc : {GetName()}");
            Console.WriteLine($"Nội dung công việc : {GetContent()}");
            Console.WriteLine($"Ngày tạo công việc : {GetTimeCreate().ToString("d/M/yyyy")}");
            Console.WriteLine($"Ngày hết hạn : {GetTimeDue().ToString("d/M/yyyy")}");
        }

        public void setAccomplished()
        {
            SetIsSuccess(true);
        }

        public override string ToString()
        {
            return string.Format("{0, -20}|{1, -35}|{2, -15}|{3, -15}|{4, -17}", GetName(), GetContent(), GetTimeCreate().ToString("d/M/yyyy"), GetTimeDue().ToString("d/M/yyyy"), (GetIsSuccess() ? "Đã hoàn thành" : "Chưa hoàn thành"));
        }
    }
    
}
    

    

