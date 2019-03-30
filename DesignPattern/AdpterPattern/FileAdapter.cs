namespace AdapterPattern
{
    public class FileAdapter : IReadData
    {
        public string GetJsonData(string parameter)
        {
            var reader = new FileReader();
            return reader.Read(parameter);
        }
    }
}