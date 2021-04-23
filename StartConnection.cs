using MySql.Data.MySqlClient;
using UnityEngine;

public class OpenConnection : MonoBehaviour
{
    public string Host = "YOUR_SERVER.mysql.database.azure.com";
    public string Pass = "YOUR_PASSWORD";
    public string User = "YOUR_USER";
    public string DataBaseName = "YOUR_DATABASE_NAME";
    public string LoginTableName = "YOUR_TABLE_NAME";
    private MySqlConnection connection;
    private string source;

    void Start()
    {
        // You can find your connection string with your server provider
        // IMPORTANT: The port is variable, so check in wich port your server is
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
        MySqlDataReader data = cmd.ExecuteReader();

        while (data.Read())
        {
            // While there is data to show, print it!
            Debug.Log("Data: " + "YOUR_FIELD: " + dados["YOUR_FIELD"] + ". YOUR_FIELD: " + dados["YOUR_FIELD"] + ". YOUR_FIELD: " + dados["YOUR_FIELD"] + ". YOUR_FIELD: " + dados["YOUR_FIELD"] + "\n"); // Mostramos estes dados
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