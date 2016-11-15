﻿//#define TEST_CLOSURE // http://weblogs.asp.net/fbouma/archive/2009/06/25/linq-beware-of-the-access-to-modified-closure-demon.aspx

using System;
using System.Data.Linq;
using System.Linq;

namespace TestLINQ2SQLII
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DataContext("Data Source=nozhenko-s8\\SQLEXPRESS;Initial Catalog=testdb;Integrated Security=SSPI;");
            //var db = new DataContext("Data Source=nozhenko-s8\\SQLEXPRESS;Initial Catalog=testdb;User Id=testuser;Password=123456");

            Table<Staff>
                tableStaff = db.GetTable<Staff>();

            #if TEST_CLOSURE
                string
                    searchTerms = "а и";

                string[]
                    searchCriteria = searchTerms.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var
                    customers = from c in tableStaff
                                select new {ID = c.ID, Name = c.Name, Salary = c.Salary, Dep = c.Dep, BirthDate = c.BirthDate};

                foreach (var search in searchCriteria)
                {
                    var searchTerm = search;
                    customers = customers.Where(p => p.Name.Contains(searchTerm));
                }
                var ids = (from c in customers select c.ID).ToArray(); // select * from staff where (Name like '%а%') and (Name like '%и%')
                foreach(var id in ids)
                    Console.WriteLine(id);
                Console.WriteLine();

                customers = from c in tableStaff
                            select new { ID = c.ID, Name = c.Name, Salary = c.Salary, Dep = c.Dep, BirthDate = c.BirthDate };

                foreach (var search in searchCriteria)
                {
                    customers = customers.Where(p => p.Name.Contains(search));
                }
                ids = (from c in customers select c.ID).ToArray(); // select * from staff where (Name like '%и%') and (Name like '%и%')
                foreach (var id in ids)
                    Console.WriteLine(id);
                Console.WriteLine();
            #endif

            var sql = from s in tableStaff select s;

            foreach (var s in sql)
                Console.WriteLine("{{ID: {0}, Name: {1}, Salary: {2}, Dep: {3}, BirthDate: {4}, NullField: {5}}}", s.ID, s.Name, s.Salary.HasValue ? s.Salary.Value.ToString() : "NULL", s.Dep.HasValue ? s.Dep.Value.ToString() : "NULL", s.BirthDate.HasValue ? s.BirthDate.Value.ToString() : "NULL", s.NullField.HasValue ? s.NullField.Value.ToString() : "NULL");

            Staff
                staff = new Staff {ID = 3, Name = "blah-blah-blah"};

            //tableStaff.InsertOnSubmit(staff);
            //db.SubmitChanges();

            try
            {
                tableStaff.Where(s => s.Name == "blah-blah-blah").Take(2).SingleOrDefault(); // InvalidOperationException: "Sequence contains more than one element"
            }
            catch(InvalidOperationException eException)
            {
                Console.WriteLine(eException.Message);
            }

            staff = tableStaff.Where(s => s.ID == 5).SingleOrDefault();
            if (staff == null)
                Console.WriteLine("staff==null");
            if(staff==default(Staff))
                Console.WriteLine("staff==default(Staff)");

            if ((staff = tableStaff.Where(s => s.ID == 2).SingleOrDefault()) != null)
            {
                staff.BirthDate = DateTime.Now;
                db.SubmitChanges();
            }

            Console.ReadLine();
        }
    }
}