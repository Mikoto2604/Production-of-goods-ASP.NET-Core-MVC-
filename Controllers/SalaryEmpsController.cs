using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Enterprises_manufacturing_goods;
using Enterprises_manufacturing_goods.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Enterprises_manufacturing_goods.Controllers
{
    public class SalaryEmpsController : Controller
    {
        private SqlConnection connect = null; // Переменная для подключения к базе данных
        string M = "";
        float allcountOfSalary = 0;
        public string connectionstring = "Data Source=KYLYM;Initial Catalog=SUBD;User ID=User;Password=12345"; // Строка подключения к базе данных

        public List<SalaryEmp> GetValuesofYearAndMonth(int Year,int Month) // Дополнительный метод. Возвращает список записей по выбранной дате
        {
            connect = new SqlConnection(connectionstring); // Создаем новое соединение
            Employees employees = new Employees(); // Обьект класса Employees
            Years years1 = new Years();
            Months months1 = new Months();
            SqlCommand cmd2 = new SqlCommand(); // Создаем новую команду
            cmd2.Connection = connect; // Соединяемся
            cmd2.CommandType = System.Data.CommandType.StoredProcedure; // Определяем тип команды. В нашем случае - это вызов хранимой процедуры
            cmd2.CommandText = "SelectAllEmployees"; // Вызываем хранимую процедуру
            connect.Open(); // Открываем соединение
            SqlDataReader getvalues = cmd2.ExecuteReader(); // Выполняем запрос и записываем результат в переменную SqlDataReader
            List<Employees> employees1 = new List<Employees>();
            if (getvalues.HasRows) // если есть записи
            {
                while (getvalues.Read()) // Читаем результат
                {
                    employees1.Add(new Employees() // Добавляем в список с типом Employees
                    {
                        // Так как SqlDataReader возвращает обьекты, нам необходимо перевести результаты в нужные нам типы данных
                        Id = Convert.ToInt32(getvalues[0]),
                        Fullname = getvalues[1].ToString(),
                        Position = (short)getvalues[2],
                        Salary = Convert.ToDecimal(getvalues[3]),
                        Address = (getvalues[4]).ToString(),
                        Telephone = (getvalues[4]).ToString(),
                    });
                }
            }
            getvalues.Close(); // Закрываем SqlDataReader. Без этого другие запросы не смогу выполниться 


            
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = connect;
            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
            cmd3.CommandText = "SelectAllMonths";
            
            SqlDataReader getvalues2 = cmd3.ExecuteReader();
            List<Months> months = new List<Months>();
            if (getvalues2.HasRows)
            {
                while (getvalues2.Read())
                {

                    months.Add(new Months()
                    {

                        Id = (byte)getvalues2[0],
                        MonthName = (getvalues2[1]).ToString(),
                    });
                }
            }
            getvalues2.Close();

            
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = connect;
            cmd4.CommandType = System.Data.CommandType.StoredProcedure;
            cmd4.CommandText = "SelectAllYears";
            
            SqlDataReader getvalues3 = cmd4.ExecuteReader();
            List<Years> years = new List<Years>();
            if (getvalues3.HasRows)
            {
                while (getvalues3.Read())
                {

                    years.Add(new Years()
                    {

                        YearName = (int)getvalues3[0],
                    });
                }
            }
            getvalues3.Close();

          
            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = connect;
            cmd5.CommandType = System.Data.CommandType.StoredProcedure;
            cmd5.CommandText = "SelectYearMonth";
            cmd5.Parameters.Add(new SqlParameter("@Year", Year)); // Первый входной параметр
            cmd5.Parameters.Add(new SqlParameter("@Month", Month)); // Второй входной параметр
            
            SqlDataReader getvalues4 = cmd5.ExecuteReader();
            List<SalaryEmp> salaryEmps = new List<SalaryEmp>();

            if (getvalues4.HasRows)
            {
                while (getvalues4.Read())
                {
                    foreach (Employees val in employees1)
                    {
                        foreach (Years val2 in years)
                        {
                            foreach (Months val3 in months)
                            {
                                if (val.Id == Convert.ToInt32(getvalues4[3]) && val2.YearName == (int)(getvalues4[1]) && val3.Id == (byte)getvalues4[2])
                                {
                                    employees = val;
                                    years1 = val2;
                                    months1 = val3;
                                    salaryEmps.Add(new SalaryEmp()
                                    {
                                        Id = (int)getvalues4[0],
                                        Year = (int?)getvalues4[1],
                                        Month = Convert.ToInt32(getvalues4[2]),
                                        Employee = (int)getvalues4[3],
                                        ParticipationPurchase = (byte?)getvalues4[4],
                                        ParticipationSale = (byte?)getvalues4[5],
                                        ParticipationProduction = (byte?)getvalues4[6],
                                        CountParticipation = (byte?)getvalues4[7],
                                        SalaryEmployee = (decimal?)getvalues4[8],
                                        TotalAmount = (float?)getvalues4[9],
                                        Issued = (bool)getvalues4[10],
                                        Bonus = (float?)getvalues4[11],
                                        YearNavigation = years1,
                                        MonthNavigation = months1,
                                        EmployeeNavigation = employees,
                                    });
                                }
                            }

                        }

                    }
                }
            }
            getvalues4.Close();
            connect.Close();
            return salaryEmps;
        }

        public List<SalaryEmp> GetValuesofSalary() // Возвращает весь список записей
        {
            connect = new SqlConnection(connectionstring);
            Employees employees = new Employees();
            Years years1 = new Years();
            Months months1 = new Months();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllEmployees";
            
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Employees> employees1 = new List<Employees>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    employees1.Add(new Employees()
                    {
                        Id = Convert.ToInt32(getvalues[0]),
                        Fullname = getvalues[1].ToString(),
                        Position = (short?)getvalues[2],
                        Salary = Convert.ToDecimal(getvalues[3]),
                        Address = (getvalues[4]).ToString(),
                        Telephone = (getvalues[4]).ToString(),
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            var years = GetValuesofYears();
            var months = GetValuesofMonths();
            List<SalaryEmp> salaryEmps = new List<SalaryEmp>();
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = connect;
            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
            cmd3.CommandText = "SelectAllSalary";
            connect.Open();
            SqlDataReader getvalues3 = cmd3.ExecuteReader();
           
            if (getvalues3.HasRows)
            {
                while (getvalues3.Read())
                {
                    foreach (Employees val in employees1)
                    {
                        foreach (Years val2 in years)
                        {
                            foreach (Months val3 in months)
                            {
                                if (val.Id == Convert.ToInt32(getvalues3[3]) && val2.YearName == (int)(getvalues3[1]) && val3.Id == (byte)getvalues3[2])
                                {
                                    employees = val;
                                    years1 = val2;
                                    months1 = val3;
                                    salaryEmps.Add(new SalaryEmp()
                                    {
                                        Id = (int)getvalues3[0],
                                        Year = (int?)getvalues3[1],
                                        Month = Convert.ToInt32(getvalues3[2]),
                                        Employee = (int)getvalues3[3],
                                        ParticipationPurchase = (byte?)getvalues3[4],
                                        ParticipationSale = (byte?)getvalues3[5],
                                        ParticipationProduction = (byte?)getvalues3[6],
                                        CountParticipation = (byte?)getvalues3[7],
                                        SalaryEmployee = (decimal?)getvalues3[8],
                                        TotalAmount = (float?)getvalues3[9],
                                        Issued = (bool)getvalues3[10],
                                        Bonus = (float?)getvalues3[11],
                                        YearNavigation = years1,
                                        MonthNavigation = months1,
                                        EmployeeNavigation = employees,
                                    });
                                }
                            }

                        }

                    }
                }
            }
            getvalues3.Close();
            connect.Close();
            return salaryEmps;
        }


        public void Check(int Year, int Month)  // Возврщает общую сумму к выдачи по выбранной дате
        {

            connect = new SqlConnection(connectionstring);
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectYearMonth";
            cmd.Parameters.Add(new SqlParameter("@Year", Year));
            cmd.Parameters.Add(new SqlParameter("@Month", Month));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    allcountOfSalary += (float)getvalues[9];
                }
            }
            
        }
        public List<Employees> GetValuesofEmployees()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllEmployees";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Employees> employees = new List<Employees>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {

                    employees.Add(new Employees()
                    {

                        Id = (int)getvalues[0],
                        Fullname = getvalues[1].ToString(),
                        Position = (short?)getvalues[2],
                        Salary = Convert.ToDecimal(getvalues[3]),
                        Address = (getvalues[4]).ToString(),
                        Telephone = (getvalues[4]).ToString(),

                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return employees;
        } // Возвращает список сотрудников
        public List<Years> GetValuesofYears()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllYears";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Years> years = new List<Years>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {

                    years.Add(new Years()
                    {

                        YearName= (int)getvalues[0],

                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return years;
        } //Возвращает список из таблицы Years
        public List<Months> GetValuesofMonths() //Возвращает список из таблицы Months
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllMonths";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Months> months = new List<Months>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {

                    months.Add(new Months()
                    {

                        Id = (byte)getvalues[0],
                        MonthName=(getvalues[1]).ToString(),
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return months;
        } 
        // GET: SalaryEmps
        public async Task<IActionResult> Index(int yearString,int monthString,string Messege) // Начальная функция. При запуске программы, будет запускаться этот метод
        {
            // Вызываем ранее созданные функции. Такой способ облегчает работу, если есть повторяющий код. Вместо написания всего кода, вызываем только нужную функцию
            var Year = GetValuesofYears();
            var Month = GetValuesofMonths();
            var Employee = GetValuesofEmployees(); 
            connect = new SqlConnection(connectionstring);
            Employees employees = new Employees();
            Years years1 = new Years();
            Months months1 = new Months();
            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = connect;
            cmd5.CommandType = System.Data.CommandType.StoredProcedure;
            cmd5.CommandText = "SelectAllSalary";
            connect.Open();
            SqlDataReader getvalues4 = cmd5.ExecuteReader();
            List<SalaryEmp> salaryEmps = new List<SalaryEmp>();

            if (getvalues4.HasRows)
            {
                while (getvalues4.Read())
                {
                    foreach (Employees val in Employee)
                    {
                        foreach (Years val2 in Year)
                        {
                            foreach (Months val3 in Month) {
                                if (val.Id == Convert.ToInt32(getvalues4[3]) && val2.YearName == (int)(getvalues4[1]) && val3.Id== (byte)getvalues4[2])
                                {
                                    employees = val;
                                    years1 = val2;
                                    months1 = val3;
                                    salaryEmps.Add(new SalaryEmp()
                                    {
                                        Id=(int)getvalues4[0],
                                        Year=(int?)getvalues4[1],
                                        Month=Convert.ToInt32(getvalues4[2]),
                                        Employee=(int)getvalues4[3],
                                        ParticipationPurchase=(byte?)getvalues4[4],
                                        ParticipationSale=(byte?)getvalues4[5],
                                        ParticipationProduction=(byte?)getvalues4[6],
                                        CountParticipation=(byte?)getvalues4[7],
                                        SalaryEmployee=(decimal?)getvalues4[8],
                                        TotalAmount=(float?)getvalues4[9],
                                        Issued=(bool)getvalues4[10],
                                        Bonus=(float?)getvalues4[11],
                                        YearNavigation =years1,
                                        MonthNavigation=months1,
                                        EmployeeNavigation=employees,
                                    });
                                }
                            }
                            
                        }

                    }
                }
            }
            getvalues4.Close();
            connect.Close();
            List<string> summa = new List<string>();
            if (yearString != 0 && monthString != 0) // Если были выбраны год и месяц 
            {

               
                ViewData["Year"] = new SelectList(Year, "YearName", "YearName", yearString);
                ViewData["Month"] = new SelectList(Month, "Id", "MonthName", monthString);

                var salaryEmp = GetValuesofYearAndMonth(yearString, monthString); // получаем список записей по выбранной дате
                ViewBag.AddMessege = Messege;

                Check(yearString, Convert.ToInt32(monthString));
                summa.Add(allcountOfSalary.ToString());
                ViewBag.Summa = allcountOfSalary;
                if (salaryEmp.Count == 0) // если таких записей нет, добавляем запись
                {
                    connect = new SqlConnection(connectionstring);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connect;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_Zarplata"; // Вызываем хранимую процедуру
                    cmd.Parameters.Add(new SqlParameter("@Year", yearString)); // Первый входной параметр
                    cmd.Parameters.Add(new SqlParameter("@Month", monthString)); // Второй входной параметр
                    connect.Open();
                    cmd.ExecuteNonQuery();
                    
                    return RedirectToAction("Index", new { yearString = yearString, monthString = monthString });

                }
                else
                {
                    
                    return View(salaryEmp);
                }
                

            }
            else // если год и месяц не были выбраны на страницу выводим все записи
            {
                ViewData["Year"] = new SelectList(Year, "YearName", "YearName");
                ViewData["Month"] = new SelectList(Month, "Id", "MonthName");
                for (int i = 0; i < salaryEmps.Count; i++)
                {
                    allcountOfSalary += (float)salaryEmps[i].TotalAmount; // Посчитываем общую сумму всех сотрудников
                }

                summa.Add(allcountOfSalary.ToString());
                ViewBag.Summa = allcountOfSalary;
            }
            
          
            return View(salaryEmps);
        }

        public async Task<IActionResult> IndexCopyAdd(int yearString, int monthString) // Функция для выдачи ЗП
        {

            var Year = GetValuesofYears();
            var Month = GetValuesofMonths();
            ViewData["Year"] = new SelectList(Year, "YearName", "YearName", yearString);
            ViewData["Month"] = new SelectList(Month, "Id", "MonthName", monthString);
            List<string> summa = new List<string>();
            allcountOfSalary = 0;
            Check(yearString, Convert.ToInt32(monthString));
            summa.Add(allcountOfSalary.ToString());
            ViewBag.Summa = allcountOfSalary;
            var salaryEmp  = GetValuesofSalary();


            if (yearString != 0 && monthString >= 0)
            {
                Check(yearString, Convert.ToInt32(monthString));
                salaryEmp = GetValuesofYearAndMonth(yearString, monthString);

                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_IssuedAndBudget"; // Вызываем хранимую процедуру
                cmd.Parameters.Add(new SqlParameter("@Year", yearString)); // Первый входной параметр
                cmd.Parameters.Add(new SqlParameter("@Month", monthString)); // Второй входной параметр
                SqlParameter p = new SqlParameter // Третий входной параметр
                {
                    ParameterName = "@p",
                    SqlDbType = SqlDbType.Int,
                    Size = 1
                };
                p.Direction = ParameterDirection.Output; // Определяем третий параметр как выходной
                cmd.Parameters.Add(p);
                connect.Open();
                cmd.ExecuteNonQuery();

                var k = Convert.ToInt32((cmd.Parameters["@p"].Value)); // Получаем результат


                if (k == 1) // Если 1, то бюджета не хватает
                {
                    M = "Не хватает денег в бюджете для зачисления зарплаты!";
                    connect.Close();
                    return RedirectToAction("Index", new { yearString = yearString, monthString = monthString, Messege = M });

                }
                else if (k == 2) // Если 2, то по выбранной дате уже выдана ЗП
                {
                    M = "По выбранной дате зарплата уже выдана!";
                    connect.Close();
                    return RedirectToAction("Index", new { yearString = yearString, monthString = monthString, Messege = M });
                }
                else // Иначе выдаем ЗП
                {
                   
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = connect;
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.CommandText = "IssuedUpdate";
                    cmd2.Parameters.Add(new SqlParameter("@Year", yearString));
                    cmd2.Parameters.Add(new SqlParameter("@Month", monthString));
                   
                    cmd2.ExecuteNonQuery();
                    connect.Close();
                    return RedirectToAction("Index", new { yearString = yearString, monthString = monthString});
                }
            }
            
            
            return View(salaryEmp);
        }
    }
}
