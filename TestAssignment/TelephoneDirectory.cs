using System.Xml.Linq;

namespace TestAssignment
{
    public class TelephoneDirectory
    {
        private struct DirectoryEntry
        {
            public string FullName;
            public string PhoneNumber;

            public DirectoryEntry(string fullName, string phoneNumber)
            {
                FullName = fullName;
                PhoneNumber = phoneNumber;
            }
        }

        private int _size;
        private readonly LinkedList<DirectoryEntry>[] _hashTable;

        public TelephoneDirectory(int size)
        {
            _size = size;
            _hashTable = new LinkedList<DirectoryEntry>[size];

            for (int i = 0; i < size; i++)
                _hashTable[i] = new();
        }

        public void AddContact(string fullName, string phoneNumber)
        {
            int hash = GetHash(fullName);
            var bucket = _hashTable[hash];

            foreach (var entry in bucket)
                if (entry.FullName == fullName) 
                    return;

            bucket.AddLast(new DirectoryEntry(fullName, phoneNumber));
        }

        public void DeleteContact(string fullName)
        {
            int hash = GetHash(fullName);
            var bucket = _hashTable[hash];

            var node = bucket.First;
            while (node != null)
            {
                if (node.Value.FullName == fullName)
                {
                    bucket.Remove(node);
                    return;
                }

                node = node.Next;
            }
        }

        public void EditPhoneNumber(string fullName, string newPhoneNumber)
        {
            int hash = GetHash(fullName);
            var bucket = _hashTable[hash];

            var node = bucket.First;
            while (node != null)
            {
                if (node.Value.FullName == fullName)
                {
                    var updatedEntry = new DirectoryEntry(node.Value.FullName, newPhoneNumber);
                    node.Value = updatedEntry;

                    return;
                }

                node = node.Next;
            }
        }

        public string FindPhoneNumber(string fullName)
        {
            int hash = GetHash(fullName);
            var bucket = _hashTable[hash];

            foreach (var entry in bucket)
                if (entry.FullName == fullName)
                    return entry.PhoneNumber;

            return string.Empty;
        }

        public void PrintContacts()
        {
            Console.WriteLine("Contacts list");
            foreach (var bucket in _hashTable)
            {
                foreach (var entry in bucket)
                {
                    Console.WriteLine($"{entry.FullName} : {entry.PhoneNumber}");
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
