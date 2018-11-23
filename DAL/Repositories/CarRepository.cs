using DAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace DAL.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private const string _connectionString = @"Data Source=DESKTOP-KLAJEJK\MSSQLSERVER2017;Integrated Security=True;Initial Catalog=FincaTask";
        private readonly SqlConnection _connection;
        public readonly SqlCommand _command;

        public CarRepository(SqlConnection connection, SqlCommand command)
        {
            _connection = connection;
            _connection.ConnectionString = _connectionString;
            _command = command;
            _command.Connection = _connection;
        }
        public void Add(Car entity)
        {
            OpenConnection();
            string commandText = "INSERT INTO Cars " +
                "(UserID,Mark,CarModel,Year,Vin,DateAdded)" +
                $"Values(@UserID,@Mark,@CarModel,@Year,@Vin,@DateAdded)";
            _command.CommandText = commandText;
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@UserID",
                Value = entity.UserID,
                SqlDbType = SqlDbType.Int,
            };
            _command.Parameters.Add(parameter);
            parameter = new SqlParameter
            {
                ParameterName = "@Mark",
                Value = entity.Mark,
                SqlDbType = SqlDbType.NVarChar,
            };
            _command.Parameters.Add(parameter);
            parameter = new SqlParameter
            {
                ParameterName = "@CarModel",
                Value = entity.CarModel,
                SqlDbType = SqlDbType.NVarChar,
            };
            _command.Parameters.Add(parameter);
            parameter = new SqlParameter
            {
                ParameterName = "@Year",
                Value = entity.Year,
                SqlDbType = SqlDbType.Int,
            };
            _command.Parameters.Add(parameter);
            parameter = new SqlParameter
            {
                ParameterName = "@Vin",
                Value = entity.Vin,
                SqlDbType = SqlDbType.NVarChar,
            };
            _command.Parameters.Add(parameter);
            parameter = new SqlParameter
            {
                ParameterName = "@DateAdded",
                Value = entity.DateAdded,
                SqlDbType = SqlDbType.SmallDateTime,
            };
            _command.Parameters.Add(parameter);

            _command.ExecuteNonQuery();

            CloseConnection();
        }
        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public void Delete(Car entity)
        {
            OpenConnection();
            string commandText = $"DELETE FROM Cars " +
                $"WHERE ID={entity.ID}";
            _command.CommandText = commandText;
            _command.ExecuteNonQuery();
            CloseConnection();
        }

        public Car GetItemByID(int id)
        {
            OpenConnection();
            Car car = null;
            string commandText = $"SELECT * FROM Cars WHERE ID={id}";
            _command.CommandText = commandText;
            using (SqlDataReader reader = _command.ExecuteReader())
            {
                while (reader.Read())
                {
                    car = new Car
                    {
                        ID = (int)reader["ID"],
                        UserID = (int)reader["UserID"],
                        Mark = (string)reader["Mark"],
                        CarModel = (string)reader["CarModel"],
                        Year = (int)reader["Year"],
                        Vin = (string)reader["Vin"],
                        DateAdded = (DateTime)reader["DateAdded"],
                        IsDeleted = (bool)reader["IsDeleted"]
                    };
                }
            }
            CloseConnection();
            return car;
        }
        public IQueryable<Car> GetItems()
        {
            List<Car> cars = new List<Car>();
            OpenConnection();
            string commandText = "SELECT * FROM Cars";
            _command.CommandText = commandText;
            using (SqlDataReader reader = _command.ExecuteReader())
            {
                while (reader.Read())
                {
                    cars.Add(new Car
                    {
                        ID = (int)reader["ID"],
                        UserID = (int)reader["UserID"],
                        Mark = (string)reader["Mark"],
                        CarModel = (string)reader["CarModel"],
                        Year = (int)reader["Year"],
                        Vin = (string)reader["Vin"],
                        DateAdded = (DateTime)reader["DateAdded"]
                    });
                }
            }
            CloseConnection();
            return cars.AsQueryable();
        }

        public ProductDetails GetProductsDetailedList(int productId, int UserId)
        {
            OpenConnection();
            ProductDetails product = new ProductDetails();
            string commandText = "SELECT Mark, CarModel, Year, Vin, DateAdded, Username " +
                $"FROM Users join Cars on Cars.UserID=Users.ID and Cars.ID={productId}";
            _command.CommandText = commandText;
            using (SqlDataReader reader = _command.ExecuteReader())
            {
                while (reader.Read())
                {
                    product.Mark = (string)reader["Mark"];
                    product.CarModel = (string)reader["CarModel"];
                    product.Year = (int)reader["Year"];
                    product.Vin = (string)reader["Vin"];
                    product.DateAdded = (DateTime)reader["DateAdded"];
                    product.Owner = (string)reader["Username"];
                }
            }
            CloseConnection();
            return product;
        }
        public void OpenConnection()
        {
            _connection.Open();
        }

        public void Update(Car updatedEntity)
        {
            OpenConnection();
            string commandText = $"UPDATE Cars SET UserID={updatedEntity.UserID}" +
                $",Mark='{updatedEntity.Mark}', CarModel='{updatedEntity.CarModel}'" +
                $",Year={updatedEntity.Year}, Vin='{updatedEntity.Vin}'" +
                $",DateAdded='{updatedEntity.DateAdded}', IsDeleted={updatedEntity.IsDeleted}";
            _command.CommandText = commandText;
            _command.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
