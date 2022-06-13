//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Enterprises_manufacturing_goods;
//using Enterprises_manufacturing_goods.Models;
//using Microsoft.Data.SqlClient;
//using System.Data;

//namespace Enterprises_manufacturing_goods.Controllers
//{
//    public class SalaryEmpsController : Controller
//    {
//        private SqlConnection connect = null;
//        float countOfSalary = 0;
//        float allcountOfSalary = 0;
//        public string connectionstring = "Data Source=KYLYM;Initial Catalog=SUBD;User ID=User;Password=12345";

//        public List<SalaryEmp> GetValuesofYearAndMonth(int Year, int Month)
//        {
//            connect = new SqlConnection(connectionstring);
//            Employees employees = new Employees();
//            Years years1 = new Years();
//            Months months1 = new Months();
//            SqlCommand cmd2 = new SqlCommand();
//            cmd2.Connection = connect;
//            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd2.CommandText = "SelectAllEmployees";

//            connect.Open();
//            SqlDataReader getvalues = cmd2.ExecuteReader();
//            List<Employees> employees1 = new List<Employees>();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {
//                    employees1.Add(new Employees()
//                    {
//                        Id = Convert.ToInt32(getvalues[0]),
//                        Fullname = getvalues[1].ToString(),
//                        Position = (short?)getvalues[2],
//                        Salary = Convert.ToDecimal(getvalues[3]),
//                        Address = (getvalues[4]).ToString(),
//                        Telephone = (getvalues[4]).ToString(),
//                    });
//                }
//            }
//            getvalues.Close();


//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd3 = new SqlCommand();
//            cmd3.Connection = connect;
//            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd3.CommandText = "SelectAllMonths";
//            connect.Open();
//            SqlDataReader getvalues2 = cmd3.ExecuteReader();
//            List<Months> months = new List<Months>();
//            if (getvalues2.HasRows)
//            {
//                while (getvalues2.Read())
//                {

//                    months.Add(new Months()
//                    {

//                        Id = (byte)getvalues2[0],
//                        MonthName = (getvalues2[1]).ToString(),
//                    });
//                }
//            }
//            getvalues2.Close();

//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd4 = new SqlCommand();
//            cmd4.Connection = connect;
//            cmd4.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd4.CommandText = "SelectAllYears";
//            connect.Open();
//            SqlDataReader getvalues3 = cmd4.ExecuteReader();
//            List<Years> years = new List<Years>();
//            if (getvalues3.HasRows)
//            {
//                while (getvalues3.Read())
//                {

//                    years.Add(new Years()
//                    {

//                        YearName = (int)getvalues3[0],
//                    });
//                }
//            }
//            getvalues3.Close();

//            connect = new SqlConnection(connectionstring);

//            SqlCommand cmd5 = new SqlCommand();
//            cmd5.Connection = connect;
//            cmd5.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd5.CommandText = "SelectYearMonth";
//            cmd5.Parameters.Add(new SqlParameter("@Year", Year));
//            cmd5.Parameters.Add(new SqlParameter("@Month", Month));
//            connect.Open();
//            SqlDataReader getvalues4 = cmd5.ExecuteReader();
//            List<SalaryEmp> salaryEmps = new List<SalaryEmp>();

//            if (getvalues4.HasRows)
//            {
//                while (getvalues4.Read())
//                {
//                    foreach (Employees val in employees1)
//                    {
//                        foreach (Years val2 in years)
//                        {
//                            foreach (Months val3 in months)
//                            {
//                                if (val.Id == Convert.ToInt32(getvalues4[3]) && val2.YearName == (int)(getvalues4[1]) && val3.Id == (byte)getvalues4[2])
//                                {
//                                    employees = val;
//                                    years1 = val2;
//                                    months1 = val3;
//                                    salaryEmps.Add(new SalaryEmp()
//                                    {
//                                        Id = (int)getvalues4[0],
//                                        Year = (int?)getvalues4[1],
//                                        Month = Convert.ToInt32(getvalues4[2]),
//                                        Employee = (int)getvalues4[3],
//                                        ParticipationPurchase = (byte?)getvalues4[4],
//                                        ParticipationSale = (byte?)getvalues4[5],
//                                        ParticipationProduction = (byte?)getvalues4[6],
//                                        CountParticipation = (byte?)getvalues4[7],
//                                        SalaryEmployee = (decimal?)getvalues4[8],
//                                        TotalAmount = (float?)getvalues4[9],
//                                        Issued = (bool)getvalues4[10],
//                                        Bonus = (float?)getvalues4[11],
//                                        YearNavigation = years1,
//                                        MonthNavigation = months1,
//                                        EmployeeNavigation = employees,
//                                    });
//                                }
//                            }

//                        }

//                    }
//                }
//            }
//            getvalues4.Close();
//            connect.Close();
//            return salaryEmps;
//        }

//        public List<SalaryEmp> GetValuesofSalary()
//        {
//            connect = new SqlConnection(connectionstring);
//            Employees employees = new Employees();
//            Years years1 = new Years();
//            Months months1 = new Months();
//            SqlCommand cmd2 = new SqlCommand();
//            cmd2.Connection = connect;
//            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd2.CommandText = "SelectAllEmployees";

//            connect.Open();
//            SqlDataReader getvalues = cmd2.ExecuteReader();
//            List<Employees> employees1 = new List<Employees>();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {
//                    employees1.Add(new Employees()
//                    {
//                        Id = Convert.ToInt32(getvalues[0]),
//                        Fullname = getvalues[1].ToString(),
//                        Position = (short?)getvalues[2],
//                        Salary = Convert.ToDecimal(getvalues[3]),
//                        Address = (getvalues[4]).ToString(),
//                        Telephone = (getvalues[4]).ToString(),
//                    });
//                }
//            }

