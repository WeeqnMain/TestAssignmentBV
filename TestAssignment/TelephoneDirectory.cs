namespace TestAssignment
{
    public class TelephoneDirectory
    {
        private int _size;
        private readonly LinkedList<KeyValuePair<string, string>>[] _hashTable;

        public TelephoneDirectory(int size)
        {
            _size = size;
            _hashTable = new LinkedList<KeyValuePair<string, string>>[size];

            for (int i = 0; i < size; i++)
                _hashTable[i] = new();
        }

        public void AddContact(string fullName, string phoneNumber)
        {
            int hash = GetHash(fullName);
            var bucket = _hashTable[hash];

            foreach (var pair in bucket)
                if (pair.Key == fullName) 
                    return;

            bucket.AddLast(new KeyValuePair<string, string>(fullName, phoneNumber));
        }

        public void DeletePhoneNumber(string fullName)
        {
            EditPhoneNumber(fullName, string.Empty);
        }

        public void EditPhoneNumber(string fullName, string newPhoneNumber)
        {
            int hash = GetHash(fullName);
            var bucket = _hashTable[hash];

            foreach (var pair in bucket)
            {
                if (pair.Key == fullName)
                {
                    bucket.AddLast(new KeyValuePair<string, string>(fullName, newPhoneNumber));
                    bucket.Remove(pair);
                    break;
                }
            }
        }

        public string FindPhoneNumber(string fullName)
        {
            int hash = GetHash(fullName);
            var bucket = _hashTable[hash];

            foreach (var pair in bucket)
                if (pair.Key == fullName)
                    return pair.Value;

            return string.Empty;
        }

        public void PrintContacts()
        {
            foreach (var bucket in _hashTable)
            {
                foreach (var pair in bucket)
                {
                    Console.WriteLine($"{pair.Key} : {pair.Value}");
                }
            }
        }

        private int GetHash(string key)
        {
            int hash = 0;
            foreach (char c in key)
                hash += c;

            return hash % _size;
        }
    }
}
