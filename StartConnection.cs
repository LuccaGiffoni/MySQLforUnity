using MySql.Data.MySqlClient;
using UnityEngine;

public class OpenConnection : MonoBehaviour
{
    public string Host = "unity-azure.mysql.database.azure.com";
    public string Pass = "Java2002.";
    public string User = "lucca@unity-azure";
    public string DataBaseName = "usuarios";
    public string LoginTableName = "goit";
    private MySqlConnection connection;
    private string source;

    void Start()
    {
        // Server=unity-azure.mysql.database.azure.com; Port=3306; Database={your_database}; Uid=lucca@unity-azure; Pwd={your_password}; SslMode=Preferred;
        // Creating the connection string
        source = "Server=" + Host + "; Port=3306; Database=" + DataBaseName + ";Uid=" + User + "; Pwd=" + Pass;

        // Creating and printing connection status
        Debug.Log("Creating connection");
        connection = new MySqlConnection(source);

        try
        {
            // Try to open the connection
            connection.OpenAsync();
            Debug.Log("Connection sucessfully opened!");
        }
        catch (System.Exception e)
        {
            // Show the error on console
            Debug.LogError(e);
        }
    }

    public void DisplayData()
    {
        // Open a new and clear command
        MySqlCommand cmd = connection.CreateCommand();

        // Putting a request on that command
        cmd.CommandText = "SELECT * FROM " + LoginTableName;

        // Executing the commmand
        MySqlDataReader dados = cmd.ExecuteReader();

        while (dados.Read())
        {
            // While there is data to show, print it!
            Debug.Log("Dados: " + "Código do Cliente: " + dados["cod_cli"] + ". Nome: " + dados["nome"] + ". Profissão: " + dados["profissao"] + ". CEP: " + dados["cep"] + "\n"); // Mostramos estes dados
        }

        // Closing the reading command
        dados.Close();
        cmd.Dispose();
    }

    void OnApplicationQuit()
    {
        // When we leave the application
        // Close the connection
        connection.Close();
        connection = null;

        // Showing the actual connection status
        Debug.Log("Database connection closed!");
    }
}