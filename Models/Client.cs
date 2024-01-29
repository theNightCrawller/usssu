// main classa clienta 
namespace app
{
    public class Client
    {
        private readonly int _id;
        private string _companyName;
        private string _address;
        // tutaj ten interjes pozwala ci na wpierdalanie roznych klass contractów
        private IContract _contract;

        public Client(int id, string companyName, string address, IContract contract)
        {
            _id = id;
            CompanyName = companyName;
            Address = address;
            Contract = contract;
        }

        public int Id => _id;

        public string CompanyName
        {
            get => _companyName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(CompanyName), "Company name cannot be null or empty");
                }
                _companyName = value;
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Address cannot be null or empty", nameof(Address));
                }
                _address = value;
            }
        }

        public IContract Contract
        {
            get => _contract;
            set => _contract = value ?? throw new ArgumentNullException(nameof(Contract), "Contract cannot be null");
        }

        public override string ToString()
        {
            return $"ID: {_id}, Company Name: {_companyName}, Address: {_address}, Contract: {_contract?.GetContractDetails() ?? "No Contract"}";
        }
    }
}
