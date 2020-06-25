


using System;

namespace Lab6.Models.ViewModels
{
    public class ProductDetailsViewModel {

        public ProductDetailsViewModel(StockItem stockItem, Supplier supplier, Person person, InvoiceLine invoiceLine) {

            StockItemID = stockItem.StockItemID;
            
            

            StockItemName = stockItem.StockItemName;
            

            Size = stockItem.Size;
            
            RecommendedRetailPrice = stockItem.RecommendedRetailPrice;

            TypicalWeightPerUnit = stockItem.TypicalWeightPerUnit;

            LeadTimeDays = stockItem.LeadTimeDays;

            ValidFrom = stockItem.ValidFrom;

            //Supplier info
            SupplierID = supplier.SupplierID;
            SupplierName = supplier.SupplierName;
            PhoneNumber = supplier.PhoneNumber;
            FaxNumber = supplier.FaxNumber;
            WebsiteURL = supplier.WebsiteURL;
            PrimaryContactPersonID = supplier.PrimaryContactPersonID;

            //Person info
            PersonID = person.PersonID;
            FullName = person.FullName;

            //InvoiceLine info
            Quantity = invoiceLine.Quantity; 


        }

       
        
     

        
        //StockItem Variables
        public int StockItemID { get; private set; }
        public string StockItemName { get; private set; }

        public string Size { get; private set; }
        public decimal? RecommendedRetailPrice { get; private set; }
        public decimal TypicalWeightPerUnit { get; private set; }
        public int LeadTimeDays { get; private set; }
        public DateTime ValidFrom { get; private set; }

        //Supplier Varaibles 
        public int SupplierID { get; private set; }
        public string SupplierName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string FaxNumber { get; private set; }
        public string WebsiteURL { get; private set; }
        public int PrimaryContactPersonID { get; private set; }

        //Person Variables 

        public int PersonID { get; private set; }
        public string FullName { get; private set; }

        //Invoice

        public int Quantity { get; private set; }

        public decimal GrossSales { get; private set; }
        public decimal GrossProfit { get; private set;  }

    }
}