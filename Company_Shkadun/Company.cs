using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Shkadun
{
    public class Company
    {
        Empoyee[] _CompanyEmpoyees = new Empoyee[5];
        public Company(string name, int money)
        {
            NameCompany = name;
            CompanyMoney = money;
        }
        public string NameCompany { get; set; }
        public int CompanyMoney { get; set; }
        public Empoyee[] CompanyEmpoyees { get; set; }

        private int test = 0;
        private int test1 = 0;
    }
}
