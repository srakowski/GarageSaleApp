using System.Collections.Generic;
using GarageSaleApp.Domain;
using System.IO;

namespace GarageSaleApp.UwpApp.DataAccess
{
    class FileGarageSaleEventRepository : IGarageSaleEventRepository
    {
        public IEnumerable<GarageSaleEvent> Events => throw new System.NotImplementedException();

        public void Add(GarageSaleEvent entity)
        {

            var fn = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "file.txt");

            File.WriteAllText(fn, "hello world");
        }
    }
}
