    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Enterprises_manufacturing_goods;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Enterprises_manufacturing_goods.Controllers
{
    public class ProductionsController : Controller
    {

        private SqlConnection connect = null;
        public string connectionstring = "Data Source=KYLYM;Initial Catalog=SUBD;User ID=User;Password=12345";
        public Production GetValuesofID(short? Id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectProduction";
            cmd.Parameters.Add(new SqlParameter("@ID", Id));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Production production = new Production();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    production.Id = (short)(getvalues[0]);
                    production.Product = (short)(getvalues[1]);
                    production.CountProduction = (float?)(getvalues[2]);
                    production.Date = (DateTime)(getvalues[3]);
                    production.Employee = (int?)(getvalues[4]);
                }
            }
            getvalues.Close();
            connect.Close();

            return production;

        }

        public List<Finproducts> GetValuesofFinproducts()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllFinproducts";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Finproducts> finproducts = new List<Finproducts>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {

                    finproducts.Add(new Finproducts()
                    {
                        Id = (short)getvalues[0],
                        Name = getvalues[1].ToString(),
                        Unit = (short)getvalues[2],
                        Sum = Convert.ToDecimal(getvalues[3]),
                        Countproducts = (float)getvalues[4],
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return finproducts;
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
                        Telephone = (getvalues[5]).ToString(),

                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return employees;
        }
        // GET: Productions
        public async Task<IActionResult> Index()
        {
            connect = new SqlConnection(connectionstring);
            Employees employees = new Employees();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllEmployees";
            connect.Open();
            SqlDataReader getvalues2 = cmd2.ExecuteReader();
            List<Employees> employees1 = new List<Employees>();
            if (getvalues2.HasRows)
            {
                while (getvalues2.Read())
                {
                    employees1.Add(new Employees()
                    {
                        Id = Convert.ToInt32(getvalues2[0]),
                        Fullname = getvalues2[1].ToString(),
                        Position = (short)getvalues2[2],
                        Salary = Convert.ToDecimal(getvalues2[3]),
                        Address = (getvalues2[4]).ToString(),
                        Telephone = (getvalues2[5]).ToString(),
                    });
                }
            }
            getvalues2.Close();




            Finproducts finproducts = new Finproducts();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = connect;
            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
            cmd3.CommandText = "SelectAllFinproducts";

            SqlDataReader getvalues3 = cmd3.ExecuteReader();
            List<Finproducts> finproducts1 = new List<Finproducts>();
            if (getvalues3.HasRows)
            {
                while (getvalues3.Read())
                {
                    finproducts1.Add(new Finproducts()
                    {
                        Id = (short)getvalues3[0],
                        Name = getvalues3[1].ToString(),
                        Unit = (short)getvalues3[2],
                        Sum = Convert.ToDecimal(getvalues3[3]),
                        Countproducts = (float)getvalues3[4],
                    });
                }
            }
            getvalues3.Close();

            // Начинай отсюдова
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectAllProduction";
            SqlDataReader getvalues = cmd.ExecuteReader();
            List<Production> productions = new List<Production>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    foreach (Employees val in employees1)
                    {
                        foreach (Finproducts val2 in finproducts1)
                        {
                            if (val.Id == Convert.ToInt32(getvalues[4]) && val2.Id == (short)(getvalues[1]))
                            {
                                employees = val;
                                finproducts = val2;
                                productions.Add(new Production()
                                {
                                    Id = (short)(getvalues[0]),
                                    Product = (short)getvalues[1],
                                    CountProduction = (float?)getvalues[2],
                                    Date = (DateTime)getvalues[3],
                                    Employee = (int)getvalues[4],
                                    ProductNavigation = finproducts,
                                    EmployeeNavigation = employees,
                                });
                            }
                        }

                    }
                }
            }
            getvalues.Close();
            connect.Close();
            return View(productions);
        }

      
        // GET: Productions/Create
        public IActionResult Create()
        {
            var Product = GetValuesofFinproducts();
            var Employee = GetValuesofEmployees();
            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname");
            ViewData["Product"] = new SelectList(Product, "Id", "Name");
            return View();
        }

        // POST: Productions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Production production)
        {
            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_Productions";
                cmd.Parameters.Add(new SqlParameter("@count", production.CountProduction));
                cmd.Parameters.Add(new SqlParameter("@ID", production.Product));
                SqlParameter p = new SqlParameter
                {
                    ParameterName = "@p",
                    SqlDbType = SqlDbType.Int,
                    Size = 1
                };
                p.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p);
                connect.Open();
                cmd.ExecuteNonQuery();

                var k = Convert.ToInt32((cmd.Parameters["@p"].Value));


                if (k == 0)
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = connect;
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.CommandText = "InsertProduction";
                    cmd2.Parameters.Add(new SqlParameter("@Product", production.Product));
                    cmd2.Parameters.Add(new SqlParameter("@CountProduction", production.CountProduction));
                    cmd2.Parameters.Add(new SqlParameter("@Date", production.Date));
                    cmd2.Parameters.Add(new SqlParameter("@Employee", production.Employee));
                    cmd2.ExecuteNonQuery();
                    connect.Close();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Не хватает количества сырья!";
                }
            }
            var Productlist = GetValuesofFinproducts();
            var result = GetValuesofID(production.Id);
            var EmployeeList = GetValuesofEmployees();
            ViewData["Employee"] = new SelectList(EmployeeList, "Id", "Fullname", result.Employee);
            ViewData["Product"] = new SelectList(Productlist, "Id", "Name", result.Product);
            return View(result);
        }

        // GET: Productions/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Productlist = GetValuesofFinproducts();
            var result = GetValuesofID(id);
            var EmployeeList = GetValuesofEmployees();
            if (result == null)
            {
                return NotFound();
            }
            ViewData["Employee"] = new SelectList(EmployeeList, "Id", "Fullname", result.Employee);
            ViewData["Product"] = new SelectList(Productlist, "Id", "Name", result.Product);
            return View(result);
        }

        // POST: Productions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,Product,CountProduction,Date,Employee")] Production production)
        {
            if (id != production.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateProduction";
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@Product", production.Product));
                cmd.Parameters.Add(new SqlParameter("@CountProduction", production.CountProduction));
                cmd.Parameters.Add(new SqlParameter("@Date", production.Date));
                cmd.Parameters.Add(new SqlParameter("@Employee", production.Employee));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            var Productlist = GetValuesofFinproducts();
            var result = GetValuesofID(id);
            var EmployeeList = GetValuesofEmployees();
            ViewData["Employee"] = new SelectList(EmployeeList, "Id", "Fullname", result.Employee);
            ViewData["Product"] = new SelectList(Productlist, "Id", "Name", result.Product);
            return View(result);
        }

        // GET: Productions/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = GetValuesofID(id);
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectFinproducts";
            cmd.Parameters.Add(new SqlParameter("@ID", result.Product));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Finproducts finproducts = new Finproducts();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    finproducts.Id = (short)getvalues[0];
                    finproducts.Name = getvalues[1].ToString();
                    finproducts.Unit = (short)getvalues[2];
                    finproducts.Sum = Convert.ToDecimal(getvalues[3]);
                    finproducts.Countproducts = (float)getvalues[4];
                }
            }
            getvalues.Close();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectEmployee";
            cmd2.Parameters.Add(new SqlParameter("@ID", result.Employee));

            SqlDataReader getvalues2 = cmd2.ExecuteReader();
            Employees employees = new Employees();
            if (getvalues2.HasRows)
            {
                while (getvalues2.Read())
                {
                    employees.Id = (int)getvalues2[0];
                    employees.Fullname = (getvalues2[1]).ToString();
                    employees.Position = (short)getvalues2[2];
                    employees.Salary = Convert.ToDecimal(getvalues2[3]);
                    employees.Address = (getvalues2[4]).ToString();
                    employees.Telephone = (getvalues2[5]).ToString();
                }
            }
            getvalues2.Close();
            connect.Close();

            if (result == null)
            {
                return NotFound();
            }
            result.ProductNavigation = finproducts;
            result.EmployeeNavigation = employees;
            return View(result);
        }

        // POST: Productions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DeleteProduction";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction(nameof(Index));
        }

    }
}
