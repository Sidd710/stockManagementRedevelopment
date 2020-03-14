using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace RHPDEntity
{
   public class AddCategoryEntity
    {
       private int id;
    

public int Id
{
  get { return id; }
  set { id = value; }
}
              
       
private int category_code ;  

public int Category_code
{
  get { return category_code; }
  set { category_code = value; }
}
   
   
 private string category_name   ;
   
public string Category_name
{
  get { return category_name; }
  set { category_name = value; }
}
   
   private string category_type;
   
public string Category_type
{
  get { return category_type; }
  set { category_type = value; }
}
   
   
 private string category_desc  ;
 
public string Category_desc
{
  get { return category_desc; }
  set { category_desc = value; }
}
  private int? parentcategory_id ;
  
public int? Parentcategory_id
{
  get { return parentcategory_id; }
  set { parentcategory_id = value; }
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
    }

   public class CategoryMasterEntity {

       private int id;

       public int Id
       {
           get { return id; }
           set { id = value; }
       }

       private string category_code;

       public string Category_code
       {
           get { return category_code; }
           set { category_code = value; }
       }

       private string category_name;

       public string Category_name
       {
           get { return category_name; }
           set { category_name = value; }
       }


       private int category_typeid;

       public int Category_typeid
       {
           get { return category_typeid; }
           set { category_typeid = value; }
       }

       private string categorydesc;

       public string Categorydesc
       {
           get { return categorydesc; }
           set { categorydesc = value; }
       }

       private int? parentcategory_id;

       public int? Parentcategory_id
       {
           get { return parentcategory_id; }
           set { parentcategory_id = value; }
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
   }

}
