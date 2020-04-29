using EscapeFromTheWoods_Asynchroon.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon
{
    class DatabaseWriter
    {
        private string _connectionString = @"Data Source=DESKTOP-VCI7746\SQLEXPRESS;Initial Catalog=EscapeFromTheWoods;Integrated Security=True";
        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public void FillDataBase(Wood wood)
        {
            Console.WriteLine($"DATABASE: Started Writing to database for {wood.Id}");
            BulkTrees(wood);
            BulkMonkeyRecords(wood);
            BulkLogs(wood);
            Console.WriteLine($"DATABASE: Finished writing to database for {wood.Id}");
        }
        public void BulkLogs(Wood wood)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("woodId", typeof(int));
                    table.Columns.Add("monkeyId", typeof(int));
                    table.Columns.Add("message", typeof(string));

                    foreach (Monkey monkey in wood.Monkeys)
                    {
                        foreach (Tree tree in monkey.VisitedTrees) {
                            string log = $"{monkey.Name} is now in tree {tree.ID} at location ({tree.X},{tree.Y}).";

                        table.Rows.Add(wood.Id, monkey.Id, log);
                        }
                    }
                    bulkCopy.DestinationTableName = "Logs";
                    bulkCopy.ColumnMappings.Add("woodId", "woodId");
                    bulkCopy.ColumnMappings.Add("monkeyId", "monkeyId");
                    bulkCopy.ColumnMappings.Add("message", "message");
                    bulkCopy.WriteToServer(table);
                }
            }
        }
        public void BulkTrees(Wood wood)
        {
            using(SqlConnection connection = GetConnection())
            {
                connection.Open();
                using(SqlBulkCopy bulkCopy = new SqlBulkCopy(connection)){
                    DataTable table = new DataTable();
                    table.Columns.Add("woodID", typeof(int));
                    table.Columns.Add("treeID", typeof(int));
                    table.Columns.Add("X", typeof(int));
                    table.Columns.Add("Y", typeof(int));

                    foreach(Tree tree in wood.Trees)
                    {
                        table.Rows.Add(wood.Id, tree.ID, tree.X, tree.Y);
                    }
                    bulkCopy.DestinationTableName = "WoodRecords";
                    bulkCopy.ColumnMappings.Add("woodID", "woodID");
                    bulkCopy.ColumnMappings.Add("treeID", "treeID");
                    bulkCopy.ColumnMappings.Add("X", "X");
                    bulkCopy.ColumnMappings.Add("Y", "Y");
                    bulkCopy.WriteToServer(table);
                }
            }
        }
        public void BulkMonkeyRecords(Wood wood)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("monkeyID", typeof(int));
                    table.Columns.Add("monkeyName", typeof(string));
                    table.Columns.Add("woodID", typeof(int));
                    table.Columns.Add("seqnr", typeof(int));
                    table.Columns.Add("treeID", typeof(int));
                    table.Columns.Add("X", typeof(int));
                    table.Columns.Add("Y", typeof(int));

                    foreach (Monkey monkey in wood.Monkeys)
                    {
                        for (int i = 0; i < monkey.VisitedTrees.Count; i++) {
                            table.Rows.Add(monkey.Id, monkey.Name, wood.Id,i,monkey.VisitedTrees[i].ID, monkey.VisitedTrees[i].X, monkey.VisitedTrees[i].Y);
                        }
                    }
                    bulkCopy.DestinationTableName = "MonkeyRecords";
                    bulkCopy.ColumnMappings.Add("monkeyID", "monkeyID");
                    bulkCopy.ColumnMappings.Add("monkeyName", "monkeyName");
                    bulkCopy.ColumnMappings.Add("woodID", "woodID");
                    bulkCopy.ColumnMappings.Add("seqnr", "seqnr");
                    bulkCopy.ColumnMappings.Add("treeID", "treeID");
                    bulkCopy.ColumnMappings.Add("X", "X");
                    bulkCopy.ColumnMappings.Add("Y", "Y");
                    bulkCopy.WriteToServer(table);
                }
            }
        }
    }
}
