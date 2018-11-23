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
    public class UserRepository : IRepository<User>
    {
        private const string _connectionString = @"Data Source=DESKTOP-KLAJEJK\MSSQLSERVER2017;Integrated Security=True;Initial Catalog=FincaTask";
        private readonly SqlConnection _connection;
        public readonly SqlCommand _command;
        public UserRepository(SqlConnection connection, SqlCommand command)
        {
            _connection = connection;
            _connection.ConnectionString = _connectionString;
            _command = command;
            _command.Connection = _connection;
        }
        public void Add(User entity)
        {
            OpenConnection();
            string commandText = "INSERT INTO Users " +
                "(Username,Password,IsAdmin,IsDeleted)" +
                $"Values(@Username,@Password,@IsAdmin,@IsDeleted)";
            _command.CommandText = commandText;
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@Username",
                Value = entity.Username,
                SqlDbType=SqlDbType.NVarChar
            };
            _command.Parameters.Add(parameter);
            parameter = new SqlParameter
            {
                ParameterName="@Password",
                Value=entity.Password,
                SqlDbType=SqlDbType.NVarChar
            };
            _command.Parameters.Add(parameter);
            parameter = new SqlParameter
            {
                ParameterName = "@IsAdmin",
                Value = entity.IsAdmin,
                SqlDbType = SqlDbType.Bit
            };
            _command.Parameters.Add(parameter);
            parameter = new SqlParameter
            {
                ParameterName = "@IsDeleted",
                Value = entity.IsDeleted,
                SqlDbType = SqlDbType.Bit
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

        public void Delete(User entity)
        {
            OpenConnection();
            string commandText = $"DELETE FROM Users " +
                $"WHERE ID={entity.ID}";
            _command.CommandText = commandText;
            _command.ExecuteNonQuery();
            CloseConnection();
        }

        public User GetItemByID(int id)
        {
            OpenConnection();
            User user = null;
            string commandText = $"SELECT * FROM Users WHERE ID={id}";
            _command.CommandText = commandText;
            using (SqlDataReader reader = _command.ExecuteReader())
            {
                while (reader.Read())
                {
                    user = new User
                    {
                        ID = (int)reader["ID"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        IsAdmin = (bool)reader["IsAdmin"],
                        IsDeleted = (bool)reader["IsDeleted"],
                    };
                }
            }
            CloseConnection();
            return user;
        }

        public IQueryable<User> GetItems()
        {
            List<User> users = new List<User>();
            OpenConnection();
            string commandText = "SELECT * FROM Users";
            _command.CommandText = commandText;
            using (SqlDataReader reader = _command.ExecuteReader())
            {
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        ID = (int)reader["ID"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        IsAdmin = (bool)reader["IsAdmin"],
                        IsDeleted = (bool)reader["IsDeleted"],
                    });
                }
            }
            CloseConnection();
            return users.AsQueryable();
        }

        public void OpenConnection() => _connection.Open();

        public void Update(User updatedEntity)
        {
            OpenConnection();
            string commandText = $"UPDATE Users SET Username={updatedEntity.Username}" +
                $",Password='{updatedEntity.Password}'" +
                $",IsAdmin='{updatedEntity.IsAdmin}',IsDeleted='{updatedEntity.IsDeleted}'";
            _command.CommandText = commandText;
            _command.ExecuteNonQuery();
            CloseConnection();
        }

        public bool GetUserRoleByUsername(string username)
        {
            OpenConnection();
            string commandText = $"Select IsAdmin from Users where Username = '{username}'";
            _command.CommandText = commandText;
            bool isAdmin = false;
            using (SqlDataReader reader = _command.ExecuteReader())
            {
                while (reader.Read())
                    isAdmin = (bool)reader[0];
            }
            CloseConnection();
            return isAdmin;
        }

        public bool ValidateUser(string username, string password, out bool isAdmin, out int id)
        {
            OpenConnection();
            string commandText = $"SELECT ID, IsAdmin FROM Users WHERE Username = '{username}' " +
                $"and Password = '{password}'";
            _command.CommandText = commandText;
            isAdmin = false;
            id = -1;
            using (SqlDataReader reader = _command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.FieldCount > 0)
                    {
                        isAdmin = (bool)reader["IsAdmin"];
                        id = (int)reader["ID"];
                    }
                }
            }
            CloseConnection();
            return id > 0;
        }
    }
}
