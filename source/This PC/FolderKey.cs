namespace ThisPC
{
    public class FolderKey
    {
        private readonly RootKey RootKey;

        public string Key { get; }

        public FolderKey(string key, RootKey rootKey)
        {
            RootKey = rootKey;
            Key = key;
        }

        public bool Exists
        {
            get => RootKey.HasSubKey(Key);
            set
            {
                if (value)
                    Add();
                else
                    Remove();
            }
        }

        public void Add()
        {
            if (!Exists) RootKey.AddSubKey(Key);
        }

        public void Remove()
        {
            if (Exists) RootKey.RemoveSubKey(Key);
        }
    }
}
