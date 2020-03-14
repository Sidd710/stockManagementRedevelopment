using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RHPDDalc;
using RHPDEntity;
using System.Data;

namespace RHPDComponent
{
  public  class AdddepuComp
    {
      AddDepuDalc objadddepu = new AddDepuDalc();
      public int insertcomponent(AddDepuEntity objentity)
      {
          try
          {
              int r;
              AddDepuDalc objadddepu = new AddDepuDalc();

              r = objadddepu.insertdalc(objentity);
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
              AddDepuDalc objAdddepuy = new AddDepuDalc();
              dt3 = new DataTable();
              dt3 = objAdddepuy.GriddisplayDALC();
              return dt3;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataSet selectDATA(string action, int id)
      {
          DataSet dt3;

          try
          {
              AddDepuDalc objAdddepuy = new AddDepuDalc();
              dt3 = objAdddepuy.selectDATA(action,id);
              return dt3;
          }
          catch (Exception)
          {
              throw;
          }
      }
      public Int32 updatecomponent(AddDepuEntity objentity)
      {

          try
          {
              int r;
              AddDepuDalc objadddepu = new AddDepuDalc();
              r=objadddepu.UpdateProductCAteDALC(objentity);
              return r;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public void ActiveInactivate(AddDepuEntity objentity)
      {

          try
          {
            
              AddDepuDalc objadddepu = new AddDepuDalc();
              objadddepu.UpdateProductCAteDALCactive(objentity);

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
              AddDepuDalc objadddepot = new AddDepuDalc();
              string code = objadddepot.generateProductcode();
              return code;
          }
          catch (Exception)
          {

              throw;
          }
      }


      public bool Ischeckparent()
      {
          try
          {
              AddDepuDalc objadddepot = new AddDepuDalc();

             return objadddepot.checkparentid();
              
              
          }
          catch (Exception)
          {

              throw;
          }
      }

       public void removeParent()
        {
            try
            {
                AddDepuDalc objadddepot = new AddDepuDalc();

                 objadddepot.removeParent();


            }
            catch (Exception)
            {

                throw;
            }
        }




    }


}
