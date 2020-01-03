using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sap.Data.Hana;
using Dapper;
using Dapper.Contrib.IduExtensions;

namespace SapHanaDapper
{
    public class HANAConsole
    {
        static void Main(string[] args)
        {
            //testInsertRawQuery();
            testInsertWithContrib();
            //testUpdateWithContrib();
            //testDeleteWithContrib();
        }

        static void testInsertWithContrib()
        {
            using (var conn = IduConnection.Create())
            {
                var entity = new Tm_Master01();
                entity.Description = "test insert dari dapper - Contrib";
                conn.Insert(entity);
            }
        }
        static void testUpdateWithContrib()
        {
            using (var conn = IduConnection.Create())
            {
                var entity = conn.Get<Tm_Master01>(2);
                entity.Description = "test dari dapper update - Contrib";
                conn.Update(entity);
            }
        }

        static void testDeleteWithContrib()
        {
            using (var conn = IduConnection.Create())
            {
                var entity = conn.Get<Tm_Master01>(2);
                conn.Delete<Tm_Master01>(entity);
            }
        }

        static void testInsertRawQuery()
        {
            using (var conn = IduConnection.Create())
            {
                string ssql = @"INSERT INTO ""Tm_Master01"" (""Description"") VALUES (:p0)";
                conn.Execute(ssql, new { p0 = "test insert dari raw query" });
            }
        } 
       

        static void testKoneksiBiasa()
        {
            HanaConnection conn = new HanaConnection("Server=$userHost$:$userPort$;UserName=$userName$;Password=$userPassword$");
            conn.Open();
            HanaCommand cmd = new HanaCommand("select 'Hello, World' from DUMMY", conn); // Exception
            try
            {
                HanaDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Console.WriteLine(reader.GetString(0));
            }
            catch (Exception e)
            {
                String errorMsg = e.ToString();
                Console.WriteLine(errorMsg);
            }
        }
    }
}