//            var years = GetValuesofYears();
//            var months = GetValuesofMonths();
//            List<SalaryEmp> salaryEmps = new List<SalaryEmp>();

//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {
//                    foreach (Employees val in employees1)
//                    {
//                        foreach (Years val2 in years)
//                        {
//                            foreach (Months val3 in months)
//                            {
//                                if (val.Id == Convert.ToInt32(getvalues[3]) && val2.YearName == (int)(getvalues[1]) && val3.Id == (byte)getvalues[2])
//                                {
//                                    employees = val;
//                                    years1 = val2;
//                                    months1 = val3;
//                                    salaryEmps.Add(new SalaryEmp()
//                                    {
//                                        Id = (int)getvalues[0],
//                                        Year = (int?)getvalues[1],
//                                        Month = Convert.ToInt32(getvalues[2]),
//                                        Employee = (int)getvalues[3],
//                                        ParticipationPurchase = (byte?)getvalues[4],
//                                        ParticipationSale = (byte?)getvalues[5],
//                                        ParticipationProduction = (byte?)getvalues[6],
//                                        CountParticipation = (byte?)getvalues[7],
//                                        SalaryEmployee = (decimal?)getvalues[8],
//                                        TotalAmount = (float?)getvalues[9],
//                                        Issued = (bool)getvalues[10],
//                                        Bonus = (float?)getvalues[11],
//                                        YearNavigation = years1,
//                                        MonthNavigation = months1,
//                                        EmployeeNavigation = employees,
//                                    });
//                                }
//                            }

//                        }

//                    }
//                }
//            }
//            getvalues.Close();
//            connect.Close();
//            return salaryEmps;
//        }


//        public void Check(int Year, int Month)
//        {

//            connect = new SqlConnection(connectionstring);

//            SqlCommand cmd = new SqlCommand();
//            cmd.Connection = connect;
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.CommandText = "SelectYearMonth";
//            cmd.Parameters.Add(new SqlParameter("@Year", Year));
//            cmd.Parameters.Add(new SqlParameter("@Month", Month));
//            connect.Open();
//            SqlDataReader getvalues = cmd.ExecuteReader();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {
//                    allcountOfSalary += (float)getvalues[9];
//                }
//            }

//        }



//        public List<Employees> GetValuesofEmployees()
//        {
//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd2 = new SqlCommand();
//            cmd2.Connection = connect;
//            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd2.CommandText = "SelectAllEmployees";
//            connect.Open();
//            SqlDataReader getvalues = cmd2.ExecuteReader();
//            List<Employees> employees = new List<Employees>();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {

//                    employees.Add(new Employees()
//                    {

//                        Id = (int)getvalues[0],
//                        Fullname = getvalues[1].ToString(),
//                        Position = (short?)getvalues[2],
//                        Salary = Convert.ToDecimal(getvalues[3]),
//                        Address = (getvalues[4]).ToString(),
//                        Telephone = (getvalues[4]).ToString(),

//                    });
//                }
//            }
//            getvalues.Close();
//            connect.Close();
//            return employees;
//        }

//        public List<Years> GetValuesofYears()
//        {
//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd2 = new SqlCommand();
//            cmd2.Connection = connect;
//            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd2.CommandText = "SelectAllYears";
//            connect.Open();
//            SqlDataReader getvalues = cmd2.ExecuteReader();
//            List<Years> years = new List<Years>();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {

//                    years.Add(new Years()
//                    {

//                        YearName = (int)getvalues[0],

//                    });
//                }
//            }
//            getvalues.Close();
//            connect.Close();
//            return years;
//        }
//        public List<Months> GetValuesofMonths()
//        {
//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd2 = new SqlCommand();
//            cmd2.Connection = connect;
//            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd2.CommandText = "SelectAllMonths";
//            connect.Open();
//            SqlDataReader getvalues = cmd2.ExecuteReader();
//            List<Months> months = new List<Months>();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {

//                    months.Add(new Months()
//                    {

//                        Id = (byte)getvalues[0],
//                        MonthName = (getvalues[1]).ToString(),
//                    });
//                }
//            }
//            getvalues.Close();
//            connect.Close();
//            return months;
//        }

//        // GET: SalaryEmps
//        public async Task<IActionResult> Index()
//        {

//            // Сумма всех сотрудников

//            connect = new SqlConnection(connectionstring);
//            Employees employees = new Employees();
//            Years years1 = new Years();
//            Months months1 = new Months();
//            SqlCommand cmd2 = new SqlCommand();
//            cmd2.Connection = connect;
//            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd2.CommandText = "SelectAllEmployees";
//            connect.Open();
//            SqlDataReader getvalues = cmd2.ExecuteReader();
//            List<Employees> employees1 = new List<Employees>();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {
//                    employees1.Add(new Employees()
//                    {
//                        Id = Convert.ToInt32(getvalues[0]),
//                        Fullname = getvalues[1].ToString(),
//                        Position = (short)getvalues[2],
//                        Salary = Convert.ToDecimal(getvalues[3]),
//                        Address = (getvalues[4]).ToString(),
//                        Telephone = (getvalues[4]).ToString(),
//                    });
//                }
//            }
//            getvalues.Close();


//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd3 = new SqlCommand();
//            cmd3.Connection = connect;
//            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd3.CommandText = "SelectAllMonths";
//            connect.Open();
//            SqlDataReader getvalues2 = cmd3.ExecuteReader();
//            List<Months> months = new List<Months>();
//            if (getvalues2.HasRows)
//            {
//                while (getvalues2.Read())
//                {

