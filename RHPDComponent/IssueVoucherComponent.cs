using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RHPDDalc;
using RHPDEntity;
using System.Data;

namespace RHPDComponent
{
  public  class IssueVoucherComponent
    {
      public int InsertIssueVoucher(IssueVocuherEntity objIssueVoucherEntity)
      {
          try
          {
              int r;
              IssueVoucherDalc objIssueVoucherDalc = new IssueVoucherDalc();

              r = objIssueVoucherDalc.insertdalc(objIssueVoucherEntity);
              return r;
          }
          catch (Exception)
          {

              throw;
          }
      }


      public int UpdateIssueVoucherCompo(IssueVocuherEntity objIssueVoucherEntity)
      {
          int r;
          try
          {

              IssueVoucherDalc objUpdateIssueVoucher = new IssueVoucherDalc();
              r = objUpdateIssueVoucher.UpdateIssuevoucherDALC(objIssueVoucherEntity);
              return r;
          }
          catch (Exception)
          {

              throw;
          }
      }


     

      public void InActiveIssueVoucher(IssueVocuherEntity objIssueVoucherEntity)
      {

          try
          {

              IssueVoucherDalc objInActiveIssueVoucher = new IssueVoucherDalc();
              objInActiveIssueVoucher.InActiveIssueVoucher(objIssueVoucherEntity);

          }
          catch (Exception)
          {

              throw;
          }
      }

      public DataTable SelectAll()
      {
          DataTable dt3;

          try
          {
              IssueVoucherDalc objSelectAllIssueVocuher = new IssueVoucherDalc();

              dt3 = new DataTable();
              dt3 = objSelectAllIssueVocuher.SelectAll();
              return dt3;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public DataTable SelectById(int IssueVoucherid)
      {
          try
          {
              DataTable dt = new DataTable();
              IssueVoucherDalc objSelectById = new IssueVoucherDalc();

              dt = objSelectById.SelectByID(IssueVoucherid);
              return dt;

          }
          catch (Exception)
          {

              throw;
          }

      }

      public DataTable SelectIndentWise(IssueVocuherEntity objIssueVoucherEntity)
      {
          DataTable dt3;

          try
          {
              IssueVoucherDalc objIndentWiseIssueVocuher = new IssueVoucherDalc();
              dt3 = new DataTable();
              dt3 = objIndentWiseIssueVocuher.SelectStcktransfrIndentWise(objIssueVoucherEntity);
              return dt3;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable SelectIssuedVoucherfromto(IssueVocuherEntity objIssueVoucherEntity)
      {
          DataTable dt3;

          try
          {
              IssueVoucherDalc objIndentWiseIssueVocuher = new IssueVoucherDalc();
              dt3 = new DataTable();
              dt3 = objIndentWiseIssueVocuher.SelectIssuedVoucherfromto(objIssueVoucherEntity);
              return dt3;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataSet SelectIssuedetailview(IssueVocuherEntity objIssueVoucherEntity)
      {
          DataSet dt3;
          try
          {
              IssueVoucherDalc objIndentWiseIssueVocuher = new IssueVoucherDalc();
              dt3 = new DataSet();
              dt3 = objIndentWiseIssueVocuher.SelectIssuedetailview(objIssueVoucherEntity);
              return dt3;
          }
          catch (Exception)
          {
              throw;
          }
      }
    }
}
