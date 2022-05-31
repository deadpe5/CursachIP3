using Shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public interface IAdminService
    {
        Task CreateSupplier(NewSupplierDTO supplier);
        Task DeleteSupplier(string supplierEmail);
        Task UpdateSupplier(SupplierDTO supplier);
        Task<List<SupplierDTO>> GetAllSuppliersList();
        Task<List<SupplierDTO>> GetSuppliersByName(string supplierName);
        CompanyInfoDTO GetCompanyInfo();
    }
}
