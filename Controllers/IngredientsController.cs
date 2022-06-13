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
    public class IngredientsController : Controller
    {
        private SqlConnection connect = null;
        public string connectionstring = "Data Source=KYLYM;Initial Catalog=SUBD;User ID=User;Password=12345";
        public Ingredients GetValuesofID(int? Id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectIngredients";
            cmd.Parameters.Add(new SqlParameter("@ID", Id));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Ingredients ingredients = new Ingredients();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    ingredients.Id = (short)(getvalues[0]);
                    ingredients.Product = (short)(getvalues[1]);
                    ingredients.RawMaterials = (short?)(getvalues[2]);
                    ingredients.Countingred = (float)(getvalues[3]);
                }
            }
            getvalues.Close();
            connect.Close();

            return ingredients;

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
                        Unit=(short)getvalues[2],
                        Sum=Convert.ToDecimal(getvalues[3]),
                        Countproducts=(float)getvalues[4],
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return finproducts;
        }
        public List<Finproducts> GetValuesofFinproductsID(int ID)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectFinproducts";
            cmd2.Parameters.Add(new SqlParameter("@ID", ID));
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

        public List<Rawmaterials> GetValuesofRawmaterials()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllRawmaterials";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Rawmaterials> rawmaterials = new List<Rawmaterials>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {

                    rawmaterials.Add(new Rawmaterials()
                    {
                        
                        Id = (short)getvalues[0],
                        Name = getvalues[1].ToString(),
                        Unit=(short)getvalues[2],
                        Sum=Convert.ToDecimal(getvalues[3]),
                        CountRawm=(float)getvalues[4],
                        
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return rawmaterials;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index(int SearchString)
        {
            connect = new SqlConnection(connectionstring);
            Finproducts finproducts = new Finproducts();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllFinproducts";
            connect.Open();
            SqlDataReader getvalues2 = cmd2.ExecuteReader();
            List<Finproducts> finproducts1 = new List<Finproducts>();
            if (getvalues2.HasRows)
            {
                while (getvalues2.Read())
                {
                    finproducts1.Add(new Finproducts()
                    {
                        Id = (short)getvalues2[0],
                        Name = getvalues2[1].ToString(),
                        Unit = (short)getvalues2[2],
                        Sum = Convert.ToDecimal(getvalues2[3]),
                        Countproducts = (float)getvalues2[4],
                    });
                }
            }
            getvalues2.Close();

           
            Rawmaterials rawmaterials = new Rawmaterials();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = connect;
            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
            cmd3.CommandText = "SelectAllRawmaterials";
            
            SqlDataReader getvalues3 = cmd3.ExecuteReader();
            List<Rawmaterials> rawmaterials1 = new List<Rawmaterials>();
            if (getvalues3.HasRows)
            {
                while (getvalues3.Read())
                {
                    rawmaterials1.Add(new Rawmaterials()
                    {
                        Id = (short)getvalues3[0],
                        Name = getvalues3[1].ToString(),
                        Unit = (short)getvalues3[2],
                        Sum = Convert.ToDecimal(getvalues3[3]),
                        CountRawm = (float)getvalues3[4],
                    });
                }
            }
            getvalues3.Close();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectAllIngredients";
            SqlDataReader getvalues = cmd.ExecuteReader();
            List<Ingredients> ingredients = new List<Ingredients>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    foreach (Finproducts val in finproducts1)
                    {
                        foreach(Rawmaterials val2 in rawmaterials1)
                        {
                            if (val.Id == (short?)(getvalues[1])&&val2.Id== (short?)(getvalues[2]))
                            {
                                finproducts = val;
                                rawmaterials = val2;
                                ingredients.Add(new Ingredients()
                                {
                                    Id = (short)(getvalues[0]),
                                    Product = (short)(getvalues[1]),
                                    RawMaterials = (short)getvalues[2],
                                    Countingred = (float)(getvalues[3]),
                                    ProductNavigation=finproducts,
                                    RawMaterialsNavigation=rawmaterials,
                                });
                            }
                        }
                        
                    }
                }
            }
            
            if (SearchString == 0)
            {
                getvalues.Close();

                connect.Close();
                var FinproductsList = GetValuesofFinproducts();
                ViewData["Product"] = new SelectList(FinproductsList, "Id", "Name");
               
                return View(ingredients);
            }
            else
            {
                getvalues.Close();
                SqlCommand cmdf = new SqlCommand();
                cmdf.Connection = connect;
                cmdf.CommandType = System.Data.CommandType.StoredProcedure;
                cmdf.CommandText = "FilterOfingr";
                cmdf.Parameters.Add(new SqlParameter("@Search", SearchString));
                SqlDataReader getvalues4 = cmdf.ExecuteReader();
                List<Ingredients> ingredients1 = new List<Ingredients>();
                if (getvalues4.HasRows)
                {
                    while (getvalues4.Read())
                    {
                        foreach (Finproducts val in finproducts1)
                        {
                            foreach (Rawmaterials val2 in rawmaterials1)
                            {
                                if (val.Id == (short?)(getvalues4[1]) && val2.Id == (short?)(getvalues4[2]))
                                {
                                    finproducts = val;
                                    rawmaterials = val2;
                                    ingredients1.Add(new Ingredients()
                                    {
                                        Id = (short)(getvalues4[0]),
                                        Product = (short)(getvalues4[1]),
                                        RawMaterials = (short)getvalues4[2],
                                        Countingred = (float)(getvalues4[3]),
                                        ProductNavigation = finproducts,
                                        RawMaterialsNavigation = rawmaterials,
                                    });
                                }
                            }

                        }
                    }
                }
                getvalues4.Close();
                connect.Close();
                var FinproductsList = GetValuesofFinproducts();
                ViewData["Product"] = new SelectList(FinproductsList, "Id", "Name");

                return View(ingredients1);
            }
          
        }

       
        // GET: Ingredients/Create
        public IActionResult Create(int ID)
        {
            var Product = GetValuesofFinproducts();
            var ProductID=GetValuesofFinproductsID(ID);
            var Rawmaterial = GetValuesofRawmaterials();
            if (ID == 0)
            {
                ViewData["Product"] = new SelectList(Product, "Id", "Name");
                ViewData["RawMaterials"] = new SelectList(Rawmaterial, "Id", "Name");
            }
            else
            {
                ViewData["Product"] = new SelectList(Product.Where(e=>e.Id==ID), "Id", "Name");
                ViewData["RawMaterials"] = new SelectList(Rawmaterial, "Id", "Name");
            }
            
           
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,RawMaterials,Countingred")] Ingredients ingredients)
        {
            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertIngredients";
                cmd.Parameters.Add(new SqlParameter("@Product", ingredients.Product));
                cmd.Parameters.Add(new SqlParameter("@RawMaterials", ingredients.RawMaterials));
                cmd.Parameters.Add(new SqlParameter("@Countingred", ingredients.Countingred));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                int ID = Convert.ToInt32(ingredients.Product);
                return RedirectToAction("Index", new { searchString = ID });
            }
            var Productlist = GetValuesofFinproducts();
            var result = GetValuesofID(ingredients.Id);
            var RawMaterialstlist = GetValuesofRawmaterials();
            ViewData["Product"] = new SelectList(Productlist, "Id", "Name", result.Product);
            ViewData["RawMaterials"] = new SelectList(RawMaterialstlist, "Id", "Name", result.RawMaterials);
            return View(result);
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Productlist = GetValuesofFinproducts();
            var result = GetValuesofID(id);
            int ProductID = (int)result.Product;
            var RawMaterialstlist = GetValuesofRawmaterials();
            if (result == null)
            {
                return NotFound();
            }

            var Product = GetValuesofFinproducts();

            ViewData["Product"] = new SelectList(Product.Where(e=>e.Id==ProductID), "Id", "Name");
            ViewData["RawMaterials"] = new SelectList(RawMaterialstlist, "Id", "Name", result.RawMaterials);
            return View(result);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,Product,RawMaterials,Countingred")] Ingredients ingredients)
        {
            if (id != ingredients.Id)
            {
                return NotFound();
            }
            var result = GetValuesofID(id);
            if (ModelState.IsValid)
            {
               
                
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateIngredients";
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@Product", ingredients.Product));
                cmd.Parameters.Add(new SqlParameter("@RawMaterials", ingredients.RawMaterials));
                cmd.Parameters.Add(new SqlParameter("@Countingred", ingredients.Countingred));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                int ID = Convert.ToInt32(ingredients.Product);
                return RedirectToAction("Index", new { searchString = ID });
                
            }
            var Productlist = GetValuesofFinproducts();
           
            var RawMaterialstlist = GetValuesofRawmaterials();
            ViewData["Product"] = new SelectList(Productlist, "Id", "Name", result.Product);
            ViewData["RawMaterials"] = new SelectList(RawMaterialstlist, "Id", "Name", result.RawMaterials);
            return View(result);
        }

        // GET: Ingredients/Delete/5
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
            cmd2.CommandText = "SelectRawmaterials";
            cmd2.Parameters.Add(new SqlParameter("@ID", result.RawMaterials));
           
            SqlDataReader getvalues2 = cmd2.ExecuteReader();
            Rawmaterials rawmaterials = new Rawmaterials();
            if (getvalues2.HasRows)
            {
                while (getvalues2.Read())
                {
                    rawmaterials.Id = (short)getvalues2[0];
                    rawmaterials.Name = getvalues2[1].ToString();
                    rawmaterials.Unit = (short)getvalues2[2];
                    rawmaterials.Sum = Convert.ToDecimal(getvalues2[3]);
                    rawmaterials.CountRawm = (float)getvalues2[4];
                }
            }
            getvalues2.Close();
            connect.Close();
            if (result == null)
            {
                return NotFound();
            }
            result.ProductNavigation = finproducts;
            result.RawMaterialsNavigation = rawmaterials;
            return View(result);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var result = GetValuesofID(id);
            int ID = (int)result.Product;
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DeleteIngredients";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction("Index", new { searchString = ID });
        }
    }
}
