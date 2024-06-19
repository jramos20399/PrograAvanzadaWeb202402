using BackEnd.Model;

namespace BackEnd.Services.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierModel> GetSuppliers();
        SupplierModel GetSupplier(int id);
    }
}
