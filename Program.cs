using System;

namespace app
{
    class Program
    {
        static void Main()
        {
            ClientManager clientManager = new ClientManager();

            while (true)
            {
                Console.WriteLine("Enter an option:");
                Console.WriteLine("1. Add a new client");
                Console.WriteLine("2. Display all Clients");
                Console.WriteLine("3. Find a client by ID");
                Console.WriteLine("4. Delete a client");
                Console.WriteLine("5. Update a client");
                Console.WriteLine("0. Exit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    clientManager.ReadFromJson();
                    continue;
                }
                try
                {
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Exiting the program...");
                            Environment.Exit(0);
                            break;

                        case 1:

                            Console.WriteLine("Adding a new client...");

                                Console.Write("ID: ");
                                int clientIdInput = int.Parse(Console.ReadLine());


                                if (clientManager.FindClientById(clientIdInput) != null)
                                {
                                    Console.WriteLine($"A client with ID {clientIdInput} already exists. IDs must be unique.");
                                }
                                else
                                {
                                    Console.Write("Company Name: ");
                                    string companyName = Console.ReadLine();

                                    Console.Write("Address: ");
                                    string address = Console.ReadLine();


                                    Console.WriteLine("Select a contract type:");
                                    Console.WriteLine("1. Shipping Contract");
                                    Console.WriteLine("2. Warehouse Lease Contract");
                                    Console.WriteLine("3. Route Planning Contract");

                                    int contractChoice = int.Parse(Console.ReadLine());

                                    IContract contract = null;

                                    switch (contractChoice)
                                    {
                                        case 1:
                                            Console.WriteLine("Enter Shipping Route:");
                                            string shippingRoute = Console.ReadLine();

                                            Console.WriteLine("Enter Shipping Cost:");
                                            decimal shippingCost = decimal.Parse(Console.ReadLine());

                                            Console.WriteLine("Enter Delivery Start Date (yyyy-MM-dd):");
                                            DateTime deliveryStartDate = DateTime.Parse(Console.ReadLine());

                                            contract = new ShippingContract(shippingRoute, shippingCost, deliveryStartDate);
                                            break;

                                        case 2:

                                            Console.WriteLine("Enter Warehouse Location:");
                                            string warehouseLocation = Console.ReadLine();

                                            Console.WriteLine("Enter Monthly Lease Cost:");
                                            decimal monthlyLeaseCost = decimal.Parse(Console.ReadLine());

                                            Console.WriteLine("Enter Lease Start Date (yyyy-MM-dd):");
                                            DateTime leaseStartDate = DateTime.Parse(Console.ReadLine());

                                            contract = new WarehouseLeaseContract(warehouseLocation, monthlyLeaseCost, leaseStartDate);

                                            break;
                                        case 3:

                                            Console.WriteLine("Enter Route Planner Name:");
                                            string routePlannerName = Console.ReadLine();

                                            Console.WriteLine("Enter Planning Fee:");
                                            decimal planningFee = decimal.Parse(Console.ReadLine());

                                            Console.WriteLine("Enter Planning Period in Months:");
                                            int planningPeriodInMonths = int.Parse(Console.ReadLine());

                                            contract = new RoutePlanningContract(routePlannerName, planningFee, planningPeriodInMonths);
                                            break;

                                        default:
                                            Console.WriteLine("Invalid contract choice.");
                                            break;
                                    }

                                    if (contract != null)
                                    {
                                        Client newClient = new Client(clientIdInput, companyName, address, contract);

                                        clientManager.AddClient(newClient);

                                        Console.WriteLine("Client added successfully.");
                                    }
                                }
                            
                          
                            break;

                        case 2:
                            Console.WriteLine("Displaying all clients...");
                            clientManager.ReadFromJson();
                            break;

                        case 3:
                            Console.WriteLine("Finding a client by ID...");
                            Console.Write("Enter client ID: ");
                            int clientId = int.Parse(Console.ReadLine());
                            Client foundClient = clientManager.FindClientById(clientId);
                            if (foundClient != null)
                            {
                                Console.WriteLine($"Found client: {foundClient}");
                            }
                            else
                            {
                                Console.WriteLine($"Client with ID {clientId} not found.");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Deleting a client...");
                            Console.Write("Enter client ID to delete: ");
                            int clientIdToDelete = int.Parse(Console.ReadLine());
                            Console.WriteLine(clientIdToDelete);
                            clientManager.DeleteClient(clientIdToDelete);
                            break;
                        case 5:
                            Console.WriteLine("Updating a client...");
                            Console.Write("Enter client ID to update: ");
                            int clientIdToUpdate = int.Parse(Console.ReadLine());

                            Client existingClient = clientManager.FindClientById(clientIdToUpdate);

                            if (existingClient != null)
                            {
                                Console.Write("Enter updated company name: ");
                                string updatedCompanyName = Console.ReadLine();

                                Console.Write("Enter updated address: ");
                                string updatedAddress = Console.ReadLine();


                                Console.WriteLine("Select a contract type:");
                                Console.WriteLine("1. Shipping Contract");
                                Console.WriteLine("2. Warehouse Lease Contract");
                                Console.WriteLine("3. Route Planning Contract");

                                int contractChoice = int.Parse(Console.ReadLine());

                                IContract contract = null;

                                switch (contractChoice)
                                {
                                    case 1:
                                        Console.WriteLine("Enter Shipping Route:");
                                        string shippingRoute = Console.ReadLine();

                                        Console.WriteLine("Enter Shipping Cost:");
                                        decimal shippingCost = decimal.Parse(Console.ReadLine());

                                        Console.WriteLine("Enter Delivery Start Date (yyyy-MM-dd):");
                                        DateTime deliveryStartDate = DateTime.Parse(Console.ReadLine());

                                        contract = new ShippingContract(shippingRoute, shippingCost, deliveryStartDate);
                                        break;

                                    case 2:

                                        Console.WriteLine("Enter Warehouse Location:");
                                        string warehouseLocation = Console.ReadLine();

                                        Console.WriteLine("Enter Monthly Lease Cost:");
                                        decimal monthlyLeaseCost = decimal.Parse(Console.ReadLine());

                                        Console.WriteLine("Enter Lease Start Date (yyyy-MM-dd):");
                                        DateTime leaseStartDate = DateTime.Parse(Console.ReadLine());

                                        contract = new WarehouseLeaseContract(warehouseLocation, monthlyLeaseCost, leaseStartDate);

                                        break;
                                    case 3:

                                        Console.WriteLine("Enter Route Planner Name:");
                                        string routePlannerName = Console.ReadLine();

                                        Console.WriteLine("Enter Planning Fee:");
                                        decimal planningFee = decimal.Parse(Console.ReadLine());

                                        Console.WriteLine("Enter Planning Period in Months:");
                                        int planningPeriodInMonths = int.Parse(Console.ReadLine());

                                        contract = new RoutePlanningContract(routePlannerName, planningFee, planningPeriodInMonths);
                                        break;

                                    default:
                                        Console.WriteLine("Invalid contract choice.");
                                        break;
                                }

                                Client updatedClient = new Client(clientIdToUpdate, updatedCompanyName, updatedAddress, contract);

                                Console.WriteLine($"Updating client: {existingClient.Id}");
                                clientManager.UpdateClient(updatedClient);
                            }
                            else
                            {
                                Console.WriteLine($"Client with ID {clientIdToUpdate} not found.");
                            }
                            break;


                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
                catch (Exception)
                {
                    throw new Exception(":(");
                }
            }
        }
    }
}
