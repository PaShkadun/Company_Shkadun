using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Company_Shkadun
{
    class Program
    {
        static String[] EmpoyyesName = {   "Ivan", "Alex", "Alcoholic", "Sam", "Dick",
                                        "Vendi", "Sasha", "Smith", "Nik", "Elisey"};
        static String[] EmpoyeesJob = { "J. prog.", "M. prog", "S. prog", "Manager", "Big Boss" };
        static int[] EmpoyeesSalary = { 1000, 2000, 5000, 8000, 10000 };
        static Random rand = new Random();
        static void Main(string[] args) 
        {
            Empoyee emp = new Empoyee();
            String profit = "Компании заплатили за работу 2000",
                    fine = "Компании влипили штраф 2000",
                    companyCheck = "В компании проверка. Месяц без работы.",
                    empFired = "Сотрудник - долбаёб. Из-за его расточительности его уволили.",
                    empQualificationUp = "Сотрудник - красавчик. Благодаря его работе компания подняла" +
                                         " бабок. Его подняли по службе.",
                    nothingIntresting = "В компании в этом месяце не произошло ничего особого.",
                    companyClosed = "В компании больше никто не работает. Она закрылась.",
                    newEmpoyee = "В компании новый сотрудник!";

            int CompanyMoney;
            Console.WriteLine("Бюджет компании: ");
            for( ; ; ) if(Int32.TryParse(Console.ReadLine(), out CompanyMoney)) break;
            Console.WriteLine("Название компании: ");
            Company company = new Company(Console.ReadLine(), CompanyMoney);
            Empoyee[] empArray = new Empoyee[10];
            emp.Name = EmpoyyesName[0];
            emp.position = EmpoyeesJob[0];
            emp.salary = EmpoyeesSalary[0];
            emp.cash = EmpoyeesSalary[0];
            empArray[0] = emp;
            company.CompanyEmpoyees = empArray;
            int i = 0, j = 0, n = 0, cash, countEmpoyees = 1, actionsRand;
            while(i++ < 36)
            {
                while(j++ < 5)
                {
                    while(n < countEmpoyees)
                    {
                        cash = rand.Next(-1000, 1000);
                        if(cash < 0)
                            Console.WriteLine(  $"Сотрудник {company.CompanyEmpoyees[n].Name} " +
                                                $"просрал {cash} денег из бюджета");
                        else
                            Console.WriteLine(  $"Сотрудник {company.CompanyEmpoyees[n].Name} " +
                                                $"принёс {cash} денег бюджету");
                        company.CompanyMoney += cash;
                        empArray[n].profit += cash;
                        if(empArray[n].profit < (-1 * (empArray[n].salary * 3)))
                        {
                            Console.WriteLine(empFired);
                            empArray[n] = null;
                            if(n != (countEmpoyees - 1))
                            {
                                empArray[n] = empArray[countEmpoyees - 1];
                                empArray[countEmpoyees - 1] = null;
                            }
                            countEmpoyees -= 1;
                            if(countEmpoyees == 0)
                            {
                                Console.WriteLine(companyClosed);
                                n = 10; j = 10; i = 36;
                            }
                        }
                        else if(empArray[n].profit > (empArray[n].salary * 3))
                        {
                            Console.WriteLine(empQualificationUp);
                            QualificationUp(empArray[n]);
                        }
                        n++;
                    }
                    Thread.Sleep(1000);
                    n = 0;
                }
                if (countEmpoyees > 0 && company.CompanyMoney > 0)
                {
                    actionsRand = rand.Next(0, 1000);
                    if (actionsRand < 250 || actionsRand > 850) Console.WriteLine(nothingIntresting);
                    else if (actionsRand >= 250 && actionsRand <= 350)
                    {
                        if (countEmpoyees != 10)
                        {
                            Console.WriteLine(newEmpoyee);
                            addEmpoyee(empArray, countEmpoyees++);
                        }
                        else Console.WriteLine(nothingIntresting);
                    }
                    else if (actionsRand >= 351 && actionsRand <= 550)
                    {
                        Console.WriteLine(fine);
                        company.CompanyMoney -= 2000;
                    }
                    else if (actionsRand >= 551 && actionsRand <= 750)
                    {
                        Console.WriteLine(profit);
                        company.CompanyMoney += 2000;
                    }
                    else if (actionsRand >= 751 && actionsRand <= 850)
                    {
                        Console.WriteLine(companyCheck);
                        Thread.Sleep(5000);
                        i++;
                    }
                    Console.WriteLine($"Бюджет на конец месяца: {company.CompanyMoney}");
                }
                j = 0;
            }
            //company.CompanyEmpoyees[1] = emp1;
            //Console.WriteLine(company.CompanyEmpoyees[0].Name);
            Console.ReadKey();
        }

        public static void addEmpoyee(Empoyee[] emp, int count)
        {
            emp[count] = new Empoyee();
            emp[count].Name = EmpoyyesName[rand.Next(0, 9)];
            emp[count].salary = EmpoyeesSalary[0];
            emp[count].position = EmpoyeesJob[0];
        }

        public static void QualificationUp(Empoyee emp)
        {
            switch (emp.position)
            {
                case "J. prog.":
                    emp.position = "M. prog.";
                    emp.salary = 2000;
                    break;
                case "M. prog.":
                    emp.position = "S. prog.";
                    emp.salary = 5000;
                    break;
                case "S. prog.":
                    emp.position = "Manager";
                    emp.salary = 8000;
                    break;
                case "Manager":
                    emp.position = "Big Boss";
                    emp.salary = 10000;
                    break;
                default:
                    break;
            }
        }
    }
}
