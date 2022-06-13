using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Enterprises_manufacturing_goods;
using Microsoft.Data.SqlClient;

namespace Enterprises_manufacturing_goods.Controllers
{
    public class RawmaterialsController : Controller
    {
        private SqlConnection connect = null;
        public string connectionstring = "Data Source=KYLYM;Initial Catalog=SUBD;User ID=User;Password=12345";
        public Rawmaterials GetValuesofID(int? Id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectRawmaterials";
            cmd.Parameters.Add(new SqlParameter("@ID", Id));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Rawmaterials rawmaterials = new Rawmaterials();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    rawmaterials.Id = (short)(getvalues[0]);
                    rawmaterials.Name = (getvalues[1]).ToString();
                    rawmaterials.Unit = (short?)(getvalues[2]);
                    rawmaterials.Sum = Convert.ToDecimal(getvalues[3]);
                    rawmaterials.CountRawm = (float)(getvalues[4]);
                }
            }
            getvalues.Close();
            connect.Close();

            return rawmaterials;

        }

        public List<Units> GetValuesofUnits()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllUnits";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Units> units = new List<Units>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {

                    units.Add(new Units()
                    {

                        Id = (short)getvalues[0],
                        Name = getvalues[1].ToString(),
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return units;
        }
        // GET: Rawmaterials
        public async Task<IActionResult> Index()
        {
            connect = new SqlConnection(connectionstring);
            Units units = new Units();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllUnits";
            connect.Open();
            SqlDataReader getvalues2 = cmd2.ExecuteReader();
            List<Units> units1 = new List<Units>();
            if (getvalues2.HasRows)
            {
                while (getvalues2.Read())
                {
                    units1.Add(new Units()
                    {

                        Id = (short)getvalues2[0],
                        Name = getvalues2[1].ToString(),
                    });
                }
            }
            getvalues2.Close();




            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectAllRawmaterials";
            SqlDataReader getvalues = cmd.ExecuteReader();
            List<Rawmaterials> rawmaterials = new List<Rawmaterials>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    foreach (Units val in units1)
                    {
                        if (val.Id == (short?)(getvalues[2]))
                        {
                            units = val;
                            rawmaterials.Add(new Rawmaterials()
                            {
                                Id = (short)(getvalues[0]),
                                Name = (getvalues[1]).ToString(),
                                Unit = (short?)(getvalues[2]),
                                Sum = Convert.ToDecimal(getvalues[3]),
                                CountRawm = (float)(getvalues[4]),
                                UnitNavigation = units,
                            });
                        }
                    }
                }
            }
            getvalues.Close();
            connect.Close();
            return View(rawmaterials);
        }

       

        // GET: Rawmaterials/Create
        public IActionResult Create()
        {
            var unit = GetValuesofUnits();
            ViewData["Unit"] = new SelectList(unit, "Id", "Name");
            return View();
        }

        // POST: Rawmaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Unit,Sum,CountRawm")] Rawmaterials rawmaterials)
        {
            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertRawmaterials";
                cmd.Parameters.Add(new SqlParameter("@Name", rawmaterials.Name));
                cmd.Parameters.Add(new SqlParameter("@Unit", rawmaterials.Unit));
                cmd.Parameters.Add(new SqlParameter("@Sum", rawmaterials.Sum));
                cmd.Parameters.Add(new SqlParameter("@CountRawm", rawmaterials.CountRawm));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            var Unitslist = GetValuesofUnits();
            var result = GetValuesofID(rawmaterials.Id);
            ViewData["Unit"] = new SelectList(Unitslist, "Id", "Name", result.Unit);
            return View(result);
        }

        // GET: Rawmaterials/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Unitslist = GetValuesofUnits();
            var result = GetValuesofID(id);
            if (result == null)
            {
                return NotFound();
            }
            ViewData["Unit"] = new SelectList(Unitslist, "Id", "Name", result.Unit);
            return View(result);
        }

        // POST: Rawmaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,Name,Unit,Sum,CountRawm")] Rawmaterials rawmaterials)
        {
            if (id != rawmaterials.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateRawmaterials";
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@Name", rawmaterials.Name));
                cmd.Parameters.Add(new SqlParameter("@Unit", rawmaterials.Unit));
                cmd.Parameters.Add(new SqlParameter("@Sum", rawmaterials.Sum));
                cmd.Parameters.Add(new SqlParameter("@CountRawm", rawmaterials.CountRawm));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            var Unitslist = GetValuesofUnits();
            var result = GetValuesofID(id);
            ViewData["Unit"] = new SelectList(Unitslist, "Id", "Name", result.Unit);
            return View(result);
        }

        // GET: Rawmaterials/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            connect = new SqlConnection(connectionstring);
            var result = GetValuesofID(id);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectUnits";
            cmd.Parameters.Add(new SqlParameter("@ID", result.Unit));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Units units = new Units();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {

                    units.Id = (short)getvalues[0];
                    units.Name = getvalues[1].ToString();

                }
            }
            getvalues.Close();
            connect.Close();
            if (result == null)
            {
                return NotFound();
            }
            result.UnitNavigation = units;
            return View(result);
        }

        // POST: Rawmaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DeleteRawmaterials";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction(nameof(Index));
        }

    }
}