//                    months.Add(new Months()
//                    {

//                        Id = (byte)getvalues2[0],
//                        MonthName = (getvalues2[1]).ToString(),
//                    });
//                }
//            }
//            getvalues2.Close();

//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd4 = new SqlCommand();
//            cmd4.Connection = connect;
//            cmd4.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd4.CommandText = "SelectAllYears";
//            connect.Open();
//            SqlDataReader getvalues3 = cmd4.ExecuteReader();
//            List<Years> years = new List<Years>();
//            if (getvalues3.HasRows)
//            {
//                while (getvalues3.Read())
//                {

//                    years.Add(new Years()
//                    {

//                        YearName = (int)getvalues3[0],
//                    });
//                }
//            }
//            getvalues3.Close();

//            connect = new SqlConnection(connectionstring);

//            SqlCommand cmd5 = new SqlCommand();
//            cmd5.Connection = connect;
//            cmd5.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd5.CommandText = "SelectAllSalary";
//            connect.Open();
//            SqlDataReader getvalues4 = cmd5.ExecuteReader();
//            List<SalaryEmp> salaryEmps = new List<SalaryEmp>();

//            if (getvalues4.HasRows)
//            {
//                while (getvalues4.Read())
//                {
//                    foreach (Employees val in employees1)
//                    {
//                        foreach (Years val2 in years)
//                        {
//                            foreach (Months val3 in months)
//                            {
//                                if (val.Id == Convert.ToInt32(getvalues4[3]) && val2.YearName == (int)(getvalues4[1]) && val3.Id == (byte)getvalues4[2])
//                                {
//                                    employees = val;
//                                    years1 = val2;
//                                    months1 = val3;
//                                    salaryEmps.Add(new SalaryEmp()
//                                    {
//                                        Id = (int)getvalues4[0],
//                                        Year = (int?)getvalues4[1],
//                                        Month = Convert.ToInt32(getvalues4[2]),
//                                        Employee = (int)getvalues4[3],
//                                        ParticipationPurchase = (byte?)getvalues4[4],
//                                        ParticipationSale = (byte?)getvalues4[5],
//                                        ParticipationProduction = (byte?)getvalues4[6],
//                                        CountParticipation = (byte?)getvalues4[7],
//                                        SalaryEmployee = (decimal?)getvalues4[8],
//                                        TotalAmount = (float?)getvalues4[9],
//                                        Issued = (bool)getvalues4[10],
//                                        Bonus = (float?)getvalues4[11],
//                                        YearNavigation = years1,
//                                        MonthNavigation = months1,
//                                        EmployeeNavigation = employees,
//                                    });
//                                }
//                            }

//                        }

//                    }
//                }
//            }
//            getvalues4.Close();
//            connect.Close();
//            List<string> summa = new List<string>();

//            for (int i = 0; i < salaryEmps.Count; i++)
//            {
//                allcountOfSalary += (float)salaryEmps[i].TotalAmount;
//            }

//            summa.Add(allcountOfSalary.ToString());
//            ViewBag.Summa = summa;
//            var Year = GetValuesofYears();
//            var Month = GetValuesofMonths();
//            var Employee = GetValuesofEmployees();
//            ViewData["Year"] = new SelectList(Year, "YearName", "YearName");
//            ViewData["Month"] = new SelectList(Month, "Id", "MonthName");
//            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname");
//            return View(salaryEmps);
//        }

//        public async Task<IActionResult> IndexCopy(int yearString, int monthString)
//        {
//            var Year = GetValuesofYears();
//            var Month = GetValuesofMonths();

//            ViewData["Year"] = new SelectList(Year, "YearName", "YearName", yearString);
//            ViewData["Month"] = new SelectList(Month, "Id", "MonthName", monthString);

//            List<Budgets> budgets = new List<Budgets>();

//            List<string> summa = new List<string>();
//            Check(yearString, Convert.ToInt32(monthString));
//            summa.Add(allcountOfSalary.ToString());
//            ViewBag.Summa = summa;
//            // Сумма всех сотрудников
//            connect = new SqlConnection(connectionstring);



//            connect = new SqlConnection(connectionstring);
//            Employees employees = new Employees();
//            Years years1 = new Years();
//            Months months1 = new Months();
//            SqlCommand cmd2 = new SqlCommand();
//            cmd2.Connection = connect;
//            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd2.CommandText = "SelectAllEmployees";
//            connect.Open();
//            SqlDataReader getvalues1 = cmd2.ExecuteReader();
//            List<Employees> employees1 = new List<Employees>();
//            if (getvalues1.HasRows)
//            {
//                while (getvalues1.Read())
//                {
//                    employees1.Add(new Employees()
//                    {
//                        Id = Convert.ToInt32(getvalues1[0]),
//                        Fullname = getvalues1[1].ToString(),
//                        Position = (short)getvalues1[2],
//                        Salary = Convert.ToDecimal(getvalues1[3]),
//                        Address = (getvalues1[4]).ToString(),
//                        Telephone = (getvalues1[4]).ToString(),
//                    });
//                }
//            }
//            getvalues1.Close();


//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd3 = new SqlCommand();
//            cmd3.Connection = connect;
//            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd3.CommandText = "SelectAllMonths";
//            connect.Open();
//            SqlDataReader getvalues2 = cmd3.ExecuteReader();
//            List<Months> months = new List<Months>();
//            if (getvalues2.HasRows)
//            {
//                while (getvalues2.Read())
//                {

//                    months.Add(new Months()
//                    {

//                        Id = (byte)getvalues2[0],
//                        MonthName = (getvalues2[1]).ToString(),
//                    });
//                }
//            }
//            getvalues2.Close();

