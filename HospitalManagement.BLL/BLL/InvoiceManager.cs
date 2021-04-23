using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.Repository.Repository;

namespace HospitalManagement.BLL.BLL
{
    public class InvoiceManager
    {
        InvoiceRepository _invoiceRepository = new InvoiceRepository();
        public bool Add(Invoice invoice)
        {
            return _invoiceRepository.Add(invoice);
        }

        public bool Delete(int id)
        {
            return _invoiceRepository.Delete(id);
        }
        public bool Update(Invoice invoice)
        {
            return _invoiceRepository.Update(invoice);
        }
        public List<Invoice> GetAll()
        {
            return _invoiceRepository.GetAll();
        }
        public Invoice GetById(int id)
        {
            return _invoiceRepository.GetById(id);
        }
    }
}
