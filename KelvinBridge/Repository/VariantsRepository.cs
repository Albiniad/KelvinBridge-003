using KelvinBridge.Models;

namespace KelvinBridge.Repository
{
    public class VariantsRepository : IRepository<BridgeModel>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BridgeModel> GetAll()
        {
            return new List<BridgeModel>
            {
                new() { VariantName = "Вариант 1", R0x = 0.5 },
                new() { VariantName = "Вариант 2", R0x = 0.6 },
                new() { VariantName = "Вариант 3", R0x = 0.008 },
                new() { VariantName = "Вариант 4", R0x = 0.004 },
                new() { VariantName = "Вариант 5", R0x = 0.3 },
                new() { VariantName = "Вариант 6", R0x = 0.1 },
                new() { VariantName = "Вариант 7", R0x = 0.009 },
                new() { VariantName = "Вариант 8", R0x = 0.2 },
                new() { VariantName = "Вариант 9", R0x = 0.4 },
                new() { VariantName = "Вариант 10", R0x = 0.7 },
                new() { VariantName = "Вариант 11", R0x = 0.002 },
                new() { VariantName = "Вариант 12", R0x = 0.003 },
                new() { VariantName = "Вариант 13", R0x = 0.005 },
                new() { VariantName = "Вариант 14", R0x = 0.8 },
                new() { VariantName = "Вариант 15", R0x = 0.001 },
                new() { VariantName = "Вариант 16", R0x = 0.007 },
                new() { VariantName = "Вариант 17", R0x = 0.006 },
                new() { VariantName = "Вариант 18", R0x = 0.9 }
            };
        }

        public BridgeModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(BridgeModel item)
        {
            throw new NotImplementedException();
        }

        public void Update(BridgeModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