//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd4 = new SqlCommand();
//            cmd4.Connection = connect;
//            cmd4.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd4.CommandText = "SelectAllYears";
//            connect.Open();
//            SqlDataReader getvalues3 = cmd4.ExecuteReader();
//            List<Years> years = new List<Years>();
//            if (getvalues3.HasRows)
//            {
//                while (getvalues3.Read())
//                {

//                    years.Add(new Years()
//                    {

//                        YearName = (int)getvalues3[0],
//                    });
//                }
//            }
//            getvalues3.Close();

//            connect = new SqlConnection(connectionstring);

//            SqlCommand cmd5 = new SqlCommand();
//            cmd5.Connection = connect;
//            cmd5.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd5.CommandText = "SelectAllSalary";
//            connect.Open();
//            SqlDataReader getvalues4 = cmd5.ExecuteReader();
//            List<SalaryEmp> salaryEmps = new List<SalaryEmp>();

//            if (getvalues4.HasRows)
//            {
//                while (getvalues4.Read())
//                {
//                    foreach (Employees val in employees1)
//                    {
//                        foreach (Years val2 in years)
//                        {
//                            foreach (Months val3 in months)
//                            {
//                                if (val.Id == Convert.ToInt32(getvalues4[3]) && val2.YearName == (int)(getvalues4[1]) && val3.Id == (byte)getvalues4[2])
//                                {
//                                    employees = val;
//                                    years1 = val2;
//                                    months1 = val3;
//                                    salaryEmps.Add(new SalaryEmp()
//                                    {
//                                        Id = (int)getvalues4[0],
//                                        Year = (int?)getvalues4[1],
//                                        Month = Convert.ToInt32(getvalues4[2]),
//                                        Employee = (int)getvalues4[3],
//                                        ParticipationPurchase = (byte?)getvalues4[4],
//                                        ParticipationSale = (byte?)getvalues4[5],
//                                        ParticipationProduction = (byte?)getvalues4[6],
//                                        CountParticipation = (byte?)getvalues4[7],
//                                        SalaryEmployee = (decimal?)getvalues4[8],
//                                        TotalAmount = (float?)getvalues4[9],
//                                        Issued = (bool)getvalues4[10],
//                                        Bonus = (float?)getvalues4[11],
//                                        YearNavigation = years1,
//                                        MonthNavigation = months1,
//                                        EmployeeNavigation = employees,
//                                    });
//                                }
//                            }

//                        }

//                    }
//                }
//            }
//            getvalues4.Close();
//            connect.Close();

//            if (yearString != 0 && monthString >= 0)
//            {

//                var salaryEmp = GetValuesofYearAndMonth(yearString, monthString);

//                if (salaryEmp.Count == 0)
//                {
//                    return RedirectToAction("Create", new { yearString = yearString, monthString = monthString });
//                }
//                else
//                {

//                    return View(salaryEmp);
//                }


//            }
//            ViewData["Year"] = new SelectList(Year, "YearName", "YearName", yearString);
//            ViewData["Month"] = new SelectList(Month, "Id", "MonthName", monthString);
//            return View(salaryEmps);
//        }

//        public async Task<IActionResult> IndexCopyAdd(int yearString, int monthString)
//        {
//            var Year = GetValuesofYears();
//            var Month = GetValuesofMonths();
//            var Employee = GetValuesofEmployees();
//            ViewData["Year"] = new SelectList(Year, "YearName", "YearName", yearString);
//            ViewData["Month"] = new SelectList(Month, "Id", "MonthName", monthString);
//            List<string> summa = new List<string>();
//            allcountOfSalary = 0;
//            Check(yearString, Convert.ToInt32(monthString));
//            summa.Add(allcountOfSalary.ToString());
//            ViewBag.Summa = summa;
//            var salaryEmp = GetValuesofSalary();


//            if (yearString != 0 && monthString >= 0)
//            {
//                Check(yearString, Convert.ToInt32(monthString));
//                salaryEmp = GetValuesofYearAndMonth(yearString, monthString);

//                connect = new SqlConnection(connectionstring);
//                SqlCommand cmd = new SqlCommand();
//                cmd.Connection = connect;
//                cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                cmd.CommandText = "IssuedUpdate";
//                cmd.Parameters.Add(new SqlParameter("@Year", yearString));
//                cmd.Parameters.Add(new SqlParameter("@Month", monthString));
//                SqlParameter p = new SqlParameter
//                {
//                    ParameterName = "@p",
//                    SqlDbType = SqlDbType.Int,
//                    Size = 1
//                };
//                p.Direction = ParameterDirection.Output;
//                cmd.Parameters.Add(p);
//                connect.Open();
//                cmd.ExecuteNonQuery();

//                var k = Convert.ToInt32((cmd.Parameters["@p"].Value));


//                if (k == 1)
//                {
//                    ViewBag.Message = "Ошибка!Не хваатет денег в бюджете для зачисления зарплаты!";
//                    return View(salaryEmp);

//                }
//                else
//                {
//                    return RedirectToAction(nameof(Index));
//                }
//            }

//            ViewData["Year"] = new SelectList(Year, "YearName", "YearName", yearString);
//            ViewData["Month"] = new SelectList(Month, "Id", "MonthName", monthString);
//            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname");
//            return View(salaryEmp);
//        }



//        // GET: SalaryEmps/Create
//        public IActionResult Create(int yearString, int monthString)
//        {
//            var Year = GetValuesofYears();
//            var Month = GetValuesofMonths();
//            var Employee = GetValuesofEmployees();
//            ViewData["Year"] = new SelectList(Year, "YearName", "YearName", yearString);
//            ViewData["Month"] = new SelectList(Month, "Id", "MonthName", monthString);
//            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname");
//            return View();
//        }

