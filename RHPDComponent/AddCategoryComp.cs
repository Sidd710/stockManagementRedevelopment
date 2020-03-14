using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using RHPDDalc;
using RHPDEntity;
using System.Data;

namespace RHPDComponent
{
    public  class AddCategoryComp
    {
      AddcategoryDalc objAddcategory;
      public int insertComponent(AddCategoryEntity objentity)
      {
          try
          {
              int r;
              objAddcategory = new AddcategoryDalc();
             
              r = objAddcategory.insertdalc(objentity);
              return r;
          }
          catch (Exception)
          {

              throw;
          }

      }


      public DataTable GridDisplayComponent()
      {
         DataTable dt3;

          try
          {
              objAddcategory = new AddcategoryDalc();
              dt3 = new DataTable();
              dt3 = objAddcategory.GriddisplayDALC();
              return dt3;
          }
          catch (Exception)
          {

              throw;
          }
      }



      public Int32 updateComponent(AddCategoryEntity objentity)
      {
          int r;
          try
          {
              
              AddcategoryDalc objAddcategory = new AddcategoryDalc();
              r=objAddcategory.UpdateProductCAteDALC(objentity);
              return r;
          }
          catch (Exception)
          {

              throw;
          }

      }

      public void ActiveInactivateCategory(AddCategoryEntity objentity)
      {

          try
          {

              AddcategoryDalc objadddepu = new AddcategoryDalc();
              objadddepu.UpdateCAteDALCactiveinactive(objentity);

          }
          catch (Exception)
          {

              throw;
          }
      }


      public DataTable getrecord()
      {
          try
          {
              DataTable dt;
              AddcategoryDalc objcategorytype = new AddcategoryDalc();
              dt = objcategorytype.DropdowndisplayDALC();
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public int insertComponent(CategoryMasterEntity objentity)
      {
          try
          {
              int r;
              AddcategoryDalc objcategorymaster = new AddcategoryDalc();
              r = objcategorymaster.insertDalc(objentity);
              return r;
          }
          catch (Exception)
          {

              throw;
          }

      }

      public string getCode()
      {
          try
          {
              AddcategoryDalc objaddpro = new AddcategoryDalc();
              string code = objaddpro.generateProductcode();
              return code;
          }
          catch (Exception)
          {

              throw;
          }
      }


      public DataTable getparentid()
      {
          try
          {
              DataTable dt = new DataTable();
              AddcategoryDalc objaddpro = new AddcategoryDalc();
              dt = objaddpro.DropdowndisplayparentcategoryDALC();
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }



      public DataTable GridDisplayMasterCategory()
      {
          DataTable dt3;

          try
          {
              objAddcategory = new AddcategoryDalc();
              dt3 = new DataTable();
              dt3 = objAddcategory.GriddisplayCategoryMasterDALC();
              return dt3;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public int updateCategoryMasterComponent(CategoryMasterEntity objentity)
      {
          int r;
          try
          {

              AddcategoryDalc objAddcategory = new AddcategoryDalc();
              r= objAddcategory.UpdateCategorymasterDALC(objentity);
              return r;

          }
          catch (Exception)
          {

              throw;
          }

      }
      public void ActiveInactivateCategoryMaster(CategoryMasterEntity objentity)
      {

          try
          {

              AddcategoryDalc objadddepu = new AddcategoryDalc();
              objadddepu.UpdateMasterCAtDALCactiveinactive(objentity);

          }
          catch (Exception)
          {

              throw;
          }
      }
    }
}
