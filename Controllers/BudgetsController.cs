using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Enterprises_manufacturing_goods;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Enterprises_manufacturing_goods.Controllers
{

    public class BudgetsController : Controller
    {
        private SqlConnection connect = null;
        public string connectionstring = "Data Source=KYLYM;Initial Catalog=SUBD;User ID=User;Password=12345";
        public Budgets GetValuesofID(int? Id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectBudget";
            cmd.Parameters.Add(new SqlParameter("@ID", Id));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Budgets budgets1 = new Budgets();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {

                    budgets1.Id = Convert.ToInt32(getvalues[0]);
                    budgets1.Budgetamount = Convert.ToDecimal(getvalues[1]);
                    budgets1.SalePercentage = (float?)(getvalues[2]);
                    budgets1.Bonus = (float?)(getvalues[3]);

                }
            }
            getvalues.Close();
            connect.Close();
            return budgets1;

        }
        
       
        // GET: Budgets
        public async Task<IActionResult> Index()
        {
            SUBDContext sUBDContext = new SUBDContext();
            //var b = sUBDContext.Budgets.FromSqlInterpolated($"vrrbtrtbrt @vddvrb={vffb}").ToList();
            //var n = sUBDContext.Database.ExecuteSqlInterpolated($"vrbr @={}");
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectAllBudgets";
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            List<Budgets> budgets = new List<Budgets>();
            
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    budgets.Add(new Budgets()
                    {
                        Id = Convert.ToInt32(getvalues[0]),
                        Budgetamount = Convert.ToDecimal(getvalues[1]),
                        SalePercentage = (float?)(getvalues[2]),
                        Bonus = (float?)(getvalues[3]),
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return View(budgets);
        }



        // GET: Budgets/Details/5


        // GET: Budgets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Budgets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Budgetamount,SalePercentage,Bonus")] Budgets budgets)
        {
            
            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertBudgets";
                cmd.Parameters.Add(new SqlParameter("@Summa", budgets.Budgetamount));
                cmd.Parameters.Add(new SqlParameter("@SalePerc", budgets.SalePercentage));
                cmd.Parameters.Add(new SqlParameter("@Bon", budgets.Bonus));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var result=GetValuesofID(budgets.Id);
                return View(result);
            }
        }

        // GET: Budgets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            var result= GetValuesofID(id);
            return View(result);
        }

        // POST: Budgets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Budgets budgets)
        {
           
            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateBudgets";
                cmd.Parameters.Add(new SqlParameter("@ID",id));
                cmd.Parameters.Add(new SqlParameter("@Summa", budgets.Budgetamount));
                cmd.Parameters.Add(new SqlParameter("@SalePers", budgets.SalePercentage));
                cmd.Parameters.Add(new SqlParameter("@Bon", budgets.Bonus));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            else
            {
               var result= GetValuesofID(id);
               return View(result);
            }
           
        }

        // GET: Budgets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = GetValuesofID(id);
            return View(result);
            
        }

        // POST: Budgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DeleteBudgeds";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction(nameof(Index));
        }
    }
}