//        // POST: SalaryEmps/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Year,Month,Employee,Issued")] SalaryEmp salaryEmp)
//        {
//            if (ModelState.IsValid)
//            {
//                connect = new SqlConnection(connectionstring);
//                SqlCommand cmd = new SqlCommand();
//                cmd.Connection = connect;
//                cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                cmd.CommandText = "SP_Zarplata";
//                cmd.Parameters.Add(new SqlParameter("@Year", salaryEmp.Year));
//                cmd.Parameters.Add(new SqlParameter("@Month", salaryEmp.Month));
//                connect.Open();
//                cmd.ExecuteNonQuery();
//                return RedirectToAction(nameof(Index));

//            }
//            var Year = GetValuesofYears();
//            var Month = GetValuesofMonths();
//            var Employee = GetValuesofEmployees();
//            ViewData["Year"] = new SelectList(Year, "YearName", "YearName", salaryEmp.Year);
//            ViewData["Month"] = new SelectList(Month, "Id", "MonthName", salaryEmp.Month);
//            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname", salaryEmp.Employee);
//            ;
//            return View(salaryEmp);
//        }




//        // GET: SalaryEmps/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }


//            return View(/*salaryEmp*/);
//        }

//        // POST: SalaryEmps/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int? id, [Bind("Id,Year,Month,Employee,TotalAmount,Issued")] SalaryEmp salaryEmp)
//        {

//            if (id != salaryEmp.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {

//                return View(salaryEmp);
//            }
//            return View(salaryEmp);
//        }

//        // GET: SalaryEmps/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }


//            return View(/*salaryEmp*/);
//        }

//        // POST: SalaryEmps/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int? id)
//        {
//            //var salaryEmp = await _context.Salary.FindAsync(id);
//            //_context.Salary.Remove(salaryEmp);
//            //await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }


//    }
//}






//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Enterprises_manufacturing_goods;
//using Enterprises_manufacturing_goods.Models;
//using Microsoft.Data.SqlClient;
//using System.Data;

//namespace Enterprises_manufacturing_goods.Controllers
//{
//    public class SalaryEmpsController : Controller
//    {
//        private SqlConnection connect = null;
//        float countOfSalary = 0;
//        string M = "";
//        float allcountOfSalary = 0;
//        public string connectionstring = "Data Source=KYLYM;Initial Catalog=SUBD;User ID=User;Password=12345";

//        public List<SalaryEmp> GetValuesofYearAndMonth(int Year, int Month)
//        {
//            connect = new SqlConnection(connectionstring);
//            Employees employees = new Employees();
//            Years years1 = new Years();
//            Months months1 = new Months();
//            SqlCommand cmd2 = new SqlCommand();
//            cmd2.Connection = connect;
//            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd2.CommandText = "SelectAllEmployees";

//            connect.Open();
//            SqlDataReader getvalues = cmd2.ExecuteReader();
//            List<Employees> employees1 = new List<Employees>();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {
//                    employees1.Add(new Employees()
//                    {
//                        Id = Convert.ToInt32(getvalues[0]),
//                        Fullname = getvalues[1].ToString(),
//                        Position = (short?)getvalues[2],
//                        Salary = Convert.ToDecimal(getvalues[3]),
//                        Address = (getvalues[4]).ToString(),
//                        Telephone = (getvalues[4]).ToString(),
//                    });
//                }
//            }
//            getvalues.Close();


//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd3 = new SqlCommand();
//            cmd3.Connection = connect;
//            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd3.CommandText = "SelectAllMonths";
//            connect.Open();
//            SqlDataReader getvalues2 = cmd3.ExecuteReader();
//            List<Months> months = new List<Months>();
//            if (getvalues2.HasRows)
//            {
//                while (getvalues2.Read())
//                {

//                    months.Add(new Months()
//                    {

//                        Id = (byte)getvalues2[0],
//                        MonthName = (getvalues2[1]).ToString(),
//                    });
//                }
//            }
//            getvalues2.Close();

//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd4 = new SqlCommand();
//            cmd4.Connection = connect;
//            cmd4.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd4.CommandText = "SelectAllYears";
//            connect.Open();
//            SqlDataReader getvalues3 = cmd4.ExecuteReader();
//            List<Years> years = new List<Years>();
//            if (getvalues3.HasRows)
//            {
//                while (getvalues3.Read())
//                {

//                    years.Add(new Years()
//                    {

//                        YearName = (int)getvalues3[0],
//                    });
//                }
//            }
//            getvalues3.Close();

//            connect = new SqlConnection(connectionstring);

//            SqlCommand cmd5 = new SqlCommand();
//            cmd5.Connection = connect;
//            cmd5.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd5.CommandText = "SelectYearMonth";
//            cmd5.Parameters.Add(new SqlParameter("@Year", Year));
//            cmd5.Parameters.Add(new SqlParameter("@Month", Month));
//            connect.Open();
//            SqlDataReader getvalues4 = cmd5.ExecuteReader();
//            List<SalaryEmp> salaryEmps = new List<SalaryEmp>();

