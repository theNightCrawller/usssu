using System.Text.Json;
// controller clienta
// czyli dodawanie,usuwanie itp

namespace app
{
    public class ClientManager
    {
        private List<Client> _clients = new List<Client>();
        // tutaj dajesz sciezke swojego programu 
        private readonly string _jsonFilePath = "clients.json";
        // zapisywanie do jsona helper i bez nadpisywania danych
        public void SaveToJson()
        {
            try
            {
                string json = JsonSerializer.Serialize(_clients);

                
                File.WriteAllText(_jsonFilePath, json);

                Console.WriteLine("Client list successfully saved to JSON.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during JSON serialization: {ex.Message}");
            }
        }

        public void ReadFromJson()
        {
            try
            {
                if (File.Exists(_jsonFilePath))
                {
                    string json = File.ReadAllText(_jsonFilePath);

                    _clients = JsonSerializer.Deserialize<List<Client>>(json);

                    
                    // po dodaniu do listy odczytujesz z listy uzwajac petli
                    Console.WriteLine("Client list:");
                    foreach (var client in _clients)
                    {

                        Console.WriteLine("Client:");
                        Console.WriteLine(client.ToString());
                    }
                }
                else
                {
                    throw new FileNotFoundException($"JSON file not found: {_jsonFilePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during JSON deserialization: {ex.Message}");
            }
        }

        public Client FindClientById(int clientId)
        {
            try
            {
                return _clients.FirstOrDefault(client => client.Id == clientId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while finding a client by ID: {ex.Message}");
                return null; 
            }
        }

        public void AddClient(Client client)
        {
            try
            {
                _clients.Add(client);
                SaveToJson();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding a client: {ex.Message}");
            }
        }

        public void DeleteClient(int clientId)
        {
            try
            {
                _clients.RemoveAll(client => client.Id == clientId);
               
                SaveToJson();

                Console.WriteLine("Client successfully deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting a client: {ex.Message}");
            }
        }

        public void UpdateClient(Client updatedClient)
        {
            try
            {
                int index = _clients.FindIndex(client => client.Id == updatedClient.Id);
                if (index != -1)
                {
                    _clients[index] = updatedClient;
                    SaveToJson();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating a client: {ex.Message}");
            }
        }

        // public List<Client> FindClientsByCategory(string clientContractType)
        // {
        //     try
        //     {
        //         return _clients.Where(client => client.Contract.ContractType == clientContractType).ToList();
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"An error occurred while finding clients by category: {ex.Message}");
        //         return new List<Client>(); 
        //     }
        // }
    }
}

