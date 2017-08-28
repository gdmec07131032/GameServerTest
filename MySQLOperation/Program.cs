﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySQLOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = "database=test007;datasource=127.0.0.1;port=3306;user=root;pwd=root;";
            MySqlConnection conn = new MySqlConnection(conStr);

            conn.Open();

            #region 查询
            /*
            MySqlCommand cmd = new MySqlCommand("select * from user", conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                string username = reader.GetString("username");
                string password = reader.GetString("password");
                Console.WriteLine(username + " : " + password);
            }

            reader.Close();
            */
            #endregion

            #region 插入
            /*
            string username = "cwer1";
            string password = "lcker1";
            //MySqlCommand cmd = new MySqlCommand("insert into user set username = '" + username + "'" + ",password='" + password + "'",conn);
            MySqlCommand cmd = new MySqlCommand("insert into user set username = @un , password = @pwd", conn);

            cmd.Parameters.AddWithValue("un", username);
            cmd.Parameters.AddWithValue("pwd", password);

            cmd.ExecuteNonQuery();
            */
            #endregion

            #region 删除
            /*
            MySqlCommand cmd = new MySqlCommand("delete from user where id = @id", conn);
            cmd.Parameters.AddWithValue("id", 9);

            cmd.ExecuteNonQuery();
            */
            #endregion

#region 更新
            /*
            MySqlCommand cmd = new MySqlCommand("update user set password = @pwd where id = 8", conn);
            cmd.Parameters.AddWithValue("pwd", "sikiedu.com");

            cmd.ExecuteNonQuery();
            */
#endregion

            conn.Close();


        }
    }
}
