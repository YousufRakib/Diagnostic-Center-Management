using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.DatabaseContext.DatabaseContext;

namespace HospitalManagement.Repository.Repository
{
    public class InvoiceRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Invoice invoice)
        {
            _dbContext.Invoices.Add(invoice);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Invoice aInvoice = _dbContext.Invoices.FirstOrDefault((c => c.id == id));
            _dbContext.Invoices.Remove(aInvoice);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Invoice invoice)
        {
            Invoice aInvoice = _dbContext.Invoices.FirstOrDefault((c => c.id == invoice.id));
            if (aInvoice != null)
            {
                aInvoice.patientId = invoice.patientId;
                aInvoice.testId = invoice.testId;
                aInvoice.billId = invoice.billId;
                aInvoice.price = invoice.price;
                aInvoice.testResult = invoice.testResult;
                aInvoice.testRoom = invoice.testRoom;
                aInvoice.referenceRange = invoice.referenceRange;
                aInvoice.unit= invoice.unit;
                aInvoice.status = invoice.status;
                aInvoice.createdAt = invoice.createdAt;
            }
            return _dbContext.SaveChanges() > 0;
        }

        public List<Invoice> GetAll()
        {
            return _dbContext.Invoices.ToList();
        }
        public Invoice GetById(int id)
        {
            return _dbContext.Invoices.FirstOrDefault((c => c.id == id));
        }
    }
}
