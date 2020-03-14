using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace RHPDEntity
{
  public  class AddProductEntity
    {
        private int product_id;

        public int Product_id
        {
            get { return product_id; }
            set { product_id = value; }
        }

        public double StockQty { get; set; }
        public double GSServe { get; set; }


        private string product_name;

        public string Product_name
        {
            get { return product_name; }
            set { product_name = value; }
        }

        private string product_desc;

        public string Product_desc
        {
            get { return product_desc; }
            set { product_desc = value; }
        }

        private string short_product_desc;

        public string Short_product_desc
        {
            get { return short_product_desc; }
            set { short_product_desc = value; }
        }

        private string admin_remarks;

        public string Admin_remarks
        {
            get { return admin_remarks; }
            set { admin_remarks = value; }
        }

        private int product_cost;

        public int Product_cost
        {
            get { return product_cost; }
            set { product_cost = value; }
        }


        private string product_code;

        public string Product_code
        {
            get { return product_code; }
            set { product_code = value; }
        }

        private int category_code;

        public int Category_code
        {
            get { return category_code; }
            set { category_code = value; }
        }
       

        private int addedby;

        public int Addedby
        {
            get { return addedby; }
            set { addedby = value; }
        }

        private int isactive;
        public int Isactive
        {
            get { return isactive; }
            set { isactive = value; }
        }

        private DateTime modifiedon;

        public DateTime Modifiedon
        {
            get { return modifiedon; }
            set { modifiedon = value; }
        }

        private DateTime addedon;


        public DateTime Addedon
        {
            get { return addedon; }
            set { addedon = value; }

        }
        private int modificationby;

        public int Modificationby
        {
            get { return modificationby; }
            set { modificationby = value; }
        }

        private int categoryid;

        public int Categoryid
        {
            get { return categoryid; }
            set { categoryid = value; }
        }
      
        private string _Cat;
        public string Cat
        {
            get { return _Cat; }
            set { _Cat = value; }
        }

        private string _Productunit;
        public string Productunit
        {
            get { return _Productunit; }
            set { _Productunit = value; }
        }
    }


    

    }
