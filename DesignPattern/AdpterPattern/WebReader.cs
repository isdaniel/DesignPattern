namespace AdapterPattern
{
    /// <summary>
    /// 從網路上讀取要的資料
    /// </summary>
    public class WebReader : IReadData
    {
        public string GetJsonData(string parameter)
        {
            string result = string.Empty;
            //實作網路讀取
            return result;
        }
    }
}