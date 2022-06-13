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
    public class SaleofproductsController : Controller
    {
        private SqlConnection connect = null;
        public string connectionstring = "Data Source=KYLYM;Initial Catalog=SUBD;User ID=User;Password=12345";
        public Saleofproducts GetValuesofID(short? Id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectSaleofproducts";
            cmd.Parameters.Add(new SqlParameter("@ID", Id));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Saleofproducts saleofproducts = new Saleofproducts();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    saleofproducts.Id = (short)(getvalues[0]);
                    saleofproducts.Product = (short)(getvalues[1]);
                    saleofproducts.CountSaleofpr = (float?)(getvalues[2]);
                    saleofproducts.Sum = (decimal)(getvalues[3]);
                    saleofproducts.Date = (DateTime)(getvalues[4]);
                    saleofproducts.Employee = (int?)(getvalues[5]);
                }
            }
            getvalues.Close();
            connect.Close();

            return saleofproducts;

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
        // GET: Saleofproducts
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
            cmd.CommandText = "SelectAllSaleofproducts";
            SqlDataReader getvalues = cmd.ExecuteReader();
            List<Saleofproducts> saleofproducts = new List<Saleofproducts>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    foreach (Employees val in employees1)
                    {
                        foreach (Finproducts val2 in finproducts1)
                        {
                            if (val.Id == Convert.ToInt32(getvalues[5]) && val2.Id == (short)(getvalues[1]))
                            {
                                employees = val;
                                finproducts = val2;
                                saleofproducts.Add(new Saleofproducts()
                                {
                                    Id = (short)(getvalues[0]),
                                    Product = (short)getvalues[1],
                                    CountSaleofpr = (float)(getvalues[2]),
                                    Sum = Convert.ToDecimal(getvalues[3]),
                                    Date = (DateTime)getvalues[4],
                                    Employee = (int)getvalues[5],
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
            return View(saleofproducts);
        }

        // GET: Saleofproducts/Create
        public IActionResult Create()
        {
            var Product = GetValuesofFinproducts();
            var Employee = GetValuesofEmployees();
            ViewData["Product"] = new SelectList(Product, "Id", "Name");
            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname");
            return View();
        }

        // POST: Saleofproducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Saleofproducts saleofproducts)
        {
            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_Product";
                cmd.Parameters.Add(new SqlParameter("@count", saleofproducts.CountSaleofpr));
                cmd.Parameters.Add(new SqlParameter("@Product", saleofproducts.Product));
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

                var k =Convert.ToInt32((cmd.Parameters["@p"].Value));


                if (k == 0)
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = connect;
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.CommandText = "InsertSaleofproducts";
                    cmd2.Parameters.Add(new SqlParameter("@Product", saleofproducts.Product));
                    cmd2.Parameters.Add(new SqlParameter("@CountSaleofpr", saleofproducts.CountSaleofpr));
                    cmd2.Parameters.Add(new SqlParameter("@Date", saleofproducts.Date));
                    cmd2.Parameters.Add(new SqlParameter("@Employee", saleofproducts.Employee));
                    cmd2.ExecuteNonQuery();
                    connect.Close();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Не хватает количества готовых продуктов!";
                }
            }
            var Productlist = GetValuesofFinproducts();
            var result = GetValuesofID(saleofproducts.Id);
            var EmployeeList = GetValuesofEmployees();
            ViewData["Employee"] = new SelectList(EmployeeList, "Id", "Fullname", result.Employee);
            ViewData["Product"] = new SelectList(Productlist, "Id", "Name", result.Product);
            return View(saleofproducts);
        }
        

        // GET: Saleofproducts/Edit/5
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

        // POST: Saleofproducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,Product,CountSaleofpr,Date,Employee")] Saleofproducts saleofproducts)
        {
            if (id != saleofproducts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateSaleofproducts";
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@Product", saleofproducts.Product));
                cmd.Parameters.Add(new SqlParameter("@CountSaleofpr", saleofproducts.CountSaleofpr));
               
                cmd.Parameters.Add(new SqlParameter("@Date", saleofproducts.Date));
                cmd.Parameters.Add(new SqlParameter("@Employee", saleofproducts.Employee));
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
            return View(saleofproducts);
        }

        // GET: Saleofproducts/Delete/5
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

        // POST: Saleofproducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DeleteSaleofproducts";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction(nameof(Index));
        }
    }
}