//            if (getvalues4.HasRows)
//            {
//                while (getvalues4.Read())
//                {
//                    foreach (Employees val in employees1)
//                    {
//                        foreach (Years val2 in years)
//                        {
//                            foreach (Months val3 in months)
//                            {
//                                if (val.Id == Convert.ToInt32(getvalues4[3]) && val2.YearName == (int)(getvalues4[1]) && val3.Id == (byte)getvalues4[2])
//                                {
//                                    employees = val;
//                                    years1 = val2;
//                                    months1 = val3;
//                                    salaryEmps.Add(new SalaryEmp()
//                                    {
//                                        Id = (int)getvalues4[0],
//                                        Year = (int?)getvalues4[1],
//                                        Month = Convert.ToInt32(getvalues4[2]),
//                                        Employee = (int)getvalues4[3],
//                                        ParticipationPurchase = (byte?)getvalues4[4],
//                                        ParticipationSale = (byte?)getvalues4[5],
//                                        ParticipationProduction = (byte?)getvalues4[6],
//                                        CountParticipation = (byte?)getvalues4[7],
//                                        SalaryEmployee = (decimal?)getvalues4[8],
//                                        TotalAmount = (float?)getvalues4[9],
//                                        Issued = (bool)getvalues4[10],
//                                        Bonus = (float?)getvalues4[11],
//                                        YearNavigation = years1,
//                                        MonthNavigation = months1,
//                                        EmployeeNavigation = employees,
//                                    });
//                                }
//                            }

//                        }

//                    }
//                }
//            }
//            getvalues4.Close();
//            connect.Close();
//            return salaryEmps;
//        }

//        public List<SalaryEmp> GetValuesofSalary()
//        {
//            connect = new SqlConnection(connectionstring);
//            Employees employees = new Employees();
//            Years years1 = new Years();
//            Months months1 = new Months();
//            SqlCommand cmd2 = new SqlCommand();
//            cmd2.Connection = connect;
//            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd2.CommandText = "SelectAllEmployees";

//            connect.Open();
//            SqlDataReader getvalues = cmd2.ExecuteReader();
//            List<Employees> employees1 = new List<Employees>();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {
//                    employees1.Add(new Employees()
//                    {
//                        Id = Convert.ToInt32(getvalues[0]),
//                        Fullname = getvalues[1].ToString(),
//                        Position = (short?)getvalues[2],
//                        Salary = Convert.ToDecimal(getvalues[3]),
//                        Address = (getvalues[4]).ToString(),
//                        Telephone = (getvalues[4]).ToString(),
//                    });
//                }
//            }

//            var years = GetValuesofYears();
//            var months = GetValuesofMonths();
//            List<SalaryEmp> salaryEmps = new List<SalaryEmp>();

//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {
//                    foreach (Employees val in employees1)
//                    {
//                        foreach (Years val2 in years)
//                        {
//                            foreach (Months val3 in months)
//                            {
//                                if (val.Id == Convert.ToInt32(getvalues[3]) && val2.YearName == (int)(getvalues[1]) && val3.Id == (byte)getvalues[2])
//                                {
//                                    employees = val;
//                                    years1 = val2;
//                                    months1 = val3;
//                                    salaryEmps.Add(new SalaryEmp()
//                                    {
//                                        Id = (int)getvalues[0],
//                                        Year = (int?)getvalues[1],
//                                        Month = Convert.ToInt32(getvalues[2]),
//                                        Employee = (int)getvalues[3],
//                                        ParticipationPurchase = (byte?)getvalues[4],
//                                        ParticipationSale = (byte?)getvalues[5],
//                                        ParticipationProduction = (byte?)getvalues[6],
//                                        CountParticipation = (byte?)getvalues[7],
//                                        SalaryEmployee = (decimal?)getvalues[8],
//                                        TotalAmount = (float?)getvalues[9],
//                                        Issued = (bool)getvalues[10],
//                                        Bonus = (float?)getvalues[11],
//                                        YearNavigation = years1,
//                                        MonthNavigation = months1,
//                                        EmployeeNavigation = employees,
//                                    });
//                                }
//                            }

//                        }

//                    }
//                }
//            }
//            getvalues.Close();
//            connect.Close();
//            return salaryEmps;
//        }


//        public void Check(int Year, int Month)
//        {

//            connect = new SqlConnection(connectionstring);

//            SqlCommand cmd = new SqlCommand();
//            cmd.Connection = connect;
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.CommandText = "SelectYearMonth";
//            cmd.Parameters.Add(new SqlParameter("@Year", Year));
//            cmd.Parameters.Add(new SqlParameter("@Month", Month));
//            connect.Open();
//            SqlDataReader getvalues = cmd.ExecuteReader();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {
//                    allcountOfSalary += (float)getvalues[9];
//                }
//            }

//        }
//        public List<Employees> GetValuesofEmployees()
//        {
//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd2 = new SqlCommand();
//            cmd2.Connection = connect;
//            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd2.CommandText = "SelectAllEmployees";
//            connect.Open();
//            SqlDataReader getvalues = cmd2.ExecuteReader();
//            List<Employees> employees = new List<Employees>();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {

//                    employees.Add(new Employees()
//                    {

//                        Id = (int)getvalues[0],
//                        Fullname = getvalues[1].ToString(),
//                        Position = (short?)getvalues[2],
//                        Salary = Convert.ToDecimal(getvalues[3]),
//                        Address = (getvalues[4]).ToString(),
//                        Telephone = (getvalues[4]).ToString(),

//                    });
//                }
//            }
//            getvalues.Close();
//            connect.Close();
//            return employees;
//        }
//        public List<Years> GetValuesofYears()
//        {
//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd2 = new SqlCommand();
//            cmd2.Connection = connect;
//            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd2.CommandText = "SelectAllYears";
//            connect.Open();
//            SqlDataReader getvalues = cmd2.ExecuteReader();
//            List<Years> years = new List<Years>();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {

//                    years.Add(new Years()
//                    {

//                        YearName = (int)getvalues[0],

