using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess.Repository
{
    /// <summary>
    /// Connect To Database and Perforum CRUD operations
    /// </summary>


    public class EmployeeRepository : IEmployeeRepository
    {
        private SqlConnection _sqlConnection;

        public EmployeeRepository(string connectionstring)
        {
            _sqlConnection = new SqlConnection(connectionstring);

        }
        public EmployeeRepository()
        {
            _sqlConnection = new SqlConnection("data source = (localdb)\\mssqllocaldb; database = EmployeeDataBase;");
        }


            public IEnumerable<EmployeeData> GetEmployees()
            {
                //Take data from Table

                try
                {
                    _sqlConnection.Open();

                    var sqlCommand = new SqlCommand(cmdText: "select Id,Name,Department from Employee", _sqlConnection);

                    var sqlDataReader = sqlCommand.ExecuteReader();

                    var listOfemployee = new List<EmployeeData>();

                    while (sqlDataReader.Read())
                    {
                        listOfemployee.Add(new EmployeeData()
                        {
                            Id = (int)sqlDataReader["Id"],
                            Name = (string)sqlDataReader["Name"],
                            Department = (string)sqlDataReader["Department"]
                        });

                    }
                    return listOfemployee;
                }
                catch (Exception )
                {
                    return null;
                }
                finally
                {
                    _sqlConnection.Close();
                }

            }
        public EmployeeData GetEmployeeById(int Id) 
        {
            try
            {
                _sqlConnection.Open();

                var sqlcommand = new SqlCommand(cmdText: "Select * From Employee where Id =@Id", _sqlConnection);
                sqlcommand.Parameters.AddWithValue("Id",Id);

                var sqlDataReader = sqlcommand.ExecuteReader();

                var employee = new EmployeeData();

                while (sqlDataReader.Read())
                {

                    {
                        employee.Id = (int)sqlDataReader["Id"];
                        employee.Name = (string)sqlDataReader["Name"];
                        employee.Department = (string)sqlDataReader["Department"];
                        employee.Age = (int)sqlDataReader["Age"];
                        employee.Address = (string)sqlDataReader["Address"];
                    }

                }
                return employee;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public EmployeeData InsertEmployee(EmployeeData employee)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "Insert Into Employee (Name,Department,Age,Address) Values (@Name,@Department,@Age,@Address)", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("Department", employee.Department);
                sqlCommand.Parameters.AddWithValue("Age", employee.Age);
                sqlCommand.Parameters.AddWithValue("Address", employee.Address);

                sqlCommand.ExecuteNonQuery();

                return employee;

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public EmployeeData UpdateEmployee(EmployeeData employee)
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "Update Employee Set Name=@Name,Department=@Department,Age=@Age,Address=@Address Where Id=@Id", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("Id", employee.Id);
                sqlCommand.Parameters.AddWithValue("Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("Department", employee.Department);
                sqlCommand.Parameters.AddWithValue("Age", employee.Age);
                sqlCommand.Parameters.AddWithValue("Address", employee.Address);


                sqlCommand.ExecuteNonQuery();

                return employee;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool DeleteEmployee(int Id)
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "Delete From Employee Where Id=@Id", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("Id", Id);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}

