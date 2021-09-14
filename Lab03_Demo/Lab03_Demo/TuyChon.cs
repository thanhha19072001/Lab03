using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_Demo
{
    public class SinhVienSortNgaySinh : IComparer<SinhVien>
    {
        public int Compare(SinhVien x, SinhVien y)
        {
            return x.NgaySinh.CompareTo(y.NgaySinh);
        }
    }

    public class SinhVienSortMaSo : IComparer<SinhVien>
    {
        public int Compare(SinhVien x, SinhVien y)
        {
            return int.Parse(x.MaSo) - int.Parse(y.MaSo);
        }
    }

    public class SinhVienSortHoTen : IComparer<SinhVien>
    {
        public int Compare(SinhVien x, SinhVien y)
        {
            var firstWords = x.HoTen.Split(' ');
            var secondWords = y.HoTen.Split(' ');

            var firstName = firstWords[firstWords.Length - 1];
            var secondName = secondWords[secondWords.Length - 1];

            return firstName.CompareTo(secondName);
        }
    }
}