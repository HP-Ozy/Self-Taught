
/*Dichiarazione dei namespace:*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/*Queste istruzioni importano i namespace necessari per utilizzare le classi e i tipi definiti nel framework .NET.*/

namespace CRUDExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Your_Connection_String"; // Inserisci la tua stringa di connessione qui

            // Create
            int newId = CreateRecord(connectionString, "John Doe", "john.doe@example.com");
            Console.WriteLine("New record created with ID: " + newId);

static int CreateRecord(string connectionString, string name, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Persons (Name, Email) VALUES (@Name, @Email); SELECT SCOPE_IDENTITY();", connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);

                int newId = Convert.ToInt32(command.ExecuteScalar());
                return newId;
            }
        }



            // Read
            List<Person> persons = ReadRecords(connectionString);
            Console.WriteLine("All records:");
            foreach (Person person in persons)
            {
                Console.WriteLine($"ID: {person.Id}, Name: {person.Name}, Email: {person.Email}");
            }


        static List<Person> ReadRecords(string connectionString)
        {
            List<Person> persons = new List<Person>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Persons", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = reader["Name"].ToString();
                    string email = reader["Email"].ToString();

                    Person person = new Person(id, name, email);
                    persons.Add(person);
                }

                reader.Close();
            }

            return persons;
        }



            // Update
            bool updated = UpdateRecord(connectionString, newId, "John Smith", "john.smith@example.com");
            if (updated)
            {
                Console.WriteLine("Record updated successfully.");
            }

static Person ReadRecord(string connectionString, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Persons WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string name = reader["Name"].ToString();
                    string email = reader["Email"].ToString();

                    Person person = new Person(id, name, email);
                    return person;
                }

                reader.Close();
            }

            return null;
        }



            // Read again to verify the update
            Person updatedPerson = ReadRecord(connectionString, newId);
            if (updatedPerson != null)
            {
                Console.WriteLine($"Updated record - ID: {updatedPerson.Id}, Name: {updatedPerson.Name}, Email: {updatedPerson.Email}");
            }

            // Delete
            bool deleted = DeleteRecord(connectionString, newId);
            if (deleted)
            {
                Console.WriteLine("Record deleted successfully.");
            }

            Console.ReadLine();
        }

        

        

        static bool UpdateRecord(string connectionString, int id, string name, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Persons SET Name = @Name, Email = @Email WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue
            }
        }