//                    });
//                }
//            }
//            getvalues.Close();
//            connect.Close();
//            return years;
//        }
//        public List<Months> GetValuesofMonths()
//        {
//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd2 = new SqlCommand();
//            cmd2.Connection = connect;
//            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd2.CommandText = "SelectAllMonths";
//            connect.Open();
//            SqlDataReader getvalues = cmd2.ExecuteReader();
//            List<Months> months = new List<Months>();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {

//                    months.Add(new Months()
//                    {

//                        Id = (byte)getvalues[0],
//                        MonthName = (getvalues[1]).ToString(),
//                    });
//                }
//            }
//            getvalues.Close();
//            connect.Close();
//            return months;
//        }
//        // GET: SalaryEmps
//        public async Task<IActionResult> Index(int yearString, int monthString, string Messege)
//        {

//            var Year = GetValuesofYears();
//            var Month = GetValuesofMonths();
//            var Employee = GetValuesofEmployees();


//            connect = new SqlConnection(connectionstring);
//            Employees employees = new Employees();
//            Years years1 = new Years();
//            Months months1 = new Months();
//            SqlCommand cmd2 = new SqlCommand();
//            cmd2.Connection = connect;
//            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd2.CommandText = "SelectAllEmployees";
//            connect.Open();
//            SqlDataReader getvalues = cmd2.ExecuteReader();
//            List<Employees> employees1 = new List<Employees>();
//            if (getvalues.HasRows)
//            {
//                while (getvalues.Read())
//                {
//                    employees1.Add(new Employees()
//                    {
//                        Id = Convert.ToInt32(getvalues[0]),
//                        Fullname = getvalues[1].ToString(),
//                        Position = (short)getvalues[2],
//                        Salary = Convert.ToDecimal(getvalues[3]),
//                        Address = (getvalues[4]).ToString(),
//                        Telephone = (getvalues[4]).ToString(),
//                    });
//                }
//            }
//            getvalues.Close();


//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd3 = new SqlCommand();
//            cmd3.Connection = connect;
//            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd3.CommandText = "SelectAllMonths";
//            connect.Open();
//            SqlDataReader getvalues2 = cmd3.ExecuteReader();
//            List<Months> months = new List<Months>();
//            if (getvalues2.HasRows)
//            {
//                while (getvalues2.Read())
//                {

//                    months.Add(new Months()
//                    {

//                        Id = (byte)getvalues2[0],
//                        MonthName = (getvalues2[1]).ToString(),
//                    });
//                }
//            }
//            getvalues2.Close();

//            connect = new SqlConnection(connectionstring);
//            SqlCommand cmd4 = new SqlCommand();
//            cmd4.Connection = connect;
//            cmd4.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd4.CommandText = "SelectAllYears";
//            connect.Open();
//            SqlDataReader getvalues3 = cmd4.ExecuteReader();
//            List<Years> years = new List<Years>();
//            if (getvalues3.HasRows)
//            {
//                while (getvalues3.Read())
//                {

//                    years.Add(new Years()
//                    {

//                        YearName = (int)getvalues3[0],
//                    });
//                }
//            }
//            getvalues3.Close();

//            connect = new SqlConnection(connectionstring);

//            SqlCommand cmd5 = new SqlCommand();
//            cmd5.Connection = connect;
//            cmd5.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd5.CommandText = "SelectAllSalary";
//            connect.Open();
//            SqlDataReader getvalues4 = cmd5.ExecuteReader();
//            List<SalaryEmp> salaryEmps = new List<SalaryEmp>();

//            if (getvalues4.HasRows)
//            {
//                while (getvalues4.Read())
//                {
//                    foreach (Employees val in employees1)
//                    {
//                        foreach (Years val2 in years)
//                        {
//                            foreach (Months val3 in months)
//                            {
//                                if (val.Id == Convert.ToInt32(getvalues4[3]) && val2.YearName == (int)(getvalues4[1]) && val3.Id == (byte)getvalues4[2])
//                                {
//                                    employees = val;
//                                    years1 = val2;
//                                    months1 = val3;
//                                    salaryEmps.Add(new SalaryEmp()
//                                    {
//                                        Id = (int)getvalues4[0],
//                                        Year = (int?)getvalues4[1],
//                                        Month = Convert.ToInt32(getvalues4[2]),
//                                        Employee = (int)getvalues4[3],
//                                        ParticipationPurchase = (byte?)getvalues4[4],
//                                        ParticipationSale = (byte?)getvalues4[5],
//                                        ParticipationProduction = (byte?)getvalues4[6],
//                                        CountParticipation = (byte?)getvalues4[7],
//                                        SalaryEmployee = (decimal?)getvalues4[8],
//                                        TotalAmount = (float?)getvalues4[9],
//                                        Issued = (bool)getvalues4[10],
//                                        Bonus = (float?)getvalues4[11],
//                                        YearNavigation = years1,
//                                        MonthNavigation = months1,
//                                        EmployeeNavigation = employees,
//                                    });
//                                }
//                            }

//                        }

//                    }
//                }
//            }
//            getvalues4.Close();
//            connect.Close();
//            List<string> summa = new List<string>();
//            if (yearString != 0 && monthString != 0)
//            {

//                ViewBag.Message = Messege;
//                ViewData["Year"] = new SelectList(Year, "YearName", "YearName", yearString);
//                ViewData["Month"] = new SelectList(Month, "Id", "MonthName", monthString);
//                var salaryEmp = GetValuesofYearAndMonth(yearString, monthString);
//                for (int i = 0; i < salaryEmp.Count; i++)
//                {
//                    allcountOfSalary += (float)salaryEmp[i].TotalAmount;
//                }

