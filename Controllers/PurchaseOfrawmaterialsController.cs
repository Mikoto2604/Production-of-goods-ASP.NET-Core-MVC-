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
    public class PurchaseOfrawmaterialsController : Controller
    {
        private SqlConnection connect = null; // Переменная для подключения
        public string connectionstring = "Data Source=KYLYM;Initial Catalog=SUBD;User ID=User;Password=12345"; // Строка подключения
        public PurchaseOfrawmaterials GetValuesofID(short? Id)  // Метод, который возвращает записи по ID
        {
            connect = new SqlConnection(connectionstring); // Создаем новое соединение с Базой
            SqlCommand cmd = new SqlCommand(); // Создаем переменную для команд
            cmd.Connection = connect; // Соединяемся 
            cmd.CommandType = System.Data.CommandType.StoredProcedure; // Определяем тип команды. Мы будем вызывать хранимые процедуры
            cmd.CommandText = "SelectPurchaseOfrawmaterials"; // Название хранимой процедуры
            cmd.Parameters.Add(new SqlParameter("@ID", Id)); // Передаем параметр ID
            connect.Open(); // Открываем соединение
            SqlDataReader getvalues = cmd.ExecuteReader(); // Считываем результаты хранимой процедуры
            PurchaseOfrawmaterials purchaseOfrawmaterials = new PurchaseOfrawmaterials(); // Создаем новый обьект класса.
            //Нам необходимо заполнить этот обьект результатом хранимой процедуры
            if (getvalues.HasRows) // Если есть запись. То есть, если хранимая процедура вернула значение
            {
                while (getvalues.Read()) // Последовательно читаем 
                {
                    // Так как, SqlDataReader хранит в себе данные как обьекты
                    // Нам требуется их преобразить в нужные нам типы данных
                    purchaseOfrawmaterials.Id = (short)(getvalues[0]);
                    purchaseOfrawmaterials.RawMaterials = (short)(getvalues[1]);
                    purchaseOfrawmaterials.CountPur = (float?)(getvalues[2]);
                    purchaseOfrawmaterials.Sum = (decimal)(getvalues[3]);
                    purchaseOfrawmaterials.Date = (DateTime)(getvalues[4]);
                    purchaseOfrawmaterials.Employee = (int?)(getvalues[5]);
                }
            }
            getvalues.Close(); // Закрываем чтение. Если не закрыть другие запросы не смогут подключиться
            connect.Close(); // Закрываем соединение так как оно больше не используется в данном методе

            return purchaseOfrawmaterials; // Вовращаем результат

        }

        public List<Rawmaterials> GetValuesofRawmaterials() // Метод, который возвращает список значений с типом Rawmaterials
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllRawmaterials";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Rawmaterials> rawmaterials = new List<Rawmaterials>(); // Создаем список с типом Rawmaterials
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    // Читаем результат и добавляем их в список
                    rawmaterials.Add(new Rawmaterials()
                    {
                        Id = (short)getvalues[0],
                        Name = getvalues[1].ToString(),
                        Unit = (short)getvalues[2],
                        Sum = Convert.ToDecimal(getvalues[3]),
                        CountRawm = (float)getvalues[4],
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return rawmaterials; // Возврааем список
        }

        public List<Employees> GetValuesofEmployees() // Метод, который возвращает список Сотрудников
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
        }


        // GET: PurchaseOfrawmaterials
        public async Task<IActionResult> Index() // Главный метод. При запуске программы, будет обрабатываься именно этот метод
        {
            connect = new SqlConnection(connectionstring);
            Employees employees = new Employees();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllEmployees"; // Получаем список всех сотрудников
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
                        Telephone = (getvalues2[4]).ToString(),
                    });
                }
            }
            getvalues2.Close();


            Rawmaterials rawmaterials = new Rawmaterials();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = connect;
            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
            cmd3.CommandText = "SelectAllRawmaterials"; // Получаем все сырье

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
            cmd.CommandText = "SelectAllPurchaseOfrawmaterials"; // Получаем все закупки
            SqlDataReader getvalues = cmd.ExecuteReader();
            List<PurchaseOfrawmaterials> purchaseOfrawmaterials = new List<PurchaseOfrawmaterials>();// Создаем новый список с типом PurchaseOfrawmaterials
            if (getvalues.HasRows)
            {
                while (getvalues.Read()) 
                {
                    foreach (Employees val in employees1) // Проходим по списку сотрудников
                    {
                        foreach (Rawmaterials val2 in rawmaterials1) // Проходим по списку сырья
                        {
                            // Если ID сотрудника совпадает с внешним ключом сотрудника в закупках
                            //Записываем этого содруника в обьект employees
                            // Если ID сырья совпадает с внешним ключом сырья в закупках
                            //Записываем это сырье в обьект rawmaterials
                            if (val.Id == Convert.ToInt32(getvalues[5]) && val2.Id == (short)(getvalues[1])) 
                            {
                                employees = val;
                                rawmaterials = val2;

                                purchaseOfrawmaterials.Add(new PurchaseOfrawmaterials() // Записываем полученные значения в список
                                {
                                    // Заполняем данные
                                    Id = (short)(getvalues[0]),
                                    RawMaterials = (short)getvalues[1],
                                    CountPur = (float)(getvalues[2]),
                                    Sum = Convert.ToDecimal(getvalues[3]),
                                    Date = (DateTime)getvalues[4],
                                    Employee = (int)getvalues[5],
                                    // Используем поля ранее созданные в модели и присваиваем им значения первычных ключов
                                    RawMaterialsNavigation = rawmaterials,
                                    EmployeeNavigation = employees,
                                });
                            }
                        }

                    }
                }
            }
            getvalues.Close();
            connect.Close();
            return View(purchaseOfrawmaterials); // Отправляем в представление Index
        }


        // GET: PurchaseOfrawmaterials/Create
        public IActionResult Create()
        {
            // Вызываем ранее созданные методы
            var Employee = GetValuesofEmployees();
            var Rawmaterial = GetValuesofRawmaterials();
            // Формируем выпадающие списки для удобства 
            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname");
            ViewData["RawMaterials"] = new SelectList(Rawmaterial, "Id", "Name");
            return View();
        }

       

        // Определяем типы методов. Первые два метода Index и Create являются методами для GET запросов
        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create([FromForm] PurchaseOfrawmaterials purchaseOfrawmaterials) //Post метод, который добавляет новые данные
        {
            if (ModelState.IsValid)
            {

                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_Zakupka"; // Вызываем хранимую процедуру для проверки суммы бюджета для закупки
                cmd.Parameters.Add(new SqlParameter("@sum", purchaseOfrawmaterials.Sum)); // Передаем как параметр сумму закупки
                SqlParameter p = new SqlParameter // Определяем выходной параметр для получения результата
                {
                    ParameterName = "@p",
                    SqlDbType = SqlDbType.Int,
                    Size=1
                };
                p.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p); 
                connect.Open();
                cmd.ExecuteNonQuery(); // Выполянем хранимую процедуру

                var k = Convert.ToInt32((cmd.Parameters["@p"].Value)); // Получаем результат p


                if (k==0) // Если p вернул 0, то сумма хватает 
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = connect;
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.CommandText = "InsertPurchaseOfrawmaterials"; // Вызываем хранимую процедуру для добавления
                    // Передаем ему нужные параметры 
                    cmd2.Parameters.Add(new SqlParameter("@RawMaterials", purchaseOfrawmaterials.RawMaterials));
                    cmd2.Parameters.Add(new SqlParameter("@CountPur", purchaseOfrawmaterials.CountPur));
                    cmd2.Parameters.Add(new SqlParameter("@Sum", purchaseOfrawmaterials.Sum));
                    cmd2.Parameters.Add(new SqlParameter("@Date", purchaseOfrawmaterials.Date));
                    cmd2.Parameters.Add(new SqlParameter("@Employee", purchaseOfrawmaterials.Employee));
                    cmd2.ExecuteNonQuery(); // Выполняем хранимую процедуру
                    connect.Close();
                    return RedirectToAction(nameof(Index)); // Возвращаемся на главную страницу 
                }
                else // Иначе сообщаем пользователю
                {
                    ViewBag.Massage = "Не хватает бюджета для закупки!";
                }
            }
            // В случае не правильного ввода данных или ошибки, возвращаем страницу с введенными данными для удобства
            var Employee = GetValuesofEmployees();
            var Rawmaterial = GetValuesofRawmaterials();
            var result = GetValuesofID(purchaseOfrawmaterials.Id);
            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname", purchaseOfrawmaterials.Employee);
            ViewData["RawMaterials"] = new SelectList(Rawmaterial, "Id", "Name", purchaseOfrawmaterials.RawMaterials);
            return View(result);
        }

       
        public async Task<IActionResult> Edit(short? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            // Вызываем ранее созданные методы и возврашаем результат
            var Employee = GetValuesofEmployees();
            var Rawmaterial = GetValuesofRawmaterials();
            var result = GetValuesofID(id);

            if (result == null)
            {
                return NotFound();
            }
            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname");
            ViewData["RawMaterials"] = new SelectList(Rawmaterial, "Id", "Name");
            return View(result);
        }

        // POST: PurchaseOfrawmaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,RawMaterials,CountPur,Sum,Date,Employee")] PurchaseOfrawmaterials purchaseOfrawmaterials)
        {
            if (id != purchaseOfrawmaterials.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Соединяем снова
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdatePurchaseOfrawmaterials";
                // Передаем в хранимую процедуру параметры
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@RawMaterials", purchaseOfrawmaterials.RawMaterials));
                cmd.Parameters.Add(new SqlParameter("@CountPur", purchaseOfrawmaterials.CountPur));
                cmd.Parameters.Add(new SqlParameter("@Sum", purchaseOfrawmaterials.Sum));
                cmd.Parameters.Add(new SqlParameter("@Date", purchaseOfrawmaterials.Date));
                cmd.Parameters.Add(new SqlParameter("@Employee", purchaseOfrawmaterials.Employee));
                connect.Open();
                cmd.ExecuteNonQuery(); // Выполняем хранимую процедуру
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            var Employee = GetValuesofEmployees();
            var Rawmaterial = GetValuesofRawmaterials();
            var result = GetValuesofID(purchaseOfrawmaterials.Id);
            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname", purchaseOfrawmaterials.Employee);
            ViewData["RawMaterials"] = new SelectList(Rawmaterial, "Id", "Name", purchaseOfrawmaterials.RawMaterials);
            return View(result);
        }

        // GET: PurchaseOfrawmaterials/Delete/5
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
            cmd.CommandText = "SelectEmployee";
            cmd.Parameters.Add(new SqlParameter("@ID", result.Employee));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Employees employees = new Employees();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    employees.Id = Convert.ToInt32(getvalues[0]);
                    employees.Fullname = getvalues[1].ToString();
                    employees.Position = (short?)getvalues[2];
                    employees.Salary = Convert.ToDecimal(getvalues[3]);
                    employees.Address = (getvalues[4]).ToString();
                    employees.Telephone = (getvalues[4]).ToString();
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

            // Получаем сотрудников по ID 
            //Получаем сырья по ID
            // и записываем их
            result.EmployeeNavigation = employees;
            result.RawMaterialsNavigation = rawmaterials;
            return View(result);
        }

        // POST: PurchaseOfrawmaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DeletePurchaseOfrawmaterials"; // Вызывем хранимую процедуру для удаления
            cmd.Parameters.Add(new SqlParameter("@ID", id)); // Передаем ему ID 
            connect.Open();
            cmd.ExecuteNonQuery(); // Выполняем и возвращаемся на главную страницу
            connect.Close();
            return RedirectToAction(nameof(Index));
        }
    }
}