//                summa.Add(allcountOfSalary.ToString());
//                ViewBag.Summa = allcountOfSalary;
//                if (salaryEmp.Count == 0)
//                {
//                    connect = new SqlConnection(connectionstring);
//                    SqlCommand cmd = new SqlCommand();
//                    cmd.Connection = connect;
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.CommandText = "SP_Zarplata";
//                    cmd.Parameters.Add(new SqlParameter("@Year", yearString));
//                    cmd.Parameters.Add(new SqlParameter("@Month", monthString));
//                    connect.Open();
//                    cmd.ExecuteNonQuery();

//                    return RedirectToAction("Index", new { yearString = yearString, monthString = monthString });

//                }
//                else
//                {

//                    return View(salaryEmp);
//                }


//            }
//            else
//            {
//                ViewData["Year"] = new SelectList(Year, "YearName", "YearName");
//                ViewData["Month"] = new SelectList(Month, "Id", "MonthName");
//                for (int i = 0; i < salaryEmps.Count; i++)
//                {
//                    allcountOfSalary += (float)salaryEmps[i].TotalAmount;
//                }

//                summa.Add(allcountOfSalary.ToString());
//                ViewBag.Summa = allcountOfSalary;
//            }


//            return View(salaryEmps);
//        }

//        public async Task<IActionResult> IndexCopyAdd(int yearString, int monthString)
//        {

//            var Year = GetValuesofYears();
//            var Month = GetValuesofMonths();
//            ViewData["Year"] = new SelectList(Year, "YearName", "YearName", yearString);
//            ViewData["Month"] = new SelectList(Month, "Id", "MonthName", monthString);
//            List<string> summa = new List<string>();
//            allcountOfSalary = 0;
//            Check(yearString, Convert.ToInt32(monthString));
//            summa.Add(allcountOfSalary.ToString());
//            ViewBag.Summa = allcountOfSalary;
//            var salaryEmp = GetValuesofSalary();


//            if (yearString != 0 && monthString >= 0)
//            {
//                Check(yearString, Convert.ToInt32(monthString));
//                salaryEmp = GetValuesofYearAndMonth(yearString, monthString);

//                connect = new SqlConnection(connectionstring);
//                SqlCommand cmd = new SqlCommand();
//                cmd.Connection = connect;
//                cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                cmd.CommandText = "SP_IssuedAndBudget";
//                cmd.Parameters.Add(new SqlParameter("@Year", yearString));
//                cmd.Parameters.Add(new SqlParameter("@Month", monthString));
//                SqlParameter p = new SqlParameter
//                {
//                    ParameterName = "@p",
//                    SqlDbType = SqlDbType.Int,
//                    Size = 1
//                };
//                p.Direction = ParameterDirection.Output;
//                cmd.Parameters.Add(p);
//                connect.Open();
//                cmd.ExecuteNonQuery();

//                var k = Convert.ToInt32((cmd.Parameters["@p"].Value));


//                if (k == 1)
//                {
//                    M = "Не хваатет денег в бюджете для зачисления зарплаты!";
//                    return RedirectToAction("Index", new { yearString = yearString, monthString = monthString, Messege = M });

//                }
//                else if (k == 2)
//                {
//                    M = "По выбранной дате зарплата уже выдана!";
//                    return RedirectToAction("Index", new { yearString = yearString, monthString = monthString, Messege = M });
//                }
//                else
//                {
//                    connect = new SqlConnection(connectionstring);
//                    SqlCommand cmd2 = new SqlCommand();
//                    cmd2.Connection = connect;
//                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd2.CommandText = "IssuedUpdate";
//                    cmd2.Parameters.Add(new SqlParameter("@Year", yearString));
//                    cmd2.Parameters.Add(new SqlParameter("@Month", monthString));
//                    connect.Open();
//                    cmd2.ExecuteNonQuery();
//                    return RedirectToAction("Index", new { yearString = yearString, monthString = monthString });
//                }
//            }


//            return View(salaryEmp);
//        }



//        // GET: SalaryEmps/Create
//        public IActionResult Create(int yearString, int monthString)
//        {
//            var Year = GetValuesofYears();
//            var Month = GetValuesofMonths();
//            var Employee = GetValuesofEmployees();
//            ViewData["Year"] = new SelectList(Year, "YearName", "YearName", yearString);
//            ViewData["Month"] = new SelectList(Month, "Id", "MonthName", monthString);
//            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname");
//            return View();
//        }

//        // POST: SalaryEmps/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Year,Month,Employee,Issued")] SalaryEmp salaryEmp)
//        {
//            if (ModelState.IsValid)
//            {
//                connect = new SqlConnection(connectionstring);
//                SqlCommand cmd = new SqlCommand();
//                cmd.Connection = connect;
//                cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                cmd.CommandText = "SP_Zarplata";
//                cmd.Parameters.Add(new SqlParameter("@Year", salaryEmp.Year));
//                cmd.Parameters.Add(new SqlParameter("@Month", salaryEmp.Month));
//                connect.Open();
//                cmd.ExecuteNonQuery();
//                return RedirectToAction("Index", new { yearString = salaryEmp.Year, monthString = salaryEmp.Month });


//            }
//            var Year = GetValuesofYears();
//            var Month = GetValuesofMonths();
//            var Employee = GetValuesofEmployees();
//            ViewData["Year"] = new SelectList(Year, "YearName", "YearName", salaryEmp.Year);
//            ViewData["Month"] = new SelectList(Month, "Id", "MonthName", salaryEmp.Month);
//            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname", salaryEmp.Employee);
//            ;
//            return View(salaryEmp);
//        }

//    }
//}
